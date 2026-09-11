---
title: Gerenciar Conectores em Apresentações em Python via Java
linktitle: Conector
type: docs
weight: 10
url: /pt/python-java/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo do conector
- ponto de conexão
- ponto de ajuste
- conectar formas
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como adicionar, anexar, reencaminhar, ajustar e inspecionar conectores retos, dobrados e curvos do PowerPoint com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um conector é uma linha que pode permanecer anexada a duas formas quando qualquer forma se move. Suas extremidades se conectam a sites de conexão, representados por pontos verdes no PowerPoint. Alguns conectores dobrados e curvos também expõem pontos de ajuste, representados por pontos laranja, que controlam a posição de segmentos individuais do conector.

Aspose.Slides representa conectores através da classe [Connector](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/) . Você pode criá-los, anexar suas extremidades a formas, escolher sites de conexão, reencaminhá‑los e modificar a geometria de conectores que possuem pontos de ajuste.

## **Tipos de Conector**

A classe [ShapeType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/) inclui predefinições de conectores retos, dobrados e curvos. A tabela a seguir mostra as geometrias de conectores disponíveis e o número de pontos de ajuste definidos por cada predefinição.

| Conector | Imagem | Número de pontos de ajuste |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

O número e o significado dos pontos de ajuste fazem parte da predefinição de conector selecionada. Não presuma que dois tipos diferentes de conector expõem a mesma estrutura de coleção.

## **Conectar duas formas**

Use [ShapeCollection.addConnector](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addConnector) para adicionar um conector e use [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/#setStartShapeConnectedTo) e [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/#setEndShapeConnectedTo) para anexar suas extremidades. Após ambas as extremidades serem anexadas, [Connector.reroute](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/#reroute) seleciona uma rota curta entre as formas.

O exemplo a seguir conecta uma elipse e um retângulo com um conector dobrado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Aviso" %}}
Chamar [reroute](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/#reroute) pode alterar os valores de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) e [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Atribua sites de conexão específicos após o reencaminhamento se esses sites precisarem permanecer fixos.
{{% /alert %}}

## **Escolher um ponto de conexão**

Cada forma conectável relata seu número de sites por meio de [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getConnectionSiteCount). Valide um índice de site baseado em zero antes de atribuí‑lo a uma extremidade de conector; a contagem de sites varia conforme a geometria da forma.

Este exemplo anexa o conector a um site específico na elipse quando esse site existe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajustar um ponto de conector**

Conectores com pontos de ajuste os expõem por meio de [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pt/python-java/aspose.slides/geometryshape/#getAdjustments). Inspecione cada [AdjustValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/) e verifique seu valor de [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType) antes de alterá‑lo com [setRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#setRawValue). As regras gerais para identificar ajustes de forma predefinidos são descritas em [Manipulação de Forma](/slides/pt/python-java/shape-manipulations/).

O número, a ordem, o significado e a faixa de valores válidos dos ajustes de conector dependem da predefinição do conector. O tipo de ajuste é somente leitura, enquanto o valor do ajuste pode ser escrito. O método somente‑leitura [getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName) fornece identificação adicional quando um conector contém mais de um ajuste do mesmo tipo semântico.

### **Roteiro ao redor de um obstáculo**

No layout a seguir, um conector [BentConnector5](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector5) entre duas formas passa por uma terceira forma:

![connector-obstruction](connector-obstruction.png)

Este código cria o conector obstruído:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mover a dobra vertical altera a rota de modo que o conector contorne o obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Em vez de presumir que o índice da coleção `1` sempre representa a dobra vertical, este exemplo procura por [ConnectorBendPositionY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) e o altera somente quando o tipo semântico esperado está presente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um [BentConnector5](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector5) possui duas ajustes [ConnectorBendPositionX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) e um ajuste [ConnectorBendPositionY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Se o tipo que você precisa ocorre mais de uma vez, inspecione [getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName) e a geometria conhecida dessa predefinição antes de escolher um. Se um ajuste relata [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#Custom), trate seu significado e faixa como específicos da predefinição e não o altere até que esse contrato seja conhecido.

## **Relacionar valores de ajuste à geometria do conector**

Para conectores dobrados, os valores de ajuste podem ser usados para estimar as posições de segmentos individuais. Esses cálculos são específicos da predefinição do conector:

- [BentConnector4](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector4) normalmente expõe um ajuste [ConnectorBendPositionX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) e um ajuste [ConnectorBendPositionY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Para essas posições de dobra, dividir o valor retornado por [getRawValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getRawValue) por `100000.0` produz a fração da largura ou altura da moldura do conector usada nos exemplos abaixo.
- Uma moldura de conector pode ser rotacionada ou invertida, portanto as coordenadas da moldura precisam ser transformadas antes de serem comparadas com as coordenadas do slide.

Os exemplos a seguir utilizam [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType) para identificar primeiro os ajustes. Eles não tratam índices de coleção como identificadores portáteis.

### **Conector não rotacionado**

O layout inicial contém duas formas de texto conectadas por um [BentConnector4](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Este exemplo inspeciona o conector e obtém seus ajustes de dobra horizontal e vertical:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Para alterar ambas as dobras, localize cada tipo esperado e modifique os valores somente depois que ambos forem encontrados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado é um conector cujos segmentos horizontal e vertical foram movidos:

![connector-adjusted-1](connector-adjusted-1.png)

Uma vez conhecidos os tipos semânticos, seus valores podem ser convertidos em coordenadas da moldura do conector. Este exemplo desenha um retângulo fino sobre o segmento vertical controlado pelos dois ajustes de dobra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A forma guia indica o segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotacionado ou invertido**

Quando a mesma geometria de conector é orientada verticalmente, seus valores [Shape.getFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeframe/#getFlipH) e [ShapeFrame.getFlipV](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapeframe/#getFlipV) afetam a conversão de coordenadas da moldura do conector para coordenadas do slide.

Este exemplo cria e ajusta o conector orientado verticalmente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O conector ajustado aparece verticalmente entre as formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para um ângulo de rotação arbitrário `alpha`, rode um ponto da moldura do conector `(x, y)` em torno do centro da moldura `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

O código a seguir trata a orientação de 90 graus usada neste exemplo e desenha um guia vermelho sobre o segmento correspondente do conector:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O guia vermelho indica o segmento calculado após a transformação das coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Essas fórmulas descrevem as predefinições usadas nos exemplos, não um modelo universal de conector. Valide os tipos de ajuste, a orientação da moldura e as faixas de valor antes de aplicar o mesmo cálculo a outra predefinição.

## **Encontrar o ângulo de direção do conector**

A direção de um conector reto pode ser calculada a partir de sua largura e altura, com inversões horizontal e vertical aplicadas. O exemplo a seguir relata o ângulo horário a partir do eixo horizontal positivo nas coordenadas do slide:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Como saber se um conector pode ser anexado a uma forma?**

Verifique o valor de [getConnectionSiteCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getConnectionSiteCount) da forma. Uma contagem positiva indica que a forma expõe sites de conexão. Valide o índice do site selecionado antes de atribuí‑lo a qualquer extremidade do conector.

**Posso identificar um ajuste de conector pelo seu índice na coleção?**

Um índice é significativo apenas para uma predefinição de conector conhecida e sua estrutura de coleção. Verifique [AdjustValue.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getType) antes de modificar um valor e use [AdjustValue.getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/adjustvalue/#getName) como informação adicional quando o mesmo tipo semântico ocorre mais de uma vez.

**O que acontece quando uma forma conectada é excluída?**

A extremidade correspondente do conector se desanexa. O conector permanece no slide e pode ser excluído, posicionado como linha livre ou anexado a outra forma.

**As ligações de conector são preservadas quando um slide é copiado?**

As ligações são geralmente preservadas quando as formas conectadas são copiadas junto com o slide. Se um conector for copiado sem uma de suas formas‑alvo, a extremidade afetada deve ser anexada novamente.