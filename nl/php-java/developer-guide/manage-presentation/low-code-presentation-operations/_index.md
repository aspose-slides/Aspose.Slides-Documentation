---
title: Low-Code presentatiewerk in PHP
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/php-java/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingesloten fonts comprimeren
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in PHP om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De namespace [aspose.slides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/) biedt statische helperklassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte objectmodel‑workflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte content kunt verwijderen met minder code.

Low‑code helpers zijn het meest nuttig wanneer de handeling van toepassing is op een heel bestand of een hele presentatie en de standaard workflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides objectmodel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia’s, masters, lay-outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor te gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/php-java/aspose.slides/convert/) | Een presentatie naar een ander formaat converteren met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/php-java/aspose.slides/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach_](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/) | Een callback uitvoeren voor elke dia, vorm, alinea of tekstdelen. |
| [Collect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/collect/) | Vormen uit de hele presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/) | Ongebruikte masters en lay-outs verwijderen en ingesloten font‑data reduceren. |

## **Een presentatie converteren**

Gebruik [Convert::autoByExtension](https://reference.aspose.com/slides/nl/php-java/aspose.slides/convert/#autoByExtension) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te selecteren. De methode opent de bronpresentatie, bepaalt het vereiste formaat aan de hand van het uitvoerpad en schrijft het resultaat.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/php-java/aspose.slides/convert/)‑klasse biedt ook speciale methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑output. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of wijzigen vóór export, of wanneer u een exportoptie moet configureren die door de geselecteerde helper niet wordt blootgesteld. Zie [Convert Presentation](/php-java/convert-presentation/) voor formaat‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger::process](https://reference.aspose.com/slides/nl/php-java/aspose.slides/merger/#process) om volledige presentaties met één aanroep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia’s moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of te remappen. Gebruik het volledige objectmodel wanneer u geselecteerde dia’s wilt samenvoegen, een bestemmings‑master of -lay-out wilt toepassen, secties expliciet wilt behouden, of verschillende dia‑groottes wilt reconciliëren. Zie [Merge Presentations](/php-java/merge-presentation/) voor die scenario’s.

## **Door presentatiedelen itereren**

De [ForEach_](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/)‑klasse roept een callback op voor elk gevraagd type presentatiedeel. Het voorkomt geneste collectie‑loops en is handig voor inspectie of opmaakwijzigingen op presentatieniveau.

Het volgende voorbeeld gebruikt [ForEach_::slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#paragraph) en [ForEach_::portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#portion) om de overeenkomstige elementen te inspecteren:

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

Standaard omvat de dia‑brede vorm‑ en tekst‑traversie normale, master‑ en lay‑outdia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe collectie‑loops wanneer de volgorde van traversie, vroegtijdig stoppen, filteren vóór de callback‑aanroep, of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect::shapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/collect/#shapes) wanneer u een collectie van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set later gefilterd, geteld of meerdere keren verwerkt moet worden.

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

Gebruik in plaats daarvan [ForEach_::shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#shape) wanneer elke vorm meteen kan worden afgehandeld en u de verzamelde resultaten niet hoeft te behouden.

## **Presentatie‑content comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten font‑data reduceren:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) verwijdert lay‑outdia’s die door geen normale dia worden gerefereerd.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedMasterSlides) verwijdert masters die niet meer worden gebruikt.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#compressEmbeddedFonts) verwijdert ongebruikte tekens uit ingesloten fonts.

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

Verwijder eerst ongebruikte lay‑outs voordat u ongebruikte masters verwijdert, zodat een master die na het opschonen van lay‑outs niet meer wordt gerefereerd, eveneens kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de originele masters, lay‑outs of volledige ingesloten font‑data nodig heeft. Zie [Slide Master](/php-java/slide-master/) en [Embedded Font](/php-java/embedded-font/) voor meer details.

## **FAQ**

**Wanneer moet ik de low‑code API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardhandeling op een compleet bestand of een volledige presentatie van toepassing is en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia’s moet selecteren, master‑ en lay‑outr relaties moet beheren, de tussenliggende status moet inspecteren, of gedrag moet configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren met verschillende bestandsformaten?**

Nee. [Merger::process](https://reference.aspose.com/slides/nl/php-java/aspose.slides/merger/#process) vereist invoer‑presentaties in hetzelfde formaat. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert::autoByExtension](https://reference.aspose.com/slides/nl/php-java/aspose.slides/convert/#autoByExtension), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach_ master‑, lay‑out‑ en notitiedia’s?**

[ForEach_::slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#slide) iterereert door normale presentatiedia’s. Presentatie‑brede [ForEach_::shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#paragraph) en [ForEach_::portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#portion) operaties omvatten standaard normale, master‑ en lay‑outdia’s. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia’s mee te nemen.

**Wat is het verschil tussen ForEach_::shape en Collect::shapes?**

Gebruik [ForEach_::shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/#shape) om elke vorm onmiddellijk via een callback te verwerken. Gebruik [Collect::shapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/collect/#shapes) wanneer u een iterabele resultaatset nodig heeft die kan worden behouden, gefilterd, geteld of meerdere keren doorlopen.

**Maakt Compress altijd de presentatiedatei kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten fonts met ongebruikte tekens bevat. Als geen van deze aanwezig is, zullen de corresponderende [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/)‑bewerkingen mogelijk geen reductie van de bestandsgrootte opleveren.

**Worden wijzigingen gemaakt door ForEach_ of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach_](https://reference.aspose.com/slides/nl/php-java/aspose.slides/foreach_/)‑callback of [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/) hebt uitgevoerd, roept u [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)