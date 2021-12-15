---
title: Access Slide in Presentation
type: docs
weight: 20
url: /python-net/access-slide-in-presentation/
keywords: "Access PowerPoint Presentation, Access slide, Edit slide properties, Change slide position, Set slide number, index, ID, position  Python, Aspose.Slides"
description: "Access PowerPoint slide by index, ID, or position in Python. Edit slide properties"
---

## **Access Slides in Presentation**
In this topic, we will introduce the possible ways to access a slide from a presentation file. Each slide in a presentation has a unique Id. On the other hand, all the slides in the presentation are arranged in the order of the slide position starting from 0, that is, slide at position 1 will be accessible through 0 index of [ISlideCollection](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islidecollection/) associated with a [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) object.

Aspose.Slides for Python via .NET provides a [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class that can be used to find and access any desired slide present in the presentation. Currently, developers can access a slide in the following two ways.

1. Access Slide by Index.
1. Access Slide by ID.
### **Access Slide by Index**
[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class represents a presentation file and exposes all slides in it as a [ISlideCollection](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islidecollection/) collection (that is a collection of [ISlide](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) objects). All of these slides can be accessed from this Slides collection using a slide index as shown below in the example.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Obtain a slide's reference by its index
    slide = presentation.slides[0]
```


### **Access Slide by ID**
Every slide in the presentation has a unique ID associated with it. The [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class exposes the [get_slide_by_id(id)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method that can be used to access the slide by ID. All you need to do is to provide the valid slide ID and access that slide using [get_slide_by_id(id)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method as shown below in the example.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Getting Slide ID
    id = presentation.slides[0].slide_id
    # Accessing Slide by ID
    slide = presentation.get_slide_by_id(id)
```



## **Change Slide Position**
If you create a presentation using MS PowerPoint, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using MS PowerPoint, you can drag a selected slide to any other position of the presentation. Aspose.Slides for Python via .NET also allows developers to change the position of a slide within the presentation. It is very simple to change the position of a slide in the presentation. Just follow the steps below:

1. Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its Index.
1. Change the SlideNumber of the referenced slide.
1. Write the modified presentation file.

The example given below moves the slide (that was at position 1 to the second position and the slide that was at the second position, is moved to the first position and so on). In this way, all slides are adjusted automatically by Aspose.Slides for Python via .NET.

```py
import aspose.slides as slides

# Instantiate Presentation class to load the source presentation file
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # Get the slide whose position is to be changed
    sld = pres.slides[0]
    # Set the new position for the slide
    sld.slide_number = 2
    # Write the presentation to disk
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Slide Number**
Aspose.Slides for Python via .NET now supports, setting the Slide Number. In this topic, we will see with an example how to get and set the slide number property in Aspose.Slides. The new methods added to the Presentation allows to get or to set the number of the first slide in a presentation. When a new FirstSlideNumber value is specified all slide numbers are recalculated. In order to get or set the Slide Number, please follow the steps below:

1. Create an instance of Presentation class.
1. Get the slide number.
1. Set the slide number.
1. Write the presentation as a PPTX file.

In the example given below, we have get and set the slide number.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Get the slide number
    firstSlideNumber = presentation.first_slide_number
    # Set the slide number
    presentation.first_slide_number = 10
    
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

