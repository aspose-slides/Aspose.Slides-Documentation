---
title: Objeto OLE
type: docs
weight: 210
url: /pt/net/examples/elements/ole-object/
keywords:
- objeto OLE
- adicionar objeto OLE
- acessar objeto OLE
- remover objeto OLE
- atualizar objeto OLE
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Manipule objetos OLE no Aspose.Slides for .NET: insira, vincule, atualize e extraia conteúdo incorporado com C# em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como incorporar um arquivo como um objeto OLE e atualizar seus dados usando **Aspose.Slides for .NET**.

## **Adicionar um Objeto OLE**

Incorpore um arquivo PDF na apresentação.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **Acessar um Objeto OLE**

Recupere o primeiro quadro de objeto OLE em um slide.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Remover um Objeto OLE**

Exclua um objeto OLE incorporado do slide.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **Atualizar Dados do Objeto OLE**

Substitua os dados incorporados em um objeto OLE existente.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```