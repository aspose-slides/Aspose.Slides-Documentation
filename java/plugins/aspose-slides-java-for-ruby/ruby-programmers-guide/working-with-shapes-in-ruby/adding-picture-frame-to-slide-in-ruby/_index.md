---
title: Adding Picture Frame to Slide in Ruby
type: docs
weight: 50
url: /java/adding-picture-frame-to-slide-in-ruby/
---

## **Aspose.Slides - Adding Picture Frame to Slide**
To Add Picture Frame to Slide using **Aspose.Slides Java for Ruby**, call **add_picture_frame** method of **Frame** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def add_picture_frame()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Instantiate the Image class

    imgx = pres.getImages().addImage(Rjb::import('java.io.FileInputStream').new(Rjb::import('java.io.File').new(data_dir + "aspose-logo.jpg")))

    # Add Picture Frame with height and width equivalent of Picture

    sld.getShapes().addPictureFrame(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "RectPicFrame.pptx", save_format.Pptx)

    puts "Added picture frame to slide, please check the output file."

end   

```
## **Download Running Code**
Download **Adding Picture Frame to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/frame.rb)
