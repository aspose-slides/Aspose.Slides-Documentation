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
description: "Gestione fácilmente celdas de tabla en PowerPoint con Aspose.Slides para Python a través de Java. Domine el acceso, la modificación y el estilo de las celdas rápidamente para una automatización fluida de diapositivas."
---
## **Visión general**

Aspose.Slides permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla fusionadas, eliminar los bordes de las celdas, trabajar con la numeración de celdas después de fusionar o dividir celdas, cambiar el color de fondo de una celda y agregar una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

## **Identificar una celda de tabla fusionada**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtener la tabla de la primera diapositiva.
3. Recorrer las filas y columnas de la tabla para encontrar celdas fusionadas.
4. Imprimir un mensaje cuando se encuentren celdas fusionadas.

Este código Python le muestra cómo identificar celdas de tabla fusionadas en una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Suponga que la primera forma en la primera diapositiva es una tabla.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Eliminar los bordes de las celdas de la tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtener una referencia a una diapositiva por su índice.
3. Definir una lista de anchos de columna.
4. Definir una lista de alturas de fila.
5. Añadir una tabla a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addTable) .
6. Recorrer cada celda para borrar los bordes superior, inferior, derecho e izquierdo.
7. Guardar la presentación modificada como archivo PPTX.

Este código Python le muestra cómo eliminar los bordes de las celdas de la tabla:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definir anchos de columna y alturas de fila.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Añadir una tabla a la diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Establecer el formato de borde para cada celda.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Guardar la presentación como archivo PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeración en celdas fusionadas**

Si fusionamos dos pares de celdas, (1, 1) y (2, 1), y (1, 2) y (2, 2), la tabla resultante conserva su numeración de celdas. Este código Python demuestra el proceso:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definir anchos de columna y alturas de fila.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añadir una tabla a la diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Establecer el formato de borde para cada celda.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Fusionar celdas (1, 1) y (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Fusionar celdas (1, 2) y (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Guardar la presentación como archivo PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Luego fusionamos más celdas fusionando (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda fusionada en su centro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definir anchos de columna y alturas de fila.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añadir una tabla a la diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Establecer el formato de borde para cada celda.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Fusionar celdas (1, 1) y (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Fusionar celdas (1, 2) y (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Fusionar celdas (1, 1) y (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Guardar la presentación como archivo PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeración en una celda dividida**

En los ejemplos anteriores, fusionar celdas de tabla no cambió la numeración de las demás celdas.

Esta vez, tomamos una tabla regular (una tabla sin celdas fusionadas) y luego intentamos dividir la celda (1, 1) para obtener una tabla especial. Puede que quiera prestar atención a la numeración de esta tabla, que puede considerarse extraña. Sin embargo, así es como Microsoft PowerPoint numeriza las celdas de tabla y Aspose.Slides hace lo mismo.

Este código Python demuestra el proceso que describimos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definir anchos de columna y alturas de fila.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añadir una tabla a la diapositiva.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Establecer el formato de borde para cada celda.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Dividir la celda (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Guardar la presentación como archivo PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cambiar el color de fondo de la celda de tabla**

Este código Python le muestra cómo cambiar el color de fondo de una celda de tabla:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definir anchos de columna y alturas de fila.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Añadir una tabla a la diapositiva.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Establecer el color de fondo para una celda.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Guardar la presentación como archivo PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Agregar una imagen dentro de una celda de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtener una referencia a una diapositiva por su índice.
3. Definir una lista de anchos de columna.
4. Definir una lista de alturas de fila.
5. Añadir una tabla a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addTable) .
6. Cargar el archivo de imagen usando [Images.fromFile](https://reference.aspose.com/slides/es/python-java/aspose.slides/images/#fromFile) .
7. Añadir la imagen a la presentación para crear un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) .
8. Establecer el tipo de relleno de la [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) de la celda de la tabla a [FillType.Picture](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/#Picture) .
9. Añadir la imagen a la primera celda de la tabla.
10. Guardar la presentación modificada como archivo PPTX.

Este código Python le muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Definir anchos de columna y alturas de fila.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Añadir una tabla a la diapositiva.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Crear una imagen de presentación a partir del archivo de imagen.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Añadir la imagen a la primera celda de la tabla.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Guardar la presentación como archivo PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/es/python-java/aspose.slides/cellformat/#getBorderRight) tienen propiedades separadas, de modo que el grosor y el estilo de cada lado pueden diferir. Esto sigue lógicamente del control de bordes por lado para una celda demostrado en el artículo.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan. El artículo menciona los modos de visualización de la imagen en una celda.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/python-java/manage-hyperlinks/) se establecen a nivel del texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda soporta [portions](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) (runs) con formato independiente—familia de fuente, estilo, tamaño y color.