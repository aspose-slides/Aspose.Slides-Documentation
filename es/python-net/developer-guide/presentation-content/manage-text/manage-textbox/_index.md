---
title: Administrar cuadros de texto en presentaciones con Python
linktitle: Administrar cuadro de texto
type: docs
weight: 20
url: /es/python-net/manage-textbox/
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
- Aspose.Slides
description: "Crear, identificar, formatear y actualizar cuadros de texto en presentaciones de PowerPoint y OpenDocument mediante Aspose.Slides para Python a través de .NET."
---
## **Introducción**

En Aspose.Slides for Python a través de .NET, el texto de la diapositiva se almacena en marcos de texto que pertenecen a las formas. La clase [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) representa la forma con texto más común y expone su texto a través de la propiedad [AutoShape.text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Nota" %}}
Todas las formas automáticas heredan de [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/), pero no todas las formas son automáticas ni admiten un marco de texto. Cuando se procesa una presentación existente, use `isinstance(shape, slides.AutoShape)` para comprobar el tipo de forma antes de acceder a su texto.
{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada una forma automática a una diapositiva, añada texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Las coordenadas y dimensiones pasadas a [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_auto_shape/) se miden en puntos. [AutoShape.add_text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/add_text_frame/) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice la propiedad [AutoShape.is_text_box](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/is_text_box/) para determinar si una forma automática se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto formas automáticas con texto como formas puramente gráficas.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada forma automática en una presentación:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Una forma automática recién añadida no se considera un cuadro de texto hasta que contiene texto no vacío. Puede proporcionar ese texto mediante [AutoShape.add_text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/add_text_frame/) o [TextFrame.text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/text/). Añadir o asignar una cadena vacía deja la propiedad [is_text_box](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/is_text_box/) establecida en `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Las dos primeras llamadas imprimen `True`; las dos últimas imprimen `False`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) sin saber qué objeto de la presentación lo contiene. Utilice la propiedad de solo lectura [TextFrame.parent_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_shape/) para volver a su [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) propietario.

Para un marco de texto poseído por una forma automática u otra forma con texto, [parent_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_shape/) contiene al propietario y [TextFrame.parent_cell](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_cell/) es `None`. Compruebe el valor devuelto antes de acceder a él. Para identificar tanto propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos de SmartArt, vea [Buscar y reemplazar texto](/slides/es/python-net/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

La propiedad [TextFrameFormat.column_count](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/column_count/) divide el marco de texto en columnas, mientras que [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/column_spacing/) establece el espacio entre columnas en puntos. Ambas configuraciones pertenecen a [TextFrameFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/) y pueden modificarse a través del marco de texto de un cuadro de texto existente. El texto se reorganiza entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee de nuevo la configuración almacenada del archivo de salida:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Extraer texto de columnas individuales**

Utilice [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/split_text_by_columns/) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por cada columna, en orden de lectura por columnas. Un marco de texto de una sola columna produce una lista con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto plano; el formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer texto conservando su orden de lectura por columnas.
- Indexar o comparar el contenido de diapositivas con varias columnas.
- Exportar cada columna a un archivo separado, campo de base de datos u otro destino.
- Inspeccionar cómo se redistribuye el texto después de cambiar [TextFrameFormat.column_count](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/column_spacing/), la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) actual; no fluye automáticamente el texto entre formas o cuadros de texto separados. La distribución de columnas puede depender de las fuentes disponibles y de otras configuraciones de diseño de texto, así que asegúrese de que las fuentes requeridas estén disponibles cuando los resultados consistentes sean importantes.

El siguiente ejemplo carga una presentación, encuentra la primera forma automática multicolumna con un marco de texto, lee su número de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Actualizar texto**

Para actualizar el texto en toda una presentación, recorra las diapositivas y formas, seleccione las formas automáticas y luego edite sus porciones de texto. Trabajar a nivel de porción le permite cambiar tanto el texto como el formato de los caracteres.

El siguiente ejemplo reemplaza cada aparición de `years` por `months` en el texto de formas automáticas y hace que cada porción afectada esté en negrita:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Este recorrido actualiza el texto solo en formas automáticas. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere recorrer las colecciones propias de esos objetos.

## **Añadir un cuadro de texto con hipervínculo**

Puede asignar un hipervínculo a una porción de texto específica, de modo que solo ese texto actúe como enlace clicable. Utilice [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) para asociar la porción con una URL externa.

El siguiente ejemplo crea texto enlazado y lo guarda en una presentación:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [marcador de posición](/slides/es/python-net/manage-placeholder/) puede heredar su posición y formato de una [diapositiva maestra](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/) o [diapositiva de diseño](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/). Un cuadro de texto normal es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando cambia el diseño.

**¿Cómo puedo reemplazar texto sin modificar el texto en gráficos, tablas o SmartArt?**

Limite el recorrido a instancias de [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/), como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objetos, por lo que no se modifican con ese bucle.