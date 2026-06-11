---
title: AI-drivet flerspråkigt bildspelsgenerator
linktitle: AI-drivet generator
type: docs
weight: 40
url: /sv/python-net/ai/generator/
keywords:
- flerspråkig presentation
- flerspråkig bild
- AI-presentationgenerator
- AI-bildgenerator
- AI-driven funktion
- AI-agent
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa flerspråkiga bilder från text med Aspose.Slides för Python. Använd din mall och exportera polerade bildspelsuppsättningar till PowerPoint och OpenDocument. Läs mer."
---
## **Introduktion**

Aspose.Slides introducerar en ny AI-driven funktion, Presentation Generator, som gör det möjligt för utvecklare att automatiskt skapa välstrukturerade PowerPoint‑presentationer från enkla textinmatningar såsom ämnesbeskrivningar, sammanfattningar, citat eller punktlistor.

Användare kan justera detaljnivån på innehållet och valfritt tillämpa en anpassad presentationsmall för att definiera den visuella designen.

För närvarande strukturerar AI Presentation Generator innehållet med textblock, punktlistor och tabeller. Bildgenerering stöds ännu inte; däremot kan bilder enkelt läggas till i efterhand med hjälp av Aspose.Slides‑verktyg eller manuellt.

Resultatet är en komplett PowerPoint‑presentation som kan användas som den är eller exporteras till vilket format som helst som stöds av Aspose.Slides‑API:t. Även om generatorn levererar högkvalitativa resultat kan mindre efterredigering behövas för att uppfylla specifika krav.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI‑modeller; i stället integreras den med externa AI‑tjänster över internet. Denna integration hanteras av klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/slidesaiagent/), som använder en implementation av klassen [IAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/iaiwebclient/) för att kommunicera med AI‑modellen.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaiwebclient/), som ansluter till OpenAI:s API, eller tillhandahålla en egen implementation av [IAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/iaiwebclient/) för att arbeta med en annan AI‑leverantör eller språkmodell. Aspose.Slides hanterar all kommunikation med AI‑tjänsten och bearbetar AI:s svar för att generera bilder. Observera att OpenAI‑API:t är en betald tjänst, så ett konto och en API‑nyckel krävs när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaiwebclient/).

## **Låt oss koda**

### **Exempel 1**

Detta exempel visar hur man genererar en presentation om ämnet Aspose.Slides med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/openaiwebclient/).

```py
# Skapa en instans av OpenAIWebClient, den inbyggda implementeringen av OpenAI-webbklienten.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Skapa en instans av SlidesAIAgent, som ger tillgång till AI-drivna funktioner.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definiera instruktionen för att generera presentationen.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Generera en presentation med en medelstor mängd innehåll baserat på instruktionen.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Spara den genererade presentationen på den lokala disken som en PowerPoint (.pptx)-fil.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Exempel 2**

Följande exempel visar överlagringarna av metoden [generate_presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). I det här fallet används användarens `master presentation`.

```py
# Skicka HttpClient till OpenAIWebClient-konstruktorn.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Skapa en instans av SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definiera instruktionen för att generera presentationen.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Läs in en masterpresentation från den lokala disken för att använda som designtmall.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Generera en detaljerad presentation med instruktionen och mastermallen.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Spara den genererade presentationen som en PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Viktiga fördelar**

Den nya AI Presentation Generator i Aspose.Slides erbjuder ett snabbt och flexibelt sätt att skapa strukturerade bildspel från enkla textpromptar. Med stöd för anpassade mallar kan den sömlöst integreras i ett brett spektrum av applikationer.

Vanliga användningsområden inkluderar att skapa marknadsföringspresentationer, utbildningsmaterial, kundrapporter och interna bildspel. Även om bildgenerering ännu inte stöds erbjuder verktyget redan en stark grund för att automatisera skapandet av presentationer, med ytterligare förbättringar förväntade i framtiden.