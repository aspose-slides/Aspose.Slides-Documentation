---
title: Removing Row Or Column in Table in Python
type: docs
weight: 40
url: /java/removing-row-or-column-in-table-in-python/
---

## **Aspose.Slides - Removing Row Or Column in Table**
To Remove Row Or Column in Table using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 pres = self.Presentation()

\# Get the first slide

slide = pres.getSlides().get_Item(0)

col_width = [100, 50, 30]

row_height = [30, 50, 30]

table = slide.getShapes().addTable(100, 100, col_width, row_height)

table.getRows().removeAt(1, False)

table.getColumns().removeAt(1, False)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "RemoveRowColumn.pptx", save_format.Pptx)

print "Removed Row & Column from table, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
