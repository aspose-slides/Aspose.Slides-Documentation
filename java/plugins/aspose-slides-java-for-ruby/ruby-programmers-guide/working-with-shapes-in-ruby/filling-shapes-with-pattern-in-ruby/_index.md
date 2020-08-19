---
title: Filling Shapes with Pattern in Ruby
type: docs
weight: 110
url: /java/filling-shapes-with-pattern-in-ruby/
---

## **Aspose.Slides - Filling Shapes with Pattern**
To Fill Shapes with Pattern using **Aspose.Slides Java for Ruby**, call **fill_shapes_with_pattern** method of **FillingShapes** module. Here you can see example code.

**Ruby Code**

```

 def fill_shapes_with_pattern()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Shapes/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add autoshape of rectangle type

    shp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, 75, 150)

    # Set the fill type to Pattern

    shp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Pattern)

    # Set the pattern style

    shp.getFillFormat().getPatternFormat().setPatternStyle(Rjb::import('com.aspose.slides.PatternStyle').Trellis)

    # Set the pattern back and fore colors

    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Rjb::import('java.awt.Color').LIGHT_GRAY)

    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Rjb::import('java.awt.Color').YELLOW)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "RectShpPatt.pptx", save_format.Pptx)

    puts "Filled shapes with Pattern, please check the output file."

end   

```
## **Download Running Code**
Download **Filling Shapes with Pattern (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Shapes/fillingshapes.rb)
