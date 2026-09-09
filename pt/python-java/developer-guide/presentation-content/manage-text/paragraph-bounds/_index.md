---
title: Obter limites de parágrafo de apresentações em Python via Java
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/python-java/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- moldura de texto
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Saiba como recuperar os limites de parágrafo no Aspose.Slides para Python via Java para otimizar o posicionamento de texto em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo de um [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) usando [Paragraph.getRect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/#getRect), como obter as coordenadas do parágrafo dentro de uma moldura de texto de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de texto nos limites, conversão para pixels e valores de formatação de parágrafo “efetivos”.

## **Obter coordenadas retangulares de um parágrafo**

Use [Paragraph.getRect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/#getRect) para obter o retângulo delimitador de um parágrafo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Obter o tamanho de um parágrafo dentro de uma moldura de texto de célula de tabela**

Para obter o tamanho e as coordenadas de um [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/) em uma moldura de texto de célula de tabela, use [Paragraph.getRect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/#getRect). O retângulo retornado é relativo à moldura de texto da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar das coordenadas ao nível do slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Em quais unidades as coordenadas do parágrafo são medidas?**

São medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setWrapText) estiver habilitado para o [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/), o texto será quebrado para se ajustar à largura da área, alterando os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando a fórmula: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para a renderização ou exportação.

**Como obter os parâmetros de formatação de parágrafo “efetivos”, levando em conta a herança de estilo?**

Use a [effective paragraph formatting data structure](/slides/pt/python-java/shape-effective-properties/); ela retorna os valores consolidados finais para recuos, espaçamento, quebra de linha, RTL e mais.