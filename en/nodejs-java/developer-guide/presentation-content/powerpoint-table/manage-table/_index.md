---
title: Manage Presentation Tables in JavaScript
linktitle: Manage Table
type: docs
weight: 10
url: /nodejs-java/manage-table/
keywords:
- add table
- create table
- access table
- aspect ratio
- align text
- text formatting
- table style
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Create & edit tables in PowerPoint slides with JavaScript and Aspose.Slides for Node.js. Discover simple code examples to streamline your table workflows."
---

## **Introduction**

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) class, [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) class, and other types to allow you to create, update, and manage tables in all kinds of presentations.

## **Create Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object to the slide through the [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Iterate through each [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the four cells in the table's top-left corner (the first two columns of the first two rows) into a single cell. 
8. Access an [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
10. Save the modified presentation.

This JavaScript code shows you how to create a table in a presentation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantiates a Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Accesses the first slide
    var sld = pres.getSlides().get_Item(0);
    // Defines columns with widths and rows with heights
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Adds a table shape to slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Sets the border format for each cell
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Merges the top-left 2x2 block of cells into one cell
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Adds some text to the merged cell
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Saves the presentation to Disk
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numbering in Standard Table**

In a standard table, the numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). 

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This JavaScript code shows you how to specify the numbering for cells in a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantiates a Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Accesses first slide
    var sld = pres.getSlides().get_Item(0);
    // Defines columns with widths and rows with heights
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Adds a table shape to slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Sets the border format for each cell
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Saves presentation to disk
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.

2. Get a reference to the slide containing the table through its index. 

3. Create an [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object and set it to null.

4. Iterate through all [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Use the [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object to work with the table. In the example below, we set the text of a cell in the table.

6. Save the modified presentation.

This JavaScript code shows you how to access and work with an existing table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantiates the Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Accesses the first slide
    var sld = pres.getSlides().get_Item(0);
    // Initializes null TableEx
    var tbl = null;
    // Iterates through the shapes and sets a reference to the table found
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Sets the text for the first column of the second row
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Saves the modified presentation to disk
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Find the Cell That Owns a Text Frame**

When generic text-processing code receives a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) from a table, use the [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) method to retrieve the owning [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/). For a table-cell text frame, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) returns the owner and [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) returns `null`, even though the table itself is a shape.

The cell coordinates are available through the read-only [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) and [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) methods. [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) also provides read-only navigation: it returns the owner but does not change ownership. Always check the returned cell for `null` before using it.

For a complete example that identifies table-cell and shape owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/nodejs-java/search-and-replace-text/).


## **Align Text in Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object to the slide.
4. Access an [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) object from the table.
5. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
6. Align the text vertically.
7. Save the modified presentation.

This JavaScript code shows you how to align the text in a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Creates an instance of the Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide
    var slide = pres.getSlides().get_Item(0);
    // Defines columns with widths and rows with heights
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Adds the table shape to the slide
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Accesses the text frame
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Creates the Paragraph object for the text frame
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Creates the Portion object for paragraph
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Aligns the text vertically
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Saves the presentation to disk
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Text Formatting on Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Access an [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object from the Slide.
4. Set the [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) for the text.
5. Set the [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Set the [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation. 

This JavaScript code shows you how to apply your preferred formatting options to the text in a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Creates an instance of the Presentation class
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Let's assume that the first shape on the first slide is a table
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Sets the table cells' font height
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Sets the table cells' text alignment and right margin in one call
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Sets the table cells' text vertical type
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Table Style Preset**

Aspose.Slides ships the built-in PowerPoint table styles as the [TableStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) enumeration, so you can apply the same look to any table. This JavaScript code shows you how to replace a table's default style with a preset style:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// change the default style preset theme
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lock Aspect Ratio of Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provided the [**setAspectRatioLocked**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)  property to allow you to lock the aspect ratio setting for tables and other shapes.

This JavaScript code shows you how to lock the aspect ratio for a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/) method, and paragraphs have [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use shape locks to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).
