---
title: "AI-Powered Multilingual Slide Generator"
linktitle: "AI-Powered Multilingual Slide Generator"
type: docs
weight: 40
url: /net/ai/generator/
---

# Aspose.Slides Presentation Translation API: AI-Powered Multilingual Slide Translation

`Aspose.Slides` is a powerful and widely used API for programmatically managing PowerPoint presentations. Beyond creating, editing, and converting slides, it now integrates `AI-driven features`—such as the `Presentation Translation API`. This tool enables fast, accurate translation of presentation content into multiple languages, simplifying global communication. In today’s interconnected world, this feature helps businesses, educators, and professionals effortlessly reach wider audiences without the burden of manual translation.

## How it Works
Aspose.Slides itself does not include built-in AI capabilities; instead, it connects to external AI models over the internet to provide intelligent features. This is done through the new` SlidesAIAgent` class, which interacts with AI services via an implementation of the `IAIWebClient` interface.

You can either use the built-in `OpenAIWebClient`, which connects to OpenAI’s API, or provide your own custom implementation of IAIWebClient if you want to work with a different AI provider or language model.

Aspose.Slides manages all communication with the AI service and intelligently handles the AI’s responses—placing the translated text while preserving the original slide layout and formatting.

Note that the OpenAI API is a paid service, so you will need to create an account and supply your API key when using the built-in `OpenAIWebClient`.


## Example

In this example, we translate a PowerPoint presentation into Japanese using the built-in OpenAIWebClient with a specified OpenAI model.

```csharp
//Load the presentation you want to translate.
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
	//Create an AI client—in this case, an OpenAIWebClient with your chosen model and API key.
	using IAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

	//Initialize the SlidesAIAgent with the AI client.
	SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

	//Translate the presentation to the desired language (e.g., Japanese).
	await aiAgent.TranslateAsync(pres, "japanese");
	
	//Save the translated presentation in your preferred format, such as PDF.
	pres.Save("presentation_jp.pdf", SaveFormat.Pdf);
}
```

By default, the built-in OpenAIWebClient creates and manages its own internal `HttpClient` instance, handling its lifecycle and disposal automatically. However, if you prefer to manage the HttpClient yourself—such as when using an IHttpClientFactory for better resource management and performance—you can provide your own HttpClient instance when constructing the OpenAIWebClient.

```csharp
//Assume you have an IHttpClientFactory instance (e.g., injected via DI)
HttpClient httpClient = httpClientFactory.CreateClient();
using OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey",null, httpClient);
```

It’s important to note that many customers use Aspose.Slides in synchronous contexts. To accommodate this, the SlidesAIAgent class offers both `synchronous` and `asynchronous` methods, allowing you to choose the best approach for your application’s workflow.

## Conclusion

The Aspose.Slides Presentation Translation API offers a powerful, AI-driven solution for multilingual communication through PowerPoint presentations. By automating translation while preserving layout and design integrity, it saves time and reduces errors compared to manual efforts. Whether you're a developer, educator, or business professional, this API empowers you to deliver compelling, localized presentations to diverse audiences worldwide—unlocking new opportunities and enhancing engagement on a global scale.