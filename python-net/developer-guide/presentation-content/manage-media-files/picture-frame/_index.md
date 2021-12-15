---
title: Picture Frame
type: docs
weight: 10
url: /python-net/picture-frame/
keywords: "Add picture frame, create picture frame, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add picture frame to PowerPoint presentation in Python"
---


## **Create Picture Frame**
Picture frame is also one of the shapes offered by Aspose.Slides for Python via .NET. Adding picture frame to a slide is bit trickier than simple shapes. 

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.
This article explains how picture frames can be used in different ways:

- Adding Simple Picture Frames to Slides.
- Controlling Picture Frame Formatting.
- Adding Picture Frame with Relative Scale.

To add a simple picture frame to your slide, please follow the steps below:

- Create an instance of [Presentation ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)class. 
- Obtain the reference of a slide by using its index.
- Create an Image object by adding an image to the Images collection associated with the Presentation object that will be used to fill the Shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the AddPictureFrame method exposed by the Shapes object associated with the referenced slide.
- Add a picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Instantiate the ImageEx class
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # Add Picture Frame with height and width equivalent of Picture
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # Apply some formatting to PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # Write the PPTX file to disk
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Create Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

- Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
- Obtain the reference of a slide by using its index.
- Add an image to the presentation image collection.
- Create an [IPPImage](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ippimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Set the relative width and height of the image in the picture frame.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides

# Instantiate presentation object
with slides.Presentation() as presentation:
    # Load Image to be added in presentaiton image collection
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # Add picture frame to slide
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Setting relative scale width and height
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # Save presentation
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/) class.
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Calculate the width and height of image.
- Create a PictureFrame according to the width and height of the image by using the [AddPictureFrame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishapecollection/methods/addpictureframe) method exposed by the [IShapes](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishapecollection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Add Picture Frame with height and width equivalent of Picture
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # Apply some formatting to PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # Write the PPTX file to disk
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Add StretchOff Property**
The Properties StretchOffsetLeft, StretchOffsetTop, StretchOffsetRight and StretchOffsetBottom has been added to IPictureFillFormat interface and PictureFillFormat class respectively. These properties specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/) class.
- Obtain the reference of a slide by using its index.
- Add an AutoShape of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:

    # Get the first slide
    slide = pres.slides[0]

    # Instantiate the ImageEx class
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Add Picture Frame with height and width equivalent of Picture
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # Set shape's fill type
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Set shape's picture fill mode
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # Set image to fill the shape
        shape.fill_format.picture_fill_format.picture.image = imgx

        # Specify image offsets from the corresponding edge of the shape's bounding box
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # Write the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```

