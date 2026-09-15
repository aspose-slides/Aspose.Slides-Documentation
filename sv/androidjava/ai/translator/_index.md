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
- presentationöversättning
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
description: "Översätt PowerPoint‑bilder med AI med Aspose.Slides för Android via Java. Lokalisera PPT, PPTX och ODP samtidigt som layout bevaras — snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för programmatisk hantering av PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI‑drivna funktioner – såsom Presentation Translation API för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inte inbyggda AI‑funktioner utan integreras med externa AI‑modeller över internet. Denna funktion exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesaiagent/) som använder en implementering av gränssnittet [IAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaiwebclient/) för att kommunicera med AI‑tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/) för att ansluta till OpenAIs API eller implementera din egen [IAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaiwebclient/) för att använda en annan AI‑leverantör eller språkmodell.

Aspose.Slides hanterar kommunikationen, tolkar AI‑svaren och infogar intelligent översatt innehåll samtidigt som den behåller det ursprungliga bildlayouten och formateringen.

{{% alert color="info" title="Note" %}}
Observera att OpenAI API är en betaltjänst, så du måste skapa ett konto och ange din API‑nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/) och en specificerad OpenAI‑[modell](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Læs in en presentation för att översätta.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
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

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och hanterar dess livscykel automatiskt. Om du föredrar att hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) själv – främst för att konfigurera viktiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resurshantering och prestanda – kan du tillhandahålla din egen `HttpURLConnection`‑instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Konfigurera en HttpURLConnection-instans själv (t.ex. med anpassade tidsgränser, proxyinställningar osv.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Skicka anslutningen till OpenAIWebClient-konstruktorn.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI‑exempel**

Du kan konfigurera översättaren för att använda din Azure OpenAI‑distribution med [OpenAICompatibleWebClient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Detta kodsnutt visar hur man översätter en presentation med ditt Azure OpenAI‑slutpunkt. Ersätt platshållarvärdena med ditt distributionsnamn, API‑nyckel och slutpunkts‑URL.

## **Viktiga fördelar**

Aspose.Slides Presentation Translation API erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint‑presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparar den tid och minskar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, lärare eller affärsproffs möjliggör detta API att skapa engagerande, lokalanpassade presentationer för en global publik – vilket ökar din räckvidd och förbättrar kommunikationen.