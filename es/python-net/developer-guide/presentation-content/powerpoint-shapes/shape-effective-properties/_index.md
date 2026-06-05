---
title: Obtener propiedades efectivas de la forma desde presentaciones con Python
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/python-net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Python a través de .NET calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Resumen**

Este artículo explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son valores que se establecen directamente en un nivel de formato específico, como:

1. Propiedades de porción en una diapositiva.  
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.  
1. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final “tal como se renderiza”, resuelve la cadena de herencia y devuelve valores **efectivos**. Puedes obtenerlos llamando al método `get_effective` en el objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Se asume que la primera forma de la primera diapositiva es una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con un marco de texto y al menos una porción.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Los datos de formato efectivo representan el formato calculado actual tras aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/iportionformateffectivedata/), pueden almacenarse en caché internamente. Llamar a `get_effective` de nuevo después de cambiar el formato del padre o heredado puede refrescar los datos en caché, y un objeto obtenido previamente puede ya no representar el estado anterior. Si necesitas conservar los valores efectivos para reutilizarlos más tarde, copia las propiedades necesarias, como la altura de fuente, el color de relleno, el estilo de fuente o la alineación, en tu propio objeto de datos.
{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides permite obtener propiedades efectivas de una cámara. El tipo [ICameraEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/icameraeffectivedata/) representa un objeto inmutable que contiene propiedades efectivas de cámara. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/icameraeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [ThreeDFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la cámara. Se asume que la primera forma de la primera diapositiva tiene formato 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Obtener propiedades efectivas de un rig de luz**

Aspose.Slides permite obtener propiedades efectivas de un rig de luz. El tipo [ILightRigEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ilightrigeffectivedata/) representa un objeto inmutable que contiene propiedades efectivas del rig de luces. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ilightrigeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [ThreeDFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el rig de luces. Se asume que la primera forma de la primera diapositiva tiene formato 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Obtener propiedades efectivas de una forma biselada**

Aspose.Slides permite obtener propiedades efectivas de un bisel de forma. El tipo [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishapebeveleffectivedata/) representa un objeto inmutable que contiene propiedades efectivas de relieve de forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishapebeveleffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [ThreeDFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el bisel superior de una forma. Se asume que la primera forma de la primera diapositiva tiene formato 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Obtener propiedades efectivas de un marco de texto**

Usando Aspose.Slides, puedes obtener propiedades efectivas de un marco de texto. El tipo [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/itextframeformateffectivedata/) contiene propiedades efectivas de formato de marco de texto.

El siguiente fragmento de código muestra cómo obtener propiedades de formato efectivo del marco de texto. Se asume que la primera forma de la primera diapositiva es una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con un marco de texto.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Obtener propiedades efectivas de un estilo de texto**

Usando Aspose.Slides, puedes obtener propiedades efectivas de un estilo de texto. El tipo [ITextStyleEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/itextstyleeffectivedata/) contiene propiedades efectivas de estilo de texto.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas de estilo de texto. Se asume que la primera forma de la primera diapositiva es una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con un marco de texto.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Obtener el valor efectivo de la altura de fuente**

Usando Aspose.Slides, puedes obtener la altura de fuente efectiva. El siguiente código demuestra cómo cambia la altura de fuente efectiva de una porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener el formato de relleno efectivo para una tabla**

Usando Aspose.Slides, puedes obtener el formato de relleno efectivo para distintas partes de una tabla. El tipo [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/ifillformateffectivedata/) contiene propiedades efectivas de formato de relleno. El formato de celda tiene mayor prioridad que el formato de fila, el formato de fila tiene mayor prioridad que el formato de columna, y el formato de columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, se utilizan las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/es/python-net/aspose.slides/icellformateffectivedata/) para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener el formato de relleno efectivo para distintas partes de la tabla. Se asume que la primera forma de la primera diapositiva es una [Table](https://reference.aspose.com/slides/es/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **Preguntas frecuentes**

**¿Devuelve `get_effective` una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden almacenarse en caché internamente. Una llamada posterior a `get_effective` puede recalcular el formato y refrescar los datos en caché, por lo que un objeto obtenido anteriormente no debe considerarse una instantánea durable.

**¿Cuándo debo volver a leer las propiedades efectivas?**

Llama a `get_effective` de nuevo después de modificar el formato local, los estilos padre, el formato de diseño, el formato maestro o los valores predeterminados a nivel de presentación. La siguiente llamada vuelve a evaluar la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas ya obtenidas?**

Sí, pero el cambio se refleja en la siguiente llamada a `get_effective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar obsoletos. Una vez llamado de nuevo a `get_effective`, Aspose.Slides vuelve a evaluar el árbol de formato y los valores resultantes de fuentes, colores, tamaños u otros pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realiza los cambios en los objetos de formato local y, a continuación, vuelve a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores por defecto de PowerPoint y de Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**¿A partir de un valor de fuente efectivo, puedo saber qué nivel proporcionó el tamaño o la tipografía?**

No directamente. Los datos efectivos devuelven el valor final. Para encontrar la fuente, verifica los valores locales en la porción, el párrafo, el marco de texto y los estilos de texto en el diseño, la maestra y la presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores efectivos a veces se ven idénticos a los locales?**

Porque el valor local resultó ser el final (no fue necesario heredar de un nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**

Utiliza los datos efectivos cuando necesites el resultado “tal como se renderiza” después de aplicar toda la herencia, por ejemplo, para alinear colores, sangrías o tamaños. Si necesitas conservar esos valores independientemente de cambios posteriores de formato, copia las propiedades requeridas en tu propio objeto. Si necesitas cambiar el formato en un nivel específico, modifica las propiedades locales y luego, si es necesario, vuelve a leer los datos efectivos para verificar el resultado.