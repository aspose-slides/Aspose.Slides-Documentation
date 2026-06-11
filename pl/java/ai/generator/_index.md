---
title: Generator wielojęzycznych slajdów zasilany sztuczną inteligencją
linktitle: Generator zasilany sztuczną inteligencją
type: docs
weight: 40
url: /pl/java/ai/generator/
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
- Java
- Aspose.Slides
description: "Generuj wielojęzyczne slajdy z tekstu za pomocą Aspose.Slides dla Javy. Zastosuj swój szablon i wyeksportuj dopracowane zestawy do PowerPoint i OpenDocument. Dowiedz się więcej."
---
## **Wprowadzenie**

Aspose.Slides wprowadza nową funkcję opartą na sztucznej inteligencji, generator prezentacji, który umożliwia programistom automatyczne tworzenie dobrze ustrukturyzowanych prezentacji PowerPoint na podstawie prostych danych tekstowych, takich jak opisy tematów, streszczenia, cytaty lub wypunktowania.

Użytkownicy mogą dostosować poziom szczegółowości treści oraz opcjonalnie zastosować własny szablon prezentacji, aby określić wygląd wizualny.

Obecnie generator prezentacji AI strukturyzuje treść za pomocą bloków tekstowych, list wypunktowanych i tabel. Generowanie obrazów nie jest jeszcze obsługiwane; jednak obrazy można łatwo dodać później przy użyciu narzędzi Aspose.Slides lub ręcznie.

Wynikiem jest pełna prezentacja PowerPoint, którą można używać bezpośrednio lub wyeksportować do dowolnego formatu obsługiwanego przez API Aspose.Slides. Chociaż generator dostarcza wysokiej jakości rezultaty, może być konieczna niewielka edycja końcowa, aby spełnić określone wymagania.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych modeli AI; zamiast tego integruje się z zewnętrznymi usługami AI przez internet. Integracja ta jest obsługiwana przez klasę [SlidesAIAgent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesaiagent/), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaiwebclient/) do komunikacji z modelem AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/), który łączy się z API OpenAI, lub dostarczyć własną implementację [IAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaiwebclient/), aby współpracować z innym dostawcą AI lub modelem językowym. Aspose.Slides zarządza całą komunikacją z usługą AI i przetwarza odpowiedzi AI w celu generowania slajdów. Należy pamiętać, że API OpenAI jest usługą płatną, więc do korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) wymagane są konto i klucz API.

## **Zacznijmy kodować**

### **Przykład 1**

Ten przykład pokazuje, jak wygenerować prezentację na temat Aspose.Slides przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/).

```java
// Utwórz instancję OpenAIWebClient, wbudowanej implementacji klienta webowego OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Utwórz instancję SlidesAIAgent, która zapewnia dostęp do funkcji zasilanych AI.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Zdefiniuj instrukcję generowania prezentacji.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Wygeneruj prezentację ze średnią ilością treści na podstawie instrukcji.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Zapisz wygenerowaną prezentację na lokalnym dysku jako plik PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Przykład 2**

Poniższy przykład demonstruje przeciążenia metody [generatePresentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). W tym przypadku używana jest zewnętrznie zarządzana instancja [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) oraz `master presentation` użytkownika.

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — na przykład przy użyciu [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) lub [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) w celu lepszego zarządzania zasobami i wydajności — możesz podać własną instancję [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/).

```java
// Przekaż HttpURLConnection do konstruktora OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Utwórz instancję SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Zdefiniuj instrukcję generowania prezentacji.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Wczytaj główną prezentację z lokalnego dysku, aby użyć jej jako szablonu projektu.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Wygeneruj szczegółową prezentację, używając instrukcji i szablonu głównej prezentacji.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Zapisz wygenerowaną prezentację jako PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Kluczowe korzyści**

Nowy generator prezentacji AI w Aspose.Slides zapewnia szybki i elastyczny sposób tworzenia ustrukturyzowanych zestawów slajdów na podstawie prostych zapytań tekstowych. Dzięki obsłudze własnych szablonów i zewnętrznie zarządzanych instancji [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), może być bezproblemowo integrowany z szeroką gamą aplikacji.

Typowe przypadki użycia obejmują tworzenie prezentacji marketingowych, materiałów edukacyjnych, raportów dla klientów oraz wewnętrznych zestawów slajdów. Chociaż generowanie obrazów nie jest jeszcze obsługiwane, narzędzie już teraz zapewnia solidną bazę do automatyzacji tworzenia prezentacji, a w przyszłości spodziewane są dalsze ulepszenia.