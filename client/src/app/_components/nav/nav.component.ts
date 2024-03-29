import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../../_models/user';
import { AccountService } from '../../_services/account/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  model: any = {}


  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(data => {
      this.router.navigateByUrl('/members');
    }, err => {
      console.log(err);
      this.toastr.error(err.error);
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
