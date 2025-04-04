---
title: Merge Presentation
type: docs
weight: 40
url: /python-net/merge-presentation/
keywords: "Merge PowerPoint, PPTX, PPT, combine PowerPoint, merge presentation, combine presentation, Python"
description: "Merge or combine PowerPoint Presentation in Python"
---

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free online** [Merger app](https://products.aspose.app/slides/merger). It allows people to merge PowerPoint presentations in the same format (PPT to PPT, PPTX to PPTX, etc.) and merge presentations in different formats (PPT to PPTX, PPTX to ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

When you merge one presentation to another, you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) , however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data. 

**See also**

[Clone Slides](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **What Can Be Merged**

With Aspose.Slides, you can merge 

* entire presentations. All the slides from the presentations end up in one presentation
* specific slides. Selected slides end up in one presentation
* presentations in one format (PPT to PPT, PPTX to PPTX, etc) and in different formats (PPT to PPTX, PPTX to ODP, etc) to one another. 

{{% alert title="Note" color="warning" %}} 

Besides presentations, Aspose.Slides allows you to merge other files:

* [Images](https://products.aspose.com/slides/python-net/merger/image-to-image/), such as [JPG to JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) or [PNG to PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* Documents, such as [PDF to PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) or [HTML to HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* And two different files such as [image to PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) or [JPG to PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) or [TIFF to PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merging Options**

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) methods (from the [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) interface). There are several implementations of the `add_clone` methods that define the presentation merging process parameters. Every Presentation object has a [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) collection, so you can call a `add_clone` method from the presentation to which you want to merge slides. 

The `add_clone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Merge Presentations** 

Aspose.Slides provides the [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method that allows you to combine slides while the slides retain their layouts and styles (default parameters). 

This Python code shows you how to merge presentations:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Presentations with Slide Master**

Aspose.Slides provides the [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation. 

This code in Python demonstrates the described operation:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}} 

The slide layout for the slide master is determined automatically. When an appropriate layout can't be determined, if the `allowCloneMissingLayout` boolean parameter of the `add_clone` method is set to true, the layout for the source slide is used. Otherwise, [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) will be thrown. 

{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) method instead when merging. 

## **Merge Specific Slides From Presentations**

Merging specific slides from multiple presentations is useful for creating custom slide decks. Aspose.Slides for Python via .NET allows you to select and import only the slides you need. The API preserves formatting, layout, and design of the original slides.

The following Python code creates a new presentation, adds title slides from two other presentations, and saves the result to a file:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Presentations With Slide Layout**

This Python code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Merge Presentations With Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

You cannot merge presentations with different slide sizes. 

{{% /alert %}}

To merge 2 presentations with different slide sizes, you have to resize one of the presentations to make its size match that of the other presentation. 

This sample code demonstrates the described operation:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Merge Slides to Presentation Section**

This Python code shows you how to merge a specific slide to a section in a presentation:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

The slide is added at the end of the section. 

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}