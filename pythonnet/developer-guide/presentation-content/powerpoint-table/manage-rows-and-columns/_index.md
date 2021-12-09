---
title: Manage Rows and Columns
type: docs
weight: 20
url: /pythonnet/manage-rows-and-columns/
keywords: "Table, table rows and columns, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Manage table rows and columns in PowerPoint presentations in Python"
---

## **Set First Row as Header**
Aspose.Slides for Python via .NET provides the feature to set the first row as header using the following methods of [ITable](https://apireference.aspose.com/slides/pythonnet/aspose.slides/itable) interface. Below code example shows how to set the first row as a header.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX
with slides.Presentation("table.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # Initialize null TableEx
    tbl = None

    # Iterate through the shapes and set a reference to the table found
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    #Set the first row of a table as header with a special formatting.
    tbl.first_row = True
```




## **Clone Row or Column of Table**
Aspose.Slides for Python via .NET has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using addTable method exposed by IShapes object.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

```py
import aspose.slides as slides

# Instantiate presentationentation class that representationents PPTX file
with slides.Presentation() as presentation:

    # Access first slide
    sld = presentation.slides[0]

    # Define columns with widths and rows with heights
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Add table shape to slide
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Add text to the row 1 cell 1
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Add text to the row 1 cell 2
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Clone Row 1 at end of table
    table.rows.add_clone(table.rows[0], False)

    # Add text to the row 2 cell 1
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Add text to the row 2 cell 2
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Clone Row 2 as 4th row of table
    table.rows.insert_clone(3,table.rows[1], False)

    #Cloning first column at end
    table.columns.add_clone(table.columns[0], False)

    #Cloning 2nd column at 4th column index
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Write PPTX to Disk
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Remove Row or Column from Table**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Text Formatting on Table Row Level**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # setting first row cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # setting first row cells' text alignment and right margin in one call
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # setting second row cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Text Formatting on Table Column Level**
Aspose.Slides for Python via .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # setting first column cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # setting first column cells' text alignment and right margin in one call
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # setting second column cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

