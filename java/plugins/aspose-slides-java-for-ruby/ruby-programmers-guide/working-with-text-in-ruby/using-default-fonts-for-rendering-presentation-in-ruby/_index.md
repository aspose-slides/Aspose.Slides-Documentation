---
title: Using Default Fonts for Rendering Presentation in Ruby
type: docs
weight: 170
url: /java/using-default-fonts-for-rendering-presentation-in-ruby/
---

## **Aspose.Slides - Using Default Fonts for Rendering Presentation**
To Use Default Fonts for Rendering Presentation using **Aspose.Slides Java for Ruby**, call **set_default_font_for_rendering** method of **TextFont** module. Here you can see example code.

**Ruby Code**

```

 def set_default_font_for_rendering()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Use load options to define the default regualr and asian fonts                               

    lo = Rjb::import('com.aspose.slides.LoadOptions').new(Rjb::import('com.aspose.slides.LoadFormat').Auto)                                           

    lo.setDefaultRegularFont("Wingdings")                                                         

    lo.setDefaultAsianFont("Wingdings") 

    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'input.pptx')



    # Generate PDF 

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "output.pdf", save_format.Pdf)

    puts "Done with font family for text, please check the output file."

end

```
## **Download Running Code**
Download **Using Default Fonts for Rendering Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/textfont.rb)
