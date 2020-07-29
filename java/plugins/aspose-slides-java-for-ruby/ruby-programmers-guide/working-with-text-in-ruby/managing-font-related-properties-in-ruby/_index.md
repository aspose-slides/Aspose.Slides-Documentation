---
title: Managing Font Related Properties in Ruby
type: docs
weight: 70
url: /java/managing-font-related-properties-in-ruby/
---

## **Aspose.Slides - Managing Font Related Properties**
To Manage Font Related Properties using **Aspose.Slides Java for Ruby**, call **font_properties** method of **TextFont** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def font_properties()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Welcome.pptx')

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape

    tf1 = slide.getShapes().get_Item(0).getTextFrame()

    tf2 = slide.getShapes().get_Item(1).getTextFrame()

    # Accessing the first Paragraph

    para1 = tf1.getParagraphs().get_Item(0)

    para2 = tf2.getParagraphs().get_Item(0)

    # Accessing the first portion

    port1 = para1.getPortions().get_Item(0)

    port2 = para2.getPortions().get_Item(0)

    # Define new fonts

    fd1 = Rjb::import('com.aspose.slides.FontData').new("Elephant")

    fd2 = Rjb::import('com.aspose.slides.FontData').new("Castellar")

    # Assign new fonts to portion

    port1.getPortionFormat().setLatinFont(fd1)

    port2.getPortionFormat().setLatinFont(fd2)

    # Set font to Bold

    port1.getPortionFormat().setFontBold(Rjb::import('com.aspose.slides.NullableBool').True)

    port2.getPortionFormat().setFontBold(Rjb::import('com.aspose.slides.NullableBool').True)

    # Set font to Italic

    port1.getPortionFormat().setFontItalic(Rjb::import('com.aspose.slides.NullableBool').True)

    port2.getPortionFormat().setFontItalic(Rjb::import('com.aspose.slides.NullableBool').True)

    # Set font color

    port1.getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLUE)

    port2.getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').GREEN)

    # Write the presentation as a PPTX file 

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "WelcomeFont.pptx", save_format.Pptx)

    puts "Done with font properties, please check the output file."

end

{{< /highlight >}}
## **Download Running Code**
Download **Managing Font Related Properties (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/textfont.rb)
