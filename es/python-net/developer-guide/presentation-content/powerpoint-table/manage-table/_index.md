---
title: Gestionar tablas de presentación con Python
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/python-net/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET. Descubre ejemplos de código sencillos para optimizar tus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, facilitando su lectura y la comparación de valores.

Aspose.Slides proporciona las clases [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) y [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Cree una tabla especificando su posición, los anchos de columna y las alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, combinar celdas e insertar texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Defina una lista de anchos de columna en puntos.
4. Defina una lista de alturas de fila en puntos.
5. Añada un objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a la diapositiva mediante el método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Iterate a través de cada [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla.
8. Acceda a la celda combinada a través de su propiedad [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Establezca el texto en la celda combinada.
10. Guarde la presentación modificada.

El ejemplo siguiente crea una tabla con tres columnas y cinco filas en (100, 50) puntos. Aplica bordes rojos con un grosor de 5 puntos, combina las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de las celdas empiezan en cero y utilizan el orden (columna, fila). La primera celda tiene el índice (0, 0). En Python, acceda a una celda con `table.rows[row_index][column_index]`; el índice de fila aparece primero en esta expresión.

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla 4 × 4 ilustrada arriba, con anchos de columna y alturas de fila de 70 puntos y bordes de celda rojos con un grosor de 5 puntos. Las coordenadas ilustran los índices de las celdas; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Recorra las formas para localizar una tabla y, a continuación, utilice la clase [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) para leer o actualizar sus celdas.

1. Cargue la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice.
3. Recorra los objetos [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) y deténgase cuando se encuentre una tabla. Si la diapositiva contiene varias tablas, utilice [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) para identificar la que necesita.
4. Actualice el texto en la celda objetivo.
5. Guarde la presentación modificada.

El ejemplo siguiente abre `UpdateExistingTable.pptx` y encuentra la primera tabla en la primera diapositiva. Establece la celda en la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla en esa diapositiva debe tener al menos una columna y dos filas.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Para redimensionar una fila en una tabla existente y entender por qué su altura real puede superar la altura mínima solicitada, vea [Controlar la altura de la fila](/slides/es/python-net/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de una tabla, utilice la propiedad [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) para recuperar la [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) propietaria. Para un marco de texto de una celda de tabla, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) está establecido y [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) es `None`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles a través de las propiedades de solo lectura [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) y [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) también es de solo lectura: proporciona la navegación al propietario pero no cambia la propiedad. Siempre compruebe que la celda devuelta no sea `None` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas formas asociadas a nodos de SmartArt, vea [Buscar y reemplazar texto](/slides/es/python-net/search-and-replace-text/).

## **Alinear texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas de tabla individuales. El ejemplo en esta sección centra el texto dentro de la primera celda y lo rota 270 grados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Añada un objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a la diapositiva.
4. Acceda a un objeto [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la tabla.
5. Acceda al primer [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establezca su texto y color.
6. Establezca el [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) y el [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) de la celda.
7. Guarde la presentación modificada.

Este ejemplo crea una tabla 4 × 4 con anchos de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto en la celda (0, 0), añade valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer formato de texto a nivel de tabla**

Utilice [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porción, de párrafo y de marco de texto, por lo que puede establecer estas propiedades sin iterar por celdas individuales.

1. Cargue la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Acceda a un objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) de la diapositiva.
4. Establezca el [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) para el texto.
5. Establezca el [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) y el [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Establezca el [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Guarde la presentación modificada.

El ejemplo siguiente abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace el texto vertical. La presentación formateada se guarda como `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener propiedades de estilo de tabla**

Utilice [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) para leer o asignar el estilo predefinido de una tabla. Este ejemplo aplica [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) a una tabla, muestra el nombre del preset y asigna el mismo preset a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Bloquear proporción de aspecto de una tabla**

La proporción de aspecto de una tabla es la relación entre su ancho y su altura. Utilice [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) para bloquear esta proporción en una tabla.

El ejemplo siguiente abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Muestra el estado de bloqueo actual, habilita el bloqueo de proporción de aspecto, muestra el estado actualizado (`True`) y guarda el resultado como `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda la tabla y el texto en sus celdas?**

Sí. La tabla expone una propiedad [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) y los párrafos tienen [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Usar ambas garantiza el orden RTL correcto y el renderizado dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/python-net/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos se aplican también a las tablas.

**¿Se admite la inserción de una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).