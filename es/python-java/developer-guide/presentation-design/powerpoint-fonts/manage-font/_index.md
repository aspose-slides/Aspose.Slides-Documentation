---
title: Gestionar fuentes en presentaciones usando Python vía Java
linktitle: Gestionar fuentes
type: docs
weight: 10
url: /es/python-java/manage-fonts/
keywords:
- gestionar fuentes
- propiedades de fuentes
- párrafo
- formato de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Controla fuentes en Python vía Java con Aspose.Slides: incrusta, sustituye y carga fuentes personalizadas para que las presentaciones PPT, PPTX y ODP sean claras, seguras para la marca y coherentes."
---
## **Visión general**

Aspose.Slides le permite gestionar las propiedades de fuente en el texto de una presentación directamente desde su código. Puede acceder al texto en las diapositivas a través de formas, marcos de texto, párrafos y porciones, y luego aplicar formato al texto seleccionado.

Este artículo explica cómo configurar las propiedades relacionadas con la fuente para texto existente en una presentación, incluyendo la familia de fuentes, estilos negrita y cursiva, alineación de párrafo y color de fuente. También muestra cómo crear un cuadro de texto, agregarle texto y establecer propiedades de fuente como familia, negrita, cursiva, subrayado, tamaño y color antes de guardar el resultado como un archivo PPTX.

## **Gestionar propiedades relacionadas con la fuente**
{{% alert color="info" title="Note" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a los estilos corporativos. El formato de texto ayuda a los usuarios a variar el aspecto del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for Python vía Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides for Python vía Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Acceder a las formas [Placeholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholder/) en la diapositiva como [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
1. Obtener el [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
1. Justificar el párrafo.
1. Acceder al texto del [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) mediante su [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/).
1. Definir la fuente mediante [FontData](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontdata/) y establecer la **Font** de la [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
1. Establecer el color de la fuente mediante el [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) expuesto por el objeto [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/).
1. Guardar la presentación modificada en un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin formato y aplica formato a las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo de la fuente.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: El texto en el archivo de entrada**|

|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: El mismo texto con el formato actualizado**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Cargar la presentación.
presentation = Presentation("FontProperties.pptx")
try:
    # Acceder a la primera diapositiva y a los marcos de texto de sus dos primeros marcadores de posición.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Acceder al primer párrafo en cada marco de texto.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Acceder a la primera porción en cada párrafo.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definir y asignar nuevas fuentes.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Establecer las fuentes en negrita y cursiva.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Establecer los colores de la fuente.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Guardar la presentación.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer propiedades de fuente del texto**
{{% alert color="info" title="Note" %}} 

Como se mencionó en **Gestionar propiedades relacionadas con la fuente**, una [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) se usa para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for Python vía Java para crear un cuadro de texto con algo de texto y luego definir una fuente concreta y diversas propiedades de fuente.

{{% /alert %}} 

Para crear un cuadro de texto y establecer las propiedades de fuente del texto que contiene:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo **Rectangle** a la diapositiva.
1. Eliminar el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
1. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) del [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
1. Añadir texto al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).
1. Acceder al objeto [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) asociado al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).
1. Definir la fuente que se usará para la [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/).
1. Establecer otras propiedades de fuente como negrita, cursiva, subrayado, color y altura mediante las propiedades correspondientes expuestas por el objeto [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/).
1. Guardar la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides for Python vía Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Obtener la primera diapositiva y añadir un rectángulo.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Eliminar el relleno de la forma.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Añadir texto al marco de texto de la forma.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Establecer la familia de fuente.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Establecer negrita, cursiva, subrayado y tamaño de fuente.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Establecer el color de la fuente.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Guardar la presentación.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```