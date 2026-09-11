---
title: Gestionar tablas de presentación en Python
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/python-java/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crear y editar tablas en diapositivas PowerPoint con Aspose.Slides para Python mediante Java. Descubra ejemplos de código sencillos para optimizar sus flujos de trabajo con tablas."
---
## **Introducción**

Una tabla en PowerPoint es una forma eficiente de mostrar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) , la clase [Cell](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear una tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Defina una lista de anchos de columna.
4. Defina una lista de alturas de fila.
5. Añada un objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addTable).
6. Itere a través de cada [Cell](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla.
8. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de una [Cell](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/).
9. Añada texto al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).
10. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancia una clase Presentation que representa un archivo PPTX
presentation = Presentation()
try:

    # Accede a la primera diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Define columnas con anchos y filas con alturas
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Añade una forma de tabla a la diapositiva
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Establece el formato de borde para cada celda
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

    # Fusiona las celdas 1 y 2 de la fila 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Añade texto a la celda fusionada
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Guarda la presentación en disco
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeración en una tabla estándar**

En una tabla estándar, la numeración de las celdas es directa y comienza en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Python le muestra cómo crear una tabla con numeración estándar de celdas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancia una clase Presentation que representa un archivo PPTX
presentation = Presentation()
try:

    # Accede a la primera diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Define columnas con anchos y filas con alturas
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Añade una forma de tabla a la diapositiva
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Establece el formato de borde para cada celda
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

    # Guarda la presentación en disco
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a una tabla existente**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice.
3. Inicialice una variable para un objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) y asígnele `None`.
4. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) hasta encontrar la tabla.

   Si sospecha que la diapositiva con la que está trabajando contiene una sola tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede usarla como objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/). Pero si la diapositiva contiene varias tablas, será más conveniente buscar la tabla que necesita mediante su [getAlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText).

5. Utilice el objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) para trabajar con la tabla. En el ejemplo siguiente, actualizamos el texto de la primera columna de la segunda fila.
6. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Instancia la clase Presentation que representa un archivo PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Accede a la primera diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Inicializa la referencia a la tabla.
    table = None

    # Itera a través de las formas y establece una referencia a la tabla encontrada
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Establece el texto para la primera columna de la segunda fila
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Guarda la presentación modificada en disco
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de una tabla, utilice el método [TextFrame.getParentCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentCell) para recuperar la [Cell](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/) propietaria. Para un marco de texto de celda de tabla, [TextFrame.getParentCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentCell) devuelve el propietario y [TextFrame.getParentShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentShape) devuelve `None`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles mediante los métodos de solo lectura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/#getFirstColumnIndex) y [Cell.getFirstRowIndex](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentCell) también proporciona navegación de solo lectura: devuelve el propietario pero no cambia la propiedad. Siempre compruebe que la celda devuelta no sea `None` antes de usarla.

Para un ejemplo completo que identifique los propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, vea [Search and Replace Text](/slides/es/python-java/search-and-replace-text/).

## **Alinear texto en una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) a la diapositiva.
4. Acceda a un objeto [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la tabla.
5. Acceda al [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) del objeto [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Crea una instancia de la clase Presentation
presentation = Presentation()
try:

    # Obtiene la primera diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Define columnas con anchos y filas con alturas
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Añade la forma de tabla a la diapositiva
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Accede al marco de texto
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Accede al primer párrafo del marco de texto.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Accede a la primera porción del párrafo.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Alinea el texto verticalmente
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Guarda la presentación en disco
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer formato de texto a nivel de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Acceda a un objeto [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) de la diapositiva.
4. Establezca la altura de fuente del texto con [setFontHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Establezca la alineación y el margen derecho con [setAlignment](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setAlignment) y [setMarginRight](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Establezca el tipo de texto vertical con [setTextVerticalType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Crea una instancia de la clase Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Supongamos que la primera forma en la primera diapositiva es una tabla
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Establece la altura de fuente de las celdas de la tabla
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Establece la alineación de texto y el margen derecho de las celdas de la tabla en una sola llamada
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Establece el tipo de texto vertical de las celdas de la tabla
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
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
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # cambiar el tema predeterminado del estilo

    # Obtiene el preset de estilo de la tabla
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Aplica el preset de estilo recuperado a otra tabla
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una forma geométrica es la proporción de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona el método [setAspectRatioLocked](https://reference.aspose.com/slides/es/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) que le permite bloquear la configuración de la relación de aspecto para tablas y otras formas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # invertir
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/#setRightToLeft), y los párrafos disponen de [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setRightToLeft). Usar ambos garantiza el orden y renderizado RTL correcto dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [shape locks](/slides/es/python-java/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estas restricciones también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).