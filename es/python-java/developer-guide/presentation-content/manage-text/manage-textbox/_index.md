---
title: Gestionar cuadros de texto en presentaciones usando Python a través de Java
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/python-java/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear, identificar, dar formato y actualizar cuadros de texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python a través de Java."
---
## **Introducción**

En Aspose.Slides para Python a través de Java, el texto de una diapositiva se almacena en marcos de texto que pertenecen a formas. La clase [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) representa la forma con texto más común y expone su texto mediante el método [AutoShape.getTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Nota" %}}

Cada forma automática hereda de [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/), pero no todas las formas son formas automáticas ni admiten un marco de texto. Al procesar una presentación existente, compruebe que una forma sea una instancia de [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) antes de acceder a su texto.

{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada una forma automática a una diapositiva, agregue texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las coordenadas y dimensiones pasadas a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) se miden en puntos. [AutoShape.addTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#addTextFrame) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice el método [AutoShape.isTextBox](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#isTextBox) para determinar si una forma automática se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto formas automáticas con texto como formas exclusivamente gráficas.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada forma automática en una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Una forma automática recién añadida no se considera un cuadro de texto hasta que contiene texto no vacío. Puede suministrar ese texto mediante [AutoShape.addTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#addTextFrame) o [TextFrame.setText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#setText). Añadir o asignar una cadena vacía hace que [AutoShape.isTextBox](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#isTextBox) devuelva `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Las dos primeras llamadas imprimen `True`; las dos últimas imprimen `False`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) sin saber qué objeto de la presentación lo contiene. Utilice el método de solo lectura [TextFrame.getParentShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentShape) para volver al [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) propietario.

Para un marco de texto que pertenece a una forma automática u otra forma con texto, [TextFrame.getParentShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentShape) devuelve el propietario y [TextFrame.getParentCell](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParentCell) devuelve `None`. Compruebe el valor devuelto antes de acceder a él. Para identificar tanto propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos de SmartArt, consulte [Buscar y reemplazar texto](/slides/es/python-java/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

El método [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setColumnCount) divide el marco de texto en columnas, mientras que [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setColumnSpacing) establece el espacio entre columnas en puntos. Ambas configuraciones pertenecen a [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/) y pueden modificarse a través del marco de texto de un cuadro de texto existente. El texto se reorganiza entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee la configuración almacenada del archivo de salida:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Extraer texto de columnas individuales**

Utilice [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#splitTextByColumns) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por cada columna, en orden de lectura basado en columnas. Un marco de texto de una sola columna produce una matriz con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto plano; el formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer texto preservando su orden de lectura basado en columnas.
- Indexar o comparar el contenido de diapositivas con varias columnas.
- Exportar cada columna a un archivo separado, campo de base de datos u otro destino.
- Inspeccionar cómo se redistribuye el texto después de cambiar el número de columnas con [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setColumnCount), el espaciado con [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setColumnSpacing), la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) actual; no fluye automáticamente el texto entre formas o cuadros de texto separados. La distribución de columnas puede depender de las fuentes disponibles y de otras configuraciones de diseño de texto, así que asegúrese de que las fuentes requeridas estén disponibles cuando los resultados consistentes sean importantes.

El siguiente ejemplo carga una presentación, encuentra la primera forma automática de varias columnas con un marco de texto, lee su número de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Actualizar texto**

Para actualizar texto en toda la presentación, recorra las diapositivas y formas, seleccione las formas automáticas y luego edite sus porciones de texto. Trabajar a nivel de porción le permite cambiar tanto el texto como el formato de los caracteres.

El siguiente ejemplo reemplaza cada aparición de `years` por `months` en el texto de las formas automáticas y pone en negrita cada porción afectada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este recorrido actualiza el texto solo en formas automáticas. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere el recorrido de las colecciones propias de esos objetos.

## **Añadir un cuadro de texto con hipervínculo**

A un fragmento de texto específico puede asignársele un hipervínculo, de modo que solo ese texto actúe como enlace clicable. Utilice [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) para asociar la porción con una URL externa.

El siguiente ejemplo crea texto enlazado y lo guarda en una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [placeholder](/slides/es/python-java/manage-placeholder/) puede heredar su posición y formato de una [master slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/) o [layout slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/). Un cuadro de texto regular es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando el diseño cambia.

**¿Cómo puedo reemplazar texto sin modificar el texto en gráficos, tablas o SmartArt?**

Limite el recorrido a las formas que sean instancias de [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/), como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objeto, por lo que no se modifican con ese bucle.