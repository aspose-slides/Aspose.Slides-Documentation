---
title: Manage Picture Frames in Presentations Using C++
linktitle: Picture Frame
type: docs
weight: 10
url: /cpp/picture-frame/
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
- C++
- Aspose.Slides
description: "Create, format, link, crop, extract, and compress picture frames in presentations with Aspose.Slides for C++."
---

## **Overview**

A picture frame is a slide shape that displays an image. In Aspose.Slides, the image resource and the shape that displays it are separate objects: a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) owns embedded image resources through its [image collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_images/), while an [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

This separation is useful when the same image is shown more than once. Add the image to the presentation once, keep the returned [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/), and use that image resource when creating picture frames.

Picture frames can contain raster images such as PNG or JPEG and vector SVG images. They can also refer to linked images instead of storing the image bytes in the presentation. The choice affects portability, file size, extraction, and export behavior, so it is useful to decide how the image should be stored before applying formatting or optimization.

## **Add and Format an Embedded Image**

For an embedded image, add the image data to the presentation and create a picture frame with [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addpictureframe/). The image becomes part of the presentation package, so the presentation remains self-contained when it is moved to another computer.

The following example adds a JPEG image, creates a frame at the image's native dimensions, and applies line formatting and rotation:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The picture frame controls the displayed geometry; changing the frame size does not change the original pixel dimensions stored in the embedded image resource. This distinction becomes important when cropping or compressing an image later.

## **Use Relative Scale**

[IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) exposes relative width and height scaling for the frame. A value of `1.0` corresponds to 100% of the original picture size. Relative scale is useful when a workflow needs to preserve a relationship to the source image size instead of calculating final dimensions manually.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Relative scale changes the frame's scale settings; it does not resample or compress the embedded image.

## **Embedded and Linked Images**

An embedded picture stores image data inside the presentation and is therefore the safest choice for portability and predictable rendering. A linked picture stores an external location through the [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) link path instead of embedding the image data in the same way.

Linked images can reduce the amount of image data stored in the PPTX, but they introduce an external dependency. The linked file must remain accessible to the application that opens or renders the presentation. If the path changes, the file is moved, or the resource is unavailable, the linked picture may not be displayed as expected. For presentations that must be emailed, archived, or rendered in isolated environments, embedded images are usually more reliable.

### **Add a Linked Image**

The following example creates a picture frame and points it to a local image file. It deals only with image linking; video linking is a separate media workflow and is intentionally not mixed into this example.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Use links when external file management is intentional. Do not use them merely as a replacement for compression: a small PPTX with broken image dependencies is usually less useful than a larger self-contained presentation.

## **Extract Images from Picture Frames**

Before extracting an image from an existing presentation, check that a shape is actually an [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) and that it contains an embedded image. Linked picture frames may not contain image bytes that can be extracted in the same way.

### **Extract a Raster Image**

The modern image API uses [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) directly. The following example finds the first embedded raster picture on a slide and saves it as PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Saving through [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) converts the extracted image to the requested output format. If you need the encoded bytes stored in the presentation rather than a converted raster file, use the image resource's binary data instead.

### **Extract an SVG Image**

For an SVG picture, the [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) exposes an [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) object. This lets you retrieve the SVG data directly instead of rasterizing the picture first.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Keeping SVG content as SVG preserves the vector source inside the presentation. Raster exports such as PNG or JPEG necessarily render that vector content to pixels. PDF or SVG slide export is also a rendering operation, so the exported graphics should not be treated as a byte-for-byte copy of the original embedded SVG; use the embedded [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) data when the original vector resource itself is required.

## **Crop an Image**

Cropping changes which part of an image is visible inside the frame. The crop values on [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) are percentages of the source image dimensions. Cropping does not initially delete the hidden pixels from the embedded image; it only changes the visible region.

The following example finds a picture frame safely and applies crop values:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Because the hidden image data is still present, the crop can be changed later without losing the original pixels. If file size matters more than reversibility, the cropped regions can be physically removed as described in the next section.

## **Remove Cropped Image Data**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) removes image data outside the current crop rectangle and returns the resulting image resource. This can reduce file size, but it is a destructive optimization: after the presentation is saved, the removed pixels are no longer available for a later uncrop operation.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

The method may add a new image resource to the presentation. If the original image is also used by other picture frames, those frames still need their existing resource, so deleting cropped areas does not necessarily reduce the total number of images. Cropping WMF or EMF content with this method rasterizes the cropped result to PNG.

## **Compress Raster Images**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/compressimage/) reduces raster image resolution relative to the size at which the picture is displayed. It can also remove cropped regions in the same operation. The method returns `true` when the image was resized or cropped and `false` when no change was necessary.

Use a predefined [PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/picturescompression/) value when a standard target resolution is sufficient:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

A custom positive DPI value can be passed instead of an enum value when a specific target is required.

Compression is intended for raster images. SVG and metafile content is not reduced by this raster compression workflow. Also remember that lower resolution and deleted cropped regions cannot be recovered from the optimized presentation. Choose a target resolution based on the largest size at which the image will actually be viewed or exported rather than applying the lowest DPI globally.

## **Inspect Image Effects**

Picture effects are stored on the picture used by the frame. The image transform collection can contain effects such as fixed alpha modulation for transparency and luminance for brightness and contrast. The example below safely reads both kinds of effects from the first picture frame on a slide:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

These effects change how the image is rendered in the frame; they do not rewrite the original embedded image bytes.

## **Lock Picture Frame Geometry**

The [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) settings control which editing operations are disabled for a picture frame. For example, the [aspect-ratio lock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) preserves the shape's proportions while it is resized.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The lock applies to the picture frame shape. It does not force the source image to be resampled or permanently changed to the same aspect ratio.

## **Adjust the StretchOffset Values**

When the picture fill mode is stretch, the stretch-offset values on [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) define the fill rectangle relative to the picture frame's bounding box. Positive percentages create an inset from an edge, while negative percentages create an outset.

This is different from cropping. Crop values select which part of the source image is visible; stretch offsets change the rectangle into which the visible picture fill is stretched.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Use stretch offsets for fill placement. Use crop properties when the goal is to hide source-image edges.

## **Storage, File Size, and Export Considerations**

The main tradeoffs are easier to manage when image storage and picture-frame formatting are treated separately:

- **Embedded images** make the presentation self-contained and are the most reliable for sharing and server-side rendering, but large raster images increase PPTX size and memory use.
- **Linked images** can keep the package smaller, but the presentation depends on external files remaining available at the stored paths or locations.
- **Cropping** is initially non-destructive. The hidden pixels remain embedded until cropped areas are explicitly deleted or removed during compression.
- **Compression** can reduce file size substantially for oversized raster images, but it trades away source resolution. It should be applied after the intended on-slide size is known.
- **SVG images** should remain as SVG when vector preservation is important. Extract the embedded SVG directly when you need the vector resource itself. Raster slide exports always convert the rendered slide to pixels.
- **Repeated images** should reuse an existing [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) resource when possible instead of repeatedly loading the same file into the presentation workflow.

For large presentations, image optimization is usually most effective when performed selectively: keep logos and diagrams as vector content, compress photographs according to their real display size, remove cropped pixels only when later editing is not required, and avoid external links unless dependency management is part of the deployment design.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

An [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) represents an image resource associated with the presentation. An [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) is a shape on a slide that displays an image and stores frame-level geometry and formatting such as size, rotation, crop values, effects, and locks.

**Should I embed or link images?**

Embed images when the presentation must be portable, archived, or rendered without access to external resources. Link images only when keeping image files outside the PPTX is intentional and the external locations can be maintained reliably.

**Does cropping reduce PPTX file size?**

Not by itself. Normal crop settings hide parts of the source image but keep the underlying pixels. Use [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) or image compression with cropped-area removal when those pixels can be discarded permanently.

**Can I restore image quality after compression?**

No. Compression can reduce stored raster resolution, and removing cropped regions discards image data. Keep the original source image outside the presentation if later high-resolution editing may be required.

**How should SVG images be handled?**

Keep SVG content as SVG when vector fidelity matters. The embedded [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) can be extracted directly. Rendering a slide to a raster format such as PNG or JPEG rasterizes the SVG as part of the slide image.

**How can I avoid unsafe casts when reading existing slides?**

Check the shape type before using picture-frame-specific members. Test the shape with [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) before applying a runtime cast, and assign the cast result to a local variable before accessing picture-frame-specific members.
