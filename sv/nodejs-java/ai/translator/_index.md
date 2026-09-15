---
title: AI‑driven presentationsöversättare
linktitle: AI‑driven översättare
type: docs
weight: 20
url: /sv/nodejs-java/ai/translator/
keywords:
- AI-presentationöversättare
- AI-bildöversättare
- AI‑driven funktion
- flerspråkig presentation
- flerspråkig bild
- presentationsöversättning
- bildöversättning
- AI‑drivna funktioner
- AI‑funktioner
- AI‑agent
- Webbklient
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Översätt PowerPoint‑bilder med AI med hjälp av Aspose.Slides för Node.js. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras—snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för programmatisk hantering av PowerPoint‑presentationer. Förutom att skapa, redigera och konvertera bildspel erbjuder det AI‑drivna funktioner – såsom Presentation Translation‑API:t för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI‑funktioner utan integreras med externa AI‑modeller över internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesaiagent/) för att kommunicera med AI‑tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) för att ansluta till OpenAIs API.

Aspose.Slides hanterar kommunikationen, tolkar AI‑svaren och infogar översatt innehåll på ett intelligent sätt samtidigt som den bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="info" title="Note" %}}

Observera att OpenAI‑API:t är en betaltjänst, så du måste skapa ett konto och ange din API‑nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Exempel**

I detta exempel översätter vi en PowerPoint‑presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) och en specificerad OpenAI‑[modell](https://platform.openai.com/docs/models).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Läs in en presentation för att översätta.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Skapa en AI-klient med OpenAIWebClient, ange din modell och API-nyckel.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initiera SlidesAIAgent med AI-klienten.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Översätt presentationen till japanska.
    aiAgent.translate(presentation, "japanese");

    // Spara den översatta presentationen som en PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och hanterar dess livscykel automatiskt. Om du däremot föredrar att själv hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) – främst för att konfigurera viktiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resursförvaltning och prestanda – kan du tillhandahålla din egen `HttpURLConnection`‑instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI‑exempel**

Du kan konfigurera översättaren att använda din Azure OpenAI‑distribution med [OpenAICompatibleWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Detta kodsnutt demonstrerar hur man översätter en presentation med din Azure OpenAI‑endpoint. Ersätt platshållarvärdena med ditt distributionsnamn, din API‑nyckel och endpoint‑URL.

## **Viktiga fördelar**

Aspose.Slides Presentation Translation‑API erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint‑presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras, sparar det tid och minskar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, lärare eller affärsprofessionell möjliggör detta API att skapa engagerande, lokalanpassade presentationer för en global publik – vilket utökar din räckvidd och förbättrar kommunikationen.