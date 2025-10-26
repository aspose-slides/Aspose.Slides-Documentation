---
title: Administrar cuadros de texto en presentaciones con Python
linktitle: Administrar cuadro de texto
type: docs
weight: 20
url: /es/python-net/developer-guide/presentation-content/manage-text/manage-textbox/
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
description: "Aspose.Slides para Python mediante .NET facilita la creación, edición y clonación de cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---

## **Descripción general**

Los textos en las diapositivas normalmente existen en cuadros de texto o formas. Por lo tanto, para añadir texto a una diapositiva, primero debe añadir un cuadro de texto y luego colocar el texto dentro de él. Aspose.Slides para Python proporciona la clase [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) que permite añadir una forma que contiene texto.

{{% alert title="Información" color="info" %}}

Aspose.Slides también ofrece la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Sin embargo, no todas las formas pueden contener texto.

{{% /alert %}}

{{% alert title="Nota" color="warning" %}}

Por ello, cuando trabaje con una forma a la que desea añadir texto, conviene comprobar y confirmar que ha sido convertida mediante la clase [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Sólo entonces podrá trabajar con [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), que es una propiedad de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Consulte la sección [Actualizar texto](/slides/es/python-net/manage-textbox/#update-text) de esta página.

{{% /alert %}}

## **Crear cuadros de texto en diapositivas**

Para crear un cuadro de texto en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la primera diapositiva.
3. Añada un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` en la posición deseada de la diapositiva.
4. Asigne el texto al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
5. Guarde la presentación como archivo PPTX.

El siguiente ejemplo en Python implementa estos pasos:

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    # Añadir un AutoShape de tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Guardar la presentación en disco.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar si una forma es un cuadro de texto**

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

Observe que si añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mediante la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), la propiedad `is_text_box` de la forma devuelve `False`. Sin embargo, después de añadir texto—bien con el método `add_text_frame` o estableciendo la propiedad `text`—`is_text_box` devuelve `True`.

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

## **Añadir columnas a los cuadros de texto**

Aspose.Slides ofrece las propiedades [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) y [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) en la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) para añadir columnas a los cuadros de texto. Puede especificar el número de columnas y establecer el espaciado (en puntos) entre ellas.

El siguiente código Python muestra esta operación:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Obtener la primera diapositiva de la presentación.
	slide = presentation.slides[0]

	# Añadir un AutoShape de tipo RECTANGLE.
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

Aspose.Slides le permite actualizar el texto en un único cuadro de texto o en toda la presentación.

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
  
    # Guardar la presentación modificada.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir cuadros de texto con hipervínculos**

Puede insertar un enlace en un cuadro de texto. Cuando se hace clic en el cuadro de texto, el enlace se abre.

Para añadir un cuadro de texto que contenga un hipervínculo, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la primera diapositiva.
3. Añada un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` en la posición deseada de la diapositiva.
4. Asigne el texto al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
5. Obtenga una referencia al [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Utilice la propiedad `hyperlink_manager` para establecer un hipervínculo externo al hacer clic.
7. Guarde la presentación como archivo PPTX.

Este ejemplo en Python muestra cómo añadir un cuadro de texto con hipervínculo a una diapositiva:

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    # Añadir un AutoShape de tipo RECTANGLE.
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

Un [marcador de posición](/slides/es/python-net/manage-placeholder/) hereda estilo/posición de la [maestra](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) y puede ser sobrescrito en los [diseños](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva específica y no cambia al cambiar de diseño.

**¿Cómo puedo realizar una sustitución masiva de texto en toda la presentación sin tocar el texto dentro de gráficos, tablas y SmartArt?**

Limite la iteración a autoformas que tengan marcos de texto y excluya los objetos incrustados ([gráficos](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [tablas](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) recorriendo sus colecciones por separado o omitiendo esos tipos de objeto.