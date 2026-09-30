---
title: Gestionar filas y columnas en tablas de PowerPoint usando Python
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
description: "Gestiona filas y columnas de tablas en PowerPoint con Aspose.Slides para Python mediante .NET y acelera la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Aspose.Slides para Python mediante .NET le permite gestionar la estructura y el formato de tablas en presentaciones de PowerPoint a través de la clase [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en Python. También muestra cómo obtener el preajuste de estilo de una tabla para que pueda reutilizarlo. Los índices de filas y columnas de la tabla comienzan en cero.

## **Controlar la altura de la fila**

Utilice [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) devuelve la altura real y es de solo lectura. Acceda a la fila a través de [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que contiene una tabla como la primera forma en la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas usan texto Arial de 18 puntos, con ajuste de línea y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo aumenta el mínimo a 100 puntos, luego lo disminuye a 20 puntos, imprime la altura real después de cada cambio y guarda ambos resultados.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Con la presentación suministrada, aumentar el mínimo agrega espacio a la fila. Disminuirlo elimina ese espacio adicional, pero la altura real sigue siendo mayor que 20 puntos porque el texto y los márgenes de la celda necesitan más espacio. Reducir solo el mínimo no puede obligar a la fila a quedar por debajo del espacio requerido por su contenido.

Varios factores afectan la altura real:

- **Texto y tamaño de fuente:** texto más largo, saltos de línea explícitos o una fuente mayor pueden requerir más espacio vertical.
- **Ajuste de texto y ancho de columna:** con el ajuste activado, una [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) más estrecha puede generar más líneas. Una columna más ancha puede reducir el espacio necesario verticalmente.
- **Márgenes de celda:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) y [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) añaden espacio vertical. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) y [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) reducen el ancho disponible para el texto y pueden provocar un ajuste adicional.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impulsado por el contenido para toda la fila. Para acortar la fila, también puede ser necesario reducir el texto, disminuir el tamaño de fuente o los márgenes, o ensanchar una columna.

Las imágenes a continuación muestran la misma tabla a la misma escala. En esta ejecución, las alturas reales fueron 70, 100 y 55,2 puntos: la fila final permaneció más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar según las fuentes disponibles en su entorno. Descargue los resultados guardados: [increased minimum](row-height-increased.pptx) y [decreased minimum](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Reducido: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla tras aumentar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla tras reducir el mínimo de la primera fila a 20 puntos; el texto ajustado mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Utilice la propiedad [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) para marcar la primera fila como encabezado. Su apariencia depende del estilo de tabla aplicado a la tabla.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma en la diapositiva.
4. Active el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva. Activa el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Clone las filas requeridas.
6. Clone las columnas requeridas.
7. Guarde la presentación modificada.

El ejemplo requiere `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `False` desactiva la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no sean necesarias en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que lo siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y la columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `False` desactiva la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

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

Aplique formato de texto a una fila completa para mantener la consistencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Establezca [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) para la primera fila.
4. Establezca [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) y [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) para la primera fila.
5. Establezca [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera fila, luego establece texto vertical en la segunda fila.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a una columna completa para mantener la consistencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Establezca [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) para la primera columna.
4. Establezca [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) y [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) para la primera columna.
5. Establezca [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera columna, luego establece texto vertical en la segunda columna.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener propiedades de estilo de tabla**

Utilice la propiedad [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) para recuperar el preajuste aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el preajuste en lugar de las anulaciones de formato de celdas individuales.

El ejemplo crea una tabla, aplica [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), y lee el preajuste de vuelta. Imprime `True` cuando el preajuste recuperado coincide con el preajuste aplicado y guarda la tabla en `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestro, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación o filtros incorporados. Ordene sus datos en memoria primero, luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) mientras mantengo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de la tabla.