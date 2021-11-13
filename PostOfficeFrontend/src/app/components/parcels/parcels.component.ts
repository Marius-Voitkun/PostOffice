import { Component, OnInit } from '@angular/core';
import { Parcel } from 'src/app/models/parcel';
import { ParcelsService } from 'src/app/services/parcels.service';

@Component({
  selector: 'parcels',
  templateUrl: './parcels.component.html',
  styleUrls: ['./parcels.component.css']
})
export class ParcelsComponent implements OnInit {

  parcels: Parcel[] = [];

  id: number = 0;
  receiverName: string = '';
  receiverPhone: string = '';
  weightInKg: number = 0;
  info: string = '';
  parcelLockerId: number | null = null;

  editMode: boolean = false;

  constructor(private parcelsService: ParcelsService) { }

  ngOnInit(): void {
    this.parcelsService.getAll().subscribe(
      parcels => {
        this.parcels = parcels;
      },
      error => {
        alert('Nepavyko įkelti siuntinių sąrašo.');
      }
    );
  }

  addParcel(parcel: Parcel): void {
    this.parcelsService.add(parcel).subscribe(
      parcelFromApi => {
        this.parcels.push(parcelFromApi);
        this.sortParcelsByWeightDesc();
      },
      error => {
        alert('Nepavyko pridėti siuntinio.');
      }
    );
  }

  editParcel(id: number): void {
    this.editMode = true;

    const parcel = this.parcels.filter(p => p.id === id)[0];

    this.id = parcel.id;
    this.receiverName = parcel.receiverName;
    this.receiverPhone = parcel.receiverPhone;
    this.weightInKg = parcel.weightInKg;
    this.info = parcel.info;
    this.parcelLockerId = parcel.parcelLockerId;
  }

  saveChanges(parcel: Parcel): void {
    this.parcelsService.update(parcel.id, parcel).subscribe(
      () => {
        const index = this.parcels.map(p => p.id).indexOf(parcel.id);
        this.parcels[index] = parcel;
        this.sortParcelsByWeightDesc();

        this.editMode = false;
      },
      error => {
        alert('Nepavyko išsaugoti pakeitimų.');
      }
    );
  }

  deleteParcel(id: number): void {
    this.parcelsService.delete(id).subscribe(
      () => {
        const index = this.parcels.map(p => p.id).indexOf(id);
        this.parcels.splice(index, 1);
      },
      error => {
        alert('Nepavyko ištrinti siuntinio.');
      }
    );
  }

  private sortParcelsByWeightDesc() {
    this.parcels.sort((a, b) => b.weightInKg - a.weightInKg);
  }
}
