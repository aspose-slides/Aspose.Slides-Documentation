---
title: Tłumacz Prezentacji z Wykorzystaniem Sztucznej Inteligencji
linktitle: Tłumacz z Wykorzystaniem Sztucznej Inteligencji
type: docs
weight: 20
url: /pl/java/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja oparta na AI
- Wielojęzyczna prezentacja
- Wielojęzyczny slajd
- Tłumaczenie prezentacji
- Tłumaczenie slajdu
- Funkcje napędzane AI
- Możliwości AI
- Agent AI
- Klient internetowy
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI i Aspose.Slides dla Javy. Lokalizuj pliki PPT, PPTX i ODP, zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API umożliwiające programowe zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na AI – takie jak Presentation Translation API do wielojęzycznej treści slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych funkcji AI, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność ta jest udostępniana poprzez klasę [SlidesAIAgent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesaiagent/), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) aby połączyć się z API OpenAI lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaiwebclient/) aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, analizuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując oryginalny układ i formatowanie slajdów.

{{% alert color="info" %}}
Należy pamiętać, że API OpenAI jest usługą płatną, więc musisz założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Wczytaj prezentację do przetłumaczenia.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
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

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — głównie aby skonfigurować niezbędne ustawienia, takie jak proxy, lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) lub innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) dla lepszego zarządzania zasobami i wydajności — możesz podać własną instancję `HttpURLConnection` podczas konstruowania [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Skonfiguruj własną instancję HttpURLConnection (niestandardowe czasy oczekiwania, ustawienia proxy itp.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Kluczowe korzyści**

Presentation Translation API firmy Aspose.Slides oferuje rozwiązanie oparte na AI umożliwiające dostarczanie wielojęzycznych prezentacji PowerPoint. Dzięki automatyzacji tłumaczenia przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem czy profesjonalistą biznesowym, to API pozwala tworzyć atrakcyjne, lokalizowane prezentacje dla globalnej publiczności – zwiększając zasięg i usprawniając komunikację.