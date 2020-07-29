---
title: Adding, Updating and Manipulating Tables
type: docs
weight: 50
url: /cpp/adding-updating-and-manipulating-tables/
---

## **Adding and Updating Tables**
### **Creating Table from Scratch**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders.
- Merge first two cells of the first row of the table.
- Access the Text Frame of a Cell.
- Add some text to the Text Frame.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-TableFromScratch-TableFromScratch.cpp" >}}
### **Removing Table Cells Border**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove the borders from table cells, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to clear the Top, Bottom, Right, Left Borders.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-TableWithCellBorders-TableWithCellBorders.cs" >}}
### **Accessing an Existing Table**
To access a table that already exists in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide (that contains the table) by using its Position.
- Create an ITable object and set it to null.
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a Table object. But, if the slide contains more than one tables then it's better to find your desired table using its Alternative Text.
- After the Table is found, you can use ITable object to control the table. For example, in our case, we have added a new row in the desired table.
- Save the modified presentation as a PPT file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdateExistingTable-UpdateExistingTable.cpp" >}}
### **Removing Row or Column inside Table**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemovingRowColumn-RemovingRowColumn.cpp" >}}
## **Manipulating Tables**
### **Numbering in Standard tables**
In a standard table numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). For example, the cells in a table with 4 columns and 4 rows will be numbered accordingly:

|**(0, 0)**|**(1, 0)**|**(2, 0)**|**(3, 0)**|
| :- | :- | :- | :- |
|(0, 1)|(1, 1)|(2, 1)|(3, 1)|
|(0, 2)|(1, 2)|(2, 2)|(3, 2)|
|(0, 3)|(1, 3)|(2, 3)|(3, 3)|
{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-StandardTables-StandardTables.cpp" >}}
### **Numbering in Merged cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2) then table will be numbered and look like this:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-MergeCells-MergeCells.cpp" >}}



Let's continue merging cells. Now we merge (1, 1) and (1, 2). As a result we have table with large merged cell in the middle:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-MergeCells-MergeCells.cpp" >}}
### **Numbering in Splitting Cell**
We could see in previous example when table cells are merged then numeration of other cells is not changed.Now let's return to our normal table (without merged cells) and try to split cell (1, 1). The result is strange enough but that is the way MS PowerPoint and Aspose.Slides for C++ numerate table cells.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CellSplit-CellSplit.cpp" >}}
### **Adding Image inside a Table Cell**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Create a Bitmap object to hold the image file.
- Add the Bitmap image to IPPImage Object.
- Set Fill Format of the Table Cell as Picture.
- Add the image to the first cell of the table.
- Save the modified presentation as a PPTX file

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddImageinsideTableCell-AddImageinsideTableCell.cpp" >}}
### **Identify merge Table Cell**
Aspose.Slides for C++ has provided the simplest API to identify merge table cells in an easiest way. To identify merge cells in table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the the table from first slide.
- Iterate through row and columns of table to find out merge cells.
- Print Message if cells are merged.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-IdentifyingTheMergedCellsinTable-IdentifyingTheMergedCellsinTable.cs" >}}
### **Cloning Row or Column of Table**
Aspose.Slides for C++ has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using addTable method exposed by IShapes object.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloningInTable-CloningInTable.cpp" >}}
### **Vertically align the text in table**
Aspose.Slides for C++ has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Insert table in the slide.
- Access text frame.
- Access paragraph.
- Align text vertically.
- Save the presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerticallyAlignText-VerticallyAlignText.cpp" >}}
### **Setting Text Formatting on Table Level**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set Table Cells Font Height.
- Set Table Cells Text Alignment and right Margin in one Call.
- Set Table Cells Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-SetTextFormattingInsideTable-SetTextFormattingInsideTable.cs" >}}
### **Setting Text Formatting on Table Row Level**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-TextFormattingInsideTableRow-TextFormattingInsideTableRow.cs" >}}
### **Setting Text Formatting on Table Column Level**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-TextFormattingInsideTableColumn-TextFormattingInsideTableColumn.cs" >}}
### **Lock Aspect Ratio of Table**
The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. You can lock aspect ratio of table using **set_AspectRatioLocked** property. Below code example shows how to use this property.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-LockAspectRatio-LockAspectRatio.cpp" >}}
