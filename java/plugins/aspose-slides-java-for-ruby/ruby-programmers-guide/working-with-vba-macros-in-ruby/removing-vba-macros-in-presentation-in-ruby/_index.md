---
title: Removing VBA Macros in Presentation in Ruby
type: docs
weight: 10
url: /java/removing-vba-macros-in-presentation-in-ruby/
---

## **Aspose.Slides - Removing VBA Macros in Presentation**
To Remove VBA Macros in Presentation using **Aspose.Slides Java for Ruby**, simply invoke **RemoveVBAMacro** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'

\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'vbamacro.pptx')

\# Access the Vba module and remove

pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0))

\# Write the presentation as a PPTX file

pres.save(data_dir + "RemoveVBAMacro.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

puts "Removed VBA Macro, please check the output file."

```
## **Download Running Code**
Download **Removing VBA Macros in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/VBAMacros/removevbamacro.rb)
