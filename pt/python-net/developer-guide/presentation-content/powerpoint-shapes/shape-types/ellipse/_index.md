---
title: "Adicionar Elipses a Apresentações em Python"
linktitle: "Elipse"
type: docs
weight: 30
url: /pt/python-net/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a criar, formatar e manipular formas de elipse no Aspose.Slides for Python via .NET em apresentações PPT, PPTX e ODP — exemplos de código incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas de elipse aos slides do PowerPoint usando o Aspose.Slides. Ele aborda a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda perguntas relacionadas, como trabalhar com a posição e o tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar elipse**
Neste tópico, apresentaremos aos desenvolvedores como adicionar formas de elipse aos seus slides usando o Aspose.Slides for Python via .NET. O Aspose.Slides for Python via .NET fornece um conjunto mais simples de APIs para desenhar diferentes tipos de formas com apenas algumas linhas de código. Para adicionar uma elipse simples a um slide selecionado da apresentação, siga as etapas abaixo:

1. Criar uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/)
1. Obter a referência de um slide usando seu Index
1. Adicionar um AutoShape do tipo Ellipse usando o método AddAutoShape exposto pelo objeto IShapes
1. Gravar a apresentação modificada como um arquivo PPTX

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa o PPTX
with slides.Presentation() as pres:
    # Obter o primeiro slide
    sld = pres.slides[0]

    # Adicionar autoshape do tipo elipse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Gravar o arquivo PPTX no disco
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Criar elipse formatada**
Para adicionar uma elipse melhor formatada a um slide, siga as etapas abaixo:

1. Criar uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obter a referência de um slide usando seu Index.
1. Adicionar um AutoShape do tipo Ellipse usando o método AddAutoShape exposto pelo objeto IShapes.
1. Definir o tipo de preenchimento da elipse como Solid.
1. Definir a cor da elipse usando a propriedade SolidFillColor.Color exposta pelo objeto FillFormat associado ao objeto IShape.
1. Definir a cor das linhas da elipse.
1. Definir a largura das linhas da elipse.
1. Gravar a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa o PPTX
with slides.Presentation() as pres:
    # Obter o primeiro slide
    sld = pres.slides[0]

    # Adicionar autoshape do tipo elipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Aplicar alguma formatação à forma de elipse
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar alguma formatação à linha da elipse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Gravar o arquivo PPTX no disco
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Como definir a posição exata e o tamanho de uma elipse em relação às unidades do slide?**

As coordenadas e os tamanhos são normalmente especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta os milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como posso posicionar uma elipse acima ou abaixo de outros objetos (controlar a ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo‑o para a frente ou enviando‑o para trás. Isso permite que a elipse sobreponha outros objetos ou revele os que estão abaixo dela.

**Como animar a aparição ou ênfase de uma elipse?**

[Aplicar](/slides/pt/python-net/shape-animation/) efeitos de entrada, ênfase ou saída à forma e configure gatilhos e temporização para orquestrar quando e como a animação será reproduzida.