---
title: Removing Slides from a Presentation in Ruby
type: docs
weight: 90
url: /java/removing-slides-from-a-presentation-in-ruby/
---

## **Aspose.Slides - Remove Slide by Index**
To remove Slide by Index from a Presentation using **Aspose.Slides Java for Ruby**, call **remove_slide_by_index** method of **RemoveSlides** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def remove_slide_by_index()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Accessing a slide using its slide index

    slide = pres.getSlides().get_Item(0)

    # Removing a slide using its reference

    pres.getSlides().remove(slide)

    # Saving the presentation file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Modified.pptx", save_format.Pptx)

    puts "Document has been created, please check the output file."

end   

```
## **Aspose.Slides - Remove Slide by ID**
To remove Slide by ID from a Presentation using **Aspose.Slides Java for Ruby**, call **remove_slide_by_id** method of **RemoveSlides** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def remove_slide_by_id()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Removing a slide using its slide index

    pres.getSlides().removeAt(1)

    # Saving the presentation file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Modified.pptx", save_format.Pptx)

    puts "Removed slide by ID, please check the output file."

end   

```
## **Download Running Code**
Download **Removing Slides from a Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/removeslides.rb)
