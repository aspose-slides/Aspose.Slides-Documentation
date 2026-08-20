---
title: Manage Picture Frames in Presentations on Android
linktitle: Picture Frame
type: docs
weight: 10
url: /androidjava/picture-frame/
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
- Android
- Java
- Aspose.Slides
description: "Create, format, link, crop, extract, and compress picture frames in presentations with Aspose.Slides for Android via Java."
---

## **Overview**

A picture frame is a slide shape that displays an image. In Aspose.Slides, the image resource and the shape that displays it are separate objects: a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) owns embedded image resources through its [IImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/), while an [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

This separation is useful when the same image is shown more than once. Add the image to the presentation once, keep the returned [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/), and use that image resource when creating picture frames.

Picture frames can contain raster images such as PNG or JPEG and vector SVG images. They can also refer to linked images instead of storing the image bytes in the presentation. The choice affects portability, file size, extraction, and export behavior, so it is useful to decide how the image should be stored before applying formatting or optimization.

## **Add and Format an Embedded Image**

For an embedded image, add the image data to the presentation and create a picture frame with [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). The image becomes part of the presentation package, so the presentation remains self-contained when it is moved to another computer.

The following example adds a JPEG image, creates a frame at the image's native dimensions, and applies line formatting and rotation:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The picture frame controls the displayed geometry; changing the frame size does not change the original pixel dimensions stored in the embedded image resource. This distinction becomes important when cropping or compressing an image later.

## **Use Relative Scale**

[IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) exposes relative width and height scaling for the frame through [setRelativeScaleWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) and [setRelativeScaleHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). A value of `1.0` corresponds to 100% of the original picture size. Relative scale is useful when a workflow needs to preserve a relationship to the source image size instead of calculating final dimensions manually.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relative scale changes the frame's scale settings; it does not resample or compress the embedded image.

## **Embedded and Linked Images**

An embedded picture stores image data inside the presentation and is therefore the safest choice for portability and predictable rendering. A linked picture stores an external location through the [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) method instead of embedding the image data in the same way.

Linked images can reduce the amount of image data stored in the PPTX, but they introduce an external dependency. The linked file must remain accessible to the application that opens or renders the presentation. If the path changes, the file is moved, or the resource is unavailable, the linked picture may not be displayed as expected. For presentations that must be emailed, archived, or rendered in isolated environments, embedded images are usually more reliable.

### **Add a Linked Image**

The following example creates a picture frame and points it to a local image file. It deals only with image linking; video linking is a separate media workflow and is intentionally not mixed into this example.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use links when external file management is intentional. Do not use them merely as a replacement for compression: a small PPTX with broken image dependencies is usually less useful than a larger self-contained presentation.

## **Extract Images from Picture Frames**

Before extracting an image from an existing presentation, check that a shape is actually an [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) and that it contains an embedded image. Linked picture frames may not contain image bytes that can be extracted in the same way.

### **Extract a Raster Image**

The modern image API uses [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) directly and does not require the older Java image wrapper. The following example finds the first embedded raster picture on a slide and saves it as PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Saving through [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) converts the extracted image to the requested output format. If you need the encoded bytes stored in the presentation rather than a converted raster file, use the image resource's binary data instead.

### **Extract an SVG Image**

For an SVG picture, the [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) exposes an [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgimage/) object. This lets you retrieve the SVG data directly instead of rasterizing the picture first.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Keeping SVG content as SVG preserves the vector source inside the presentation. Raster exports such as PNG or JPEG necessarily render that vector content to pixels. PDF or SVG slide export is also a rendering operation, so the exported graphics should not be treated as a byte-for-byte copy of the original embedded SVG; use the embedded [ISvgImage.getSvgData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgimage/#getSvgData--) data when the original vector resource itself is required.

## **Crop an Image**

Cropping changes which part of an image is visible inside the frame. The crop values on [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) are percentages of the source image dimensions. Cropping does not initially delete the hidden pixels from the embedded image; it only changes the visible region.

The following example finds a picture frame safely and applies crop values:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Because the hidden image data is still present, the crop can be changed later without losing the original pixels. If file size matters more than reversibility, the cropped regions can be physically removed as described in the next section.

## **Remove Cropped Image Data**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) removes image data outside the current crop rectangle and returns the resulting image resource. This can reduce file size, but it is a destructive optimization: after the presentation is saved, the removed pixels are no longer available for a later uncrop operation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

The method may add a new image resource to the presentation. If the original image is also used by other picture frames, those frames still need their existing resource, so deleting cropped areas does not necessarily reduce the total number of images. Cropping WMF or EMF content with this method rasterizes the cropped result to PNG.

## **Compress Raster Images**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) reduces raster image resolution relative to the size at which the picture is displayed. It can also remove cropped regions in the same operation. The method returns `true` when the image was resized or cropped and `false` when no change was necessary.

Use a predefined [PicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturescompression/) value when a standard target resolution is sufficient:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

A custom positive DPI value can be passed instead of a predefined value when a specific target is required.

Compression is intended for raster images. SVG and metafile content is not reduced by this raster compression workflow. Also remember that lower resolution and deleted cropped regions cannot be recovered from the optimized presentation. Choose a target resolution based on the largest size at which the image will actually be viewed or exported rather than applying the lowest DPI globally.

## **Inspect Image Effects**

Picture effects are stored on the picture used by the frame. The image transform collection can contain effects such as fixed alpha modulation for transparency and luminance for brightness and contrast. The example below safely reads both kinds of effects from the first picture frame on a slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

These effects change how the image is rendered in the frame; they do not rewrite the original embedded image bytes.

## **Lock Picture Frame Geometry**

The [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) settings control which editing operations are disabled for a picture frame. For example, [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) preserves the shape's proportions while it is resized.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The lock applies to the picture frame shape. It does not force the source image to be resampled or permanently changed to the same aspect ratio.

## **Adjust the StretchOffset Values**

When the picture fill mode is stretch, the stretch-offset values on [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) define the fill rectangle relative to the picture frame's bounding box. Positive percentages create an inset from an edge, while negative percentages create an outset.

This is different from cropping. Crop values select which part of the source image is visible; stretch offsets change the rectangle into which the visible picture fill is stretched.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
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
- **Repeated images** should reuse an existing [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) resource when possible instead of repeatedly loading the same file into the presentation workflow.

For large presentations, image optimization is usually most effective when performed selectively: keep logos and diagrams as vector content, compress photographs according to their real display size, remove cropped pixels only when later editing is not required, and avoid external links unless dependency management is part of the deployment design.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

An [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) represents an image resource associated with the presentation. An [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) is a shape on a slide that displays an image and stores frame-level geometry and formatting such as size, rotation, crop values, effects, and locks.

**Should I embed or link images?**

Embed images when the presentation must be portable, archived, or rendered without access to external resources. Link images only when keeping image files outside the PPTX is intentional and the external locations can be maintained reliably.

**Does cropping reduce PPTX file size?**

Not by itself. Normal crop settings hide parts of the source image but keep the underlying pixels. Use [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) or image compression with cropped-area removal when those pixels can be discarded permanently.

**Can I restore image quality after compression?**

No. Compression can reduce stored raster resolution, and removing cropped regions discards image data. Keep the original source image outside the presentation if later high-resolution editing may be required.

**How should SVG images be handled?**

Keep SVG content as SVG when vector fidelity matters. The embedded [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgimage/) can be extracted directly. Rendering a slide to a raster format such as PNG or JPEG rasterizes the SVG as part of the slide image.

**How can I avoid unsafe casts when reading existing slides?**

Check the shape type before using picture-frame-specific members. An `instanceof` check against [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) avoids invalid casts and lets the code handle slides that do not contain picture frames.


