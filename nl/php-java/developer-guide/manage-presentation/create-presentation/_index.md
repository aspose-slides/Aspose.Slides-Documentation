---
title: Presentaties maken in PHP
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/php-java/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak presentaties met Aspose.Slides voor PHP via Java — genereer PPT-, PPTX- en ODP‑bestanden en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel toont hoe u een presentatie maakt in Aspose.Slides, een tekstvak toevoegt aan de eerste dia en het resultaat opslaat als een bestand. Het laat tevens zien hoe u een lege presentatie maakt en opslaat, en hoe u een bestaande presentatie in een ondersteund formaat opent en opslaat in een ander formaat. Een korte FAQ aan het einde beantwoordt veelgestelde vragen over formaten, sjablonen, dia‑afmetingen, eenheden, geheugengebruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

Voordat u begint, installeert u Aspose.Slides voor PHP via Java met Composer en start u de PHP/Java Bridge in Apache Tomcat. Zie [Installation](/slides/nl/php-java/installation/) voor de volledige installatie. De voorbeelden hieronder gaan ervan uit dat Tomcat draait op `localhost:8080` en dat de Composer `vendor`‑map zich naast het script bevindt.

## **PowerPoint‑presentatie maken**

Om een presentatie te maken en een tekstvak op de eerste dia te plaatsen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse. Een nieuwe presentatie bevat al één lege dia.  
2. Haal die dia op uit de collectie die wordt geretourneerd door [Presentation::getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getslides/), met index 0.  
3. Voeg een rechthoek toe met de [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addautoshape/) methode en stel de tekst in met [TextFrame::setText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/settext/).  
4. Sla de presentatie op als een PPTX‑bestand met de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/save/) methode.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

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

De twee `require_once`‑regels laden de PHP/Java Bridge‑client van Tomcat en de Aspose.Slides‑klassen uit het Composer‑pakket. De linkerbovenhoek van de rechthoek bevindt zich 50 punten van de linkerrand en 50 punten van de bovenzijde van de dia, en de rechthoek is 400 punten breed en 100 punten hoog. Het opgeslagen bestand bevat één dia met die rechthoek en tekst. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die het opslaat; zie [Licensing](/slides/nl/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides leest en schrijft bestanden binnen Tomcat, niet in uw PHP‑proces, dus een relatief pad zoals `"hello.pptx"` wordt ten opzichte van de werkmap van Tomcat opgelost. De voorbeelden op deze pagina bouwen absolute paden met `__DIR__`, waardoor de bestanden worden gelezen vanuit en opgeslagen naast het script.
{{% /alert %}}

## **Presentatie maken en opslaan**

Om een lege presentatie te maken en op te slaan, maakt u een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse en slaat u deze op in een willekeurig formaat van de [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) enumeratie. Het resultaat is een presentatie met één lege dia.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Presentatie openen en opslaan**

Om een presentatie van het ene formaat naar het andere te converteren, opent u deze door het pad door te geven aan de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) constructor, en slaat u deze vervolgens op in het doel‑formaat. Aspose.Slides detecteert het invoerformaat, zoals PPT, PPTX of ODP, aan de hand van het bestand zelf.

Het voorbeeld hieronder verwacht een OpenDocument‑presentatie met de naam *Sample.odp* naast het script en slaat deze op als PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

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

### In welke formaten kan ik een nieuwe presentatie opslaan?

U kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/php-java/save-presentation/), en exporteren naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/php-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), [SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/) en [afbeeldingen](/slides/nl/php-java/convert-powerpoint-to-png/), onder andere.

### Kan ik beginnen vanuit een sjabloon (POTX/POTM) en opslaan als een reguliere PPTX?

Ja. Laad het sjabloon en sla het op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/php-java/supported-file-formats/).

### Hoe beheer ik de dia‑grootte/verhoudingsratio bij het maken van een presentatie?

Stel de [dia‑grootte](/slides/nl/php-java/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet worden geschaald.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In punten: 1 inch is gelijk aan 72 eenheden.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?

Gebruik [BLOB-beheerstrategieën](/slides/nl/php-java/manage-blob/), beperk opslag in het geheugen door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestandsgebaseerde workflows boven puur in‑memory streams.

### Kan ik presentaties parallel maken/opslaan?

U kunt niet tegelijk op dezelfde [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) instantie werken vanuit [meerdere threads](/slides/nl/php-java/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proef‑watermerk en de beperkingen?

[Pas een licentie toe](/slides/nl/php-java/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑instelling moet gesynchroniseerd worden als er meerdere threads betrokken zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digitale handtekeningen](/slides/nl/php-java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro's (VBA) ondersteund in gemaakte presentaties?

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/php-java/presentation-via-vba/) en macro‑ingeschakelde bestanden zoals PPTM/PPSM opslaan.