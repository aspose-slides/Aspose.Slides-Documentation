---
title: Get the Entire Presentation Slide Background as an Image
type: docs
weight: 95
url: /python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slide
- background
- slide background
- background to an image
- PowerPoint
- PPT
- PPTX
- PowerPoint presentation
- Python
- Aspose.Slides for Python
---

In PowerPoint presentations, the slide background can consist of many elements. In addition to the image set as the [slide background](/slides/python-net/presentation-background/), the final background can be influenced by the presentation theme, color scheme, and the shapes placed on the master slide and layout slide.

Aspose.Slides for Python does not provide a simple method to extract the entire presentation slide background as an image, but you can follow the steps below to do this:
1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide size from the presentation.
1. Select a slide.
1. Create a temporary presentation.
1. Set the same slide size in the temporary presentation.
1. Clone the selected slide into the temporary presentation.
1. Delete the shapes from the cloned slide.
1. Convert the cloned slide to an image.

The following code example extracts the entire presentation slide background as an image.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```
