---
title: Rotating Shapes in Ruby
type: docs
weight: 170
url: /java/rotating-shapes-in-ruby/
---

## **Aspose.Slides - Rotating Shapes**
To Rotate Shapes using **Aspose.Slides Java for Ruby**, simply invoke **RotatingShapes** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, 75, 150)

\# Rotate the shape to 90 degree

shp.setRotation(90)

\# Write the presentation as a PPTX file

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "RectShpRot.pptx", save_format.Pptx)

puts "Rotated shape, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Rotating Shapes (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/rotatingshapes.rb)
