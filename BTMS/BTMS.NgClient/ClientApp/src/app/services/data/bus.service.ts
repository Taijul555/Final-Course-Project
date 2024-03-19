import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bus } from 'src/app/models/data/bus';
import { apiBaseUrl } from 'src/app/shared/app-constant';

@Injectable({
  providedIn: 'root'
})
export class BusService {

  constructor(private http: HttpClient) {}
  get(): Observable<Bus[]> {
    return this.http.get<Bus[]>(`${apiBaseUrl}/ api/Buses`);
  }
  getById(id: number): Observable<Bus> {
    return this.http.get<Bus>(`${apiBaseUrl}/api/Buses/${id}`);
  }
  post(data: Bus): Observable<Bus> {
    return this.http.post<Bus>(`${apiBaseUrl}/api/Buses`, data);
  }
}
