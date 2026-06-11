---
title: Generator wielojęzycznych slajdów napędzany AI
linktitle: Generator napędzany AI
type: docs
weight: 40
url: /pl/net/ai/generator/
keywords:
- wielojęzyczna prezentacja
- wielojęzyczny slajd
- generator prezentacji AI
- generator slajdów AI
- funkcja napędzana AI
- agent AI
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Generuj wielojęzyczne slajdy z tekstu przy użyciu Aspose.Slides dla .NET. Zastosuj swój szablon i wyeksportuj dopracowane zestawy do PowerPoint i OpenDocument. Dowiedz się więcej."
---
## **Wstęp**

Aspose.Slides wprowadza nową funkcję opartą na sztucznej inteligencji, Generator prezentacji, który umożliwia programistom automatyczne tworzenie dobrze zbudowanych prezentacji PowerPoint z prostych danych tekstowych, takich jak opisy tematów, streszczenia, cytaty lub wypunktowania.

Użytkownicy mogą dostosować poziom szczegółowości treści oraz opcjonalnie zastosować własny szablon prezentacji, aby określić wygląd wizualny.

Obecnie Generator prezentacji AI strukturyzuje treść przy użyciu bloków tekstowych, list punktowanych i tabel. Generowanie obrazów nie jest jeszcze obsługiwane; jednak obrazy można łatwo dodać później przy użyciu narzędzi Aspose.Slides lub ręcznie.

Wynikiem jest pełna prezentacja PowerPoint, którą można używać bez zmian lub wyeksportować do dowolnego formatu obsługiwanego przez API Aspose.Slides. Choć generator dostarcza wyniki wysokiej jakości, może być konieczna drobna korekta po wygenerowaniu, aby spełnić określone wymagania.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych modeli AI; zamiast tego integruje się z zewnętrznymi usługami AI przez internet. Integracja jest obsługiwana przez klasę [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent/), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) do komunikacji z modelem AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/), który łączy się z API OpenAI, lub dostarczyć własną implementację [IAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/iaiwebclient/) do współpracy z innym dostawcą AI lub modelem językowym. Aspose.Slides zarządza całą komunikacją z usługą AI i przetwarza odpowiedzi AI w celu generowania slajdów. Należy pamiętać, że API OpenAI jest usługą płatną, więc potrzebne są konto i klucz API przy używaniu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).

## **Zacznijmy kodować**

### **Przykład 1**

Ten przykład pokazuje, jak wygenerować prezentację na temat Aspose.Slides przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Utwórz instancję OpenAIWebClient, wbudowanej implementacji klienta sieciowego OpenAI.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Utwórz instancję SlidesAIAgent, który zapewnia dostęp do funkcji napędzanych AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Zdefiniuj instrukcję generowania prezentacji.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Wygeneruj prezentację o średniej ilości treści na podstawie instrukcji.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Zapisz wygenerowaną prezentację na lokalnym dysku jako plik PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Przykład 2**

Poniższy przykład pokazuje przeciążenia metody [GeneratePresentation](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent/generatepresentation/). W tym przypadku używana jest zewnętrznie zarządzana instancja [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) oraz `master presentation` użytkownika.

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), automatycznie obsługując jej cykl życia i usuwanie. Jednakże, jeśli wolisz samodzielnie zarządzać [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — na przykład przy użyciu [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) w celu lepszego zarządzania zasobami i wydajności — możesz przekazać własną instancję [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) przy konstruowaniu [OpenAIWebClient](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Utwórz zewnętrznie zarządzaną instancję HttpClient.
using var httpClient = new HttpClient();

// Przekaż HttpClient do konstruktora OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Utwórz instancję SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Zdefiniuj instrukcję generowania prezentacji.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Załaduj główną prezentację z lokalnego dysku, aby użyć jej jako szablonu projektu.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Wygeneruj szczegółową prezentację używając instrukcji i szablonu głównego.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Zapisz wygenerowaną prezentację jako plik PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Warto zauważyć, że wielu klientów używa Aspose.Slides w kontekstach synchronicznych. Aby to wspierać, klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/net/aspose.slides.ai/slidesaiagent/) udostępnia zarówno metody synchroniczne, jak i asynchroniczne, umożliwiając wybór podejścia najlepiej pasującego do przepływu pracy Twojej aplikacji.

## **Kluczowe korzyści**

Nowy Generator prezentacji AI w Aspose.Slides zapewnia szybki i elastyczny sposób tworzenia uporządkowanych zestawów slajdów z prostych poleceń tekstowych. Dzięki obsłudze własnych szablonów, zewnętrznie zarządzanych instancji [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) oraz zarówno synchronicznych, jak i asynchronicznych przepływów pracy, można go bezproblemowo zintegrować z szeroką gamą aplikacji.

Typowe scenariusze użycia obejmują tworzenie prezentacji marketingowych, materiałów edukacyjnych, raportów dla klientów oraz wewnętrznych zestawów slajdów. Chociaż generowanie obrazów nie jest jeszcze obsługiwane, narzędzie już oferuje solidną bazę do automatyzacji tworzenia prezentacji, a w przyszłości planowane są dalsze ulepszenia.