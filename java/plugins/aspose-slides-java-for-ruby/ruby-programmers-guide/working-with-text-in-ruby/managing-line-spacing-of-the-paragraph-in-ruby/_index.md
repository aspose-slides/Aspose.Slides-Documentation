---
title: Managing Line Spacing of the paragraph in Ruby
type: docs
weight: 90
url: /java/managing-line-spacing-of-the-paragraph-in-ruby/
---

## **Aspose.Slides - Managing Line Spacing of the paragraph**
To Manage Line Spacing of the paragraph using **Aspose.Slides Java for Ruby**, call **line_spacing** method of **Paragraphs** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def line_spacing()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Welcome.pptx')

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Access the TextFrame

    tf = slide.getShapes().get_Item(0).getTextFrame()

    # Access the Paragraph

    para = tf.getParagraphs().get_Item(0)

    # Set properties of Paragraph

    para.getParagraphFormat().setSpaceWithin(80)

    para.getParagraphFormat().setSpaceBefore(40)

    para.getParagraphFormat().setSpaceAfter(40)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "LineSpacing.pptx", save_format.Pptx)

    puts "Done with line spacing, please check the output file."

end

{{< /highlight >}}
## **Download Running Code**
Download **Managing Line Spacing of the paragraph (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/paragraphs.rb)
