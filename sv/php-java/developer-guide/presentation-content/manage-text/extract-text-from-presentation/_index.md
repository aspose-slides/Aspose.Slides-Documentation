---
title: Avancerad textutvinning från presentationer i PHP
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/php-java/extract-text-from-presentation/
keywords:
- extrahera text
- extrahera text från bild
- extrahera text från presentation
- extrahera text från PowerPoint
- extrahera text från OpenDocument
- extrahera text från PPT
- extrahera text från PPTX
- extrahera text från ODP
- hämta text
- hämta text från bild
- hämta text från presentation
- hämta text från PowerPoint
- hämta text från OpenDocument
- hämta text från PPT
- hämta text från PPTX
- hämta text från ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Följ vår enkla, steg-för-steg-guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men samtidigt viktig uppgift för utvecklare som arbetar med bildspelsinnehåll. Oavsett om du hanterar Microsoft PowerPoint‑filer i PPT‑ eller PPTX‑format, eller OpenDocument‑presentationer (ODP), kan åtkomst till och hämtning av textuell data vara kritisk för analys, automation, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide för hur du på ett effektivt sätt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med hjälp av Aspose.Slides for PHP via Java. Du kommer att lära dig hur du systematiskt itererar genom presentationselement för att exakt hämta den text du behöver.

## **Extrahera text från en bild**

Aspose.Slides for PHP via Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/). Denna klass exponerar flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation, använd metoden [getAllTextBoxes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/#getAllTextBoxes). Denna metod accepterar ett objekt av typen [BaseSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/) som parameter. Vid körning skannar metoden hela bilden efter text och returnerar en array av objekt av typen [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/), med bibehållen formatering.

Följande kodsnutt extraherar all text från den första bilden i presentationen:

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

## **Extrahera text från en presentation**

För att skanna text från hela presentationen, använd den statiska metoden [getAllTextFrames](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/#getAllTextFrames) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/). Den accepterar två parametrar:

1. Först, ett [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation från vilken text ska extraheras.
1. För det andra, ett `boolean`‑värde som anger om master‑bilderna ska inkluderas när text skannas i presentationen.

Metoden returnerar en array av objekt av typen [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/), inklusive information om textformatering. Koden nedan skannar texten och formateringsdetaljerna från en presentation, inklusive master‑bilderna.

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

## **Kategoriserad och snabb textutvinning**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) tillhandahåller också metoder för att extrahera all text från presentationer:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Argumentet av typen [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textextractionarrangingmode/) anger hur resultatet av textutvinning ska organiseras och kan sättas till följande värden:
- `Unarranged` – Råtext utan hänsyn till dess position på bilden.
- `Arranged` – Texten ordnas i samma sekvens som på bilden.

Det oordnade läget kan användas när hastighet är kritisk; det är snabbare än det ordnade läget.

[PresentationText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationtext/) representerar den råa text som extraherats från presentationen. Dess metod `getSlidesText` returnerar en array av objekt där varje objekt representerar texten på den motsvarande bilden. Varje returnerat objekt har följande metoder:

- `getText` – Texten inom bildens former.
- `getMasterText` – Texten inom master‑bildens former som är associerade med denna bild.
- `getLayoutText` – Texten inom layout‑bildens former som är associerade med denna bild.
- `getNotesText` – Texten inom antecknings‑bildens former som är associerade med denna bild.
- `getCommentsText` – Texten inom kommentarer som är associerade med denna bild.

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

**Hur snabbt bearbetar Aspose.Slides stora presentationer vid textutvinning?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/php-java/open-presentation/), vilket gör det lämpligt för realtids‑ eller massbearbetningsscenarier.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan få åtkomst till och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides‑licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/php-java/licensing/), såsom att endast ett begränsat antal bilder kan bearbetas. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en fullständig licens.