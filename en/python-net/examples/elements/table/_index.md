---
title: Table
type: docs
weight: 120
url: /python-net/examples/elements/table/
keywords:
- table
- add table
- access table
- remove table
- merge cells
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create and format tables in Python with Aspose.Slides: insert data, merge cells, style borders, align content, and import/export for PPT, PPTX and ODP."
---

Examples for adding tables, accessing them, removing them, and merging cells using **Aspose.Slides for Python via .NET**.

## **Add a Table**

Create a simple table with two rows and two columns.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Define column widths and row heights.
        widths = [80, 80]
        heights = [30, 30]

        # Add a table shape to the slide.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Table**

Retrieve the first table shape on the slide.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first table on the slide.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Remove a Table**

Delete a table from a slide.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a table.
        table = slide.shapes[0]

        # Remove the table from the slide.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Table Cells**

Merge adjacent cells of a table into a single cell.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a table.
        table = slide.shapes[0]

        # Merge cells.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```
