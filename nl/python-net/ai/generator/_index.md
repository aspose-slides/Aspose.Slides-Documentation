---
title: AI-ondersteunde meertalige dia-generator
linktitle: AI-ondersteunde generator
type: docs
weight: 40
url: /nl/python-net/ai/generator/
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
- Python
- Aspose.Slides
description: "Genereer meertalige dia's vanuit tekst met Aspose.Slides voor Python. Pas uw sjabloon toe en exporteer gepolijste presentaties naar PowerPoint en OpenDocument. Leer meer."
---
## **Introductie**

Aspose.Slides introduceert een nieuwe AI-gestuurde functie, de Presentatiegenerator, die ontwikkelaars in staat stelt automatisch goed gestructureerde PowerPoint‑presentaties te maken vanuit eenvoudige tekstinvoer zoals onderwerp‑beschrijvingen, samenvattingen, citaten of opsommingstekens.

Gebruikers kunnen het detailniveau van de inhoud aanpassen en naar keuze een aangepast presentatiesjabloon toepassen om het visuele ontwerp te bepalen.

Momenteel structureert de AI‑Presentatiegenerator de inhoud met tekstblokken, opsommingslijsten en tabellen. Beeldgeneratie wordt nog niet ondersteund; afbeeldingen kunnen echter eenvoudig later worden toegevoegd met behulp van Aspose.Slides‑tools of handmatig.

De uitvoer is een volledige PowerPoint‑presentatie die direct bruikbaar is of geëxporteerd kan worden naar elk formaat dat door de Aspose.Slides‑API wordt ondersteund. Hoewel de generator resultaten van hoge kwaliteit oplevert, kan een kleine nabewerking nodig zijn om aan specifieke eisen te voldoen.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑modellen; in plaats daarvan integreert het met externe AI‑services via internet. Deze integratie wordt afgehandeld door de [SlidesAIAgent](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/slidesaiagent/)‑klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/iaiwebclient/)‑klasse gebruikt om met het AI‑model te communiceren.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/openaiwebclient/) gebruiken, die verbinding maakt met de API van OpenAI, of een aangepaste implementatie van [IAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/iaiwebclient/) leveren om met een andere AI‑provider of taalmodel te werken. Aspose.Slides beheert alle communicatie met de AI‑service en verwerkt de reacties van de AI om dia’s te genereren. Let op: de OpenAI‑API is een betaalde dienst, dus een account en een API‑sleutel zijn vereist bij gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/openaiwebclient/).

## **Laten we coderen**

### **Voorbeeld 1**

Dit voorbeeld laat zien hoe u een presentatie over het onderwerp Aspose.Slides genereert met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/openaiwebclient/).

```py
# Maak een instantie van OpenAIWebClient, de ingebouwde implementatie van de OpenAI webclient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Maak een instantie van SlidesAIAgent, die toegang biedt tot AI-ondersteunde functies.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definieer de instructie voor het genereren van de presentatie.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Genereer een presentatie met een gemiddelde hoeveelheid inhoud op basis van de instructie.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Sla de gegenereerde presentatie op op de lokale schijf als een PowerPoint (.pptx) bestand.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Voorbeeld 2**

Het volgende voorbeeld toont de overloads van de [generate_presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation)‑methode. In dit geval wordt de `master presentation` van de gebruiker gebruikt.

```py
# Geef de HttpClient door aan de OpenAIWebClient constructor.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Maak een instantie van SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definieer de instructie voor het genereren van de presentatie.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Laad een masterpresentatie van de lokale schijf om te gebruiken als ontwerpsjabloon.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Genereer een gedetailleerde presentatie met de instructie en master‑sjabloon.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Sla de gegenereerde presentatie op als PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Belangrijkste voordelen**

De nieuwe AI‑Presentatiegenerator in Aspose.Slides biedt een snelle en flexibele manier om gestructureerde dia‑sets te maken vanuit eenvoudige tekst‑prompten. Met ondersteuning voor aangepaste sjablonen kan deze naadloos worden geïntegreerd in een breed scala aan toepassingen.

Typische gebruikssituaties omvatten het maken van marketingpresentaties, educatief materiaal, klantrapporten en interne dia‑sets. Hoewel beeldgeneratie nog niet wordt ondersteund, biedt het hulpmiddel al een stevige basis voor het automatiseren van het maken van presentaties, met verdere verbeteringen die in de toekomst verwacht worden.