---
title: Accessing OpenDocument Presentation in Ruby
type: docs
weight: 10
url: /java/accessing-opendocument-presentation-in-ruby/
---

## **Aspose.Slides - Accessing OpenDocument Presentation**
To convert OpenDocument to PPTX presentation using **Aspose.Slides Java for Ruby**, simply invoke **OdpToPptx** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate a Presentation object that represents a PPTX file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Source.odp")

\# Saving the PPTX presentation to PPTX format

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Source.pptx", save_format.Pptx)

puts "Document has been converted, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Accessing OpenDocument Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/odptopptx.rb)
