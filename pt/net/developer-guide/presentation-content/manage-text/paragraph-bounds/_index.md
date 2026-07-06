---
title: Obter limites de parágrafo de apresentações em .NET
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/net/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafo no Aspose.Slides para .NET a fim de otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, tamanho e coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo de um [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) usando [IParagraph.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getrect/), como obter as coordenadas do parágrafo dentro de um TextFrame de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de texto nos limites, conversão para pixels e valores de formatação de parágrafo efetiva.

## **Obter coordenadas retangulares de um parágrafo**

Use [IParagraph.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getrect/) para obter o retângulo delimitador de um parágrafo.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Obter o tamanho de um parágrafo dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas de um [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/) em um TextFrame de célula de tabela, use [IParagraph.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/getrect/). O retângulo retornado é relativo ao TextFrame da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar das coordenadas ao nível do slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**Em que unidades as coordenadas do parágrafo são medidas?**

Elas são medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites do parágrafo?**

Sim. Se [TextFrameFormat.WrapText](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/wraptext/) estiver habilitado para o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), o texto é interrompido para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando esta fórmula: pixels = pontos × (DPI / 72). O resultado depende do DPI escolhido para renderização ou exportação.

**Como obtenho os parâmetros de formatação "efetiva" do parágrafo, considerando a herança de estilo?**

Use a [estrutura de dados de formatação efetiva de parágrafo](/slides/pt/net/shape-effective-properties/); ela retorna os valores consolidados finais para recuos, espaçamento, quebra de linha, RTL e muito mais.