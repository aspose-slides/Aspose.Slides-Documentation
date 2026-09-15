---
title: Tłumacz prezentacji zasilany AI
linktitle: Tłumacz zasilany AI
type: docs
weight: 20
url: /pl/net/ai/translator/
keywords:
- Translator prezentacji AI
- Translator slajdów AI
- Funkcja oparta na AI
- Wielojęzyczna prezentacja
- Wielojęzyczny slajd
- Tłumaczenie prezentacji
- Tłumaczenie slajdów
- Funkcje napędzane AI
- Możliwości AI
- Agent AI
- Klient internetowy
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI i Aspose.Slides dla .NET. Lokalizuj pliki PPT, PPTX i ODP zachowując układ — szybko i przyjazny dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API do programowego zarządzania prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na AI – takie jak [Presentation Translation API](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/) umożliwiające wielojęzyczną zawartość slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych funkcji AI, lecz integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność ta jest udostępniana za pomocą klasy [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent), która wykorzystuje implementację interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/), aby połączyć się z API OpenAI, lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/), aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, analizuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując pierwotny układ i formatowanie slajdów.

{{% alert color="info" title="Uwaga" %}}
Zauważ, że API OpenAI jest usługą płatną, więc musisz założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński, używając wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) z określonym [modelem](https://platform.openai.com/docs/models) OpenAI.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Wczytaj prezentację do przetłumaczenia.
using var presentation = new Presentation("sample.pptx");

// Utwórz klienta AI przy użyciu OpenAIWebClient, określając model i klucz API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Przetłumacz prezentację na język japoński.
await aiAgent.TranslateAsync(presentation, "japanese");

// Zapisz przetłumaczoną prezentację jako PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), automatycznie obsługując jej cykl życia i usuwanie. Jednak jeśli wolisz samodzielnie zarządzać [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) – np. używając [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) w celu lepszego zarządzania zasobami i wydajności – możesz przekazać własną instancję `HttpClient` podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Użyj własnego HttpClient, którym zarządzasz samodzielnie - na przykład takiego utworzonego przez IHttpClientFactory
// wstrzyknięty przez wstrzykiwanie zależności.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides jest powszechnie używany w środowiskach synchronicznych. Aby to wspierać, klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent/) oferuje zarówno metody synchroniczne, jak i asynchroniczne – umożliwiając wybór podejścia najlepiej pasującego do przepływu pracy aplikacji.

### **Przykład Azure OpenAI**

Aspose.Slides for .NET obsługuje dostawców zgodnych z OpenAI, w tym Azure OpenAI. Możesz skonfigurować tłumacz, aby używał własnego wdrożenia Azure za pomocą [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Ten fragment pokazuje tłumaczenie prezentacji przy użyciu twojego punktu końcowego Azure OpenAI. Zamień wartości zastępcze na nazwę wdrożenia, klucz API i URL punktu końcowego.

## **Kluczowe korzyści**

API [Presentation Translation](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/) firmy Aspose.Slides zapewnia rozwiązanie oparte na AI do tworzenia wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem czy specjalistą biznesowym, to API umożliwia tworzenie atrakcyjnych, lokalizowanych prezentacji dla globalnej publiczności – zwiększając zasięg i poprawiając komunikację.