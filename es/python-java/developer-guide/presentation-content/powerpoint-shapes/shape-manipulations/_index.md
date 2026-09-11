---
title: Administrar formas de presentación en Python vía Java
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/python-java/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Encontrar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma interop
- Texto alternativo de la forma
- Punto de ajuste de forma
- Ajuste de forma predefinido
- Geometría de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- Voltear forma
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprende cómo identificar, ajustar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para Python vía Java."
---
## **Visión general**

Aspose.Slides for Python via Java representa las formas en una diapositiva como una [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` corresponde a la forma más trasera, mientras que el último índice corresponde a la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de forma fiable y modificar los puntos de ajuste predefinidos, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y los ajustes de volteo. Cada ejemplo es independiente, de modo que puedes usar solo las operaciones que requiera tu flujo de trabajo.

## **Identificar y encontrar formas**

Los índices de la colección son convenientes al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elige un identificador según cómo se autorice y mantenga la presentación:

- [Name](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getName) es útil para plantillas controladas por el desarrollador y es fácil de inspeccionar en el panel de selección de PowerPoint. Los nombres pueden editarse y no se garantiza que sean únicos, así que establece una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no se garantiza que sea único. No reutilices silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getOfficeInteropShapeId) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma utilizado por la interoperabilidad de PowerPoint. Úsalo al integrar con PowerPoint o cuando necesites una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

El método relacionado [getUniqueId](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getUniqueId) devuelve un identificador con alcance de presentación, pero ese identificador está pensado para complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantén el mapeo en los datos de la aplicación y valida que la forma esperada siga existiendo.

El siguiente ejemplo busca por nombre con una comparación exacta e informa el ID de interop con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Cuando una operación es específica de un tipo de forma, verifica el tipo antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto nombrado es un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identificar y modificar ajustes de forma predefinidos**

Las formas de geometría predefinida pueden exponer puntos de ajuste que controlan características como el tamaño de la esquina, las proporciones de la flecha o los ángulos del arco. Accede a ellos a través de la colección de solo lectura [GeometryShape.getAdjustments](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#getAdjustments). La colección es proporcionada por la forma, pero cada [AdjustValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/) contiene un valor que puede modificarse.

No confíes solo en un índice de colección fijo. Recorre los ajustes e inspecciona el método de solo lectura [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType), cuyo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/) describe qué controla el ajuste. El método de solo lectura [getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName) proporciona información adicional de identificación y es especialmente útil cuando un preajuste contiene más de un ajuste con el mismo tipo semántico.

Usa el método de valor que coincida con el significado del ajuste:

| Tipo de ajuste | Propósito | Valor a cambiar |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Tamaño de las esquinas redondeadas | [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Espesor de la cola de una flecha | [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Longitud de la punta de la flecha | [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Ancho de la punta de la flecha | [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Ángulo inicial de una porción o arco | [setAngleValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Ángulo final de una porción o arco | [setAngleValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType) y [getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName) devuelven información de solo lectura. [getRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getRawValue) y [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue) trabajan con un entero en las unidades de geometría nativas del preajuste, mientras que [getAngleValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getAngleValue) y [setAngleValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setAngleValue) trabajan con un ángulo en grados. El número, orden, significado y rango válido de los ajustes dependen del [ShapeType](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#getShapeType) del preajuste. Un valor válido para un preajuste puede ser inválido o tener un efecto diferente para otro.

Cuando [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType) devuelve [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeadjustmenttype/#Custom), la API no reconoce un significado semántico estándar. Inspecciona [getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName), el tipo de preajuste y el valor existente, y deja el ajuste sin cambios a menos que conozcas el significado y el rango esperados. Incluso para los tipos reconocidos, verifica si el mismo tipo ocurre más de una vez antes de seleccionar un valor. El artículo [Connector](/slides/es/python-java/connector/) muestra esta situación con los ajustes de curvatura de conectores.

El siguiente ejemplo completo crea versiones predeterminadas y modificadas de tres formas predefinidas. Recorre cada ajuste, informa su nombre y tipo, cambia los valores relacionados con el tamaño mediante [setRawValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setRawValue), cambia los ángulos mediante [setAngleValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#setAngleValue) y guarda el resultado. La columna izquierda conserva la geometría predeterminada; la columna derecha muestra el rectángulo redondeado ajustado, la flecha de cuatro puntas y la porción.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añade encabezados para las columnas de forma predeterminada y ajustada.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Comprobar el tipo semántico antes de cambiar un valor hace que el código sea explícito sobre su intención y evita asumir que un índice de colección particular tiene el mismo significado en distintas formas predefinidas.

## **Modificar la colección de formas**

Los métodos de agregar, clonar, eliminar y reordenar operan sobre la colección inmediatamente. Si una operación cambia el número o el orden de las formas, no continúes confiando en índices capturados antes de esa operación.

### **Clonar una forma**

[addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addClone) crea una copia independiente y la añade al final de la colección de destino. [insertClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#insertClone) también crea una copia pero la coloca en un índice z‑order especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente e inserta un segundo clon al fondo. Los cambios en cualquiera de los clones no modifican la forma original.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigna nuevos identificadores lógicos al clon cuando esos valores deben ser únicos. Los recursos utilizados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#remove) elimina un objeto forma específico de su colección. Al eliminar varias coincidencias durante una iteración indexada, recorre la colección de atrás hacia adelante para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee la forma en el índice actual, no un elemento de colección fijo, y no realiza conversiones de tipo innecesarias.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considera conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Hidden](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setHidden) a `True` mantiene la forma en la colección pero impide que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más tarde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ocultar no es eliminar ni es una medida de seguridad. El objeto aún puede ser descubierto y vuelto a mostrar por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se dibujan según el orden de la colección. [reorder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#reorder) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es la parte trasera; el [size](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#size) de la colección menos uno es la parte delantera.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El rectángulo se crea primero y inicialmente está detrás de la elipse. Moverlo al índice final lo coloca al frente. Finaliza el orden Z después de agregar o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, de diseño y maestras poseen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de manera similar en una diapositiva normal. Inspecciona las formas de diseño cuando necesites comprender o cambiar el formato proporcionado por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getFillFormat) y el [LineFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getLineFormat) de cada forma del diseño sin asumir que todas las formas son un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Editar un diseño puede afectar a múltiples diapositivas que lo utilizan. Antes de cambiar una forma de diseño, determina si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y prueba cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

El método `writeAsSvg` de [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) escribe el contenido renderizado de una forma en un flujo. El resultado contiene sólo la forma, no el fondo completo de la diapositiva ni las formas vecinas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Mantén la presentación abierta mientras se realiza el renderizado. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesitas toda la composición, exporta la diapositiva en lugar de una forma individual. El llamador posee el flujo y debe cerrarlo.

## **Alinear formas**

Los sobrecargas de [SlideUtil.alignShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/#alignShapes) alinean todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establece `align_to_slide` a `True` para usar los bordes de la diapositiva; establézcalo a `False` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Las referencias a formas devueltas se convierten a sus índices actuales inmediatamente antes de la alineación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La alineación cambia la posición, no el orden Z. La alineación relativa normalmente requiere al menos dos formas, mientras que la distribución horizontal o vertical necesita suficientes formas para definir el espaciado. Recalcula los índices si modificas la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeframe/) almacena la posición, el tamaño, los ajustes de volteo horizontal y vertical, y la rotación. Sus valores [getFlipH](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeframe/#getFlipH) y [getFlipV](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeframe/#getFlipV) usan [NullableBool](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/): `True` habilita el volteo, `False` lo deshabilita y `NotDefined` mantiene el estado no especificado/predeterminado.

La presentación de entrada a continuación contiene una forma no volteada.

![La forma antes de girar](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo los dos ajustes de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setFrame) reemplaza todo el marco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La forma guardada queda reflejada horizontal y verticalmente mientras mantiene su posición, tamaño y rotación.

![La forma después de girar](flipped_shape.png)

## **FAQ**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesos de corta duración cuando la colección no cambiará antes de usar el índice. Prefiere una convención validada basada en [Name](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getName) o [AlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText) para plantillas creadas, o [OfficeInteropShapeId](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getOfficeInteropShapeId) para trabajo de interop con alcance de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma ocultada sigue en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o hacerse visible nuevamente.

**¿Por qué una forma clonada apareció delante de otra forma?**

[addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addClone) agrega el clon al final de la colección, que corresponde al frente del orden Z. Usa [insertClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#insertClone) para elegir el índice inicial o [reorder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#reorder) después de haber agregado todas las formas.

**¿Puedo usar un índice fijo para identificar un ajuste de forma predefinido?**

Solo después de validar el preajuste exacto y la disposición de la colección. Prefiere iterar a través de [GeometryShape.getAdjustments](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#getAdjustments) y comprobar [AdjustValue.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getType); usa [AdjustValue.getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/adjustvalue/#getName) como información adicional cuando el mismo tipo semántico aparece más de una vez.