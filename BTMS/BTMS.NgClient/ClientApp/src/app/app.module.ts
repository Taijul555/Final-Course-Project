import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NgMaterialMultilevelMenuModule, MultilevelMenuService } from 'ng-material-multilevel-menu';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BusListComponent } from './components/bus/bus-list/bus-list.component';
import { BusAddComponent } from './components/bus/bus-add/bus-add.component';
import { BusEditComponent } from './components/bus/bus-edit/bus-edit.component';
import { BusRouteListComponent } from './components/busRoute/bus-route-list/bus-route-list.component';
import { BusRouteAddComponent } from './components/busRoute/bus-route-add/bus-route-add.component';
import { BusRouteEditComponent } from './components/busRoute/bus-route-edit/bus-route-edit.component';
import { FareListComponent } from './components/fare/fare-list/fare-list.component';
import { FareAddComponent } from './components/fare/fare-add/fare-add.component';
import { FareEditComponent } from './components/fare/fare-edit/fare-edit.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatCardModule} from '@angular/material/card';
import { BusService } from './services/data/bus.service';
import { BusRouteService } from './services/data/bus-route.service';
import { FareService } from './services/data/fare.service';
import { NotifyService } from './services/common/notify.service';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    BusListComponent,
    BusAddComponent,
    BusEditComponent,
    BusRouteListComponent,
    BusRouteAddComponent,
    BusRouteEditComponent,
    FareListComponent,
    FareAddComponent,
    FareEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSortModule,
    MatPaginatorModule,
    MatInputModule,
    MatTableModule,
    MatSnackBarModule,
    MatCardModule

  ],
  providers: [HttpClient, MultilevelMenuService,BusService,BusRouteService,FareService,NotifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
