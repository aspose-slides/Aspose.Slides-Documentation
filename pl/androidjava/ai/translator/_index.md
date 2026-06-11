---
title: Translator prezentacji z AI
linktitle: Translator z AI
type: docs
weight: 20
url: /pl/androidjava/ai/translator/
keywords:
- Translator prezentacji AI
- Translator slajdów AI
- Funkcja zasilana AI
- Prezentacja wielojęzyczna
- Slajd wielojęzyczny
- Tłumaczenie prezentacji
- Tłumaczenie slajdów
- Funkcje sterowane AI
- Możliwości AI
- Agent AI
- Klient sieciowy
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint za pomocą AI przy użyciu Aspose.Slides dla Androida w Javie. Lokalizuj pliki PPT, PPTX i ODP zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API umożliwiające programowe zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edycji i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API tłumaczenia prezentacji dla wielojęzycznych treści slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości sztucznej inteligencji, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność tę udostępnia klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesaiagent/), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaiwebclient/) do komunikacji z usługami AI.

Możesz używać wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/), aby połączyć się z API OpenAI lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaiwebclient/), aby używać innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując oryginalny układ i formatowanie slajdów.

{{% alert color="primary" %}}
Należy pamiętać, że API OpenAI jest usługą płatną, więc musisz założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) oraz określonego modelu OpenAI [model](https://platform.openai.com/docs/models).

```java
// Załaduj prezentację do tłumaczenia.
Presentation presentation = new Presentation("sample.pptx");

// Utwórz klienta AI przy użyciu OpenAIWebClient, określając model i klucz API.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Zainicjalizuj SlidesAIAgent z klientem AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Przetłumacz prezentację na język japoński.
    aiAgent.translate(presentation, "japanese");

    // Zapisz przetłumaczoną prezentację jako PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — głównie w celu skonfigurowania niezbędnych ustawień, takich jak proxy, lub użycia [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) albo innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html), aby lepiej zarządzać zasobami i wydajnością — możesz dostarczyć własną instancję `HttpURLConnection` podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/).

```java
// Załóż, że masz wstępnie skonfigurowaną instancję HttpURLConnection (np. z własnymi timeoutami, ustawieniami proxy itp.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Kluczowe korzyści**

API tłumaczenia prezentacji Aspose.Slides oferuje rozwiązanie oparte na sztucznej inteligencji do dostarczania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem czy profesjonalistą biznesowym, to API umożliwia tworzenie angażujących, lokalizowanych prezentacji dla globalnych odbiorców – zwiększając zasięg i usprawniając komunikację.