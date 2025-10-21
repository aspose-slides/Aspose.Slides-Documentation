---
title: Manage Rows and Columns in PowerPoint Tables Using Python
linktitle: Rows and Columns
type: docs
weight: 20
url: /python-net/manage-rows-and-columns/
keywords:
- table row
- table column
- first row
- table header
- clone row
- clone column
- copy row
- copy column
- remove row
- remove column
- row text formatting
- column text formatting
- table style
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Manage table rows and columns in PowerPoint and OpenDocument with Aspose.Slides for Python via .NET and speed up presentation editing and data updates."
---

## **Overview**

This article shows how to manage table rows and columns in PowerPoint and OpenDocument presentations using Aspose.Slides for Python. You’ll learn how to add, insert, clone, and delete rows or columns, mark the first row as a header, adjust sizing and layout, and apply text and style formatting at the row or column level. Each task is demonstrated with compact, self-contained code snippets based on the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) API, so you can quickly find a table on a slide and reshape its structure to match your design.

## **Set the First Row as a Header**

Mark the table’s first row as a header to clearly distinguish column titles from data. In Aspose.Slides for Python, simply enable the table’s *First Row* option to apply the header formatting defined by the selected table style.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation.
1. Access the slide by its index.
1. Iterate through all [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) objects to find the relevant table.
1. Set the table’s first row as the header.

This Python code shows how to set a table’s first row as its header:

```python
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation("table.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Iterate through the shapes and get a reference to the table.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Set the first row of the table as its header.
    table.first_row = True
    
    # Save the presentation to disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone a Table Row or Column**

Clone any table row or column and insert the copy at the desired position in the table. The duplicate preserves cell content, formatting, and sizes, so you can extend layouts quickly and consistently.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation.
1. Access the slide by its index.
1. Define an array of column widths.
1. Define an array of row heights.
1. Add a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) to the slide using `add_table(x, y, column_widths, row_heights)`.
1. Clone a table row.
1. Clone a table column.
1. Save the modified presentation.

This Python code shows how to clone a row and column of a PowerPoint table:

```python
 import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Add text to row 1, column 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Add text to row 2, column 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Clone row 1 at the end of the table.
    table.rows.add_clone(table.rows[0], False)

    # Add text to row 1, column 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Add text to row 2, column 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Clone row 2 as the 4th row of the table.
    table.rows.insert_clone(3,table.rows[1], False)

    # Clone the first column at the end.
    table.columns.add_clone(table.columns[0], False)

    # Clone the second column at index 3 (the 4th position).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Save the presentation to disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Row or Column from a Table**

Streamline a table by removing any row or column by index using Aspose.Slides for Python—the layout readjusts automatically while preserving the formatting of remaining cells. This is handy for simplifying data grids or deleting placeholders without rebuilding the table.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation.
1. Access the slide by its index.
1. Define an array of column widths.
1. Define an array of row heights.
1. Add an ITable to the slide using `add_table(x, y, column_widths, row_heights)`.
1. Remove the table row.
1. Remove the table column.
1. Save the modified presentation.

The following Python code shows how to remove a row and column from a table:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Row Level**

Apply consistent text styling to an entire table row in one step. With Aspose.Slides for Python, you can set font family, size, weight, color, and alignment for all cells in the row at once to keep headings or data bands uniform.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation.
1. Access the slide by its index.
1. Access the relevant [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object on the slide.
1. Set the font height for the first-row cells.
1. Set the alignment and right margin for the first-row cells.
1. Set the text vertical type for the second-row cells.
1. Save the modified presentation.

This Python code demonstrates the operation.

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Set the font height for the first-row cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Set the first-row cells' text alignment and right margin.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Set the second-row cells' text vertical type.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Save the presentation to disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Column Level**

Apply consistent text styling to an entire table column at once. With Aspose.Slides for Python, you can set font family, size, weight, color, and alignment for all cells in a column to create uniform vertical bands for headings or data.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation.
1. Access the slide by its index.
1. Access the relevant [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object on the slide.
1. Set the font height for the first-column cells.
1. Set the alignment and right margin for the first-column cells.
1. Set the text vertical type for the second-column cells.
1. Save the modified presentation.

The following Python code demonstrates the operation:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Set the first-column cells' font height.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Set the first-column cells' text alignment and right margin.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Set the second-column cells' text vertical type.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Save the presentation to disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Table Style Properties**

Aspose.Slides lets you retrieve a table’s style properties so you can reuse them for another table or elsewhere. The following Python code shows how to get the style properties from a preset table style:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.

**Can I sort table rows like in Excel?**

No, Aspose.Slides tables don’t have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.
