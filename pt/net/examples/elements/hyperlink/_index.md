---
title: Hiperlink
type: docs
weight: 130
url: /pt/net/examples/elements/hyperlink/
keywords:
- hiperlink
- adicionar hiperlink
- acessar hiperlink
- remover hiperlink
- atualizar hiperlink
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Adicione e gerencie hiperlinks no Aspose.Slides for .NET: vincule texto, formas e imagens, defina destinos e ações para PPT, PPTX e ODP com exemplos em C#."
---
Este artigo demonstra como adicionar, acessar, remover e atualizar hyperlinks em formas usando **Aspose.Slides for .NET**.

## **Adicionar um Hyperlink**

Crie uma forma retangular com um hyperlink apontando para um site externo.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Acessar um Hyperlink**

Leia as informações do hyperlink a partir da porção de texto de uma forma.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Remover um Hyperlink**

Remova o hyperlink do texto de uma forma.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Atualizar um Hyperlink**

Altere o destino de um hyperlink existente. Use `HyperlinkManager` para modificar o texto que já contém um hyperlink, replicando como o PowerPoint atualiza hyperlinks de forma segura.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Alterar um hyperlink em texto existente deve ser feito via
    // HyperlinkManager em vez de definir a propriedade diretamente.
    // Isso imita como o PowerPoint atualiza hyperlinks de forma segura.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```