import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parcel } from '../models/parcel';
import { GenericService } from './generic.service';

@Injectable({
  providedIn: 'root'
})
export class ParcelsService extends GenericService<Parcel> {

  constructor(http: HttpClient) {
    super(http, "https://localhost:44308/api/Parcels");
  }
}
