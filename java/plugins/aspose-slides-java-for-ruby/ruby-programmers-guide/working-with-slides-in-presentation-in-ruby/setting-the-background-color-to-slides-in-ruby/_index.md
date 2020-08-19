---
title: Setting the Background Color to Slides in Ruby
type: docs
weight: 100
url: /java/setting-the-background-color-to-slides-in-ruby/
---

## **Aspose.Slides - Setting the Background Color of a Master Slide**
To Set the Background Color of a Master Slide using **Aspose.Slides Java for Ruby**, simply invoke **set_background_color_of_master_slide** method of **Background** module. Here you can see example code.

**Ruby Code**

```

 def set_background_color_of_master_slide()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Set the background color of the Master Slide to Forest Green

    pres.getMasters().get_Item(0).getBackground().setType(Rjb::import('com.aspose.slides.BackgroundType').OwnBackground)

    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').GREEN)

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "MasterBG.pptx", save_format.Pptx)

    puts "Set background color of master slide, please check the output file."

end

```
## **Aspose.Slides - Setting the Background Color of a Normal Slide**
To Set the Background Color of a Master Slide using **Aspose.Slides Java for Ruby**, simply invoke **set_background_color_of_normal_slide** method of **Background** module. Here you can see example code.

**Ruby Code**

```

 def set_background_color_of_normal_slide()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Set the background color of the Normal slide to Blue

    pres.getSlides().get_Item(0).getBackground().setType(Rjb::import('com.aspose.slides.BackgroundType').OwnBackground)

    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Solid)

    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Rjb::import('java.awt.Color').BLUE)

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "ContentBG.pptx", save_format.Pptx)

    puts "Set background color of normal slide, please check the output file."

end

```
## **Download Running Code**
Download **Setting the Background Color to Slides (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/background.rb)
