---
title: Manage Table
type: docs
weight: 10
url: /python-net/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Create and manage table in PowerPoint presentations in Python"
---

## **Create Table from Scratch**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders.
- Merge first two cells of the first row of the table.
- Access the Text Frame of a Cell.
- Add some text to the Text Frame.
- Save the modified presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as pres:
    # Access first slide
    sld = pres.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Add table shape to slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Set border format for each cell
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # Merge cells 1 & 2 of row 1
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # Add text to the merged cell
    tbl.rows[0][0].text_frame.text = "Merged Cells"

    # save PPTX to Disk
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```



## **Access Existing Table**
To access a table that already exists in a slide, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide (that contains the table) by using its Position.
- Create an ITable object and set it to null.
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a Table object. But, if the slide contains more than one tables then it's better to find your desired table using its Alternative Text.
- After the Table is found, you can use ITable object to control the table. For example, in our case, we have added a new row in the desired table.
- Save the modified presentation as a PPT file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # Initialize null TableEx
    tbl = None

    # Iterate through the shapes and set a reference to the table found
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Set the text of the first column of second row
    tbl.rows[0][1].text_frame.text = "New"

    #Write the PPTX to Disk
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Align Text in Table**
Aspose.Slides for Python via .NET has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Insert table in the slide.
- Access text frame.
- Access paragraph.
- Align text vertically.
- Save the presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Get the first slide 
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # Add table shape to slide
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # Accessing the text frame
    txtFrame = tbl.rows[0][0].text_frame

    # Create the Paragraph object for text frame
    paragraph = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = paragraph.portions[0]
    portion.text = "text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Aligning the text vertically
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # save Presentation
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Text Formatting on Table Level**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set Table Cells Font Height.
- Set Table Cells Text Alignment and right Margin in one Call.
- Set Table Cells Vertical Type.
- Save the modified presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # setting table cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # setting table cells' text alignment and right margin in one call
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # setting table cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```




## **Numbering in Standard Table**
In a standard table numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). For example, the cells in a table with 4 columns and 4 rows will be numbered accordingly:

|(0, 0)|(1, 0)|(2, 0)|(3, 0)|
| :- | :- | :- | :- |
|(0, 1)|(1, 1)|(2, 1)|(3, 1)|
|(0, 2)|(1, 2)|(2, 2)|(3, 2)|
|(0, 3)|(1, 3)|(2, 3)|(3, 3)|

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as pres:
    # Access first slide
    sld = pres.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Add table shape to slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Set border format for each cell
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    #Write PPTX to Disk
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Lock Aspect Ratio of Table**
The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. You can lock aspect ratio of table using **ShapeLock.AspectRatioLocked** property. Below code example shows how to use this property.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("Lock aspect ratio set: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("Lock aspect ratio set: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

