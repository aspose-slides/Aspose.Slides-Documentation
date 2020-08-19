---
title: Converting Presentation with Notes in Ruby
type: docs
weight: 70
url: /java/converting-presentation-with-notes-in-ruby/
---

## **Aspose.Slides - Converting Presentation to TIFF Notes**
To convert Presentation to TIFF Notes using **Aspose.Slides Java for Ruby**, simply invoke **convert_to_tiff_notes** method of **ConvertingToNotes** module. Here you can see example code.

**Ruby Code**

```

 def convert_to_tiff_notes()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Notes.tiff", save_format.TiffNotes)

    puts "Document has been converted, please check the output file."

end   

```
## **Aspose.Slides - Converting Presentation to PDF Notes**
To convert Presentation to PDF Notes using **Aspose.Slides Java for Ruby**, simply invoke **convert_to_pdf_notes** method of **ConvertingToNotes** module. Here you can see example code.

**Ruby Code**

```

 def convert_to_pdf_notes()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate a Presentation object that represents a PPTX file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + "Aspose.pptx")

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Notes.pdf", save_format.Pdf)

    puts "Document has been converted, please check the output file."

end   

```
## **Download Running Code**
Download **Converting Presentation with Notes (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Presentation/convertingtonotes.rb)
