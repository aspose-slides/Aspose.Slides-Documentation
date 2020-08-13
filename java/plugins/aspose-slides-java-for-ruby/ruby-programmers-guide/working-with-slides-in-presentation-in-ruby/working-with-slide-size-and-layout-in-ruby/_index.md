---
title: Working With Slide Size and Layout in Ruby
type: docs
weight: 120
url: /java/working-with-slide-size-and-layout-in-ruby/
---

## **Aspose.Slides - Setting the Size and Type of a slide**
To Set the Size and Type of a slide using **Aspose.Slides Java for Ruby**, simply invoke **set_size_and_type** method of **SizeAndLayout** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def set_size_and_type()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'demo.pptx')

    aux_pres = Rjb::import('com.aspose.slides.Presentation').new

    slide = pres.getSlides().get_Item(0)

    # Set the slide size of generated presentations to that of source

    aux_pres.getSlideSize().setType(pres.getSlideSize().getType())

    aux_pres.getSlideSize().setSize(pres.getSlideSize().getSize())

    # Clone required slide        

    aux_pres.getSlides().addClone(pres.getSlides().get_Item(0))

    aux_pres.getSlides().removeAt(0)

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Slide_Size_Type.pptx", save_format.Pptx)

    puts "Set slide size and type, please check the output file."

end 

```
## **Aspose.Slides - Setting the page size when generating PDF**
To Set the page size when generating PDF using **Aspose.Slides Java for Ruby**, simply invoke **set_page_size_for_pdf** method of **SizeAndLayout** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def set_page_size_for_pdf()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Set SlideSize.Type Property

    pres.getSlideSize().setType(Rjb::import('com.aspose.slides.SlideSizeType').A4Paper)

    # Set different properties of PDF Options

    opts = Rjb::import('com.aspose.slides.PdfOptions').new

    opts.setSufficientResolution(600)

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Export.pdf", save_format.Pdf, opts)

    puts "Set page size for pdf, please check the output file."

end 

```
## **Download Running Code**
Download **Working With Slide Size and Layout (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/sizeandlayout.rb)
