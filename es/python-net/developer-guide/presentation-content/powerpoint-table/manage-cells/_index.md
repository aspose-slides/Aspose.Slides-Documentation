---
title: Administrar celdas de tabla en presentaciones con Python
linktitle: Administrar celdas
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
description: "Administre fácilmente las celdas de tabla en PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET. Domine el acceso, la modificación y el estilo de celdas rápidamente para una automatización de diapositivas sin problemas."
---

## **Visión general**

Este artículo muestra cómo trabajar con celdas de tabla en presentaciones usando Aspose.Slides. Aprenderá a detectar celdas combinadas, a borrar o personalizar los bordes de las celdas y a entender cómo PowerPoint numera las celdas después de operaciones de combinar y dividir, de modo que pueda predecir la indexación en diseños complejos. El artículo también demuestra tareas comunes de formato—como cambiar el relleno de fondo de una celda—y muestra cómo colocar una imagen directamente dentro de una celda de tabla con configuraciones de relleno de imagen. Cada escenario va acompañado de ejemplos concisos en Python que crean o editan tablas y luego guardan la presentación actualizada, para que pueda adaptar los fragmentos a sus propias diapositivas rápidamente.

## **Identificar celdas de tabla combinadas**

Las tablas a menudo contienen celdas combinadas para encabezados o para agrupar datos relacionados. En esta sección verá cómo determinar si una celda específica pertenece a una región combinada y cómo referenciar la celda maestra (superior‑izquierda) para leer o formatear todo el bloque de forma consistente.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la tabla de la primera diapositiva.
1. Recorra las filas y columnas de la tabla para encontrar celdas combinadas.
1. Imprima un mensaje cuando se encuentren celdas combinadas.

El siguiente código Python identifica celdas de tabla combinadas en una presentación:

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

A veces los bordes de la tabla distraen del contenido o generan desorden visual. Esta sección muestra cómo eliminar bordes de celdas seleccionadas—o de lados específicos de una celda—para lograr un diseño más limpio y alineado con la estética de su diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenga la diapositiva por su índice.
1. Defina un arreglo de anchos de columnas.
1. Defina un arreglo de alturas de filas.
1. Añada una tabla a la diapositiva usando el método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
1. Recorra cada celda para borrar los bordes superior, inferior, izquierdo y derecho.
1. Guarde la presentación modificada como archivo PPTX.

El siguiente código Python muestra cómo eliminar bordes de celdas de tabla:

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

    # Borrar el relleno del borde para cada celda.
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

Si combina dos pares de celdas—por ejemplo, (1, 1) x (2, 1) y (1, 2) x (2, 2)—la tabla resultante mantendrá la misma numeración de celdas que la tabla sin combinar. El siguiente código Python demuestra este comportamiento:

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

    # Combinar celdas (1,2) y (2,2).
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

Salida:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numeración en celdas divididas**

En el ejemplo anterior, cuando las celdas de la tabla se combinaron, la numeración en las demás celdas no cambió. Esta vez, creamos una tabla normal (sin celdas combinadas) y luego dividimos la celda (1, 1) para producir una tabla especial. Preste atención a la numeración de esta tabla—puede parecer inusual. Sin embargo, así es como Microsoft PowerPoint numera las celdas de tabla, y Aspose.Slides sigue el mismo comportamiento.

El siguiente código Python demuestra este comportamiento:

```python
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir anchos de columnas y alturas de filas.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añadir una forma de tabla a la diapositiva.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Dividir la celda (1,1).
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

Salida:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Cambiar el color de fondo de la celda de tabla**

El siguiente ejemplo en Python muestra cómo cambiar el color de fondo de una celda de tabla:

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

Esta sección muestra cómo insertar una imagen en una celda de tabla en Aspose.Slides. Cubre la aplicación de un relleno de imagen a la celda de destino y la configuración de opciones de visualización como estiramiento o mosaico.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenga una referencia a la diapositiva por su índice.
1. Defina un arreglo de anchos de columnas.
1. Defina un arreglo de alturas de filas.
1. Añada una tabla a la diapositiva con el método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
1. Cargue la imagen desde un archivo.
1. Añada la imagen a las imágenes de la presentación para obtener un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) .
1. Establezca el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la celda de tabla a `PICTURE` .
1. Aplique la imagen a la celda de tabla y elija un modo de relleno (p. ej., `STRETCH`) .
1. Guarde la presentación como archivo PPTX.

El siguiente código Python muestra cómo colocar una imagen dentro de una celda de tabla al crear la tabla:

```python
import aspose.slides as slides

# Instanciar un objeto Presentation.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir anchos de columnas y alturas de filas.
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

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [superior](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[inferior](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[izquierda](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[derecha](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir. Esto sigue lógicamente del control de borde por lado para una celda demostrado en el artículo.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [modo de relleno](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan. El artículo menciona los modos de visualización de la imagen en una celda.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

Los [Hyperlinks](/slides/es/python-net/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [porciones](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) con formato independiente—familia de fuente, estilo, tamaño y color.