---
title: Manage Picture Frames in Presentations Using PHP
linktitle: Picture Frame
type: docs
weight: 10
url: /php-java/picture-frame/
keywords:
- picture frame
- add picture frame
- create picture frame
- embedded image
- linked image
- extract image
- raster image
- SVG image
- crop image
- delete cropped areas
- compress image
- StretchOffset
- picture frame formatting
- relative scale
- image effect
- aspect ratio
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Create, format, link, crop, extract, and compress picture frames in presentations with Aspose.Slides for PHP via Java."
---

## **Overview**

A picture frame is a slide shape that displays an image. In Aspose.Slides, the image resource and the shape that displays it are separate objects: a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) owns embedded image resources through its [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/), while a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

This separation is useful when the same image is shown more than once. Add the image to the presentation once, keep the returned [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), and use that image resource when creating picture frames.

Picture frames can contain raster images such as PNG or JPEG and vector SVG images. They can also refer to linked images instead of storing the image bytes in the presentation. The choice affects portability, file size, extraction, and export behavior, so it is useful to decide how the image should be stored before applying formatting or optimization.

## **Add and Format an Embedded Image**

For an embedded image, add the image data to the presentation and create a picture frame with [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/). The image becomes part of the presentation package, so the presentation remains self-contained when it is moved to another computer.

The following example adds a JPEG image, creates a frame at the image's native dimensions, and applies line formatting and rotation:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The picture frame controls the displayed geometry; changing the frame size does not change the original pixel dimensions stored in the embedded image resource. This distinction becomes important when cropping or compressing an image later.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) exposes relative width and height scaling for the frame through [setRelativeScaleWidth](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/setrelativescalewidth/) and [setRelativeScaleHeight](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/setrelativescaleheight/). A value of `1.0` corresponds to 100% of the original picture size. Relative scale is useful when a workflow needs to preserve a relationship to the source image size instead of calculating final dimensions manually.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Relative scale changes the frame's scale settings; it does not resample or compress the embedded image.

## **Embedded and Linked Images**

An embedded picture stores image data inside the presentation and is therefore the safest choice for portability and predictable rendering. A linked picture stores an external location through the [Picture::setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setlinkpathlong/) method instead of embedding the image data in the same way.

Linked images can reduce the amount of image data stored in the PPTX, but they introduce an external dependency. The linked file must remain accessible to the application that opens or renders the presentation. If the path changes, the file is moved, or the resource is unavailable, the linked picture may not be displayed as expected. For presentations that must be emailed, archived, or rendered in isolated environments, embedded images are usually more reliable.

### **Add a Linked Image**

The following example creates a picture frame and points it to a local image file. It deals only with image linking; video linking is a separate media workflow and is intentionally not mixed into this example.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Use links when external file management is intentional. Do not use them merely as a replacement for compression: a small PPTX with broken image dependencies is usually less useful than a larger self-contained presentation.

## **Extract Images from Picture Frames**

Before extracting an image from an existing presentation, check that a shape is actually a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) and that it contains an embedded image. Linked picture frames may not contain image bytes that can be extracted in the same way.

### **Extract a Raster Image**

The modern image API uses [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) directly. The following example finds the first embedded raster picture on a slide and saves it as PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Saving through [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) converts the extracted image to the requested output format. If you need the encoded bytes stored in the presentation rather than a converted raster file, use the image resource's binary data instead.

### **Extract an SVG Image**

For an SVG picture, the [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) exposes an [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/) object. This lets you retrieve the SVG data directly instead of rasterizing the picture first.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Keeping SVG content as SVG preserves the vector source inside the presentation. Raster exports such as PNG or JPEG necessarily render that vector content to pixels. PDF or SVG slide export is also a rendering operation, so the exported graphics should not be treated as a byte-for-byte copy of the original embedded SVG; use the embedded [SvgImage::getSvgData](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/getsvgdata/) data when the original vector resource itself is required.

## **Crop an Image**

Cropping changes which part of an image is visible inside the frame. The crop values on [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) are percentages of the source image dimensions. Cropping does not initially delete the hidden pixels from the embedded image; it only changes the visible region.

The following example finds a picture frame safely and applies crop values:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Because the hidden image data is still present, the crop can be changed later without losing the original pixels. If file size matters more than reversibility, the cropped regions can be physically removed as described in the next section.

## **Remove Cropped Image Data**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) removes image data outside the current crop rectangle and returns the resulting image resource. This can reduce file size, but it is a destructive optimization: after the presentation is saved, the removed pixels are no longer available for a later uncrop operation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

The method may add a new image resource to the presentation. If the original image is also used by other picture frames, those frames still need their existing resource, so deleting cropped areas does not necessarily reduce the total number of images. Cropping WMF or EMF content with this method rasterizes the cropped result to PNG.

## **Compress Raster Images**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) reduces raster image resolution relative to the size at which the picture is displayed. It can also remove cropped regions in the same operation. The method returns `true` when the image was resized or cropped and `false` when no change was necessary.

Use a predefined [PicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/picturescompression/) value when a standard target resolution is sufficient:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

A custom positive DPI value can be passed instead of a predefined value when a specific target is required.

Compression is intended for raster images. SVG and metafile content is not reduced by this raster compression workflow. Also remember that lower resolution and deleted cropped regions cannot be recovered from the optimized presentation. Choose a target resolution based on the largest size at which the image will actually be viewed or exported rather than applying the lowest DPI globally.

## **Manage Image Transform Effects**

For a complete workflow covering brightness, contrast, color transformations, blur, alpha effects, ordered chains, inspection, removal, and round-trip verification, see [Image Transform Effects](/slides/php-java/image-transform-effects/).

## **Lock Picture Frame Geometry**

The [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) settings control which editing operations are disabled for a picture frame. For example, [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) preserves the shape's proportions while it is resized.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The lock applies to the picture frame shape. It does not force the source image to be resampled or permanently changed to the same aspect ratio.

## **Adjust the StretchOffset Values**

When the picture fill mode is stretch, the stretch-offset values on [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) define the fill rectangle relative to the picture frame's bounding box. Positive percentages create an inset from an edge, while negative percentages create an outset.

This is different from cropping. Crop values select which part of the source image is visible; stretch offsets change the rectangle into which the visible picture fill is stretched.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Use stretch offsets for fill placement. Use crop properties when the goal is to hide source-image edges.

## **Storage, File Size, and Export Considerations**

The main tradeoffs are easier to manage when image storage and picture-frame formatting are treated separately:

- **Embedded images** make the presentation self-contained and are the most reliable for sharing and server-side rendering, but large raster images increase PPTX size and memory use.
- **Linked images** can keep the package smaller, but the presentation depends on external files remaining available at the stored paths or locations.
- **Cropping** is initially non-destructive. The hidden pixels remain embedded until cropped areas are explicitly deleted or removed during compression.
- **Compression** can reduce file size substantially for oversized raster images, but it trades away source resolution. It should be applied after the intended on-slide size is known.
- **SVG images** should remain as SVG when vector preservation is important. Extract the embedded SVG directly when you need the vector resource itself. Raster slide exports always convert the rendered slide to pixels.
- **Repeated images** should reuse an existing [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) resource when possible instead of repeatedly loading the same file into the presentation workflow.

For large presentations, image optimization is usually most effective when performed selectively: keep logos and diagrams as vector content, compress photographs according to their real display size, remove cropped pixels only when later editing is not required, and avoid external links unless dependency management is part of the deployment design.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

A [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) represents an image resource associated with the presentation. A [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) is a shape on a slide that displays an image and stores frame-level geometry and formatting such as size, rotation, crop values, effects, and locks.

**Should I embed or link images?**

Embed images when the presentation must be portable, archived, or rendered without access to external resources. Link images only when keeping image files outside the PPTX is intentional and the external locations can be maintained reliably.

**Does cropping reduce PPTX file size?**

Not by itself. Normal crop settings hide parts of the source image but keep the underlying pixels. Use [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) or image compression with cropped-area removal when those pixels can be discarded permanently.

**Can I restore image quality after compression?**

No. Compression can reduce stored raster resolution, and removing cropped regions discards image data. Keep the original source image outside the presentation if later high-resolution editing may be required.

**How should SVG images be handled?**

Keep SVG content as SVG when vector fidelity matters. The embedded [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/) can be extracted directly. Rendering a slide to a raster format such as PNG or JPEG rasterizes the SVG as part of the slide image.

**How can I avoid unsafe casts when reading existing slides?**

Check the shape type before using picture-frame-specific members. A `java_instanceof` check against [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) avoids invalid casts and lets the code handle slides that do not contain picture frames.
