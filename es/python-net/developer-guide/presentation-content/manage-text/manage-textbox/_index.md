---
title: Gestionar cuadros de texto en presentaciones con Python
linktitle: Gestionar cuadro de texto
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
description: "Aspose.Slides para Python mediante .NET facilita crear, editar y clonar cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---
## **Introducción**

Los textos en las diapositivas normalmente existen en cuadros de texto o formas. Por lo tanto, para añadir un texto a una diapositiva, tienes que añadir un cuadro de texto y luego colocar algún texto dentro del cuadro. Aspose.Slides for Python proporciona la clase [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) que permite añadir una forma que contiene texto.

{{% alert title="Información" color="info" %}}
Aspose.Slides también proporciona la clase [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/). Sin embargo, no todas las formas pueden contener texto.
{{% /alert %}}

{{% alert title="Nota" color="warning" %}}
Por lo tanto, cuando trabajes con una forma a la que quieras añadir texto, es posible que desees comprobar y confirmar que se ha convertido mediante la clase [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/). Sólo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/), que es una propiedad de [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/). Consulta la sección [Update Text](/slides/es/python-net/manage-textbox/#update-text) de esta página.
{{% /alert %}}

## **Crear cuadros de texto en diapositivas**

Para crear un cuadro de texto en una diapositiva:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtén una referencia a la primera diapositiva.
3. Añade un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` en la posición deseada de la diapositiva.
4. Establece el texto en el [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
5. Guarda la presentación como archivo PPTX.

El siguiente ejemplo en Python implementa estos pasos:

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    # Añadir un AutoShape del tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Guardar la presentación en disco.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar si una forma es un cuadro de texto**

Aspose.Slides proporciona la propiedad [is_text_box](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/is_text_box/) en la clase [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/), que permite determinar si una forma es un cuadro de texto.

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

Ten en cuenta que si añades un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) mediante la clase [ShapeCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/), la propiedad `is_text_box` de la forma devuelve `False`. Sin embargo, después de añadir texto—ya sea con el método `add_text_frame` o estableciendo la propiedad `text`—`is_text_box` devuelve `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box es falso
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box es verdadero

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box es falso
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box es verdadero

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box es falso
    shape3.add_text_frame("")
    # shape3.is_text_box es falso

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box es falso
    shape4.text_frame.text = ""
    # shape4.is_text_box es falso
```

## **Encontrar la forma que posee un TextFrame**

En código genérico de procesamiento de texto, puede que recibas un [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) sin saber ya cuál objeto de presentación lo contiene. Utiliza la propiedad [TextFrame.parent_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_shape/) para volver a la [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) propietaria.

Para un TextFrame que pertenece a un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) u otra forma que contenga texto, la propiedad [TextFrame.parent_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_shape/) está establecida y [TextFrame.parent_cell](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/parent_cell/) es `None`. Ambas propiedades son de solo lectura, por lo que leerlas no cambia la propiedad. Siempre verifica que el valor devuelto no sea `None` antes de acceder a la forma.

Para un ejemplo completo que identifica propietarios de formas y celdas de tabla, incluidas las formas asociadas a nodos de SmartArt, consulta [Search and Replace Text](/slides/es/python-net/search-and-replace-text/).

## **Añadir columnas a los cuadros de texto**

Aspose.Slides proporciona las propiedades [column_count](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/column_count/) y [column_spacing](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/column_spacing/) en la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/) para añadir columnas a los cuadros de texto. Puedes especificar el número de columnas y establecer el espaciado (en puntos) entre ellas.

El siguiente código en Python demuestra esta operación:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Obtener la primera diapositiva de la presentación.
	slide = presentation.slides[0]

	# Añadir un AutoShape del tipo RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Añadir un TextFrame al rectángulo.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Obtener el formato de texto del TextFrame.
	format = shape.text_frame.text_frame_format

	# Especificar el número de columnas en el TextFrame.
	format.column_count = 3

	# Especificar el espaciado entre columnas.
	format.column_spacing = 10

	# Guardar la presentación.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar texto**

Aspose.Slides permite actualizar el texto en un solo cuadro de texto o en toda la presentación.

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
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Guardar la presentación modificada.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir cuadros de texto con hipervínculos**

Puedes insertar un enlace en un cuadro de texto. Cuando se hace clic en el cuadro de texto, se abre el enlace.

Para añadir un cuadro de texto que contenga un hipervínculo, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtén una referencia a la primera diapositiva.
3. Añade un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` en la posición deseada de la diapositiva.
4. Establece el texto en el [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
5. Obtén una referencia al [HyperlinkManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/hyperlinkmanager/).
6. Utiliza la propiedad `hyperlink_manager` para establecer un hipervínculo externo al hacer clic.
7. Guarda la presentación como archivo PPTX.

Este ejemplo en Python muestra cómo añadir un cuadro de texto con un hipervínculo a una diapositiva:

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    # Añadir un AutoShape del tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Añadir texto al marco.
    text_portion.text = "Aspose.Slides"

    # Establecer un hipervínculo para el texto de la porción.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Guardar la presentación como archivo PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [placeholder](/slides/es/python-net/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/) y puede sobrescribirse en los [layouts](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva concreta y no cambia al cambiar de diseño.

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin tocar el texto dentro de gráficos, tablas y SmartArt?**

Limita la iteración a auto‑shapes que tengan marcos de texto y excluye los objetos incrustados ([charts](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/es/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartart/)) recorriendo sus colecciones por separado o saltándolos según el tipo de objeto.