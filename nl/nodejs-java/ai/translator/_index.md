---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/nodejs-java/ai/translator/
keywords:
- AI-presentatietranslator
- AI-diavertaler
- AI-aangedreven functie
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor Node.js. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gestuurde functies – zoals de Presentation Translation‑API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesaiagent/)‑klasse om te communiceren met AI‑services.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI.

Aspose.Slides regelt de communicatie, verwerkt de AI‑antwoorden en voegt vertaalde inhoud op intelligente wijze in, terwijl de oorspronkelijke dia‑indeling en opmaak behouden blijven.

{{% alert color="info" title="Opmerking" %}}
Houd er rekening mee dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) en een gespecificeerd OpenAI‑model.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Laad een presentatie om te vertalen.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Maak een AI-client met OpenAIWebClient, waarbij je je model en API‑sleutel opgeeft.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseer SlidesAIAgent met de AI-client.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Vertaal de presentatie naar het Japans.
    aiAgent.translate(presentation, "japanese");

    // Sla de vertaalde presentatie op als PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie aan en beheert deze, waarbij de levenscyclus automatisch wordt afgehandeld. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren – voornamelijk om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor beter resource‑beheer en betere prestaties – kunt u uw eigen `HttpURLConnection`‑instantie opgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI‑voorbeeld**

U kunt de vertaler configureren om uw Azure OpenAI‑implementatie te gebruiken met de [OpenAICompatibleWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Dit fragment toont het vertalen van een presentatie met uw Azure OpenAI‑endpoint. Vervang de tijdelijke waarden door uw implementatienaam, API‑sleutel en endpoint‑URL.

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation‑API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren terwijl de lay‑out en het ontwerp behouden blijven, bespaart het tijd en minimaliseert het fouten in vergelijking met handmatige workflows. Of u nu een ontwikkelaar, docent of bedrijfsprofessional bent, stelt deze API u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – uw bereik uit te breiden en de communicatie te verbeteren.