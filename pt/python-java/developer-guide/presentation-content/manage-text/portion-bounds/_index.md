---
title: Obter limites de porção de texto de apresentações em Python via Java
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/python-java/portion-bounds/
keywords:
- limites de porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como recuperar os limites de porções de texto em apresentações do PowerPoint usando Aspose.Slides para Python via Java."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar os limites de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [Portion.getRect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getRect). Também demonstra como obter as coordenadas do início de uma porção usando [Portion.getCoordinates](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getCoordinates). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hiperlink a um único fragmento de texto, entender como a formatação é resolvida através da herança de porção, parágrafo, quadro de texto e tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter limites de uma porção de texto**

Use [Portion.getRect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getRect) para recuperar o retângulo delimitador de uma porção de texto:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Obter coordenadas de uma porção de texto**

Use [Portion.getCoordinates](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getCoordinates) para recuperar as coordenadas do início de uma porção de texto:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso aplicar um hiperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hiperlink](/slides/pt/python-java/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que uma porção sobrescreve e o que é herdado de um parágrafo ou quadro de texto?**

As propriedades ao nível da Porção têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/), o Aspose.Slides a obtém do [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo do [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) ou do [theme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

[Regras de substituição de fonte](/slides/pt/python-java/font-selection-sequence/) são aplicadas. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que importa para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específicos de uma porção independentemente do resto do parágrafo?**

Sim, cor, preenchimento e transparência do texto ao nível da [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) podem diferir dos fragmentos vizinhos.