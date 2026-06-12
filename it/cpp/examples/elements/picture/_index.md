---
title: Immagine
type: docs
weight: 50
url: /it/cpp/examples/elements/picture/
keywords:
- esempio di codice
- immagine
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavora con le immagini in Aspose.Slides per C++: inserisci, ritaglia, comprimi, ri-colora e esporta le immagini con esempi C++ per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come inserire e accedere alle immagini da immagini in memoria utilizzando **Aspose.Slides for C++**. Gli esempi seguenti creano un'immagine in memoria, la inseriscono in una diapositiva e poi la recuperano.

## **Aggiungi un'immagine**

Questo codice genera un piccolo bitmap, lo converte in uno stream e lo inserisce come cornice immagine nella prima diapositiva.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crea un'immagine semplice in memoria.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Converti il bitmap in un array di byte.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Aggiungi l'immagine alla presentazione.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Inserisci un frame immagine che mostra l'immagine nella prima diapositiva.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Accedi a un'immagine**

Questo esempio verifica che una diapositiva contenga una cornice immagine e quindi accede alla prima trovata.

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