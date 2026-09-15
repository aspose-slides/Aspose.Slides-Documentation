---
title: AI-driven presentationsöversättare
linktitle: AI-driven översättare
type: docs
weight: 20
url: /sv/java/ai/translator/
keywords:
- AI presentationsöversättare
- AI bildöversättare
- AI-driven funktion
- flerspråkig presentation
- flerspråkig bild
- presentationöversättning
- bildöversättning
- AI-drivna funktioner
- AI-förmågor
- AI-agent
- Webbklient
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Översätt PowerPoint-bilder med AI med Aspose.Slides för Java. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras - snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för att programatiskt hantera PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI‑drivna funktioner – såsom Presentation Translation API för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inte inbyggda AI‑funktioner utan integreras med externa AI‑modeller över internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidesaiagent/) som använder en implementation av gränssnittet [IAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iaiwebclient/) för att kommunicera med AI‑tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/) för att ansluta till OpenAIs API eller implementera din egen [IAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iaiwebclient/) för att använda en annan AI‑leverantör eller språkmodell.

Aspose.Slides hanterar kommunikationen, analyserar AI‑svaren och infogar intelligent översatt innehåll samtidigt som den bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="info" title="Note" %}}
Observera att OpenAI API är en betaltjänst, så du måste skapa ett konto och ange din API‑nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/) och en specificerad OpenAI‑[model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Läs in en presentation för översättning.
Presentation presentation = new Presentation("sample.pptx");

// Skapa en AI-klient med OpenAIWebClient, ange din modell och API-nyckel.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initiera SlidesAIAgent med AI-klienten.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Översätt presentationen till japanska.
    aiAgent.translate(presentation, "japanese");

    // Spara den översatta presentationen som PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instans och sköter dess livscykel automatiskt. Men om du föredrar att hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) själv – främst för att konfigurera viktiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resurshantering och prestanda – kan du tillhandahålla din egen `HttpURLConnection`‑instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Konfigurera en HttpURLConnection-instans själv (anpassade tidsgränser, proxy-inställningar osv.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI‑exempel**

Du kan konfigurera översättaren att använda din Azure OpenAI‑distribution med [OpenAICompatibleWebClient](https://reference.aspose.com/slides/sv/java/com.aspose.slides/openaicompatiblewebclient/).

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

Det här kodsnutten demonstrerar hur man översätter en presentation med din Azure OpenAI‑ändpunkt. Ersätt platshållarvärdena med ditt deploymentsnamn, API‑nyckel och URL för ändpunkten.

## **Nyckelfördelar**

Aspose.Slides Presentation Translation API erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparar den tid och minskar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, utbildare eller affärsproffs gör detta API det möjligt att skapa engagerande, lokalanpassade presentationer för en global målgrupp – vilket ökar din räckvidd och förbättrar kommunikationen.