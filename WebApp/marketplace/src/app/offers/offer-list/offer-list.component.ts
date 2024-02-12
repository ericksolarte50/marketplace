import { Component, OnInit } from '@angular/core';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { OfferModel } from 'src/app/core/marketplace-api/models/offer.model';
import { TempPage } from 'src/app/core/models/TempPage.model';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.scss']
})
export class OfferListComponent implements OnInit {

  pageSize = 10;
  listOffers: OfferModel[] = [];
  totalPages;
  totalPagesNum: number = 0;

  listPages: TempPage[] = [];

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
          console.log(result);
          this.listOffers = result.info;

          for (let i = 1; i <= this.pageSize; i++) {
            let tempPage = new TempPage(i, false, '', pageNumber);
            if(i == pageNumber ){
              tempPage.label = 'active';
            }
            
            this.listPages.push(tempPage);
          }

          // console.log("this.listPages");
          // console.log(this.listPages);

          //this.totalPages = result.totalPages;
        }
        , error: (error) => {
          console.log("error: " + error);
        }
      })
  }

}
