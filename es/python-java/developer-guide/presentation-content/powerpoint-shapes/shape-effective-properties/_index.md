---
title: Obtener propiedades efectivas de forma de presentaciones en Python vía Java
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/python-java/shape-effective-properties/
keywords:
  - propiedades de forma
  - propiedades de cámara
  - sistema de iluminación
  - biselado de forma
  - marco de texto
  - estilo de texto
  - altura de fuente
  - formato de relleno
  - PowerPoint
  - presentación
  - Python
  - Java
  - Aspose.Slides
description: "Aprenda a utilizar Aspose.Slides para Python vía Java para distinguir el formato local, heredado y efectivo de formas en presentaciones de PowerPoint."
---
## **Comprender las propiedades locales, heredadas y efectivas**

La formateo de PowerPoint puede provenir de varios lugares. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está establecido, PowerPoint busca en las fuentes de formato padre, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o los valores predeterminados a nivel de presentación. Esos valores son **valores heredados**. El valor que queda después de que se resuelve toda la jerarquía es el **valor efectivo**—el valor utilizado para representar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su valor local [getFontHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#getFontHeight) es entonces `float("nan")`, que significa "no establecido aquí". La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación o de otra fuente aplicable. Llamar a [getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#getEffective) sobre el formato de la porción devuelve la altura final resuelta.

Utilice los dos tipos de datos de formato para diferentes propósitos:

- Lea o cambie un objeto de formato local, como [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/), cuando necesite controlar dónde se define un valor.
- Lea un objeto de datos efectivo, como `PortionFormatEffectiveData`, cuando necesite el resultado final renderizado. Los datos efectivos son de solo lectura.

## **Comparar valores locales, heredados y efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso imprime los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También muestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Leer datos efectivos después de los cambios anteriores.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Definir valores heredados en dos niveles diferentes.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Un valor local en la porción sobrescribe ambos valores heredados.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Cambiar un valor heredado no sobrescribe un valor local existente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Borrar el valor local. La porción vuelve a heredar del párrafo.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Borrar el valor del párrafo. El valor predeterminado de la presentación suministra ahora el resultado.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La prioridad en este ejemplo es el formato local de la porción, luego el formato de párrafo y, por último, el valor predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico gana, y [getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#getEffective) devuelve el resultado final.

## **Obtener propiedades de texto efectivas**

El formato de texto se divide entre varios objetos:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#getEffective) resuelve propiedades del marco de texto como márgenes, anclaje, ajuste automático y dirección vertical del texto.
- [TextStyle.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/textstyle/#getEffective) resuelve el formato de párrafo para cada nivel de estilo de texto.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#getEffective) resuelve propiedades del párrafo como alineación, sangría y viñetas.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#getEffective) resuelve propiedades de carácter como altura de fuente, tipografía, color, negrita e itálica.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) con un marco de texto no vacío. La AutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Obtener propiedades 3D efectivas**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/threedformat/#getEffective) devuelve un objeto `ThreeDFormatEffectiveData` que agrupa todos los ajustes 3D resueltos. Sus métodos `getCamera`, `getLightRig`, `getBevelTop` y `getBevelBottom` exponen los datos efectivos correspondientes. Leer estos ajustes relacionados juntos facilita la comprensión de la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique ajustes de cámara 3D, iluminación o biselado a esa forma si desea que la salida contenga valores diferentes a los predeterminados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Obtener formato de tabla efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, una columna, una fila o una celda individual. En caso de conflictos entre rellenos definidos explícitamente, la prioridad es celda, fila, columna y, finalmente, tabla completa. El formato efectivo de una celda es el formato final utilizado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca una [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) en lugar de asumir que `getShapes().get_Item(0)` es una tabla.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Si necesita el color en lugar de solo el tipo de relleno, primero verifique el `getFillType` efectivo y, a continuación, lea el método que corresponde a ese tipo—por ejemplo, `getSolidFillColor` para un relleno sólido.

## **Volver a leer datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a [getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#getEffective) de nuevo después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluyendo:

- el formato local del objeto;
- los valores predeterminados de párrafo o de marco de texto;
- un estilo de tabla, tabla, columna, fila o formato de celda;
- el formato de diseño o diapositiva maestra;
- los datos del tema o los valores predeterminados a nivel de presentación;
- el diseño o la maestra asignada a una diapositiva.

No mantenga un objeto de datos efectivo como una instantánea permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a [getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#getEffective) puede actualizar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite—como la altura de fuente, el color, la alineación o el ancho del bisel—en sus propias variables antes de realizar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y luego llame a [getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#getEffective) para verificar el resultado. Los objetos de datos efectivos son de solo lectura.

## **Preguntas frecuentes**

**¿Cómo puedo saber qué nivel proporcionó un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para el texto, esto puede incluir la porción, el párrafo, el marco de texto, el diseño, la maestra, el tema y los valores predeterminados de la presentación. Los valores no definidos como `float("nan")` o `None` indican que la búsqueda continúa en otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado apropiado de PowerPoint o de la biblioteca. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo defina explícitamente.

**¿Por qué un valor efectivo a veces es igual al valor local?**

El valor local ganó el cálculo de herencia. Esto es esperado cuando la propiedad está establecida explícitamente en el objeto y ninguna regla más específica lo sobrescribe.

**¿Cuándo debo usar datos locales en lugar de datos efectivos?**

Utilice datos locales para inspeccionar o editar un nivel de formato específico. Utilice datos efectivos cuando necesite la apariencia final después de la herencia, las reglas del tema y los estilos aplicables hayan sido resueltos. El [ejemplo completo de comparación](#compare-local-inherited-and-effective-values) muestra ambos en el mismo flujo de trabajo.