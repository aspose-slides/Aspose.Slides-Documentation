---
title: Create Table using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/slides-poi/create-table/
---

## **Aspose.Slides - Create Table**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class
- Obtain the reference of a slide by using its Index
- Define Array of Columns with Width
- Define Array of Rows with Height
- Add a Table to the slide using [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders
- Merge first two cells of the first row of the table
- Access the Text Frame of a Cell
- Add some text to the Text Frame

```java
//Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.getSlides().get_Item(0);

//Define columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add table shape to slide
ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

//Set border format for each cell
for(int row = 0; row < tbl.getRows().size(); row++)
{
    for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
    {
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderTop().setWidth(5);

        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderBottom().setWidth(5);

        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderLeft().setWidth(5);

        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
        tbl.getRows().get_Item(row).get_Item(cell).getCellFormat().getBorderRight().setWidth(5);
    }
}

//Merge cells 1 & 2 of row 1
tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(0), false);

//Add text to the merged cell
tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
```

## **Apache POI SL - HSLF XSLF - Create Table**
Apache POI provides Table class for created tables. Sample for creating table is shown below:

```java
//table data
String[][] data = { { "INPUT FILE", "NUMBER OF RECORDS" },
		{ "Item File", "11,559" }, { "Vendor File", "300" },
		{ "Purchase History File", "10,000" },
		{ "Total # of requisitions", "10,200,038" } };

SlideShow ppt = new SlideShow();

Slide slide = ppt.createSlide();

// create a table of 5 rows and 2 columns
Table table = new Table(5, 2);

for (int i = 0; i < data.length; i++)
{
	for (int j = 0; j < data[i].length; j++)
	{
		TableCell cell = table.getCell(i, j);
		cell.setText(data[i][j]);

		RichTextRun rt = cell.getTextRun().getRichTextRuns()[0];
		rt.setFontName("Arial");
		rt.setFontSize(10);

		cell.setVerticalAlignment(TextBox.AnchorMiddle);
		cell.setHorizontalAlignment(TextBox.AlignCenter);
	}
}

// set table borders
Line border = table.createBorder();
border.setLineColor(Color.black);
border.setLineWidth(1.0);

table.setAllBorders(border);

// set width of the 1st column
table.setColumnWidth(0, 300);

// set width of the 2nd column
table.setColumnWidth(1, 150);

slide.addShape(table);

table.moveTo(100, 100);
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/tables/createtable)

{{% alert color="primary" %}} 

For more details, visit [Creating a Table from Scratch in Slide](https://docs.aspose.com/slides/java/manage-table/#create-table-from-scratch).

{{% /alert %}}
