---
title: Tłumacz prezentacji oparty na AI
linktitle: Tłumacz oparty na AI
type: docs
weight: 20
url: /pl/net/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja oparta na AI
- Prezentacja wielojęzyczna
- Slajd wielojęzyczny
- Tłumaczenie prezentacji
- Tłumaczenie slajdów
- Funkcje napędzane AI
- Możliwości AI
- Agent AI
- Klient sieciowy
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI z Aspose.Slides dla .NET. Lokalizuj pliki PPT, PPTX i ODP, zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API umożliwiające programowe zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak [Presentation Translation API](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/) umożliwiające wielojęzyczną treść slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, lecz integruje się z zewnętrznymi modelami AI przez Internet. Funkcjonalność tę udostępnia klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) do połączenia z API OpenAI lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując oryginalny układ i formatowanie slajdu.

{{% alert color="info" %}}
Należy pamiętać, że API OpenAI jest płatną usługą, więc musisz utworzyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Wczytaj prezentację do przetłumaczenia.
using var presentation = new Presentation("sample.pptx");

// Utwórz klienta AI za pomocą OpenAIWebClient, podając model i klucz API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Przetłumacz prezentację na język japoński.
await aiAgent.TranslateAsync(presentation, "japanese");

// Zapisz przetłumaczoną prezentację jako PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), automatycznie obsługując jej cykl życia i usuwanie. Jednakże, jeśli wolisz samodzielnie zarządzać [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) – na przykład przy użyciu [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) w celu lepszego zarządzania zasobami i wydajności – możesz przekazać własną instancję `HttpClient` podczas konstrukcji [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Użyj HttpClienta, którym zarządzasz samodzielnie - na przykład utworzonego przez IHttpClientFactory
// wstrzykniętego poprzez wstrzykiwanie zależności.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides jest powszechnie używany w środowiskach synchronicznych. Aby to wspierać, klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent/) oferuje zarówno metody synchroniczne, jak i asynchroniczne – co pozwala wybrać podejście najlepiej pasujące do przepływu pracy Twojej aplikacji.

## **Kluczowe korzyści**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/) oferuje rozwiązanie oparte na AI umożliwiające dostarczanie wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś deweloperem, edukatorem, czy profesjonalistą biznesowym, to API pozwala tworzyć angażujące, lokalizowane prezentacje dla globalnych odbiorców – zwiększając zasięg i poprawiając komunikację.