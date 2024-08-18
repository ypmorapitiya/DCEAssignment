import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }

  simulate(data:any){
    return this.http.post("https://localhost:7109/simulate", data);
  }
}
