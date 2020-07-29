---
title: Managing the Hyperlinks in Presentation in Ruby
type: docs
weight: 80
url: /java/managing-the-hyperlinks-in-presentation-in-ruby/
---

## **Aspose.Slides - Removing Hyperlinks inside Presentation**
To Remove Hyperlinks inside Presentation using **Aspose.Slides Java for Ruby**, simply invoke **Hyperlinks** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate Presentation class that represents the presentation file

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'demo.pptx')

\# Removing the hyperlinks from presentation

pres.getHyperlinkQueries().removeAllHyperlinks()

\# Saving the presentation

save_format = Rjb::import('com.aspose.slides.SaveFormat')

pres.save(data_dir + "Hyperlinks.pptx", save_format.Pptx)

puts "Removed hyperlinks successfully, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Managing the Hyperlinks in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/hyperlinks.rb)
