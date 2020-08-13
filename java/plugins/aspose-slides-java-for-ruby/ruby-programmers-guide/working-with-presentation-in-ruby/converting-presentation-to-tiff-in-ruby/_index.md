---
title: Converting Presentation to TIFF in Ruby
type: docs
weight: 50
url: /java/converting-presentation-to-tiff-in-ruby/
---

## **Aspose.Slides - Converting Presentation to TIFF with default size**
To convert presentation to TIFF with default size using **Aspose.Slides Java for Ruby**, simply invoke **convert_with_default_size** method of **ConvertingToTiff** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def convert_with_default_size()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    # Saving the PPTX presentation to Tiff format

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose.tiff", save_format.Tiff)

    puts "Document has been converted, please check the output file."

end   

```
## **Aspose.Slides - Converting Presentation to TIFF with custom size**
To convert presentation to TIFF with custom size using **Aspose.Slides Java for Ruby**, simply invoke **convert_with_custom_size** method of **ConvertingToTiff** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def convert_with_custom_size()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    # Instantiate the TiffOptions class

    opts = Rjb::import('com.aspose.slides.TiffOptions').new

    # Setting compression type

    tiff_compression_types = Rjb::import('com.aspose.slides.TiffCompressionTypes')

    opts.setCompressionType (tiff_compression_types.Default)

    # Compression Types

    #Default - Specifies the default compression scheme (LZW).

    #None - Specifies no compression.

    #CCITT3

    #CCITT4

    #LZW

    #RLE

    # Depth - depends on the compression type and cannot be set manually.

    # Resolution unit - is always equal to "2" (dots per inch)

    #Setting image DPI

    opts.setDpiX(200)

    opts.setDpiY(100)

    # Set Image Size

    opts.setImageSize(Rjb::import('java.awt.Dimension').new(1728, 1078))

    # Save the presentation to TIFF with specified image size

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose-Custom-Size.tiff", save_format.Tiff, opts)

    puts "Document has been converted, please check the output file."

end  

```
## **Download Running Code**
Download **Converting Presentation to TIFF (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/convertingtotiff.rb)
