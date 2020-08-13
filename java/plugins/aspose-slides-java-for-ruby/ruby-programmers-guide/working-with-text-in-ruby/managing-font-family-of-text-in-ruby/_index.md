---
title: Managing Font Family of Text in Ruby
type: docs
weight: 60
url: /java/managing-font-family-of-text-in-ruby/
---

## **Aspose.Slides - Managing Font Family of Text**
To Manage Font Family of Text using **Aspose.Slides Java for Ruby**, call **font_family_of_text** method of **TextFont** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def font_family_of_text()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type

    ashp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 50, 200, 50)

    # Remove any fill style associated with the AutoShape

    ashp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').NoFill)

    # Access the TextFrame associated with the AutoShape

    tf = ashp.getTextFrame()

    tf.setText("Aspose TextBox")

    # Access the Portion associated with the TextFrame

    port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Set the Font for the Portion

    port.getPortionFormat().setLatinFont(Rjb::import('com.aspose.slides.FontData').new("Times New Roman"))

    # Set Bold property of the Font

    port.getPortionFormat().setFontBold(Rjb::import('com.aspose.slides.NullableBool').True)

    # Set Italic property of the Font

    port.getPortionFormat().setFontItalic(Rjb::import('com.aspose.slides.NullableBool').True)

    # Set Underline property of the Font

    port.getPortionFormat().setFontUnderline(Rjb::import('com.aspose.slides.TextUnderlineType').Single)

    # Set the Height of the Font

    port.getPortionFormat().setFontHeight(25)

    # Set the color of the Font

    port.getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLUE)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "FontFamilyOfText.pptx", save_format.Pptx)

    puts "Done with font family for text, please check the output file."

end

```
## **Download Running Code**
Download **Managing Font Family of Text (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/textfont.rb)
