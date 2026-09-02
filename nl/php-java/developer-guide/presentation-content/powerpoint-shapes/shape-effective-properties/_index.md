---
title: Effectieve eigenschappen van vormen ophalen uit presentaties in PHP
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/php-java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtrig
- schuine vorm
- tekstframe
- tekststijl
- letterhoogte
- vulopmaak
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe je Aspose.Slides voor PHP via Java kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint‑presentaties te onderscheiden."
---
## **Begrijpen van lokale, overgeërfde en effectieve eigenschappen**

PowerPoint-opmaak kan afkomstig zijn uit verschillende bronnen. De waarde die rechtstreeks op een object wordt opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar bovenliggende opmaakbronnen, zoals een alinea-standaard, een tekst-stijl, een layout- of masterslide, een thema of presentatie-standaarden. Die waarden zijn **overgeërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is opgelost, is de **effectieve waarde**— de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstdelen kan zijn eigen letterhoogte niet definiëren. De lokale [getFontHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/) waarde is dan `NAN`, wat betekent "niet hier ingesteld". Het deel kan een hoogte erven van de alinea, de standaard tekststijl van de presentatie, of een andere toepasselijke bron. Het aanroepen van [getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/geteffective/) op het deel-formaat retourneert de uiteindelijk opgeloste hoogte.

Gebruik de twee soorten opmaakgegevens voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/), wanneer je moet bepalen waar een waarde wordt gedefinieerd.
- Lees een effectief gegevensobject, zoals de [data die wordt geretourneerd door PortionFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/geteffective/), wanneer je het uiteindelijke, gerenderde resultaat nodig hebt. Effectieve gegevens zijn alleen-lezen.

Voordat je de voorbeelden uitvoert, [installeer Aspose.Slides voor PHP via Java](/slides/nl/php-java/installation/).

## **Vergelijk lokale, overgeërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatie-, alinea- en deel-niveau. Elke stap drukt de waarden af die op die niveaus zijn gedefinieerd en de resulterende effectieve waarde voor hetzelfde tekstdelen. Het laat ook zien waarom effectieve gegevens opnieuw gelezen moeten worden na opmaakwijzigingen.

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

    // Lees effectieve gegevens na de voorgaande wijzigingen.
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

    // Definieer overgeërfde waarden op twee verschillende niveaus.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Een lokale waarde op het deel overschrijft beide overgeërfde waarden.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Het wijzigen van een overgeërfde waarde overschrijft geen bestaande lokale waarde.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Verwijder de lokale waarde. Het deel erft nu opnieuw van de alinea.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Verwijder de alinea-waarde. De presentatiestandaard levert nu het resultaat.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De prioriteit in dit voorbeeld is de lokale opmaak van het deel, vervolgens de alinea-opmaak, vervolgens de standaard van de presentatie. Andere objecten kunnen verschillende overervingsketens hebben, maar het principe blijft hetzelfde: een meer specifieke expliciete waarde wint, en [getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/geteffective/) retourneert het uiteindelijke resultaat.

## **Haal effectieve tekst-eigenschappen op**

Tekstopmaak is verdeeld over verschillende objecten:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/geteffective/) lost tekst-frame-eigenschappen op zoals marges, verankering, automatisch passend maken en verticale tekstrichting.
- [TextStyle.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textstyle/geteffective/) lost alinea-opmaak op voor elk tekst-stijlniveau.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/geteffective/) lost alinea-eigenschappen op zoals uitlijning, inspringing en opsommingstekens.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/geteffective/) lost teken-eigenschappen op zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` ten minste één dia en één [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) bevatten met een niet-lege tekst-frame. De AutoShape kan op elke positie in de vormcollectie staan; de code zoekt een geschikt object en valideert het vóór gebruik.

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

## **Haal effectieve 3D-eigenschappen op**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/) retourneert één effectief gegevensobject dat alle opgeloste 3D-instellingen groepeert. De methoden [getCamera](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/) en [getBevelBottom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/) geven de bijbehorende effectieve gegevens weer. Het samen lezen van deze gerelateerde instellingen maakt het makkelijker te begrijpen hoe de uiteindelijke 3D-weergave van een vorm eruitziet.

Voor dit voorbeeld moet `shape-3d.pptx` ten minste één vorm op de eerste dia bevatten. Pas 3D-camera-, verlichting- of schuine-instellingen toe op die vorm als je wilt dat de uitvoer andere waarden bevat dan de standaardwaarden.

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

## **Haal effectieve tabel-opmaak op**

Tabel-opmaak kan afkomstig zijn van de tabel-stijl en van opmaak die is toegepast op de volledige tabel, een kolom, een rij of een individuele cel. Bij conflicten tussen expliciet gedefinieerde vulopties is de prioriteit cel, rij, kolom en vervolgens de hele tabel. Het effectieve formaat van een cel is de uiteindelijke opmaak die wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` ten minste één tabel op de eerste dia bevatten. De tabel moet minimaal één rij en één kolom hebben. De code zoekt naar een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/) in plaats van ervan uit te gaan dat `getShapes()->get_Item(0)` een tabel is.

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

Als je de kleur nodig hebt in plaats van alleen het vultype, controleer dan eerst de effectieve [getFillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/geteffective/) waarde, en lees vervolgens de methode die bij dat type hoort - bijvoorbeeld [getSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/geteffective/) voor een effen vulkleur.

## **Lees effectieve gegevens opnieuw na wijzigingen**

Effectieve gegevens beschrijven de opmaak-hiërarchie op het moment dat deze wordt opgelost. Roep `getEffective` opnieuw aan nadat je iets hebt gewijzigd dat aan die hiërarchie kan deelnemen, inclusief:

- de lokale opmaak van het object;
- alinea- of tekst-frame-standaarden;
- een tabel-stijl, tabel, kolom, rij of cel-opmaak;
- layout- of masterslide-opmaak;
- themagegevens of presentatie-standaarden;
- de layout of master die aan een dia is toegewezen.

Houd een effectief gegevensobject niet als permanente momentopname. Aspose.Slides kan sommige effectieve gegevens intern cachen, en een later `getEffective`-aanroep kan die gegevens vernieuwen. Als je waarden vóór en na een wijziging wilt vergelijken, kopieer dan de scalare waarden die je nodig hebt - bijvoorbeeld een letterhoogte, kleur, uitlijning of schuine breedte - naar je eigen variabelen voordat je de wijziging doorvoert.

Om een waarde te wijzigen, werk je het betreffende lokale opmaakobject bij en roep je vervolgens `getEffective` aan om het resultaat te verifiëren. Effectieve gegevensobjecten zelf zijn alleen-lezen.

## **Veelgestelde vragen**

**Hoe weet ik welk niveau een effectieve waarde heeft geleverd?**

Effectieve gegevens bevatten de uiteindelijke waarde, niet de bron. Inspecteer de relevante lokale objecten vanaf het meest specifieke niveau naar buiten toe. Voor tekst kan dit het deel, de alinea, het tekst-frame, de layout, de master, het thema en de presentatie-standaarden omvatten. Niet-gedefinieerde waarden zoals `NAN` of `null` geven aan dat de zoekopdracht doorgaat naar een ander niveau.

**Wat gebeurt er als geen enkel niveau een eigenschap definieert?**

Aspose.Slides lost de geschikte PowerPoint- of bibliotheek-standaard op. Die opgeloste waarde verschijnt in de effectieve gegevens, ook al definieert geen lokaal object deze expliciet.

**Waarom komt een effectieve waarde soms overeen met de lokale waarde?**

De lokale waarde won de overervingsberekening. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale gegevens gebruiken in plaats van effectieve gegevens?**

Gebruik lokale gegevens om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve gegevens wanneer je de uiteindelijke weergave nodig hebt na overerving, themaregels en toepasselijke stijlen. Het [volledige vergelijkingsvoorbeeld](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.