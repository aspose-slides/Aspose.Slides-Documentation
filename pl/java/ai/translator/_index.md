---
title: Tłumacz Prezentacji Napędzany Sztuczną Inteligencją
linktitle: Tłumacz Napędzany Sztuczną Inteligencją
type: docs
weight: 20
url: /pl/java/ai/translator/
keywords:
- tłumacz prezentacji AI
- tłumacz slajdów AI
- funkcja napędzana AI
- prezentacja wielojęzyczna
- slajd wielojęzyczny
- tłumaczenie prezentacji
- tłumaczenie slajdów
- funkcje sterowane AI
- możliwości AI
- agent AI
- klient sieciowy
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI i Aspose.Slides dla Java. Lokalizuj PPT, PPTX i ODP zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API umożliwiające programistyczne zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API Tłumaczenia Prezentacji dla wielojęzycznej treści slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność ta jest udostępniona za pomocą klasy [SlidesAIAgent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidesaiagent/), która wykorzystuje implementację interfejsu [IAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaiwebclient/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/), aby połączyć się z API OpenAI, lub zaimplementować własny [IAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaiwebclient/), aby korzystać z innego dostawcy AI lub modelu językowego.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując pierwotny układ i formatowanie slajdów.

{{% alert color="info" title="Uwaga" %}}
Należy pamiętać, że API OpenAI jest usługą płatną, więc będziesz musiał założyć konto i podać swój klucz API przy używaniu wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński, korzystając z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) oraz określonego [modelu](https://platform.openai.com/docs/models) OpenAI.

```java
import com.aspose.slides.*;

// Wczytaj prezentację do przetłumaczenia.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
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

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — głównie aby skonfigurować kluczowe ustawienia, takie jak proxy, lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) lub innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) dla lepszego zarządzania zasobami i wydajności — możesz przekazać własną instancję `HttpURLConnection` podczas tworzenia [OpenAIWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaiwebclient/).

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

### **Przykład Azure OpenAI**

Możesz skonfigurować tłumacz, aby używał Twojej implementacji Azure OpenAI za pomocą [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/openaicompatiblewebclient/).

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

Ten fragment kodu demonstruje tłumaczenie prezentacji przy użyciu Twojego punktu końcowego Azure OpenAI. Zamień wartości zastępcze na nazwę wdrożenia, klucz API oraz URL punktu końcowego.

## **Kluczowe korzyści**

API Tłumaczenia Prezentacji Aspose.Slides oferuje rozwiązanie oparte na sztucznej inteligencji do udostępniania wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy jednoczesnym zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem czy specjalistą biznesowym, to API pozwala tworzyć angażujące, lokalizowane prezentacje dla globalnych odbiorców – zwiększając zasięg i poprawiając komunikację.