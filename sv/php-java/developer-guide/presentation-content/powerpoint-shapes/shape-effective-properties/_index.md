---
title: Hämta effektiva formegenskaper från presentationer i PHP
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/php-java/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusanordning
- fasettform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för PHP via Java beräknar och tillämpar effektiva formegenskaper för exakt PowerPoint-rendering."
---
## **Översikt**

Detta ämne förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som sätts direkt på en specifik formateringsnivå, till exempel:

1. Portionsegenskaper på en bild.
1. Prototypformens textstilar på en layout‑ eller masternivå, när portionens textramhänsliga form har en sådan.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga “som renderad” formateringen löser den arvskedjan och returnerar **effektiva** värden. Du kan få dem genom att anropa `getEffective`‑metoden på det lokala formatobjektet.

Följande exempel visar hur man får effektiva värden. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) med en textram och minst en portion.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Effektiv formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt som returneras av metoder såsom [PortionFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/geteffective/) cachas internt. Att anropa `getEffective` igen efter att föräldra‑ eller ärvd formatering har ändrats kan uppdatera den cachade datan, och ett tidigare hämtat objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckensnittsstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Den effektiva data som returneras av [ThreeDFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/) innehåller de slutgiltiga kameraegenskaperna för ett [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/).

Följande kodexempel visar hur man hämtar effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Hämta effektiva egenskaper för en ljusanordning**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusanordning. Den effektiva data som returneras av [ThreeDFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/) innehåller de slutgiltiga ljusanordningsegenskaperna för ett [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/).

Följande kodexempel visar hur man hämtar effektiva egenskaper för ljusanordningen. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Hämta effektiva egenskaper för en fasettform**

Aspose.Slides låter dig hämta effektiva egenskaper för en fasettring. Den effektiva data som returneras av [ThreeDFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/) innehåller de slutgiltiga ytreliefsegenskaperna för ett [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/).

Följande kodexempel visar hur man hämtar effektiva egenskaper för den övre fasetten på en form. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Den effektiva data som returneras av [TextFrameFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/geteffective/) innehåller egenskaper för textramens formatering.

Följande kodexempel visar hur man hämtar effektiva formateringsegenskaper för en textram. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) med en textram.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Den effektiva data som returneras av [TextStyle.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textstyle/geteffective/) innehåller egenskaper för textstilen.

Följande kodexempel visar hur man hämtar effektiva textstilegenskaper. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) med en textram.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Hämta det effektiva teckenhöjdsvärdet**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod demonstrerar hur en portions effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har satts på olika nivåer i presentationsstrukturen.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hämta den effektiva fyllningsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika tabellens delar. Den effektiva data som returneras av formatobjekten innehåller [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/)‑egenskaper. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än hela‑tabellformatering.

Som ett resultat används effektiva [CellFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellformat/)‑egenskaper för att rita tabellcellen. Följande kodexempel visar hur man hämtar effektiv fyllningsformatering för olika tabellens delar. Det förutsätter att den första formen på den första bilden är en [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Returnerar `getEffective` ett ögonblicksbilder?**

Inte alltid. Effektiv data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachas internt. Ett efterföljande anrop av `getEffective` kan omberäkna formateringen och uppdatera den cachade datan, så ett tidigare hämtat objekt bör inte betraktas som en beständig ögonblicksbild.

**När bör jag läsa effektiva egenskaper igen?**

Anropa `getEffective` igen efter att lokal formatering, föräldra‑stilar, layout‑formatering, master‑formatering eller presentationens standardvärden har ändrats. Nästa anrop räknar om formateringshierarkin och returnerar det aktuella effektiva resultatet.

**Påverkar ändring eller borttagning av en layout/masternivå effektiva egenskaper som redan har hämtats?**

Ja, men förändringen syns först vid nästa `getEffective`‑anrop. Om en föräldrakälla för formatering ändras eller tas bort kan tidigare hämtad effektiv data vara föråldrad. När `getEffective` anropas igen utvärderar Aspose.Slides formateringsträdet på nytt och de resulterande teckensnitten, färgerna, storlekarna eller andra värden kan förändras.

**Kan jag ändra värden via effektiva dataobjekt?**

Nej. Effektiva dataobjekt exponerar beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena på nytt.

**Vad händer om en egenskap inte är satt på formnivå, varken i layout/masternivå eller i globala inställningar?**

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standarder. Det lösta värdet blir en del av den aktuella effektiva datan.

**Kan jag ur ett effektivt teckenvärde avgöra på vilken nivå storlek eller teckensnitt har angetts?**

Inte direkt. Effektiv data returnerar det slutgiltiga värdet. För att hitta källan, kontrollera lokala värden på portion, stycke, textram och textstilar på layout‑, master‑ och presentationsnivå för att se var den första explicita definitionen finns.

**Varför ser effektiva värden ibland identiska ut med de lokala?**

För att det lokala värdet visade sig vara det slutgiltiga (ingen högre nivå behövdes). I sådana fall matchar det effektiva värdet det lokala.

**När ska jag använda effektiva egenskaper, och när ska jag arbeta enbart med lokala?**

Använd effektiva data när du behöver resultatet “som renderat” efter att all arv har tillämpats, t.ex. för att matcha färger, indrag eller storlekar. Om du behöver bevara dessa värden oberoende av framtida formateringsändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du behöver ändra formatering på en specifik nivå, modifiera lokala egenskaper och, vid behov, läs de effektiva data igen för att verifiera resultatet.