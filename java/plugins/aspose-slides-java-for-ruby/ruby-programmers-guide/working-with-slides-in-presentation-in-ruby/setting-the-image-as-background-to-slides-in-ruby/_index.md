---
title: Setting the Image as Background to Slides in Ruby
type: docs
weight: 110
url: /java/setting-the-image-as-background-to-slides-in-ruby/
---

## **Aspose.Slides - Setting the Image as Background to Slides**
To Set the Image as Background to Slides using **Aspose.Slides Java for Ruby**, simply invoke **set_image_as_background_color** method of **Background** module. Here you can see example code.

**Ruby Code**

```

 def set_image_as_background_color()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Set the background with Image

    pres.getSlides().get_Item(0).getBackground().setType(Rjb::import('com.aspose.slides.BackgroundType').OwnBackground)

    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(Rjb::import('com.aspose.slides.FillType').Picture)

    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(Rjb::import('com.aspose.slides.PictureFillMode').Stretch)

    # Set the picture

    imgx = pres.getImages().addImage(Rjb::import('java.io.FileInputStream').new(Rjb::import('java.io.File').new(data_dir + 'night.jpg')))

    # Image imgx = pres.getImages().addImage(image);

    # Add image to presentation's images collection

    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx)

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "ContentBG_Image.pptx", save_format.Pptx)

    puts "Set image as background, please check the output file."

end

```
## **Download Running Code**
Download **Setting the Image as Background to Slides (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/background.rb)
