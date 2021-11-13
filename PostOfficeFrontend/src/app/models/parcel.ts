export interface Parcel {
  id: number;
  receiverName: string;
  receiverPhone: string;
  weightInKg: number;
  info: string;
  parcelLockerId: number | null;
}