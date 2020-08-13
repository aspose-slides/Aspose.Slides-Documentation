---
title: Managing Shape Properties in Ruby
type: docs
weight: 160
url: /java/managing-shape-properties-in-ruby/
---

## **Aspose.Slides - Changing Order of Shapes**
To Change order of Shapes using **Aspose.Slides Java for Ruby**, simply invoke **ShapeProperties** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new

slide = pres.getSlides().get_Item(0)

shp3 = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 200, 365, 400, 150)

shp3.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').NoFill)

shp3.addTextFrame(" ")

txt_frame = shp3.getTextFrame()

para = txt_frame.getParagraphs().get_Item(0)

portion = para.getPortions().get_Item(0)

portion.setText("Watermark Text Watermark Text Watermark Text")

shp3 = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Triangle, 200, 365, 400, 150)

slide.getShapes().reorder(1, shp3)

\# Write the presentation as a PPTX file

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "ChangeShapesOrder.pptx", save_format.Pptx)

puts "Changed shapes order, please check the output file."

```
## **Download Running Code**
Download **Managing Shape Properties (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/shapeproperties.rb)
