---
title: AI-ondersteunde Presentatievertaler
linktitle: AI-ondersteunde Vertaler
type: docs
weight: 20
url: /nl/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI via Aspose.Slides voor Node.js. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gedreven functies – zoals de Presentation Translation‑API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑mogelijkheden, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesaiagent/)‑klasse om te communiceren met AI‑services.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI.

Aspose.Slides verzorgt de communicatie, parseert de AI‑reacties en voegt de vertaalde inhoud intelligent in, terwijl de oorspronkelijke dia‑lay-out en opmaak behouden blijven.

{{% alert color="primary" %}}
Houd er rekening mee dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) en een gespecificeerd OpenAI‑[model](https://platform.openai.com/docs/models).

```js
// Laad een presentatie om te vertalen.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Maak een AI‑client met OpenAIWebClient, waarbij u uw model en API‑sleutel opgeeft.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseer SlidesAIAgent met de AI‑client.
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

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie aan en beheert deze, waarbij de levenscyclus automatisch wordt afgehandeld. Als u er echter de voorkeur aan geeft de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf te beheren – voornamelijk om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor een betere bronbeheer en prestaties – kunt u uw eigen `HttpURLConnection`‑instantie opgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Ga ervan uit dat u een vooraf geconfigureerde HttpURLConnection‑instantie heeft (bijv. met aangepaste timeouts, proxy‑instellingen, enz.).
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation‑API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door de vertaling te automatiseren en tegelijkertijd lay-out en ontwerp te behouden, bespaart het tijd en minimaliseert het fouten in vergelijking met handmatige workflows. Of u nu ontwikkelaar, docent of zakelijk professional bent, deze API stelt u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – uw bereik uit te breiden en de communicatie te verbeteren.