---
title: Imagem
type: docs
weight: 50
url: /pt/net/examples/elements/picture/
keywords:
- imagem
- quadro de imagem
- adicionar imagem
- acessar imagem
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com imagens no Aspose.Slides for .NET: insira, recorte, comprima, recolor e exporte imagens com exemplos em C# para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como inserir e acessar imagens a partir de imagens armazenadas na memória usando **Aspose.Slides for .NET**. Os exemplos abaixo criam uma imagem na memória, a colocam em um slide e, em seguida, a recuperam.

## **Adicionar uma Imagem**

Este código gera um bitmap pequeno, converte‑o em um fluxo e o insere como um quadro de imagem no primeiro slide.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crie uma imagem simples em memória.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Converta o bitmap para MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Adicione a imagem à apresentação.
    var image = presentation.Images.AddImage(imageStream);

    // Insira um quadro de imagem exibindo a imagem no primeiro slide.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Acessar uma Imagem**

Este exemplo garante que um slide contenha um quadro de imagem e então acessa o primeiro que encontrar.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Garanta que haja pelo menos um quadro de imagem para trabalhar.
    using var bitmap = new Bitmap(40, 40);

    // Converta o bitmap para MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Adicione a imagem à apresentação.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Acesse o primeiro quadro de imagem no slide.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```