---
title: Clone PowerPoint Slides in Python
linktitle: Clone Slides
type: docs
weight: 40
url: /python-net/clone-slides/
keywords:
- clone slide
- copy slide
- save slide
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Quickly clone or duplicate PowerPoint slides with Aspose.Slides for Python via .NET. Follow our clear code examples and tips to automate PPT creation in seconds, boost productivity, and eliminate manual work."
---

## **Overview**

Cloning is the process of making an exact copy or replica of something. Aspose.Slides for Python via .NET allows you to clone any slide and insert that clone into the current presentation or another open presentation. The cloning process creates a new slide that you can modify without affecting the original.

There are several ways to clone a slide:

- Clone a slide at the end within the same presentation.
- Clone a slide to a specific position within the same presentation.
- Clone a slide at the end of another presentation.
- Clone a slide to a specific position in another presentation.
- Clone a slide with its master slide into another presentation.

In Aspose.Slides for Python via .NET, the [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object provides the `add_clone` and `insert_clone` methods to perform these types of slide cloning.

## **Clone at the End Within the Same Presentation**

If you want to clone a slide within the same presentation and append it to the end of the existing slides, use the `add_clone` method. Follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide collection from the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
1. Call the `add_clone` method on the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), passing the slide to be cloned.
1. Save the modified presentation.

In the example below, the first slide (index 0) is cloned and appended to the end of the presentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent the presentation file.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clone the desired slide to the end of the slide collection in the same presentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Save the modified presentation to disk.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone to a Specific Position Within the Same Presentation**

If you want to clone a slide within the same presentation and place it at a different position, use the `insert_clone` method:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide collection from the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
1. Call the `insert_clone` method on the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), passing the slide to be cloned and the target index for its new position.
1. Save the modified presentation.

In the example below, the slide at index 0 (position 1) is cloned to index 1 (position 2) within the same presentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent the presentation file.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clone the desired slide to the specified position (index) within the same presentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Save the modified presentation to disk.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone at the End of Another Presentation**

If you need to clone a slide from one presentation and append it to the end of another presentation:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class for the source presentation (the one that contains the slide to clone).
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class for the destination presentation (where the slide will be added).
1. Get the slide collection from the destination presentation.
1. Call `add_clone` on the destination [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), passing the slide from the source presentation.
1. Save the modified destination presentation.

In the example below, the slide at index 0 in the source presentation is cloned to the end of the destination presentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent the source presentation file.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instantiate the Presentation class for the destination PPTX (where the slide will be cloned).
    with slides.Presentation() as target_presentation:
        # Clone the desired slide from the source presentation to the end of the slide collection in the destination presentation.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Save the destination presentation to disk.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone to a Specific Position in Another Presentation**

If you need to clone a slide from one presentation and insert it into another presentation at a specific position:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class for the source presentation (the one containing the slide to clone).
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class for the destination presentation (where the slide will be added).
1. Get the slide collection from the destination presentation.
1. Call the `insert_clone` method on the destination [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), passing the slide from the source presentation and the desired target index.
1. Save the modified destination presentation.

In the example below, the slide at index 0 in the source presentation is cloned to index 1 (position 2) in the destination presentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent the source presentation file.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instantiate the Presentation class for the destination PPTX (where the slide is to be cloned).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insert a clone of the first slide from the source at index 2 in the destination presentation.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Save the destination presentation to disk.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone a Slide with Its Master Slide into Another Presentation**

If you need to clone a slide **with its master** from one presentation and use it in another, first clone the required master slide from the source presentation into the destination presentation. Then use that destination master when cloning the slide. The method `add_clone(Slide, MasterSlide)` expects a **master slide from the destination presentation**, not from the source.

To clone a slide with its master, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class for the source presentation (the one containing the slide to clone).
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class for the destination presentation.
1. Access the source slide to be cloned and its master slide.
1. Get the [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) from the destination presentation’s master collection.
1. Call `add_clone` on the destination [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), passing the source master to clone it into the destination.
1. Get the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) from the destination presentation’s slide collection.
1. Call `add_clone` on the destination [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), passing the source slide and the cloned destination master.
1. Save the modified destination presentation.

In the example below, the slide at index 0 in the source presentation is cloned to the end of the destination presentation using the master cloned from the source.

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent the source presentation file.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instantiate the Presentation class for the destination presentation where the slide will be cloned.
    with slides.Presentation() as target_presentation:
        # Get the first slide from the source presentation.
        source_slide = source_presentation.slides[0]
        # Get the master slide used by the first slide.
        source_master = source_slide.layout_slide.master_slide
        # Clone the master slide into the destination presentation's master collection.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clone the slide from the source presentation to the end of the destination presentation using the cloned master.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Save the destination presentation to disk.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone at the End in a Specified Section**

With Aspose.Slides for Python via .NET, you can clone a slide from one section of a presentation and insert it into another section within the same presentation. To do this, use the `add_clone(Slide, Section)` method of the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) class.

The following Python example shows how to clone a slide and insert the clone into a specified section:

```py
import aspose.slides as slides

# Create a new blank presentation.
with slides.Presentation() as presentation:
    # Add an empty slide based on the layout of the first slide.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Add an ellipse shape to the new slide; this slide will be cloned later.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Add another empty slide based on the layout of the first slide.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Create a section named "Section2" that starts at slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Clone the previously created slide into the "Section2" section.
    presentation.slides.add_clone(slide, section)
    # Save the presentation as a PPTX file.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Do speaker notes and reviewer comments get cloned?**

Yes. The notes page and review comments are included in the clone. If you don’t want them, [remove them](/slides/python-net/presentation-notes/) after insertion.

**How are charts and their data sources handled?**

The chart object, formatting, and embedded data are copied. If the chart was linked to an external source (e.g., an OLE-embedded workbook), that linkage is preserved as an [OLE object](/slides/python-net/manage-ole/). After moving between files, verify data availability and refresh behavior.

**Can I control the insertion position and sections for the clone?**

Yes. You can insert the clone at a specific slide index and place it into a chosen [section](/slides/python-net/slide-section/). If the target section doesn’t exist, create it first and then move the slide into it.
