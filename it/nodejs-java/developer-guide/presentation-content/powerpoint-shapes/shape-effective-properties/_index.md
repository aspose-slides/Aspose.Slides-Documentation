---
title: Ottieni le proprietà effettive della forma dalle presentazioni in JavaScript
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/nodejs-java/shape-effective-properties/
keywords:
- proprietà forma
- proprietà fotocamera
- rig di luce
- forma smussata
- cornice di testo
- stile testo
- altezza carattere
- formato riempimento
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara come utilizzare Aspose.Slides per Node.js via Java per distinguere la formattazione locale, ereditata ed efficace delle forme nelle presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate ed effettive**

PowerPoint formatting can come from several places. The value stored directly on an object is its **valore locale**. If that value is not set, PowerPoint looks at parent formatting sources, such as a paragraph default, a text style, a layout or master slide, a theme, or presentation-level defaults. Those values are **valori ereditati**. The value that remains after the entire hierarchy is resolved is the **valore effettivo**—the value used to render the object.

For example, a text portion may not define its own font height. Its local [getFontHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getFontHeight) value is then `NaN`, which means "not set here." The portion can inherit a height from its paragraph, the presentation's default text style, or another applicable source. Calling [getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getEffective) on the portion format returns the final resolved height.

Use the two kinds of formatting data for different purposes:

- Read or change a local format object, such as [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/), when you need to control where a value is defined.
- Read the [effective data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getEffective) when you need the final, rendered result. Effective data is read-only.

Before running the examples, [install Aspose.Slides for Node.js via Java](/slides/it/nodejs-java/installation/).

## **Confronta valori locali, ereditati ed effettivi**

The following complete example creates a shape and applies font heights at the presentation, paragraph, and portion levels. Each step prints the values defined at those levels and the resulting effective value for the same text portion. It also demonstrates why effective data must be read again after formatting changes.

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

    // Leggi i dati effettivi dopo le modifiche precedenti.
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

    // Definisci i valori ereditati a due livelli differenti.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Modificare un valore ereditato non sovrascrive un valore locale esistente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Cancella il valore locale. La porzione ora eredita dal paragrafo di nuovo.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Cancella il valore del paragrafo. Il valore predefinito della presentazione fornisce ora il risultato.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The priority in this example is portion local formatting, then paragraph formatting, then the presentation default. Other objects can have different inheritance chains, but the principle is the same: a more specific explicit value wins, and [getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getEffective) returns the final result.

## **Ottenere le proprietà di testo effettive**

Text formatting is split across several objects:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#getEffective) resolves text-frame properties such as margins, anchoring, autofit, and vertical text direction.
- [TextStyle.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textstyle/#getEffective) resolves paragraph formatting for each text style level.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#getEffective) resolves paragraph properties such as alignment, indentation, and bullets.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getEffective) resolves character properties such as font height, typeface, color, bold, and italic.

For the next example, `text-formatting.pptx` must contain at least one slide and one [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) with a non-empty text frame. The AutoShape can appear at any position in the shape collection; the code searches for a suitable object and validates it before use.

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

## **Ottenere le proprietà 3D effettive**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getEffective) returns one effective data object that groups all resolved 3D settings. Its [getCamera](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getBevelTop), and [getBevelBottom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getBevelBottom) methods expose the corresponding effective data. Reading these related settings together makes it easier to understand the final 3D appearance of a shape.

For this example, `shape-3d.pptx` must contain at least one shape on its first slide. Apply 3D camera, lighting, or bevel settings to that shape if you want the output to contain values other than the defaults.

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

## **Ottenere la formattazione della tabella effettiva**

Table formatting can come from the table style and from formats applied to the whole table, a column, a row, or an individual cell. For conflicts among explicitly defined fills, the priority is cell, row, column, and then whole table. The effective format of a cell is the final format used to draw that cell.

For this example, `table-formatting.pptx` must contain at least one table on its first slide. The table must have at least one row and one column. The code searches for a [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/) instead of assuming that `getShapes().get_Item(0)` is a table.

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

If you need the color rather than only the fill type, first check the effective [getFillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#getFillType), and then read the method that applies to that type—for example, [getSolidFillColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) for a solid fill.

## **Rileggere i dati effettivi dopo le modifiche**

Effective data describes the formatting hierarchy at the time it is resolved. Call `getEffective` again after changing anything that can participate in that hierarchy, including:

- the object's local formatting;
- paragraph or text-frame defaults;
- a table style, table, column, row, or cell format;
- layout or master slide formatting;
- theme data or presentation-level defaults;
- the layout or master assigned to a slide.

Do not keep an effective data object as a permanent snapshot. Aspose.Slides may cache some effective data internally, and a later `getEffective` call can refresh that data. If you need to compare values before and after a change, copy the scalar values you need—such as a font height, color, alignment, or bevel width—into your own variables before making the change.

To change a value, update the appropriate local format object and then call `getEffective` to verify the result. Effective data objects themselves are read-only.

## **FAQ**

**How can I tell which level supplied an effective value?**

Effective data contains the final value, not its source. Inspect the applicable local objects from the most specific level outward. For text, this can include the portion, paragraph, text frame, layout, master, theme, and presentation defaults. Undefined values such as `NaN` or `null` indicate that the search continues to another level.

**What happens when no level defines a property?**

Aspose.Slides resolves the appropriate PowerPoint or library default. That resolved value appears in the effective data even though no local object explicitly defines it.

**Why does an effective value sometimes equal the local value?**

The local value won the inheritance calculation. This is expected when the property is explicitly set on the object and no more specific rule overrides it.

**When should I use local data instead of effective data?**

Use local data to inspect or edit a specific formatting level. Use effective data when you need the final appearance after inheritance, theme rules, and applicable styles have been resolved. The [complete comparison example](#compare-local-inherited-and-effective-values) demonstrates both in the same workflow.