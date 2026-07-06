---
title: Obter limites de parágrafos de apresentações em Python
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/python-net/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafos no Aspose.Slides para Python via .NET para otimizar o posicionamento de texto em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo de um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) usando [Paragraph.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/get_rect/), como obter as coordenadas do parágrafo dentro de um quadro de texto de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de texto nos limites, a conversão de pixels e os valores de formatação de parágrafo efetivos.

## **Obter coordenadas retangulares de um parágrafo**

Use [Paragraph.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/get_rect/) para obter o retângulo delimitador de um parágrafo.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Obter o tamanho de um parágrafo dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas de um [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) em um quadro de texto de célula de tabela, use [Paragraph.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/get_rect/). O retângulo retornado é relativo ao quadro de texto da célula de tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar de coordenadas ao nível do slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Em quais unidades as coordenadas do parágrafo são medidas?**

Elas são medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/wrap_text/) estiver habilitado para o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/), o texto será quebrado para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**É possível mapear de forma confiável as coordenadas do parágrafo para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando esta fórmula: pixels = pontos × (DPI / 72). O resultado depende do DPI escolhido para renderização ou exportação.

**Como obtenho os parâmetros de formatação de parágrafo "efetivos", levando em conta a herança de estilo?**

Use a [estrutura de dados de formatação efetiva de parágrafo](/slides/pt/python-net/shape-effective-properties/); ela devolve os valores finais consolidados para recuos, espaçamento, quebra, RTL e muito mais.