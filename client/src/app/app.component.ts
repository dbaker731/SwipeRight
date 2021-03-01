import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private accountService: AccountService) {}
  
  title = 'SwipeRight';
  users: any;

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.accountService.getUsers().subscribe(data => {
      this.users = data;
    }, err => {
      console.log(err);
    });
  }

}
