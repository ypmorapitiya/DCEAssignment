import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  simulationForm: FormGroup;
  isShowChart:boolean ;
  errorMessage:string;
  chartData:any;
  isError:boolean;
  isloading:boolean;
  averageWinProbability:number;
  isShowAvgProb:boolean
  constructor(private formBuilder: FormBuilder, private api : ApiService) {
    this.isloading=false;
    this.isShowAvgProb=false;
    this.averageWinProbability=0;
    this.isShowChart =false;
    this.errorMessage='';
    this.isError=false;
    this.simulationForm = this.formBuilder.group({
      numberOfSimulations: [0],
      isSwitch: [false],
    });
  }

  onSubmit() {
    const formData = this.simulationForm.value;
    console.log(formData);
    this.isloading=true;
    this.api.simulate(formData).subscribe({
      next: (res: any) => {      
        if(res.isSucess){
        this.chartData = res.probabilities;
        this.averageWinProbability=this.roundToTwoDecimalPlaces(res.averageWinProbability);
        this.isShowChart=true;
        this.isError=false;
        this.isShowAvgProb=true;
        }
        else{
          this.isShowChart=false;
          this.isError=true;
          this.errorMessage = res.errorMessage
          this.isShowAvgProb=false;
        }
        this.isloading=false;
      },
      error: (err: any) => {
        this.isShowChart=false;
        this.isError=true;
        this.errorMessage = "serer error"
        this.isloading=false;
        this.isShowAvgProb=false;
      },
    });
    
  }
  
  roundToTwoDecimalPlaces(value: number): number {
   let rounded= value?  parseFloat(value.toFixed(2)) : 0 ;
    return rounded;
  }
}
