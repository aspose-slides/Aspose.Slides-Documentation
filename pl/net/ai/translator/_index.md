---
title: Tłumacz Prezentacji zasilany SI
linktitle: Tłumacz zasilany SI
type: docs
weight: 20
url: /pl/net/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja zasilana AI
- Wielojęzyczna prezentacja
- Wielojęzyczny slajd
- Tłumaczenie prezentacji
- Tłumaczenie slajdu
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
description: "Tłumacz slajdy PowerPoint za pomocą SI wykorzystując Aspose.Slides dla .NET. Lokalizuj pliki PPT, PPTX i ODP zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides jest potężnym API do programowego zarządzania prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje napędzane sztuczną inteligencją – takie jak [Presentation Translation API](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/) do wielojęzycznej zawartości slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność tę udostępnia klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) do połączenia z API OpenAI lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) aby używać innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną zawartość, zachowując oryginalny układ i formatowanie slajdów.

{{% alert color="primary" %}}
Należy pamiętać, że API OpenAI jest usługą płatną, więc będziesz musiał założyć konto i podać swój klucz API podczas używania wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```csharp
// Załaduj prezentację do przetłumaczenia.
using var presentation = new Presentation("sample.pptx");
// Utwórz klienta AI przy użyciu OpenAIWebClient, określając swój model i klucz API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);
// Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
var aiAgent = new SlidesAIAgent(aiWebClient);
// Przetłumacz prezentację na język japoński.
await aiAgent.TranslateAsync(presentation, "japanese");
// Zapisz przetłumaczoną prezentację jako PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), obsługując jej cykl życia i usuwanie automatycznie. Jednakże, jeśli wolisz samodzielnie zarządzać [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), na przykład przy użyciu [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) dla lepszego zarządzania zasobami i wydajności, możesz podać własną instancję `HttpClient` podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Załóż, że masz instancję IHttpClientFactory (np. wstrzykniętą poprzez wstrzykiwanie zależności).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides jest powszechnie używany w środowiskach synchronicznych. Aby to wspierać, klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent/) oferuje zarówno metody synchroniczne, jak i asynchroniczne – pozwalając wybrać podejście najlepiej pasujące do przepływu pracy aplikacji.

## **Kluczowe korzyści**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/) oferuje rozwiązanie oparte na SI do udostępniania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem czy profesjonalistą biznesowym, to API umożliwia tworzenie angażujących, lokalizowanych prezentacji dla globalnej publiczności – zwiększając zasięg i poprawiając komunikację.