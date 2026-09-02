---
title: Hämta effektiva egenskaper för former från presentationer i PHP
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/php-java/shape-effective-properties/
keywords:
- formegenskaper
- kamerainställningar
- ljusrigg
- fasettform
- textram
- textstil
- teckenhöjd
- fyllformat
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du använder Aspose.Slides för PHP via Java för att skilja mellan lokal, ärvd och effektiv formatering av former i PowerPoint-presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint-formatering kan komma från flera ställen. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är angivet tittar PowerPoint på föräldraformateringskällor, såsom ett stycke‑standardvärde, en textstil, en layout‑ eller masternedslide, ett tema eller standardvärden på presentationsnivå. Dessa värden är **ärvda värden**. Värdet som återstår efter att hela hierarkin har lösts är **det effektiva värdet** – värdet som används för att rendera objektet.

Till exempel kanske en textdel inte definierar sin egen teckenhöjd. Dess lokala [getFontHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/)‑värde blir då `NAN`, vilket betyder "inte angivet här". Textdelen kan ärva en höjd från sitt stycke, presentationens standard‑textstil eller en annan tillämplig källa. Genom att anropa [getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/geteffective/) på portionens format får du den slutgiltigt lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, till exempel [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/), när du behöver kontrollera var ett värde definieras.
- Läs ett effektivt datatobjekt, såsom [data som returneras av PortionFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/geteffective/), när du behöver det slutgiltiga, renderade resultatet. Effektiv data är skrivskyddad.

Innan du kör exemplen, [installera Aspose.Slides för PHP via Java](/slides/sv/php-java/installation/).

## **Jämför lokala, ärvda och effektiva värden**

Det följande fullständiga exemplet skapar en form och tilldelar teckenhöjder på presentations-, stycke‑ och portionsnivå. Varje steg skriver ut de värden som definierats på dessa nivåer samt det resulterande effektiva värdet för samma textdel. Det visar också varför effektiv data måste läsas igen efter formateringsändringar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Läs effektiv data efter de föregående ändringarna.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Definiera ärvda värden på två olika nivåer.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Ett lokalt värde på portionen åsidosätter båda ärvda värden.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Att ändra ett ärvt värde åsidosätter inte ett befintligt lokalt värde.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Rensa det lokala värdet. Portionen ärver nu från paragrafen igen.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Rensa paragrafvärdet. Presentationens standardvärde levererar nu resultatet.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prioriteten i detta exempel är portionslokal formatering, sedan styckeformatering, sedan presentationens standard. Andra objekt kan ha olika arvskedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/geteffective/) returnerar slutresultatet.

## **Hämta effektiva textegenskaper**

Textformatering är uppdelad på flera objekt:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/geteffective/) löser text‑ram‑egenskaper såsom marginaler, förankring, autofit och vertikal textriktning.
- [TextStyle.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textstyle/geteffective/) löser styckeformatering för varje textstilsnivå.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/geteffective/) löser styckeegenskaper såsom justering, indrag och punktlistor.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/geteffective/) löser teckengenskaper såsom teckenhöjd, teckensnitt, färg, fetstil och kursiv.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) med en icke‑tom textramhållare. AutoShape kan finnas på vilken position som helst i form‑samlingen; koden söker efter ett lämpligt objekt och validerar det innan det används.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Hämta effektiva 3D‑egenskaper**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/) returnerar ett effektivt datatobjekt som grupperar alla lösta 3D‑inställningar. Dess metoder [getCamera](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/) och [getBevelBottom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/geteffective/) visar motsvarande effektiv data. Att läsa dessa relaterade inställningar tillsammans gör det enklare att förstå den slutgiltiga 3D‑utformningen av en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på den första bilden. Tilldela 3D‑kamera, belysning eller fasettinställningar till den formen om du vill att resultatet ska innehålla andra värden än standardvärdena.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen och från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och sedan hela tabellen. Den effektiva formatet för en cell är det slutgiltiga format som används för att rita den cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på den första bilden. Tabellens måste ha minst en rad och en kolumn. Koden söker efter en [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/) istället för att anta att `getShapes()->get_Item(0)` är en tabell.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Om du behöver färgen snarare än bara fyllningstypen, kontrollera först det effektiva [getFillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/geteffective/)-värdet och läs sedan den metod som gäller för den typen – till exempel [getSolidFillColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/geteffective/) för en solid fyllning.

## **Läs effektiv data igen efter ändringar**

Effektiv data beskriver formateringshierarkin vid den tidpunkt den lösts. Anropa `getEffective` igen efter att du ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- stycke‑ eller textram‑standarder;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller masternedslide‑formatering;
- temadata eller standardinställningar på presentationsnivå;
- layouten eller mastern som tilldelats en bild.

Behåll inte ett effektivt datatobjekt som en permanent ögonblicksbild. Aspose.Slides kan cachea viss effektiv data internt, och ett senare `getEffective`‑anrop kan uppdatera den datan. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver – såsom teckenhöjd, färg, justering eller fasettbredd – till dina egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan `getEffective` för att verifiera resultatet. Effektiva datatobjekt är skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiv data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera portionen, stycket, textramen, layouten, mastern, temat och presentationsstandarderna. Odefinierade värden såsom `NAN` eller `null` indikerar att sökningen fortsätter till en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser det lämpliga PowerPoint‑ eller bibliotekstandardvärdet. Det lösta värdet visas i den effektiva datan även om inget lokalt objekt explicit definierar det.

**Varför är ett effektivt värde ibland lika med det lokala värdet?**

Det lokala värdet vann arvberäkningen. Detta är förväntat när egenskapen är explicit satt på objektet och ingen mer specifik regel åsidosätter det.

**När bör jag använda lokala data istället för effektiv data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiv data när du behöver den slutgiltiga utseendet efter arv, temaregel och tillämpliga stilar har lösts. [Det kompletta jämförelseexemplet](#compare-local-inherited-and-effective-values) visar båda i samma arbetsflöde.