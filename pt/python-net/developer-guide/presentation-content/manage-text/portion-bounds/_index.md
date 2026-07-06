---
title: Obter limites de porção de texto de apresentações em Python
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/python-net/portion-bounds/
keywords:
- limites de porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como recuperar os limites de porção de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite trabalhar com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter os limites de um fragmento de texto, aplicar formatação a apenas parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [Portion.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/get_rect/). Também mostra como obter as coordenadas do início de uma porção usando [Portion.get_coordinates](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/get_coordinates/). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida através da porção, parágrafo, caixa de texto e herança de tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter limites de uma porção de texto**

Use [Portion.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/get_rect/) para recuperar o retângulo delimitador de uma porção de texto:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Obter coordenadas de uma porção de texto**

Use [Portion.get_coordinates](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/get_coordinates/) para recuperar as coordenadas do início de uma porção de texto:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **Perguntas Frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/python-net/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilos: o que uma porção sobrescreve e o que é herdado de um parágrafo ou caixa de texto?**

As propriedades no nível da Porção têm a maior precedência. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/), o Aspose.Slides a obtém do [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo da [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) ou do [theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

[Font substitution rules](/slides/pt/python-net/font-selection-sequence/) são aplicadas. O texto pode sofrer reflow: métricas, hifenização e largura podem mudar, o que é importante para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específicos da porção independentemente do resto do parágrafo?**

Sim, a cor, o preenchimento e a transparência do texto no nível da [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.