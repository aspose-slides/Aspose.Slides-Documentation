---
title: Add Slides to Presentations with Python
linktitle: Add Slide
type: docs
weight: 10
url: /python-net/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Easily add slides to your PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET—seamless, efficient slide insertion in seconds."
---

## **Overview**

Before adding slides to a presentation, it helps to understand how PowerPoint organizes them. Each presentation contains a master slide, optional layout slides, and one or more normal slides. Every slide has a unique ID, and normal slides are ordered by a zero-based index. This article shows how to use Aspose.Slides for Python to create slides and choose appropriate layouts.

## **Add Slides to Presentations**

Aspose.Slides allows you to append new slides based on existing layout slides. The example below iterates through each layout in the presentation, adds a slide that uses that layout, and then saves the file.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Access the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. For each item in `presentation.layout_slides`, call `add_empty_slide` to append a slide that uses that layout.
1. Optionally modify the newly added slides.
1. Save the presentation as a PPTX file.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Yes. The library supports slide collections and [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) operations, so you can add a slide at the required index rather than only at the end.

**Are the theme/styles preserved when adding a slide based on a layout?**

Yes. A layout inherits formatting from its master, and the new slide inherits from the selected layout and its associated master.

**Which slide is present in a new "empty" presentation before adding slides?**

A newly created presentation already contains one blank slide with index zero. This is important to consider when calculating insertion indices.

**How do I choose the "right" layout for a new slide if the master has many options?**

Generally choose the [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) that matches the required structure ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). If such a layout is missing, you can [add it to the master](/slides/python-net/slide-layout/) and then use it.
