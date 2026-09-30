---
title: Gestionar filas y columnas en tablas de PowerPoint usando Python
linktitle: Filas y columnas
type: docs
weight: 20
url: /es/python-java/manage-rows-and-columns/
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
description: Gestiona filas y columnas de tabla en PowerPoint con Aspose.Slides para Python vía Java y acelera la edición de presentaciones y la actualización de datos.
---
## **Introducción**

Aspose.Slides for Python via Java le permite gestionar la estructura y el formato de tablas en presentaciones PowerPoint a través de la clase [Tabla](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en Python. También muestra cómo obtener el estilo predefinido de una tabla para reutilizarlo. Los índices de filas y columnas de la tabla comienzan en cero.

## **Controlar la altura de la fila**

Utilice [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) devuelve la altura real. Acceda a la fila mediante [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que contiene una tabla como la primera forma en la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas utilizan texto Arial de 18 puntos, con ajuste de línea y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo aumenta el mínimo a 100 puntos, luego lo disminuye a 20 puntos, muestra la altura real después de cada cambio y guarda ambos resultados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Con la presentación proporcionada, aumentar el mínimo añade espacio a la fila. Disminuirlo elimina ese espacio adicional, pero la altura real sigue siendo mayor que 20 puntos porque el texto y los márgenes de la celda requieren más espacio. Reducir solo el mínimo no puede forzar la fila por debajo del espacio requerido por su contenido.

Varios factores afectan la altura real:

- **Texto y tamaño de fuente:** texto más largo, saltos de línea explícitos o una fuente mayor pueden requerir más espacio vertical.
- **Ajuste y ancho de columna:** con el ajuste habilitado, reducir el ancho de columna con [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) puede producir más líneas. Una columna más ancha puede reducir el espacio necesario verticalmente.
- **Márgenes de celda:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) y [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) añaden espacio vertical. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) y [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) reducen el ancho disponible para el texto y pueden provocar más ajustes.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impulsado por el contenido para toda la fila. Para acortar la fila, también puede ser necesario acortar el texto, reducir el tamaño de fuente o los márgenes, o ensanchar una columna.

Las imágenes a continuación muestran la misma tabla a la misma escala. En los resultados ilustrados, las alturas reales fueron 70, 100 y 55,2 puntos: la fila final siguió siendo más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar según las fuentes disponibles en su entorno. Descargue los resultados guardados: [mínimo aumentado](row-height-increased.pptx) y [mínimo disminuido](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Disminuido: mínimo 20 pt, real 55,2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla después de aumentar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla después de disminuir el mínimo de la primera fila a 20 puntos; el texto ajustado mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Utilice el método [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) para marcar la primera fila con formato de encabezado. Su apariencia depende del estilo de tabla aplicado a la tabla.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma en la diapositiva.
4. Habilite el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva. Habilita el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Clone las filas requeridas.
6. Clone las columnas requeridas.
7. Guarde la presentación modificada.

El ejemplo requiere `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `False` deshabilita la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no son necesarias en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que le siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y la columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `False` deshabilita la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer formato de texto a nivel de fila de tabla**

Aplique formato de texto a una fila completa para mantener la coherencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Utilice [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para la primera fila.
4. Utilice [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) y [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) para la primera fila.
5. Utilice [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen derecho de párrafo de 20 puntos a la primera fila, luego establece texto vertical en la segunda fila.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a una columna completa para mantener la coherencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Utilice [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para la primera columna.
4. Utilice [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) y [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) para la primera columna.
5. Utilice [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen derecho de párrafo de 20 puntos a la primera columna, luego establece texto vertical en la segunda columna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtener propiedades de estilo de tabla**

Utilice el método [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) para recuperar el estilo predefinido aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el estilo predefinido en lugar de sobrescribir el formato de celdas individualmente.

El ejemplo crea una tabla, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) y lee el estilo de vuelta. Imprime el valor entero correspondiente a `DarkStyle1` y guarda la tabla en `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestro, y aún puede sobrescribir rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de clasificación o filtros integrados. Ordene sus datos en memoria primero y luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.