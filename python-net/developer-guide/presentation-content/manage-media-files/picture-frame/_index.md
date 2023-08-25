---
title: Picture Frame
type: docs
weight: 10
url: /python-net/picture-frame/
keywords: "Add picture frame, create picture frame, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add picture frame to PowerPoint presentation in Python"
---

A picture frame is a shape that contains an image—it is like a picture in a frame. 

You can add an image to a slide through a picture frame. This way, you get to format the image by formatting the picture frame.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

## **Create Picture Frame**

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class. 
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) based on the image's width and height through the `AddPictureFrame` method exposed by the shape object associated with the referenced slide.
6. Add a picture frame (containing the picture) to the slide.
7. Write the modified presentation as a PPTX file.

This Python code shows you how to create a picture frame:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates the Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Instantiates the ImageEx class
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # Adds a frame with the picture's equivalent height and width
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # Applies some formatting to the PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # Writes the PPTX file to disk
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

Picture frames allow you to quickly create presentation slides based on images. When you combine picture frame with the save options Aspose.Slides, you can manipulate input/output operations to convert images from one format to another. You may want to see these pages: convert [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Create Picture Frame with Relative Scale**

By altering an image's relative scaling, you can create a more complicated picture frame. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an image to the presentation image collection.
4. Create an [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) associated with the presentation object that will be used to fill the shape.
5. Specify the image's relative width and height in the picture frame.
6. Write the modified presentation as a PPTX file.

This Python code shows you how to create a picture frame with relative scale:

```py
import aspose.slides as slides

# Instantiates the Presentation class that represents a PPTX file
with slides.Presentation() as presentation:
    # Loads the Image that will be added to the presentaiton image collection
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # Adds a picture frame to the slide
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Sets the relative scale width and height
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # Saves the presentation
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Transparency of Image**

Aspose.Slides allows you to get the transparency of an image. This Python code demonstrates the operation: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("Picture transparency: " + str(transparencyValue))
```

## **Picture Frame Formatting**

Aspose.Slides provides many formatting options that can be applied to a picture frame. Using those options, you can alter a picture frame to make it match specific requirements.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a `PictureFrame` based on the image's width and height through the [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) method exposed by the [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) object associated with the referenced slide.
6. Add the picture frame (containing the picture) to the slide.
7. Set the picture frame's line color.
8. Set the picture frame's line width.
9. Rotate the picture frame by giving it either a positive or negative value.
   * A positive value rotates the image clockwise. 
   * A negative value rotates the image anti-clockwise.
10. Add the picture frame (containing the picture) to the slide.
11. Write the modified presentation as a PPTX file.

This Python code demonstrates the picture frame formatting process:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # Adds a picture frame with the picture's equivalent height and width
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # Applies some formatting to PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # Writes the PPTX file to disk
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Add Image as Link**

To avoid large presentation sizes, you can add images (or videos) through links instead of embedding the files directly into presentations. This Python code shows you how to add an image and video into a placeholder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Crop Image**

This Python code shows you how to crop an existing image on a slide:

``` py
import aspose.slides as slides
import aspose.pydrawing as drawing


with slides.Presentation() as presentation:
    # Creates new image object
    newImage = presentation.images.add_image(drawing.Image.from_file(imagePath))

    # Adds a PictureFrame to a Slide
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # Crops the image (percentage values)
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # Saves the result
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## **Lock Aspect Ratio**

If you want a shape containing an image to retain its aspect ratio even after you change the image dimensions, you can use the *aspect_ratio_locked* property to set the *Lock Aspect Ratio* setting. 

This Python code shows you how to lock a shape's aspect ratio: 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # set shape to have to preserve aspect ratio on resizing
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **Use StretchOff Property**

Using the `StretchOffsetLeft`, `StretchOffsetTop`, `StretchOffsetRight` and `StretchOffsetBottom` properties from the [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) interface and [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) class, you can specify a fill rectangle. 

When stretching is specified for an image, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset while a negative percentage specifies an outset.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) class.
2. Get a slide's reference through its index.
3. Add a rectangle `AutoShape`. 
4. Create an image.
5. Set the shape's fill type.
6. Set the shape's picture fill mode.
7. Add a set image to fill the shape.
8. Specify image offsets from the corresponding edge of the shape's bounding box
9. Write the modified presentation as a PPTX file.

This Python code demonstrates a process in which a StretchOff property is used:

```py
import aspose.slides as slides

# Instantiates the Prseetation class that represents a PPTX file
with slides.Presentation() as pres:

    # Gets the first slide
    slide = pres.slides[0]

    # Instantiates the ImageEx class
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Adds a picture frame with the picture's equivalent height and width
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # Sets the shape's fill type
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Sets the shape's picture fill mode
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # Sets the image to fill the shape
        shape.fill_format.picture_fill_format.picture.image = imgx

        # Specifies image offsets from the corresponding edge of the shape's bounding box
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # Writes the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```

