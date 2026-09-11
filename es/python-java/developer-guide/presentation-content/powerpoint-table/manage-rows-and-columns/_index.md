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
description: "Gestione filas y columnas de tablas en PowerPoint con Aspose.Slides para Python mediante Java y acelere la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Para permitirle gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) y muchos otros tipos.

## **Establecer la primera fila como encabezado**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación.
2. Obtenga una referencia a una diapositiva por su índice.
3. Cree una referencia a [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) y establézcala en `None`.
4. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) para encontrar la tabla correspondiente.
5. Establezca la primera fila de la tabla como su encabezado.

Este código Python le muestra cómo establecer la primera fila de una tabla como su encabezado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar una fila o columna de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación.
2. Obtenga una referencia a una diapositiva por su índice.
3. Defina una lista de anchos de columna.
4. Defina una lista de alturas de fila.
5. Añada un objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addTable).
6. Clone la fila de la tabla.
7. Clone la columna de la tabla.
8. Guarde la presentación modificada.

Este código Python le muestra cómo clonar una fila o columna de una tabla de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva por su índice.
3. Defina una lista de anchos de columna.
4. Defina una lista de alturas de fila.
5. Añada un objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addTable).
6. Elimine la fila de la tabla.
7. Elimine la columna de la tabla.
8. Guarde la presentación modificada.

Este código Python le muestra cómo eliminar una fila o columna de una tabla:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer formato de texto a nivel de fila de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación.
2. Obtenga una referencia a una diapositiva por su índice.
3. Acceda al objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) correspondiente desde la diapositiva.
4. Establezca la altura de fuente de las celdas de la primera fila usando [setFontHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Establezca la alineación del texto y el margen derecho de las celdas de la primera fila usando [setAlignment](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setAlignment) y [setMarginRight](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Establezca el tipo de texto vertical de las celdas de la segunda fila usando [setTextVerticalType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Guarde la presentación modificada.

Este código Python demuestra la operación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Establecer formato de texto a nivel de columna de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación.
2. Obtenga una referencia a una diapositiva por su índice.
3. Acceda al objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) correspondiente desde la diapositiva.
4. Establezca la altura de fuente de las celdas de la primera columna usando [setFontHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Establezca la alineación del texto y el margen derecho de las celdas de la primera columna usando [setAlignment](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setAlignment) y [setMarginRight](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Establezca el tipo de texto vertical de las celdas de la segunda columna usando [setTextVerticalType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Guarde la presentación modificada.

Este código Python demuestra la operación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código Python le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/diagrama maestro, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación ni filtros integrados. Ordene sus datos en memoria primero y luego vuelva a rellenar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (a rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.