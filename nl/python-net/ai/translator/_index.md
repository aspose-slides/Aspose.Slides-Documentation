---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/python-net/ai/translator/
keywords:
- AI-presentatietranslator
- AI-dia-translator
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
- Python
- Aspose.Slides
description: "Vertaal PowerPoint-dias met AI met behulp van Aspose.Slides voor Python. Lokaliseer PPT, PPTX en ODP terwijl de layout behouden blijft - snel en ontwikkelaarvriendelijk. Probeer het."
---
## **Inleiding**

Aspose.Slides is een krachtige API voor het programmatic beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia's, biedt het AI‑gestuurde functionaliteit – zoals de [Presentation Translation API](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/) voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI-mogelijkheden, maar integreert met externe AI‑modellen via het internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/slidesaiagent/) klasse, die [IAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/iaiwebclient/) subklassen gebruikt om met AI‑services te communiceren.

Je kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI, of je eigen [IAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides verwerkt de communicatie, parseert de AI‑reacties en voegt op slimme wijze vertaalde inhoud in, terwijl de oorspronkelijke dia‑lay-out en opmaak behouden blijven.

{{% alert color="primary" %}}
Houd er rekening mee dat de OpenAI‑API een betaalde dienst is, dus je moet een account aanmaken en je API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/openaiwebclient/) en een opgegeven OpenAI‑[model](https://platform.openai.com/docs/models).

```py
# Laad een presentatie om te vertalen.
with slides.Presentation("sample.pptx") as presentation:

    # Maak een AI-client met OpenAIWebClient, waarbij je je model en API-sleutel opgeeft.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Initialiseer SlidesAIAgent met de AI-client.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Vertaal de presentatie naar het Japans.
        ai_agent.translate(presentation, "japanese")

        # Bewaar de vertaalde presentatie als PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **Belangrijkste voordelen**

De Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/nl/python-net/aspose.slides.ai/) biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren terwijl lay-out en ontwerp behouden blijven, bespaart het tijd en minimaliseert het fouten ten opzichte van handmatige workflows. Of je nu ontwikkelaar, docent of zakelijk professional bent, deze API stelt je in staat om boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – waardoor je bereik wordt vergroot en de communicatie verbetert.