---
title: Setting Default Zoom Value for Presentation in Ruby
type: docs
weight: 110
url: /java/setting-default-zoom-value-for-presentation-in-ruby/
---

## **Aspose.Slides - Setting Default Zoom Value**
To set default Zoom value for presentation using **Aspose.Slides Java for Ruby**, simply invoke **Zoom** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Setting View Properties of Presentation

#pres.getViewProperties().getSlideViewProperties().setScale(50) # zoom value in percentages for slide view

pres.getViewProperties().getNotesViewProperties().setScale(50) # .Scale = 50; //zoom value in percentages for notes view

\# Save the presentation as a PPTX file

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Zoom.pptx", save_format.Pptx)

puts "Set zoom value, please check the output file."

```
## **Download Running Code**
Download **Setting Default Zoom Value (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/zoom.rb)
