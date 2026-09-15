---
title: Tłumacz prezentacji zasilany sztuczną inteligencją
linktitle: Tłumacz zasilany AI
type: docs
weight: 20
url: /pl/nodejs-java/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja oparta na AI
- Wielojęzyczna prezentacja
- Wielojęzyczny slajd
- Tłumaczenie prezentacji
- Tłumaczenie slajdu
- Funkcje sterowane AI
- Możliwości AI
- Agent AI
- Klient sieciowy
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI dzięki Aspose.Slides dla Node.js. Lokalizuj pliki PPT, PPTX i ODP zachowując układ — szybkie i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides jest potężnym API do programowego zarządzania prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API tłumaczenia prezentacji dla wielojęzycznej treści slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości sztucznej inteligencji, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność tę udostępnia klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesaiagent/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) do połączenia się z API OpenAI.

Aspose.Slides obsługuje komunikację, analizuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując pierwotny układ slajdu i formatowanie.

{{% alert color="info" title="Note" %}}

Należy zauważyć, że API OpenAI jest usługą płatną, więc musisz założyć konto i podać swój klucz API, używając wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Wczytaj prezentację do tłumaczenia.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Zainicjalizuj SlidesAIAgent z klientem AI.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Przetłumacz prezentację na język japoński.
    aiAgent.translate(presentation, "japanese");

    // Zapisz przetłumaczoną prezentację jako PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jeśli jednak wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) – na przykład aby skonfigurować ważne ustawienia, takie jak proxy, lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) albo innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) dla lepszego zarządzania zasobami i wydajności – możesz przekazać własną instancję `HttpURLConnection` podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz i wstępnie skonfiguruj instancję HttpURLConnection (np. z niestandardowymi limitami czasu, ustawieniami proxy itp.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Przykład Azure OpenAI**

Możesz skonfigurować tłumacza, aby używał Twojej instalacji Azure OpenAI za pomocą [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Ten fragment kodu demonstruje tłumaczenie prezentacji przy użyciu Twojego punktu końcowego Azure OpenAI. Zastąp wartości zastępcze nazwą wdrożenia, kluczem API i adresem URL punktu końcowego.

## **Kluczowe korzyści**

API tłumaczenia prezentacji Aspose.Slides oferuje rozwiązanie oparte na sztucznej inteligencji, umożliwiające tworzenie wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy jednoczesnym zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem, czy profesjonalistą biznesowym, to API pozwala tworzyć angażujące, lokalizowane prezentacje dla globalnych odbiorców – zwiększając zasięg i poprawiając komunikację.