---
title: Cloning Shapes in Slides in Ruby
type: docs
weight: 80
url: /java/cloning-shapes-in-slides-in-ruby/
---

## **Aspose.Slides - Cloning Shapes in Slides**
To Clone Shapes in Slides using **Aspose.Slides Java for Ruby**, simply invoke **CloneShape** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



\# Create an instance of Presentation class

srcPres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'demo.pptx')

\# Accessing source slide shape collection

sourceShapes = srcPres.getSlides().get_Item(0).getShapes()

blankLayout = srcPres.getMasters().get_Item(0).getLayoutSlides().getByType(Rjb::import('com.aspose.slides.SlideLayoutType').Blank)

destSlide = srcPres.getSlides().addEmptySlide(blankLayout)

\# Accessing destination slide shape collection

destShapes = destSlide.getShapes()

\# Clone shapes by using different methods

destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight())

destShapes.addClone(sourceShapes.get_Item(2))

destShapes.addClone(sourceShapes.get_Item(3), 50, 200, 50, 50)

destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150)

\# Write the presentation as a PPTX file

save_format = Rjb::import('com.aspose.slides.SaveFormat')

srcPres.save(data_dir + "CloneShape.pptx", save_format.Pptx)

puts "Cloned shape, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Cloning Shapes in Slides (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/cloneshape.rb)
