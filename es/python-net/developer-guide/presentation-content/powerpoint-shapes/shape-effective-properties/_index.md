---
title: Obtener propiedades efectivas de la forma desde presentaciones en Python
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/python-net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luces
- forma con bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a usar Aspose.Slides para Python a través de .NET para distinguir el formato local, heredado y efectivo de formas en presentaciones de PowerPoint."
---
## **Entender las propiedades locales, heredadas y efectivas**

El formato de PowerPoint puede provenir de varios lugares. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está establecido, PowerPoint busca en las fuentes de formato padre, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o los valores predeterminados a nivel de presentación. Esos valores son **valores heredados**. El valor que queda después de resolver toda la jerarquía es el **valor efectivo**, que se utiliza para renderizar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su [font_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/ibaseportionformat/font_height/) local es entonces `float("nan")`, lo que significa "no establecido aquí". La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación o de otra fuente aplicable. Llamar a [get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/iportionformat/get_effective/) en el formato de la porción devuelve la altura final resuelta.

Utilice los dos tipos de datos de formato para diferentes propósitos:

- Lea o modifique un objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/iportionformat/), cuando necesite controlar dónde se define un valor.
- Lea un objeto de datos efectivo, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/iportionformateffectivedata/), cuando necesite el resultado final renderizado. Los datos efectivos son de solo lectura.

## **Comparar los valores locales, heredados y efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso imprime los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También muestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Leer datos efectivos después de los cambios anteriores.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Definir valores heredados en dos niveles diferentes.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Un valor local en la porción sobrescribe ambos valores heredados.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Cambiar un valor heredado no sobrescribe un valor local existente.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Borrar el valor local. La porción vuelve a heredar del párrafo.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Borrar el valor del párrafo. El valor predeterminado de la presentación suministra ahora el resultado.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

La prioridad en este ejemplo es el formato local de la porción, luego el formato del párrafo y, por último, el predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico prevalece, y [get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides/iportionformat/get_effective/) devuelve el resultado final.

## **Obtener las propiedades de texto efectivas**

El formato de texto se divide entre varios objetos:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/es/python-net/aspose.slides/itextframeformat/get_effective/) resuelve las propiedades del marco de texto, como márgenes, anclaje, ajuste automático y dirección vertical del texto.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/es/python-net/aspose.slides/itextstyle/get_effective/) resuelve el formato de párrafo para cada nivel de estilo de texto.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/es/python-net/aspose.slides/iparagraphformat/get_effective/) resuelve las propiedades del párrafo, como alineación, sangría y viñetas.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/es/python-net/aspose.slides/iportionformat/get_effective/) resuelve propiedades de caracteres como altura de fuente, tipo de letra, color, negrita e itálica.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con un marco de texto no vacío. La AutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Obtener las propiedades 3D efectivas**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformat/get_effective/) devuelve un objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/) que agrupa todas las configuraciones 3D resueltas. Sus propiedades [camera](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), y [bevel_bottom](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) exponen los datos efectivos correspondientes. Leer estos ajustes relacionados juntos facilita la comprensión de la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique configuraciones de cámara 3D, iluminación o biselado a esa forma si desea que la salida contenga valores diferentes de los predeterminados.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Obtener el formato de tabla efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, a una columna, a una fila o a una celda individual. En caso de conflictos entre rellenos definidos explícitamente, la prioridad es celda, fila, columna y, después, toda la tabla. El formato efectivo de una celda es el formato final utilizado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca una [Table](https://reference.aspose.com/slides/es/python-net/aspose.slides/table/) en lugar de suponer que `shapes[0]` es una tabla.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Si necesita el color en lugar de solo el tipo de relleno, primero compruebe el [fill_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/ifillformateffectivedata/fill_type/) efectivo, y luego lea la propiedad que corresponde a ese tipo, por ejemplo, [solid_fill_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) para un relleno sólido.

## **Volver a leer los datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a `get_effective` de nuevo después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluyendo:

- el formato local del objeto;
- los valores predeterminados de párrafo o del marco de texto;
- un estilo de tabla, tabla, columna, fila o formato de celda;
- el formato de diseño o diapositiva maestra;
- los datos del tema o valores predeterminados a nivel de presentación;
- el diseño o maestra asignado a una diapositiva.

No conserve un objeto de datos efectivo como una captura permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a `get_effective` puede actualizar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite, como la altura de fuente, el color, la alineación o el ancho del bisel, en sus propias variables antes de realizar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y luego llame a `get_effective` para verificar el resultado. Los propios objetos de datos efectivos son de solo lectura.

## **Preguntas frecuentes**

**¿Cómo puedo saber qué nivel proporcionó un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para el texto, esto puede incluir la porción, el párrafo, el marco de texto, el diseño, la maestra, el tema y los valores predeterminados de la presentación. Los valores indefinidos como `float("nan")` o `None` indican que la búsqueda continúa a otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado de PowerPoint o de la biblioteca correspondiente. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo defina explícitamente.

**¿Por qué a veces un valor efectivo es igual al valor local?**

El valor local ganó el cálculo de herencia. Esto es esperado cuando la propiedad está establecida explícitamente en el objeto y ninguna regla más específica la sobrescribe.

**¿Cuándo debería usar datos locales en lugar de datos efectivos?**

Utilice datos locales para inspeccionar o editar un nivel de formato específico. Utilice datos efectivos cuando necesite la apariencia final después de que la herencia, las reglas del tema y los estilos aplicables se hayan resuelto. El [ejemplo completo de comparación](#compare-local-inherited-and-effective-values) muestra ambos en el mismo flujo de trabajo.