---
title: Clone Presentation Slides in Python
linktitle: Clone Slides
type: docs
weight: 35
url: /python-java/clone-slides/
keywords:
- clone slide
- copy slide
- save slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Quickly duplicate PowerPoint slides with Aspose.Slides for Python via Java. Follow our clear code examples to automate PPT creation in seconds and eliminate manual work."
---

## **Introduction**

Cloning is the process of making an exact copy or replica of something. Aspose.Slides for Python via Java also makes it possible to make a copy or clone of any slide and then insert that cloned slide into the current presentation or any other open presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at the end within a presentation.
- Clone at another position within a presentation.
- Clone at the end in another presentation.
- Clone at another position in another presentation.
- Clone together with its master slide into another presentation.

In Aspose.Slides for Python via Java, the slide collection (a collection of [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) objects) exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object provides the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) and [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) methods to perform the above types of slide cloning.

## **Clone a Slide at the End of a Presentation**

If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method according to the steps listed below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object by referencing the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
1. Call the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object and pass the slide to be cloned as a parameter to the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate Presentation class that represents a presentation file
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Clone the desired slide to the end of the collection of slides in the same presentation
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Write the modified presentation to disk
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clone a Slide to Another Position within a Presentation**

If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) method:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a reference to the slide collection returned by [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) on the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
1. Call the [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object and pass the slide to be cloned along with the index for the new position as a parameter to the [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at index 1 – position 2 – of the presentation) to index 2 – position 3 – of the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate Presentation class that represents a presentation file
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Get the collection of slides in the presentation
    slides = presentation.getSlides()

    # Clone the desired slide to the specified index in the same presentation
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Write the modified presentation to disk
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clone a Slide at the End of Another Presentation**

If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class containing the destination presentation that the slide will be added to.
1. Get the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object by referencing the slide collection returned by [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) on the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object of the destination presentation.
1. Call the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object and pass the slide from the source presentation as a parameter to the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from index 0 of the source presentation) to the end of the destination presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate Presentation class to load the source presentation file
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    destination_presentation = Presentation()
    try:
        # Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Write the destination presentation to disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clone a Slide to Another Position in Another Presentation**

If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class containing the presentation the slide will be added to.
1. Get the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object by referencing the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object of the destination presentation.
1. Call the [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object and pass the slide from the source presentation along with the desired position as a parameter to the [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate Presentation class to load the source presentation file
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instantiate Presentation class for destination PPTX (where slide is to be cloned)
    destination_presentation = Presentation()
    try:
        # Clone the desired slide from the source presentation to the specified index in the destination presentation
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Write the destination presentation to disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clone a Slide with Its Master Slide to Another Presentation**

If you need to clone a slide with a master slide from one presentation and use it in another presentation, you need to clone the desired master slide from the source presentation to the destination presentation first. Then use the cloned master slide when cloning the slide. The [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method expects a master slide from the destination presentation rather than from the source presentation. In order to clone the slide with a master, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Get the [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/) object by referencing the Masters collection exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object of the destination presentation.
1. Call the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) method exposed by the [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/) object and pass the master from the source PPTX to be cloned as a parameter to the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) method.
1. Get the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object by referencing the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object of the destination presentation.
1. Call the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using the source slide's master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate Presentation class to load the source presentation file
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instantiate Presentation class for destination presentation (where slide is to be cloned)
    destination_presentation = Presentation()
    try:
        # Instantiate Slide from the collection of slides in source presentation along with
        # Master slide
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Clone the desired master slide from the source presentation to the collection of masters in the
        # Destination presentation
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Clone the desired slide from the source presentation with the desired master to the end of the
        # Collection of slides in the destination presentation
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Save the destination presentation to disk
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clone a Slide at the End of a Specified Section**

If you want to clone a slide and then use it within the same presentation file but in a different section, then use the [**addClone**](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) method exposed by the [**SlideCollection**](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) class. Aspose.Slides for Python via Java makes it possible to clone a slide from the first section and then insert that cloned slide into the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Save the destination presentation to disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ensure Matching Slide Size**

When cloning slides into another presentation, make sure the destination presentation has the same slide size as the source. If the slide sizes differ, Aspose.Slides does not automatically rescale the cloned shapes—their original coordinates and dimensions are preserved, which may cause the content to appear misaligned or extend beyond the slide boundaries.

You can set the destination presentation's slide size to match the source before cloning the master and slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Do this before cloning the master and the slide.

## **FAQ**

**Do speaker notes and reviewer comments get cloned?**

Yes. The notes page and review comments are included in the clone. If you don’t want them, [remove them](/slides/python-java/presentation-notes/) after insertion.

**How are charts and their data sources handled?**

The chart object, formatting, and embedded data are copied. If the chart was linked to an external source (e.g., an OLE-embedded workbook), that linkage is preserved as an [OLE object](/slides/python-java/manage-ole/). After moving between files, verify data availability and refresh behavior.

**Can I control the insertion position and sections for the clone?**

Yes. You can insert the clone at a specific slide index and place it into a chosen [section](/slides/python-java/slide-section/). If the target section doesn’t exist, create it first and then move the slide into it.
