---
title: Add Slides to Presentations in Python
linktitle: Add Slide
type: docs
weight: 10
url: /python-java/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Easily add slides to your PowerPoint and OpenDocument presentations using Aspose.Slides for Python via Java—seamless, efficient slide insertion in seconds."
---

## **Overview**

Aspose.Slides allows you to add slides to PowerPoint presentations programmatically. A presentation contains master/layout slides and normal slides, and normal slides are arranged by a zero-based index. Each slide has a unique ID, and presentation files without slides are not supported.

This article explains how to create a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object, access its slide collection, add an empty slide, work with the newly added slide, and save the updated presentation. It also covers related points such as inserting slides at a specific position, using layouts, and understanding the blank slide that exists in a newly created presentation.

## **Add a Slide to a Presentation**

Before discussing how to add slides to presentation files, let us review some facts about slides. Each PowerPoint presentation file contains **master/layout** slides and **normal** slides. A presentation file contains at least one slide. Presentation files without slides are not supported by Aspose.Slides for Python via Java. Each slide has a unique ID, and all normal slides are arranged in an order specified by a zero-based index.

Aspose.Slides for Python via Java allows developers to add empty slides to their presentations. To add an empty slide to a presentation, follow these steps:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object using the [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) method exposed by the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
- Add an empty slide to the end of the presentation's slide collection by calling the [addEmptySlide](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addEmptySlide) method exposed by the [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) object.
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantiate the Presentation class that represents the presentation file.
presentation = Presentation()
try:
    # Get the slide collection.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Add an empty slide to the slide collection.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Do some work on the newly added slide.

    # Save the PPTX file to disk.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Yes. The library supports slide collections and [insert](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertClone) operations, so you can add a slide at the required index rather than only at the end.

**Are the theme/styles preserved when adding a slide based on a layout?**

Yes. A layout inherits formatting from its master, and the new slide inherits from the selected layout and its associated master.

**Which slide is present in a new "empty" presentation before adding slides?**

A newly created presentation already contains one blank slide with index zero. This is important to consider when calculating insertion indices.

**How do I choose the "right" layout for a new slide if the master has many options?**

Generally, choose the [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) that matches the required structure ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/python-java/aspose.slides/slidelayouttype/)). If such a layout is missing, you can [add it to the master](/slides/python-java/slide-layout/) and then use it.
