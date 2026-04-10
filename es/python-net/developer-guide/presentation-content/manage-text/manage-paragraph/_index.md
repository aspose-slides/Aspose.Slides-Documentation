---
title: Gestionar párrafos de texto de PowerPoint en Python
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/python-net/manage-paragraph/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades del párrafo
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
description: "Domina el formato de párrafos con Aspose.Slides para Python a través de .NET—optimiza alineación, espaciado & estilo en presentaciones de PowerPoint y OpenDocument en Python para cautivar a los espectadores."
---
## **Descripción general**

Aspose.Slides proporciona las clases que necesita para trabajar con texto de PowerPoint en Python.

* Aspose.Slides proporciona la clase [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) para crear objetos de marco de texto. Un objeto `TextFrame` puede contener uno o varios párrafos (cada párrafo está separado por un retorno de carro).
* Aspose.Slides proporciona la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) para crear objetos de párrafo. Un objeto `Paragraph` puede contener una o varias porciones de texto.
* Aspose.Slides proporciona la clase [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) para crear objetos de porción de texto y especificar sus propiedades de formato.

Un objeto `Paragraph` puede manejar texto con diferentes propiedades de formato mediante sus objetos subyacentes `Portion`.

## **Agregar varios párrafos que contienen varias porciones**

Estos pasos muestran cómo añadir un marco de texto que contiene tres párrafos, cada uno con tres porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva objetivo mediante su índice.
1. Añada una [AutoShape] rectangular a la diapositiva.
1. Obtenga el [TextFrame] asociado con la [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).
1. Cree dos objetos [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y añádalos a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) (junto con el párrafo predeterminado, esto da tres párrafos).
1. Para cada párrafo, cree tres objetos [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) y añádalos a la colección de porciones de ese párrafo.
1. Establezca el texto para cada porción.
1. Aplique cualquier formato deseado a cada porción de texto utilizando las propiedades expuestas por [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/).
1. Guarde la presentación modificada.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation para crear un nuevo archivo PPTX.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una AutoShape rectangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Acceder al TextFrame de la AutoShape.
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

## **Gestionar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con viñetas suelen ser más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceda a la diapositiva objetivo mediante su índice.
1. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
1. Elimine el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Cree el primer párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/).
1. Establezca el tipo de viñeta del párrafo a `SYMBOL` y especifique el carácter de la viñeta.
1. Establezca el texto del párrafo.
1. Establezca la sangría de la viñeta para el párrafo.
1. Establezca el color de la viñeta.
1. Establezca el tamaño (altura) de la viñeta.
1. Añada el párrafo a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Añada un segundo párrafo y repita los pasos 7–12.
1. Guarde la presentación.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de presentación.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir y acceder a una AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al marco de texto de la AutoShape creada.
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

## **Gestionar viñetas con imágenes**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Las viñetas con imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceda a la diapositiva objetivo mediante su índice.
1. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
1. Elimine el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Cree el primer párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/).
1. Cargue una imagen en un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/).
1. Establezca el tipo de viñeta a [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) y asigne la imagen.
1. Establezca el texto del párrafo.
1. Establezca la sangría del párrafo para la viñeta.
1. Establezca el color de la viñeta.
1. Establezca la altura de la viñeta.
1. Añada el nuevo párrafo a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Añada un segundo párrafo y repita los pasos 8–12.
1. Guarde la presentación.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Cargar la imagen de viñeta.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Añadir y acceder a una AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al TextFrame de la AutoShape creada.
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

## **Gestionar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceda a la diapositiva objetivo mediante su índice.
1. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceda al [TextFrame] de la [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).
1. Elimine el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Cree el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca su profundidad a 0.
1. Cree el segundo párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca su profundidad a 1.
1. Cree el tercer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca su profundidad a 2.
1. Cree el cuarto párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca su profundidad a 3.
1. Añada los nuevos párrafos a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Guarde la presentación.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de presentación.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]
    
    # Añadir una AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al TextFrame de la AutoShape creada.
    text_frame = auto_shape.text_frame
    
    # Eliminar el párrafo predeterminado.
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

## **Gestionar párrafos con listas numeradas personalizadas**

La clase [BulletFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/) proporciona la propiedad `numbered_bullet_start_with` (y otras) para controlar la numeración y el formato personalizados de los párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceda a la diapositiva que contendrá los párrafos.
1. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
1. Elimine el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Cree el primer [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca `numbered_bullet_start_with` a 2.
1. Cree el segundo [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca `numbered_bullet_start_with` a 3.
1. Cree el tercer [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establezca `numbered_bullet_start_with` a 7.
1. Añada los párrafos a la colección del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Guarde la presentación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Añadir y acceder a una AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acceder al TextFrame de la AutoShape creada.
    text_frame = shape.text_frame

    # Eliminar el párrafo predeterminado existente.
    text_frame.paragraphs.remove_at(0)

    # Crear el primer elemento numerado (comenzar en 2, nivel de profundidad 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Crear el segundo elemento numerado (comenzar en 3, nivel de profundidad 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Crear el tercer elemento numerado (comenzar en 7, nivel de profundidad 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer sangría de primera línea para un párrafo**

Utilice la propiedad [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para controlar la sangría de la primera línea de un párrafo. Esta propiedad desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Utilice [ParagraphFormat.margin_left](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/margin_left/) cuando necesite mover todo el párrafo. Utilice [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) cuando necesite mover solo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de `indent` para demostrar cómo la sangría de primera línea afecta la disposición del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape] rectangular a la diapositiva.
4. Añada un [TextFrame] vacío a la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

![La sangría de primera línea de los párrafos](first_line_indent.png)

## **Establecer sangría colgante para un párrafo**

Una sangría colgante es una disposición de párrafo en la que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con la propiedad [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/). Establezca `indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/margin_left/) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo de `margin_left` y un valor negativo de `indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas ajustadas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape] rectangular a la diapositiva.
4. Añada un [TextFrame] vacío a la forma y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [margin_left](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/margin_left/) para cada párrafo.
6. Establezca un valor negativo de [indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

![La sangría colgante de los párrafos](hanging_indent.png)

## **Gestionar el formato de porción de fin de párrafo**

Cuando necesite controlar el estilo del «final» de un párrafo (el formato aplicado después de la última porción de texto), use la propiedad `end_paragraph_portion_format`. El ejemplo a continuación aplica una fuente Times New Roman más grande al final del segundo párrafo.

1. Cree o abra un archivo [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Obtenga la diapositiva objetivo por índice.
1. Añada una [AutoShape] rectangular a la diapositiva.
1. Utilice el [TextFrame] de la forma y cree dos párrafos.
1. Cree un [PortionFormat] configurado a Times New Roman de 48 pt y aplíquelo como el formato de porción de fin de párrafo del párrafo.
1. Asignelo a `end_paragraph_portion_format` del párrafo (se aplica al final del segundo párrafo).
1. Escriba la presentación modificada como un archivo PPTX.

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

Aspose.Slides ofrece un soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Acceda a la diapositiva objetivo mediante su índice.
1. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a la diapositiva.
1. Acceda al [TextFrame] de la [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).
1. Elimine el párrafo predeterminado del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Lea el archivo HTML de origen.
1. Cree el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/).
1. Añada el contenido HTML a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
1. Guarde la presentación modificada.

```python
import aspose.slides as slides

# Crear una instancia vacía de Presentation.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva de la presentación.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Añadir una AutoShape para albergar el contenido HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Eliminar todos los párrafos del marco de texto añadido.
    shape.text_frame.paragraphs.clear()

    # Cargar el archivo HTML.
    with open("file.html", "rt") as html_stream:
        # Añadir texto del archivo HTML al marco de texto.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Guardar la presentación.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Exportar texto de párrafo a HTML**

Aspose.Slides ofrece un soporte mejorado para exportar texto a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y cargue la presentación objetivo.
1. Acceda a la diapositiva deseada mediante su índice.
1. Seleccione la forma que contiene el texto a exportar.
1. Acceda al [TextFrame] de la forma.
1. Abra una secuencia de archivo para escribir la salida HTML.
1. Especifique el índice inicial y exporte los párrafos requeridos.

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

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la clase [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/), como una imagen. Ambos ejemplos incluyen obtener la imagen de una forma que contiene el párrafo usando los métodos `get_image` de la clase [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/), calcular los límites del párrafo dentro de la forma y exportarlo como una imagen bitmap. Estos enfoques permiten extraer partes específicas del texto de presentaciones de PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen separada conservando sus dimensiones y formato exactos.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Guardar la forma en memoria como bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Crear un bitmap de la forma desde la memoria.
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

    # Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

![La imagen del párrafo](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como imagen con un factor de escala de `2`. Esto permite obtener una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para material impreso de alta calidad.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Guardar la forma en memoria como bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Crear un bitmap de la forma desde la memoria.
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

    # Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Utilice la configuración de ajuste del marco de texto ([wrap_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/wrap_text/)) para desactivar el ajuste, de modo que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede recuperar el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/alignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de cada porción.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte de un párrafo (p.ej., una palabra)?**

Sí. El idioma se establece a nivel de porción ([PortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/language_id/)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.