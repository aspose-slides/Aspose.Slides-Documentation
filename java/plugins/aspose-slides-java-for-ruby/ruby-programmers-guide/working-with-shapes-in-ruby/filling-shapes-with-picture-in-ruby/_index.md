---
title: Filling Shapes with Picture in Ruby
type: docs
weight: 120
url: /java/filling-shapes-with-picture-in-ruby/
---

## **Aspose.Slides - Filling Shapes with Picture**
To Fill Shapes with Picture using **Aspose.Slides Java for Ruby**, call **fill_shapes_with_picture** method of **FillingShapes** module. Here you can see example code.

**Ruby Code**

```

 def fill_shapes_with_picture()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add autoshape of rectangle type

    shp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, 75, 150)

    # Set the fill type to Picture

    shp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Picture)

    # Set the picture fill mode

    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(Rjb::import('com.aspose.slides.PictureFillMode').Tile)

    # Set the picture

    imgx = pres.getImages().addImage(Rjb::import('java.io.FileInputStream').new(Rjb::import('java.io.File').new(data_dir + "night.jpg")))

    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(imgx)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "RectShpPic.pptx", save_format.Pptx)

    puts "Filled shapes with Picture, please check the output file."

end   

```
## **Download Running Code**
Download **Filling Shapes with Picture (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/fillingshapes.rb)
