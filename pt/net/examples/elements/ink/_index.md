---
title: Tinta
type: docs
weight: 180
url: /pt/net/examples/elements/ink/
keywords:
- tinta
- acessar tinta
- remover tinta
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com Tinta no Aspose.Slides for .NET: desenhe, importe e edite traços, ajuste cor e largura e exporte para PPT, PPTX e ODP usando exemplos em C#."
---
Este artigo fornece exemplos de como acessar formas de tinta existentes e removê-las usando **Aspose.Slides for .NET**.

> ❗ **Nota:** Formas de tinta representam a entrada do usuário a partir de dispositivos especializados. O Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar a tinta existente.

## **Acessar Tinta**

Leia as tags da primeira forma de tinta em um slide.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Use tagName conforme necessário.
        }
    }
}
```

## **Remover Tinta**

Exclua uma forma de tinta do slide, se houver.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```