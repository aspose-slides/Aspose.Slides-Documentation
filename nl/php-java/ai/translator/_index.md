---
title: AI-ondersteunde presentatievertaler
linktitle: AI-ondersteunde vertaler
type: docs
weight: 20
url: /nl/php-java/ai/translator/
keywords:
- AI-presentatievertaler
- AI-diavertaler
- AI-ondersteunde functie
- meertalige presentatie
- meertalige dia
- presentatievertaling
- diavertaling
- AI-gedreven functies
- AI-mogelijkheden
- AI-agent
- Webclient
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor PHP. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft - snel en ontwikkelaarvriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van diaʼs biedt het AI‑gestuurde functies – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt blootgesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesaiagent/) klasse om te communiceren met AI‑services.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI.

Aspose.Slides verzorgt de communicatie, parseert de AI‑reacties en voegt vertaaldere inhoud intelligent in, terwijl de oorspronkelijke dia‑lay‑out en opmaak behouden blijven.

{{% alert color="primary" %}}
Let op dat de OpenAI API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/) en een opgegeven OpenAI [model](https://platform.openai.com/docs/models).

```php
// Laad een presentatie om te vertalen.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseer SlidesAIAgent met de AI-client.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Vertaal de presentatie naar Japans.
    $aiAgent->translate($presentation, "japanese");

    // Sla de vertaalde presentatie op als PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instantie aan en beheert de levenscyclus automatisch. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren – bijvoorbeeld om een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor beter resource‑beheer en prestaties – kunt u uw eigen `HttpURLConnection`‑instantie doorgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/).

```php
// Veronderstel dat u een vooraf geconfigureerde HttpURLConnection-instantie heeft (bijv. met aangepaste timeouts, proxyinstellingen, enz.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren terwijl de lay‑out en het ontwerp behouden blijven, bespaart het tijd en minimaliseert het fouten ten opzichte van handmatige werkwijzen. Of u nu ontwikkelaar, docent of zakelijk professional bent, deze API stelt u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – waardoor uw bereik wordt vergroot en de communicatie wordt verbeterd.