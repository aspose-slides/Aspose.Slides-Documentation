---
title: Removing Row Or Column in Table in Ruby
type: docs
weight: 40
url: /java/removing-row-or-column-in-table-in-ruby/
---

## **Aspose.Slides - Removing Row Or Column in Table**
To Remove Row Or Column in Table using **Aspose.Slides Java for Ruby**, simply invoke **RemoveRowColumn** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Tables/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Get the first slide

slide = pres.getSlides().get_Item(0)

col_width = [100, 50, 30]

row_height = [30, 50, 30]                                           



table = slide.getShapes().addTable(100, 100, col_width, row_height)



table.getRows().removeAt(1, false)                                           

table.getColumns().removeAt(1, false)

\# Write the presentation as a PPTX file

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "RemoveRowColumn.pptx", save_format.Pptx)

puts "Removed Row & Column from table, please check the output file."

```
## **Download Running Code**
Download **Removing Row Or Column in Table (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Tables/removerowcolumn.rb)
