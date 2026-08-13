---
title: Tłumacz prezentacji oparty na AI
linktitle: Tłumacz oparty na AI
type: docs
weight: 20
url: /pl/androidjava/ai/translator/
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
- Klient sieciowy
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI z Aspose.Slides dla Androida w Javie. Lokalizuj pliki PPT, PPTX i ODP, zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API do programowego zarządzania prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API Tłumaczenia Prezentacji dla wielojęzycznej zawartości slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność ta jest udostępniana za pośrednictwem klasy [SlidesAIAgent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesaiagent/) , która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/), aby połączyć się z API OpenAI, lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaiwebclient/), aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując pierwotny układ i formatowanie slajdu.

{{% alert color="info" %}}
Należy pamiętać, że API OpenAI jest usługą płatną, więc musisz utworzyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński, używając wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) wraz z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Wczytaj prezentację do tłumaczenia.
Presentation presentation = new Presentation("sample.pptx");

// Utwórz klienta AI przy użyciu OpenAIWebClient, podając model i klucz API.
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

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), obsługując jej cykl życia automatycznie. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), głównie aby skonfigurować istotne ustawienia takie jak proxy, lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) lub innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html), aby lepiej zarządzać zasobami i wydajnością – możesz dostarczyć własną instancję `HttpURLConnection` przy tworzeniu [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Skonfiguruj instancję HttpURLConnection samodzielnie (np. z własnymi limitami czasu, ustawieniami proxy itp.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Przekaż połączenie do konstruktora OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Kluczowe korzyści**

API Tłumaczenia Prezentacji Aspose.Slides oferuje rozwiązanie oparte na AI do dostarczania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, nauczycielem, czy profesjonalistą biznesowym, to API umożliwia tworzenie angażujących, lokalizowanych prezentacji dla globalnej publiczności – zwiększając zasięg i poprawiając komunikację.