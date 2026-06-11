---
title: AI-drivet flerspråkig bildgenerator
linktitle: AI-drivet Generator
type: docs
weight: 40
url: /sv/nodejs-java/ai/generator/
keywords:
- flerspråkig presentation
- flerspråkigt bildspel
- AI-presentationgenerator
- AI-bildgenerator
- AI-driven funktion
- AI-agent
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Generera flerspråkiga bilder från text med Aspose.Slides för Node.js. Använd din mall och exportera polerade bildspel till PowerPoint och OpenDocument. Läs mer."
---
## **Introduktion**

Aspose.Slides introducerar en ny AI-drivet funktion, Presentation Generator, som gör det möjligt för utvecklare att automatiskt skapa välstrukturerade PowerPoint‑presentationer från enkla textinmatningar såsom ämnesbeskrivningar, sammanfattningar, citat eller punktlistor.

Användare kan justera detaljnivån på innehållet och valfritt tillämpa en anpassad presentationsmall för att definiera den visuella designen.

För närvarande strukturerar AI Presentation Generator innehållet med textblock, punktlistor och tabeller. Bildgenerering stöds ännu inte; dock kan bilder enkelt läggas till i efterhand med hjälp av Aspose.Slides‑verktyg eller manuellt.

Resultatet är en komplett PowerPoint‑presentation som kan användas direkt eller exporteras till något format som stöds av Aspose.Slides API. Även om generatorn levererar högkvalitativa resultat kan mindre efterredigering behövas för att uppfylla specifika krav.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI-modeller; istället integreras den med externa AI-tjänster via internet. Denna integration hanteras av klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesaiagent/).

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/), som ansluter till OpenAIs API. Aspose.Slides hanterar all kommunikation med AI‑tjänsten och bearbetar AI:s svar för att generera bilder. Observera att OpenAI API är en betaltjänst, så ett konto och en API‑nyckel krävs när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).

## **Låt oss koda**

### **Exempel 1**

Detta exempel visar hur man genererar en presentation om ämnet Aspose.Slides med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Skapa en instans av OpenAIWebClient, den inbyggda implementeringen av OpenAI-webbklienten.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Skapa en instans av SlidesAIAgent, som ger tillgång till AI-drivna funktioner.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definiera instruktionen för att generera presentationen.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generera en presentation med en medelstor mängd innehåll baserat på instruktionen.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Spara den genererade presentationen till den lokala disken som en PowerPoint (.pptx)-fil.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Exempel 2**

Följande exempel demonstrerar överlagringarna av metoden [generatePresentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). I detta fall används en externt hanterad [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och användarens `master presentation`.

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och hanterar dess livscykel automatiskt. Men om du föredrar att hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) själv — till exempel när du använder en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för förbättrad resursförvaltning och prestanda — kan du tillhandahålla din egen [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Skicka HttpURLConnection till OpenAIWebClient-konstruktorn.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Skapa en instans av SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definiera instruktionen för att generera presentationen.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Ladda en huvudpresentation från den lokala disken för att använda som designtmall.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Generera en detaljerad presentation med hjälp av instruktionen och huvudmall.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Spara den genererade presentationen som en PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Viktiga fördelar**

Den nya AI Presentation Generator i Aspose.Slides ger ett snabbt och flexibelt sätt att skapa strukturerade bildspel från enkla textuppmaningar. Med stöd för anpassade mallar och externt hanterade [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instanser kan den sömlöst integreras i ett brett spektrum av applikationer.

Typiska användningsfall inkluderar att skapa marknadsföringspresentationer, utbildningsmaterial, kundrapporter och interna bildspel. Även om bildgenerering ännu inte stöds erbjuder verktyget redan en solid grund för automatisering av presentationsskapande, med ytterligare förbättringar förväntade i framtiden.