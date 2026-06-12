---
title: Obrázek
type: docs
weight: 50
url: /cs/cpp/examples/elements/picture/
keywords:
- příklad kódu
- obrázek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Práce s obrázky v Aspose.Slides pro C++: vkládání, ořezávání, komprimování, změna barev a export obrázků s příklady v C++ pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vložit a získat obrázky z paměťových obrázků pomocí **Aspose.Slides for C++**. Níže uvedené příklady vytvoří obrázek v paměti, umístí jej na snímek a následně jej získají.

## **Přidat obrázek**

Tento kód vygeneruje malý bitmapový obrázek, převede jej na proud a vloží jej jako rámeček obrázku na první snímek.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Vytvořte jednoduchý obrázek v paměti.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Převést bitmapu na pole bajtů.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Přidejte obrázek do prezentace.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Vložte rámeček obrázku zobrazující obrázek na první snímek.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Přístup k obrázku**

Tento příklad zajišťuje, že snímek obsahuje rámeček obrázku, a následně přistoupí k prvnímu, který najde.

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