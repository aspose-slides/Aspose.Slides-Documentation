---
title: Manage Cells
type: docs
weight: 30
url: /java/manage-cells/
keywords: "Table, merged cells, split cells, image in table cell, Java, Aspose.Slides for Java"
description: "Table cells in PowerPoint presentations in Java"
---


## **Identify Merged Table Cell**
1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get the table from the first slide. 
3. Iterate through the table's rows and columns to find merge cells.
4. Print message when merged cells are found.

This Java code shows you how to identify merged table cells in a presentation:

```javascript
    var pres = new  com.aspose.slides.Presentation("SomePresentationWithTable.pptx");
    try {
        var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// assuming that Slide#0.Shape#0 is a table
        for (var i = 0; i < table.getRows().size(); i++) {
            for (var j = 0; j < table.getColumns().size(); j++) {
                var currentCell = table.getRows().get_Item(i).get_Item(j);
                if (currentCell.isMergedCell()) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
                }
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Remove Table Cells Border**
1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Iterate through every cell to clear the top, bottom, right, and left borders.
7. Save the modified presentation as a PPTX file.

This Java code shows you how to remove the borders from table cells:

```javascript
    // Instantiates Presentation class that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 50, 50, 50, 50 };
        var dblRows = new double[]{ 50, 30, 30, 30, 30 };
        // Adds table shape to slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Sets the border format for each cell
        for (var row : tbl.getRows()) {
            for (var cell : row) {
                cell.getCellFormat().getBorderTop().getFillFormat().setFillType(com.aspose.slides.FillType.NoFill);
                cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(com.aspose.slides.FillType.NoFill);
                cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(com.aspose.slides.FillType.NoFill);
                cell.getCellFormat().getBorderRight().getFillFormat().setFillType(com.aspose.slides.FillType.NoFill);
            }
        }
        // Writes the PPTX to disk
        pres.save("table_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2), the resulting table will be numbered. This Java code demonstrates the process:

```javascript
    // Instantiates Presentation class that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Accesses first slide
        var sld = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 70, 70, 70, 70 };
        var dblRows = new double[]{ 70, 70, 70, 70 };
        // Adds a table shape to the slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Sets the border format for each cell
        for (var row : tbl.getRows()) {
            for (var cell : row) {
                cell.getCellFormat().getBorderTop().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderTop().setWidth(5);
                cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderBottom().setWidth(5);
                cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderLeft().setWidth(5);
                cell.getCellFormat().getBorderRight().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderRight().setWidth(5);
            }
        }
        // Merges cells (1, 1) x (2, 1)
        tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
        // Merges cells (1, 2) x (2, 2)
        tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
        pres.save("MergeCells_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

We then merge the cells further by merging (1, 1) and (1, 2). The result is a table containing a large merged cell in its center: 

```javascript
    // Instantiates Presentation class that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Accesses first slide
        var sld = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 70, 70, 70, 70 };
        var dblRows = new double[]{ 70, 70, 70, 70 };
        // Adds a table shape to the slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Sets the border format for each cell
        for (var row : tbl.getRows()) {
            for (var cell : row) {
                cell.getCellFormat().getBorderTop().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderTop().setWidth(5);
                cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderBottom().setWidth(5);
                cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderLeft().setWidth(5);
                cell.getCellFormat().getBorderRight().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderRight().setWidth(5);
            }
        }
        // Merges cells (1, 1) x (2, 1)
        tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
        // Merges cells (1, 2) x (2, 2)
        tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
        // Merges cells (1, 1) x (1, 2)
        tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
        // Writes the PPTX file to disk
        pres.save("MergeCells_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Numbering in Splitted Cell**
In previous examples, when table cells got merged, the numeration or number system in other cells did not change. 

This time, we take a regular table (a table without merged cells) and then try to split cell (1,1) to get a special table. You may want to pay attention to this table's numbering, which may be considered strange. However, that is the way Microsoft PowerPoint numerates table cells and Aspose.Slides does the same thing. 

This Java code demonstrates the process we described:

```javascript
    // Instantiates the Presentation class that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 70, 70, 70, 70 };
        var dblRows = new double[]{ 70, 70, 70, 70 };
        // Adds a table shape to the slide
        var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
        // Sets the border format for each cell
        for (var row : tbl.getRows()) {
            for (var cell : row) {
                cell.getCellFormat().getBorderTop().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderTop().setWidth(5);
                cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderBottom().setWidth(5);
                cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderLeft().setWidth(5);
                cell.getCellFormat().getBorderRight().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
                cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                cell.getCellFormat().getBorderRight().setWidth(5);
            }
        }
        // Merges cells (1, 1) x (2, 1)
        tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
        // Merges cells (1, 2) x (2, 2)
        tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
        // Splits cell (1, 1)
        tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
        // Writes the PPTX file to disk
        pres.save("SplitCells_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Change Table Cell Background Color**

This Java code shows you how to change a table cell's background color:

```javascript
    var presentation = new  com.aspose.slides.Presentation();
    try {
        var slide = presentation.getSlides().get_Item(0);
        var dblCols = new double[]{ 150, 150, 150, 150 };
        var dblRows = new double[]{ 50, 50, 50, 50, 50 };
        // create a new table
        var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
        // set the background color for a cell
        var cell = table.get_Item(2, 3);
        cell.getCellFormat().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
        cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
        presentation.save("cell_background_color.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

## **Add Image Inside Table Cell**

1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Create a `Images` object to hold the image file.
7. Add the `IImage` image to `IPPImage` Object.
8. Set the `FillFormat` for the Table Cell to `Picture`.
9. Add the image to the table's first cell.
10. Save the modified presentation as a PPTX file

This Java code shows you how to place an image inside a table cell when creating a table:

```javascript
    // Instantiates the Presentation class that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var islide = pres.getSlides().get_Item(0);
        // Defines columns with widths and rows with heights
        var dblCols = new double[]{ 150, 150, 150, 150 };
        var dblRows = new double[]{ 100, 100, 100, 100, 90 };
        // Adds a table shape to the slide
        var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
        // Create an IPPImage object using the image file
        var picture;
        var image = com.aspose.slides.Images.fromFile("image.jpg");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        // Adds the image to the first table cell
        var cellFormat = tbl.get_Item(0, 0).getCellFormat();
        cellFormat.getFillFormat().setFillType(com.aspose.slides.FillType.Picture);
        cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(com.aspose.slides.PictureFillMode.Stretch);
        cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
        // Saves the PPTX file to Disk
        pres.save("Image_In_TableCell_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
