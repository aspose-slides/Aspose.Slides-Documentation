---
title: Administrar Cuadros de Texto en Presentaciones con Python
linktitle: Administrar Cuadro de Texto
type: docs
weight: 20
url: /es/python-net/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- agregar texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- agregar columna de texto
- agregar hipervínculo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aspose.Slides para Python a través de .NET facilita la creación, edición y clonación de cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---

## **Resumen**

Los textos en las diapositivas normalmente existen en cuadros de texto o formas. Por lo tanto, para agregar texto a una diapositiva, debes añadir un cuadro de texto y luego colocar algo de texto dentro del mismo. Aspose.Slides para Python proporciona la clase [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) que permite agregar una forma que contenga texto.

{{% alert title="Información" color="info" %}}

Aspose.Slides también ofrece la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Sin embargo, no todas las formas pueden contener texto.

{{% /alert %}}

{{% alert title="Nota" color="warning" %}}

Por ello, cuando trabajes con una forma a la que deseas agregar texto, puede que necesites comprobar y confirmar que ha sido convertida mediante la clase [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), que es una propiedad de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Consulta la sección [Actualizar Texto](/slides/es/python-net/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear Cuadros de Texto en Diapositivas**

Para crear un cuadro de texto en una diapositiva:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia a la primera diapositiva.
3. Añade una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` en la posición deseada de la diapositiva.
4. Establece el texto en el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
5. Guarda la presentación como archivo PPTX.

El siguiente ejemplo en Python implementa estos pasos:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar si una Forma es un Cuadro de Texto**

Aspose.Slides proporciona la propiedad [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) en la clase [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), que permite determinar si una forma es un cuadro de texto.

![Cuadro de texto y forma](istextbox.png)

Este ejemplo en Python muestra cómo comprobar si una forma se creó como cuadro de texto:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Ten en cuenta que si añades una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mediante la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), la propiedad `is_text_box` de la forma devuelve `False`. Sin embargo, después de agregar texto —ya sea con el método `add_text_frame` o estableciendo la propiedad `text`— `is_text_box` devuelve `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **Agregar Columnas a los Cuadros de Texto**

Aspose.Slides ofrece las propiedades [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) y [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) en la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) para añadir columnas a los cuadros de texto. Puedes especificar el número de columnas y establecer el espacio (en puntos) entre ellas.

El siguiente código en Python demuestra esta operación:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar Texto**

Aspose.Slides permite actualizar el texto en un único cuadro de texto o en toda la presentación.

El siguiente ejemplo en Python muestra cómo actualizar todo el texto de una presentación:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Cuadros de Texto con Hipervínculos** 

Puedes insertar un vínculo en un cuadro de texto. Cuando se hace clic en el cuadro, el vínculo se abre.

Para agregar un cuadro de texto que contenga un hipervínculo, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén una referencia a la primera diapositiva.
3. Añade una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` en la posición deseada de la diapositiva.
4. Establece el texto en el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
5. Obtén una referencia al [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Usa la propiedad `hyperlink_manager` para establecer un hipervínculo de clic externo.
7. Guarda la presentación como archivo PPTX.

Este ejemplo en Python muestra cómo agregar un cuadro de texto con un hipervínculo a una diapositiva:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [placeholder](/slides/es/python-net/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) y puede ser sobrescrito en los [layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva concreta y no cambia cuando cambias de layout.

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin tocar el texto dentro de gráficos, tablas y SmartArt?**

Limita tu iteración a auto‑shapes que tengan marcos de texto y excluye los objetos incrustados ([charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) recorriendo sus colecciones por separado o saltándolos.