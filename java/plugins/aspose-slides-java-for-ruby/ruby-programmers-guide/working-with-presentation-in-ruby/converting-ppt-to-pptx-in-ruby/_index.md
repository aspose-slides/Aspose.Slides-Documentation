---
title: Converting PPT to PPTX in Ruby
type: docs
weight: 20
url: /java/converting-ppt-to-pptx-in-ruby/
---

## **Aspose.Slides - Converting PPT to PPTX**
To convert PPT to PPTX presentation using **Aspose.Slides Java for Ruby**, simply invoke **PptToPptx** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate a Presentation object that represents a PPTX file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Presentation1.ppt")

\# Saving the PPT presentation to PPTX format

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Aspose.pptx", save_format.Pptx)

puts "Document has been converted, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Converting PPT to PPTX (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/ppttopptx.rb)
