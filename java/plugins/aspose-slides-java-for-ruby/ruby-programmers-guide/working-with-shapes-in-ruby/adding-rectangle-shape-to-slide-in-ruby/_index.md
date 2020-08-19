---
title: Adding Rectangle Shape to Slide in Ruby
type: docs
weight: 60
url: /java/adding-rectangle-shape-to-slide-in-ruby/
---

## **Aspose.Slides - Adding Simple Rectangle in the Slide**
To Add Simple Rectangle in the Slide using **Aspose.Slides Java for Ruby**, call **add_simple_rectangle_shape** method of **AddRectangleShape** module. Here you can see example code.

**Ruby Code**

```

 def add_simple_rectangle_shape()    

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add autoshape of rectangle type

    sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, 150, 50)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "SimpleRectangleShape.pptx", save_format.Pptx)

    puts "Added simple rectangle shape in the slide, please check the output file."

end   

```
## **Aspose.Slides - Adding Formatted Rectangle in the Slide**
To Add Formatted Rectangle in the Slide using **Aspose.Slides Java for Ruby**, call **add_formatted_rectangle_shape** method of **AddRectangleShape** module. Here you can see example code.

**Ruby Code**

```

 def add_formatted_rectangle_shape()    

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add autoshape of rectangle type

    shp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape

    shp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    shp.getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').new(Rjb::import('com.aspose.slides.PresetColor').Chocolate))

    # Apply some formatting to the line of Rectangle

    shp.getLineFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLACK)

    shp.getLineFormat().setWidth(5)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "FormattedRectangleShape.pptx", save_format.Pptx)

    puts "Added formatted rectangle shape in the slide, please check the output file."

end

```
## **Download Running Code**
Download **Adding Rectangle Shape to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/addrectangleshape.rb)
