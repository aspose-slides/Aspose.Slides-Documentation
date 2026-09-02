---
title: Gestionar conectores en presentaciones con Python
linktitle: Conector
type: docs
weight: 10
url: /es/python-net/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo de conector
- sitio de conexión
- punto de ajuste
- conectar formas
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo añadir, unir, reencaminar, ajustar e inspeccionar conectores rectos, doblados y curvados de PowerPoint con Aspose.Slides para Python mediante .NET."
---
## **Visión general**

Un conector es una línea que puede permanecer unida a dos formas cuando cualquiera de ellas se mueve. Sus extremos se conectan a sitios de conexión, representados por puntos verdes en PowerPoint. Algunos conectores doblados y curvados también exponen puntos de ajuste, representados por puntos naranjas, que controlan la posición de los segmentos individuales del conector.

Aspose.Slides representa los conectores mediante la interfaz [IConnector](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/). Puedes crearlos, unir sus extremos a formas, elegir sitios de conexión, reencaminarles y modificar la geometría de los conectores que tienen puntos de ajuste.

## **Tipos de conector**

La enumeración [ShapeType](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapetype/) incluye preajustes de conectores rectos, doblados y curvados. La tabla siguiente muestra las geometrías de conector disponibles y el número de puntos de ajuste definidos por cada preajuste.

| Conector | Imagen | Número de puntos de ajuste |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

El número y el significado de los puntos de ajuste forman parte del preajuste de conector seleccionado. No asumas que dos tipos de conector diferentes exponen la misma disposición de colección.

## **Conectar dos formas**

Utiliza [IShapeCollection.add_connector](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishapecollection/add_connector/) para añadir un conector y asigna sus propiedades [start_shape_connected_to](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/start_shape_connected_to/) y [end_shape_connected_to](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/end_shape_connected_to/). Después de que ambos extremos estén unidos, [IConnector.reroute](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/reroute/) selecciona una ruta corta entre las formas.

El siguiente ejemplo conecta una elipse y un rectángulo con un conector doblado:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Advertencia" %}}
Invocar `reroute` puede cambiar los valores de [start_shape_connection_site_index](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) y [end_shape_connection_site_index](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Asigna sitios de conexión específicos después de reencaminar si esos sitios deben permanecer fijos.
{{% /alert %}}

## **Elegir un sitio de conexión**

Cada forma que puede conectarse informa su número de sitios mediante [connection_site_count](https://reference.aspose.com/slides/es/python-net/aspose.slides/igeometryshape/connection_site_count/). Valida un índice de sitio preferido basado en cero antes de asignarlo a un extremo del conector; el número de sitios varía según la geometría de la forma.

Este ejemplo une el conector a un sitio concreto de la elipse cuando ese sitio existe:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar un punto de conector**

Los conectores con puntos de ajuste los exponen mediante [IGeometryShape.adjustments](https://reference.aspose.com/slides/es/python-net/aspose.slides/igeometryshape/adjustments/). Inspecciona cada [IAdjustValue](https://reference.aspose.com/slides/es/python-net/aspose.slides/iadjustvalue/) y comprueba su [type](https://reference.aspose.com/slides/es/python-net/aspose.slides/iadjustvalue/type/) antes de cambiar su [raw_value](https://reference.aspose.com/slides/es/python-net/aspose.slides/iadjustvalue/raw_value/). Para la manipulación general de formas, consulta [Shape Manipulation](/slides/es/python-net/shape-manipulations/).

El número, orden, significado y rango de valores válidos de los ajustes del conector dependen del preajuste del conector. La propiedad `type` es de solo lectura, mientras que el valor del ajuste es modificable. La propiedad de solo lectura [name](https://reference.aspose.com/slides/es/python-net/aspose.slides/iadjustvalue/name/) proporciona identificación adicional cuando un conector contiene más de un ajuste del mismo tipo semántico.

### **Ruta alrededor de un obstáculo**

En la siguiente disposición, un conector `ShapeType.BENT_CONNECTOR5` entre dos formas atraviesa una tercera forma:

![connector-obstruction](connector-obstruction.png)

Este código crea el conector obstruido:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Mover el doble vertical cambia la ruta de modo que el conector evita el obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

En lugar de asumir que el índice de colección `1` siempre representa el doble vertical, este ejemplo busca `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` y lo modifica solo cuando el tipo semántico esperado está presente:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Un `ShapeType.BENT_CONNECTOR5` tiene dos ajustes `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` y un ajuste `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Si el tipo que necesitas aparece más de una vez, inspecciona `name` y la geometría conocida de ese preajuste antes de seleccionar uno. Si un ajuste informa [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapeadjustmenttype/), trata su significado y rango como específicos del preajuste y no lo cambies hasta que ese contrato sea conocido.

## **Relacionar valores de ajuste con la geometría del conector**

Para conectores doblados, los valores de ajuste pueden usarse para estimar las posiciones de los segmentos individuales. Estos cálculos son específicos del preajuste del conector:

- `ShapeType.BENT_CONNECTOR4` normalmente expone un ajuste `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` y uno `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Para estas posiciones de doble, `raw_value / 100000` produce la fracción del ancho o alto del marco del conector utilizada en los ejemplos siguientes.
- Un marco de conector puede rotarse o voltearse, por lo que las coordenadas del marco deben transformarse antes de compararse con las coordenadas de la diapositiva.

Los siguientes ejemplos usan `type` para identificar primero los ajustes. No tratan los índices de colección como identificadores portables.

### **Conector sin rotar**

La disposición inicial contiene dos formas de texto conectadas mediante un `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Este ejemplo inspecciona el conector y obtiene sus ajustes de doble horizontal y vertical:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Para cambiar ambos dobles, localiza cada tipo esperado y modifica los valores solo después de haber encontrado ambos:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

El resultado es un conector cuyas secciones horizontal y vertical se han desplazado:

![connector-adjusted-1](connector-adjusted-1.png)

Una vez conocidos los tipos semánticos, sus valores pueden convertirse en coordenadas del marco del conector. Este ejemplo dibuja un rectángulo delgado sobre el segmento vertical controlado por los dos ajustes de doble:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

La forma guía marca el segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector girado o volteado**

Cuando la misma geometría de conector se orienta verticalmente, sus valores de [frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishapeframe/flip_h/) y [flip_v](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishapeframe/flip_v/) afectan la conversión de coordenadas del marco del conector a coordenadas de la diapositiva.

Este ejemplo crea y ajusta el conector orientado verticalmente:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

El conector ajustado aparece verticalmente entre las formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para un ángulo de rotación arbitrario `alpha`, rota un punto del marco del conector `(x, y)` alrededor del centro del marco `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

El siguiente código maneja la orientación de 90 grados utilizada en este ejemplo y dibuja una guía roja sobre el segmento correspondiente del conector:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

La guía roja marca el segmento calculado después de la transformación de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Estas fórmulas describen los preajustes usados en los ejemplos, no un modelo universal de conector. Valida los tipos de ajuste, la orientación del marco y los rangos de valores antes de aplicar el mismo cálculo a un preajuste diferente.

## **Encontrar el ángulo de dirección de un conector**

La dirección de un conector recto puede calcularse a partir de su ancho y alto, aplicando volteos horizontales y verticales. El siguiente ejemplo informa el ángulo en sentido horario desde el eje horizontal positivo en coordenadas de la diapositiva:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un conector puede unirse a una forma?**  
Comprueba el [connection_site_count](https://reference.aspose.com/slides/es/python-net/aspose.slides/igeometryshape/connection_site_count/) de la forma. Un recuento positivo indica que la forma expone sitios de conexión. Valida el índice del sitio seleccionado antes de asignarlo a cualquiera de los extremos del conector.

**¿Puedo identificar un ajuste de conector por su índice de colección?**  
Un índice tiene sentido solo para un preajuste de conector conocido y una disposición de colección específica. Verifica [IAdjustValue.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/iadjustvalue/type/) antes de modificar un valor, y usa [IAdjustValue.name](https://reference.aspose.com/slides/es/python-net/aspose.slides/iadjustvalue/name/) como información adicional cuando el mismo tipo semántico ocurre más de una vez.

**¿Qué ocurre cuando se elimina una forma conectada?**  
El extremo del conector correspondiente queda desacoplado. El conector permanece en la diapositiva y puede eliminarse, posicionarse como una línea libre o volver a unirse a otra forma.

**¿Se conservan los enlaces del conector cuando se copia una diapositiva?**  
Los enlaces generalmente se conservan cuando las formas conectadas se copian con la diapositiva. Si se copia un conector sin una de sus formas objetivo, el extremo afectado deberá volver a unirse.