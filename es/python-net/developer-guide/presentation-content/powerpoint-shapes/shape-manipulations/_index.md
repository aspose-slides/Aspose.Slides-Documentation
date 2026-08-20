---
title: Gestionar formas de presentación en Python
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/python-net/shape-manipulations/
keywords:
- forma PowerPoint
- forma de presentación
- forma en diapositiva
- buscar forma
- clonar forma
- eliminar forma
- ocultar forma
- cambiar orden de forma
- obtener ID de forma interop
- texto alternativo de la forma
- formatos de diseño de forma
- forma como SVG
- forma a SVG
- alinear forma
- voltear forma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a identificar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para Python via .NET."
---
## **Visión general**

Aspose.Slides for Python via .NET representa las formas en una diapositiva como una colección ordenada [ShapeCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/). La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más atrás, mientras que el último índice es la forma más al frente.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de manera fiable, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y la configuración de volteo. Cada ejemplo es independiente, de modo que puede usar solo las operaciones que requiera su flujo de trabajo.

## **Identificar y encontrar formas**

Los índices de la colección son cómodos al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elija un identificador según cómo se cree y mantenga la presentación:

- [Shape.name](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/name/) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el panel de selección de PowerPoint. Los nombres pueden editarse y no se garantiza que sean únicos, por lo que debe establecerse una convención de nombres si el código depende de ellos.
- [Shape.alternative_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/alternative_text/) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no se garantiza que sea única. No reutilice silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/office_interop_shape_id/) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma usado por la interoperabilidad de PowerPoint. Úselo al integrar con PowerPoint o cuando necesite una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

La propiedad relacionada [Shape.unique_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/unique_id/) tiene alcance de presentación, pero está pensada para complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantenga el mapeo en los datos de la aplicación y valide que la forma esperada siga existiendo.

El siguiente ejemplo busca por `name` con una comparación exacta e informa el ID de interop con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

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

Cuando una operación es específica de un tipo de forma, compruebe el tipo antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto con nombre es un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).

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

## **Modificar la colección de formas**

Los métodos añadir, clonar, eliminar y reordenar operan sobre la colección inmediatamente. Si una operación cambia el número o el orden de las formas, no continúe basándose en índices capturados antes de esa operación.

### **Clonar una forma**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_clone/) crea una copia independiente y la agrega al final de la colección de destino. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/insert_clone/) también crea una copia pero la coloca en un índice de orden Z especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

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

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigne nuevos identificadores lógicos al clon cuando esos valores deban ser únicos. Los recursos utilizados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[ShapeCollection.remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/remove/) elimina un objeto de forma específico de su colección. Al eliminar varias coincidencias durante una iteración indexada, recorra la colección desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee `slide.shapes[index]`, no un elemento de colección fijo, y no realiza conversiones innecesarias de la forma.

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

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considere conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Shape.hidden](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/hidden/) a `True` mantiene la forma en la colección pero evita que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse después.

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

Ocultar no es eliminación ni seguridad. El objeto aún puede ser descubierto y volver a mostrarse por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se dibujan según el orden de la colección. [ShapeCollection.reorder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/reorder/) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es la parte trasera; `len(slide.shapes) - 1` es la parte delantera.

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

El rectángulo se crea primero y inicialmente queda detrás de la elipse. Moverlo al índice final lo sitúa al frente. Finalice el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, de diseño y maestras tienen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de forma similar en una diapositiva normal. Inspeccione las formas del diseño cuando necesite comprender o cambiar el formato suministrado por un diseño.

El siguiente ejemplo lee el [Shape.fill_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/fill_format/) y el [Shape.line_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/line_format/) de cada forma de diseño sin asumir que cada forma es un `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Editar un diseño puede afectar a varias diapositivas que lo utilizan. Antes de cambiar una forma de diseño, determine si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y pruebe cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/write_as_svg/) escribe el contenido renderizado de una sola forma en un flujo. El resultado contiene únicamente la forma, no el fondo completo de la diapositiva ni las formas vecinas.

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

Mantenga la presentación abierta mientras renderiza. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesita la composición completa, exporte la diapositiva en lugar de una forma individual. El llamador es propietario del flujo y debe cerrarlo.

## **Alinear formas**

Los sobrecargas de [SlideUtil.align_shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/align_shapes/) alinean todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establezca `align_to_slide` a `True` para usar los bordes de la diapositiva; establézcalo a `False` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas con el borde superior de la diapositiva. Sus índices actuales se resuelven inmediatamente antes de la alineación.

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

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente requiere al menos dos formas, mientras que la distribución horizontal o vertical necesita suficientes formas para definir el espaciado. Recalcule los índices si modifica la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapeframe/) almacena la posición, el tamaño, la configuración de volteo horizontal y vertical, y la rotación. Sus valores `flip_h` y `flip_v` utilizan [NullableBool](https://reference.aspose.com/slides/es/python-net/aspose.slides/nullablebool/): `TRUE` habilita el volteo, `FALSE` lo deshabilita, y `NOT_DEFINED` conserva el estado no especificado o predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![La forma antes de voltearla](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo las dos configuraciones de volteo. Esto es importante porque asignar un nuevo [Shape.frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/frame/) reemplaza todo el marco.

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

![La forma después de voltearla](flipped_shape.png)

## **Preguntas frecuentes**

**¿Debería usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de que se use el índice. Prefiera un `name` o `alternative_text` validado para plantillas creadas, o `office_interop_shape_id` para trabajos de interoperabilidad con PowerPoint.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a mostrarse.

**¿Por qué una forma clonada apareció delante de otra forma?**

`add_clone` agrega el clon al final de la colección, que corresponde al frente del orden Z. Use `insert_clone` para elegir el índice inicial o `reorder` después de haber añadido todas las formas.