---
title: Adicionar formas de linha a apresentações em Python via Java
linktitle: Linha
type: docs
weight: 50
url: /pt/python-java/line/
keywords:
- linha
- criar linha
- adicionar linha
- linha simples
- configurar linha
- personalizar linha
- estilo de tracejado
- ponta de seta
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint com Aspose.Slides para Python via Java. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

Aspose.Slides permite adicionar formas de linha a slides do PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos focam em configurações práticas de formatação de linha, como estilo, largura, padrão de tracejado, opções de ponta de seta e cor de preenchimento.

## **Criar uma linha simples**

Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) classe.
- Obtenha uma referência a um slide pelo seu índice.
- Adicione uma forma de linha usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) da objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Grave a apresentação modificada como um arquivo PPTX.

O exemplo a seguir adiciona uma linha ao primeiro slide da apresentação:

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

    # Adicionar uma forma de linha.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Gravar o arquivo PPTX no disco.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Criar uma linha em forma de seta**

Aspose.Slides for Python via Java também permite que os desenvolvedores configurem propriedades de linha para tornar uma linha mais atraente. Para configurar uma linha para que pareça uma seta, siga os passos abaixo:

- Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) classe.
- Obtenha uma referência a um slide pelo seu índice.
- Adicione uma forma de linha usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) da objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Defina o [line style](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linestyle/) para um dos estilos oferecidos pelo Aspose.Slides for Python via Java.
- Defina a largura da linha.
- Defina o [dash style](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linedashstyle/) para um dos estilos oferecidos pelo Aspose.Slides for Python via Java.
- Defina o [arrowhead style](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linearrowheadstyle/) e o [length](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linearrowheadlength/) no início da linha.
- Defina o [arrowhead style](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linearrowheadstyle/) e o [length](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linearrowheadlength/) no final da linha.
- Grave a apresentação modificada como um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instanciar a classe Presentation que representa o arquivo PPTX.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma de linha.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Aplicar formatação à linha.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Gravar o arquivo PPTX no disco.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso converter uma linha regular em um conector para que ela “encaixe” nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/)) não se torna automaticamente um conector. Para fazer com que ela encaixe nas formas, use o tipo [Connector](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/) dedicado e as [APIs correspondentes](/slides/pt/python-java/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha forem herdadas do tema e for difícil determinar os valores finais?**

[Leia as propriedades efetivas](/slides/pt/python-java/shape-effective-properties/) da linha e de seu preenchimento — elas já levam em conta a herança e os estilos do tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As formas fornecem [objetos de bloqueio](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#getAutoShapeLock) que permitem [negar operações de edição](/slides/pt/python-java/applying-protection-to-presentation/).