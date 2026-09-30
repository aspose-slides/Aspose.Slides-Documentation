---
title: Administrar tablas de presentación en Python
linktitle: Administrar tabla
type: docs
weight: 10
url: /es/python-java/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder a tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para Python mediante Java. Descubra ejemplos de código sencillos para optimizar sus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, lo que facilita la lectura y la comparación de valores.

Aspose.Slides proporciona las clases [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) y [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Cree una tabla especificando su posición, los anchos de columna y las alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, combinar celdas e insertar texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Defina una lista de anchos de columna en puntos.
4. Defina una lista de alturas de fila en puntos.
5. Añada un objeto [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Itere a través de cada [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combina las dos primeras celdas de la primera fila de la tabla.
8. Acceda a la celda combinada mediante su método [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Establezca el texto en la celda combinada.
10. Guarde la presentación modificada.

El ejemplo siguiente crea una tabla con tres columnas y cinco filas en (100, 50) puntos. Aplica bordes rojos con un grosor de 5 puntos, combina las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de las celdas comienzan en cero y utilizan el orden (columna, fila). La primera celda tiene el índice (0, 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla de 4 × 4 ilustrada arriba, con anchos de columna y alturas de fila de 70 puntos y bordes de celda rojos con un grosor de 5 puntos. Las coordenadas ilustran los índices de las celdas; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Itere a través de las formas para localizar una tabla y, a continuación, utilice la clase [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) para leer o actualizar sus celdas.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice.
3. Itere a través de los objetos [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) y deténgase cuando se encuentre una tabla. Si la diapositiva contiene varias tablas, utilice [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) para identificar la que necesita.
4. Actualice el texto en la celda objetivo.
5. Guarde la presentación modificada.

El ejemplo siguiente abre `UpdateExistingTable.pptx` y encuentra la primera tabla en la primera diapositiva. Establece la celda en la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla en esa diapositiva debe tener al menos una columna y dos filas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para cambiar el tamaño de una fila en una tabla existente y comprender por qué su altura real puede superar la mínima solicitada, consulte [Controlar la altura de fila](/slides/es/python-java/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) de una tabla, utilice el método [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) para obtener la [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) propietaria. Para un marco de texto de una celda de tabla, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) devuelve el propietario y [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) devuelve `None`, aunque la tabla en sí sea una forma.

Las coordenadas de la celda están disponibles a través de los métodos de solo lectura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) y [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) también proporciona navegación de solo lectura: devuelve el propietario pero no cambia la titularidad. Siempre compruebe que la celda devuelta no sea `None` antes de usarla.

Para un ejemplo completo que identifique los propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, consulte [Buscar y reemplazar texto](/slides/es/python-java/search-and-replace-text/).

## **Alinear texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas individuales de la tabla. El ejemplo en esta sección centra el texto dentro de la primera celda y lo rota 270 grados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Añada un objeto [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) a la diapositiva.
4. Acceda a un objeto [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) de la tabla.
5. Acceda al primer [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) y establezca su texto y color.
6. Establezca el anclaje vertical de la celda y la dirección del texto mediante [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) y [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Guarde la presentación modificada.

Este ejemplo crea una tabla de 4 × 4 con anchos de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto en la celda (0, 0), agrega valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer formato de texto a nivel de tabla**

Utilice [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porción, párrafo y marco de texto, por lo que puede establecer estas propiedades sin iterar por celdas individuales.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Acceda a un objeto [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) de la diapositiva.
4. Establezca el tamaño de fuente usando [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para el texto.
5. Establezca la alineación del párrafo y el margen derecho mediante [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) y [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Establezca la dirección del texto mediante [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Guarde la presentación modificada.

El ejemplo siguiente abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace que el texto sea vertical. La presentación formateada se guarda como `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtener propiedades de estilo de tabla**

Utilice [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) para leer el estilo predefinido de una tabla y [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) para asignarlo. Este ejemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) a una tabla, muestra el valor del preset y asigna el mismo preset a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bloquear relación de aspecto de una tabla**

La relación de aspecto de una tabla es la proporción entre su ancho y su altura. Utilice [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) para bloquear esta relación en una tabla.

El ejemplo siguiente abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Muestra el estado actual del bloqueo, activa el bloqueo de relación de aspecto, muestra el estado actualizado (`True`) y guarda el resultado como `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Usar ambos garantiza el orden RTL correcto y la representación adecuada dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [shape locks](/slides/es/python-java/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).