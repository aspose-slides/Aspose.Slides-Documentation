---
title: AI‑drivet flerspråkigt bildgenereringsverktyg
linktitle: AI‑drivet generator
type: docs
weight: 40
url: /sv/python-java/ai/generator/
keywords:
- flerspråkig presentation
- flerspråkig bild
- AI‑presentationgenerator
- AI‑bildgenerator
- presentationmall
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Generera flerspråkiga presentationer från text med Aspose.Slides för Python via Java. Välj innehållsdetalj, tillämpa en mall och exportera till PowerPoint eller PDF."
---
## **Introduktion**

AI‑presentationsgeneratorn i Aspose.Slides för Python via Java skapar presentationer från ämnesbeskrivningar, sammanfattningar, citat eller punktlistor. Ange det önskade språket i din prompt, välj mängden innehåll och kan eventuellt ange en presentationmall för att definiera layout och design.

Generatorn strukturerar innehållet med textblock, punktlistor och tabeller. Den genererar inte bilder; du kan lägga till dem i den färdiga presentationen i efterhand. Granska det genererade innehållet och layouten innan du delar presentationen.

## **Hur det fungerar**

[SlidesAIAgent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesaiagent/) använder en AI‑klient för att kommunicera med en extern modell. Exemplen nedan använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-java/aspose.slides/openaiwebclient/). Aspose.Slides bearbetar modellens svar och bygger en presentation som du kan redigera eller exportera.

Använd [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesaiagent/#generatePresentation) med en textbeskrivning och ett [PresentationContentAmountType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationcontentamounttype/)‑värde. Överlagringen med ett tredje argument accepterar en presentation att använda som designmall.

## **Förutsättningar**

Följ [Installation](/slides/sv/python-java/installation/) för att konfigurera Python, Java, JPype och Aspose.Slides. Ställ in miljövariablerna `OPENAI_API_KEY` och `OPENAI_MODEL` innan du kör exemplen. Välj en modell som stöds av den inbyggda klienten och som är tillgänglig för ditt API‑konto.

{{% alert color="info" title="Obs" %}}
AI‑tjänsten kräver en internetanslutning och separat API‑åtkomst. Prompter skickas till den konfigurerade tjänsten, och dess användningskostnader gäller oberoende av din Aspose.Slides‑licens.
{{% /alert %}}

Varje exempel startar JVM endast om den inte redan körs och lämnar den tillgänglig för efterföljande operationer. Se [JVM lifecycle guidance](/slides/sv/python-java/limitations-and-api-differences/#import-the-library) när du anpassar koden för notebooks.

## **Generera en presentation från text**

Detta exempel genererar en engelsk presentation med en [Medium](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationcontentamounttype/#Medium)‑mängd innehåll och sparar den som en PowerPoint‑fil.

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

## **Generera en presentation med en mall**

Placera `masterPresentation.pptx` i arbetskatalogen. Detta exempel läser in den med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), genererar en spansk presentation med [Detailed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationcontentamounttype/#Detailed)‑innehåll och exporterar den till PDF. Både mallen och den genererade presentationen frigörs, även om generering eller sparning misslyckas.

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

Om du behöver konfigurera en proxy eller anslutningstidsgränser, se [Configure the HTTP Connection](/slides/sv/python-java/ai/translator/#configure-the-http-connection). Du kan också skicka den resulterande klienten till generatorn.

## **Viktiga fördelar**

Generering kan minska det initiala skrivandet för utbildningsmaterial, produktöversikter, kundrapporter och interna presentationer. Prompter styr ämnet och språket, medan en mall låter dig återanvända en befintlig presentationsdesign.

## **FAQ**

**Hur kontrollerar jag längden på den genererade presentationen?**

Välj [Brief](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationcontentamounttype/#Medium) eller [Detailed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Dessa inställningar påverkar både antalet bilder och detaljnivån på varje bild; de anger inte ett exakt bildantal.

**Kan jag generera bilder på ett annat språk?**

Ja. Inkludera det önskade språket i textbeskrivningen. Resultatet beror på den valda modellens språkstöd.

**Kan jag behålla en redigerbar version vid export till PDF?**

Ja. Innan du disponerar den genererade presentationen, spara den också som PPTX enligt tillvägagångssättet i det första exemplet.