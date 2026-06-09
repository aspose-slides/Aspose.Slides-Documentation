---
title: SmartArt
type: docs
weight: 140
url: /pt/net/examples/elements/smart-art/
keywords:
- SmartArt
- adicionar SmartArt
- acessar SmartArt
- remover SmartArt
- layout de SmartArt
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com SmartArt no Aspose.Slides for .NET: crie, edite, converta e estilize diagramas com C# para apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como adicionar gráficos SmartArt, acessá‑los, removê‑los e alterar layouts usando **Aspose.Slides for .NET**.

## **Adicionar SmartArt**

Insira um gráfico SmartArt usando um dos layouts incorporados.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Acessar SmartArt**

Recupere o primeiro objeto SmartArt em um slide.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Remover SmartArt**

Exclua um shape SmartArt do slide.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Alterar Layout do SmartArt**

Atualize o tipo de layout de um gráfico SmartArt existente.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```