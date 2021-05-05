---
title: Manage Rows and Columns
type: docs
weight: 20
url: /java/manage-rows-and-columns/
---

## **Set First Row as Header**
Aspose.Slides for Java provides the feature to set the first row as header using the following methods of [ITable](https://apireference.aspose.com/slides/java/com.aspose.slides/ITable) interface. Below code example shows how to set the first row as a header.

```java
// Instantiate Presentation class that represents PPTX
Presentation pres = new Presentation("table.pptx");
try {
    // Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialize null TableEx
    ITable tbl = null;

    // Iterate through the shapes and set a reference to the table found
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Set the first row of a table as header with a special formatting.
            tbl.setFirstRow(true);
        }
    }
    
    // Save PPTX to Disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clone Row or Column of Table**
Aspose.Slides for Java has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

```java
// Instantiate presentation class
Presentation pres = new Presentation("Test.pptx");
try {
    // Access first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columns with widths and rows with heights
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Add table shape to slide
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Add text to the row 1 cell 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Add text to the row 1 cell 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Clone Row 1 at end of table
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Add text to the row 2 cell 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Add text to the row 2 cell 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Clone Row 2 as 4th row of table
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    //Cloning first column at end
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    //Cloning 2nd column at 4th column index
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Write PPTX to Disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Row or Column from Table**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Text Formatting on Table Row Level**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // the first shape on the first slide is a table
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // setting first row cells' font height
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // setting first row cells' text alignment and right margin in one call
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // setting second row cells' text vertical type
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Text Formatting on Table Column Level**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // the first shape on the first slide is a table
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // setting first column cells' font height
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // setting first column cells' text alignment and right margin in one call
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // setting second column cells' text vertical type
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```