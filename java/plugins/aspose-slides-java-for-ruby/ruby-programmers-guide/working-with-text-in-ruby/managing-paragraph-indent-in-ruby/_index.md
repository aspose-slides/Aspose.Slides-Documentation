---
title: Managing Paragraph Indent in Ruby
type: docs
weight: 120
url: /java/managing-paragraph-indent-in-ruby/
---

## **Aspose.Slides - Managing Paragraph Indent**
To Manage Paragraph Indent using **Aspose.Slides Java for Ruby**, call **paragraphs_indentation** method of **Paragraphs** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def paragraphs_indentation()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Add a Rectangle Shape

    rect = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle,100, 100, 500, 150)

    # Add TextFrame to the Rectangle

    tf = rect.addTextFrame("This is first line \nThis is second line \nThis is third line")

    # Set the text to fit the shape

    tf.getTextFrameFormat().setAutofitType(Rjb::import('com.aspose.slides.TextAutofitType').Shape)

    # Hide the lines of the Rectangle

    rect.getLineFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    # Get first Paragraph in the TextFrame and set its Indent

    para1 = tf.getParagraphs().get_Item(0)

    # Setting paragraph bullet style and symbol

    para1.getParagraphFormat().getBullet().setType(Rjb::import('com.aspose.slides.BulletType').Symbol)

    para1.getParagraphFormat().getBullet().setChar(8226)

    para1.getParagraphFormat().setAlignment(Rjb::import('com.aspose.slides.TextAlignment').Left)

    para1.getParagraphFormat().setDepth(2)

    para1.getParagraphFormat().setIndent(30)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "InOutDent.pptx", save_format.Pptx)

    puts "Done with paragraphs identation, please check the output file."

end

```
## **Download Running Code**
Download **Managing Paragraph Indent (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/paragraphs.rb)
