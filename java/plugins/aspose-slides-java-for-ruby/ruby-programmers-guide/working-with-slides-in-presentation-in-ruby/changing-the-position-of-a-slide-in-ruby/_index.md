---
title: Changing the Position of a Slide in Ruby
type: docs
weight: 30
url: /java/changing-the-position-of-a-slide-in-ruby/
---

## **Aspose.Slides - Changing the Position of a Slide**
To change the Position of a Slide using **Aspose.Slides Java for Ruby**, simply invoke **ChangingPosition** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate Presentation class that represents the presentation file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

\# Get the slide whose position is to be changed

slide = pres.getSlides().get_Item(0)

\# Set the new position for the slide

slide.setSlideNumber(2)

\# Saving the presentation

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Aspose_Position.pptx", save_format.Pptx)

puts "Changes slide position, please check the output file.

```
## **Download Running Code**
Download **Changing the Position of a Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/changingposition.rb)
