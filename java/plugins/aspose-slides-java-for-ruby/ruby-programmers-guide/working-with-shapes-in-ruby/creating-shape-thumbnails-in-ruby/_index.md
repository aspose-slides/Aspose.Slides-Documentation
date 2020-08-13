---
title: Creating Shape Thumbnails in Ruby
type: docs
weight: 100
url: /java/creating-shape-thumbnails-in-ruby/
---

## **Aspose.Slides - Creating Shape Thumbnails**
To Create Shape Thumbnails using **Aspose.Slides Java for Ruby**, simply invoke **ShapeThumbnail** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'demo.pptx')

\# Create a full scale image

image = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail()

\# Save the image to disk in PNG format

Rjb::import('javax.imageio.ImageIO').write(image,"jpeg",Rjb::import('java.io.File').new(data_dir + "ShapeThumbnail.jpg"))

puts "Generated shape Thumbnail from a slide, please check the output file."

```
## **Download Running Code**
Download **Creating Shape Thumbnails (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/shapethumbnail.rb)
