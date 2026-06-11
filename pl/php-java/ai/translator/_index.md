---
title: Tłumacz prezentacji napędzany AI
linktitle: Tłumacz napędzany AI
type: docs
weight: 20
url: /pl/php-java/ai/translator/
keywords:
- Tłumacz prezentacji AI
- Tłumacz slajdów AI
- Funkcja napędzana AI
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
- PHP
- Aspose.Slides
description: "Tłumacz slajdy PowerPoint przy użyciu AI i Aspose.Slides dla PHP. Lokalizuj PPT, PPTX i ODP zachowując układ - szybkie i przyjazne dla programistów. Wypróbuj."
---
## **Wprowadzenie**

Aspose.Slides to potężne API umożliwiające programowe zarządzanie prezentacjami PowerPoint. Oprócz tworzenia, edytowania i konwertowania slajdów, oferuje funkcje oparte na sztucznej inteligencji – takie jak API Tłumaczenia Prezentacji dla wielojęzycznej treści slajdów.

## **Jak to działa**

Aspose.Slides nie zawiera wbudowanych możliwości AI, ale integruje się z zewnętrznymi modelami AI przez internet. Ta funkcjonalność jest udostępniana za pośrednictwem klasy [SlidesAIAgent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesaiagent/), aby komunikować się z usługami AI.

Możesz użyć wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/), aby połączyć się z API OpenAI.

Aspose.Slides obsługuje komunikację, parsuje odpowiedzi AI i inteligentnie wstawia przetłumaczoną treść, zachowując pierwotny układ i formatowanie slajdów.

{{% alert color="primary" %}}
Uwaga: API OpenAI jest usługą płatną, więc będziesz musiał założyć konto i podać swój klucz API podczas korzystania z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Przykład**

W tym przykładzie tłumaczymy prezentację PowerPoint na język japoński, używając wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/) z określonym modelem OpenAI [model](https://platform.openai.com/docs/models).

```php
// Wczytaj prezentację do przetłumaczenia.
$presentation = new Presentation("sample.pptx");

// Utwórz klienta AI za pomocą OpenAIWebClient, podając swój model i klucz API.
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

Domyślnie wbudowany [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/) tworzy i zarządza własną wewnętrzną instancją [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automatycznie obsługując jej cykl życia. Jednakże, jeśli wolisz zarządzać [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) samodzielnie — głównie w celu skonfigurowania niezbędnych ustawień, takich jak proxy, lub użycia [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) albo innego [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) w celu lepszego zarządzania zasobami i wydajności — możesz podać własną instancję `HttpURLConnection` podczas konstrukcji [OpenAIWebClient](https://reference.aspose.com/slides/pl/php-java/aspose.slides/openaiwebclient/).

```php
// Załóż, że masz wstępnie skonfigurowaną instancję HttpURLConnection (np. z niestandardowymi timeoutami, ustawieniami proxy itp.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Kluczowe korzyści**

API Tłumaczenia Prezentacji Aspose.Slides oferuje rozwiązanie oparte na sztucznej inteligencji umożliwiające dostarczanie wielojęzycznych prezentacji PowerPoint. Dzięki automatyzacji tłumaczenia przy zachowaniu układu i designu, oszczędza czas i minimalizuje błędy w porównaniu z ręcznymi procesami. Niezależnie od tego, czy jesteś programistą, edukatorem czy profesjonalistą biznesowym, to API pozwala tworzyć angażujące, zlokalizowane prezentacje dla globalnej publiczności – zwiększając zasięg i poprawiając komunikację.