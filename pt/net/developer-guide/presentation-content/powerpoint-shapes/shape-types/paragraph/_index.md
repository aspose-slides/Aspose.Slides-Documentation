---
title: Obter limites de parágrafo de apresentações em .NET
linktitle: Parágrafo
type: docs
weight: 60
url: /pt/net/paragraph/
keywords:
- limites de parágrafo
- limites de trecho de texto
- coordenada de parágrafo
- coordenada de trecho
- tamanho do parágrafo
- tamanho do trecho de texto
- quadro de texto
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafos e trechos de texto no Aspose.Slides for .NET para otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, tamanho e coordenadas de parágrafos e trechos de texto no Aspose.Slides. Ele mostra como recuperar o retângulo de um parágrafo em um `TextFrame` usando `GetRect()`, como obter coordenadas de parágrafo e trecho dentro de um quadro de texto de célula de tabela, e destaca detalhes importantes como unidades de medida, o efeito da quebra de linha nos limites, conversão de pixels e valores de formatação de parágrafo efetivos.

## **Obter coordenadas de parágrafo e trecho em um TextFrame**
Usando Aspose.Slides for .NET, os desenvolvedores agora podem obter as coordenadas retangulares para Parágrafo dentro da coleção de parágrafos de TextFrame. Também permite obter as coordenadas do trecho dentro da coleção de trechos de um parágrafo. Neste tópico, vamos demonstrar com a ajuda de um exemplo como obter as coordenadas retangulares para o parágrafo juntamente com a posição do trecho dentro de um parágrafo.

## **Obter coordenadas retangulares de um Parágrafo**
O novo método **GetRect()** foi adicionado. Ele permite obter o retângulo de limites do parágrafo.

```c#
 // Instanciar um objeto Presentation que representa um arquivo de apresentação
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Obter o tamanho de um Parágrafo e Trecho dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas do [Portion](https://reference.aspose.com/slides/pt/net/aspose.slides/portion) ou [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph) em um quadro de texto de célula de tabela, você pode usar os métodos [IPortion.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iportion/methods/getrect) e [IParagraph.GetRect](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/methods/getrect).

Este código de exemplo demonstra a operação descrita:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **FAQ**

**Em quais unidades as coordenadas retornadas para um parágrafo e trechos de texto são medidas?**

Em pontos, onde 1 polegada = 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [wrapping](https://reference.aspose.com/slides/pt/net/aspose.slides/textframeformat/wraptext/) estiver habilitado no [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/), o texto quebra para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas com confiabilidade para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para renderização/exportação.

**Como obtenho os parâmetros de formatação de parágrafo "efetivos", considerando a herança de estilo?**

Use a [effective paragraph formatting data structure](/slides/pt/net/shape-effective-properties/); ele retorna os valores consolidados finais para recuos, espaçamento, quebra, RTL e mais.