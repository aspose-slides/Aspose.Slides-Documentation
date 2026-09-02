---
title: Gestionar formas de presentación en Python
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/python-net/shape-manipulations/
keywords:
- forma de PowerPoint
- forma de presentación
- forma en diapositiva
- buscar forma
- clonar forma
- eliminar forma
- ocultar forma
- cambiar orden de forma
- obtener ID de forma interop
- texto alternativo de forma
- punto de ajuste de forma
- ajuste predefinido de forma
- geometría de forma
- formatos de diseño de forma
- forma como SVG
- forma a SVG
- alinear forma
- voltear forma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprende cómo identificar, ajustar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides for Python via .NET."
---
## **Descripción general**

Aspose.Slides for Python via .NET representa las formas de una diapositiva como una [ShapeCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más trasera, mientras que el último índice es la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de forma fiable y modificar los puntos de ajuste predefinidos, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y la configuración de volteo. Cada ejemplo es independiente, por lo que puedes utilizar solo las operaciones que requiera tu flujo de trabajo.

## **Identificar y encontrar formas**

Los índices de la colección son convenientes al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elige un identificador según cómo se haya creado y mantenga la presentación:

- [Shape.name](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/name/) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el panel de selección de PowerPoint. Los nombres pueden editarse y no garantizan ser únicos, por lo que es conveniente establecer una convención de nombres si el código depende de ellos.
- [Shape.alternative_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/alternative_text/) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no garantiza ser único. No reutilices silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/office_interop_shape_id/) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma utilizado por la interoperabilidad de PowerPoint. Úsalo al integrarte con PowerPoint o cuando necesites una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma distinta y recibe su propio ID.

La propiedad relacionada [Shape.unique_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/unique_id/) tiene ámbito de presentación, pero está destinada a complementos y puede reasignarse. No debe considerarse una clave externa permanente. Si la identidad a largo plazo es esencial, conserva el mapeo en los datos de la aplicación y valida que la forma esperada siga existiendo.

El siguiente ejemplo busca por `name` con una comparación exacta e informa el ID de interoperabilidad con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Cuando una operación es específica de un tipo de forma, verifica el tipo antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto con nombre es un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identificar y modificar ajustes predefinidos de forma**

Las formas de geometría predefinida pueden exponer puntos de ajuste que controlan características como el tamaño de la esquina, las proporciones de la flecha o los ángulos del arco. Accede a ellos a través de la colección de solo lectura [GeometryShape.adjustments](https://reference.aspose.com/slides/es/python-net/aspose.slides/geometryshape/adjustments/). La propia colección la proporciona la forma, pero cada [AdjustValue](https://reference.aspose.com/slides/es/python-net/aspose.slides/adjustvalue/) contiene un valor que puede modificarse.

No confíes solo en un índice de colección fijo. Itera a través de los ajustes e inspecciona la propiedad de solo lectura [AdjustValue.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/adjustvalue/type/), cuyo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapeadjustmenttype/) describe qué controla el ajuste. La propiedad de solo lectura [AdjustValue.name](https://reference.aspose.com/slides/es/python-net/aspose.slides/adjustvalue/name/) proporciona información adicional de identificación y es especialmente útil cuando una predefinición contiene más de un ajuste con el mismo tipo semántico.

Utiliza la propiedad de valor que coincida con el significado del ajuste:

| Tipo de ajuste | Propósito | Valor a cambiar |
|---|---|---|
| `CORNER_SIZE` | Tamaño de las esquinas redondeadas | [raw_value](https://reference.aspose.com/slides/es/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Espesor de la cola de una flecha | `raw_value` |
| `ARROWHEAD_LENGTH` | Longitud de la cabeza de la flecha | `raw_value` |
| `ARROWHEAD_WIDTH` | Anchura de la cabeza de la flecha | `raw_value` |
| `START_ANGLE` | Ángulo inicial de un sector o arco | [angle_value](https://reference.aspose.com/slides/es/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Ángulo final de un sector o arco | `angle_value` |

`type` y `name` no pueden asignarse. `raw_value` es un entero de lectura/escritura en las unidades nativas de geometría de la predefinición, mientras que `angle_value` es un ángulo de lectura/escritura en grados. El número, orden, significado y rango válido de los ajustes dependen de la predefinición [GeometryShape.shape_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/geometryshape/shape_type/). Un valor válido para una predefinición puede ser inválido o tener un efecto diferente para otra.

Cuando `type` es `ShapeAdjustmentType.CUSTOM`, la API no reconoce un significado semántico estándar. Inspecciona `name`, el tipo de predefinición y el valor existente, y deja el ajuste sin cambios a menos que se conozca el significado y rango esperados. Incluso para tipos reconocidos, verifica si el mismo tipo aparece más de una vez antes de seleccionar un valor. El artículo [Connector](/slides/es/python-net/connector/) muestra esta situación con ajustes de curvatura del conector.

El siguiente ejemplo completo crea versiones predeterminadas y modificadas de tres formas predefinidas. Itera por cada ajuste, informa su `name` y `type`, cambia los valores relacionados con el tamaño mediante `raw_value`, cambia los ángulos mediante `angle_value` y guarda el resultado. La columna izquierda conserva la geometría predeterminada; la columna derecha muestra el rectángulo redondeado ajustado, la flecha de cuatro puntas y el sector.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Añadir encabezados para las columnas de forma predeterminada y ajustada.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Comprobar el tipo semántico antes de cambiar un valor hace que el código sea explícito respecto a su intención y evita asumir que un índice de colección particular tiene el mismo significado en diferentes formas predefinidas.

## **Modificar la colección de formas**

Los métodos de añadir, clonar, eliminar y reordenar operan sobre la colección de inmediato. Si una operación cambia el número o el orden de las formas, no continúes basándote en índices capturados antes de esa operación.

### **Clonar una forma**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_clone/) crea una copia independiente y la añade al final de la colección de destino. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/insert_clone/) también crea una copia pero la coloca en un índice de orden Z especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente e inserta un segundo clon al fondo. Los cambios en cualquiera de los clones no modifican la forma original.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigna nuevos identificadores lógicos al clon cuando esos valores deban ser únicos. Los recursos utilizados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[ShapeCollection.remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/remove/) elimina un objeto de forma específico de su colección. Cuando se eliminan varias coincidencias durante una iteración con índices, recorre la colección desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee `slide.shapes[index]`, no un elemento de colección fijo, y no hace conversiones innecesarias de la forma.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considera conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Shape.hidden](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/hidden/) a `True` mantiene la forma en la colección pero impide que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más tarde.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Ocultar no equivale a eliminar ni a seguridad. El objeto aún puede ser descubierto y volver a mostrarse por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se pintan en el orden de la colección. [ShapeCollection.reorder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/reorder/) mueve una forma existente a un índice de destino sin clonarla. El índice `0` es el fondo; `len(slide.shapes) - 1` es el frente.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

El rectángulo se crea primero y inicialmente se sitúa detrás de la elipse. Moverlo al índice final lo coloca al frente. Finaliza el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, las diapositivas de diseño y las diapositivas maestras tienen colecciones de formas separadas. Una forma en la colección de diseño no es el mismo objeto que una forma posicionada de forma similar en una diapositiva normal. Inspecciona las formas de diseño cuando necesites comprender o cambiar el formato suministrado por un diseño.

El siguiente ejemplo lee el [Shape.fill_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/fill_format/) y el [Shape.line_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/line_format/) de cada forma de diseño sin asumir que cada forma sea un `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Editar un diseño puede afectar a varias diapositivas que lo utilicen. Antes de cambiar una forma de diseño, determina si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y prueba cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/write_as_svg/) escribe el contenido renderizado de una forma en un flujo. El resultado contiene la forma, no todo el fondo de la diapositiva o las formas vecinas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Mantén la presentación abierta mientras renderizas. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesitas toda la composición, exporta la diapositiva en lugar de una forma individual. El llamador posee el flujo y debe cerrarlo.

## **Alinear formas**

Los sobrecargas de [SlideUtil.align_shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/align_shapes/) alinean ya sea todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establece `align_to_slide` a `True` para usar los bordes de la diapositiva; establézcalo a `False` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Sus índices actuales se resuelven inmediatamente antes de la alineación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical requiere suficientes formas para definir el espaciado. Recalcula los índices si modificas la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapeframe/) almacena la posición, el tamaño, los ajustes de volteo horizontal y vertical, y la rotación. Sus valores `flip_h` y `flip_v` usan [NullableBool](https://reference.aspose.com/slides/es/python-net/aspose.slides/nullablebool/): `TRUE` habilita el volteo, `FALSE` lo deshabilita y `NOT_DEFINED` conserva el estado no especificado o predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![The shape before flipping](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo los dos ajustes de volteo. Esto es importante porque asignar un nuevo [Shape.frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/frame/) sustituye todo el marco.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

La forma guardada se refleja horizontal y verticalmente manteniendo su posición, tamaño y rotación.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de usar el índice. Prefiere una convención validada de `name` o `alternative_text` para plantillas creadas, o `office_interop_shape_id` para trabajo de interoperabilidad con alcance de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a hacerse visible.

**¿Por qué una forma clonada aparece delante de otra forma?**

`add_clone` añade el clon al final de la colección, que es el frente del orden Z. Usa `insert_clone` para elegir el índice inicial o `reorder` después de haber añadido todas las formas.

**¿Puedo usar un índice fijo para identificar un ajuste predefinido de forma?**

Solo después de validar la predefinición exacta y la disposición de la colección. Prefiere iterar a través de `GeometryShape.adjustments` y comprobar `AdjustValue.type`; usa `AdjustValue.name` como información adicional cuando el mismo tipo semántico aparece más de una vez.