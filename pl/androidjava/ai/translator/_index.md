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
- Android
- Java
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint za pomocą AI, korzystając z Aspose.Slides dla Androida w Javie. Lokalizuj pliki PPT, PPTX i ODP, zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API do programowego zarządzania prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API Tłumaczenia Prezentacji dla wielojęzycznej zawartości slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, lecz integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność tę udostępnia klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidesaiagent/), która używa implementacji interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) do połączenia z API OpenAI lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaiwebclient/), aby skorzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując oryginalny układ i formatowanie slajdów.

{{% alert color="info" title="Note" %}}
Uwaga: API OpenAI jest usługą płatną, więc musisz założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński przy użyciu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) i określonego modelu OpenAI [model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Wczytaj prezentację do przetłumaczenia.
Presentation presentation = new Presentation("sample.pptx");

// Utwórz klienta AI z OpenAIWebClient, określając model i klucz API.
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

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — na przykład aby skonfigurować proxy lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) albo innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) dla lepszego zarządzania zasobami i wydajności — możesz przekazać własną instancję `HttpURLConnection` podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Skonfiguruj własną instancję HttpURLConnection (np. z własnymi limitami czasu, ustawieniami proxy itp.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Przekaż połączenie do konstruktora OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Przykład Azure OpenAI**

Możesz skonfigurować translator, aby używał Twojego wdrożenia Azure OpenAI przy pomocy [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Ten fragment kodu demonstruje tłumaczenie prezentacji przy użyciu Twojego punktu końcowego Azure OpenAI. Zamień wartości zastępcze na nazwę wdrożenia, klucz API i adres URL punktu końcowego.

## **Kluczowe korzyści**

API Tłumaczenia Prezentacji Aspose.Slides oferuje rozwiązanie oparte na AI do dostarczania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy jednoczesnym zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem, czy profesjonalistą biznesowym, to API umożliwia tworzenie angażujących, lokalizowanych prezentacji dla globalnej publiczności – zwiększając zasięg i poprawiając komunikację.