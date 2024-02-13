import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TempPage } from 'src/app/core/models/TempPage.model';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {

  @Input()
  numberPages: number;
  
  @Output()
  changePageEvent: EventEmitter<number> = new EventEmitter();
  
  listPages: TempPage[] = [];
  
  lblDisabledBackBtn: string = '';
  lblDisabledNextBtn: string = '';
  
  currentPage: number = 1;
  start: number = 1;
  end: number = 10;
  defaultStart: number = 1;
  defaultEnd: number = 10;
  incrementPage: number = 5;

  ngOnInit(): void {
    this.refreshListpage();
  }

  backBtn() {
    let tmpPage = this.currentPage;
    tmpPage--;

    if (tmpPage < 1) {
      this.currentPage = 1;
    } else {
      this.currentPage = tmpPage;
      this.refreshListpage();
    }
  }

  nextBtn() {
    let tmpPage = this.currentPage;
    tmpPage++;

    if (tmpPage > this.numberPages) {
      this.currentPage = this.numberPages;
    } else {
      this.currentPage = tmpPage;
      this.refreshListpage();
    }
  }

  findPage(positionPage: number){
    this.currentPage = positionPage;
    this.refreshListpage();
  }

  initPage(){
    this.start = this.defaultStart;
    this.end = this.defaultEnd;
    this.currentPage = 1;
    this.refreshListpage();
  }

  lastPage(){
    this.start = this.numberPages - 10;
    this.end = this.numberPages;
    this.currentPage = this.numberPages;
    this.refreshListpage();
  }

  refreshListpage() {

    if (this.currentPage === this.end && this.currentPage !== this.numberPages) {
      this.start = this.currentPage - this.incrementPage;
      
      let tempEnd = this.currentPage + this.incrementPage;      
      if (tempEnd >= this.numberPages) {
        this.end = this.numberPages;
      } else {
        this.end = tempEnd;
      }
    }

    if (this.currentPage !== 1 && this.currentPage === this.start) {
      let tempStart = this.currentPage - this.incrementPage;
      if (tempStart <= 0) {
        this.start = 1;
      } else {
        this.start = tempStart;
      }

      this.end = this.end - this.incrementPage;
    }

    this.listPages = [];
    for (let i = this.start; i <= this.end; i++) {
      let tempPage = new TempPage(i, '', this.currentPage);
      if (i == this.currentPage) {
        tempPage.label = 'active';
      }

      this.listPages.push(tempPage);
    }

    this.lblDisabledBackBtn = this.currentPage === 1 ? 'disabled' : '';
    this.lblDisabledNextBtn = this.currentPage === this.numberPages ? 'disabled' : '';

    // console.log("FIN :: this.start: " + this.start + " this.currentPage: " + this.currentPage + " this.end: " + this.end);
    this.changePageEvent.emit(this.currentPage);
  }
}
