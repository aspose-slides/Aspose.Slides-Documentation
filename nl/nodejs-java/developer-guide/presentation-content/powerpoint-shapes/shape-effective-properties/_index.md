---
title: Haal effectieve vormeigenschappen op uit presentaties in JavaScript
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/nodejs-java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtopstelling
- afgeschuinde vorm
- tekstframe
- tekststijl
- letterhoogte
- vulformaat
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor Node.js via Java kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint-presentaties te onderscheiden."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint-opmaak kan uit verschillende bronnen komen. De waarde die rechtstreeks op een object is opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar de opmaakbronnen van de ouder, zoals een alinea‑standaard, een tekst‑stijl, een lay‑out‑ of masterslide, een thema of standaardinstellingen op presentatie‑niveau. Die waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is opgelost, is de **effectieve waarde** — de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstdelen kan zijn eigen letterhoogte niet definiëren. De lokale [getFontHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getFontHeight)-waarde is dan `NaN`, wat betekent “hier niet ingesteld”. Het deel kan een hoogte erven van de alinea, de standaard‑tekst‑stijl van de presentatie, of een andere toepasselijke bron. Het aanroepen van [getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getEffective) op het deel‑formaat retourneert de uiteindelijk opgeloste hoogte.

Gebruik de twee soorten opmaakgegevens voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/), wanneer u moet bepalen waar een waarde is gedefinieerd.
- Lees de [effectieve data die wordt geretourneerd door PortionFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getEffective) wanneer u het uiteindelijke gerenderde resultaat nodig hebt. Effectieve data is alleen‑lezen.

Voordat u de voorbeelden uitvoert, [installeer Aspose.Slides voor Node.js via Java](/slides/nl/nodejs-java/installation/).

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatie‑, alinea‑ en deel‑niveau. Elke stap toont de waarden die op die niveaus zijn gedefinieerd en de resulterende effectieve waarde voor hetzelfde tekstdelen. Het laat ook zien waarom effectieve data opnieuw gelezen moet worden na formatteringswijzigingen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Lees effectieve gegevens na de voorgaande wijzigingen.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Definieer geërfde waarden op twee verschillende niveaus.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Een lokale waarde op het deel overschrijft beide geërfde waarden.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Het wijzigen van een geërfde waarde overschrijft een bestaande lokale waarde niet.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Wis de lokale waarde. Het deel erft nu opnieuw van de alinea.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Wis de alinea‑waarde. De presentatie‑standaard levert nu het resultaat.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De prioriteit in dit voorbeeld is de lokale opmaak van het deel, daarna de alinea‑opmaak, daarna de standaard van de presentatie. Andere objecten kunnen verschillende erfingsketens hebben, maar het principe is hetzelfde: een meer specifieke expliciete waarde heeft voorrang, en [getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getEffective) retourneert het uiteindelijke resultaat.

## **Haal effectieve teksteigenschappen op**

Tekstopmaak is verdeeld over verschillende objecten:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#getEffective) lost tekst‑frame‑eigenschappen op, zoals marges, verankering, automatisch passen en verticale tekstrichting.
- [TextStyle.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textstyle/#getEffective) lost alinea‑opmaak op voor elk tekst‑stijlniveau.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getEffective) lost alinea‑eigenschappen op, zoals uitlijning, inspringen en opsommingstekens.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getEffective) lost teken‑eigenschappen op, zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` ten minste één dia en één [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) met een niet‑leeg tekst‑frame bevatten. De AutoShape kan zich op elke positie in de vormverzameling bevinden; de code zoekt naar een geschikt object en valideert het vóór gebruik.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Haal effectieve 3D‑eigenschappen op**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getEffective) retourneert één effectief gegevensobject dat alle opgeloste 3D‑instellingen groepeert. De methoden [getCamera](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getBevelTop) en [getBevelBottom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getBevelBottom) tonen de respectieve effectieve gegevens. Het gezamenlijk lezen van deze gerelateerde instellingen maakt het makkelijker om het uiteindelijke 3D‑ uiterlijk van een vorm te begrijpen.

Voor dit voorbeeld moet `shape-3d.pptx` ten minste één vorm op de eerste dia bevatten. Pas 3D‑camera‑, verlichting‑ of afschuiningsinstellingen toe op die vorm als u wilt dat de uitvoer andere waarden dan de standaard bevat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Haal effectieve tabelopmaak op**

Tabelopmaak kan afkomstig zijn van de tabelstijl en van formats die op de hele tabel, een kolom, een rij of een individuele cel zijn toegepast. Bij conflicten tussen expliciet gedefinieerde opvullingen is de prioriteit cel, rij, kolom en daarna de hele tabel. Het effectieve format van een cel is het uiteindelijke format dat wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` ten minste één tabel op de eerste dia bevatten. De tabel moet ten minste één rij en één kolom hebben. De code zoekt naar een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/) in plaats van aan te nemen dat `getShapes().get_Item(0)` een tabel is.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Als u de kleur nodig heeft in plaats van alleen het vultype, controleer dan eerst de effectieve [getFillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#getFillType), en lees vervolgens de methode die op dat type van toepassing is — bijvoorbeeld [getSolidFillColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) voor een effen vulling.

## **Lees effectieve data opnieuw na wijzigingen**

Effectieve data beschrijft de opmaakhiërarchie op het moment dat deze wordt opgelost. Roep `getEffective` opnieuw aan nadat u iets hebt gewijzigd dat kan deelnemen aan die hiërarchie, inclusief:

- de lokale opmaak van het object;
- alinea‑ of tekst‑frame‑standaarden;
- een tabelstijl, tabel, kolom, rij of cel‑format;
- lay‑out‑ of master‑slide‑opmaak;
- themagegevens of standaardinstellingen op presentatie‑niveau;
- de lay‑out of master die aan een dia is toegewezen.

Bewaar een effectief gegevensobject niet als een permanente momentopname. Aspose.Slides kan sommige effectieve data intern cachen, en een latere `getEffective`‑aanroep kan die data verversen. Als u waarden vóór en na een wijziging moet vergelijken, kopieer dan de scalare waarden die u nodig hebt — zoals een letterhoogte, kleur, uitlijning of afschuiningsbreedte — naar uw eigen variabelen voordat u de wijziging doorvoert.

Om een waarde te wijzigen, werkt u het juiste lokale opmaakobject bij en roept u daarna `getEffective` aan om het resultaat te verifiëren. Effectieve gegevensobjecten zelf zijn alleen‑lezen.

## **FAQ**

**Hoe kan ik zien welk niveau een effectieve waarde heeft geleverd?**

Effectieve data bevat de uiteindelijke waarde, niet de bron. Inspecteer de toepasselijke lokale objecten van het meest specifieke niveau naar buiten. Voor tekst kan dit het deel, de alinea, het tekst‑frame, de lay‑out, de master, het thema en de standaardinstellingen van de presentatie omvatten. Niet‑gedefinieerde waarden zoals `NaN` of `null` duiden erop dat de zoektocht doorgaat naar een ander niveau.

**Wat gebeurt er als geen enkel niveau een eigenschap definieert?**

Aspose.Slides lost de juiste PowerPoint‑ of bibliotheek‑standaard op. Die opgeloste waarde verschijnt in de effectieve data, ook al definieert geen lokaal object het expliciet.

**Waarom is een effectieve waarde soms gelijk aan de lokale waarde?**

De lokale waarde heeft de erfberekening gewonnen. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale data gebruiken in plaats van effectieve data?**

Gebruik lokale data om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve data wanneer u de uiteindelijke weergave nodig heeft na erfelijkheid, themaregels en toepasselijke stijlen die zijn opgelost. Het [complete vergelijkingsvoorbeeld](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.