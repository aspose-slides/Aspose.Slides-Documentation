---
title: Gestionar celdas de tabla en presentaciones usando Python
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/python-java/manage-cells/
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
description: "Gestiona celdas de tabla de PowerPoint en Python: identifica celdas combinadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para Python mediante Java."
---
## **Visión general**

Aspose.Slides le permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla combinadas, eliminar los bordes de las celdas, trabajar con la numeración de celdas después de combinar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de las celdas mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

Aspose.Slides utiliza índices basados en cero para acceder a las celdas de tabla en el orden `(column, row)`.

## **Identificar una celda de tabla combinada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Se asume que la diapositiva y la forma existen y que la forma es una tabla. Luego recorre todas las filas y columnas y utiliza [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) para identificar celdas en regiones combinadas. Para cada coincidencia, muestra las coordenadas de la celda en orden `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) y las coordenadas iniciales de la región, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) y [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Eliminar bordes de celdas de tabla**

Cree una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Los anchos de columna, alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda en [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), haciéndolos invisibles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Combinar celdas de tabla**

Utilice [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) para combinar un rango rectangular de celdas en una sola celda. Especifique las celdas en las esquinas superior‑izquierda e inferior‑derecha del rango. El argumento final controla si la combinación puede incluir celdas fuera del rango especificado; `False` mantiene la combinación dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, luego combina las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla conserva cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda combinada, use su posición superior‑izquierda: `table.get_Item(1, 1)` en este ejemplo. Las demás posiciones del rango combinado siguen formando parte de la cuadrícula, por lo que los índices de las celdas fuera del rango no cambian.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dividir celdas de tabla**

Combinar celdas en el ejemplo anterior conserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas situadas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tablas de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) sobre la celda `(1, 1)`. La mitad del ancho de 70 puntos se pasa para crear dos celdas de ancho igual.

Después de esta división, las dos mitades se acceden como `table.get_Item(1, 1)` y `table.get_Item(2, 1)`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas originalmente en las columnas 2 y 3 pasan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Utilice estos índices de columna actualizados al acceder a las celdas después de la división.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dividir celdas combinadas por extensión de fila o columna**

Para preparar las celdas de plantilla combinadas para la población de datos, use [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) para dividir a lo largo de un límite de fila existente, o [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región combinada:

- División de fila: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- División de columna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

El ejemplo asume que una presentación tiene una tabla como primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` combinados verticalmente. Partiendo de la posición inferior, utiliza [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) y [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) para localizar el origen y comprueba ambas extensiones. `splitByRowSpan(1)` separa entonces las filas 2 y 3 para los nombres de producto. Para una combinación horizontal de dos columnas, use `splitByColSpan(1)` en su lugar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Recuperar las celdas resultantes de la tabla tras la división.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

La cuadrícula de la tabla y los índices de las celdas circundantes permanecen sin cambios. Recupere las celdas resultantes por sus coordenadas; aquí, ambas tienen extensiones de 1 y [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) muestra `False`. Regiones más grandes pueden permanecer parcialmente combinadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de la celda, como relleno, bordes y márgenes. Rellene las celdas después de dividir y establezca cualquier formato de texto necesario de forma explícita.

La presentación guardada contiene celdas separadas "Product A" y "Product B" con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) para más detalles.

## **Cambiar el color de fondo de la celda de tabla**

Este ejemplo crea una tabla con columnas de 150 puntos y filas de 50 puntos. Utiliza [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) para seleccionar un relleno sólido y establece el color devuelto por [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. Carga la imagen con [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) y la añade a la colección de imágenes de la presentación con [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Luego asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) estira la imagen para que ocupe toda la celda, lo que puede modificar su proporción. Los anchos de columna y las alturas de fila están en puntos. La imagen cargada se elimina en un bloque `finally` después de añadirse a la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/python-java/manage-hyperlinks/) se establecen a nivel de porción de texto dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (segmentos) con formato independiente: familia de fuente, estilo, tamaño y color.