---
title: Formatear texto de PowerPoint en Python
linktitle: Formato de Texto
type: docs
weight: 50
url: /es/python-net/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuentes
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a formatear y dar estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python vía .NET. Personalice fuentes, colores, alineación y más con potentes ejemplos de código Python."
---

## **Resaltar texto**

El método `highlight_text` en la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) permite resaltar una parte del texto con un color de fondo usando una muestra de texto, similar a la herramienta Texto resaltado en PowerPoint 2019.

El siguiente fragmento de código muestra cómo usar esta función:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **Resaltar texto usando expresiones regulares**

El método `highlight_regex` de la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) le permite resaltar una porción de texto con un color de fondo usando una expresión regular, similar a la herramienta Texto resaltado en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer color de fondo del texto**

Aspose.Slides le permite especificar el color de fondo preferido para el texto. El código Python a continuación muestra cómo establecer el color de fondo para todo el texto:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


Este código Python muestra cómo establecer el color de fondo solo para una parte del texto:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Alinear párrafos de texto**

El formato del texto es un elemento clave al crear documentos o presentaciones. Aspose.Slides for Python vía .NET admite agregar texto a diapositivas; en esta sección veremos cómo controlar la alineación de párrafos en una diapositiva. Siga estos pasos para alinear párrafos de texto usando Aspose.Slides for Python vía .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Acceder a las formas de marcador de posición en la diapositiva y convertirlas a [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Desde el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) expuesto por el [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), obtener el párrafo que necesita alinearse.
1. Alinear el párrafo. Un párrafo puede alinearse `LEFT`, `RIGHT`, `CENTER`, `JUSTIFY`, `JUSTIFY_LOW` o `DISTRIBUTED`.
1. Guardar la presentación modificada como archivo PPTX.

La implementación de estos pasos se muestra a continuación.
```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPTX
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # Acceder a la primera diapositiva
    slide = presentation.slides[0]

    # Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo a AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Cambiar el texto en ambos marcadores de posición
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # Obtener el primer párrafo de los marcadores de posición
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Alinear el párrafo de texto al centro
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Guardar la presentación como archivo PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer transparencia del texto**

Esta sección demuestra cómo establecer la propiedad de transparencia para cualquier forma de texto usando Aspose.Slides for Python vía .NET. Para establecer la transparencia del texto, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva.
1. Establecer el color de la sombra.
1. Guardar la presentación como archivo PPTX.

La implementación de estos pasos se muestra a continuación.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # establecer la transparencia a cero por ciento
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer espaciado entre caracteres del texto**

Aspose.Slides le permite ajustar el espaciado entre letras en un cuadro de texto. Esto le permite controlar la densidad visual de una línea o bloque de texto expandiendo o condensando el espacio entre caracteres.

El ejemplo Python a continuación muestra cómo expandir el espaciado para una línea de texto y condensarlo para otra:
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # expandir
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condensar

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Administrar propiedades de fuente de párrafo**

Las presentaciones suelen contener texto e imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para cumplir con estilos corporativos. El formato del texto ayuda a los usuarios a cambiar la apariencia del contenido de la presentación.

Esta sección demuestra cómo usar Aspose.Slides for Python vía .NET para configurar las propiedades de fuente de los párrafos en el texto de una diapositiva. Para administrar las propiedades de fuente de un párrafo usando Aspose.Slides for Python vía .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Acceder a las formas de marcador de posición en la diapositiva y convertirlas a [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Obtener el párrafo del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Justificar el párrafo.
1. Acceder a la porción de texto del párrafo.
1. Definir la fuente usando [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) y establecer la fuente de la porción de texto en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
1. Establecer el color de la fuente usando el [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) expuesto por el objeto [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Guardar la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación simple y aplica formato de fuente a una de las diapositivas.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar un objeto Presentation que representa un archivo PPTX
with slides.Presentation("FontProperties.pptx") as pres:
    # Acceder a una diapositiva usando su posición
    slide = pres.slides[0]

    # Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo a AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Acceder al primer Párrafo
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Acceder a la primera porción
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Definir nuevas fuentes
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Asignar nuevas fuentes a la porción
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Establecer la fuente en negrita
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Establecer la fuente en cursiva
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Establecer color de fuente
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    # Guardar el PPTX en disco
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Administrar la familia de fuentes del texto**

Los objetos [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) se utilizan para contener texto con un estilo de formato similar dentro de un párrafo. Esta sección demuestra cómo usar Aspose.Slides for Python para crear un cuadro de texto, agregarle texto y luego definir una fuente específica junto con varias propiedades de familia de fuentes.

Para crear un cuadro de texto y establecer las propiedades de fuente del texto dentro de él:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de tipo `RECTANGLE` a la diapositiva.
1. Eliminar el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) del AutoShape.
1. Agregar texto al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Acceder al objeto [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) asociado al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Definir la fuente que se usará para la [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Establecer otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades relevantes del objeto [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Guardar la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar Presentation
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva
    sld = presentation.slides[0]

    # Agregar un AutoShape de tipo Rectángulo
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Eliminar cualquier estilo de relleno asociado al AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Acceder al TextFrame asociado al AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Acceder a la Portion asociada al TextFrame
    port = tf.paragraphs[0].portions[0]

    # Establecer la fuente para la Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Establecer la propiedad negrita de la fuente
    port.portion_format.font_bold = 1

    # Establecer la propiedad cursiva de la fuente
    port.portion_format.font_italic = 1

    # Establecer la propiedad subrayado de la fuente
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Establecer la altura de la fuente
    port.portion_format.font_height = 25

    # Establecer el color de la fuente
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Guardar el PPTX en disco
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer el tamaño de fuente del texto**

Aspose.Slides le permite definir su tamaño de fuente preferido para el texto existente en un párrafo, así como para cualquier texto que pueda agregarse más adelante al párrafo.

Este ejemplo Python demuestra cómo establecer el tamaño de fuente para el texto contenido en un párrafo:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Obtiene la primera forma, por ejemplo.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Obtiene el primer párrafo, por ejemplo.
        paragraph = shape.text_frame.paragraphs[0]

        # Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto del párrafo. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Establece el tamaño de fuente a 20 pt para las porciones de texto actuales del párrafo. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer rotación del texto**

Aspose.Slides for Python vía .NET permite a los desarrolladores rotar texto. El texto puede configurarse para aparecer como `HORIZONTAL`, `VERTICAL`, `VERTICAL270`, `WORD_ART_VERTICAL`, `EAST_ASIAN_VERTICAL`, `MONGOLIAN_VERTICAL` o `WORD_ART_VERTICAL_RIGHT_TO_LEFT`.

Para rotar el texto en cualquier [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar una forma a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Aplicar la rotación de texto deseada.
1. Guardar el archivo en disco.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva 
    slide = presentation.slides[0]

    # Agregar un AutoShape de tipo Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Agregar TextFrame al Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accediendo al TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Crear el objeto Paragraph para el TextFrame
    para = txtFrame.paragraphs[0]

    # Crear el objeto Portion para el párrafo
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Guardar la presentación
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer un ángulo de rotación personalizado para un TextFrame**

Aspose.Slides for Python vía .NET admite establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). En esta sección demostraremos cómo usar la propiedad `rotation_angle` en Aspose.Slides.

Para establecer la propiedad `rotation_angle`, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agregar un gráfico a la diapositiva.
1. Establecer la propiedad `rotation_angle`.
1. Guardar la presentación como archivo PPTX.

En el ejemplo a continuación, establecemos la propiedad `rotation_angle`.
```py
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # Guardar la presentación
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer espaciado entre líneas de los párrafos**

Aspose.Slides proporciona las propiedades `space_after`, `space_before` y `space_within` bajo la clase [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) para controlar el interlineado de un párrafo. Estas propiedades funcionan de la siguiente manera:

* Para especificar el interlineado como un porcentaje, use un valor positivo.
* Para especificar el interlineado en puntos, use un valor negativo.

Por ejemplo, para aplicar un interlineado de 16 pt antes de un párrafo, establezca la propiedad `space_before` en `-16`.

Así es como se establece el interlineado para un párrafo específico:

1. Cargar una presentación que contenga un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con texto.
1. Obtener una referencia a la diapositiva por su índice.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Acceder al [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Establecer las propiedades deseadas del párrafo.
1. Guardar la presentación.

El siguiente ejemplo Python demuestra cómo establecer el interlineado para un párrafo:
```py
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation("Fonts.pptx") as presentation:

    # Obtener la referencia de una diapositiva por su índice
    sld = presentation.slides[0]

    # Acceder al TextFrame
    tf1 = sld.shapes[0].text_frame

    # Acceder al Párrafo
    para1 = tf1.paragraphs[0]

    # Establecer propiedades del Párrafo
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Guardar la presentación
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer la propiedad AutofitType para TextFrame**

En esta sección exploraremos varias propiedades de formato de un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), incluido cómo establecer su `autofit_type`, ajustar el ancla del texto y rotar el texto en una presentación.

Aspose.Slides for Python vía .NET permite a los desarrolladores establecer la propiedad `autofit_type` de cualquier [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). El `autofit_type` puede establecerse en `NORMAL` o `SHAPE`:

* Si se establece en `NORMAL`, la forma permanece sin cambios mientras el texto se ajusta para caber dentro de ella.
* Si se establece en `SHAPE`, la forma se redimensiona para contener solo el texto requerido.

Para establecer la propiedad `autofit_type` de un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar una forma a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Establecer el `autofit_type` para el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Guardar el archivo en disco.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva
    slide = presentation.slides[0]

    # Agregar un AutoShape de tipo Rectángulo
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Agregar TextFrame al Rectángulo
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accediendo al TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Crear el objeto Paragraph para el TextFrame
    para = txtFrame.paragraphs[0]

    # Crear el objeto Portion para el párrafo
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Guardar la presentación
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Establecer el ancla de un TextFrame**

Aspose.Slides for Python vía .NET permite a los desarrolladores establecer la posición de ancla de cualquier [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). La propiedad [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) especifica dónde se coloca el texto dentro de la forma. Puede establecerse en `TOP`, `CENTER`, `BOTTOM`, `JUSTIFIED` o `DISTRIBUTED`.

Para establecer el ancla de un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar una forma a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Establecer el [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) para el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Guardar el archivo en disco.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva 
    slide = presentation.slides[0]

    # Agregar un AutoShape de tipo Rectángulo
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Agregar TextFrame al Rectángulo
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accediendo al TextFrame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Crear el objeto Paragraph para el TextFrame
    para = txtFrame.paragraphs[0]

    # Crear el objeto Portion para el párrafo
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Guardar la presentación
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer el estilo de texto predeterminado**

Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto en una presentación, puede usar la propiedad `default_text_style` de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y establecer el formato deseado.

El ejemplo a continuación demuestra cómo establecer la fuente predeterminada en negrita, con un tamaño de 14 pt, para todo el texto en cada diapositiva de una nueva presentación.
```py
with slides.Presentation() as presentation:
    # Obtenga el formato de párrafo de nivel superior.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva incluso cuando se escribió originalmente en minúsculas. Cuando recupera esa porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se ingresó. Para manejar esto, verifique [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)—si indica `ALL`, simplemente convierta la cadena devuelta a mayúsculas para que su salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![The All Caps effect](all_caps_effect.png)

El ejemplo de código a continuación muestra cómo extraer el texto con el efecto **All Caps** aplicado:
```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```


Salida:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


{{% alert color="primary" %}}

Aspose ofrece un sencillo, [servicio gratuito de edición en línea de PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **FAQ**

**¿Puedo aplicar diferentes formatos a partes específicas del texto dentro de un solo párrafo (por ejemplo, negrita solo a un par de palabras), y cómo interactúa eso con los estilos heredados de diseños y temas?**

Sí. El formato se establece a nivel de “porción de texto” dentro de un párrafo y sobrescribe el estilo de tema/diseño solo para esos fragmentos seleccionados. Cuando el tema cambia, solo las regiones sin formato local explícito se actualizarán.

**¿Cómo funcionan las fuentes en Linux y en contenedores Docker que no tienen fuentes del sistema instaladas?**

La biblioteca usa detección/substitución de fuentes. En sistemas sin fuentes, debe especificar explícitamente [la ruta a directorios de fuentes](/slides/es/python-net/custom-font/) y/o configurar una [tabla de sustitución](/slides/es/python-net/font-substitution/) para evitar el uso de tipografías inadecuadas y cambios de diseño.

**¿En qué se diferencia el formato de texto en marcadores de posición de el formato en autoshapes normales?**

Los marcadores de posición heredan estilos del maestro de diapositivas y del diseño con mayor fuerza que los autoshapes normales. Los cambios locales en marcadores de posición son posibles, pero cuando el diseño cambia es más probable que vuelvan a los estilos del tema a menos que haya sobrescrito el formato a nivel de porción de texto.