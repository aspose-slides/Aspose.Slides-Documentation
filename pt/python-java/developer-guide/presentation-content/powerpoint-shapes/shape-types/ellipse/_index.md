---
title: Adicionar Elipses a Apresentações em Python via Java
linktitle: Elipse
type: docs
weight: 30
url: /pt/python-java/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como criar, formatar e manipular formas elípticas no Aspose.Slides para Python via Java em apresentações PPT e PPTX—exemplos de código Python incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas elípticas a slides do PowerPoint usando Aspose.Slides. Ele aborda a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda questões relacionadas, como trabalhar com a posição e tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar uma Elipse**

Para adicionar uma elipse simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Obtenha uma referência a um slide pelo seu índice.
- Adicione uma elipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) do objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Grave a apresentação modificada como um arquivo PPTX.

O exemplo a seguir adiciona uma elipse ao primeiro slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanciar a classe Presentation que representa o arquivo PPTX.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma de elipse.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Gravar o arquivo PPTX no disco.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Criar uma Elipse Formatada**

Para adicionar uma elipse formatada a um slide, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Obtenha uma referência a um slide pelo seu índice.
- Adicione uma elipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) do objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Defina o tipo de preenchimento da elipse como sólido.
- Defina a cor de preenchimento da elipse através de [getSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getSolidFillColor) no objeto [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) associado ao objeto [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/).
- Defina a cor do contorno da elipse.
- Defina a espessura do contorno da elipse.
- Grave a apresentação modificada como um arquivo PPTX.

O exemplo a seguir adiciona uma elipse formatada ao primeiro slide da apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa o arquivo PPTX.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma de elipse.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Formatar o preenchimento da elipse.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Formatar o contorno da elipse.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Gravar o arquivo PPTX no disco.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Como definir a posição e o tamanho exatos de uma elipse em relação às unidades do slide?**

As coordenadas e os tamanhos são tipicamente especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta os milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como posicionar uma elipse acima ou abaixo de outros objetos (controlar a ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo‑o para a frente ou enviando‑o para trás. Isso permite que a elipse sobreponha outros objetos ou revele aqueles que estão abaixo dela.

**Como animar a aparição ou ênfase de uma elipse?**

[Aplicar](/slides/pt/python-java/shape-animation/) efeitos de entrada, ênfase ou saída à forma, e configure gatilhos e temporização para orquestrar quando e como a animação será executada.