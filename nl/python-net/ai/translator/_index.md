---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/python-net/ai/translator/
keywords:
- AI-presentatievertaler
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
- Python
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor Python. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia's biedt het AI‑gedreven functionaliteiten – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt beschikbaar gesteld via de SlidesAIAgent‑klasse, die IAIWebClient‑subklassen gebruikt om met AI‑diensten te communiceren.

U kunt de ingebouwde OpenAIWebClient gebruiken om verbinding te maken met de API van OpenAI, of uw eigen IAIWebClient implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides behandelt de communicatie, parseert de AI‑reacties en voegt op intelligente wijze de vertaalde inhoud in, terwijl de oorspronkelijke dia‑lay-out en opmaak behouden blijven.

{{% alert color="info" %}}
Let op dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde OpenAIWebClient.
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar Japans met behulp van de ingebouwde OpenAIWebClient en een opgegeven OpenAI‑model.

```py
import aspose.slides as slides

# Laad een presentatie om te vertalen.
with slides.Presentation("sample.pptx") as presentation:

    # Maak een AI-client met OpenAIWebClient, met vermelding van uw model en API-sleutel.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Initialiseert SlidesAIAgent met de AI-client.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Vertaal de presentatie naar Japans.
        ai_agent.translate(presentation, "japanese")

        # Sla de vertaalde presentatie op als PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI‑voorbeeld**

Sinds versie **26.7.0** ondersteunt Aspose.Slides voor Python via .NET OpenAI‑compatibele providers, waaronder Azure OpenAI. U kunt de vertaler configureren om uw interne Azure‑implementatie te gebruiken met de OpenAICompatibleWebClient.

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Dit fragment toont hoe een presentatie wordt vertaald met uw Azure OpenAI‑endpoint. Vervang de placeholder‑waarden door uw implementatienaam, API‑sleutel en endpoint‑URL.

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren en tegelijkertijd de lay‑out en het ontwerp te behouden, bespaart het tijd en minimaliseert het fouten in vergelijking met handmatige processen. Of u nu een ontwikkelaar, docent of bedrijfsprofessional bent, deze API stelt u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – uw bereik uit te breiden en de communicatie te verbeteren.