---
title: Exporting Text to HTML in Ruby
type: docs
weight: 40
url: /java/exporting-text-to-html-in-ruby/
---

## **Aspose.Slides - Exporting Text to HTML**
To Export Text to HTML using **Aspose.Slides Java for Ruby**, simply invoke **ExportTextToHtml** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



\# Create an instance of Presentation class

pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'input.pptx')

\# Get the first slide

slide= pres.getSlides().get_Item(0)

\# Desired index                                                                                                                  

index = 0                                                                                                                    



\# Accessing the added shape                                                                                                      

ashape = slide.getShapes().get_Item(index)



\# Creating output html file                                                                                                  

os = Rjb::import('java.io.FileOutputStream').new(data_dir + "export.html")                                                    

writer = Rjb::import('java.io.OutputStreamWriter').new(os,"UTF-8")                                                                



\# Extracting first paragraph as HTML                                                                                        

\# Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied                       

writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), nil))

writer.close()                    

puts "Export text to html, please check the output file."

```
## **Download Running Code**
Download **Exporting Text to HTML (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/exporttexttohtml.rb)
