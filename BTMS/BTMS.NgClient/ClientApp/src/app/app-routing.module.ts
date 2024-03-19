import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusListComponent } from './components/bus/bus-list/bus-list.component';
import { BusRouteListComponent } from './components/busRoute/bus-route-list/bus-route-list.component';
import { FareListComponent } from './components/fare/fare-list/fare-list.component';

const routes: Routes = [
  {path:'bus-list',component:BusListComponent},
  {path:'busRoute-list',component:BusRouteListComponent},
  {path:'fare-list',component:FareListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
