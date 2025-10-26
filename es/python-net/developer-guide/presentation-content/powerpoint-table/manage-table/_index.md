---
title: Administrar tablas de presentación con Python
linktitle: Administrar tabla
type: docs
weight: 10
url: /es/python-net/developer-guide/presentation-content/powerpoint-table/manage-table/
keywords:
- agregar tabla
- crear tabla
- acceder a tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python vía .NET. Descubra ejemplos de código simples para optimizar sus flujos de trabajo con tablas."
---

## **Resumen**

Una tabla en PowerPoint es una forma eficaz de presentar información. La información organizada en una cuadrícula de celdas (filas y columnas) resulta directa y fácil de comprender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), la clase [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) y otros tipos relacionados para ayudarle a crear, actualizar y administrar tablas en cualquier presentación.

## **Crear tablas desde cero**

Esta sección muestra cómo crear una tabla desde cero en Aspose.Slides añadiendo una forma de tabla a una diapositiva, definiendo sus filas y columnas, y estableciendo tamaños precisos. También verá cómo rellenar celdas con texto, ajustar la alineación y los bordes, y personalizar la apariencia de la tabla.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva por su índice.
3. Definir una matriz de anchos de columna.
4. Definir una matriz de alturas de fila.
5. Añadir una [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a la diapositiva.
6. Recorrer cada [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) y formatear sus bordes superior, inferior, derecho e izquierdo.
7. Fusionar las dos primeras celdas en la primera fila de la tabla.
8. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de una [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/).
9. Añadir texto al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo crear una tabla en una presentación:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeración en tablas estándar**

En una tabla estándar, la numeración de celdas es directa y basada en cero. La primera celda de una tabla está indexada como (0, 0) (columna 0, fila 0).

Por ejemplo, en una tabla con 4 columnas y 4 filas, las celdas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

El siguiente ejemplo en Python muestra cómo referenciar celdas usando esta numeración basada en cero:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Acceder a una tabla existente**

Esta sección explica cómo localizar y trabajar con una tabla existente en una presentación usando Aspose.Slides. Aprenderá a encontrar la tabla en una diapositiva, acceder a sus filas, columnas y celdas, y actualizar el contenido o formato.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva que contiene la tabla por su índice.
3. Recorrer todos los objetos [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) hasta encontrar la tabla.
4. Usar el objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) para trabajar con la tabla.
5. Guardar la presentación modificada.

{{% alert color="info" %}}

Si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita mediante su propiedad `alternative_text`.

{{% /alert %}}

El siguiente ejemplo en Python muestra cómo acceder y trabajar con una tabla existente:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinear texto en tablas**

Esta sección muestra cómo controlar la alineación del texto dentro de las celdas de una tabla usando Aspose.Slides. Aprenderá a establecer la alineación horizontal y vertical de las celdas para mantener su contenido claro y coherente.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Añadir un objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a la diapositiva.
4. Acceder a un objeto [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) de la tabla.
5. Alinear el texto verticalmente.
6. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo alinear el texto en una tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer formato de texto a nivel de tabla**

Esta sección muestra cómo aplicar formato de texto a nivel de tabla en Aspose.Slides para que cada celda herede un estilo coherente y unificado. Aprenderá a establecer tamaños de fuente, alineaciones y márgenes de forma global.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Añadir una [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a la diapositiva.
4. Establecer el tamaño de fuente (altura de fuente) para el texto.
5. Establecer la alineación de párrafo y los márgenes.
6. Establecer la orientación vertical del texto.
7. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo aplicar sus opciones de formato preferidas al texto en una tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar estilos de tabla predefinidos**

Aspose.Slides le permite formatear tablas usando estilos predefinidos directamente en el código. El ejemplo muestra la creación de una tabla, la aplicación de un estilo predefinido y el guardado del resultado, una forma eficiente de asegurar un formato consistente y profesional.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Bloquear relación de aspecto de tablas**

La relación de aspecto de una forma es la proporción de sus dimensiones. Aspose.Slides proporciona la propiedad `aspect_ratio_locked`, que permite bloquear la relación de aspecto para tablas y otras formas.

El siguiente ejemplo en Python muestra cómo bloquear la relación de aspecto para una tabla:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda la tabla y el texto en sus celdas?**

Sí. La tabla expone una propiedad [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), y los párrafos tienen [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Usar ambas asegura el orden RTL correcto y el renderizado dentro de las celdas.

**¿Cómo puedo impedir que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/python-net/applying-protection-to-presentation/) para desactivar el movimiento, cambio de tamaño, selección, etc. Estos bloqueos se aplican también a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estiramiento o mosaico).