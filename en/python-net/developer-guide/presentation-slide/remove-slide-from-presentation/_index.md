---
title: Remove Slides from Presentations in Python
linktitle: Remove Slide
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords:
- remove slide
- delete slide
- remove unused slide
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Effortlessly remove slides from PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Get clear code examples and boost your workflow."
---

## **Overview**

If a slide (or its contents) is no longer needed, you can delete it. Aspose.Slides provides the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, which encapsulates [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), the repository for all slides in a presentation. Using a reference or index to a known [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) object, you can remove the target slide.

## **Remove a Slide by Reference**

When you already have a reference to the target [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/), you can remove it directly. This avoids index lookups and keeps the code shorter and clearer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide you want to remove by its ID or index.
1. Remove the referenced slide from the presentation.
1. Save the modified presentation.

The following Python example removes a slide by reference:

```python
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Access a slide by its index in the slides collection.
    slide = presentation.slides[0]

    # Remove the slide by reference.
    presentation.slides.remove(slide)

    # Save the modified presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Slide by Index**

If you know the slide’s position in the deck, delete it by its index. This is especially handy in loops or bulk operations where positions are known ahead of time.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Remove the slide by its index.
1. Save the modified presentation.

This Python example shows how to remove a slide by index:

```python
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Remove the slide by its index.
    presentation.slides.remove_at(0)

    # Save the modified presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove an Unused Layout Slide**

Aspose.Slides provides the `remove_unused_layout_slides` method in the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class to delete unwanted, unused layout slides. The following Python example shows how to remove unused layout slides from a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove an Unused Master Slide**

Aspose.Slides provides the `remove_unused_master_slides` method in the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class to delete unwanted, unused master slides. The following Python example shows how to remove unused master slides from a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```
