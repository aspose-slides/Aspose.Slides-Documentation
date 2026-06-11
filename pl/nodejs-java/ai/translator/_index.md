---
title: Tłumacz Prezentacji Zasilany Sztuczną Inteligencją
linktitle: Tłumacz Zasilany Sztuczną Inteligencją
type: docs
weight: 20
url: /pl/nodejs-java/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja zasilana sztuczną inteligencją
- Prezentacja wielojęzyczna
- Slajd wielojęzyczny
- Tłumaczenie prezentacji
- Tłumaczenie slajdów
- Funkcje sterowane AI
- Możliwości AI
- Agent AI
- Klient internetowy
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI i Aspose.Slides dla Node.js. Lokalizuj pliki PPT, PPTX i ODP zachowując układ — szybkie i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API do programowego zarządzania prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji — takie jak API Tłumaczenia Prezentacji dla wielojęzycznej treści slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych funkcji AI, ale integruje się z zewnętrznymi modelami AI przez internet. Ta funkcjonalność jest udostępniona poprzez klasę [SlidesAIAgent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesaiagent/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) do połączenia się z API OpenAI.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując oryginalny układ i formatowanie slajdów.

{{% alert color="primary" %}}
Zwróć uwagę, że API OpenAI jest usługą płatną, więc musisz założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```js
// Załaduj prezentację do przetłumaczenia.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Zainicjuj SlidesAIAgent z klientem AI.
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

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) samodzielnie — głównie aby skonfigurować niezbędne ustawienia, takie jak proxy, lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) lub innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html), dla lepszego zarządzania zasobami i wydajności — możesz dostarczyć własną instancję `HttpURLConnection` przy tworzeniu [OpenAIWebClient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Załóż, że masz wstępnie skonfigurowaną instancję HttpURLConnection (np. z niestandardowymi timeoutami, ustawieniami proxy itp.)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Kluczowe korzyści**

API Tłumaczenia Prezentacji Aspose.Slides oferuje rozwiązanie oparte na sztucznej inteligencji do dostarczania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem, czy profesjonalistą biznesowym, to API umożliwia tworzenie angażujących, lokalizowanych prezentacji dla globalnej publiczności — zwiększając zasięg i poprawiając komunikację.