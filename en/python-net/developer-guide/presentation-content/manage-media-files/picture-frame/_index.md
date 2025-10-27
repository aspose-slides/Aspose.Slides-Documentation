---
title: Add Picture Frames to Presentations with Python
linktitle: Picture Frame
type: docs
weight: 10
url: /python-net/picture-frame/
keywords:
- picture frame
- add picture frame
- create picture frame
- add image
- create image
- extract image
- raster image
- vector image
- crop image
- cropped area
- StretchOff property
- picture frame formatting
- picture frame properties
- ralative scale
- image effect
- aspect ratio
- image transparency
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Add picture frames to PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Streamline your workflow and enhance slide designs."
---

## **Overview**

Picture frames in Aspose.Slides for Python let you place and manage raster and vector images as native slide shapes. You can insert pictures from files or streams, position and resize them with precise coordinates, apply rotation, set transparency, and control z-order alongside other shapes. The API also supports cropping, maintaining aspect ratios, setting borders and effects, and replacing the underlying image without rebuilding the layout. Because picture frames behave like regular shapes, you can add animations, hyperlinks, and alt text, making it straightforward to build visually rich, accessible presentations.

## **Create Picture Frames**

This section shows how to insert an image into a slide by creating a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) with Aspose.Slides for Python. You’ll learn how to load the image, place it precisely on the slide, and control its size and formatting.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide by its index.
3. Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) by adding the image to the presentation’s [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/). This image will be used to fill the shape.
4. Specify the frame’s width and height.
5. Create a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) of that size using the [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) method.
6. Save the presentation as a PPTX file.

The following Python code shows how to create a picture frame:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Picture frames allow you to quickly create presentation slides from images. When you combine picture frames with Aspose.Slides save options, you can control I/O operations to convert images from one format to another. You may want to see these pages: convert [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); convert [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); convert [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Create Picture Frames with Relative Scale**

This section demonstrates placing an image at a fixed size, then applying percentage-based scaling independently to its width and height. Because the percentages may differ, the aspect ratio can change. Scaling is performed relative to the image’s original dimensions.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide by its index.
3. Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) by adding the image to the presentation’s [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
4. Add a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) to the slide.
5. Set the picture frame’s relative width and height.
6. Save the presentation as a PPTX file.

The following Python code shows how to create a picture frame with relative scaling:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Raster Images from Picture Frames**

You can extract raster images from [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) objects and save them in PNG, JPG, and other formats. The code example below demonstrates how to extract an image from the document "sample.pptx" and save it in PNG format.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extract SVG Images from Picture Frames**

When a presentation contains SVG graphics placed inside [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) shapes, Aspose.Slides for Python via .NET lets you retrieve the original vector images with full fidelity. By traversing the slide’s shape collection, you can identify each [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), check whether the underlying [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) holds SVG content, and then save that image to disk or a stream in its native SVG format.

The following code example demonstrates how to extract an SVG image from a picture frame:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Get Image Transparency**

Aspose.Slides lets you retrieve the transparency effect applied to an image. This Python code demonstrates the operation:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
All effects applied to images can be found in [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Picture Frame Formatting**

Aspose.Slides provides many formatting options you can apply to a picture frame. With these options, you can adjust a picture frame to meet specific requirements.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide by its index.
3. Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) by adding the image to the presentation’s [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/). This image will be used to fill the shape.
4. Specify the frame’s width and height.
5. Create a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) of that size using the slide’s [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) method.
6. Set the picture frame’s line color.
7. Set the picture frame’s line width.
8. Rotate the picture frame by supplying a positive (clockwise) or negative (counterclockwise) value.
9. Save the modified presentation as a PPTX file.

The following Python code demonstrates the picture frame formatting process:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose has developed a free [Collage Maker](https://products.aspose.app/slides/collage). If you need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, or [create photo grids](https://products.aspose.app/slides/collage/photo-grid), you can use this service.

{{% /alert %}}

## **Add Images as Links**

To keep presentation files small, you can add images or videos via links instead of embedding the files directly in the presentations. The following Python code shows how to insert an image and a video into a placeholder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Crop Images**

In this section, you'll learn how to crop the visible area of an image within a picture frame without altering the source file. You'll also learn the basic method for applying cropping margins to create a clean, focused composition directly on the slide.

The following Python code shows how to crop an image on a slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Delete Cropped Areas of Images**

If you want to delete the cropped areas of an image in a frame, use the [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) method. This method returns the cropped image, or the original image if no cropping is needed.

The following Python code demonstrates the operation:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

The [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) method adds the cropped image to the presentation’s image collection. If the image is used only in the processed [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), this can reduce the presentation size; otherwise, the number of images in the resulting presentation may increase.

During cropping, this method converts WMF/EMF metafiles to a raster PNG image.

{{% /alert %}}

## **Lock the Aspect Ratio**

If you want a shape that contains an image to retain its aspect ratio after you change the image’s dimensions, set the [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) property to `True`.

The following Python code shows how to lock a shape’s aspect ratio:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

This *Lock Aspect Ratio* setting preserves only the shape’s aspect ratio, not the aspect ratio of the image inside it.

{{% /alert %}}

## **Use Stretch Offset Properties**

Using the `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, and `stretch_offset_bottom` properties of the [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) class, you can define a fill rectangle.

When stretching is specified for an image, the source rectangle is scaled to fit the fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape’s bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add a rectangular [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
4. Set the shape’s fill type.
5. Set the shape’s picture fill mode.
6. Load an image.
7. Assign the image to fill the shape.
8. Specify image offsets from the corresponding edges of the shape’s bounding box.
9. Save the presentation as a PPTX file.

The following Python code demonstrates how to use the Stretch Offset properties:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that let you quickly create presentations from images.

{{% /alert %}}

## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**

Aspose.Slides supports both raster images (PNG, JPEG, BMP, GIF, etc.) and vector images (for example, SVG) via the image object that is assigned to a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). The list of supported formats generally overlaps with the capabilities of the slide and image conversion engine.

**How will adding dozens of large images affect PPTX size and performance?**

Embedding large images increases file size and memory usage; linking images helps keep the presentation size down but requires the external files to remain accessible. Aspose.Slides provides the ability to add images by link to reduce file size.

**How can I lock an image object from accidental moving/resizing?**

Use [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) for a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (for example, disable moving or resizing). The locking mechanism is described for shapes in a separate [protection article](/slides/python-net/applying-protection-to-presentation/) and is supported for various shape types, including [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**

Aspose.Slides allows extracting an SVG from a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) as the original vector. When [exporting to PDF](/slides/python-net/convert-powerpoint-to-pdf/) or [raster formats](/slides/python-net/convert-powerpoint-to-png/), the result may be rasterized depending on the export settings; the fact that the original SVG is stored as a vector is confirmed by the extraction behavior.
