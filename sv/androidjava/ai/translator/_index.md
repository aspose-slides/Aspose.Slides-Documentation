---
title: AI-drivet presentationsöversättningsverktyg
linktitle: AI-drivet översättningsverktyg
type: docs
weight: 20
url: /sv/androidjava/ai/translator/
keywords:
- AI-presentationöversättare
- AI-bildöversättare
- AI-driven funktion
- flerspråkig presentation
- flerspråkig bild
- presentationsöversättning
- bildöversättning
- AI-drivna funktioner
- AI-funktioner
- AI-agent
- Webbklient
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Översätt PowerPoint-bilder med AI med Aspose.Slides för Android via Java. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras—snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för att programatiskt hantera PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI-drivna funktioner - såsom Presentation Translation API för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI-funktioner utan integreras med externa AI-modeller över internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesaiagent/) som använder en implementation av gränssnittet [IAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaiwebclient/) för att kommunicera med AI-tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/) för att ansluta till OpenAIs API eller implementera din egen [IAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaiwebclient/) för att använda en annan AI-leverantör eller språkmodell.

Aspose.Slides hanterar kommunikationen, tolkar AI-svaren och infogar på ett intelligent sätt översatt innehåll samtidigt som den bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="primary" %}}
Observera att OpenAI API är en betaltjänst, så du måste skapa ett konto och ange din API-nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/) och en specificerad OpenAI-[model](https://platform.openai.com/docs/models).

```java
// Läs in en presentation för att översätta.
Presentation presentation = new Presentation("sample.pptx");

// Skapa en AI-klient med OpenAIWebClient, ange din modell och API-nyckel.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initiera SlidesAIAgent med AI-klienten.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Översätt presentationen till japanska.
    aiAgent.translate(presentation, "japanese");

    // Spara den översatta presentationen som en PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och sköter dess livscykel automatiskt. Men om du föredrar att hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) själv - främst för att konfigurera nödvändiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resurs-hantering och prestanda - kan du tillhandahålla din egen `HttpURLConnection`-instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/).

```java
// Anta att du har en förkonfigurerad HttpURLConnection-instans (t.ex. med anpassade tidsgränser, proxyinställningar, etc.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Viktiga fördelar**

Aspose.Slides Presentation Translation API erbjuder en AI-driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparar den tid och minskar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, lärare eller affärsproffs möjliggör detta API att skapa engagerande, lokaliserade presentationer för en global publik - vilket utökar din räckvidd och förbättrar kommunikationen.