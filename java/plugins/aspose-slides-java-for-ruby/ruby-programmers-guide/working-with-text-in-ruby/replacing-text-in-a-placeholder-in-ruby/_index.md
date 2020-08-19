---
title: Replacing Text in a Placeholder in Ruby
type: docs
weight: 160
url: /java/replacing-text-in-a-placeholder-in-ruby/
---

## **Aspose.Slides - Replacing Text in a Placeholder**
To Replace Text in a Placeholder using **Aspose.Slides Java for Ruby**, simply invoke **ReplaceText** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Welcome.pptx')

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Change the text of each placeholder

shp = sld.getShapes().get_Item(0)

shp.getTextFrame().setText("This is Placeholder")

\# Write the presentation as a PPTX file

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Welcome_PH.pptx", save_format.Pptx)

puts "Replaced text, please check the output file."

```
## **Download Running Code**
Download **Replacing Text in a Placeholder (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/replacetext.rb)
