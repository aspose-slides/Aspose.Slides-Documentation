---
title: Formatear formas de PowerPoint en Python
linktitle: Formato de forma
type: docs
weight: 20
url: /es/python-net/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto boceto
- línea de forma boceto
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- renderizado de forma en blanco y negro
- renderizado de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en Python usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

Formatea formas en PowerPoint ajustando sus contornos, rellenos y efectos. Aspose.Slides for Python via .NET le permite controlar estos ajustes de forma programática, incluyendo transparencia, rotación y formato 3D.

![Opciones de formato de formas en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET proporciona clases y propiedades que le permiten formatear formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Utilice [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) para controlar el contorno de una forma. Este ejemplo crea un rectángulo sin relleno con un contorno azul y discontinuo. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) selecciona una línea compuesta gruesa‑delgada, mientras que [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) establece su ancho en 7 puntos y [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) selecciona el patrón de guiones.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

### **Establecer patrones de guiones de línea personalizados**

Utilice [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) cuando los estilos de línea predefinidos no proporcionan las longitudes de guiones y espacios que necesita, por ejemplo para contornos de marca o diagramas técnicos. Asignar un patrón establece automáticamente [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) en [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Las entradas de la lista alternan entre longitudes de guión y de espacio, comenzando con un guión. Cada valor es un múltiplo del ancho de la línea: `[4, 2]` con un ancho de 3 puntos produce un guión de 12 puntos seguido de un espacio de 6 puntos. Utilice pares de valores finitos y no negativos para definir segmentos completos de guión‑y‑espacio. El ejemplo usa valores positivos para que cada guión y espacio sean visibles.

Este ejemplo crea cinco líneas azules con la misma longitud y extremos planos. Las tres primeras comparan patrones con un ancho de 3 puntos. La cuarta repite el primer patrón con el doble de ancho, duplicando tanto la longitud del guión como del espacio. La quinta cambia de un patrón personalizado a una línea sólida.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Restablecer la última línea a un estilo sólido.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Para volver a un estilo discontinuo predefinido, asigne [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). El estilo seleccionado controla la apariencia de la línea.

El resultado en PowerPoint, de arriba a abajo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; y **Solid, 3 pt**.

![Tres patrones de guiones personalizados, una línea más ancha usando el primer patrón y una línea sólida en PowerPoint](custom-dash-patterns.png)

### **Establecer extremos de línea**

Utilice [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) para establecer los extremos de una línea abierta. La enumeración [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) proporciona tres estilos de extremo explícitos:

- `FLAT`: El trazo se detiene en el punto final.
- `ROUND`: Un extremo semicircular se extiende más allá del punto final en medio ancho de línea.
- `SQUARE`: Un extremo cuadrado se extiende más allá del punto final en medio ancho de línea.

La enumeración también incluye `NOT_DEFINED`, que significa que no se asigna un estilo de extremo explícitamente.

Los extremos son diferentes de las puntas de flecha, que añaden símbolos a los extremos de la línea, y de las uniones, que controlan las esquinas entre segmentos de línea. Este ejemplo desactiva las puntas de flecha mediante [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) y [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) para que solo se comparen las formas de los extremos.

El siguiente ejemplo crea tres líneas horizontales idénticas, de 20 puntos de ancho. De arriba a abajo, utilizan extremos plano, redondo y cuadrado. Sus puntos finales tienen las mismas coordenadas horizontales; los extremos redondos y cuadrados se extienden 10 puntos más allá de cada punto final.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

El resultado en PowerPoint, de arriba a abajo: **Flat**, **Round**, y **Square**.

![Extremos plano, redondo y cuadrado en líneas gruesas idénticas en PowerPoint](line-caps.png)

## **Aplicar efectos de boceto a las líneas de forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utilice [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) para acceder a la configuración de la línea, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) para acceder a la configuración del boceto y [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

El siguiente código Python muestra cómo aplicar un efecto [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

El valor devuelto por [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) representa la configuración asignada directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, utilice [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), acceda a [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), y lea [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia. Este ejemplo requiere una presentación existente con al menos una forma en su primera diapositiva y muestra ambos valores:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

El estilo de unión controla cómo se encuentran dos segmentos de contorno en una esquina. Use **Redondo** para esquinas redondeadas, **Inglete** para esquinas afiladas o **Bisel** para esquinas aplanadas.

![El estilo de unión en la presentación](join-style-powerpoint.png)

Este ejemplo crea tres rectángulos negros con contornos azules de 15 puntos de ancho. Establece [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) en los valores de inglete, bisel y redondo de [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), respectivamente, para comparar cómo se dibujan las esquinas.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Limitar uniones de inglete en esquinas agudas**

Utilice [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) con [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) establecido en [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) para limitar hasta dónde puede extenderse una esquina aguda.

El límite es una proporción entre la distancia entre las esquinas interna y externa de la unión y el ancho de la línea. Por ejemplo, un valor de `8` permite una longitud de inglete de hasta ocho veces el ancho de la línea; no es una medida en puntos. Si la esquina excede el límite, PowerPoint utiliza una unión biselada en esa esquina. Un límite mayor permite puntos más agudos. La configuración afecta solo a las uniones de inglete y cambiarla no tiene efecto visible cuando la esquina se mantiene dentro de ambos límites.

Este ejemplo crea dos triángulos idénticos sin relleno con contornos de 20 puntos de ancho. El triángulo izquierdo usa un límite de `2` y el derecho `8`. Cada triángulo mide 80 puntos de ancho y 160 puntos de alto, lo que da a su esquina superior una proporción de longitud‑de‑inglete a ancho de línea de aproximadamente `4.12`. En consecuencia, PowerPoint bisela la cúspide izquierda y mantiene la derecha.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

El resultado en PowerPoint: **Límite de inglete 2** a la izquierda y **límite de inglete 8** a la derecha.

![Una cúspide biselada con límite de inglete 2 y una cúspide puntiaguda con límite de inglete 8 en PowerPoint](miter-limits.png)

## **Relleno de degradado**

Un relleno de degradado mezcla colores a lo largo de una forma. Este ejemplo rellena una elipse con un degradado lineal en ángulo de 45 grados de rojo a púrpura usando [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). El método [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) coloca los puntos de color en 0 y 1, el inicio y el final del degradado. Eliminar los puntos existentes garantiza que solo se usen estos dos colores.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La elipse con relleno de degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulte [Choose a Gradient Rendering Style](/slides/es/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puede seleccionar un estilo de renderizado sin cambiar el relleno de degradado almacenado en la presentación.

### **Establecer el ángulo del degradado lineal**

Utilice [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) para controlar la orientación de un relleno [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). El ángulo se mide en grados y aumenta en sentido horario: `0` va de izquierda a derecha, `90` de arriba a abajo, `180` de derecha a izquierda y `270` de abajo a arriba. Se admiten ángulos fraccionarios. Los ángulos finitos fuera del rango `[0, 360)` se normalizan a una revolución; por ejemplo, `-45` se convierte en `315` y `360` en `0`.

Este ejemplo crea seis rectángulos con paradas de rojo, verde y azul idénticas en las posiciones `0`, `0.5` y `1`. El escalado está desactivado para que el ángulo pueda compararse independientemente de las proporciones de los rectángulos. Los ángulos, de izquierda a derecha, son `0`, `45` y `90` en la primera fila, y `135`, `180` y `270` en la segunda fila.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

El resultado en PowerPoint:

![Degradados lineales a 0, 45 y 90 grados en la fila superior, y a 135, 180 y 270 grados en la fila inferior](linear-gradient-angles.png)

### **Escalar un degradado lineal con la forma**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) acepta un valor [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Establézcalo explícitamente en `FALSE` para mantener el ángulo geométrico del degradado cuando cambian las proporciones de la forma, o en `TRUE` para escalar el degradado con el ancho y la altura de la forma. Con el escalado activado, el ángulo visible puede diferir del ángulo asignado en una forma no cuadrada.

El siguiente ejemplo usa un ángulo de `45` grados y las mismas paradas de color que la comparación de ángulos. La columna izquierda usa `FALSE`; la derecha usa `TRUE`. Cada columna contiene un rectángulo ancho encima de un rectángulo alto. Ambos comienzan con las mismas dimensiones anchas; cambiar el ancho y la altura del segundo rectángulo muestra cómo el relleno responde al redimensionado sin cambiar sus ajustes de degradado.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

El resultado en PowerPoint, con el escalado desactivado a la izquierda y activado a la derecha:

![Rectángulos anchos y altos con un degradado de 45 grados, comparando linear_gradient_scaled FALSE a la izquierda con TRUE a la derecha](linear-gradient-scaling.png)

Con el escalado desactivado, las bandas de color diagonal mantienen la misma orientación en ambos rectángulos. Con el escalado activado, las bandas se estiran con las proporciones de la forma. Esto ayuda a reproducir el degradado de una plantilla al adaptar una forma a un tamaño diferente. En un cuadrado, activar el escalado no cambia la apariencia de este degradado de `45` grados.

Ambos ajustes, ángulo y escalado, se aplican a los degradados lineales. No controlan los rellenos [GradientShape.RADIAL o GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Combinar el ángulo con la dirección del degradado**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) selecciona un estilo de degradado de la enumeración [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); no es un sustituto de un ángulo numérico. Para un degradado lineal, los estilos de esquina pueden cambiar el área sobre la que se distribuyen los colores sin cambiar [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Mantenga la dirección sin cambios al comparar ángulos o escalado.

El siguiente ejemplo aplica los mismos ajustes en orden inverso. Los dos rectángulos tienen la misma apariencia: asignar la dirección antes o después del ángulo no cambia el resultado.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Relleno de patrón**

Un relleno de patrón aplica un diseño bicolórico, como puntos, rayas o cuadros. Este ejemplo usa [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) para seleccionar un patrón de celosía. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) aporta el fondo gris claro y [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) el color amarillo del patrón.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

Un relleno de imagen usa una imagen dentro de una forma. Este ejemplo requiere una imagen local y utiliza [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) para cargarla en la colección de imágenes de la presentación. Establecer [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) en el modo mosaico repite la imagen dentro del rectángulo. La imagen fuente utilizada aquí se muestra a continuación:

![La imagen de loto](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![La forma con relleno de imagen](picture-fill.png)

### **Mosaico de imagen como textura**

Si desea establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puede usar las siguientes propiedades de la clase [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- `[picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)`: Establece el modo de relleno de imagen — `TILE` o `STRETCH`.
- `[tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/)`: Especifica la alineación de los mosaicos dentro de la forma.
- `[tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/)`: Controla si el mosaico se voltea horizontalmente, verticalmente o ambos.
- `[tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/)`: Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- `[tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/)`: Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- `[tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/)`: Define la escala horizontal del mosaico como porcentaje.
- `[tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/)`: Define la escala vertical del mosaico como porcentaje.

Este ejemplo requiere una imagen local y configura [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) para repetirla al 50 % de su tamaño original. Desplazamientos de −32 puntos desplazan los mosaicos horizontal y verticalmente; la alineación inferior‑derecha y el volteo en ambas direcciones determinan cómo se dispone la textura repetida.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

Un relleno sólido otorga a una forma un color único y uniforme. Este ejemplo establece [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) en el modo de relleno sólido y asigna amarillo mediante [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), luego guarda el rectángulo en una presentación.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![La forma con relleno de color sólido](solid-color-fill.png)

### **Copiar colores preservando referencias de tema**

Utilice [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) para copiar una definición de color, incluyendo su tipo de color, referencia de tema y transformaciones. Esto es útil al transferir un color de relleno entre formas que deben seguir el tema de la presentación. El método copia solo el color: no copia el tipo de relleno, contorno u otro formato de forma. Establezca explícitamente el [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) del destino.

Este ejemplo crea tres rectángulos, de izquierda a derecha: el origen, una copia consciente del tema y una copia RGB fija. El origen usa [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) para referenciar el primer color de acento y añade un tinte mediante [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). La copia RGB usa el color de relleno efectivo del origen, por lo que los tres inicialmente se ven idénticos. Asignar [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) establece un valor RGB fijo y elimina cualquier transformación de color existente.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Las referencias de tema siguen el nuevo color de acento; el valor RGB fijo no lo hace.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Antes del cambio de tema, los tres rellenos coinciden:

![Origen, destino copy_from y destino RGB fijo con rellenos azules idénticos](color-copy-before.png)

Después del cambio de tema, el origen y la copia consciente del tema siguen el nuevo color de acento y conservan su tinte. La copia RGB fija permanece azul:

![Origen y destino copy_from con rellenos naranjas, mientras el destino RGB fijo permanece azul](color-copy-after.png)

La definición copiada es independiente del origen. Cambiar posteriormente la referencia de tema del origen, asignar otro color o añadir o eliminar sus transformaciones no afecta al destino. Un cambio de tema sigue afectando a ambas formas porque cada una hace referencia de forma independiente al mismo color del tema.

Al guardar y volver a abrir el PPTX se conserva el [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), la referencia de tema y la colección [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/); no aplana la definición a RGB.

Al copiar entre diferentes contextos de tema, como presentaciones con paletas de acento distintas, la referencia copiada se resuelve con respecto al tema del destino. La misma referencia y transformaciones pueden, por tanto, producir un color visible diferente. Consulte [Presentation Theme](/slides/es/python-net/presentation-theme/) para obtener más información sobre la configuración de colores de tema.

## **Usar el fondo de la diapositiva como relleno de forma**

Utilice [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) cuando una forma debe coincidir con el fondo de la diapositiva, por ejemplo en una plantilla de presentación. Establezca primero [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) en [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) para eliminar cualquier relleno explícito. Con esta combinación, la forma usa el fondo de la diapositiva en lugar de su relleno de estilo. Activar solo la bandera no elimina un relleno explícito existente.

Esto difiere de [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): el relleno de fondo cubre los objetos detrás de la forma con el área correspondiente del fondo de la diapositiva, mientras que sin relleno esos objetos permanecen visibles. Un degradado permanece alineado con la diapositiva en lugar de reiniciarse dentro de cada forma.

El siguiente ejemplo crea un fondo maestro heredado por la diapositiva y coloca una banda magenta detrás de tres rectángulos. El rectángulo izquierdo usa el fondo, el rectángulo central sin relleno y el rectángulo derecho cambia de relleno de fondo a un relleno naranja explícito.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Heredar el degradado del maestro.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Añadir este objeto primero para que aparezca detrás de los rectángulos.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Desactivar el relleno de fondo antes de aplicar un relleno explícito.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

El resultado, de izquierda a derecha: **relleno de fondo**, **sin relleno** y **relleno explícito**. La banda magenta está oculta por los rectángulos izquierdo y derecho, pero sigue visible a través del rectángulo central.

![Relleno de fondo, sin relleno y relleno naranja explícito sobre una banda magenta](background-fill.png)

El mismo comportamiento se aplica a un fondo definido directamente en la diapositiva o heredado de un diseño. La forma usa el fondo resuelto de la diapositiva; el ejemplo deja sin definir tanto los fondos de la diapositiva como del diseño, de modo que el maestro lo suministra.

## **Establecer transparencia**

Para un relleno sólido, el componente alfa del color controla la opacidad: 0 es totalmente transparente y 255 es totalmente opaco. Este ejemplo usa un valor alfa de 128 para un rectángulo amarillo, haciéndolo aproximadamente 50 % transparente para que el rectángulo debajo permanezca visible. El color se asigna mediante [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Utilice [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) para rotar una forma en el plano de la diapositiva. El ángulo se mide en grados; este ejemplo rota un rectángulo 5 grados en sentido horario y guarda la presentación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![La rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Utilice [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) para dar a una forma profundidad y bordes biselados. Este ejemplo crea una elipse verde con un contorno naranja, establece [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) en 4 puntos y aplica un bisel superior circular con ancho y alto de 6 puntos mediante [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Una cámara ortográfica frontal y una iluminación de tres puntos hacen visible el bisel.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

La vista 3D de una forma se controla mediante sus ajustes de cámara. Este ejemplo usa [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) con ángulos de latitud, longitud y revolución de 40, 35 y 20 grados, respectivamente. Selecciona una cámara isométrica mediante [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) y una iluminación equilibrada mediante [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), luego guarda el rectángulo formateado.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar el renderizado en blanco y negro para formas**

La propiedad [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) especifica cómo se renderiza una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí misma, y no cambia el relleno, la línea u otro formato de la forma en modo de color normal.

Utilice un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `AUTOMATIC` permite que la aplicación de renderizado elija la conversión, `GRAY` y `LIGHT_GRAY` usan coloreado gris, `BLACK_WHITE` usa solo blanco y negro, `BLACK` y `WHITE` fuerzan un color único, `COLOR` preserva el coloreado normal, y `HIDDEN` omite la forma en modo blanco y negro. `NOT_DEFINED` significa que no se asigna un modo a nivel de forma.

Este ejemplo crea un rectángulo naranja y establece [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) en gris. La forma guardada conserva su relleno naranja para la visualización en color normal y solicita coloreado gris a las aplicaciones que respetan la configuración de visualización en blanco y negro:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza coloreado gris porque su modo está configurado a `GRAY`. Esto le permite preservar una diapositiva en color completo mientras define una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

Utilice [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) para restaurar la posición, tamaño y formato de los marcadores de posición de la diapositiva a partir de sus marcadores de posición de diseño correspondientes. Este ejemplo requiere una presentación existente con marcadores de posición vinculados al diseño y restablece todas las diapositivas antes de guardar. Las formas sin marcadores de posición de diseño correspondientes no se restablecen.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Afecta el formato de la forma al tamaño final del archivo de la presentación?**

Los colores, estilos de línea y configuraciones de efectos generalmente añaden pocos datos en comparación con imágenes y medios incrustados. Los rellenos de imagen pueden aumentar el tamaño del archivo porque sus imágenes se almacenan en la presentación.

**¿Cómo puedo detectar formas en una diapositiva que comparten el mismo formato para poder agruparlas?**

Compare cada una de las propiedades clave de formato de la forma — relleno, línea y configuraciones de efectos. Si todos los valores correspondientes coinciden, trate sus estilos como idénticos y agrupe lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarde formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abra la plantilla, clone las formas estilizadas que necesite y vuelva a aplicar su formato donde sea necesario.