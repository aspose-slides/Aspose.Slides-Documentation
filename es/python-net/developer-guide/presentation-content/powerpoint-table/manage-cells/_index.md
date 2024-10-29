---
title: Gestionar Celdas
type: docs
weight: 30
url: /es/python-net/manage-cells/
keywords: "Tabla, celdas combinadas, celdas divididas, imagen en celda de tabla, Python, Aspose.Slides para Python a través de .NET"
description: "Celdas de tabla en presentaciones de PowerPoint en Python"
---

## **Identificar Celda de Tabla Combinada**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la tabla de la primera diapositiva.
3. Recorre las filas y columnas de la tabla para encontrar celdas combinadas.
4. Imprime un mensaje cuando se encuentren celdas combinadas.

Este código Python te muestra cómo identificar celdas de tabla combinadas en una presentación:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # asumiendo que #0.Shape#0 es una tabla
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("La celda 01 es parte de una celda combinada con RowSpan=2 y ColSpan=3, comenzando desde la celda 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **Eliminar Bordes de Celdas de Tabla**
1. Crea una instancia de la clase `Presentation`.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Define un arreglo de columnas con ancho.
4. Define un arreglo de filas con altura.
5. Agrega una tabla a la diapositiva a través del método `AddTable`.
6. Recorre cada celda para limpiar los bordes superior, inferior, derecho e izquierdo.
7. Guarda la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo eliminar los bordes de las celdas de tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
   # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # Agrega una forma de tabla a la diapositiva
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Establece el formato del borde para cada celda
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Escribe el archivo PPTX en disco
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Numeración en Celdas Combinadas**
Si combinamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante será numerada. Este código Python demuestra el proceso:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as presentation:
    # Accede a la primera diapositiva
    sld = presentation.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Agrega una forma de tabla a la diapositiva
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Establece el formato del borde para cada celda
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Combina celdas (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # Combina celdas (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

Luego combinamos las celdas aún más combinando (1, 1) y (1, 2). El resultado es una tabla que contiene una celda combinada grande en su centro:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as presentation:
    # Accede a la primera diapositiva
    slide = presentation.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # Agrega una forma de tabla a la diapositiva
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Establece el formato del borde para cada celda
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Combina celdas (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Combina celdas (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Combina celdas (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # Escribe el archivo PPTX en disco
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeración en Celda Dividida**
En los ejemplos anteriores, cuando las celdas de la tabla se combinaban, la numeración o el sistema de números en las otras celdas no cambiaba. 

Esta vez, tomamos una tabla normal (una tabla sin celdas combinadas) y luego intentamos dividir la celda (1,1) para obtener una tabla especial. Puede que desees prestar atención a la numeración de esta tabla, que podría considerarse extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de la tabla y Aspose.Slides hace lo mismo. 

Este código Python demuestra el proceso que describimos:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as presentation:
    # Accede a la primera diapositiva
    slide = presentation.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Agrega una forma de tabla a la diapositiva
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Establece el formato del borde para cada celda
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Combina celdas (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Combina celdas (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Divide la celda (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Escribe el archivo PPTX en disco
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar el Color de Fondo de la Celda de Tabla**

Este código Python te muestra cómo cambiar el color de fondo de una celda de tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # crea una nueva tabla
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # establece el color de fondo para una celda 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Imagen Dentro de la Celda de Tabla**
1. Crea una instancia de la clase `Presentation`.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Define un arreglo de columnas con ancho.
4. Define un arreglo de filas con altura.
5. Agrega una tabla a la diapositiva a través del método `AddTable`. 
6. Crea un objeto `Bitmap` para contener el archivo de imagen.
7. Agrega la imagen del bitmap al objeto `IPPImage`.
8. Establece el `FillFormat` para la celda de tabla como `Picture`.
9. Agrega la imagen a la primera celda de la tabla.
10. Guarda la presentación modificada como un archivo PPTX.

Este código Python te muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia un objeto de la clase Presentation
with slides.Presentation() as presentation:
    # Accede a la primera diapositiva
    islide = presentation.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # Agrega una forma de tabla a la diapositiva
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # Crea un objeto de imagen Bitmap para contener el archivo de imagen
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # Crea un objeto IPPImage usando el objeto bitmap
    imgx1 = presentation.images.add_image(image)

    # Agrega la imagen a la primera celda de la tabla
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # Guarda el PPTX en disco
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```