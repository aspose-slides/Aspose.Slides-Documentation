---
title: AI-aangedreven meertalige dia-generator
linktitle: AI-aangedreven generator
type: docs
weight: 40
url: /nl/nodejs-java/ai/generator/
keywords:
- meertalige presentatie
- meertalige dia
- AI-presentatiegenerator
- AI-diagnenerator
- AI-aangedreven functie
- AI-agent
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Genereer meertalige dia's vanuit tekst met Aspose.Slides voor Node.js. Pas uw sjabloon toe en exporteer gepolijste decks naar PowerPoint en OpenDocument. Leer meer."
---
## **Inleiding**

Aspose.Slides introduceert een nieuwe door AI aangedreven functie, de Presentation Generator, waarmee ontwikkelaars automatisch goed gestructureerde PowerPoint‑presentaties kunnen maken op basis van eenvoudige tekstelementen zoals onderwerpbeschrijvingen, samenvattingen, citaten of opsommingstekens.

Gebruikers kunnen het detailniveau van de inhoud aanpassen en eventueel een aangepast presentatiesjabloon toepassen om het visuele ontwerp te bepalen.

Momenteel structureert de AI Presentation Generator de inhoud met tekstblokken, opsommingslijsten en tabellen. Het genereren van afbeeldingen wordt nog niet ondersteund; afbeeldingen kunnen echter eenvoudig achteraf worden toegevoegd met behulp van de tools van Aspose.Slides of handmatig.

De output is een volledige PowerPoint‑presentatie die direct bruikbaar is of kan worden geëxporteerd naar elk formaat dat door de Aspose.Slides‑API wordt ondersteund. Hoewel de generator resultaten van hoge kwaliteit oplevert, kan er lichte nabewerking nodig zijn om aan specifieke eisen te voldoen.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑modellen; in plaats daarvan wordt er geïntegreerd met externe AI‑services via internet. Deze integratie wordt afgehandeld door de [SlidesAIAgent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesaiagent/)‑klasse.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) gebruiken, die verbinding maakt met de API van OpenAI. Aspose.Slides verzorgt alle communicatie met de AI‑service en verwerkt de antwoorden van de AI om dia’s te genereren. Houd er rekening mee dat de OpenAI‑API een betaalde dienst is, waardoor een account en een API‑sleutel vereist zijn bij gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).

## **Laten we coderen**

### **Voorbeeld 1**

Dit voorbeeld laat zien hoe u een presentatie over het onderwerp Aspose.Slides kunt genereren met de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Maak een instantie van OpenAIWebClient, de ingebouwde implementatie van de OpenAI webclient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Maak een instantie van SlidesAIAgent, die toegang biedt tot AI-aangedreven functies.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definieer de instructie voor het genereren van de presentatie.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Genereer een presentatie met een gemiddelde hoeveelheid inhoud op basis van de instructie.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Sla de gegenereerde presentatie op de lokale schijf op als een PowerPoint (.pptx) bestand.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Voorbeeld 2**

Het volgende voorbeeld toont de overloads van de [generatePresentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation)‑methode. In dit geval worden een extern beheerde [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie en de `master presentation` van de gebruiker gebruikt.

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/) zelf een interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie aan en beheert deze automatisch. Als u echter liever zelf de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) beheert — bijvoorbeeld bij gebruik van een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) voor betere resource‑beheer en prestaties — kunt u uw eigen [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie leveren bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Geef de HttpURLConnection door aan de OpenAIWebClient constructor.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Maak een instantie van SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definieer de instructie voor het genereren van de presentatie.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Laad een masterpresentatie van de lokale schijf om te gebruiken als ontwerpsjabloon.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Genereer een gedetailleerde presentatie met behulp van de instructie en het mastersjabloon.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Sla de gegenereerde presentatie op als PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Belangrijkste voordelen**

De nieuwe AI Presentation Generator in Aspose.Slides biedt een snelle en flexibele manier om gestructureerde presentaties te maken op basis van eenvoudige tekst prompts. Met ondersteuning voor aangepaste sjablonen en extern beheerde [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instellingen kan deze functie naadloos worden geïntegreerd in een breed scala aan applicaties.

Typische use‑cases omvatten het creëren van marketingpresentaties, educatief materiaal, klantrapporten en interne slide decks. Hoewel het genereren van afbeeldingen nog niet wordt ondersteund, biedt het gereedschap al een solide basis voor het automatiseren van het maken van presentaties, met verdere verbeteringen die in de toekomst worden verwacht.