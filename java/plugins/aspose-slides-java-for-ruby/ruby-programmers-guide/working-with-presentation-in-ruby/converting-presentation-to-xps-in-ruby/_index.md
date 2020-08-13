---
title: Converting Presentation to XPS in Ruby
type: docs
weight: 60
url: /java/converting-presentation-to-xps-in-ruby/
---

## **Aspose.Slides - Converting Presentation to XPS with default size**
To convert presentation to XPS with default size using **Aspose.Slides Java for Ruby**, simply invoke **convert_with_default_size** method of **ConvertingToXps** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def convert_with_default_size()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    # Saving the presentation to XPS format

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose.xps", save_format.Xps)

    puts "Document has been converted, please check the output file."

end   

```
## **Aspose.Slides - Converting Presentation to XPS with custom size**
To convert presentation to XPS with custom size using **Aspose.Slides Java for Ruby**, simply invoke **convert_with_custom_size** method of **ConvertingToXps** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def convert_with_custom_size()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    # Instantiate the TiffOptions class

    opts = Rjb::import('com.aspose.slides.XpsOptions').new

    # Save MetaFiles as PNG

    opts.SaveMetafilesAsPng = true

    # Save the presentation to TIFF with specified image size

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose-Custom-Size.xps", save_format.Xps, opts)

    puts "Document has been converted, please check the output file."

end  

```
## **Download Running Code**
Download **Converting Presentation to XPS (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/convertingtoxps.rb)
