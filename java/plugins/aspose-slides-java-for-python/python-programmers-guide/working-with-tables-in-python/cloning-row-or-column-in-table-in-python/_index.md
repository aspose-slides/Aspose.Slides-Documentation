---
title: Cloning Row or Column in table in Python
type: docs
weight: 20
url: /java/cloning-row-or-column-in-table-in-python/
keywords: Clone Row in Slide Table using Python, Clone Column in PowerPoint Table using Python
description: Learn how to clone row or column a Table inside a PowerPoint Slide using Python.
---

## **Aspose.Slides - Cloning Row or Column in table**
To Clone Row or Column in table using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Define columns with widths and rows with heights

dbl_cols = [50, 50, 50]

dbl_rows = [50, 30, 30, 30]

\# Add table shape to slide

tbl = sld.getShapes().addTable(100, 50, dbl_cols, dbl_rows)

fill_type = self.FillType

color = self.Color

\# Set border format for each cell

row = 0

while (row < tbl.getRows().size()): 

    cell = 0

    while (cell < tbl.getRows().get_Item(row).size()): 

        tbl.getRows().get_Item(row).get_Item(cell).getBorderTop().getFillFormat().setFillType(fill_type.Solid)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderTop().getFillFormat().getSolidFillColor().setColor(color.RED)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderTop().setWidth(5)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderBottom().getFillFormat().setFillType(fill_type.Solid)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderBottom().getFillFormat().getSolidFillColor().setColor(color.RED)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderBottom().setWidth(5)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderLeft().getFillFormat().setFillType(fill_type.Solid)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderLeft().getFillFormat().getSolidFillColor().setColor(color.RED)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderLeft().setWidth(5)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderRight().getFillFormat().setFillType(fill_type.Solid)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderRight().getFillFormat().getSolidFillColor().setColor(color.RED)

        tbl.getRows().get_Item(row).get_Item(cell).getBorderRight().setWidth(5)

        cell += 1

    row += 1


tbl.getColumns().get_Item(0).get_Item(0).getTextFrame().setText("00")

tbl.getColumns().get_Item(0).get_Item(1).getTextFrame().setText("01")

tbl.getColumns().get_Item(0).get_Item(2).getTextFrame().setText("02")

tbl.getColumns().get_Item(0).get_Item(3).getTextFrame().setText("03")

tbl.getColumns().get_Item(1).get_Item(0).getTextFrame().setText("10")

tbl.getColumns().get_Item(2).get_Item(0).getTextFrame().setText("20")

tbl.getColumns().get_Item(1).get_Item(1).getTextFrame().setText("11")

tbl.getColumns().get_Item(2).get_Item(1).getTextFrame().setText("21")

\# AddClone adds a row in the end of the table

tbl.getRows().addClone(tbl.getRows().get_Item(0) , False)

\# AddClone adds a column in the end of the table

tbl.getColumns().addClone(tbl.getColumns().get_Item(0), False)

\# InsertClone adds a row at specific position in a table

tbl.getRows().insertClone(2, tbl.getRows().get_Item(0), False)

\# InsertClone adds a row at specific position in a table

tbl.getColumns().insertClone(2, tbl.getColumns().get_Item(0), False)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "CloneRowColumn.pptx", save_format.Pptx)

print "Cloned Row & Column from table, please check the output file."

```
## **Download Running Code**
Download running code the following social coding site:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
