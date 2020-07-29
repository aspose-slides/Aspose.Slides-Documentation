---
title: Managing Paragraphs Alignment in Ruby
type: docs
weight: 130
url: /java/managing-paragraphs-alignment-in-ruby/
---

## **Aspose.Slides - Managing Paragraphs Alignment**
To Manage Paragraphs Alignment using **Aspose.Slides Java for Ruby**, call **paragraphs_alignment** method of **Paragraphs** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def paragraphs_alignment()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'leftalign.pptx')

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape

    tf1 = slide.getShapes().get_Item(0).getTextFrame()

    tf2 = slide.getShapes().get_Item(1).getTextFrame()

    # Change the text in both placeholders

    tf1.setText("Center Align by Aspose")

    tf2.setText("Center Align by Aspose")

    # Getting the first paragraph of the placeholders

    para1 = tf1.getParagraphs().get_Item(0)

    para2 = tf2.getParagraphs().get_Item(0)

    # Aligning the text paragraph to center

    para1.getParagraphFormat().setAlignment(Rjb::import('com.aspose.slides.TextAlignment').Center)

    para2.getParagraphFormat().setAlignment(Rjb::import('com.aspose.slides.TextAlignment').Center)

    # Write the presentation as a PPTX file 

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Centeralign.pptx", save_format.Pptx)

    puts "Done with text alignment, please check the output file."

end

{{< /highlight >}}
## **Download Running Code**
Download **Managing Paragraphs Alignment (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/paragraphs.rb)
