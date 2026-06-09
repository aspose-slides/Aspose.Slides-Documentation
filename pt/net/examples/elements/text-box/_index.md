---
title: Caixa de Texto
type: docs
weight: 40
url: /pt/net/examples/elements/text-box/
keywords:
- caixa de texto
- adicionar caixa de texto
- acessar caixa de texto
- remover caixa de texto
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com caixas de texto no Aspose.Slides para .NET: adicione, formate, alinhe, quebre linhas, ajuste automático e estilize texto usando C# para apresentações PPT, PPTX e ODP."
---
No Aspose.Slides, uma **caixa de texto** é representada por um `AutoShape`. Quase qualquer forma pode conter texto, mas uma caixa de texto típica não tem preenchimento nem borda e exibe apenas texto.

Este guia explica como adicionar, acessar e remover caixas de texto programaticamente.

## **Adicionar uma Caixa de Texto**

Uma caixa de texto é simplesmente um `AutoShape` sem preenchimento nem borda e com algum texto formatado. Aqui está como criar uma:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Criar uma forma retangular (padrão preenchida com borda e sem texto).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remover preenchimento e borda para que pareça uma caixa de texto típica.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Definir formatação de texto.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Atribuir o conteúdo real do texto.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Observação:** Qualquer `AutoShape` que contenha um `TextFrame` não vazio pode funcionar como uma caixa de texto.

## **Acessar Caixas de Texto por Conteúdo**

Para encontrar todas as caixas de texto que contenham uma palavra‑chave específica (por exemplo, "Slide"), itere pelas formas e verifique seu texto:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Apenas AutoShapes podem conter texto editável.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Faça algo com a caixa de texto correspondente.
            }
        }
    }
}
```

## **Remover Caixas de Texto por Conteúdo**

Este exemplo encontra e exclui todas as caixas de texto no primeiro slide que contêm uma palavra‑chave específica:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Dica:** Sempre crie uma cópia da coleção de formas antes de modificá‑la durante a iteração para evitar erros de modificação da coleção.