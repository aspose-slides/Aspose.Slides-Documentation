---
title: Administrar filas y columnas en tablas de PowerPoint usando Python
linktitle: Filas y columnas
type: docs
weight: 20
url: /es/python-net/manage-rows-and-columns/
keywords:
- fila de tabla
- columna de tabla
- primera fila
- encabezado de tabla
- clonar fila
- clonar columna
- copiar fila
- copiar columna
- eliminar fila
- eliminar columna
- formato de texto de fila
- formato de texto de columna
- estilo de tabla
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Administre filas y columnas de tabla en PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET y acelere la edición de presentaciones y la actualización de datos."
---

## **Descripción general**

Este artículo muestra cómo administrar filas y columnas de tabla en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides for Python. Aprenderá cómo agregar, insertar, clonar y eliminar filas o columnas, marcar la primera fila como encabezado, ajustar el tamaño y el diseño, y aplicar formato de texto y estilo a nivel de fila o columna. Cada tarea se demuestra con fragmentos de código compactos y autocontenidos basados en la API [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), para que pueda encontrar rápidamente una tabla en una diapositiva y remodelar su estructura según su diseño.

## **Establecer la primera fila como encabezado**

Marque la primera fila de la tabla como encabezado para distinguir claramente los títulos de columna de los datos. En Aspose.Slides for Python, simplemente habilite la opción *First Row* de la tabla para aplicar el formato de encabezado definido por el estilo de tabla seleccionado.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación.  
1. Acceda a la diapositiva por su índice.  
1. Recorra todos los objetos [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para encontrar la tabla pertinente.  
1. Establezca la primera fila de la tabla como encabezado.

Este código Python muestra cómo establecer la primera fila de una tabla como su encabezado:
```python
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Recorrer las formas y obtener una referencia a la tabla.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Establecer la primera fila de la tabla como encabezado.
    table.first_row = True
    
    # Guardar la presentación en disco.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clonar una fila o columna de tabla**

Clone cualquier fila o columna de tabla e inserte la copia en la posición deseada dentro de la tabla. El duplicado conserva el contenido de las celdas, el formato y los tamaños, lo que le permite ampliar los diseños de forma rápida y coherente.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación.  
1. Acceda a la diapositiva por su índice.  
1. Defina una matriz de anchos de columna.  
1. Defina una matriz de alturas de fila.  
1. Añada una [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) a la diapositiva mediante `add_table(x, y, column_widths, row_heights)`.  
1. Clone una fila de tabla.  
1. Clone una columna de tabla.  
1. Guarde la presentación modificada.

Este código Python muestra cómo clonar una fila y una columna de una tabla de PowerPoint:
```python
 import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Definir anchos de columna y alturas de fila.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Agregar una tabla a la diapositiva.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Agregar texto a la fila 1, columna 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Agregar texto a la fila 2, columna 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Clonar la fila 1 al final de la tabla.
    table.rows.add_clone(table.rows[0], False)

    # Agregar texto a la fila 1, columna 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Agregar texto a la fila 2, columna 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Clonar la fila 2 como la cuarta fila de la tabla.
    table.rows.insert_clone(3,table.rows[1], False)

    # Clonar la primera columna al final.
    table.columns.add_clone(table.columns[0], False)

    # Clonar la segunda columna en el índice 3 (la cuarta posición).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Guardar la presentación en disco.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar una fila o columna de una tabla**

Simplifique una tabla eliminando cualquier fila o columna por índice usando Aspose.Slides for Python; el diseño se readapta automáticamente mientras conserva el formato de las celdas restantes. Esto es útil para simplificar cuadrículas de datos o suprimir marcadores de posición sin reconstruir la tabla.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación.  
1. Acceda a la diapositiva por su índice.  
1. Defina una matriz de anchos de columna.  
1. Defina una matriz de alturas de fila.  
1. Añada un ITable a la diapositiva mediante `add_table(x, y, column_widths, row_heights)`.  
1. Elimine la fila de la tabla.  
1. Elimine la columna de la tabla.  
1. Guarde la presentación modificada.

El siguiente código Python muestra cómo eliminar una fila y una columna de una tabla:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer formato de texto a nivel de fila de tabla**

Aplique un estilo de texto coherente a toda una fila de tabla de una sola vez. Con Aspose.Slides for Python, puede establecer la familia de fuentes, el tamaño, el peso, el color y la alineación para todas las celdas de la fila simultáneamente, manteniendo uniformes los encabezados o bandas de datos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación.  
1. Acceda a la diapositiva por su índice.  
1. Acceda al objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) pertinente en la diapositiva.  
1. Establezca la altura de fuente para las celdas de la primera fila.  
1. Defina la alineación y el margen derecho para las celdas de la primera fila.  
1. Configure el tipo de texto vertical para las celdas de la segunda fila.  
1. Guarde la presentación modificada.

Este código Python demuestra la operación.
```python
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Establecer la altura de fuente para las celdas de la primera fila.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Establecer la alineación de texto y el margen derecho de las celdas de la primera fila.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Establecer el tipo de orientación vertical del texto en las celdas de la segunda fila.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Guardar la presentación en disco.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer formato de texto a nivel de columna de tabla**

Aplique un estilo de texto coherente a toda una columna de tabla de una sola vez. Con Aspose.Slides for Python, puede establecer la familia de fuentes, el tamaño, el peso, el color y la alineación para todas las celdas de la columna, creando bandas verticales uniformes para encabezados o datos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación.  
1. Acceda a la diapositiva por su índice.  
1. Acceda al objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) pertinente en la diapositiva.  
1. Establezca la altura de fuente para las celdas de la primera columna.  
1. Defina la alineación y el margen derecho para las celdas de la primera columna.  
1. Configure el tipo de texto vertical para las celdas de la segunda columna.  
1. Guarde la presentación modificada.

El siguiente código Python demuestra la operación:
```python
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Establecer la altura de fuente de las celdas de la primera columna.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Establecer la alineación de texto y el margen derecho de las celdas de la primera columna.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Establecer el tipo de orientación vertical del texto en las celdas de la segunda columna.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Guardar la presentación en disco.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para reutilizarlas en otra tabla o en otro lugar. El siguiente código Python muestra cómo obtener las propiedades de estilo de un estilo de tabla predefinido:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla ya creada?**

Sí. La tabla hereda el tema de la diapositiva/diseño/maestra, y aún puede sobrescribir rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación o filtros incorporados. Ordene sus datos en memoria primero y luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.