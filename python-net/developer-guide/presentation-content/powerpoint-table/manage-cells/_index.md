---
title: Manage Cells
type: docs
weight: 30
url: /python-net/manage-cells/
keywords: "Table, merged cells, split cells, image in table cell, Python, Aspose.Slides for Python via .NET"
description: "Table cells in PowerPoint presentations in Python"
---

## **Identify Merged Table Cell**
Aspose.Slides for Python via .NET has provided the simplest API to identify merge table cells in an easiest way. To identify merge cells in table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Obtain the the table from first slide.
- Iterate through row and columns of table to find out merge cells.
- Print Message if cells are merged.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # assuming that #0.Shape#0 is a table
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("Cell 01 is a part of merged cell with RowSpan=2 and ColSpan=3 starting from Cell 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```



## **Remove Table Cells Border**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. In order to remove the borders from table cells, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to clear the Top, Bottom, Right, Left Borders.
- Save the modified presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as pres:
   # Access first slide
    sld = pres.slides[0]

    # Define columns with widths and rows with heights
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # Add table shape to slide

    # Add table shape to slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Set border format for each cell
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    #Write PPTX to Disk
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2) then table will be numbered and look like this:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as presentation:
    # Access first slide
    sld = presentation.slides[0]

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

    # Merging cells (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # Merging cells (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```



Let's continue merging cells. Now we merge (1, 1) and (1, 2). As a result we have table with large merged cell in the middle:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as presentation:
    # Access first slide
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # Add table shape to slide
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Set border format for each cell
    for row in table.rows:
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

    # Merging cells (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merging cells (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Merging cells (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    #Write PPTX to Disk
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Numbering in Splitted Cell**
We could see in previous example when table cells are merged then numeration of other cells is not changed.Now let's return to our normal table (without merged cells) and try to split cell (1, 1). The result is strange enough but that is the way MS PowerPoint and Aspose.Slides for Python via .NET numerate table cells.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as presentation:
    # Access first slide
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Add table shape to slide
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Set border format for each cell
    for row in table.rows:
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

    # Merging cells (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merging cells (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # split cell (1, 1). 
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    #Write PPTX to Disk
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Add Image Inside Table Cell**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Create a Bitmap object to hold the image file.
- Add the Bitmap image to IPPImage Object.
- Set Fill Format of the Table Cell as Picture.
- Add the image to the first cell of the table.
- Save the modified presentation as a PPTX file

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class object
with slides.Presentation() as presentation:
    # Access first slide
    islide = presentation.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # Add table shape to slide
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # Creating a Bitmap Image object to hold the image file
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # Create an IPPImage object using the bitmap object
    imgx1 = presentation.images.add_image(image)

    # Add image to first table cell
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # save PPTX to Disk
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```

