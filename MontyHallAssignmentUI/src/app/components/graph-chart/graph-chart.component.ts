import { Component, Input, input, SimpleChanges } from '@angular/core';
import * as Highcharts from 'highcharts';
@Component({
  selector: 'app-graph-chart',
  templateUrl: './graph-chart.component.html',
  styleUrl: './graph-chart.component.css'
})
export class GraphChartComponent {
  @Input() chartData: any; 
  Highcharts: typeof Highcharts = Highcharts;
  chartOptions: Highcharts.Options = {};
  transformedData:any;
  constructor() {}

  ngOnInit() {
   
    console.log(this.chartData)
    this.transformData(this.chartData);
    this.setChartOption(this.chartData);

    
  }

  transformData(apiResponse:any){
    this.transformedData = Object.entries(apiResponse).map(([key, value]) => [
      Number(key),
      value
    ]);
  }

  setChartOption(apiResponse:any){
    this.chartOptions = {
      chart: {
        type: 'line'
      },
      title: {
        text: 'Win Probability of Monty Hall Problem'
      },
      credits: {
        enabled: false
      },
      xAxis: {
        title: {
          text: 'Number of Simulations'
        },
        categories: Object.keys(apiResponse) 
      },
      yAxis: {
        title: {
          text: 'Win Probability'
        },
        min: 0, 
        max: 1, 
        tickInterval: 0.1 
      },
      series: [
        {
          type: 'line',
          name: 'Win Probability',
          data: this.transformedData 
        }
      ]
    };
  }
  ngOnChanges(changes: SimpleChanges) {
    if (changes['chartData']) {
      this.transformData(this.chartData);
      this.setChartOption(this.chartData);
    }
  }
 
}
