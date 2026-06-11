---
title: AI-drivet flerspråkigt bildspelsgenerator
linktitle: AI-drivet generator
type: docs
weight: 40
url: /sv/java/ai/generator/
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
- Java
- Aspose.Slides
description: "Generera flerspråkiga bildspel från text med Aspose.Slides för Java. Använd din mall och exportera polerade presentationer till PowerPoint och OpenDocument. Läs mer."
---
## **Introduktion**

Aspose.Slides introducerar en ny AI‑driven funktion, Presentation Generator, som gör det möjligt för utvecklare att automatiskt skapa välstrukturerade PowerPoint‑presentationer från enkla textinmatningar såsom ämnesbeskrivningar, sammanfattningar, citat eller punktlistor.

Användare kan justera detaljnivån på innehållet och valfritt använda en anpassad presentationsmall för att definiera den visuella designen.

För närvarande strukturerar AI Presentation Generator innehållet med textblock, punktlistor och tabeller. Bildgenerering stöds ännu inte; dock kan bilder enkelt läggas till i efterhand med hjälp av Aspose.Slides‑verktyg eller manuellt.

Resultatet är en komplett PowerPoint‑presentation som kan användas som den är eller exporteras till vilket format som helst som stöds av Aspose.Slides‑API:t. Även om generatorn levererar högkvalitativa resultat kan mindre efterredigering krävas för att uppfylla specifika krav.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI‑modeller; istället integreras den med externa AI‑tjänster via internet. Denna integration hanteras av klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidesaiagent/) som använder en implementation av gränssnittet [IAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iaiwebclient/) för att kommunicera med AI‑modellen.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/), som ansluter till OpenAIs API, eller tillhandahålla en egen implementation av [IAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iaiwebclient/) för att arbeta med en annan AI‑leverantör eller språkmodell. Aspose.Slides hanterar all kommunikation med AI‑tjänsten och bearbetar AI‑svar för att generera bilder. Observera att OpenAI‑API:t är en betaltjänst, så ett konto och en API‑nyckel krävs när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/).

## **Låt oss koda**

### **Exempel 1**

Detta exempel visar hur man genererar en presentation om ämnet Aspose.Slides med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/).

```java
// Skapa en instans av OpenAIWebClient, den inbyggda implementeringen av OpenAI-webbklienten.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Skapa en instans av SlidesAIAgent, som ger åtkomst till AI-drivna funktioner.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definiera instruktionen för att generera presentationen.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generera en presentation med en medelstor mängd innehåll baserat på instruktionen.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Spara den genererade presentationen på den lokala disken som en PowerPoint (.pptx)-fil.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Exempel 2**

Följande exempel demonstrerar överlagringarna av metoden [generatePresentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). I detta fall används en externt hanterad [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instans och användarens `master presentation`.

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och sköter dess livscykel automatiskt. Om du däremot föredrar att hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) själv—till exempel när du använder en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för förbättrad resurshantering och prestanda—kan du ange din egen [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans vid konstruktion av [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/).

```java
// Skicka HttpURLConnection till OpenAIWebClient-konstruktorn.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Skapa en instans av SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definiera instruktionen för att generera presentationen.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Ladda en masterpresentation från den lokala disken för att använda som designmall.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Generera en detaljerad presentation med hjälp av instruktionen och mastermallen.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Spara den genererade presentationen som en PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Viktiga fördelar**

Den nya AI Presentation Generator i Aspose.Slides erbjuder ett snabbt och flexibelt sätt att producera strukturerade bildspel från enkla textpromptar. Med stöd för anpassade mallar och externt hanterade [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instanser kan den sömlöst integreras i ett brett spektrum av applikationer.

Vanliga användningsområden inkluderar skapande av marknadsföringspresentationer, utbildningsmaterial, kundrapporter och interna bildspel. Även om bildgenerering ännu inte stöds, erbjuder verktyget redan en stark grund för automatisering av presentationsskapande, med ytterligare förbättringar förväntade i framtiden.