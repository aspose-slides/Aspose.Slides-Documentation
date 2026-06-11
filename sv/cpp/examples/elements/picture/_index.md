---
title: Bild
type: docs
weight: 50
url: /sv/cpp/examples/elements/picture/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med bilder i Aspose.Slides för C++: infoga, beskära, komprimera, färgändra och exportera bilder med C++-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man infogar och får åtkomst till bilder från minnesbilder med **Aspose.Slides for C++**. Exemplen nedan skapar en bild i minnet, placerar den på en bild och hämtar den sedan.

## **Lägg till en bild**

Den här koden genererar en liten bitmap, konverterar den till en ström och infogar den som en bildram på den första bilden.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Skapa en enkel bild i minnet.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Konvertera bitmapen till en bytearray.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Lägg till bilden i presentationen.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Infoga en bildram som visar bilden på den första bilden.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Få åtkomst till en bild**

Det här exemplet säkerställer att en bild innehåller en bildram och hämtar sedan den första som den hittar.

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
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```