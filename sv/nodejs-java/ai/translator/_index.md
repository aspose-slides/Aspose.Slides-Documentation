---
title: AI-drivet presentationsöversättningsverktyg
linktitle: AI-drivet översättningsverktyg
type: docs
weight: 20
url: /sv/nodejs-java/ai/translator/
keywords:
- AI-presentationöversättare
- AI-bildöversättare
- AI-drivet funktion
- flerspråkig presentation
- flerspråkig bild
- presentationsöversättning
- bildöversättning
- AI-drivna funktioner
- AI-förmågor
- AI-agent
- webbklient
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Översätt PowerPoint-bilder med AI med Aspose.Slides för Node.js. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras - snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för programmatisk hantering av PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI-drivna funktioner – såsom Presentation Translation API för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller ingen inbyggd AI-funktionalitet men integreras med externa AI-modeller via internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesaiagent/) för att kommunicera med AI-tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) för att ansluta till OpenAI:s API.

Aspose.Slides hanterar kommunikationen, analyserar AI-svaren och infogar intelligent översatt innehåll samtidigt som den bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="primary" %}}
Observera att OpenAI API är en betald tjänst, så du måste skapa ett konto och ange din API-nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) och en specificerad OpenAI [model](https://platform.openai.com/docs/models).

```js
// Läs in en presentation för att översätta.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
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

Som standard skapar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/) och hanterar sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans, och styr dess livscykel automatiskt. Om du däremot föredrar att själv hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) – framför allt för att konfigurera viktiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resursförvaltning och prestanda – kan du tillhandahålla din egen `HttpURLConnection`-instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Anta att du har en förkonfigurerad HttpURLConnection-instans (t.ex. med anpassade tidsgränser, proxyinställningar osv.)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Viktiga fördelar**

Aspose.Slides Presentation Translation API erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparar den tid och minskar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, lärare eller affärsproffs möjliggör detta API att skapa engagerande, lokaliserade presentationer för en global publik – vilket expanderar din räckvidd och förbättrar kommunikationen.