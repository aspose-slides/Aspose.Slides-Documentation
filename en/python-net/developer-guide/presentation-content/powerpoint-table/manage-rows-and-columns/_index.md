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
description: "Manage table rows and columns in PowerPoint with Aspose.Slides for Python via .NET and speed up presentation editing and data updates."
---

## **Introduction**

Aspose.Slides for Python via .NET lets you manage table structure and formatting in PowerPoint presentations through the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) class. You can designate a header row, clone or remove rows and columns, and apply text formatting to an entire row or column.

This article explains these operations with Python examples. It also shows how to retrieve a table's style preset so you can reuse it. Table row and column indices are zero-based.

## **Control Row Height**

Use [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) to set a row's minimum height in points. It is a lower bound, not a fixed height. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) returns the actual height and is read-only. Access the row through [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

The example loads [row-height-input.pptx](row-height-input.pptx), which has a table as the first shape on the first slide. Its first row starts at 70 points. The cells use 18-point Arial text, wrapping, and 6-point top and bottom margins; the longer text in the second column wraps onto multiple lines. The example increases the minimum to 100 points, then decreases it to 20 points, prints the actual height after each change, and saves both results.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

With the supplied presentation, increasing the minimum adds space to the row. Decreasing it removes that extra space, but the actual height remains greater than 20 points because the text and cell margins need more room. Reducing the minimum alone cannot force the row below the space required by its content.

Several factors affect the actual height:

- **Text and font size:** longer text, explicit line breaks, or a larger font can require more vertical space.
- **Wrapping and column width:** with wrapping enabled, a narrower [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) can produce more lines. A wider column can reduce the space required vertically.
- **Cell margins:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) and [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) add vertical space. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) and [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) reduce the width available for text and can cause additional wrapping.

For this table without merged cells, the cell that needs the most vertical space determines the content-driven lower limit for the entire row. To make the row shorter, you may also need to shorten the text, reduce the font size or margins, or widen a column.

The images below show the same table at the same scale. In this run, the actual heights were 70, 100, and 55.2 points: the final row remained taller than its 20-point minimum. Exact text measurements can vary with the fonts available in your environment. Download the saved results: [increased minimum](row-height-increased.pptx) and [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Use the [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) property to mark the first row for header formatting. Its appearance depends on the table style applied to the table.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Access the table stored as the first shape on the slide.
4. Enable header formatting for its first row.
5. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide. It enables header formatting for the first row and saves `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone a Table Row or Column**

Clone rows or columns to reuse their content and formatting. You can append a copy to the end of the table or insert it at a specific position.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.
5. Clone the required rows.
6. Clone the required columns.
7. Save the modified presentation.

The example requires `Test.pptx` with at least one slide. It creates a table with three columns and five rows, with dimensions specified in points. It appends copies of the first row and column, then inserts copies of the second row and column at index 3 (the fourth position). The resulting table has seven rows and five columns. The `False` argument disables cloning into adjacent merged rows or columns; this table has no merged cells.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Row or Column from a Table**

Remove rows or columns that are no longer needed in a table. Removing an item shifts the indices of the rows or columns that follow it.

1. Create a presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.
5. Remove the second row and second column.
6. Save the modified presentation.

This example creates a three-by-three table and removes the row and column at index 1, leaving a two-by-two table in `TestTable_out.pptx`. The dimensions are in points. The `False` argument disables removal of adjacent merged rows or columns; this table has no merged cells.

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

Apply text formatting to an entire row to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Set [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) for the first row.
4. Set [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) and [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) for the first row.
5. Set [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) for the second row.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two rows. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first row, then sets vertical text in the second row.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Column Level**

Apply text formatting to an entire column to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Set [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) for the first column.
4. Set [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) and [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) for the first column.
5. Set [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) for the second column.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two columns. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first column, then sets vertical text in the second column.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Table Style Properties**

Use the [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) property to retrieve the preset applied to a table and reuse it on another table. This identifies the preset rather than individual cell formatting overrides.

The example creates a table, applies [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), and reads the preset back. It prints `True` when the retrieved preset matches the applied preset and saves the table in `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that's already created?**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.

**Can I sort table rows like in Excel?**

No, Aspose.Slides tables don't have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.
