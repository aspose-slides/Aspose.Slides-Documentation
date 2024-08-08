---
title: Manage Table
type: docs
weight: 10
url: /androidjava/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, Java, Aspose.Slides for Android via Java"
description: "Create and manage table in PowerPoint presentations in Java"
---

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table) class, [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) interface, [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) interface, and other types to allow you to create, update, and manage tables in all kinds of presentations.

## **Create Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Iterate through each [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row. 
8. Access an [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
10. Save the modified presentation.

This Java code shows you how to create a table in a presentation:

```java
// Instantiates a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Defines columns with widths and rows with heights
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Adds a table shape to slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Merges cells 1 & 2 of row 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Adds some text to the merged cell
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Saves the presentation to Disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
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

```java
// Instantiates a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Defines columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adds a table shape to slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Saves presentation to disk
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.

2. Get a reference to the slide containing the table through its index. 

3. Create an [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) object and set it to null.

4. Iterate through all [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Use the [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) object to work with the table. In the example below, we added a new row to the table.

6. Save the modified presentation.

This Java code shows you how to access and work with an existing table:

```java
// Instantiates the Presentation class that represents a PPTX file
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accesses the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Initializes null TableEx
    ITable tbl = null;

    // Iterates through the shapes and sets a reference to the table found
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Sets the text for the first column of the second row
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Saves the modified presentation to disk
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Align Text in Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) object to the slide.
4. Access an [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) object from the table.
5. Access the [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/).
6. Align the text vertically.
7. Save the modified presentation.

This Java code shows you how to align the text in a table:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    // Gets the first slide 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Defines columns with widths and rows with heights
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Adds the table shape to the slide
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Accesses the text frame
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Creates the Paragraph object for the text frame
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Creates the Portion object for paragraph
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Aligns the text vertically
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Saves the presentation to disk
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Text Formatting on Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Access an [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) object from the Slide.
4. Set the [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) for the text.
5. Set the [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Set the [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation. 

This Java code shows you how to apply your preferred formatting options to the text in a table:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Let's assume that the first shape on the first slide is a table
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Sets the table cells' font height
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Sets the table cells' text alignment and right margin in one call
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Sets the table cells' text vertical type
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This Java code shows you how to get the style properties from a table preset style:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // change the default style preset theme 
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lock Aspect Ratio of Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provided the [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)  property to allow you to lock the aspect ratio setting for tables and other shapes.

This Java code shows you how to lock the aspect ratio for a table:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invert

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
