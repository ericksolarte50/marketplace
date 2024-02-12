import { Component, Input, OnInit } from '@angular/core';
import { TempPage } from 'src/app/core/models/TempPage.model';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {

  @Input()
  // offer: OfferModel;
  listPages: TempPage[];

  showBackButton = true;
  showNextButton = true;

  ngOnInit(): void {
    //this.updateVisiblePages();
    console.log("this.listPages")
    console.log(this.listPages)
    // this.showBackButton = this.listPages != null && (this.listPages.length > 0);
    // this.showNextButton = this.listPages != null && (this.listPages.length > 0);
  }
}
