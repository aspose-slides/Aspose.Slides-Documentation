---
title: Wielojęzyczny generator slajdów zasilany sztuczną inteligencją
linktitle: Generator zasilany sztuczną inteligencją
type: docs
weight: 40
url: /pl/nodejs-java/ai/generator/
keywords:
- wielojęzyczna prezentacja
- wielojęzyczny slajd
- generator prezentacji AI
- generator slajdów AI
- funkcja zasilana AI
- agent AI
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Generuj wielojęzyczne slajdy z tekstu przy użyciu Aspose.Slides dla Node.js. Zastosuj własny szablon i wyeksportuj dopracowane zestawy do PowerPoint i OpenDocument. Dowiedz się więcej."
---
## **Wprowadzenie**

Aspose.Slides wprowadza nową funkcję napędzaną sztuczną inteligencją, Presentation Generator, która umożliwia programistom automatyczne tworzenie dobrze zorganizowanych prezentacji PowerPoint z prostych danych tekstowych, takich jak opisy tematów, streszczenia, cytaty lub wypunktowania.

Użytkownicy mogą dostosować poziom szczegółowości treści oraz opcjonalnie zastosować własny szablon prezentacji, aby określić wygląd wizualny.

Obecnie AI Presentation Generator strukturyzuje treść przy użyciu bloków tekstowych, list wypunktowanych i tabel. Generowanie obrazów nie jest jeszcze obsługiwane; jednak obrazy można łatwo dodać później przy użyciu narzędzi Aspose.Slides lub ręcznie.

Wynikiem jest pełna prezentacja PowerPoint, którą można używać bez zmian lub wyeksportować do dowolnego formatu obsługiwanego przez API Aspose.Slides. Choć generator generuje wysokiej jakości wyniki, mogą być konieczne niewielkie korekty po wygenerowaniu, aby spełnić określone wymagania.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych modeli AI; zamiast tego integruje się z zewnętrznymi usługami AI poprzez internet. Integrację tę obsługuje klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesaiagent/).

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/), który łączy się z API OpenAI. Aspose.Slides zarządza całą komunikacją z usługą AI i przetwarza odpowiedzi AI w celu generowania slajdów. Należy pamiętać, że API OpenAI jest usługą płatną, więc wymagane są konto oraz klucz API przy używaniu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).

## **Zacznijmy kodować**

### **Przykład 1**

Ten przykład pokazuje, jak wygenerować prezentację na temat Aspose.Slides przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Utwórz instancję OpenAIWebClient, wbudowanej implementacji klienta internetowego OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Utwórz instancję SlidesAIAgent, który zapewnia dostęp do funkcji napędzanych sztuczną inteligencją.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Zdefiniuj instrukcję generowania prezentacji.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Wygeneruj prezentację o średniej ilości treści na podstawie instrukcji.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Zapisz wygenerowaną prezentację na lokalnym dysku jako plik PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Przykład 2**

Poniższy przykład pokazuje przeciążenia metody [generatePresentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). W tym przypadku używana jest zewnętrznie zarządzana instancja [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) oraz `master presentation` użytkownika.

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednakże, jeśli wolisz zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) samodzielnie — na przykład przy użyciu [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) lub [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) w celu lepszego zarządzania zasobami i wydajności — możesz dostarczyć własną instancję [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Przekaż HttpURLConnection do konstruktora OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Utwórz instancję SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Zdefiniuj instrukcję generowania prezentacji.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Załaduj prezentację główną z lokalnego dysku, aby użyć jej jako szablon projektu.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Wygeneruj szczegółową prezentację przy użyciu instrukcji i szablonu głównego.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Zapisz wygenerowaną prezentację jako PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Kluczowe korzyści**

Nowy Generator prezentacji AI w Aspose.Slides zapewnia szybki i elastyczny sposób tworzenia uporządkowanych zestawów slajdów z prostych zapytań tekstowych. Dzięki obsłudze własnych szablonów i zewnętrznie zarządzanych instancji [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), może być bezproblemowo integrowany z szerokim zakresem aplikacji.

Typowe zastosowania obejmują tworzenie prezentacji marketingowych, materiałów edukacyjnych, raportów dla klientów oraz wewnętrznych zestawów slajdów. Chociaż generowanie obrazów nie jest jeszcze obsługiwane, narzędzie już oferuje solidną bazę do automatyzacji tworzenia prezentacji, a w przyszłości spodziewane są dalsze ulepszenia.