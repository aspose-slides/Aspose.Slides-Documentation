---
title: Kép
type: docs
weight: 50
url: /hu/cpp/examples/elements/picture/
keywords:
- kód példa
- kép
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Képek kezelése az Aspose.Slides for C++-ban: képek beszúrása, vágása, tömörítése, színezése és exportálása C++ példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet képeket beszúrni és elérni memóriában lévő képek használatával a **Aspose.Slides for C++** segítségével. Az alábbi példák memóriában hoznak létre egy képet, elhelyezik egy dián, majd lekérik azt.

## **Kép hozzáadása**

Ez a kód egy kis bitmapet generál, átalakítja egy adatfolyammá, és képkockaként helyezi el az első dián.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Hozzon létre egy egyszerű memóriában tárolt képet.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // A bitmapet bájttömbbé konvertálja.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // A képet hozzáadja a prezentációhoz.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Beszúr egy képkockát, amely megjeleníti a képet az első dián.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Kép elérése**

Ez a példa biztosítja, hogy egy dia tartalmazzon képkockát, majd eléri az elsőként megtaláltat.

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