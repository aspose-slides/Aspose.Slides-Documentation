---
title: Remove Slide from Presentation
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords: "Remove slide, Delete slide, PowerPoint, Presentation, Python, Aspose.Slides"
description: "Remove slide from PowerPoint by reference or index in Python"

---

If a slide (or its contents) becomes redundant, you can delete it. Aspose.Slides provides the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class that encapsulates [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), which is a repository for all slides in a presentation. Using pointers (reference or index) for a known [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) object, you can specify the slide you want to remove. 

## **Remove Slide by Reference**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference of the slide you want to remove through its ID or Index.
1. Remove the referenced slide from the presentation.
1. Save the modified presentation. 

This Python code shows you how to remove a slide through its reference:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # Accesses a slide through its index in the slides collection
    slide = pres.slides[0]

    # Removes a slide through its reference
    pres.slides.remove(slide)

    # Saves the modified presentation
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Remove Slide by Index**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Remove the slide from the presentation through its index position.
1. Save the modified presentation. 

This Python code shows you how to remove a slide through its index:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # Removes a slide through its slide index
    pres.slides.remove_at(0)

    # Saves the modified presentation
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the `remove_unused_layout_slides(pres)` method (from the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused layout slides. This Python code shows you how to remove a layout slide from a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Unused Master Slide**

Aspose.Slides provides the `remove_unused_master_slides(pres)` method (from the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class) to allow you to delete unwanted and unused master slides. This Python code shows you how to remove a master slide from a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

