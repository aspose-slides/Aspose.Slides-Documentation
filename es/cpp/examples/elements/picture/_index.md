---
title: Imagen
type: docs
weight: 50
url: /es/cpp/examples/elements/picture/
keywords:
- ejemplo de código
- imagen
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Trabaje con imágenes en Aspose.Slides for C++: inserte, recorte, comprima, cambie el color y exporte imágenes con ejemplos en C++ para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo insertar y acceder a imágenes a partir de imágenes en memoria usando **Aspose.Slides for C++**. Los ejemplos siguientes crean una imagen en memoria, la colocan en una diapositiva y luego la recuperan.

## **Agregar una imagen**

Este código genera un bitmap pequeño, lo convierte en un stream y lo inserta como un marco de imagen en la primera diapositiva.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crear una imagen simple en memoria.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Convertir el bitmap a una matriz de bytes.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Añadir la imagen a la presentación.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Insertar un marco de imagen que muestre la imagen en la primera diapositiva.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Acceder a una imagen**

Este ejemplo verifica que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

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