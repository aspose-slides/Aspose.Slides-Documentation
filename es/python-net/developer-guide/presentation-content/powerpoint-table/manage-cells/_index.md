---
title: Gestionar celdas de tabla en presentaciones con Python
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/python-net/manage-cells/
keywords:
- celda de tabla
- fusionar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestiona celdas de tabla de PowerPoint en Python: identifica celdas fusionadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para Python a través de .NET."
---
## **Resumen**

Aspose.Slides le permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla fusionadas, eliminar bordes de celda, trabajar con la numeración de celdas después de fusionar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

Aspose.Slides utiliza índices basados en cero. Las coordenadas en este artículo se escriben como `(columna, fila)`.

## **Identificar una celda de tabla fusionada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Se asume que la diapositiva y la forma existen y que la forma es una tabla. Luego recorre todas las filas y columnas y utiliza [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) para identificar celdas en regiones fusionadas. Para cada coincidencia, muestra las coordenadas de la celda en orden `fila;columna`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), y las coordenadas de inicio de la región, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) y [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

Cree una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Los anchos de columna, alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), haciéndolos invisibles.

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

## **Añadir bordes diagonales a la celda**

Utilice [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) para dibujar una línea desde la esquina superior izquierda a la inferior derecha, y [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) para dibujar una línea desde la esquina inferior izquierda a la superior derecha. Una diagonal puede marcar un encabezado de esquina; ambas diagonales pueden formar una X para indicar que una celda no es aplicable.

Cada diagonal es una [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). En su [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), establezca [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) a [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) y elija un [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Defina el [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) de la línea en puntos.

El ejemplo crea tres celdas en una fila: una diagonal roja descendente, una diagonal azul ascendente y ambas diagonales. Deja sin cambios los bordes superior, inferior, izquierdo y derecho de la celda.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Una diagonal es una propiedad de formato, no una división de celda. Cada celda conserva un único [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); las regiones a ambos lados de una diagonal no pueden editarse independientemente.

La tabla guardada, renderizada en Microsoft PowerPoint:

![Tres celdas de tabla que muestran una diagonal roja de la esquina superior izquierda a la inferior derecha, una diagonal azul de la esquina inferior izquierda a la superior derecha y ambas diagonales formando una X.](diagonal-cell-borders.png)

*De izquierda a derecha: diagonal descendente (roja, 3 pt), diagonal ascendente (azul, 5 pt) y ambas diagonales.*

## **Fusionar celdas de tabla**

Utilice [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) para combinar un rango rectangular de celdas en una sola celda. Especifique las celdas en las esquinas superior izquierda e inferior derecha del rango. El argumento final controla si la fusión puede incluir celdas fuera del rango especificado; `False` mantiene la fusión dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 pt, luego fusiona las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla mantiene cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda fusionada, use su posición superior izquierda: `table.rows[1][1]` en este ejemplo. Las demás posiciones del rango fusionado siguen formando parte de la cuadrícula, por lo que los índices de las celdas fuera del rango no cambian.

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

Fusionar celdas en el ejemplo anterior conserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tablas de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 pt y llama a [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) sobre la celda `(1, 1)`. La mitad del ancho de 70 pt de la celda se pasa para crear dos celdas de ancho igual.

Tras esta división, las dos mitades se acceden como `table.rows[1][1]` y `table.rows[1][2]`. La cuadrícula ahora tiene cinco columnas: las celdas originalmente en las columnas 2 y 3 pasan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Utilice estos índices de columna actualizados al acceder a celdas después de la división.

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


<!-- visual-explanation:manage-cells:start -->
[![Una celda no fusionada de 70 pt se divide en dos celdas de 35 pt, añadiendo una quinta columna en la cuadrícula y desplazando los índices a su derecha.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La división de ancho afecta a la celda (1, 1), usando índices basados en cero (columna, fila). Otras filas conservan una celda que abarca ambas nuevas posiciones de columna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir celdas fusionadas por rango de filas o columnas**

Para preparar celdas de plantilla fusionadas para la población de datos, utilice [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) para dividir a lo largo de un límite de fila existente, o [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región fusionada:

- División de fila: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- División de columna: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

El ejemplo supone que una presentación tiene una tabla como la primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` fusionados verticalmente. Partiendo de la posición inferior, utiliza [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) y [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) para localizar el origen y verifica ambas fusiones. `split_by_row_span` con un índice de 1 separa entonces las filas 2 y 3 para los nombres de producto. Para una fusión horizontal de dos columnas, use `split_by_col_span` con un índice de 1.

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

        # Recuperar las celdas resultantes de la tabla después de dividir.
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

La cuadrícula de la tabla y los índices de celda circundantes permanecen sin cambios. Recupere las celdas resultantes mediante sus coordenadas; aquí, ambas tienen un rango de 1 y [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) devuelve `False`. Regiones más grandes pueden quedar parcialmente fusionadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de celda como relleno, bordes y márgenes. Rellene las celdas después de dividir y establezca explícitamente cualquier formato de texto necesario.

La presentación guardada contiene celdas separadas “Product A” y “Product B” con el formato de celda de la plantilla mantenido. Consulte la [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) para más detalles.

### **Dividir una celda a una altura específica**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) recibe la altura de la parte superior en puntos. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) recibe el número de filas de cuadrícula existentes en la parte superior. Para centrar verticalmente una celda de 40 pt en la columna derecha, reste 40 de la altura real de la celda y divida el espacio restante equitativamente arriba y abajo.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

La primera división añade una fila a la cuadrícula, dejando los 90 pt inferiores en `table.rows[1][1]`. La segunda división segmenta esa celda en una celda central de 40 pt y una celda inferior de 50 pt. Las tres celdas de la columna derecha ahora miden 50, 40 y 50 pt de alto de arriba a abajo. La celda izquierda abarca las tres filas con su altura original de 140 pt.

![La celda izquierda abarca toda la altura de la tabla junto a tres celdas con “Middle” en el centro.](split-by-height.png)

## **Cambiar el color de fondo de la celda de tabla**

Este ejemplo crea una tabla con columnas de 150 pt y filas de 50 pt. Establece [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) a sólido y [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. La carga la imagen con [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) y la añade a la colección de imágenes de la presentación con [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Luego asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) estira la imagen para llenar la celda, lo que puede cambiar su proporción. Los anchos de columna y las alturas de fila están en puntos. La imagen cargada se elimina automáticamente cuando finaliza su bloque `with`.

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

Sí. Los bordes superior, inferior, izquierdo y derecho ([top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/)) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

Los [Hyperlinks](/slides/es/python-net/manage-hyperlinks/) se establecen a nivel de porción de texto dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo usar diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (segmentos) con formato independiente: familia, estilo, tamaño y color de fuente.