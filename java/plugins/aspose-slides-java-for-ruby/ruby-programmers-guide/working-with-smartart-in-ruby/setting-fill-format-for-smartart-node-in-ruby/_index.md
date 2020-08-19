---
title: Setting Fill Format for SmartArt Node in Ruby
type: docs
weight: 20
url: /java/setting-fill-format-for-smartart-node-in-ruby/
---

## **Aspose.Slides - Setting Fill Format for SmartArt Node**
To Set Fill Format for SmartArt Node using **Aspose.Slides Java for Ruby**, simply invoke **FillFormat** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Adding SmartArt shape and nodes

chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, Rjb::import('com.aspose.slides.SmartArtLayoutType').ClosedChevronProcess)

node = chevron.getAllNodes().addNode()

node.getTextFrame().setText("Some text")

\# Setting node fill color

item = node.getShapes().get_Item(0)

item.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

item.getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').RED)

\# Write the presentation as a PPTX file  

pres.save(data_dir + "FillFormat.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

puts "Set fill format for smartart node, please check the output file."

```
## **Download Running Code**
Download **Setting Fill Format for SmartArt Node (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/SmartArt/fillformat.rb)
