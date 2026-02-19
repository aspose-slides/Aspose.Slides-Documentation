---
title: Bild
type: docs
weight: 50
url: /de/cpp/examples/elements/picture/
keywords:
- Codebeispiel
- Bild
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit Bildern in Aspose.Slides für C++: Einfügen, Zuschneiden, Komprimieren, Umfärben und Exportieren von Bildern mit C++-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie Sie Bilder aus im Speicher befindlichen Bildern mithilfe von **Aspose.Slides for C++** einfügen und darauf zugreifen können. Die nachstehenden Beispiele erzeugen ein Bild im Speicher, platzieren es auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

Dieser Code erzeugt ein kleines Bitmap, konvertiert es in einen Stream und fügt es als Bildrahmen auf der ersten Folie ein.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Erstelle ein einfaches Bild im Speicher.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Konvertiere das Bitmap in ein Byte-Array.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Füge das Bild zur Präsentation hinzu.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Füge einen Bildrahmen ein, der das Bild auf der ersten Folie anzeigt.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Zugriff auf ein Bild**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift anschließend auf den ersten gefundenen zu.

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