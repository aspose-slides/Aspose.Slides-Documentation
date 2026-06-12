---
title: Geavanceerde tekstextractie uit presentaties in PHP
linktitle: Tekst extraheren
type: docs
weight: 90
url: /nl/php-java/extract-text-from-presentation/
keywords:
- tekst extraheren
- tekst extraheren uit dia
- tekst extraheren uit presentatie
- tekst extraheren uit PowerPoint
- tekst extraheren uit OpenDocument
- tekst extraheren uit PPT
- tekst extraheren uit PPTX
- tekst extraheren uit ODP
- tekst ophalen
- tekst ophalen uit dia
- tekst ophalen uit presentatie
- tekst ophalen uit PowerPoint
- tekst ophalen uit OpenDocument
- tekst ophalen uit PPT
- tekst ophalen uit PPTX
- tekst ophalen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Extraheer snel tekst uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides for PHP via Java. Volg onze eenvoudige, stapsgewijze handleiding om tijd te besparen."
---
## **Overzicht**

Tekst extraheren uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die werken met dia‑inhoud. Of je nu Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat behandelt, of OpenDocument‑presentaties (ODP), het benaderen en ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of content‑migratie.

Dit artikel biedt een uitgebreide gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met Aspose.Slides for PHP via Java. Je leert hoe je systematisch door presentatie‑elementen kunt itereren om nauwkeurig de gewenste tekstinhoud op te halen.

## **Tekst extraheren van een dia**

Aspose.Slides for PHP via Java biedt de klasse [SlideUtil](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/) . Deze klasse exposeert verschillende overladen statische methoden voor het extraheren van alle tekst uit een presentatie of dia. Om tekst uit een dia van een presentatie te extraheren, gebruik je de methode [getAllTextBoxes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/#getAllTextBoxes) . Deze methode accepteert een object van het type [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/) als parameter. Bij uitvoering scant de methode de gehele dia op tekst en retourneert een array van objecten van het type [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) , waarbij alle tekstopmaak behouden blijft.

De volgende code‑fragment extrahert alle tekst van de eerste dia van de presentatie:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Tekst extraheren uit een presentatie**

Om tekst uit de volledige presentatie te scannen, gebruik je de statische methode [getAllTextFrames](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/#getAllTextFrames) die wordt blootgesteld door de klasse [SlideUtil](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/) . Deze neemt twee parameters:

1. Ten eerste een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst wordt geëxtraheerd.
1. Ten tweede een `boolean`‑waarde die aangeeft of de master‑dia’s moeten worden meegenomen bij het scannen van de tekst uit de presentatie.

De methode retourneert een array van objecten van het type [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) , inclusief informatie over tekstopmaak. De code hieronder scant de tekst en formatteerinformatie uit een presentatie, inclusief de master‑dia’s.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gecategoriseerde en snelle tekstextractie**

De klasse [PresentationFactory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) biedt ook methoden om alle tekst uit presentaties te extraheren:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Het enum‑argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het ordenen van het resultaat van de tekstextractie en kan worden ingesteld op de volgende waarden:
- `Unarranged` - De ruwe tekst zonder rekening te houden met de positie op de dia.
- `Arranged` - De tekst wordt gerangschikt in dezelfde volgorde als op de dia.

De unarranged‑modus kan worden gebruikt wanneer snelheid cruciaal is; hij is sneller dan de arranged‑modus.

[PresentationText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. De `getSlidesText`‑methode retourneert een array van objecten waarbij elk object de tekst van de overeenkomstige dia weergeeft. Elk teruggegeven object heeft de volgende methoden:

- `getText` - De tekst binnen de vormen van de dia.
- `getMasterText` - De tekst binnen de vormen van de master‑dia die bij deze dia horen.
- `getLayoutText` - De tekst binnen de vormen van de lay‑out‑dia die bij deze dia horen.
- `getNotesText` - De tekst binnen de vormen van de notitiedia die bij deze dia horen.
- `getCommentsText` - De tekst binnen de opmerkingen die bij deze dia horen.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekstextractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/php-java/open-presentation/) verwerken, waardoor het geschikt is voor realtime‑ of bulk‑verwerking scenario's.

**Kan Aspose.Slides tekst extraheren uit tabellen en grafieken binnen presentaties?**

Ja. Aspose.Slides kan tekst extraheren uit vele dia‑elementen, inclusief tabellen en grafiekgerelateerde objecten, zodat je de tekstuele inhoud in gangbare presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [bepaalde beperkingen](/slides/nl/php-java/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia’s. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aanbevolen een volledige licentie aan te schaffen.