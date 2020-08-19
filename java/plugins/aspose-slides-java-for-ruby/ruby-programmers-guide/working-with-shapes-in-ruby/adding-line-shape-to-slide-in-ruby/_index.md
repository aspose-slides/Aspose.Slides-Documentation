---
title: Adding Line Shape to Slide in Ruby
type: docs
weight: 40
url: /java/adding-line-shape-to-slide-in-ruby/
---

## **Aspose.Slides - Adding Plain Line to Slide**
To Add Plain Line to Slide using **Aspose.Slides Java for Ruby**, call **add_plain_line** method of **AddingLineShape** module. Here you can see example code.

**Ruby Code**

```

 def add_plain_line()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add an autoshape of type line

    sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Line, 50, 150, 300, 0)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "LineShape.pptx", save_format.Pptx)

    puts "Added plain line to slide, please check the output file."

end   

```
## **Aspose.Slides - Adding Arrow Shaped Line to Slide**
To Add Arrow Shaped Line to Slide using **Aspose.Slides Java for Ruby**, call **add_arrow_line** method of **AddingLineShape** module. Here you can see example code.

**Ruby Code**

```

 def add_arrow_line()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add an autoshape of type line

    shp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Line, 50, 150, 300, 0)

    # Apply some formatting on the line

    shp.getLineFormat().setStyle(Rjb::import('com.aspose.slides.LineStyle').ThickBetweenThin)

    shp.getLineFormat().setWidth(10)

    shp.getLineFormat().setDashStyle(Rjb::import('com.aspose.slides.LineDashStyle').DashDot)

    shp.getLineFormat().setBeginArrowheadLength(Rjb::import('com.aspose.slides.LineArrowheadLength').Short)

    shp.getLineFormat().setBeginArrowheadStyle(Rjb::import('com.aspose.slides.LineArrowheadStyle').Oval)

    shp.getLineFormat().setEndArrowheadLength(Rjb::import('com.aspose.slides.LineArrowheadLength').Long)

    shp.getLineFormat().setEndArrowheadStyle(Rjb::import('com.aspose.slides.LineArrowheadStyle').Triangle)

    shp.getLineFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').new(Rjb::import('com.aspose.slides.PresetColor').Maroon))


    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "ArrowShape.pptx", save_format.Pptx)

    puts "Added arrow shape line to slide, please check the output file."

end   

```
## **Download Running Code**
Download **Adding Line Shape to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/addinglineshape.rb)
