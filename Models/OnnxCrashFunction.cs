using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.OnnxRuntime.Tensors;
using Newtonsoft.Json;

namespace ONNXCrash.Models
{
    public class CrashData
    {
        //public int InsuranceId { get; set; }
        public int Age { get; set; }
        public int Bmi { get; set; }
        public int NumChildren { get; set; }
        public int Male { get; set; }
        public int Smoker { get; set; }
        public int Region_Northwest { get; set; }
        public int Region_Southeast { get; set; }
        public int Region_Southwest { get; set; }

        public Tensor<int> AsTensor()
        {
            int[] data = new int[]
            {
                Age, Bmi, NumChildren, Male, Smoker, Region_Northwest, Region_Southeast, Region_Southwest
            };
            int[] dimensions = new int[] { 1, 29 };
            return new DenseTensor<int>(data, dimensions);
        }
    }
}



////We'll just use our regular controller that inherits from the Controller class.  But inside that controller, we still need to bring in the instance of an InferenceSession, which we will use in the action we are creating

///// <summary>
///// Summary description for Class1
///// </summary>
//public static class OnnxCrashFunction
//{
//	[FunctionName("OnnxCrashFunction")]
//	public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWritter log)
//	{
//		log.Info("C# HTTP tricger function processed a request. )

//		string requestBody = new StreamReader(req.Body).ReadToEnd();
//		dynamic data = JsonConvert.Deserializeobject(requestBody);

//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int
//		//int





//		float YearBuilt data?.modelp.YearBuilt;
//		float GrLivArea data?.modelp.GrLivArea,
//		float Fireplaces data?.modelp.Firepleces
//		float SaleCondition data?.modelp.SaleCondition;
//		float BldgType data?.modelp.BldgType;

//		string ONNXMode 1 Path - "G:\\GitHub\\ONNX-Examples\\Python Model\\HousePriceMode1.onnx


//		var inputTensor = new DenseTensor<float>(new float[] { YearBuilt, GrLivArea, Fireplaces, SaleCondition, BldgType }, new int[] { 1, 29 });
//		var input = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor<float>("feature_input", inputTensor) };
//		var session = new InferenceSession(ONNXModelPath);
//		var output = session.Run(input);
//		var result = output.ToArray()[0].AsTenor<float>().ToArray<float>()[0];
//		var resultMessage = new { houseprice = result };
//		return new JsonResult(resultMessage);

//	}
//}




