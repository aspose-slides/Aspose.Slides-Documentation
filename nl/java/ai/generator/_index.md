---
title: AI-ondersteunde meertalige dia-generator
linktitle: AI-ondersteunde generator
type: docs
weight: 40
url: /nl/java/ai/generator/
keywords:
- meertalige presentatie
- meertalige dia
- AI-presentatiegenerator
- AI-dia-generator
- AI-ondersteunde functie
- AI-agent
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Genereer meertalige dia's vanuit tekst met Aspose.Slides voor Java. Pas uw sjabloon toe en exporteer gepolijste presentaties naar PowerPoint en OpenDocument. Leer meer."
---
## **Introductie**

Aspose.Slides introduceert een nieuwe AI‑ondersteunde functie, de Presentatiegenerator, die ontwikkelaars in staat stelt automatisch goed gestructureerde PowerPoint‑presentaties te maken op basis van eenvoudige tekstopdrachten, zoals onderwerp‑beschrijvingen, samenvattingen, citaten of opsommingstekens.

Gebruikers kunnen het detailniveau van de inhoud aanpassen en optioneel een aangepast presentatiesjabloon toepassen om het visuele ontwerp te definiëren.

Momenteel structureert de AI‑Presentatiegenerator de inhoud met tekstblokken, opsomminglijsten en tabellen. Afbeeldingsgeneratie wordt nog niet ondersteund; afbeeldingen kunnen echter achteraf eenvoudig worden toegevoegd met behulp van Aspose.Slides‑tools of handmatig.

De uitvoer is een volledige PowerPoint‑presentatie die direct bruikbaar is of kan worden geëxporteerd naar elk formaat dat door de Aspose.Slides‑API wordt ondersteund. Hoewel de generator resultaten van hoge kwaliteit levert, kan er een kleine nabewerking nodig zijn om aan specifieke eisen te voldoen.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑modellen; in plaats daarvan integreert het met externe AI‑diensten via internet. Deze integratie wordt afgehandeld door de [SlidesAIAgent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesaiagent/)‑klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/)‑interface gebruikt om met het AI‑model te communiceren.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) gebruiken, die verbinding maakt met de API van OpenAI, of een aangepaste implementatie van [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) leveren om met een andere AI‑provider of taalmodel te werken. Aspose.Slides beheert alle communicatie met de AI‑service en verwerkt de reacties van de AI om dia's te genereren. Houd er rekening mee dat de OpenAI‑API een betaalde service is, dus een account en API‑sleutel zijn vereist bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).

## **Laten we coderen**

### **Voorbeeld 1**

Dit voorbeeld laat zien hoe u een presentatie over het onderwerp Aspose.Slides kunt genereren met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).

```java
// Maak een instantie van OpenAIWebClient, de ingebouwde implementatie van de OpenAI webclient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Maak een instantie van SlidesAIAgent, die toegang geeft tot AI-ondersteunde functies.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definieer de instructie voor het genereren van de presentatie.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Genereer een presentatie met een gemiddelde hoeveelheid content op basis van de instructie.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Sla de gegenereerde presentatie op de lokale schijf op als een PowerPoint-bestand (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Voorbeeld 2**

Het volgende voorbeeld toont de overloads van de [generatePresentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-)‑methode. In dit geval wordt een extern beheerde [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie en de `master presentation` van de gebruiker gebruikt.

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) en beheert hij zijn eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie, waarbij de levenscyclus automatisch wordt afgehandeld. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren — bijvoorbeeld bij gebruik van een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) voor beter resource‑beheer en prestaties — kunt u uw eigen [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie leveren bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).

```java
// Geef de HttpURLConnection door aan de constructor van OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Maak een instantie van SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definieer de instructie voor het genereren van de presentatie.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Laad een masterpresentatie vanaf de lokale schijf om te gebruiken als ontwerpsjabloon.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Genereer een gedetailleerde presentatie met behulp van de instructie en het master sjabloon.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Sla de gegenereerde presentatie op als PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Belangrijkste voordelen**

De nieuwe AI‑Presentatiegenerator in Aspose.Slides biedt een snelle en flexibele manier om gestructureerde diapresentaties te produceren op basis van eenvoudige tekstopdrachten. Met ondersteuning voor aangepaste sjablonen en extern beheerde [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie kan hij naadloos worden geïntegreerd in een breed scala aan toepassingen.

Typische gebruikssituaties omvatten het maken van marketingpresentaties, educatief materiaal, klantrapporten en interne diapresentaties. Hoewel afbeeldingen nog niet worden gegenereerd, biedt de tool al een solide basis voor het automatiseren van het maken van presentaties, met in de toekomst verwachte verdere uitbreidingen.