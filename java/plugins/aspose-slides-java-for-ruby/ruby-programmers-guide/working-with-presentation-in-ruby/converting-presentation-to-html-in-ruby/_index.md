---
title: Converting Presentation to HTML in Ruby
type: docs
weight: 30
url: /java/converting-presentation-to-html-in-ruby/
---

## **Aspose.Slides - Converting Presentation to HTML**
To convert presentation to HTML using **Aspose.Slides Java for Ruby**, simply invoke **convert_to_html method** of **ConvertingToHtml** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def convert_to_html()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    html_opt = Rjb::import('com.aspose.slides.HtmlOptions').new

    html_formatter = Rjb::import('com.aspose.slides.HtmlFormatter')

    html_opt.setHtmlFormatter(html_formatter.createDocumentFormatter("",false))

    # Saving the presentation to HTML format

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose.html", save_format.Html, html_opt)

    puts "Document has been converted, please check the output file."

end   

{{< /highlight >}}
## **Download Running Code**
Download **Converting Presentation to HTML (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/convertingtohtml.rb)
