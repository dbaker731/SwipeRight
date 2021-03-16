import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../_models/user';
import { AccountService } from '../../_services/account/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public accountService: AccountService) { }

  model: any = {}


  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(data => {
      console.log(data);
    }, err => {
      console.log(err);
    })
    console.log(this.model);
  }

  logout() {
    this.accountService.logout();
  }

}
