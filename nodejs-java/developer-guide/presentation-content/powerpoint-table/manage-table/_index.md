---
title: Manage Table
type: docs
weight: 10
url: /nodejs-java/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Create and manage table in PowerPoint presentations in Javascript"
---

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) class, [ITable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITable) interface, [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/icell/) interface, and other types to allow you to create, update, and manage tables in all kinds of presentations.

## **Create Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Iterate through each [ICell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/icell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row. 
8. Access an [ICell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
10. Save the modified presentation.

This Java code shows you how to create a table in a presentation:

```javascript
    // Instantiates a Presentation class that represents a PPTX file
    var pres = new  aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 50, 50, 50 };
        var dblRows = new double[]{ 50, 30, 30, 30, 30 };
        // Adds a table shape to slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Sets the border format for each cell
        for (var row = 0; row < tbl.getRows().size(); row++) {
            for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
                var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
                cellFormat.getBorderTop().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cellFormat.getBorderTop().setWidth(5);
                cellFormat.getBorderBottom().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cellFormat.getBorderBottom().setWidth(5);
                cellFormat.getBorderLeft().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cellFormat.getBorderLeft().setWidth(5);
                cellFormat.getBorderRight().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cellFormat.getBorderRight().setWidth(5);
            }
        }
        // Merges cells 1 & 2 of row 1
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

This Java code shows you how to specify the numbering for cells in a table:

```javascript
    // Instantiates a Presentation class that represents a PPTX file
    var pres = new  aspose.slides.Presentation();
    try {
        // Accesses first slide
        var sld = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 70, 70, 70, 70 };
        var dblRows = new double[]{ 70, 70, 70, 70 };
        // Adds a table shape to slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Sets the border format for each cell
        tbl.getRows().forEach(function(row) {
            row.forEach(function(cell) {
                cell.getCellFormat().getBorderTop().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderTop().setWidth(5);
                cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderBottom().setWidth(5);
                cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderLeft().setWidth(5);
                cell.getCellFormat().getBorderRight().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderRight().setWidth(5);
            });
        });
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

3. Create an [ITable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITable) object and set it to null.

4. Iterate through all [IShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ishape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Use the [ITable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITable) object to work with the table. In the example below, we added a new row to the table.

6. Save the modified presentation.

This Java code shows you how to access and work with an existing table:

```javascript
    // Instantiates the Presentation class that represents a PPTX file
    var pres = new  aspose.slides.Presentation("UpdateExistingTable.pptx");
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Initializes null TableEx
        var tbl = null;
        // Iterates through the shapes and sets a reference to the table found
        sld.getShapes().forEach(function(shp) {
            if (shp instanceof aspose.slides.ITable) {
                tbl = shp;
                // Sets the text for the first column of the second row
                tbl.get_Item(0, 1).getTextFrame().setText("New");
            }
        });
        // Saves the modified presentation to disk
        pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Align Text in Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [ITable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITable) object to the slide.
4. Access an [ITextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/itextframe/) object from the table.
5. Access the [ITextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iparagraph/).
6. Align the text vertically.
7. Save the modified presentation.

This Java code shows you how to align the text in a table:

```javascript
    // Creates an instance of the Presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var slide = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 120, 120, 120, 120 };
        var dblRows = new double[]{ 100, 100, 100, 100 };
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
        portion.getPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Aligns the text vertically
        var cell = tbl.get_Item(0, 0);
        cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
        cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
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
3. Access an [ITable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITable) object from the Slide.
4. Set the [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) for the text.
5. Set the [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iparagraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Set the [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation. 

This Java code shows you how to apply your preferred formatting options to the text in a table:

```javascript
    // Creates an instance of the Presentation class
    var pres = new  aspose.slides.Presentation("simpletable.pptx");
    try {
        // Let's assume that the first shape on the first slide is a table
        var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        // Sets the table cells' font height
        var portionFormat = new  aspose.slides.PortionFormat();
        portionFormat.setFontHeight(25);
        someTable.setTextFormat(portionFormat);
        // Sets the table cells' text alignment and right margin in one call
        var paragraphFormat = new  aspose.slides.ParagraphFormat();
        paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
        paragraphFormat.setMarginRight(20);
        someTable.setTextFormat(paragraphFormat);
        // Sets the table cells' text vertical type
        var textFrameFormat = new  aspose.slides.TextFrameFormat();
        textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
        someTable.setTextFormat(textFrameFormat);
        pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This Java code shows you how to get the style properties from a table preset style:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[]{ 100, 150 }, new double[]{ 5, 5, 5 });
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

This Java code shows you how to lock the aspect ratio for a table:

```javascript
    var pres = new  aspose.slides.Presentation("pres.pptx");
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
