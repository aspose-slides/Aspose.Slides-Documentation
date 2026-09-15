---
title: AI-drivet presentationsöversättningsverktyg
linktitle: AI-drivet översättningsverktyg
type: docs
weight: 20
url: /sv/python-net/ai/translator/
keywords:
- AI presentationsöversättare
- AI bildöversättare
- AI-driven funktion
- flerspråkig presentation
- flerspråkig bild
- presentationöversättning
- bildöversättning
- AI-driven funktioner
- AI-funktioner
- AI-agent
- Webbklient
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Översätt PowerPoint-bilder med AI med Aspose.Slides för Python. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras—snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för att programatiskt hantera PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI-drivna funktioner - såsom [Presentation Translation API](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/) för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inte inbyggda AI-funktioner men integreras med externa AI-modeller över internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/slidesaiagent/) som använder underklasser av [IAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/iaiwebclient/) för att kommunicera med AI-tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaiwebclient/) för att ansluta till OpenAIs API eller implementera din egen [IAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/iaiwebclient/) för att använda en annan AI-leverantör eller språkmodell.

Aspose.Slides hanterar kommunikationen, analyserar AI-svaren och infogar översatt innehåll på ett intelligent sätt samtidigt som den bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="info" %}}
Observera att OpenAI API är en betald tjänst, så du måste skapa ett konto och ange din API-nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaiwebclient/) och en specificerad OpenAI [modell](https://platform.openai.com/docs/models).

```py
import aspose.slides as slides

# Läs in en presentation för att översätta.
with slides.Presentation("sample.pptx") as presentation:

    # Skapa en AI-klient med OpenAIWebClient och ange din modell och API-nyckel.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Initiera SlidesAIAgent med AI-klienten.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Översätt presentationen till japanska.
        ai_agent.translate(presentation, "japanese")

        # Spara den översatta presentationen som en PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI‑exempel**

Sedan version **26.7.0** stöder Aspose.Slides för Python via .NET OpenAI-kompatibla leverantörer, inklusive Azure OpenAI. Du kan konfigurera översättaren att använda din interna Azure-distribution med [OpenAICompatibleWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaicompatiblewebclient/).

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

Detta kodavsnitt demonstrerar hur man översätter en presentation med ditt Azure OpenAI-slutpunkt. Ersätt platshållarvärdena med ditt distributionsnamn, API-nyckel och slutpunkt-URL.

## **Viktiga fördelar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/) erbjuder en AI-driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparar den tid och minskar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, pedagog eller affärsprofessionell möjliggör detta API att skapa engagerande, lokalanpassade presentationer för en global publik - vilket utökar din räckvidd och förbättrar kommunikationen.