---
title: Change the Slide Size in Presentations with Python
linktitle: Slide Size
type: docs
weight: 70
url: /python-net/slide-size/
keywords:
- slide size
- aspect ratio
- standard
- widescreen
- 4:3
- 16:9
- set slide size
- change slide size
- custom slide size
- special slide size
- unique slide size
- full-size slide
- screen type
- do not scale
- ensure fit
- maximize
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
descriptions: "Learn how to quickly resize slides in PPT, PPTX and ODP files with Python and Aspose.Slides, optimize presentations for any screen without losing quality."
---

## **Introduction**

Aspose.Slides provides comprehensive tools to adjust the slide size and aspect ratio in PowerPoint presentations, critical for both printing and on-screen display. 

Popular Slide Sizes and Ratios:

- **Standard (4:3 Aspect Ratio)**: Ideal for older screens and devices.
- **Widescreen (16:9 Aspect Ratio)**: Recommended for modern projectors and displays.

Ensure consistency throughout your presentation as a single slide size and aspect ratio apply to all slides. For optimal results, set your slide dimensions at the beginning of your presentation creation process to avoid complications.

{{% alert color="primary" %}} 
By default, presentations created with Aspose.Slides use the standard 4:3 aspect ratio.
{{% /alert %}}

## **Change the Slide Size in a Presentation**

 This sample code shows you how to change the slide size in a presentation in Python using Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Specify Custom Slide Sizes**

If you find the common slide sizes (4:3 and 16:9) unsuitable for your work, you may decide to use a specific or unique slide size. For example, if you plan to print full-size slides from your presentation on a custom page layout or if you intend to display your presentation on certain screen types, you are likely to benefit from using a custom size setting for your presentation. 

This sample code shows you how to use Aspose.Slides for Python via .NET to specify a custom slide size for a presentation in Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 paper size
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Handle Slide Content After Resizing**

After you change the slide size for a presentation, the slides’ contents (images or objects, for example) may become distorted. By default, the objects get automatically resized to fit the new slide size. However, when changing a presentation's slide size, you can specify a setting that determines how Aspose.Slides deals with the contents on the slides.

Depending on what you intend to do or achieve, you can use any of these settings:

- `DO_NOT_SCALE`

  If you do NOT want the objects on the slides to be resized, use this setting.

- `ENSURE_FIT`

  If you want to scale to a smaller slide size and you need Aspose.Slides to scale down the slides’ objects to ensure they all fit on slides (this way, you avoid losing content), use this setting. 

- `MAXIMIZE`

  If you want to scale to a larger slide size and you need Aspose.Slides to enlarge the slides’ objects to make them proportional to the new slide size, use this setting. 

This sample code shows you how to use the `MAXIMIZE` setting when changing the size of a presentation’s slide:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

Yes. Aspose.Slides uses points internally, where 1 point equals 1/72 of an inch. You can convert any unit (such as millimeters or centimeters) to points and use the converted values to define slide width and height.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Yes. Larger slide dimensions (in points) combined with higher rendering scale lead to increased memory consumption and longer processing times. Aim for a practical slide size and adjust rendering scale only as needed to achieve the desired output quality.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

You can’t [merge presentations](/slides/python-net/merge-presentation/) while they have different slide sizes — first, resize one presentation to match the other. When changing the slide size, you can choose how existing content is handled via the [SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) option. After aligning sizes, you can merge slides while preserving formatting.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

Yes. Aspose.Slides can render thumbnails for [entire slides](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) as well as for [selected shapes](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/). The resulting images reflect the current slide size and aspect ratio, ensuring consistent framing and geometry.
