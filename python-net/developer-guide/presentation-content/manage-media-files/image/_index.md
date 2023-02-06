---
title: Image
type: docs
weight: 10
url: /python-net/image/
keywords: "Add image, Add picture, PowerPoint presentation, EMF, SVG, Python, Aspose.Slides for Python via .NET"
description: "Add image to PowerPoint slide or presentation in Python"
---

## **Images in Slides In Presentations**

Images make presentations more engaging and interesting. In Microsoft PowerPoint, you can insert pictures from a file, the internet, or other locations onto slides. Similarly, Aspose.Slides allows you to add images to slides in your presentations through different procedures.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

If you want to add an image as a frame object—especially if you plan to use standard formatting options on it to change its size, add effects, and so on—see [Picture Frame](https://docs.aspose.com/slides/python-net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

You can manipulate input/output operations involving images and PowerPoint presentations to convert an image from one format to another. See these pages: convert [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supports operations with images in these popular formats: JPEG, PNG, BMP, GIF, and others. 

## **Adding Images Stored Locally to Slides**

You can add one or several images on your computer onto a slide in a presentation. This sample code in Python shows you how to add an image to a slide:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Adding Images From the Web to Slides**

If the image you want to add to a slide is unavailable on your computer, you can add the image directly from the web. 

This sample code shows you how to add an image from the web to a slide in Python:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Adding Images to Slide Masters**

A slide master is the top slide that stores and controls information (theme, layout, etc.) about all slides under it. So, when you add an image to a slide master, that image appears on every slide under that slide master. 

This Python sample code shows you how to add an image to a slide master:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Adding Images as Slide Background**

You may decide to use a picture as the background for a specific slide or several slides. In that case, you have to see *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Adding SVG to Presentations**
You can add or insert any image into a presentation by using the [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method that belongs to the [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) interface.

To create an image object based on SVG image, you can do it this way:

1. Create SvgImage object to insert it to ImageShapeCollection
2. Create PPImage object from ISvgImage
3. Create PictureFrame object using IPPImage interface

This sample code shows you how to implement the steps above to add an SVG image into a presentation:
```py 
import aspose.slides as slides

# Create new presentation
with slides.Presentation() as p:
    # Read SVG file content
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Create SvgImage object
        svgImage = slides.SvgImage(svgContent)

        # Create PPImage object
        ppImage = p.images.add_image(svgImage)

        # Creates a new PictureFrame 
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # Save presentation in PPTX format
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Converting SVG to a Set of Shapes**
Aspose.Slides' conversion of SVG to a set of shapes is similar to the PowerPoint functionality used to work with SVG images:


![PowerPoint Popup Menu](img_01_01.png)

The functionality is provided by one of the overloads of the [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/) method of the [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) interface that takes an [ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/) object as the first argument.

This sample code shows you how to use the described method to convert an SVG file to a set of shapes:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Read SVG file content
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Create SvgImage object
        svgImage = slides.SvgImage(svgContent)

        # Get slide size
        slide_size = presentation.slide_size.size

        # Convert SVG image to group of shapes scaling it to slide size
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # Save presentation in PPTX format
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Adding Images as EMF in Slides**
Aspose.Slides for Python via .NET allows you to add the EMF image. 

This sample code shows you how to perform the described task:

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Using Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter, you can easily animate texts, create GIFs from texts, etc. 

{{% /alert %}}