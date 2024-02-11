import { Component, OnInit } from '@angular/core';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { OfferModel } from 'src/app/core/marketplace-api/models/offer.model';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.scss']
})
export class OfferListComponent implements OnInit {

  pageSize = 4;
  listOffers: OfferModel[] = [];
  totalPages;
  totalPagesNum: number = 0;

  constructor(private serviceMarcketplace: MarketplaceApiService) {
  }

  ngOnInit(): void {
    this.getListOffers(1);
  }


  private getListOffers(pageNumber: number) {
    this.serviceMarcketplace.getOffers(pageNumber, this.pageSize)
      .subscribe({
        next: (result: any) => {
          console.log("result");
          console.log(result.data);
          this.listOffers = result.data;
          //this.totalPages = result.totalPages;
        }
        , error: (error) => {
          console.log("error: " + error);
        }
      })
  }

}
