import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Bus } from 'src/app/models/data/bus';
import { NotifyService } from 'src/app/services/common/notify.service';
import { BusService } from 'src/app/services/data/bus.service';
import { BusType } from 'src/app/shared/app-constant';

@Component({
  selector: 'app-bus-list',
  templateUrl: './bus-list.component.html',
  styleUrls: ['./bus-list.component.css']
})
export class BusListComponent implements OnInit {
  buses: Bus[] = [];
  dataSource: MatTableDataSource<Bus> = new MatTableDataSource(this.buses);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columns = ['name', 'number', 'busType', 'capacity'];
  constructor(
    private busService: BusService,
    private notifyService: NotifyService
  ) {}
  getTypeName(v: number) {
    return BusType[v];
  }
  
  ngOnInit(): void {
    this.busService.get().subscribe({
      next: (r) => {
        this.buses = r;
        console.log(this.buses);
        this.dataSource.data = this.buses;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {
        this.notifyService.message('Cannot load buses');
        console.log(err.message | err);
      },
    });
  }
}
