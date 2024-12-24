using Newtonsoft.Json;

namespace ViewModel
{
	public class ResponseViewModel
	{
		public int statusCode { get; set; }

		
		public string Message { get; set; }
		public object Data { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}


	}
}
