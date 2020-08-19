---
title: Adding SmartArt shape in Ruby
type: docs
weight: 10
url: /java/adding-smartart-shape-in-ruby/
---

## **Aspose.Slides - Adding SmartArt shape**
To Add SmartArt shape using **Aspose.Slides Java for Ruby**, call **create_smartart_shape** method of **AddSmartArt** module. Here you can see example code.

**Ruby Code**

```

 def create_smartart_shape()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'

    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Add Smart Art Shape

    smart = slide.getShapes().addSmartArt(0, 0, 400, 400, Rjb::import('com.aspose.slides.SmartArtLayoutType').BasicBlockList)

    # Write the presentation as a PPTX file

    pres.save(data_dir + "SimpleSmartArt.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

    puts "Created smartart shape, please check the output file."

end

```
## **Download Running Code**
Download **Adding SmartArt shape (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/SmartArt/addsmartart.rb)
