# Configure an AI Provider

Requires .NET SDK8.0.427 and Aspose.Slides.NET26.10.0 (locked).
Set ASPOSE_LICENSE_PATH to your licensed file; full-content checks need a valid license.
AI requests use the network. No key or model is included.
Run: dotnet run --project Example.csproj --configuration Release
Run the same generation request through the default Aspose client and a caller-configured OpenAI-compatible endpoint. The complete project reads the endpoint, model identifier, API key and timeout from environment variables and saves separate editable results.
Provide a compatible service you are authorized to use and its real model identifier. The compatible client is an adapter, not a bundled AI model. Service authentication, request limits and model fees belong to the chosen provider. The program reports configuration, HTTP and cancellation failures without printing keys; --configured-only skips the default-service demonstration.
Configure SLIDES_AI_BASE_URL, SLIDES_AI_MODEL and SLIDES_AI_API_KEY. Optional SLIDES_AI_TIMEOUT_SECONDS defaults to180.
