---
title: "Gestionar conectores en presentaciones en Python mediante Java"
linktitle: "Conector"
type: docs
weight: 10
url: /es/python-java/connector/
keywords:
- conector
- tipo de conector
- punto del conector
- línea de conector
- ángulo del conector
- sitio de conexión
- punto de ajuste
- conectar formas
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a añadir, unir, volver a trazar, ajustar e inspeccionar conectores rectos, doblados y curvos de PowerPoint con Aspose.Slides para Python mediante Java."
---
## **Visión general**

Un conector es una línea que puede permanecer unida a dos formas cuando cualquiera de ellas se mueve. Sus extremos se conectan a sitios de conexión, representados por puntos verdes en PowerPoint. Algunos conectores doblados y curvos también exponen puntos de ajuste, representados por puntos naranjas, que controlan la posición de los segmentos individuales del conector.

Aspose.Slides representa los conectores mediante la clase [Connector](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/). Puede crear‑los, unir sus extremos a formas, elegir sitios de conexión, volver a trazarlos y modificar la geometría de los conectores que tienen puntos de ajuste.

## **Tipos de conector**

La clase [ShapeType](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/) incluye predefinidos de conectores rectos, doblados y curvos. La tabla siguiente muestra las geometrías de conector disponibles y el número de puntos de ajuste definidos por cada predefinido.

| Conector | Imagen | Número de puntos de ajuste |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

El número y el significado de los puntos de ajuste forman parte del predefinido de conector seleccionado. No asuma que dos tipos de conector diferentes exponen la misma disposición de la colección.

## **Conectar dos formas**

Utilice [ShapeCollection.addConnector](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addConnector) para añadir un conector, y utilice [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/#setStartShapeConnectedTo) y [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/#setEndShapeConnectedTo) para unir sus extremos. Después de que ambos extremos estén unidos, [Connector.reroute](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/#reroute) selecciona una ruta corta entre las formas.

El siguiente ejemplo conecta una elipse y un rectángulo con un conector doblado:

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

{{% alert color="warning" title="Warning" %}}
Llamar a [reroute](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/#reroute) puede cambiar los valores de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) y [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Asigne sitios de conexión específicos después de volver a trazar si esos sitios deben permanecer fijos.
{{% /alert %}}

## **Elegir un sitio de conexión**

Cada forma conectable informa su número de sitios mediante [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getConnectionSiteCount). Valide un índice de sitio basado en cero antes de asignarlo a un extremo del conector; el recuento de sitios varía según la geometría de la forma.

Este ejemplo une el conector a un sitio concreto de la elipse cuando ese sitio existe:

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

## **Ajustar un punto del conector**

Los conectores con puntos de ajuste los exponen a través de [GeometryShape.getAdjustments](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#getAdjustments). Examine cada [AdjustValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/) y compruebe su valor de [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType) antes de modificarlo con [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue). Las reglas generales para identificar los ajustes predefinidos de forma se describen en [Manipulación de formas](/slides/es/python-java/shape-manipulations/).

El número, orden, significado y rango de valores válidos de los ajustes dependen del predefinido del conector. El tipo de ajuste es de solo lectura, mientras que el valor del ajuste es modificable. El método de solo lectura [getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName) proporciona identificación adicional cuando un conector contiene más de un ajuste del mismo tipo semántico.

### **Rutar alrededor de un obstáculo**

En el diseño siguiente, un [BentConnector5](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector5) entre dos formas pasa a través de una tercera forma:

![connector-obstruction](connector-obstruction.png)

Este código crea el conector obstruido:

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

Mover el doblez vertical cambia la ruta de modo que el conector evite el obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

En lugar de suponer que el índice de colección `1` siempre representa el doblez vertical, este ejemplo busca [ConnectorBendPositionY](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) y lo cambia sólo cuando el tipo semántico esperado está presente:

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

Un [BentConnector5](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector5) tiene dos ajustes [ConnectorBendPositionX](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) y uno [ConnectorBendPositionY](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Si el tipo que necesita aparece más de una vez, inspeccione [getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName) y la geometría conocida de ese predefinido antes de seleccionar uno. Si un ajuste devuelve [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#Custom), trate su significado y rango como específicos del predefinido y no lo modifique hasta que ese contrato sea conocido.

## **Relacionar valores de ajuste con la geometría del conector**

Para los conectores doblados, los valores de ajuste pueden usarse para estimar las posiciones de los segmentos individuales. Estos cálculos son específicos del predefinido del conector:

- [BentConnector4](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector4) normalmente expone un ajuste [ConnectorBendPositionX](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) y uno [ConnectorBendPositionY](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Para estas posiciones de doblez, dividir el valor devuelto por [getRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getRawValue) entre `100000.0` produce la fracción del ancho o alto del marco del conector utilizada en los ejemplos siguientes.
- Un marco de conector puede estar rotado o volteado, por lo que las coordenadas del marco deben transformarse antes de compararse con las coordenadas de la diapositiva.

Los siguientes ejemplos usan [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType) para identificar primero los ajustes. No tratan los índices de colección como identificadores portátiles.

### **Conector sin rotar**

El diseño inicial contiene dos formas de texto conectadas por un [BentConnector4](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Este ejemplo inspecciona el conector y obtiene sus ajustes de doblez horizontal y vertical:

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

Para cambiar ambos dobleces, localice cada tipo esperado y modifique los valores sólo después de haber encontrado ambos:

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

El resultado es un conector cuyos segmentos horizontales y verticales se han desplazado:

![connector-adjusted-1](connector-adjusted-1.png)

Una vez que se conocen los tipos semánticos, sus valores pueden convertirse en coordenadas del marco del conector. Este ejemplo dibuja un rectángulo delgado sobre el segmento vertical controlado por los dos ajustes de doblez:

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

La forma guía marca el segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotado o volteado**

Cuando la misma geometría de conector se orienta verticalmente, sus valores de [Shape.getFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeframe/#getFlipH) y [ShapeFrame.getFlipV](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeframe/#getFlipV) influyen en la conversión de coordenadas del marco del conector a coordenadas de la diapositiva.

Este ejemplo crea y ajusta el conector orientado verticalmente:

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

El conector ajustado aparece verticalmente entre las formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para un ángulo de rotación arbitrario `alpha`, rote un punto del marco del conector `(x, y)` alrededor del centro del marco `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

El siguiente código maneja la orientación de 90 grados utilizada en este ejemplo y dibuja una guía roja sobre el segmento correspondiente del conector:

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

La guía roja marca el segmento calculado tras la transformación de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Estas fórmulas describen los predefinidos usados en los ejemplos, no un modelo universal de conector. Valide los tipos de ajuste, la orientación del marco y los rangos de valores antes de aplicar el mismo cálculo a otro predefinido.

## **Encontrar el ángulo de dirección de un conector**

La dirección de un conector recto puede calcularse a partir de su ancho y alto, aplicando los volteos horizontales y verticales. El siguiente ejemplo muestra el ángulo en sentido horario a partir del eje horizontal positivo en coordenadas de diapositiva:

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

## **FAQ**

**¿Cómo puedo saber si un conector puede unirse a una forma?**

Compruebe el valor de [getConnectionSiteCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getConnectionSiteCount) de la forma. Un recuento positivo indica que la forma expone sitios de conexión. Valide el índice de sitio seleccionado antes de asignarlo a cualquiera de los extremos del conector.

**¿Puedo identificar un ajuste de conector por su índice de colección?**

Un índice tiene sentido solo para un predefinido de conector y disposición de colección conocidos. Consulte [AdjustValue.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType) antes de modificar un valor, y use [AdjustValue.getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName) como información adicional cuando el mismo tipo semántico ocurra más de una vez.

**¿Qué ocurre cuando se elimina una forma conectada?**

El extremo correspondiente del conector queda desacoplado. El conector permanece en la diapositiva y puede eliminarse, posicionarse como una línea libre o unirse a otra forma.

**¿Se conservan los enlaces del conector cuando se copia una diapositiva?**

Los enlaces se conservan generalmente cuando las formas conectadas se copian junto con la diapositiva. Si se copia un conector sin alguna de sus formas objetivo, el extremo afectado deberá volver a unirse.