---
title: Converting Presentation to PDF in Ruby
type: docs
weight: 40
url: /java/converting-presentation-to-pdf-in-ruby/
---

## **Aspose.Slides - Converting Presentation to PDF**
To convert presentation to PDF document using **Aspose.Slides Java for Ruby**, simply invoke **ConvertingToPdf** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate a Presentation object that represents a PPTX file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

\# Saving the PPTX presentation to Pdf format

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Aspose.pdf", save_format.Pdf)

puts "Document has been converted, please check the output file."


```
## **Download Running Code**
Download **Hello World (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/convertingtopdf.rb)
