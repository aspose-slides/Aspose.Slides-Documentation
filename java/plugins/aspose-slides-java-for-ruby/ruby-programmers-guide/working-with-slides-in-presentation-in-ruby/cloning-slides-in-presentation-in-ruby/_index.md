---
title: Cloning Slides in Presentation in Ruby
type: docs
weight: 40
url: /java/cloning-slides-in-presentation-in-ruby/
---

## **Aspose.Slides - Within the Same Presentation from One Position to the End**
To clone slide within the Same Presentation from One Position to the End using **Aspose.Slides Java for Ruby**, call **clone_to_end_of_presentation** of **CloneSlides** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def clone_to_end_of_presentation()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Clone the desired slide to the end of the collection of slides in the same presentation

    slides = pres.getSlides()

    slides.addClone(pres.getSlides().get_Item(0))

    # Saving the presentation file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose_Cloned.pptx", save_format.Pptx)

    puts "Slide has been cloned, please check the output file."

end

```
## **Aspose.Slides - From One Position to Anther within the Same Presentation**
To clone slide from one Position to Anther within the same Presentation using **Aspose.Slides Java for Ruby**, call **clone_to_aonther_position** of **CloneSlides** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def clone_to_aonther_position()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Clone the desired slide to the end of the collection of slides in the same presentation

    slides = pres.getSlides()



    # Clone the desired slide to the specified index in the same presentation

    slides.insertClone(2, pres.getSlides().get_Item(1))

    # Saving the presentation file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Aspose_Cloned.pptx", save_format.Pptx)

    puts "Slide has been cloned, please check the output file."

end

```
## **Aspose.Slides - In Another Presentation at the End of the Existing Slides**
To clone slide at the End of the Existing Slides using **Aspose.Slides Java for Ruby**, call **clone_to_other_presentation_at_end_of_existing_slide** of **CloneSlides** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def clone_to_other_presentation_at_end_of_existing_slide()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    src_pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Instantiate Presentation class for destination PPTX (where slide is to be cloned)

    dest_pres = Rjb::import('com.aspose.slides.Presentation').new

    # Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation

    slds = dest_pres.getSlides()

    slds.addClone(src_pres.getSlides().get_Item(0))

    # Saving the presentation file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    dest_pres.save(data_dir + "Aspose_dest2.pptx", save_format.Pptx)

    puts "Slide has been cloned, please check the output file."

end

```
## **Download Running Code**
Download **Cloning Slides in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/cloneslides.rb)
