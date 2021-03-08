import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private accountAservice: AccountService) { }

  model: any = {}
  loggedIn: boolean;

  ngOnInit(): void {
  }

  login() {
    this.accountAservice.login(this.model).subscribe(data => {
      console.log(data);
    }, err => {
      console.log(err);
      this.loggedIn = true;
    })
    console.log(this.model);
  }

}
