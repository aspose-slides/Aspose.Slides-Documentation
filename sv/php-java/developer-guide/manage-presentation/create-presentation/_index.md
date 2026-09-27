---
title: Skapa presentationer i PHP
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/php-java/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PPT
- ny PPT
- skapa PPTX
- ny PPTX
- skapa ODP
- ny ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa presentationer med Aspose.Slides för PHP via Java — producera PPT-, PPTX- och ODP-filer och spara dem programatiskt för tillförlitliga resultat."
---
## **Översikt**

Denna artikel visar hur man skapar en presentation i Aspose.Slides, lägger till en textruta på dess första bild och sparar resultatet som en fil. Den visar också hur man skapar och sparar en tom presentation, samt hur man öppnar en befintlig presentation i ett stödd format och sparar den i ett annat format. En kort FAQ i slutet täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

Innan du börjar, installera Aspose.Slides för PHP via Java med Composer och starta PHP/Java Bridge i Apache Tomcat. Se [Installation](/slides/sv/php-java/installation/) för den kompletta konfigurationen. Exemplen nedan förutsätter att Tomcat körs på `localhost:8080` och att Composer‑mappen `vendor` ligger bredvid skriptet.

## **Skapa en PowerPoint-presentation**

För att skapa en presentation och lägga till en textruta på dess första bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.  
2. Hämta den bilden från samlingen som returneras av [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), genom dess index, 0.  
3. Lägg till en rektangel med metoden [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) och sätt dess text med [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).  
4. Spara presentationen som en PPTX‑fil med metoden [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/sv/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De två `require_once`‑raderna laddar PHP/Java Bridge‑klienten från Tomcat och Aspose.Slides‑klasserna från Composer‑paketet. Rektangelns övre vänstra hörn ligger 50 punkter från vänsterkant och 50 punkter från övre kant på bilden, och rektangeln är 400 punkter bred och 100 punkter hög. Den sparade filen innehåller en bild med den rektangeln och dess text. Utan licens lägger Aspose.Slides även till ett utvärderingsvattenstämpel på varje bild den sparar; se [Licensiering](/slides/sv/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides läser och skriver filer inuti Tomcat, inte i din PHP‑process, så en relativ sökväg som `"hello.pptx"` löses mot Tomcats arbetsmapp. Exemplen på denna sida bygger absoluta sökvägar med `__DIR__`, så filerna läses från och sparas bredvid skriptet.
{{% /alert %}}

## **Skapa och spara en presentation**

För att skapa en tom presentation och spara den, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och spara den i valfritt format från [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/)-enumerationen. Resultatet är en presentation med en tom bild.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/sv/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Öppna och spara en presentation**

För att konvertera en presentation från ett format till ett annat, öppna den genom att skicka dess sökväg till [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-konstruktorn och spara den sedan i målformatet. Aspose.Slides identifierar indataformatet, såsom PPT, PPTX eller ODP, från själva filen.

Exemplet nedan förutsätter en OpenDocument-presentation med namnet *Sample.odp* bredvid skriptet och sparar den som PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/sv/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT och ODP](/slides/sv/php-java/save-presentation/), och exportera till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/php-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), [SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/) och [bilder](/slides/sv/php-java/convert-powerpoint-to-png/), med flera.

### Kan jag starta från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Läs in mallen och spara i önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/php-java/supported-file-formats/).

### Hur styr jag bildstorlek/bildformat när jag skapar en presentation?

Ställ in [bildstorleken](/slides/sv/php-java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller anpassade dimensioner) och välj hur innehållet ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediabitar) för att minska minnesanvändning?

Använd [BLOB‑hanteringsstrategier](/slides/sv/php-java/manage-blob/), begränsa lagring i minnet genom att utnyttja temporära filer, och föredra filbaserade arbetsflöden framför rena minnesströmmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta på samma [Presentation]‑instans från [flera trådar](/slides/sv/php-java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort provvattenstämpeln och begränsningarna?

[Applicera en licens](/slides/sv/php-java/licensing/) en gång per process. Licens‑XML-filen får inte modifieras, och licensinställningen bör synkroniseras om flera trådar är inblandade.

### Kan jag digitalt signera PPTX‑filen jag skapar?

Ja. [Digitala signaturer](/slides/sv/php-java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/php-java/presentation-via-vba/) och spara makroaktiverade filer såsom PPTM/PPSM.