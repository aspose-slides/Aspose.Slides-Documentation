---
title: AI-driven presentationsöversättare
linktitle: AI-driven översättare
type: docs
weight: 20
url: /sv/net/ai/translator/
keywords:
- AI-presentationöversättare
- AI-bildöversättare
- AI-driven funktion
- flerspråkig presentation
- flerspråkig bild
- presentationöversättning
- bildöversättning
- AI-drivna funktioner
- AI-funktioner
- AI-agent
- Webbklient
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Översätt PowerPoint-bilder med AI med hjälp av Aspose.Slides för .NET. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras - snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för programmatisk hantering av PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bildspel erbjuder det AI‑drivna funktioner – till exempel [Presentation Translation API](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/) för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller ingen inbyggd AI‑funktionalitet utan integreras med externa AI‑modeller via internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/slidesaiagent) som använder en implementation av gränssnittet [IAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/iaiwebclient/) för att kommunicera med AI‑tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/) för att ansluta till OpenAI:s API eller implementera ditt eget [IAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/iaiwebclient/) för att använda en annan AI‑leverantör eller språkmodell.

Aspose.Slides hanterar kommunikationen, tolkar AI‑svaren och infogar intelligent översatt innehåll samtidigt som det bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="info" title="Note" %}}

Observera att OpenAI API är en betaltjänst, så du måste skapa ett konto och ange din API‑nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/).

{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/) med en specificerad OpenAI [model](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Läs in en presentation för att översätta.
using var presentation = new Presentation("sample.pptx");

// Skapa en AI-klient med OpenAIWebClient och ange din modell samt API-nyckel.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initiera SlidesAIAgent med AI-klienten.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Översätt presentationen till japanska.
await aiAgent.TranslateAsync(presentation, "japanese");

// Spara den översatta presentationen som en PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/) sin egen interna [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-instans, vilket hanterar livscykel och borttagning automatiskt. Om du däremot föredrar att hantera [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) själv – till exempel när du använder en [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) för bättre resurshantering och prestanda – kan du tillhandahålla din egen `HttpClient`‑instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Använd en HttpClient som du hanterar själv - till exempel en som skapats av en IHttpClientFactory
// injicerad via beroendeinjektion.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides används ofta i synkrona miljöer. För att stödja detta erbjuder klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/slidesaiagent/) både synkrona och asynkrona metoder – så att du kan välja den metod som bäst passar ditt programflöde.

### **Azure OpenAI-exempel**

Aspose.Slides för .NET stöder OpenAI‑kompatibla leverantörer, inklusive Azure OpenAI. Du kan konfigurera översättaren att använda din interna Azure‑distribution med [OpenAICompatibleWebClient](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Det här kodsnutten visar hur du översätter en presentation med ditt Azure OpenAI‑slutpunkt. Ersätt platshållarvärdena med ditt distributionsnamn, API‑nyckel och slutpunkts‑URL.

## **Viktiga fördelar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/sv/net/aspose.slides.ai/) erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparas tid och fel minimeras jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, lärare eller affärsproffs möjliggör detta API att skapa engagerande, lokalanpassade presentationer för globala målgrupper – vilket utökar din räckvidd och förbättrar kommunikationen.