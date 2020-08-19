---
title: Accessing Slides of a Presentation in Ruby
type: docs
weight: 10
url: /java/accessing-slides-of-a-presentation-in-ruby/
---

## **Aspose.Slides - Access Slide by Index**
To access Slide by Index of a Presentation using **Aspose.Slides Java for Ruby**, call **get_slide_by_index** method of **AccessSlides** module. Here you can see example code.

**Ruby Code**

```

 def get_slide_by_index()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Accessing a slide using its slide index

    slide = pres.getSlides().get_Item(0)

    puts "Slide: " + slide.to_string

end

```
## **Aspose.Slides - Access Slide by ID**
To access Slide by ID of a Presentation using **Aspose.Slides Java for Ruby**, call **get_slide_by_id** method of **AccessSlides** module. Here you can see example code.

**Ruby Code**

```

 def get_slide_by_id()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new(data_dir + 'Aspose.pptx')

    # Getting Slide ID

    id = pres.getSlides().get_Item(0).getSlideId()



    # Accessing Slide by ID

    slide = pres.getSlideById(id)

    puts "Slide: " + slide.to_string

end   

```
## **Download Running Code**
Download **Accessing Slides of a Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Slides/accessslides.rb)
