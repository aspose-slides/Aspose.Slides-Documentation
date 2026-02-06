---
title: Picture
type: docs
weight: 50
url: /python-net/examples/elements/picture/
keywords:
- picture
- picture frame
- add picture
- access picture
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with pictures in Python using Aspose.Slides: insert, replace, crop, compress, adjust transparency and effects, fill shapes, and export for PPT, PPTX and ODP."
---

Shows how to insert and access pictures from in-memory images using **Aspose.Slides for Python via .NET**. The examples below create an image in memory, place it on a slide, and then retrieve it.

## **Add a Picture**

This code loads an image from a file and inserts it as a picture frame on the first slide.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Load an image from a file.
        with open("image.png", "rb") as image_stream:
            # Add the image to the presentation resources.
            image = presentation.images.add_image(image_stream)

        # Insert a picture frame showing the image on the first slide.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first picture frame on the slide.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```
