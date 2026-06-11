---
title: AI-drivet flerspråkigt bildspelsgenerator
linktitle: AI-drivet generator
type: docs
weight: 40
url: /sv/net/ai/generator/
keywords:
- flerspråkig presentation
- flerspråkigt bildspel
- AI-presentationgenerator
- AI-bildspelsgenerator
- AI-driven funktion
- AI-agent
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Generera flerspråkiga bildspel från text med Aspose.Slides för .NET. Använd din mall och exportera färdiga presentationer till PowerPoint och OpenDocument. Läs mer."
---
## **Introduktion**

Aspose.Slides introducerar en ny AI‑driven funktion, Presentation Generator, som gör det möjligt för utvecklare att automatiskt skapa välstrukturerade PowerPoint‑presentationer från enkla textinmatningar såsom ämnesbeskrivningar, sammanfattningar, citat eller punktlistor.

Användare kan justera detaljnivån på innehållet och valfritt tillämpa en anpassad presentationmall för att definiera den visuella designen.

För närvarande strukturerar AI Presentation Generator innehållet med textblock, punktlistor och tabeller. Bildgenerering stöds ännu inte; dock kan bilder enkelt läggas till i efterhand med Aspose.Slides‑verktyg eller manuellt.

Resultatet är en komplett PowerPoint‑presentation som kan användas som den är eller exporteras till vilket format som helst som stöds av Aspose.Slides API. Även om generatorn ger högkvalitativa resultat kan mindre efterredigering krävas för att uppfylla specifika krav.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI‑modeller; istället integreras den med externa AI‑tjänster via internet. Denna integration hanteras av klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/slidesaiagent/) som använder en implementation av gränssnittet [IAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/iaiwebclient/) för att kommunicera med AI‑modellen.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/) som ansluter till OpenAIs API, eller tillhandahålla en egen implementation av [IAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/iaiwebclient/) för att arbeta med en annan AI‑leverantör eller språkmodell. Aspose.Slides hanterar all kommunikation med AI‑tjänsten och bearbetar AI:s svar för att generera bildspel. Observera att OpenAI API är en betaltjänst, så ett konto och en API‑nyckel krävs när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/).

## **Låt oss koda**

### **Exempel 1**

Detta exempel visar hur man genererar en presentation om ämnet Aspose.Slides med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Skapa en instans av OpenAIWebClient, den inbyggda implementeringen av OpenAI-webbklienten.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Skapa en instans av SlidesAIAgent, som ger åtkomst till AI-drivna funktioner.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definiera instruktionen för att generera presentationen.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generera en presentation med en medelhög mängd innehåll baserat på instruktionen.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Spara den genererade presentationen till den lokala disken som en PowerPoint (.pptx)-fil.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Exempel 2**

Följande exempel visar överlagringarna av metoden [GeneratePresentation](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/slidesaiagent/generatepresentation/). I detta fall används en externt hanterad [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-instans och användarens `master presentation`.

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/) sin egen interna [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-instans, och hanterar dess livscykel och avstängning automatiskt. Om du föredrar att själv hantera [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — till exempel när du använder en [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) för förbättrad resurshantering och prestanda — kan du tillhandahålla din egen [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Skapa en externt hanterad HttpClient-instans.
using var httpClient = new HttpClient();

// Skicka HttpClient till OpenAIWebClient-konstruktorn.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Skapa en instans av SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definiera instruktionen för att generera presentationen.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Ladda en huvudpresentation från den lokala disken för att använda som designmall.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generera en detaljerad presentation med instruktionen och huvudmallen.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Spara den genererade presentationen som en PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Det är värt att notera att många kunder använder Aspose.Slides i synkrona sammanhang. För att stödja detta erbjuder klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/slidesaiagent/) både synkrona och asynkrona metoder, så att du kan välja det tillvägagångssätt som bäst passar ditt programs arbetsflöde.

## **Nyckelfördelar**

Den nya AI Presentation Generator i Aspose.Slides ger ett snabbt och flexibelt sätt att producera strukturerade bildspel från enkla textpromptar. Med stöd för anpassade mallar, externt hanterade [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-instanser och både synkrona och asynkrona arbetsflöden kan den sömlöst integreras i en rad olika applikationer.

Vanliga användningsområden inkluderar skapande av marknadsföringspresentationer, utbildningsmaterial, kundrapporter och interna bildspel. Även om bildgenerering ännu inte stöds ger verktyget redan en stark grund för att automatisera skapandet av presentationer, och ytterligare förbättringar förväntas i framtiden.