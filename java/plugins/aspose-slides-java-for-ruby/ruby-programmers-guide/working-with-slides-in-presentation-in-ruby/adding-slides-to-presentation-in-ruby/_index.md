---
title: Adding Slides to Presentation in Ruby
type: docs
weight: 20
url: /java/adding-slides-to-presentation-in-ruby/
---

## **Aspose.Slides - Adding Slides to Presentation**
To add Slides to Presentation using **Aspose.Slides Java for Ruby**, simply invoke **AddSlides** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate Presentation class that represents the presentation file

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Instantiate SlideCollection calss

slides = pres.getSlides()

i = 0

while i < pres.getLayoutSlides().size()     

    # Add an empty slide to the Slides collection

    slides.addEmptySlide(pres.getLayoutSlides().get_Item(i))

    i +=1

end

#Do some work on the newly added slide

\# Saving the presentation

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "EmptySlide.pptx", save_format.Pptx)

puts "Document has been created, please check the output file."

```
## **Download Running Code**
Download **Adding Slides to Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/addslides.rb)
