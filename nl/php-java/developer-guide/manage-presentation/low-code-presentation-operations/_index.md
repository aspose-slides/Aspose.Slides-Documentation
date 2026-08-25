---
title: Low-Code presentatietaken in PHP
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/php-java/low-code-presentation-operations/
keywords:
- low-code presentatie API
- presentatie converteren
- presentaties samenvoegen
- dia's doorlopen
- vormen doorlopen
- tekst doorlopen
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in PHP om presentaties te converteren en samen te voegen, door content te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De namespace aspose.slides biedt statische hulpprogrammaclassen voor algemene presentatietaken. Deze helpers verpakken veelgebruikte objectmodel‑workflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code helpers zijn het meest nuttig wanneer de bewerking van toepassing is op een heel bestand of een hele presentatie en de standaard‑workflow aan uw eisen voldoet. Gebruik het volledige Aspose.Slides‑objectmodel wanneer u fijne controle nodig hebt over individuele dia’s, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/php-java/aspose.slides/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/php-java/aspose.slides/merger/) | Complete presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach_](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/) | Een callback uitvoeren voor elke dia, vorm, alinea of tekstdeel. |
| [Collect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/collect/) | Vormen ophalen uit de volledige presentatie voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑gegevens verkleinen. |

## **Een presentatie converteren**

Gebruik Convert::autoByExtension wanneer de bestands­extensie van de uitvoer voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het uitvoerpad en schrijft het resultaat.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

De Convert‑klasse biedt ook speciale methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑output. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of aanpassen vóór export of een exportoptie moet configureren die niet beschikbaar is via de geselecteerde helper. Zie [Convert Presentation](/slides/nl/php-java/convert-presentation/) voor format‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik Merger::process om volledige presentatiebestanden met één aanroep te combineren. De invoerpresentaties moeten hetzelfde bestandsformaat hebben.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia's moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of te remappen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's moet samenvoegen, een doel‑master of –lay‑out moet toepassen, secties expliciet moet behouden, of verschillende dia‑groottes moet harmoniseren. Zie [Merge Presentations](/slides/nl/php-java/merge-presentation/) voor die scenario’s.

## **Door presentatie‑elementen itereren**

De ForEach_‑klasse roept een callback aan voor elk gevraagd type presentaties‑element. Het vermijdt geneste verzamelings‑lussen en is handig voor inspectie of formatteringswijzigingen voor de hele presentatie.

Het volgende voorbeeld gebruikt ForEach_::slide, ForEach_::shape, ForEach_::paragraph en ForEach_::portion om de overeenkomstige elementen te inspecteren:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Standaard omvat de vorm‑ en tekstdoorloop voor de gehele presentatie normale, master‑ en lay‑out‑dia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe verzamelings‑lussen wanneer de doorloopvolgorde, vroegtijdig afbreken, filteren vóór de callback‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik Collect::shapes wanneer u een collectie van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is handig wanneer dezelfde set meerdere keren gefilterd, geteld of verwerkt zal worden.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Gebruik ForEach_::shape in plaats daarvan wanneer elke vorm onmiddellijk kan worden verwerkt en u het verzamelde resultaat niet hoeft te behouden.

## **Presentatie‑inhoud comprimeren**

De Compress‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens verkleinen:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) verwijdert lay‑out‑dia’s die door geen enkele normale dia worden aangeduid.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedMasterSlides) verwijdert master‑dia’s die niet meer worden gebruikt.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#compressEmbeddedFonts) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verwijder ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na het opruimen van lay‑outs geen referenties meer heeft, ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later mogelijk de originele masters, lay‑outs of volledige ingesloten lettertype‑gegevens nodig heeft. Zie [Slide Master](/slides/nl/php-java/slide-master/) en [Embedded Font](/slides/nl/php-java/embedded-font/) voor meer details.

## **FAQ**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of een volledige presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia’s moet selecteren, relaties tussen masters en lay‑outs moet beheren, de tussentijdse status moet inspecteren, of gedrag moet configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. Merger::process vereist invoerpresentaties in hetzelfde formaat. Converteer eerst de invoerbestanden naar een gemeenschappelijk formaat, bijvoorbeeld met Convert::autoByExtension, en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach_ master‑, lay‑out‑ en notitiedia’s?**

ForEach_::slide doorloopt de normale presentatiedia’s. Presentatie‑brede ForEach_::shape, ForEach_::paragraph en ForEach_::portion‑operaties omvatten standaard normale, master‑ en lay‑out‑dia’s. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia’s op te nemen.

**Wat is het verschil tussen ForEach_::shape en Collect::shapes?**

Gebruik ForEach_::shape om elke vorm onmiddellijk via een callback te verwerken. Gebruik Collect::shapes wanneer u een doorloopbaar resultaat nodig heeft dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Verkleint Compress altijd het presentatie‑bestand?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, kunnen de betreffende Compress‑operaties de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen gemaakt door ForEach_ of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen Presentation‑object in het geheugen. Nadat u elementen hebt gewijzigd in een ForEach_-callback of Compress hebt uitgevoerd, roept u Presentation::save aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Presentatie converteren](/slides/nl/php-java/convert-presentation/)
- [Presentaties samenvoegen](/slides/nl/php-java/merge-presentation/)
- [Dia‑master](/slides/nl/php-java/slide-master/)
- [Tekstvak beheren](/slides/nl/php-java/manage-textbox/)
- [Ingesloten lettertype](/slides/nl/php-java/embedded-font/)