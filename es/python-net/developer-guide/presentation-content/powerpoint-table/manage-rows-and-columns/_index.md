---
title: Administrar Filas y Columnas
type: docs
weight: 20
url: /python-net/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de tabla, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Gestionar filas y columnas de tabla en presentaciones de PowerPoint en Python"
---

Para permitirte gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) y muchos otros tipos.

## **Establecer la Primera Fila como Encabezado**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación. 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) y configúralo como nulo.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) para encontrar la tabla relevante. 
5. Establece la primera fila de la tabla como su encabezado. 

Este código Python te muestra cómo establecer la primera fila de una tabla como su encabezado:

```python
import aspose.slides as slides

# Instancia la clase Presentation
with slides.Presentation("table.pptx") as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Inicializa el TableEx nulo
    tbl = None

    # Itera a través de las formas y establece una referencia a la tabla
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Establece la primera fila de una tabla como su encabezado 
    tbl.first_row = True
    
    # Guarda la presentación en disco
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación, 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) a la diapositiva a través del método `add_table(x, y, column_widths, row_heights)`.
6. Clona la fila de la tabla.
7. Clona la columna de la tabla.
8. Guarda la presentación modificada.

Este código Python te muestra cómo clonar una fila o columna de una tabla de PowerPoint:

```python
import aspose.slides as slides

# Instancia la clase Presentation
with slides.Presentation() as presentation:

    # Accede a la primera diapositiva
    sld = presentation.slides[0]

    # Define columnas con anchuras y filas con alturas
    dblCols = [50, 50, 50] 
    dblRows = [50, 30, 30, 30, 30] 

    # Agrega una forma de tabla a la diapositiva
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Agrega texto a la celda 1 de la fila 1
    table.rows[0][0].text_frame.text = "Fila 1 Celda 1"

    # Agrega texto a la celda 2 de la fila 1
    table.rows[1][0].text_frame.text = "Fila 1 Celda 2"

    # Clona la fila 1 al final de la tabla
    table.rows.add_clone(table.rows[0], False)

    # Agrega texto a la celda 1 de la fila 2
    table.rows[0][1].text_frame.text = "Fila 2 Celda 1"

    # Agrega texto a la celda 2 de la fila 2
    table.rows[1][1].text_frame.text = "Fila 2 Celda 2"

    # Clona la fila 2 como la 4ª fila de la tabla
    table.rows.insert_clone(3, table.rows[1], False)

    # Clona la primera columna al final
    table.columns.add_clone(table.columns[0], False)

    # Clona la 2ª columna en el índice de la 4ª columna
    table.columns.insert_clone(3, table.columns[1], False)
    
    # Guarda la presentación en disco
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación, 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) a la diapositiva a través del método `add_table(x, y, column_widths, row_heights)`.
6. Elimina la fila de la tabla.
7. Elimina la columna de la tabla.
8. Guarda la presentación modificada. 

Este código Python te muestra cómo eliminar una fila o columna de una tabla:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth = [100, 50, 30] 
    rowHeight = [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Formato de Texto a Nivel de Fila de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación, 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede al objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) relevante desde la diapositiva. 
4. Establece la `font_height` de las celdas de la primera fila.
5. Establece el `alignment` y `margin_right` de las celdas de la primera fila. 
6. Establece el `text_vertical_type` de las celdas de la segunda fila.
7. Guarda la presentación modificada.

Este código Python demuestra la operación.

```python
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Establece la altura de fuente de las celdas de la primera fila
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # Establece la alineación del texto y el margen derecho de las celdas de la primera fila
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # Establece el tipo de texto vertical de las celdas de la segunda fila
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)

    # Guarda la presentación en disco
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Formato de Texto a Nivel de Columna de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación, 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede al objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) relevante desde la diapositiva. 
4. Establece la `font_height` de las celdas de la primera columna.
5. Establece el `alignment` y `margin_right` de las celdas de la primera columna. 
6. Establece el `text_vertical_type` de las celdas de la segunda columna.
7. Guarda la presentación modificada. 

Este código Python demuestra la operación:

```python
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Establece la altura de fuente de las celdas de la primera columna
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # Establece la alineación del texto y el margen derecho de las celdas de la primera columna 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # Establece el tipo de texto vertical de las celdas de la segunda columna
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # Guarda la presentación en disco
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener Propiedades de Estilo de Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo para una tabla para que puedas usar esos detalles para otra tabla o en otro lugar. Este código Python te muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```