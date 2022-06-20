import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Iprovider } from  './provider';


@Component({
  templateUrl: './provider-list.component.html',
  styleUrls: ['./provider-list.component.css']
})
export class ProviderListComponent implements OnInit, OnDestroy {
  pageTitle = 'Provider List';
  imageWidth = 50;
  imageMargin = 2;
  showImage = false;
  errorMessage = '';
  sub!: Subscription;

  private _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }
  

  constructor() {}

  providers : Iprovider[] = [
    {
      "providerId": 1,
      "firstName": "Kathy",
      "lastName": "Worthen",
      "npiNumber": "06092022",
      "businessAddress": "Greenlanes Jax , FL, 32256",
      "telephoneNumber":"904-001-1234",
      "emailAddress":"abc@uhc.com"
  },
  {
    "providerId": 2,
    "firstName": "David",
    "lastName": "Warren",
    "npiNumber": "06092022",
    "businessAddress": "Greenlanes Jax , FL, 32256",
    "telephoneNumber":"904-001-1234",
    "emailAddress":"abc@uhc.com"
  }
]

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
   
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

 /*  onRatingClicked(message: string): void {
    this.pageTitle = 'Product List: ' + message;
  } */
}
