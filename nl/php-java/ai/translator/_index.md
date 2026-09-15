---
title: AI-aangedreven Presentatievertaler
linktitle: AI-aangedreven Vertaler
type: docs
weight: 20
url: /nl/php-java/ai/translator/
keywords:
- AI-presentatievertaler
- AI-diavertaler
- AI-aangedreven functie
- meertalige presentatie
- meertalige dia
- presentatievertaling
- diavertaling
- AI-gestuurde functies
- AI-mogelijkheden
- AI-agent
- webclient
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor PHP. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Inleiding**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gestuurde functies – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via het internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesaiagent/)‑klasse om te communiceren met AI‑services.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI.

Aspose.Slides verzorgt de communicatie, verwerkt de AI‑reacties en voegt vertaald materiaal intelligent in, terwijl de oorspronkelijke dia‑lay‑out en opmaak behouden blijven.

{{% alert color="info" title="Opmerking" %}}

Let op dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/) en een opgegeven OpenAI‑[model](https://platform.openai.com/docs/models).

```php
// Laad een presentatie om te vertalen.
$presentation = new Presentation("sample.pptx");

// Maak een AI‑client met OpenAIWebClient, waarbij je model en API‑sleutel opgeeft.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseert SlidesAIAgent met de AI‑client.
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

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/) en beheert hij eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie en regelt hij de levenscyclus automatisch. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren – bijvoorbeeld om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een ander [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor betere resource‑beheer en prestaties – kunt u uw eigen `HttpURLConnection`‑instantie doorgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaiwebclient/).

```php
// Maak en preconfigureer uw eigen HttpURLConnection‑instantie (aangepaste timeouts, proxy‑instellingen, enz.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Geef de verbinding door aan de AI‑client.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI‑voorbeeld**

U kunt de vertaler configureren om uw Azure OpenAI‑implementatie te gebruiken met de [OpenAICompatibleWebClient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/openaicompatiblewebclient/).

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

Dit fragment laat zien hoe een presentatie wordt vertaald met uw Azure OpenAI‑endpoint. Vervang de voorbeeldwaarden door uw implementatienaam, API‑sleutel en endpoint‑URL.

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door de vertaling te automatiseren en tegelijk de lay‑out en het ontwerp te behouden, bespaart u tijd en minimaliseert u fouten ten opzichte van handmatige processen. Of u nu ontwikkelaar, docent of zakenprofessional bent, deze API stelt u in staat om boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – uw bereik te vergroten en de communicatie te verbeteren.