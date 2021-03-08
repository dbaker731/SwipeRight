import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.baseUrl + `users`);
  }

  login (model:any) {
    return this.http.post(this.baseUrl + `account/login`, model);
  }

}
