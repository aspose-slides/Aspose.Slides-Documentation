---
title: Managing Fonts inside Presentation in Ruby
type: docs
weight: 80
url: /java/managing-fonts-inside-presentation-in-ruby/
---

## **Aspose.Slides - Replacing Fonts Explicitly Inside Presentation**
To Replace Fonts Explicitly Inside Presentation using **Aspose.Slides Java for Ruby**, call **replace_font** method of **ManageFont** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def replace_font()    

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'input.pptx')

    # Load source font to be replaced

    source_font = Rjb::import('com.aspose.slides.FontData').new("Arial")



    # Load the replacing font

    dest_font = Rjb::import('com.aspose.slides.FontData').new("Times New Roman")



    # Replace the fonts

    fonts_manager = Rjb::import('com.aspose.slides.FontsManager')

    pres.fonts_manager.replaceFont(source_font, dest_font)

    # Write the presentation as a PPTX file 

    pres.save(data_dir + "ReplaceFont.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

    puts "Replaced font, please check the output file."

end

```
## **Download Running Code**
Download **Managing Fonts inside Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/managefont.rb)
