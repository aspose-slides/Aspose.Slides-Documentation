---
title: AI-drivet presentationsöversättare
linktitle: AI-drivet Översättningsverktyg
type: docs
weight: 20
url: /sv/php-java/ai/translator/
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
- PHP
- Aspose.Slides
description: "Översätt PowerPoint-bilder med AI med hjälp av Aspose.Slides för PHP. Lokalisera PPT, PPTX och ODP samtidigt som layouten bevaras - snabbt och utvecklarvänligt. Prova det."
---
## **Introduktion**

Aspose.Slides är ett kraftfullt API för att programatiskt hantera PowerPoint-presentationer. Förutom att skapa, redigera och konvertera bilder erbjuder det AI‑drivna funktioner – såsom Presentation Translation API för flerspråkigt bildinnehåll.

## **Hur det fungerar**

Aspose.Slides innehåller inga inbyggda AI‑funktioner utan integreras med externa AI‑modeller över internet. Denna funktionalitet exponeras via klassen [SlidesAIAgent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesaiagent/) för att kommunicera med AI‑tjänster.

Du kan använda den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/) för att ansluta till OpenAIs API.

Aspose.Slides hanterar kommunikationen, tolkar AI‑svaren och sätter intelligent in översatt innehåll samtidigt som den bevarar det ursprungliga bildlayouten och formateringen.

{{% alert color="info" title="Note" %}}
Observera att OpenAI API är en betaltjänst, så du måste skapa ett konto och ange din API‑nyckel när du använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exempel**

I det här exemplet översätter vi en PowerPoint-presentation till japanska med den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/) och en specificerad OpenAI [modell](https://platform.openai.com/docs/models).

```php
// Läs in en presentation för att översätta.
$presentation = new Presentation("sample.pptx");

// Skapa en AI-klient med OpenAIWebClient, specificera din modell och API-nyckel.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initiera SlidesAIAgent med AI-klienten.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Översätt presentationen till japanska.
    $aiAgent->translate($presentation, "japanese");

    // Spara den översatta presentationen som en PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Som standard skapar och hanterar den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/) sin egen interna [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instans och sköter dess livscykel automatiskt. Om du däremot föredrar att hantera [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) själv – främst för att konfigurera viktiga inställningar som en proxy, eller för att använda en [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) eller en annan [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) för bättre resurshantering och prestanda – kan du tillhandahålla din egen `HttpURLConnection`‑instans när du konstruerar [OpenAIWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaiwebclient/).

```php
// Skapa och förkonfigurera din egen HttpURLConnection-instans (anpassade timeout‑värden, proxy‑inställningar osv.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Skicka anslutningen till AI-klienten.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI‑exempel**

Du kan konfigurera översättaren att använda din Azure OpenAI‑distribution med [OpenAICompatibleWebClient](https://reference.aspose.com/slides/sv/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Detta kodsnutt demonstrerar hur man översätter en presentation med ditt Azure OpenAI‑slutpunkt. Ersätt platshållarvärdena med ditt deploymentsnamn, API‑nyckel och slutpunkt‑URL.

## **Viktiga fördelar**

Aspose.Slides Presentation Translation API erbjuder en AI‑driven lösning för att leverera flerspråkiga PowerPoint-presentationer. Genom att automatisera översättningen samtidigt som layout och design bevaras sparar den tid och minimerar fel jämfört med manuella arbetsflöden. Oavsett om du är utvecklare, utbildare eller affärsprofessionell gör detta API det möjligt att skapa engagerande, lokalt anpassade presentationer för globala målgrupper – vilket utökar din räckvidd och förbättrar kommunikationen.