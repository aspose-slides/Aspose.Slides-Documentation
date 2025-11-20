---
title: Gestionar celdas de tabla en presentaciones con Python
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/python-net/manage-cells/
keywords:
- celda de tabla
- combinar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Gestiona sin esfuerzo celdas de tabla en PowerPoint y OpenDocument con Aspose.Slides para Python vía .NET. Domina el acceso, la modificación y el estilo de celdas rápidamente para una automatización fluida de diapositivas."
---

## **Descripción general**

Este artículo muestra cómo trabajar con celdas de tabla en presentaciones usando Aspose.Slides. Aprenderá a detectar celdas combinadas, borrar o personalizar los bordes de las celdas y comprender cómo PowerPoint numera las celdas después de operaciones de combinación y división para que pueda predecir la indexación en diseños complejos. El artículo también demuestra tareas comunes de formato—como cambiar el relleno de fondo de una celda—y muestra cómo colocar una imagen directamente dentro de una celda de tabla mediante la configuración de relleno de imagen. Cada escenario va acompañado de ejemplos concisos en Python que crean o editan tablas y luego guardan la presentación actualizada, para que pueda adaptar los fragmentos a sus propias diapositivas rápidamente.

## **Identificar celdas de tabla combinadas**

Las tablas a menudo contienen celdas combinadas para encabezados o para agrupar datos relacionados. En esta sección verá cómo determinar si una celda específica pertenece a una región combinada y cómo referenciar la celda maestra (superior‑izquierda) para leer o dar formato al bloque completo de forma consistente.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
1. Get the table from the first slide.  
1. Iterate through the table’s rows and columns to find merged cells.  
1. Print a message when merged cells are found.

The following Python code identifies merged table cells in a presentation:
```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Suponiendo que la primera forma en la primera diapositiva es una tabla.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```


## **Eliminar bordes de celdas de tabla**

A veces los bordes de la tabla distraen del contenido o crean desorden visual. Esta sección muestra cómo eliminar los bordes de celdas seleccionadas—o de lados específicos de una celda—para lograr un diseño más limpio y alineado con el estilo de su diapositiva.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
1. Get the slide by its index.  
1. Define an array of column widths.  
1. Define an array of row heights.  
1. Add a table to the slide using the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.  
1. Iterate through each cell to clear the top, bottom, left, and right borders.  
1. Save the modified presentation as a PPTX file.

The following Python code shows how to remove borders from table cells:
```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir columnas con anchos y filas con alturas.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Añadir una forma de tabla a la diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Limpiar el relleno del borde de cada celda.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Guardar el archivo PPTX en disco.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Numeración en celdas combinadas**

If you merge two pairs of cells—for example, (1, 1) x (2, 1) and (1, 2) x (2, 2)—the resulting table will keep the same cell numbering as the table without merging. The following Python code demonstrates this behavior:
```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir columnas con anchos y filas con alturas.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añadir una forma de tabla a la diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Combinar celdas (1,1) y (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Combinar celdas (1, 2) y (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Imprimir los índices de las celdas.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Guardar el archivo PPTX en disco.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```


Output:
```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```


## **Numeración en celdas divididas**

In previous example, when table cells were merged, the numbering in the other cells did not change. This time, we create a regular table (with no merged cells) and then split cell (1, 1) to produce a special table. Pay attention to this table’s numbering—it may look unusual. However, this is how Microsoft PowerPoint numbers table cells, and Aspose.Slides follows the same behavior.

The following Python code demonstrates this behavior:
```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir anchos de columna y alturas de fila.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añadir una forma de tabla a la diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Dividir la celda (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Imprimir los índices de las celdas.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Guardar el archivo PPTX en disco.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


Output:
```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```


## **Cambiar color de fondo de la celda de tabla**

The following Python example demonstrates how to change a table cell’s background color:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Crear una tabla nueva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Establecer el color de fondo para una celda.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```


## **Insertar imágenes en celdas de tabla**

Esta sección muestra cómo insertar una imagen en una celda de tabla en Aspose.Slides. Cubre la aplicación de un relleno de imagen a la celda objetivo y la configuración de opciones de visualización como estirar o mosaico.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
1. Get a slide reference by its index.  
1. Define an array of column widths.  
1. Define an array of row heights.  
1. Add a table to the slide with the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.  
1. Load the image from a file.  
1. Add the image to the presentation’s images to obtain a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).  
1. Set the table cell’s [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `PICTURE`.  
1. Apply the image to the table cell and choose a fill mode (e.g., `STRETCH`).  
1. Save the presentation as a PPTX file.

The following Python code shows how to place an image inside a table cell when creating a table:
```python
import aspose.slides as slides

# Instanciar un objeto Presentation.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir anchos de columna y alturas de fila.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Añadir una forma de tabla a la diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Cargar la imagen y añadirla a la presentación para obtener un PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Aplicar la imagen a la primera celda de la tabla.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Guardar la presentación en disco.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Puedo establecer diferentes grosores y estilos de línea para los diferentes lados de una sola celda?**

Yes. The [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) borders have separate properties, so the thickness and style of each side can differ. This logically follows from the per-side border control for a cell demonstrated in the article.

**¿Qué le ocurre a la imagen si cambio el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated. The article mentions the image display modes in a cell.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/python-net/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.