---
title: Tłumacz Prezentacji z AI
linktitle: Tłumacz z AI
type: docs
weight: 20
url: /pl/php-java/ai/translator/
keywords:
- tłumacz prezentacji AI
- tłumacz slajdów AI
- funkcja napędzana AI
- prezentacja wielojęzyczna
- slajd wielojęzyczny
- tłumaczenie prezentacji
- tłumaczenie slajdów
- funkcje oparte na AI
- możliwości AI
- agent AI
- klient sieciowy
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI w Aspose.Slides dla PHP. Lokalizuj PPT, PPTX i ODP zachowując układ — szybko i przyjazne dla programistów. Wypróbuj."
---
## **Wstęp**

Aspose.Slides to potężne API umożliwiające programistyczne zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API Tłumaczenia Prezentacji dla wielojęzycznej zawartości slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez internet. Funkcjonalność tę udostępnia klasa [SlidesAIAgent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesaiagent/) do komunikacji z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/), aby połączyć się z API OpenAI.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując oryginalny układ i formatowanie slajdu.

{{% alert color="info" title="Uwaga" %}}
Uwaga, że API OpenAI jest usługą płatną, więc musisz utworzyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński, używając wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```php
// Wczytaj prezentację do tłumaczenia.
$presentation = new Presentation("sample.pptx");

// Utwórz klienta AI z OpenAIWebClient, podając swój model i klucz API.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Zainicjalizuj SlidesAIAgent przy użyciu klienta AI.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Przetłumacz prezentację na język japoński.
    $aiAgent->translate($presentation, "japanese");

    // Zapisz przetłumaczoną prezentację jako PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednak jeśli wolisz samodzielnie zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — głównie aby skonfigurować niezbędne ustawienia, takie jak proxy, lub użyć [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) albo innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) dla lepszego zarządzania zasobami i wydajności — możesz przekazać własną instancję `HttpURLConnection` przy tworzeniu [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/).

```php
// Utwórz i wstępnie skonfiguruj własną instancję HttpURLConnection (niestandardowe czasy oczekiwania, ustawienia proxy itp.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Przekaż połączenie do klienta AI.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Przykład Azure OpenAI**

Możesz skonfigurować tłumacz, aby używał Twojego wdrożenia Azure OpenAI, korzystając z [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Ten fragment kodu demonstruje tłumaczenie prezentacji przy użyciu Twojego punktu końcowego Azure OpenAI. Zamień wartości zastępcze na nazwę wdrożenia, klucz API i adres URL punktu końcowego.

## **Kluczowe korzyści**

API Tłumaczenia Prezentacji Aspose.Slides oferuje rozwiązanie zasilane AI umożliwiające dostarczanie wielojęzycznych prezentacji PowerPoint. Automatyzując tłumaczenie przy jednoczesnym zachowaniu układu i projektu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem, czy profesjonalistą biznesowym, to API pozwala tworzyć angażujące, lokalizowane prezentacje dla globalnej publiczności – zwiększając zasięg i poprawiając komunikację.