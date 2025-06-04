---
title: Formatear texto de PowerPoint en Python
linktitle: Formateo de texto
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
- familia tipográfica
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad de ajuste automático
- anclaje de marco de texto
- tabulación de texto
- idioma predeterminado
- Python
- Aspose.Slides
description: "Aprende cómo formatear y estilizar texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides for Python via .NET. Personaliza fuentes, colores, alineación y más con potentes ejemplos de código en Python."
---

## **Resaltar Texto**
Se ha añadido un nuevo método HighlightText a la interfaz ITextFrame y a la clase TextFrame.

Permite resaltar una parte del texto con color de fondo utilizando una muestra de texto, similar a la herramienta de Color de Resaltado de Texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo utilizar esta función:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Aspose ofrece un sencillo, [servicio de edición de PowerPoint en línea gratuito](https://products.aspose.app/slides/editor).

{{% /alert %}} 


## **Resaltar Texto usando Expresión Regular**
Se ha añadido un nuevo método HighlightRegex a la interfaz ITextFrame y a la clase TextFrame.

Permite resaltar una parte del texto con color de fondo utilizando una expresión regular, similar a la herramienta de Color de Resaltado de Texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo utilizar esta función:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Color de Fondo para Texto**

Aspose.Slides te permite especificar tu color preferido para el fondo de un texto.

Este código Python te muestra cómo establecer el color de fondo para todo un texto: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Negro")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Rojo ")
    
    portion3 = slides.Portion("Negro")
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

Este código Python te muestra cómo establecer el color de fondo solo para una porción de un texto:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Negro")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Rojo ")
    
    portion3 = slides.Portion("Negro")
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

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Rojo' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Alinear Párrafos de Texto**
El formateo de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides para Python vía .NET permite agregar texto a las diapositivas, pero en este tema, veremos cómo podemos controlar la alineación de los párrafos de texto en una diapositiva. Por favor, sigue los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides para Python vía .NET :

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener la referencia de una diapositiva utilizando su índice.
3. Acceder a las formas de Marcador de posición presentes en la diapositiva y convertirlas en AutoShape.
4. Obtener el Párrafo (que necesita ser alineado) del TextFrame expuesto por AutoShape.
5. Alinear el Párrafo. Un párrafo puede alinearse a la Derecha, Izquierda, Centro y Justificar.
6. Guardar la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se ofrece a continuación.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPTX
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # Acceder a la primera diapositiva
    slide = presentation.slides[0]

    # Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo en AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Cambiar el texto en ambos marcadores de posición
    tf1.text = "Alinear al Centro por Aspose"
    tf2.text = "Alinear al Centro por Aspose"

    # Obtener el primer párrafo de los marcadores de posición
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Alinear el párrafo de texto al centro
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Escribir la presentación como un archivo PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Transparencia para Texto**
Este artículo demuestra cómo establecer la propiedad de transparencia a cualquier forma de texto usando Aspose.Slides para Python vía .NET. Para establecer la transparencia en el texto, por favor sigue los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener la referencia de una diapositiva.
3. Establecer el color de sombra.
4. Guardar la presentación como un archivo PPTX.

La implementación de los pasos anteriores se ofrece a continuación.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - la transparencia es: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # establecer transparencia a cero por ciento
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Espaciado de Caracteres para Texto**

Aspose.Slides te permite establecer el espacio entre letras en un cuadro de texto. De esta manera, puedes ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espacio entre caracteres.

Este código Python te muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea: 

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # expandir
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condensar

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gestionar las Propiedades de Fuente del Párrafo**
Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de varias maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a los estilos corporativos. El formateo de texto ayuda a los usuarios a variar el aspecto y la sensación del contenido de la presentación. Este artículo muestra cómo utilizar Aspose.Slides para Python vía .NET para configurar las propiedades de fuente de los párrafos de texto en las diapositivas. Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides para Python vía .NET :

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a las formas de Marcador de posición en la diapositiva y convertirlas en AutoShape.
1. Obtener el Párrafo del TextFrame expuesto por AutoShape.
1. Justificar el párrafo.
1. Acceder a la porción de texto de un párrafo.
1. Definir la fuente usando FontData y establecer la Fuente de la porción de texto en consecuencia.
   1. Establecer la fuente en negrita.
   2. Establecer la fuente en cursiva.
1. Establecer el color de fuente usando el FillFormat expuesto por el objeto Porción.
1. Escribir la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se ofrece a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar un objeto Presentation que representa un archivo PPTX
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # Acceder a una diapositiva usando su posición en la diapositiva
    slide = pres.slides[0]

    # Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo en AutoShape
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

    # Establecer el color de fuente
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #Escribir el PPTX en disco
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gestionar la Familia de Fuentes del Texto**
Una Porción se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para Python para crear un cuadro de texto con algún texto y luego definir una fuente particular, y varias otras propiedades de la categoría de fuente. Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener la referencia de una diapositiva utilizando su índice.
3. Agregar un AutoShape del tipo Rectángulo a la diapositiva.
4. Quitar el estilo de relleno asociado con el AutoShape.
5. Acceder al TextFrame del AutoShape.
6. Agregar texto al TextFrame.
7. Acceder al objeto Porción asociado con el TextFrame.
8. Definir la fuente que se utilizará para la Porción.
9. Establecer otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura utilizando las propiedades relevantes expuestas por el objeto Porción.
10. Escribir la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se ofrece a continuación.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar Presentation
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva
    sld = presentation.slides[0]

    # Agregar un AutoShape de tipo Rectángulo
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Quitar cualquier estilo de relleno asociado con el AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Acceder al TextFrame asociado con el AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Acceder a la Porción asociada con el TextFrame
    port = tf.paragraphs[0].portions[0]

    # Establecer la Fuente para la Porción
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Establecer la propiedad Negrita de la Fuente
    port.portion_format.font_bold = 1

    # Establecer la propiedad Cursiva de la Fuente
    port.portion_format.font_italic = 1

    # Establecer la propiedad Subrayado de la Fuente
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Establecer la Altura de la Fuente
    port.portion_format.font_height = 25

    # Establecer el color de la Fuente
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Escribir el PPTX en disco 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Tamaño de Fuente para Texto**

Aspose.Slides te permite elegir tu tamaño de fuente preferido para el texto existente en un párrafo y otros textos que puedan ser añadidos al párrafo más adelante.

Este código Python te muestra cómo establecer el tamaño de fuente para textos contenidos en un párrafo: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Obtiene la primera forma, por ejemplo.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Obtiene el primer párrafo, por ejemplo.
        paragraph = shape.text_frame.paragraphs[0]

        # Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto en el párrafo. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Establece el tamaño de fuente a 20 pt para las porciones de texto actuales en el párrafo. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Establecer Rotación de Texto**
Aspose.Slides para Python vía .NET permite a los desarrolladores rotar el texto. El texto puede establecerse para aparecer como Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical o WordArtVerticalRightToLeft. Para rotar el texto de cualquier TextFrame, por favor sigue los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceder a la primera diapositiva.
3. Agregar cualquier forma a la diapositiva.
4. Acceder al TextFrame.
5. Rotar el texto.
6. Guardar el archivo en disco.

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

    # Accediendo al marco de texto
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Crear el objeto Párrafo para el marco de texto
    para = txtFrame.paragraphs[0]

    # Crear objeto Porción para el párrafo
    portion = para.portions[0]
    portion.text = "Un rápido zorro marrón salta sobre el perro perezoso. Un rápido zorro marrón salta sobre el perro perezoso."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Guardar Presentación
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Ángulo de Rotación Personalizado para TextFrame**
Aspose.Slides para Python vía .NET ahora admite Establecer un ángulo de rotación personalizado para el marco de texto. En este tema, veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. La nueva propiedad RotationAngle se ha añadido a las interfaces IChartTextBlockFormat y ITextFrameFormat, permite establecer el ángulo de rotación personalizado para el marco de texto. Para establecer la propiedad RotationAngle, por favor sigue los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Añadir un gráfico a la diapositiva.
3. Establecer la propiedad RotationAngle.
4. Escribir la presentación como un archivo PPTX.

En el ejemplo dado a continuación, establecemos la propiedad RotationAngle.

```py
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Título personalizado").text_frame_format.rotation_angle = -30

    # Guardar Presentación
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Espaciado de Líneas del Párrafo**
Aspose.Slides proporciona propiedades bajo `paragraph_format`—`space_after`, `space_before` y `space_within`—que te permiten gestionar el espaciado de línea para un párrafo. Las tres propiedades se utilizan de esta manera:

* Para especificar el espaciado de línea para un párrafo en porcentaje, usa un valor positivo. 
* Para especificar el espaciado de línea para un párrafo en puntos, usa un valor negativo.

Por ejemplo, puedes aplicar un espaciado de línea de 16pt para un párrafo configurando la propiedad `space_before` a -16.

Así es como especificas el espaciado de línea para un párrafo específico:

1. Cargar una presentación que contenga un AutoShape con algo de texto en él.
2. Obtener la referencia de una diapositiva a través de su índice.
3. Acceder al TextFrame.
4. Acceder al Párrafo.
5. Establecer las propiedades del Párrafo.
6. Guardar la presentación.

Este código Python te muestra cómo especificar el espaciado de línea para un párrafo:

```py
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # Obtener la referencia de una diapositiva a través de su índice
    sld = presentation.slides[0]

    # Acceder al TextFrame
    tf1 = sld.shapes[0].text_frame

    # Acceder al Párrafo
    para1 = tf1.paragraphs[0]

    # Establecer propiedades del Párrafo
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Guardar Presentación
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer la Propiedad AutofitType para TextFrame**
En este tema, exploraremos las diferentes propiedades de formateo del marco de texto. Este artículo cubre cómo establecer la propiedad AutofitType del marco de texto, el ancla del texto y la rotación del texto en la presentación. Aspose.Slides para Python vía .NET permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType podría establecerse en Normal o Shape. Si se establece en Normal, la forma seguirá siendo la misma, mientras que el texto se ajustará sin hacer que la forma cambie. Mientras que si AutofitType se establece en shape, entonces la forma se modificará para que solo el texto necesario esté contenido en ella. Para establecer la propiedad AutofitType de un marco de texto, por favor sigue los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceder a la primera diapositiva.
3. Agregar cualquier forma a la diapositiva.
4. Acceder al TextFrame.
5. Establecer el AutofitType del TextFrame.
6. Guardar el archivo en disco.

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

    # Accediendo al marco de texto
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Crear el objeto Párrafo para el marco de texto
    para = txtFrame.paragraphs[0]

    # Crear objeto Porción para el párrafo
    portion = para.portions[0]
    portion.text = "Un rápido zorro marrón salta sobre el perro perezoso. Un rápido zorro marrón salta sobre el perro perezoso."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Guardar Presentación
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Establecer Ancla de TextFrame**
Aspose.Slides para Python vía .NET permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca ese texto en la forma. TextAnchorType puede establecerse en Top, Center, Bottom, Justified o Distributed. Para establecer el ancla de cualquier TextFrame, por favor sigue los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceder a la primera diapositiva.
3. Agregar cualquier forma a la diapositiva.
4. Acceder al TextFrame.
5. Establecer TextAnchorType del TextFrame.
6. Guardar el archivo en disco.

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

    # Accediendo al marco de texto
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Crear el objeto Párrafo para el marco de texto
    para = txtFrame.paragraphs[0]

    # Crear objeto Porción para el párrafo
    portion = para.portions[0]
    portion.text = "Un rápido zorro marrón salta sobre el perro perezoso. Un rápido zorro marrón salta sobre el perro perezoso."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Guardar Presentación
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Tabulación de Texto**
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las pestañas (de la colección Tabs y las pestañas predeterminadas)
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las pestañas predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera pestaña explícita (Posición = 731), index = 1 - segunda pestaña (Posición = 1241). Si intentas obtener la siguiente pestaña con index = 2, devolverá la primera pestaña predeterminada (Posición = 1470) etc.
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la siguiente tabulación después de algún texto. Por ejemplo, tienes el texto: "Helloworld!". Para renderizar dicho texto debes saber dónde comenzar a dibujar "world!". Primero, debes calcular la longitud de "Hello" en píxeles y llamar a GetTabAfterPosition con este valor. Obtendrás la siguiente posición de pestaña para dibujar "world!".


## **Establecer Estilo de Texto Predeterminado**

Si necesitas aplicar el mismo formateo de texto predeterminado a todos los elementos de texto de una presentación a la vez, puedes usar la propiedad `default_text_style` de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y establecer el formato preferido. El siguiente ejemplo de código muestra cómo establecer la fuente en negrita predeterminada (14 pt) para el texto en todas las diapositivas en una nueva presentación.

```py
with slides.Presentation() as presentation:
    # Obtener el formato de párrafo de nivel superior.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```