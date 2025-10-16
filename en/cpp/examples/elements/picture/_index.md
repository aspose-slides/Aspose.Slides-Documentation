---
title: Picture
type: docs
weight: 50
url: /cpp/examples/elements/picture/
keywords:
- code example
- picture
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Work with pictures in Aspose.Slides for C++: insert, crop, compress, recolor, and export images with C++ examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to insert and access pictures from in-memory images using **Aspose.Slides for C++**. The examples below create an image in memory, place it on a slide, and then retrieve it.

## **Add a Picture**

This code generates a small bitmap, converts it to a stream, and inserts it as a picture frame on the first slide.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Create a simple in-memory image.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Convert the bitmap to a byte array.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Add the image to the presentation.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Insert a picture frame showing the image on the first slide.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes()) {
        if (ObjectExt::Is<IPictureFrame>(shape)) {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```
