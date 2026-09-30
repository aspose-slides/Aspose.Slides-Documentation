---
title: जावास्क्रिप्ट में प्रस्तुतियों की तालिकाएँ प्रबंधित करें
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/nodejs-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएँ
- तालिका तक पहुँचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल कोड उदाहरणों की खोज करें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मूल्यों को पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) class, [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) class, and other types to allow you to create, update, and manage tables in presentations.

## **शुरू से एक तालिका बनाना**

Create a table by specifying its position, column widths, and row heights. After adding it to a slide, you can format cell borders, merge cells, and insert text.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Define an array of column widths in points.
4. Define an array of row heights in points.
5. Add a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) object to the slide through the [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) method.
6. Iterate through each [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row.
8. Access the merged cell through its [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) method.
9. Set the text in the merged cell.
10. Save the modified presentation.

The example below creates a table with three columns and five rows at (100, 50) points. It applies red borders with a width of 5 points, merges the first two cells in the first row, and saves the result as `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मानक तालिका में क्रमांकन**

In a standard table, cell indices are zero-based and use the order (column, row). The first cell is indexed as (0, 0).

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This example creates the 4 × 4 table illustrated above, with column widths and row heights of 70 points and red cell borders with a width of 5 points. The coordinates illustrate cell indices; the example leaves the cells empty and saves the table as `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मौजूद तालिका तक पहुंच**

Tables are stored in a slide's shape collection. Iterate through the shapes to locate a table, then use the [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) class to read or update its cells.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Get a reference to the slide containing the table by its index.
3. Iterate through the [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) objects and stop when a table is found. If the slide contains several tables, use [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) to identify the one you need.
4. Update the text in the target cell.
5. Save the modified presentation.

The example below opens `UpdateExistingTable.pptx` and finds the first table on the first slide. It sets the cell at column 0, row 1 to `New` and saves the result as `table1_out.pptx`. The input must contain at least one slide, and the first table on that slide must have at least one column and two rows.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

To resize a row in an existing table and understand why its actual height can exceed the requested minimum, see [Control Row Height](/slides/hi/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Find the Cell That Owns a Text Frame**

When generic text-processing code receives a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) from a table, use the [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) method to retrieve the owning [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/). For a table-cell text frame, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) returns the owner and [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) returns `null`, even though the table itself is a shape.

The cell coordinates are available through the read-only [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) and [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) methods. [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) also provides read-only navigation: it returns the owner but does not change ownership. Always check the returned cell for `null` before using it.

For a complete example that identifies table-cell and shape owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/hi/nodejs-java/search-and-replace-text/).

## **Align Text in a Table**

You can control the vertical anchoring and text direction of individual table cells. The example in this section centers text within the first cell and rotates it by 270 degrees.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Add a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) object to the slide.
4. Access a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) object from the table.
5. Access the first [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) and set its text and color.
6. Set the cell's vertical anchoring and text direction using [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) and [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Save the modified presentation.

This example creates a 4 × 4 table with column widths of 120 points and row heights of 100 points. It formats the text in cell (0, 0), adds values to the remaining cells in the first row, and saves the result as `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set Text Formatting on the Table Level**

Use [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) to apply text formatting to all cells in a table. Its overloads accept portion, paragraph, and text frame formatting, so you can set these properties without iterating through individual cells.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Access a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) object from the slide.
4. Set the font size using [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) for the text.
5. Set paragraph alignment and the right margin using [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) and [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Set the text direction using [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation.

The example below opens `table.pptx`, which must contain at least one slide with a table as its first shape. It sets the font size to 25 points, right-aligns paragraphs with a right margin of 20 points, and makes the text vertical. The formatted presentation is saved as `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get Table Style Properties**

Use [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) to read a table's preset style and [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) to assign it. This example applies [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) to one table, prints the preset value, and assigns the same preset to a second table. Both tables are saved in `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lock Aspect Ratio of a Table**

A table's aspect ratio is the ratio of its width to its height. Use [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) to lock this ratio for a table.

The example below opens `pres.pptx`, which must contain at least one slide with a table as its first shape. It prints the current lock state, enables the aspect ratio lock, prints the updated state (`true`), and saves the result as `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) method, and paragraphs have [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).