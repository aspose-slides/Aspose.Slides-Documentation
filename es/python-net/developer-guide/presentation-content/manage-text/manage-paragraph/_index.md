---
title: Administrar párrafos de texto de PowerPoint en Python
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/python-net/manage-paragraph/
keywords:
- agregar texto
- agregar párrafo
- administrar texto
- administrar párrafo
- administrar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades de párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para Python vía .NET—optimiza alineación, espaciado y estilo en presentaciones de PowerPoint y OpenDocument en Python para cautivar a la audiencia."
---

## **Visión general**

Aspose.Slides proporciona las clases que necesita para trabajar con texto de PowerPoint en Python.

* Aspose.Slides ofrece la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) para crear objetos de marco de texto. Un objeto `TextFrame` puede contener uno o varios párrafos (cada párrafo está separado por un retorno de carro).
* Aspose.Slides ofrece la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) para crear objetos de párrafo. Un objeto `Paragraph` puede contener una o varias porciones de texto.
* Aspose.Slides ofrece la clase [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) para crear objetos de porción de texto y especificar sus propiedades de formato.

Un objeto `Paragraph` puede manejar texto con diferentes propiedades de formato a través de sus objetos subyacentes `Portion`.

## **Agregar varios párrafos que contengan varias porciones**

Estos pasos muestran cómo agregar un marco de texto que contiene tres párrafos, cada uno con tres porciones:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva de destino por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Obtener el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) asociado a la [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Crear dos objetos [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y agregarlos a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (junto con el párrafo predeterminado, esto da tres párrafos).
1. Para cada párrafo, crear tres objetos [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) y agregarlos a la colección de porciones de ese párrafo.
1. Establecer el texto para cada porción.
1. Aplicar cualquier formato deseado a cada porción de texto usando las propiedades expuestas por [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Guardar la presentación modificada.

El siguiente código Python implementa estos pasos:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation para crear un nuevo archivo PPTX.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar un AutoShape rectangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Acceder al TextFrame del AutoShape.
    text_frame = shape.text_frame

    # Crear párrafos y porciones; el formato se aplica a continuación.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Guardar el PPTX en disco.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Administrar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con viñetas suelen ser más fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la diapositiva de destino por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
1. Eliminar el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Crear el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Establecer el tipo de viñeta del párrafo a `SYMBOL` y especificar el carácter de viñeta.
1. Establecer el texto del párrafo.
1. Establecer la sangría de la viñeta para el párrafo.
1. Establecer el color de la viñeta.
1. Establecer el tamaño (altura) de la viñeta.
1. Agregar el párrafo a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Agregar un segundo párrafo y repetir los pasos 7 – 12.
1. Guardar la presentación.

Este código Python muestra cómo agregar párrafos con viñetas:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de presentación.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir y acceder a un AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al marco de texto del AutoShape creado.
    text_frame = shape.text_frame

    # Eliminar el párrafo predeterminado.
    text_frame.paragraphs.remove_at(0)

    # Crear un párrafo.
    paragraph = slides.Paragraph()

    # Establecer el estilo y símbolo de viñeta del párrafo.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Establecer el texto del párrafo.
    paragraph.text = "Welcome to Aspose.Slides"

    # Establecer la sangría de la viñeta.
    paragraph.paragraph_format.indent = 25

    # Establecer el color de la viñeta.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Establecer la altura de la viñeta.
    paragraph.paragraph_format.bullet.height = 100

    # Añadir el párrafo al marco de texto.
    text_frame.paragraphs.add(paragraph)

    # Crear el segundo párrafo.
    paragraph2 = slides.Paragraph()

    # Establecer el tipo y estilo de viñeta del párrafo.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Establecer el texto del párrafo.
    paragraph2.text = "This is numbered bullet"

    # Establecer la sangría de la viñeta.
    paragraph2.paragraph_format.indent = 25

    # Establecer el color de la viñeta.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Establecer la altura de la viñeta.
    paragraph2.paragraph_format.bullet.height = 100

    # Añadir el párrafo al marco de texto.
    text_frame.paragraphs.add(paragraph2)

    # Guardar la presentación como archivo PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Administrar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas de imagen son fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la diapositiva de destino por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
1. Eliminar el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Crear el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Cargar una imagen en un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. Establecer el tipo de viñeta a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) y asignar la imagen.
1. Establecer el texto del párrafo.
1. Establecer la sangría de la viñeta para el párrafo.
1. Establecer el color de la viñeta.
1. Establecer la altura de la viñeta.
1. Agregar el nuevo párrafo a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Agregar un segundo párrafo y repetir los pasos 8 – 12.
1. Guardar la presentación.

Este código Python muestra cómo agregar y administrar viñetas de imagen:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Cargar la imagen de viñeta.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Añadir y acceder a un AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al TextFrame del AutoShape creado.
    text_frame = auto_shape.text_frame

    # Eliminar el párrafo predeterminado.
    text_frame.paragraphs.remove_at(0)

    # Crear un nuevo párrafo.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Establecer el tipo de viñeta del párrafo a Imagen y asignar la imagen.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Establecer la altura de la viñeta.
    paragraph.paragraph_format.bullet.height = 100

    # Añadir el párrafo al marco de texto.
    text_frame.paragraphs.add(paragraph)

    # Guardar la presentación como archivo PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Guardar la presentación como archivo PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **Administrar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la diapositiva de destino por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Eliminar el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Crear el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer su profundidad en 0.
1. Crear el segundo párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer su profundidad en 1.
1. Crear el tercer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer su profundidad en 2.
1. Crear el cuarto párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer su profundidad en 3.
1. Agregar los nuevos párrafos a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Guardar la presentación.

El siguiente código Python muestra cómo agregar y administrar viñetas multinivel:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de presentación.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]
    
    # Añadir un AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al TextFrame del AutoShape creado.
    text_frame = auto_shape.text_frame
    
    # Borrar el párrafo predeterminado.
    text_frame.paragraphs.clear()

    # Añadir el primer párrafo.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Establecer el nivel de viñeta.
    paragraph1.paragraph_format.depth = 0

    # Añadir el segundo párrafo.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Establecer el nivel de viñeta.
    paragraph2.paragraph_format.depth = 1

    # Añadir el tercer párrafo.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Establecer el nivel de viñeta.
    paragraph3.paragraph_format.depth = 2

    # Añadir el cuarto párrafo.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Establecer el nivel de viñeta.
    paragraph4.paragraph_format.depth = 3

    # Añadir los párrafos a la colección.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Guardar la presentación como archivo PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Administrar párrafos con listas numeradas personalizadas**

La clase [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) proporciona la propiedad `numbered_bullet_start_with` (y otras) para controlar la numeración y el formato personalizado de los párrafos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la diapositiva que contendrá los párrafos.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
1. Eliminar el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Crear el primer [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer `numbered_bullet_start_with` en 2.
1. Crear el segundo [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer `numbered_bullet_start_with` en 3.
1. Crear el tercer [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establecer `numbered_bullet_start_with` en 7.
1. Agregar los párrafos a la colección del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Guardar la presentación.

El siguiente código Python demuestra cómo agregar y administrar párrafos con numeración y formato personalizado.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Agregar y acceder a un AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al TextFrame del AutoShape creado.
    text_frame = shape.text_frame

    # Eliminar el párrafo predeterminado existente.
    text_frame.paragraphs.remove_at(0)

    # Crear el primer elemento numerado (iniciar en 2, nivel de profundidad 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Crear el segundo elemento numerado (iniciar en 3, nivel de profundidad 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Crear el tercer elemento numerado (iniciar en 7, nivel de profundidad 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer sangría de párrafo**

La sangría de párrafo ayuda a establecer una jerarquía de lectura clara en una diapositiva y a afinar la alineación del texto. El ejemplo a continuación muestra cómo establecer tanto la sangría general como la de la primera línea en Aspose.Slides para Python mediante las propiedades de [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/).

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la diapositiva de destino por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Agregar un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) con tres párrafos a la [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Ocultar el contorno del rectángulo.
1. Establecer la sangría para cada [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) usando su propiedad `paragraph_format`.
1. Guardar la presentación modificada como archivo PPT.

El siguiente código Python muestra cómo establecer sangrías de párrafo:
```python
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar una forma rectangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Agregar un TextFrame al rectángulo.
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # Ajustar el texto para que quepa en la forma.
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Establecer un contorno sólido para el rectángulo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Obtener el primer párrafo en el TextFrame y establecer su viñeta y sangría.
    paragraph1 = text_frame.paragraphs[0]
    # Establecer el estilo de viñeta y símbolo del párrafo.
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # Obtener el segundo párrafo en el TextFrame y establecer su viñeta y sangría.
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # Obtener el tercer párrafo en el TextFrame y establecer su viñeta y sangría.
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # Guardar la presentación en disco.
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer sangría colgante para párrafos**

Este código Python muestra cómo establecer una sangría colgante para un párrafo:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Administrar formato de porción al final del párrafo**

Cuando necesita controlar el estilo del “final” de un párrafo (el formato aplicado después de la última porción de texto), use la propiedad `end_paragraph_portion_format`. El ejemplo a continuación aplica una fuente Times New Roman de mayor tamaño al final del segundo párrafo.

1. Crear o abrir un archivo [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la diapositiva de destino por índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Usar el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma y crear dos párrafos.
1. Crear un [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) configurado a 48 pt Times New Roman y aplicarlo como formato de porción al final del párrafo.
1. Asignarlo a la propiedad `end_paragraph_portion_format` del párrafo (se aplica al final del segundo párrafo).
1. Guardar la presentación modificada como archivo PPTX.

Este código Python le muestra cómo establecer el formato al final del párrafo para el segundo párrafo:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Importar texto HTML en párrafos**

Aspose.Slides brinda soporte mejorado para importar texto HTML en párrafos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la diapositiva de destino por su índice.
1. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Eliminar el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Leer el archivo HTML de origen.
1. Crear el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Agregar el contenido HTML a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Guardar la presentación modificada.

El siguiente código Python implementa estos pasos para importar texto HTML en párrafos.
```python
import aspose.slides as slides

# Crear una instancia vacía de Presentation.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Agregar un AutoShape para alojar el contenido HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Borrar todos los párrafos del marco de texto añadido.
    shape.text_frame.paragraphs.clear()

    # Cargar el archivo HTML.
    with open("file.html", "rt") as html_stream:
        # Añadir texto del archivo HTML al marco de texto.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Guardar la presentación.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Exportar texto de párrafo a HTML**

Aspose.Slides brinda soporte mejorado para exportar texto a HTML.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargar la presentación de destino.
1. Acceder a la diapositiva deseada por su índice.
1. Seleccionar la forma que contiene el texto a exportar.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
1. Abrir un flujo de archivo para escribir la salida HTML.
1. Especificar el índice de inicio y exportar los párrafos requeridos.

Este ejemplo Python muestra cómo exportar texto de párrafo a HTML.
```python
import aspose.slides as slides

# Cargar el archivo de presentación.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Acceder a la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    # Índice de la forma objetivo.
    index = 0

    # Acceder a la forma por índice.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Escribir los datos de los párrafos a HTML proporcionando el índice del párrafo inicial y el número total de párrafos a exportar.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```


## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/), como una imagen. Ambos ejemplos incluyen la obtención de la imagen de una forma que contiene el párrafo mediante los métodos `get_image` de la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), el cálculo de los límites del párrafo dentro de la forma y la exportación como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones de PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como imagen. Para hacerlo, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es particularmente útil cuando necesita guardar un párrafo específico como una imagen independiente manteniendo las dimensiones y el formato exactos del texto.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Guardar la forma en memoria como un mapa de bits.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Crear un mapa de bits de forma desde la memoria.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calcular los límites del segundo párrafo.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Recortar el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


El resultado:

![The paragraph image](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para materiales impresos de alta calidad.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Guardar la forma en memoria como un mapa de bits.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Crear un mapa de bits de forma desde la memoria.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calcular los límites del segundo párrafo.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Recortar el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Use la configuración de ajuste del marco de texto ([wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede obtener el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de cada porción.

**¿Puedo establecer un idioma de revisión ortográfica solo para una parte del párrafo (p. ej., una palabra)?**

Sí. El idioma se establece a nivel de porción ([PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.