---
title: Clone Slides
type: docs
weight: 40
url: /python-net/clone-slides/
keywords: "Clone slide, Copy slide, Save slide copy, PowerPoint, Presentation, Python, Aspose.Slides"
description: "Clone PowerPoint slide in Python"
---

## **Clone Slides in Presentation**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for Python via .NET also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

In Aspose.Slides for Python via .NET, (a collection of [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) objects) exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object provides the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) and [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) methods to perform the above types of slide cloning
## **Clone at End Within a Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method according to the steps listed below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) class by referencing the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
2. Call the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) object and pass the slide to be cloned as a parameter to the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method.
3. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents a presentation file
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # Clone the desired slide to the end of the collection of slides in the same presentation
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # Write the modified presentation to disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone at Another Position Within Presentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Instantiate the class by referencing the **Slides** collection exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
1. Call the [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) object and pass the slide to be cloned along with the index for the new position as a parameter to the [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents a presentation file
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # Clone the desired slide to the end of the collection of slides in the same presentation
    slds = pres.slides

    # Clone the desired slide to the specified index in the same presentation
    slds.insert_clone(2, pres.slides[1])

    # Write the modified presentation to disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone at End in Another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class containing the destination presentation that the slide will be added to.
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) class by referencing the **Slides** collection exposed by the Presentation object of the destination presentation.
1. Call the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) object and pass the slide from the source presentation as a parameter to the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

```py
import aspose.slides as slides

# Instantiate Presentation class to load the source presentation file
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    with slides.Presentation() as destPres:
        # Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # Write the destination presentation to disk
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone at Another Position in Another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) object and pass the slide from the source presentation along with the desired position as a parameter to the [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

```py
import aspose.slides as slides

# Instantiate Presentation class to load the source presentation file
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # Write the destination presentation to disk
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone at Specific Position in Another Presentation**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **add_clone(ISlide, IMasterSlide)** expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) class by referencing the Masters collection exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object of the destination presentation.
1. Call the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method exposed by the [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) object and pass the master from the source PPTX to be cloned as a parameter to the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method.
1. Instantiate the [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) class by setting the reference to the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object of the destination presentation.
2. Call the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method.
3. Write the modified destination presentation file.

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using a master from source slide.

```py
import aspose.slides as slides

# Instantiate Presentation class to load the source presentation file
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # Instantiate Presentation class for destination presentation (where slide is to be cloned)
    with slides.Presentation() as destPres:
        # Instantiate ISlide from the collection of slides in source presentation along with
        # Master slide
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # Clone the desired master slide from the source presentation to the collection of masters in the
        # Destination presentation
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # Clone the desired master slide from the source presentation to the collection of masters in the
        # Destination presentation
        iSlide = masters.add_clone(sourceMaster)

        # Clone the desired slide from the source presentation with the desired master to the end of the
        # Collection of slides in the destination presentation
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)
      
        # Clone the desired master slide from the source presentation to the collection of masters in the # Destination presentation
        # save the destination presentation to disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```



## Clone at End in Specified Section

With Aspose.Slides for Python via .NET, you can clone a slide from one section of a presentation and insert that slide into another section in the same presentation. In this case, you have to use the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method from the [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Interface. 

This Python code shows you how to clone a slide and insert the cloned slide into a specified section:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # to clone
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Section2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```



