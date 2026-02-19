---
title: Image
type: docs
weight: 50
url: /fr/cpp/examples/elements/picture/
keywords:
- exemple de code
- image
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Travailler avec les images dans Aspose.Slides pour C++ : insérer, recadrer, compresser, recolorer et exporter des images avec des exemples C++ pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment insérer et accéder à des images à partir d'images en mémoire à l'aide de **Aspose.Slides for C++**. Les exemples ci-dessous créent une image en mémoire, la placent sur une diapositive, puis la récupèrent.

## **Ajouter une image**

Ce code génère un petit bitmap, le convertit en flux et l'insère comme cadre d'image sur la première diapositive.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Créer une image simple en mémoire.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Convertir le bitmap en tableau d'octets.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Ajouter l'image à la présentation.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Insérer un cadre d'image affichant l'image sur la première diapositive.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Accéder à une image**

Cet exemple s'assure qu'une diapositive contient un cadre d'image et accède au premier trouvé.

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