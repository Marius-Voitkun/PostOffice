import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ParcelLockersComponent } from './components/parcel-lockers/parcel-lockers.component';
import { ParcelsComponent } from './components/parcels/parcels.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'parcels',
    component: ParcelsComponent
  },
  {
    path: 'parcel-lockers',
    component: ParcelLockersComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
