---
title: Presentation Viewer
type: docs
weight: 50
url: /python-net/presentation-viewer/
keywords: "View PowerPoint presentation, view ppt, view PPTX, Python, Aspose.Slides for Python via .NET"
description: "View PowerPoint presentation in Python "
---



Aspose.Slides for Python via .NET is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as images in their favorite image viewer or create their own presentation viewer. In such cases, Aspose.Slides for Python via .NET lets you export an individual slide to an image. This article describes how to do it. 
## **Live Example**
You can try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) free app to see what you can implement with Aspose.Slides API:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Generate SVG Image from Slide**
To generate an SVG image from any desired slide with Aspose.Slides for Python, please follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.

```py
import aspose.slides as slides

# Instantiate a Presentation class that represents the presentation file
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # Create a memory stream object
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # Generate SVG image of slide and save in memory stream
        sld.write_as_svg(svg_stream)
```


## **Generate SVG with Custom Shape IDS**
Aspose.Slides for Python via .NET can be used to generate [SVG ](https://docs.fileformat.com/page-description-language/svg/)from slide with custom shape ID. For that, use ID property from [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/), which represents custom ID of shapes in generated SVG. CustomSvgShapeFormattingController can be used to set shape ID.

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **Create Slides Thumbnail Image**
Aspose.Slides for Python via .NET help you generate thumbnail images of the slides. To generate the thumbnail of any desired slide using Aspose.Slides for Python via .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```py
import aspose.slides as slides

# Instantiate a Presentation class that represents the presentation file
with slides.Presentation("pres.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # Create a full scale image
    bmp = sld.get_image(1, 1)

    # save the image to disk in JPEG format
    bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **Create Thumbnail with User Defined Dimensions**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```py
import aspose.slides as slides

# Instantiate a Presentation class that represents the presentation file
with slides.Presentation("pres.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # User defined dimension
    desiredX = 1200
    desiredY = 800

    # Getting scaled value  of X and Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # Create a full scale image
    bmp = sld.get_image(ScaleX, ScaleY)

    # save the image to disk in JPEG format
    bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **Create Thumbnail from Slide in Notes Slides View**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for Python via .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

The code snippet below produces a thumbnail of the first slide of a presentation in Notes Slide View.

```py
import aspose.slides as slides

# Instantiate a Presentation class that represents the presentation file
with slides.Presentation("pres.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # User defined dimension
    desiredX = 1200
    desiredY = 800

    # Getting scaled value  of X and Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # Create a full scale image                
    bmp = sld.get_image(ScaleX, ScaleY)
    # save the image to disk in JPEG format
    bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```

