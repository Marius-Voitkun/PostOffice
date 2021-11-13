import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Parcel } from '../models/parcel';
import { GenericService } from './generic.service';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ParcelsService extends GenericService<Parcel> {

  constructor(http: HttpClient) {
    super(http, "https://localhost:44308/api/Parcels");
  }

  override getAll(parcelLockerId: number | null = null): Observable<Parcel[]> {
    return this.http.get<Parcel[]>(this.url
        + (parcelLockerId != null ? `?parcelLockerId=${parcelLockerId}` : ''))
      .pipe(
        catchError(super.handleError)
      );
  }
}
