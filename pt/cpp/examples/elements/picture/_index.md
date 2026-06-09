---
title: Imagem
type: docs
weight: 50
url: /pt/cpp/examples/elements/picture/
keywords:
- exemplo de código
- imagem
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Trabalhe com imagens no Aspose.Slides for C++: insira, recorte, comprima, recolor e exporte imagens com exemplos em C++ para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como inserir e acessar imagens a partir de imagens armazenadas na memória usando **Aspose.Slides for C++**. Os exemplos abaixo criam uma imagem na memória, a colocam em um slide e, em seguida, a recuperam.

## **Adicionar uma Imagem**

Este código gera um bitmap pequeno, converte‑o em um fluxo e o insere como um quadro de imagem no primeiro slide.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crie uma imagem simples em memória.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Converta o bitmap em um array de bytes.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Adicione a imagem à apresentação.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Insira um quadro de imagem exibindo a imagem no primeiro slide.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Acessar uma Imagem**

Este exemplo garante que um slide contenha um quadro de imagem e, em seguida, acessa o primeiro que encontra.

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