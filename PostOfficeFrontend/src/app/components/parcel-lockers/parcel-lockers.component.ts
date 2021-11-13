import { Component, OnInit } from '@angular/core';
import { ParcelLocker } from 'src/app/models/parcel-locker';
import { ParcelLockersService } from 'src/app/services/parcel-lockers.service';

@Component({
  selector: 'parcel-lockers',
  templateUrl: './parcel-lockers.component.html',
  styleUrls: ['./parcel-lockers.component.css']
})
export class ParcelLockersComponent implements OnInit {

  parcelLockers: ParcelLocker[] = [];

  id: number = 0;
  code: string = '';
  maxParcelsCount: number = 0;
  town: string = '';

  editMode: boolean = false;

  constructor(private parcelLockersService: ParcelLockersService) { }

  ngOnInit(): void {
    this.parcelLockersService.getAll().subscribe(
      parcelLockers => {
        this.parcelLockers = parcelLockers;
      },
      error => {
        alert('Nepavyko įkelti paštomatų sąrašo.');
      }
    );
  }

  addParcelLocker(parcelLocker: ParcelLocker): void {
    this.parcelLockersService.add(parcelLocker).subscribe(
      parcelLockerFromApi => {
        this.parcelLockers.push(parcelLockerFromApi);
        this.sortParcelLockersByCode();
      },
      error => {
        alert('Nepavyko pridėti paštomato.');
      }
    );
  }

  editParcelLocker(id: number): void {
    this.editMode = true;

    const parcelLocker = this.parcelLockers.filter(pl => pl.id === id)[0];

    this.id = parcelLocker.id;
    this.code = parcelLocker.code;
    this.maxParcelsCount = parcelLocker.maxParcelsCount;
    this.town = parcelLocker.town;
  }

  saveChanges(parcelLocker: ParcelLocker): void {
    this.parcelLockersService.update(parcelLocker.id, parcelLocker).subscribe(
      () => {
        const index = this.parcelLockers.map(pl => pl.id).indexOf(parcelLocker.id);
        this.parcelLockers[index] = parcelLocker;
        this.sortParcelLockersByCode();

        this.editMode = false;
      },
      error => {
        alert('Nepavyko išsaugoti pakeitimų.');
      }
    );
  }

  deleteParcelLocker(id: number): void {
    this.parcelLockersService.delete(id).subscribe(
      () => {
        const index = this.parcelLockers.map(pl => pl.id).indexOf(id);
        this.parcelLockers.splice(index, 1);
      },
      error => {
        alert('Nepavyko ištrinti paštomato.');
      }
    );
  }

  private sortParcelLockersByCode(): void {
    this.parcelLockers.sort((a, b) => {
      const nameA = a.code.toLowerCase();
      const nameB = b.code.toLowerCase();

      return nameA.localeCompare(nameB);
    });
  }
}
