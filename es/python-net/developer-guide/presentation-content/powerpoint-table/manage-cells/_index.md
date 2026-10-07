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
- presentación
- Python
- Aspose.Slides
description: "Gestiona celdas de tabla de PowerPoint en Python: identifica celdas combinadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para Python vía .NET."
---
## **Visión general**

Aspose.Slides permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla combinadas, eliminar los bordes de las celdas, trabajar con la numeración de celdas después de combinar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

Aspose.Slides utiliza índices basados en cero. Las coordenadas en este artículo se escriben como `(column, row)`.

## **Identificar una celda de tabla combinada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Asume que la diapositiva y la forma existen y que la forma es una tabla. Luego itera por todas las filas y columnas y usa [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) para identificar celdas en regiones combinadas. Para cada coincidencia, imprime las coordenadas de la celda en orden `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), y las coordenadas de inicio de la región, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) y [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Eliminar los bordes de la celda de tabla**

Cree una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Las anchuras de columna, alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), haciéndolos invisibles.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Combinar celdas de tabla**

Utilice [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) para combinar un rango rectangular de celdas de tabla en una sola celda. Especifique las celdas en la esquina superior izquierda y la esquina inferior derecha del rango. El argumento final controla si la combinación puede incluir celdas fuera del rango especificado; `False` mantiene la combinación dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, y luego combina las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla conserva cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda combinada, use su posición superior izquierda: `table.rows[1][1]` en este ejemplo. Las demás posiciones del rango combinado siguen formando parte de la cuadrícula de la tabla, por lo que los índices de las celdas fuera del rango no cambian.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Dividir celdas de tabla**

Combinar celdas en el ejemplo anterior preserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas situadas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tablas de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) sobre la celda `(1, 1)`. Se pasa la mitad del ancho de 70 puntos de la celda para crear dos celdas de ancho igual.

Después de esta división, las dos mitades se acceden como `table.rows[1][1]` y `table.rows[1][2]`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas que estaban originalmente en las columnas 2 y 3 pasan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Utilice estos índices de columna actualizados al acceder a las celdas después de la división.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Dividir celdas combinadas por extensión de fila o columna**

Para preparar celdas de plantilla combinadas para la población de datos, use [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) para dividir a lo largo de un límite de fila existente, o [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región combinada:

- División de fila: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- División de columna: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

El ejemplo asume que una presentación tiene una tabla como primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` combinados verticalmente. Partiendo de la posición inferior, usa [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) y [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) para localizar el origen y verifica ambas extensiones. `split_by_row_span` con un índice de 1 separa entonces las filas 2 y 3 para los nombres de producto. Para una combinación horizontal de dos columnas, use `split_by_col_span` con un índice de 1 en su lugar.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Recupera las celdas resultantes de la tabla después de dividir.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

La cuadrícula de la tabla y los índices de las celdas circundantes permanecen sin cambios. Recupere las celdas resultantes por sus coordenadas; aquí, ambas tienen extensiones de 1 y [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) devuelve `False`. Regiones más grandes pueden quedar parcialmente combinadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de celda, como relleno, bordes y márgenes. Rellene las celdas después de dividir y establezca cualquier formato de texto requerido de forma explícita.

La presentación guardada contiene celdas separadas “Product A” y “Product B” con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) para más detalles.

## **Cambiar el color de fondo de la celda de tabla**

Este ejemplo crea una tabla con columnas de 150 puntos y filas de 50 puntos. Establece [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) a sólido y [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. Carga la imagen con [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) y la añade a la colección de imágenes de la presentación con [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Luego asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) estira la imagen para cubrir la celda, lo que puede cambiar su proporción. Las anchuras de columna y alturas de fila están en puntos. La imagen cargada se elimina automáticamente cuando finaliza su bloque `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) tienen propiedades separadas, por lo que el grosor y el estilo de cada lado pueden diferir.

**¿Qué ocurre con la imagen si modifico el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/python-net/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) con formato independiente: familia de fuente, estilo, tamaño y color.