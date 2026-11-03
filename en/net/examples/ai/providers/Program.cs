using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

internal static partial class Program
{
    private const string Prompt = "Create a short English presentation about the water cycle. Cover evaporation, condensation and precipitation. Use ordinary text slides with a title and a short paragraph. No charts, tables or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return raw JSON without Markdown code fences or commentary.";

    private static async Task<int> RunExample(string[] args)
    {
        try
        {
            string baseUrl = Required("SLIDES_AI_BASE_URL");
            string model = Required("SLIDES_AI_MODEL");
            string key = Required("SLIDES_AI_API_KEY");
            bool configuredOnly = args.Contains("--configured-only");
            int completed = 0;
            if (!configuredOnly)
            {
                using var defaultHttp = Http("default");
                using var defaultClient = new AsposeAIWebClient(defaultHttp);
                using IPresentation deck = await new SlidesAIAgent(defaultClient).GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief);
                VerifyGenerated(deck, "default-generated.pptx");
                completed++;
            }
            using var configuredHttp = Http("configured");
            using var configuredClient = new OpenAICompatibleWebClient(model, key, baseUrl, configuredHttp);
            using IPresentation configuredDeck = await new SlidesAIAgent(configuredClient).GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief);
            VerifyGenerated(configuredDeck, "configured-generated.pptx");
            completed++;
            Require(Requests.Any(r => r.Provider == "configured" && r.StatusCode == 200), "Configured provider did not return a model response.");
            Report(new { providers_checked = completed, configured_provider_succeeded = true, reopened_text_matches = true, requests = Requests.ToArray() });
            return 0;
        }
        catch (Exception error)
        {
            int exit = error is OperationCanceledException ? 4 : error is HttpRequestException ? 3 : 2;
            File.WriteAllText("error.json", JsonSerializer.Serialize(new { error_type = error.GetType().Name, requests = Requests.ToArray(), exit_code = exit }));
            Console.Error.WriteLine("AI example failed: " + error.GetType().Name + ". Check configuration and provider access.");
            return exit;
        }
    }
}
