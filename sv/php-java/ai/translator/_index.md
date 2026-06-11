---
title: AI‑driven presentationsöversättare
linktitle: AI‑driven översättare
type: docs
weight: 20
url: /sv/php-java/ai/translator/
keywords:
- AI presentationsöversättare
- AI bildöversättare
- AI‑driven funktion
- flerspråkig presentation
- flerspråkig bild
- presentationöversättning
- bildöversättning
- AI‑drivna funktioner
- AI‑funktioner
- AI‑agent
- Webbklient
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Översätt PowerPoint‑bilder med AI med Aspose.Slides för PHP. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras – snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för programmatisk hantering av PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI‑drivna funktioner - såsom Presentation Translation API för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inte inbyggda AI‑funktioner utan integreras med externa AI‑modeller via internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesaiagent/) för att kommunicera med AI‑tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/) för att ansluta till OpenAIs API.

Aspose.Slides hanterar kommunikationen, tolkar AI‑svaren och infogar på ett intelligent sätt översatt innehåll samtidigt som den bevarar den ursprungliga bildlayouten och formateringen.

{{% alert color="primary" %}}
Observera att OpenAI API är en betaltjänst, så du måste skapa ett konto och ange din API‑nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I detta exempel översätter vi en PowerPoint-presentation till japanska med hjälp av den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/) och en specificerad OpenAI [modell](https://platform.openai.com/docs/models).

```php
// Ladda en presentation för översättning.
$presentation = new Presentation("sample.pptx");

// Skapa en AI‑klient med OpenAIWebClient, ange din modell och API‑nyckel.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initiera SlidesAIAgent med AI‑klienten.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Översätt presentationen till japanska.
    $aiAgent->translate($presentation, "japanese");

    // Spara den översatta presentationen som PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-instans och hanterar dess livscykel automatiskt. Men om du föredrar att själv hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — främst för att konfigurera viktiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resurshantering och prestanda — kan du tillhandahålla din egen `HttpURLConnection`-instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/).

```php
// Anta att du har en förkonfigurerad HttpURLConnection-instans (t.ex. med anpassade tidsgränser, proxyinställningar, etc.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Viktiga fördelar**

Aspose.Slides Presentation Translation API erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparas tid och fel minimeras jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, lärare eller affärsproffs gör detta API det möjligt att skapa engagerande, lokalanpassade presentationer för globala målgrupper – vilket ökar din räckvidd och förbättrar kommunikationen.