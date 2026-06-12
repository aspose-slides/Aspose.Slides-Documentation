---
title: Afbeelding
type: docs
weight: 50
url: /nl/cpp/examples/elements/picture/
keywords:
- codevoorbeeld
- afbeelding
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werken met afbeeldingen in Aspose.Slides for C++: invoegen, bijsnijden, comprimeren, opnieuw kleuren en afbeeldingen exporteren met C++-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe je afbeeldingen uit geheugen‑afbeeldingen kunt invoegen en openen met **Aspose.Slides for C++**. De onderstaande voorbeelden maken een afbeelding in het geheugen, plaatsen die op een dia en halen hem vervolgens op.

## **Een afbeelding toevoegen**

Deze code genereert een kleine bitmap, zet deze om in een stream en voegt hem als een afbeeldingframe toe aan de eerste dia.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Maak een eenvoudige afbeelding in het geheugen.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Zet de bitmap om naar een byte-array.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Voeg de afbeelding toe aan de presentatie.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Voeg een afbeeldingframe toe dat de afbeelding op de eerste dia toont.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Een afbeelding openen**

Dit voorbeeld controleert of een dia een afbeeldingframe bevat en opent vervolgens de eerste die gevonden wordt.

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