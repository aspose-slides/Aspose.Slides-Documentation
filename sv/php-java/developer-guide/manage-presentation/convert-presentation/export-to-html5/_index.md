---
title: Konvertera presentationer till HTML5 i PHP
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/php-java/export-to-html5/
keywords:
- PowerPoint till HTML5
- OpenDocument till HTML5
- presentation till HTML5
- slide till HTML5
- PPT till HTML5
- PPTX till HTML5
- ODP till HTML5
- spara PPT som HTML5
- spara PPTX som HTML5
- spara ODP som HTML5
- exportera PPT till HTML5
- exportera PPTX till HTML5
- exportera ODP till HTML5
- PHP
- Aspose.Slides
description: "Exportera PowerPoint‑ och OpenDocument‑presentationer till responsiv HTML5 med Aspose.Slides för PHP via Java. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides för PHP via Java. Den täcker grundläggande export, kontroll av formanimationer och bildövergångar, samt kommentarslayout. Den jämför också HTML5-utdata med den SVG-baserade utdata från standard‑HTML‑export.

## **Exportera PowerPoint till HTML5**

Följande exempel läser in en presentation från arbetskatalogen och sparar den i HTML5-format. Det använder standardexportinställningarna; nästa exempel visar hur man kontrollerar animeringsuppspelning explicit. Ersätt inmatningssökvägen med sökvägen till din presentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Obs" %}}
Förutom HTML‑dokumentet skriver exporten stödjande CSS‑ och JavaScript‑filer för bildstyling, animationer, effekter och navigation. Behåll dessa filer tillsammans med HTML‑dokumentet när du flyttar eller publicerar utdata. Den genererade sidan laddar även jQuery och Anime.js från offentliga CDN:er; utan dem fungerar inte bildnavigering och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, skicka `false` till [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) och [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) i [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena medan du inaktiverar den andra. Exemplet exporterar presentationen med båda typerna av animation inaktiverade i den genererade sidan.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Exportera PowerPoint till HTML**

Standard‑HTML‑exporten använder ett annat renderingssätt: bildinnehållet representeras av SVG inom en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med detta renderingssätt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Den förenklade markupen nedan illustrerar strukturen för den genererade sidan. SVG‑elementet innehåller det renderade bildinnehållet; platshållartexten representerar det innehållet och är inte en faktisk exportoutput.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Varning" color="warning" %}}
Den SVG‑baserade exporten exponerar inte PowerPoint‑former som enskilda HTML‑element. Använd HTML5‑export när du behöver formanimation‑ och bildövergångsalternativen som demonstreras i den här artikeln.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

HTML5‑exporten skapar en sida för att visa och navigera i presentationens bilder i en webbläsare. Detta exempel aktiverar både [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) och [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) så att den exporterade bildvyn kan spela upp effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som saknar dem. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödjande filer tillgängliga.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsare kan se återkoppling bredvid bildinnehållet. Exemplet i det här avsnittet förutsätter att källpresentationen innehåller kommentarer, som illustrerat nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/)‑objekt till metoden [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) i [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Använd [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) för att välja `Right` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) för att placera kommentarerna till höger om varje bild.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Följande exempel exporterar presentationen till HTML5 med denna kommentarslayout. En presentation utan kommentarer kommer inte att ha någon kommentartext att visa.

![Kommentarerna i det exporterade HTML5‑dokumentet](two_comments_html5.png)

## **Exkludera JavaScript‑hyperlänkar vid export**

Anta att `hyperlinks.pptx` innehåller länkad text med ett `javascript:alert('Hello')`‑mål och en vanlig `https://example.com/`‑länk. För att exkludera JavaScript‑hyperlänken vid export, skicka `true` till [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Standardvärdet är `false`, så dessa länkar filtreras inte om du inte aktiverar alternativet.

Följande exempel läser in presentationen från arbetskatalogen och exporterar den med [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Den exporterade filen utelämnar JavaScript‑hyperlänken men behåller dess text och den vanliga HTTPS‑länken. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och det garanterar inte CSP‑efterlevnad. Till exempel innehåller HTML5‑utdata fortfarande skript för bildnavigering och animationer.

## **Vanliga frågor**

**Kan jag styra om objektanimationer och bildövergångar ska spelas upp i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [formanimationer](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) och [bildövergångar](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och positioneras (t.ex. till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, inställningen [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) låter dig hoppa över hyperlänkar med JavaScript‑anrop under sparande. Standardvärdet är `false`. Se [Exkludera JavaScript‑hyperlänkar vid export](/slides/sv/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett HTML5‑exportexempel och filteromfånget. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigation och animationer.