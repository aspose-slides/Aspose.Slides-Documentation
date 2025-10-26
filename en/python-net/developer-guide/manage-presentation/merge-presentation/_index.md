---
title: Efficiently Merge Presentations with Python
linktitle: Merge Presentations
type: docs
weight: 40
url: /python-net/merge-presentation/
keywords:
- merge PowerPoint
- merge presentations
- merge slides
- merge PPT
- merge PPTX
- merge ODP
- combine PowerPoint
- combine presentations
- combine slides
- combine PPT
- combine PPTX
- combine ODP
- Python
- Aspose.Slides
description: "Effortlessly merge PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations with Aspose.Slides for Python via .NET, streamlining your workflow."
---

## **Optimize Your Presentation Merging**

With [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/), you can seamlessly combine PowerPoint presentations while preserving styles, layouts, and all elements. Unlike other tools, Aspose.Slides merges presentations without compromising quality or losing data. Merge entire decks, specific slides, or even different file formats (e.g., PPT to PPTX).

### **Merging Features**

- **Full Presentation Merge:** Assemble all slides into a single file.
- **Specific Slide Merge:** Choose and combine selected slides.
- **Cross-Format Merge:** Integrate presentations of varying formats, maintaining integrity.

## **Presentation Merging**

When you merge one presentation into another, you are effectively combining their slides into a single presentation to produce one file. Most presentation programs—such as PowerPoint or OpenOffice—do not provide features that let you merge presentations in this way.

However, [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) allows you to merge presentations in several ways. You can merge presentations with all their shapes, styles, text, formatting, comments, and animations, without any loss of quality or data.

**See also**

[Clone PowerPoint Slides in Python](/slides/python-net/clone-slides/)

### **What Can Be Merged**

With Aspose.Slides, you can merge:

- Entire presentations: all slides from the source decks are combined into a single presentation.
- Specific slides: only the selected slides are combined into a single presentation.
- Presentations of the same format (e.g., PPT→PPT, PPTX→PPTX) or across different formats (e.g., PPT→PPTX, PPTX→ODP).

{{% alert title="Note" color="info" %}}

Besides presentations, Aspose.Slides also allows you to merge other files:

- [Images](https://products.aspose.com/slides/python-net/merger/image-to-image/), such as [JPG to JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) or [PNG to PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- Documents, such as [PDF to PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) or [HTML to HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- Two different file types, such as [image to PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/), or [TIFF to PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merging Options**

You can control whether:
- Each slide in the output presentation retains its original style, or
- A single style is applied to all slides in the output presentation.

To merge presentations, Aspose.Slides provides the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) methods on the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) class. These method overloads define how the merge is performed. Every [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object exposes a [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection, so you call `add_clone` on the destination presentation’s slide collection.

The `add_clone` method returns an `Slide`—a clone of the source slide. Slides in the output presentation are copies of the originals, so you can modify the resulting slides (for example, apply styles, formatting, or layouts) without affecting the source presentations.

## **Merge Presentations** 

Aspose.Slides provides the [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) method, which allows you to combine slides while preserving their layouts and styles (using default parameters).

The following Python example shows how to merge presentations:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Presentations with a Slide Master**

Aspose.Slides provides the [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) method, which allows you to merge slides while applying a slide master from a template. This way, when needed, you can restyle the slides in the output presentation.

The following Python example demonstrates this operation:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}}

The appropriate layout under the specified slide master is determined automatically. If no suitable layout can be found and the `allow_clone_missing_layout` boolean parameter of the `add_clone` method is set to `True`, the source slide’s layout is used instead. Otherwise, a [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) is thrown.

{{% /alert %}}

To apply a different slide layout to slides in the output presentation, use the [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) method when merging.

## **Merge Specific Slides From Presentations**

Merging specific slides from multiple presentations is useful when creating custom slide decks. Aspose.Slides lets you select and import only the slides you need, while preserving the original slides’ formatting, layout, and design.

The following Python example creates a new presentation, adds title slides from two other presentations, and saves the result to a file:

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

## **Merge Presentations with a Slide Layout**

The following Python example shows how to merge slides from multiple presentations while applying a specific slide layout to produce a single output presentation:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}}

You cannot directly merge presentations that have different slide sizes.

{{% /alert %}}

To merge two presentations with different slide sizes, first resize one presentation so its slide size matches the other’s.

The following sample code demonstrates this process:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Merge Slides into a Presentation Section**

The following Python example shows how to merge a specific slide into a section of a presentation:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

The slide is added at the end of the section. 

{{% alert title="Tip" color="primary" %}}

Looking for a quick and **free online tool** to **merge PowerPoint presentations**? Try the [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **Merge PowerPoint files easily**: Combine multiple **PPT, PPTX, ODP** presentations into a single file.  
- **Supports different formats**: Merge **PPT to PPTX**, **PPTX to ODP**, and more.  
- **No installation required**: Works directly in your browser, fast and secure.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Start merging your PowerPoint files with **Aspose free online tool** today!  

{{% /alert %}}

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}

## **FAQ**

**Are speaker notes preserved during merge?**

Yes. When cloning slides, Aspose.Slides carries over all slide elements, including notes, formatting, and animations.

**Are comments and their authors transferred?**

Comments, as part of slide content, are copied with the slide. Comment author labels are preserved as comment objects in the resulting presentation.

**What if the source presentation is password-protected?**

It must be [opened with the password](/slides/python-net/password-protected-presentation/) via [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); after loading, those slides can be safely cloned into an unprotected target file (or a protected one as well).

**How thread-safe is the merge operation?**

Do not use the same [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance from [multiple threads](/slides/python-net/multithreading/). The recommended rule is "one document — one thread"; different files can be processed in parallel in separate threads.
