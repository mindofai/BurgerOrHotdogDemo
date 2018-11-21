using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using System.Linq;

namespace BurgerOrHotdog.Services
{
    public class CustomVisionService
    {
        private string endpoint => "<endpoint here>";
        private string predictionKey => "<predictionKey here>";
        private Guid projectId => new Guid("<projectId here>");
        private Guid iterationId => new Guid("<iterationId here>");

        public async Task<string> PredictImage(string url)
        {
            try
            {
                CustomVisionPredictionClient client = new CustomVisionPredictionClient()
                {
                    ApiKey = predictionKey,
                    Endpoint = endpoint
                };

                var result = await client.PredictImageUrlAsync(projectId, new ImageUrl(url), iterationId: iterationId);

                if (result != null)
                {
                    return result.Predictions.OrderByDescending(p => p.Probability).FirstOrDefault().TagName;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
