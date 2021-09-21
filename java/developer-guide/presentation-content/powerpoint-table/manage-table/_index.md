---
title: Manage Table
type: docs
weight: 10
url: /java/manage-table/
---

## **Create Table from Scratch**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method exposed by [IShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders.
- Merge first two cells of the first row of the table.
- Access the Text Frame of a Cell.
- Add some text to the Text Frame.
- Save the modified presentation as a PPTX file.

```java
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();
try {
    // Access first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columns with widths and rows with heights
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Add table shape to slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Set border format for each cell
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
    // Merge cells 1 & 2 of row 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Add text to the merged cell
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Save PPTX to Disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access Existing Table**
To access a table that already exists in a slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide (that contains the table) by using its Position.
- Create an [ITable](https://apireference.aspose.com/slides/java/com.aspose.slides/ITable) object and set it to null.
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a [Table](https://apireference.aspose.com/slides/java/com.aspose.slides/Table) object. But, if the slide contains more than one tables then it's better to find your desired table using its Alternative Text.
- After the Table is found, you can use [ITable](https://apireference.aspose.com/slides/java/com.aspose.slides/ITable) object to control the table. For example, in our case, we have added a new row in the desired table.
- Save the modified presentation as a PPT file.

```java
// Instantiate Presentation class that represents PPTX// Instantiate Presentation class that represents PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
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
            tbl = (ITable) shp;
            // Set the text of the first column of second row
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    //Write the PPTX to Disk
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Align Text in Table**
Aspose.Slides for Java has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Insert table in the slide.
- Access text frame.
- Access paragraph.
- Align text vertically.
- Save the presentation as a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get the first slide 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Define columns with widths and rows with heights
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Add table shape to slide
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Accessing the text frame
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Create the Paragraph object for text frame
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Create Portion object for paragraph
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Aligning the text vertically
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Save Presentation
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Text Formatting on Table Level**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set Table Cells Font Height.
- Set Table Cells Text Alignment and right Margin in one Call.
- Set Table Cells Vertical Type.
- Save the modified presentation as a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation("simpletable.pptx");
try {
    // the first shape on the first slide is a table
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // setting table cells' font height
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // setting table cells' text alignment and right margin in one call
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // setting table cells' text vertical type
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numbering in Standard Table**
In a standard table numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). For example, the cells in a table with 4 columns and 4 rows will be numbered accordingly:

|(0, 0)|(1, 0)|(2, 0)|(3, 0)|
| :- | :- | :- | :- |
|(0, 1)|(1, 1)|(2, 1)|(3, 1)|
|(0, 2)|(1, 2)|(2, 2)|(3, 2)|
|(0, 3)|(1, 3)|(2, 3)|(3, 3)|

```java
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();
try {
    // Access first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Add table shape to slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Set border format for each cell
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

    //Write PPTX to Disk
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lock Aspect Ratio of Table**
The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. You can lock aspect ratio of table using [**setAspectRatioLocked**](https://apireference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) method. Below code example shows how to use this method.

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
