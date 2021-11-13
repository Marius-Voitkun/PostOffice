import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ParcelLocker } from '../models/parcel-locker';
import { GenericService } from './generic.service';

@Injectable({
  providedIn: 'root'
})
export class ParcelLockersService extends GenericService<ParcelLocker> {

  constructor(http: HttpClient) {
    super(http, "https://localhost:44308/api/ParcelLockers");
  }
}
