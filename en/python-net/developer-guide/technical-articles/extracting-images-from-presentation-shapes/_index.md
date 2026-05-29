---
title: Extract Images from Presentation Shapes in Python
linktitle: Image from Shape
type: docs
weight: 90
url: /python-net/extracting-images-from-presentation-shapes/
keywords:
- extract image
- retrieve image
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Extract images from shapes in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET - quick, code-friendly solution."
---

## **Overview**

Images in a presentation can appear in several shape types: as ordinary picture frames, as picture fills applied to shapes, as OLE object preview images, as video or audio frame thumbnails, as zoom images, or as images nested inside table, chart, and SmartArt shapes. Aspose.Slides stores those images in the presentation image collection, exposed through [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) and [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) objects.

If you only need to export every image resource embedded in a presentation, iterate through `presentation.images`. This article focuses on a different task: traversing shapes to find where images are used on slides, so the saved files can keep useful context such as the slide number, shape position, and source type (picture frame, fill image, media preview, OLE preview, or zoom image).

{{% alert title="Tip" color="primary" %}}

Use the `binary_data` property of [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) to preserve the original encoded image data and file type. Use the `image` property with `save` when you want to normalize the output to a specific format such as PNG.

{{% /alert %}}

## **Shared Helper Methods**

The helper methods below keep the examples short. `save_original_image` writes the original embedded bytes, chooses a safe extension from the MIME type, and skips duplicate image binaries by SHA-256 hash.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Extract Images from Picture Frames**

Use this approach for pictures inserted as standalone objects. A [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) stores its picture in `picture_format.picture.image`, which returns a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Extract Images from Picture-Filled Shapes**

Shapes can use a picture as their fill. Check the shape's fill type first: if it is not [FillType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), there is no picture to extract from that fill. The example below handles [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) objects and saves each image as PNG through the `image` property of [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Extract Preview Images from OLE Object Frames**

An [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) can have a substitute picture that PowerPoint uses as the object's preview on a slide. This image is available through `substitute_picture_format.picture.image`. Extracting this picture gives you the preview image, not the embedded OLE package contents.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extract Preview Images from Video Frames**

A [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) can also store a preview image in `picture_format.picture.image`. This is the poster or thumbnail shown on the slide, not a frame decoded from the video stream.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extract Preview Images from Audio Frames**

An [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) can store a thumbnail in `picture_format.picture.image`. This is the image shown for the audio object on the slide.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extract Images from Zoom Objects**

[ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) and [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) shapes can use custom images. Read `zoom_image` from the zoom frame.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Extract Images from Summary Zoom Frames**

A [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/) is also a shape. Its section items can use custom images, exposed through each summary zoom section's `zoom_image` property.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Extract Images from Table Shapes**

A [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) is a shape. Images in a table are usually stored as picture fills in table cells.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extract Images from Chart Shapes**

A [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) is a shape. The example below extracts an image from the chart area's picture fill.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extract Images from SmartArt Shapes**

A [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) object is a shape. Depending on the SmartArt layout, images may be stored in node bullet fills or in the fill formats of node shapes.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Include Images Inside Grouped Shapes**

Grouped shapes contain their own shape collections. The shared `enumerate_shapes` helper has an `include_grouped_shapes` option. Set it to `True` when you want to inspect shapes inside [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) objects. The example below extracts images from picture frames, picture-filled shapes, OLE object previews, video frame thumbnails, and audio frame thumbnails. To include table, chart, SmartArt, and summary zoom images as well, reuse the specialized extraction logic from the previous sections while keeping the same recursive shape traversal.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Edge Cases and Practical Notes**

- **Duplicate images:** Multiple shapes may reference the same image or separate images with identical bytes. Hash the `binary_data` property of [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) before writing files if you want one output file per unique image.
- **Original data vs. converted output:** Saving the `binary_data` property of [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) preserves the embedded JPEG, PNG, GIF, SVG, EMF, or WMF data. Saving the `image` property through `save` is useful when you want a consistent output format.
- **Unsupported fill types:** Solid, gradient, pattern, and no-fill shapes do not contain a picture fill. Check [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) before reading `picture_fill_format`.
- **Grouped shapes:** The top-level slide shape collection does not flatten groups. Recursively inspect [GroupShape.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) when grouped content matters.
- **OLE object previews:** An [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) may expose a preview image through `substitute_picture_format`, but that image is only the slide preview. It is not the embedded file inside the OLE object.
- **Video frame thumbnails:** A [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) may expose a preview image through `picture_format`, but that image is only the poster shown on the slide. It is not extracted from the video stream.
- **Audio frame thumbnails:** An [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) may expose an icon or thumbnail through `picture_format`; it is not the embedded audio data.
- **Zoom images:** Slide zoom, section zoom, and summary zoom shapes may use custom [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) objects through `image`.
- **Nested shape models:** Table, chart, and SmartArt objects implement [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), but their images are often stored in nested table cell, chart element, or SmartArt node formatting objects.
- **Cropped or transformed pictures:** Accessing [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) gives you the stored image resource. It does not render cropping, transparency, recoloring, rotation, or other visual effects applied by the shape.

## **FAQ**

**Can I extract the original image without cropping, effects, or shape transformations?**

Yes. Access the [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object and write its `binary_data` property to disk. This preserves the original encoded image stored in the presentation, not the way the image is rendered on the slide.

**Can I export every extracted image as PNG?**

Yes. Use the `image` property of [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) to get an image object, and then call `save` with [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/). This converts the output and may not preserve the original file type or vector data.

**How do I avoid saving the same image more than once?**

Use a hash of the `binary_data` property of [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) and keep the hashes in a set. If a new image has a hash that already exists, skip it or record another reference to the existing output file.

**Why do some shapes not produce an image?**

Picture frames, picture-filled shapes, OLE object frames, media frames, zoom frames, tables, charts, and SmartArt objects can reference images. Some shape types expose images through nested formatting objects, so a simple `picture_format` or shape `fill_format` check is not always enough.

**Can I extract the thumbnail shown for a video frame?**

Yes. Use [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) and read `picture_format.picture.image`. This extracts the poster image stored with the video frame, not a frame generated from the video file.

**How can I determine which shapes use a specific image from the presentation image collection?**

Aspose.Slides does not store reverse links from [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) to shapes. Build a mapping during traversal: whenever you find an image reference, record the slide number, shape path, and image hash or collection item.

**Can I extract images embedded inside OLE objects, such as attached documents?**

You can extract the OLE object's slide preview from the `substitute_picture_format` property of [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). However, that preview is not the embedded document itself. To extract images from inside the embedded file, extract the OLE data and inspect it with tools for that file type.
