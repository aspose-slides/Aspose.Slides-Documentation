---
title: Creating a TextBox on Slide in Ruby
type: docs
weight: 20
url: /java/creating-a-textbox-on-slide-in-ruby/
---

## **Aspose.Slides - Creating a TextBox on Slide**
To Create a TextBox on Slide using **Aspose.Slides Java for Ruby**, call **create_textbox** method of **CreateTextBox** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def create_textbox()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    sld = pres.getSlides().get_Item(0)

    # Add autoshape of rectangle type

    shp = sld.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 150, 75, 150, 50)

    # Add TextFrame to the Rectangle

    shp.addTextFrame(" ")

    # Accessing the text frame

    txt_frame = shp.getTextFrame()

    # Create the Paragraph object for text frame

    para = txt_frame.getParagraphs().get_Item(0)

    # Create Portion object for paragraph

    portion = para.getPortions().get_Item(0)

    # Set Text

    portion.setText("Aspose TextBox")

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "TextBox.pptx", save_format.Pptx)

    puts "Created TextBox, please check the output file."

end

{{< /highlight >}}
## **Download Running Code**
Download **Creating a TextBox on Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/createtextbox.rb)
