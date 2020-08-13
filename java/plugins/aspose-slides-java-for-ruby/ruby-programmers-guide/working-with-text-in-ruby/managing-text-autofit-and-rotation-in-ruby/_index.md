---
title: Managing Text Autofit and Rotation in Ruby
type: docs
weight: 140
url: /java/managing-text-autofit-and-rotation-in-ruby/
---

## **Aspose.Slides - Setting the AutofitType property of text frame**
To Set the AutofitType property of text frame using **Aspose.Slides Java for Ruby**, call **set_autofittype_of_text** method of **ManageText** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def set_autofittype_of_text()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type

    ashp = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle

    ashp.addTextFrame(" ")

    ashp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').NoFill)

    # Accessing the text frame

    txt_frame = ashp.getTextFrame()

    # Setting text autofit type

    txt_frame.getTextFrameFormat().setAutofitType(Rjb::import('com.aspose.slides.TextAutofitType').Shape)

    # Create the Paragraph object for text frame

    para = txt_frame.getParagraphs().get_Item(0)

    # Create Portion object for paragraph

    portion = para.getPortions().get_Item(0)

    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.")

    portion.getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLACK)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "formatText.pptx", save_format.Pptx)

    puts "Set autofittype of text, please check the output file."

end

```
## **Aspose.Slides - Setting the anchor of TextFrame**
To Set the anchor of TextFrame using **Aspose.Slides Java for Ruby**, call **set_anchor_of_text** method of **ManageText** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def set_anchor_of_text()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type

    ashp = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle

    ashp.addTextFrame(" ")

    ashp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').NoFill)

    # Accessing the text frame

    txt_frame = ashp.getTextFrame()

    # Setting text anchoring to bottom

    txt_frame.getTextFrameFormat().setAnchoringType(Rjb::import('com.aspose.slides.TextAnchorType').Bottom)

    # Create the Paragraph object for text frame

    para = txt_frame.getParagraphs().get_Item(0)

    # Create Portion object for paragraph

    portion = para.getPortions().get_Item(0)

    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.")

    portion.getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLACK)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "AnchorText.pptx", save_format.Pptx)

    puts "Set anchor of text, please check the output file."

end

```
## **Aspose.Slides - Rotating the text**
To Rotate the text using **Aspose.Slides Java for Ruby**, call **rotate_text** method of **ManageText** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def rotate_text()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type

    ashp = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle

    ashp.addTextFrame(" ")

    ashp.getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').NoFill)

    # Accessing the text frame

    txt_frame = ashp.getTextFrame()

    # Setting text Vertical type

    txt_frame.getTextFrameFormat().setTextVerticalType(Rjb::import('com.aspose.slides.TextVerticalType').Vertical270)

    # Create the Paragraph object for text frame

    para = txt_frame.getParagraphs().get_Item(0)

    # Create Portion object for paragraph

    portion = para.getPortions().get_Item(0)

    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.")

    portion.getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLACK)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "VerticleText.pptx", save_format.Pptx)

    puts "Done with text rotation, please check the output file."

end

```
## **Download Running Code**
Download **Managing Text Autofit and Rotation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/managetext.rb)
