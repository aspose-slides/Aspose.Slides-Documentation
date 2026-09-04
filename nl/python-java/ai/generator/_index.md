---
title: AI-aangedreven meertalige dia-generator
linktitle: AI-aangedreven generator
type: docs
weight: 40
url: /nl/python-java/ai/generator/
keywords:
- meertalige presentatie
- meertalige dia
- AI-presentatiegenerator
- AI-dia-generator
- presentatiesjabloon
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Genereer meertalige presentaties vanuit tekst met Aspose.Slides voor Python via Java. Kies het detail van de inhoud, pas een sjabloon toe en exporteer naar PowerPoint of PDF."
---
## **Introductie**

De AI‑presentatiegenerator in Aspose.Slides voor Python via Java maakt presentaties aan op basis van onderwerp‑beschrijvingen, samenvattingen, citaten of opsommingstekens. Geef de gewenste taal op in je prompt, kies de hoeveelheid inhoud en lever eventueel een presentatiesjabloon aan om de lay‑out en het ontwerp te bepalen.

De generator structureert de inhoud met behulp van tekstblokken, opsommingslijsten en tabellen. Hij genereert geen afbeeldingen; je kunt ze later aan de resulterende presentatie toevoegen. Controleer de gegenereerde inhoud en lay‑out voordat je de presentatie deelt.

## **Hoe het werkt**

[SlidesAIAgent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesaiagent/) gebruikt een AI‑client om te communiceren met een extern model. De onderstaande voorbeelden gebruiken de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-java/aspose.slides/openaiwebclient/). Aspose.Slides verwerkt de antwoorden van het model en bouwt een presentatie die je kunt bewerken of exporteren.

Gebruik [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesaiagent/#generatePresentation) met een tekstbeschrijving en een [PresentationContentAmountType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationcontentamounttype/)‑waarde. De overload met een derde argument accepteert een presentatie die als ontwerpsjabloon gebruikt kan worden.

## **Vereisten**

Volg [Installation](/slides/nl/python-java/installation/) om Python, Java, JPype en Aspose.Slides te configureren. Stel de omgevingsvariabelen `OPENAI_API_KEY` en `OPENAI_MODEL` in voordat je de voorbeelden uitvoert. Kies een model dat door de ingebouwde client wordt ondersteund en beschikbaar is voor je API‑account.

{{% alert color="info" title="Note" %}}
De AI‑service vereist een internetverbinding en een afzonderlijke API‑toegang. Prompts worden naar de geconfigureerde service gestuurd en de gebruikskosten zijn onafhankelijk van je Aspose.Slides‑licentie.
{{% /alert %}}

Elk voorbeeld start de JVM alleen als deze nog niet draait en laat deze beschikbaar voor volgende bewerkingen. Zie [JVM lifecycle guidance](/slides/nl/python-java/limitations-and-api-differences/#import-the-library) bij het aanpassen van de code voor notebooks.

## **Een presentatie genereren vanuit tekst**

Dit voorbeeld genereert een Engelstalige presentatie met een [Medium](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationcontentamounttype/#Medium) hoeveelheid inhoud en slaat deze op als een PowerPoint‑bestand.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Een presentatie genereren met een sjabloon**

Plaats `masterPresentation.pptx` in de werkmap. Dit voorbeeld laadt het met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/), genereert een Spaanstalige presentatie met [Detailed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationcontentamounttype/#Detailed) inhoud en exporteert deze naar PDF. Zowel het sjabloon als de gegenereerde presentatie worden vrijgegeven, zelfs als het genereren of opslaan mislukt.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Als je een proxy of verbindings‑time‑outs moet configureren, zie [Configure the HTTP Connection](/slides/nl/python-java/ai/translator/#configure-the-http-connection). Je kunt de resulterende client ook aan de generator doorgeven.

## **Belangrijke voordelen**

Genereren kan het initiële opstelwerk voor trainingsmateriaal, productoverzichten, klantrapporten en interne presentaties verminderen. Prompts bepalen het onderwerp en de taal, terwijl een sjabloon je in staat stelt een bestaand presentatiedesign opnieuw te gebruiken.

## **Veelgestelde vragen**

**Hoe kan ik de lengte van de gegenereerde presentatie regelen?**

Kies [Brief](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationcontentamounttype/#Medium) of [Detailed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Deze instellingen beïnvloeden zowel het aantal dia's als de mate van detail per dia; ze bepalen geen exact aantal dia's.

**Kan ik dia's in een andere taal genereren?**

Ja. Voeg de gewenste taal toe in de tekstbeschrijving. Het resultaat hangt af van de taalondersteuning van het geselecteerde model.

**Kan ik een bewerkbare versie behouden bij export naar PDF?**

Ja. Sla de gegenereerde presentatie, voordat je deze verwijdert, ook op als PPTX met de aanpak uit het eerste voorbeeld.