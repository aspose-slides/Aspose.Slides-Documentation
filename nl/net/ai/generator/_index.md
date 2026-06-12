---
title: AI-ondersteunde meertalige dia-generator
linktitle: AI-ondersteunde generator
type: docs
weight: 40
url: /nl/net/ai/generator/
keywords:
- meertalige presentatie
- meertalige dia
- AI-presentatiegenerator
- AI-diegenerator
- AI-ondersteunde functie
- AI-agent
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Genereer meertalige dia's vanuit tekst met Aspose.Slides voor .NET. Pas uw sjabloon toe en exporteer afgewerkte presentaties naar PowerPoint en OpenDocument. Leer meer."
---
## **Introductie**

Aspose.Slides introduceert een nieuwe AI-ondersteunde functie, de Presentation Generator, die ontwikkelaars in staat stelt automatisch goed gestructureerde PowerPoint‑presentaties te maken op basis van eenvoudige tekstelementen zoals onderwerpbeschrijvingen, samenvattingen, citaten of opsommingstekens.

Gebruikers kunnen het detailniveau van de inhoud aanpassen en eventueel een aangepast presentatiesjabloon toepassen om het visuele ontwerp te bepalen.

Momenteel structureert de AI Presentation Generator de inhoud met tekstblokken, opsommingslijsten en tabellen. Het genereren van afbeeldingen wordt nog niet ondersteund; echter kunnen afbeeldingen later eenvoudig worden toegevoegd met behulp van Aspose.Slides‑tools of handmatig.

De output is een volledige PowerPoint‑presentatie die direct kan worden gebruikt of kan worden geëxporteerd naar elk formaat dat door de Aspose.Slides‑API wordt ondersteund. Hoewel de generator resultaten van hoge kwaliteit oplevert, kan er kleine nabewerking nodig zijn om aan specifieke eisen te voldoen.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑modellen; in plaats daarvan integreert het met externe AI‑services via internet. Deze integratie wordt afgehandeld door de [SlidesAIAgent](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent/)‑klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/iaiwebclient/)‑interface gebruikt om te communiceren met het AI‑model.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) gebruiken, die verbinding maakt met de OpenAI‑API, of een aangepaste implementatie van [IAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/iaiwebclient/) leveren om met een andere AI‑provider of taalmodel te werken. Aspose.Slides beheert alle communicatie met de AI‑service en verwerkt de reacties van de AI om dia’s te genereren. Houd er rekening mee dat de OpenAI‑API een betaalde service is, dus een account en API‑sleutel zijn vereist bij gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/).

## **Laten we coderen**

### **Voorbeeld 1**

Dit voorbeeld laat zien hoe u een presentatie over het onderwerp Aspose.Slides genereert met de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Maak een instantie van OpenAIWebClient, de ingebouwde implementatie van de OpenAI-webclient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Maak een instantie van SlidesAIAgent, die toegang biedt tot AI-ondersteunde functies.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definieer de instructie voor het genereren van de presentatie.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Genereer een presentatie met een gemiddelde hoeveelheid inhoud op basis van de instructie.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Sla de gegenereerde presentatie op de lokale schijf op als een PowerPoint (.pptx)-bestand.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Voorbeeld 2**

Het volgende voorbeeld toont de overloads van de methode [GeneratePresentation](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent/generatepresentation/). In dit geval wordt een extern beheerde [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)‑instantie en de `master presentation` van de gebruiker gebruikt.

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) een eigen interne [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)‑instantie aan en beheert deze, waarbij de levenscyclus en verwijdering automatisch worden afgehandeld. Als u echter de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) zelf wilt beheren — bijvoorbeeld bij gebruik van een [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) voor beter middelenbeheer en hogere prestaties — kunt u uw eigen [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)‑instantie leveren bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Maak een extern beheerde HttpClient‑instantie.
using var httpClient = new HttpClient();

// Geef de HttpClient door aan de OpenAIWebClient‑constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Maak een instantie van SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definieer de instructie voor het genereren van de presentatie.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Laad een masterpresentatie van de lokale schijf om te gebruiken als ontwerpsjabloon.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Genereer een gedetailleerde presentatie met behulp van de instructie en het master‑sjabloon.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Sla de gegenereerde presentatie op als PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Het is vermeldenswaard dat veel klanten Aspose.Slides gebruiken in synchrone contexten. Om dit te ondersteunen biedt de [SlidesAIAgent](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent/)‑klasse zowel synchrone als asynchrone methoden, zodat u de aanpak kunt kiezen die het beste past bij de workflow van uw applicatie.

## **Belangrijkste voordelen**

De nieuwe AI Presentation Generator in Aspose.Slides biedt een snelle en flexibele manier om gestructureerde diavoorstellingen te maken vanuit eenvoudige tekstopdrachten. Met ondersteuning voor aangepaste sjablonen, extern beheerde [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)‑instanties, en zowel synchrone als asynchrone werkstromen, kan hij naadloos worden geïntegreerd in een breed scala aan applicaties.

Typische gebruikssituaties zijn het creëren van marketingpresentaties, educatief materiaal, klantverslagen en interne diavoorstellingen. Hoewel het genereren van afbeeldingen nog niet ondersteund wordt, biedt de tool al een stevige basis voor het automatiseren van het maken van presentaties, met verdere verbeteringen die in de toekomst verwacht worden.