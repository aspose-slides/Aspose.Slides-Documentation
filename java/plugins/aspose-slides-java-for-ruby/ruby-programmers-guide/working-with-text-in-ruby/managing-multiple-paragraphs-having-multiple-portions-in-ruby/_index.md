---
title: Managing Multiple Paragraphs having Multiple Portions in Ruby
type: docs
weight: 100
url: /java/managing-multiple-paragraphs-having-multiple-portions-in-ruby/
---

## **Aspose.Slides - Managing Multiple Paragraphs having Multiple Portions**
To Manage Multiple Paragraphs having Multiple Portions using **Aspose.Slides Java for Ruby**, call **multiple_paragraphs_having_muliple_portions** method of **Paragraphs** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def multiple_paragraphs_having_muliple_portions()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type

    ashp = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 50, 150, 300, 150)

    # Access TextFrame of the AutoShape

    tf = ashp.getTextFrame()

    # Create Paragraphs and Portions with different text formats

    para0 = tf.getParagraphs().get_Item(0)

    port01 = Rjb::import('com.aspose.slides.Portion').new

    port02 = Rjb::import('com.aspose.slides.Portion').new

    para0.getPortions().add(port01)

    para0.getPortions().add(port02)

    para1 = Rjb::import('com.aspose.slides.Paragraph').new

    tf.getParagraphs().add(para1)

    port10 = Rjb::import('com.aspose.slides.Portion').new

    port11 = Rjb::import('com.aspose.slides.Portion').new

    port12 = Rjb::import('com.aspose.slides.Portion').new

    para1.getPortions().add(port10)

    para1.getPortions().add(port11)

    para1.getPortions().add(port12)

    para2 = Rjb::import('com.aspose.slides.Paragraph').new

    tf.getParagraphs().add(para2)

    port20 = Rjb::import('com.aspose.slides.Portion').new

    port21 = Rjb::import('com.aspose.slides.Portion').new

    port22 = Rjb::import('com.aspose.slides.Portion').new

    para2.getPortions().add(port20)

    para2.getPortions().add(port21)

    para2.getPortions().add(port22)

    i = 0

    for i in 0..2

       j = 0

       for j in 0..2

           tf.getParagraphs().get_Item(i).getPortions().get_Item(j).setText("Portion0#{j}")

           if j == 0

               tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

               tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').RED)

               tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().setFontBold(Rjb::import('com.aspose.slides.NullableBool').True)

               tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().setFontHeight(15)

           #elseif j == 1

           #    tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

           #    tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLUE)

           #    tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().setFontItalic(Rjb::import('com.aspose.slides.NullableBool').True)

           #    tf.getParagraphs().get_Item(i).getPortions().get_Item(j).getPortionFormat().setFontHeight(18)

           end

       end

    end   

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "multiParaPort.pptx", save_format.Pptx)

    puts "Done with multiple paragraphs, please check the output file."

end

{{< /highlight >}}
## **Download Running Code**
Download **Managing Multiple Paragraphs having Multiple Portions (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/paragraphs.rb)
