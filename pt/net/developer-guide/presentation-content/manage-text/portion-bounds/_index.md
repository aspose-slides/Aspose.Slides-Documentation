---
title: Obter limites de porções de texto em apresentações no .NET
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/net/portion-bounds/
keywords:
- limites de porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como recuperar os limites de porções de texto em apresentações PowerPoint usando Aspose.Slides para .NET."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter os limites de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [IPortion.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/getrect/). Também mostra como obter as coordenadas do início de uma porção usando [IPortion.GetCoordinates](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/getcoordinates/). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida através da porção, parágrafo, quadro de texto e herança de tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter limites de uma porção de texto**

Use [IPortion.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/getrect/) para recuperar o retângulo delimitador de uma porção de texto:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Obter coordenadas de uma porção de texto**

Use [IPortion.GetCoordinates](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/getcoordinates/) para recuperar as coordenadas do início de uma porção de texto:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **Perguntas frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/net/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que a porção substitui e o que é herdado de um parágrafo ou de um quadro de texto?**

As propriedades ao nível da porção têm a maior precedência. Se uma propriedade não estiver definida no [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/), o Aspose.Slides a obtém do [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo do [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) ou do [theme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

[Font substitution rules](/slides/pt/net/font-selection-sequence/) se aplicam. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que é importante para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específicos de uma porção independentemente do restante do parágrafo?**

Sim, a cor, o preenchimento e a transparência do texto ao nível do [IPortion](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/) podem diferir dos fragmentos vizinhos.