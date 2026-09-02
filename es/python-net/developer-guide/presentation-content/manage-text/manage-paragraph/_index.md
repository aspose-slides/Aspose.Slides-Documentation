---
title: Administrar párrafos de texto de PowerPoint en Python
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría francesa
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
description: "Aprenda cómo crear y dar formato a párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML e imágenes de párrafos con Aspose.Slides para Python mediante .NET."
---
## **Visión general**

Aspose.Slides for Python a través de .NET representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) representa un párrafo en un marco de texto y proporciona acceso a sus porciones y formato a nivel de párrafo.
* [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varias porciones.

## **Crear y dar formato a párrafos**

### **Crear párrafos con múltiples porciones**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres porciones:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceder a la diapositiva correspondiente mediante su índice.
3. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
5. Utilizar el párrafo predeterminado y añadir dos objetos [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) más al marco de texto.
6. Añadir suficientes objetos [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) para que cada párrafo contenga tres porciones. El párrafo predeterminado ya contiene una porción vacía.
7. Establecer el texto de cada porción.
8. Aplicar formato a nivel de carácter a través de [Portion.portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/portion_format/).
9. Guardar la presentación modificada.

Este ejemplo en Python implementa los pasos:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear listas con viñetas y numeradas**

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la lectura de elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [BulletFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/).

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceder a la diapositiva correspondiente mediante su índice.
3. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a la diapositiva seleccionada.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
5. Eliminar el párrafo predeterminado del marco de texto.
6. Crear un [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establecer [BulletFormat.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/type/) a [BulletType.SYMBOL](https://reference.aspose.com/slides/es/python-net/aspose.slides/bullettype/) y especificar el carácter de la viñeta.
8. Definir el texto del párrafo, sangría, color y altura de la viñeta.
9. Añadir el párrafo al marco de texto.
10. Crear un segundo párrafo y establecer [BulletFormat.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/type/) a [BulletType.NUMBERED](https://reference.aspose.com/slides/es/python-net/aspose.slides/bullettype/).
11. Configurar el estilo de la viñeta numerada y añadir el párrafo al marco de texto.
12. Guardar la presentación.

Este ejemplo en Python crea una viñeta de símbolo y una viñeta numerada:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Usar viñetas con imágenes**

Las viñetas con imágenes permiten usar una imagen personalizada en lugar de un símbolo o número.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceder a la diapositiva correspondiente mediante su índice.
3. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) y acceder a su [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).
4. Eliminar el párrafo predeterminado del marco de texto.
5. Cargar la imagen de la viñeta y añadirla a la colección de imágenes de la presentación como un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/).
6. Crear un [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) y establecer su texto.
7. Establecer [BulletFormat.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/type/) a [BulletType.PICTURE](https://reference.aspose.com/slides/es/python-net/aspose.slides/bullettype/).
8. Asignar la imagen mediante [BulletFormat.picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/picture/) y definir la altura de la viñeta.
9. Añadir el párrafo al marco de texto.
10. Guardar la presentación modificada.

Este ejemplo en Python crea una viñeta con imagen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Crear una lista multinivel**

Establezca [ParagraphFormat.depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/depth/) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Crear una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y acceder a una diapositiva.
2. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) y borrar el párrafo predeterminado de su marco de texto.
3. Crear cuatro párrafos y configurar sus símbolos de viñeta.
4. Asignar a cada uno los valores de [ParagraphFormat.depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/depth/) `0`, `1`, `2` y `3`.
5. Añadir los párrafos al marco de texto y guardar la presentación.

Este ejemplo en Python crea una lista con viñetas de cuatro niveles:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Iniciar elementos numerados con valores personalizados**

Utilice [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) para establecer el número inicial que se muestra en un párrafo numerado.

1. Crear una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) a una diapositiva.
2. Borrar el párrafo predeterminado del marco de texto de la forma.
3. Crear tres párrafos numerados.
4. Establecer [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) a `2`, `3` y `7` para los respectivos párrafos.
5. Añadir los párrafos al marco de texto y guardar la presentación.

Este ejemplo en Python asigna un número inicial personalizado a cada párrafo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar el diseño del párrafo y sus propiedades de finalización**

### **Establecer una sangría de primera línea**

Utilice la propiedad [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para controlar la sangría de la primera línea de un párrafo. Esta propiedad desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Use [ParagraphFormat.margin_left](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/margin_left/) cuando necesite mover todo el párrafo. Use [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) cuando solo necesite mover la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para demostrar cómo la sangría de primera línea afecta el diseño del párrafo.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceder a la diapositiva objetivo.
3. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma y eliminar el párrafo predeterminado.
5. Crear varios párrafos y establecer diferentes valores de [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para ellos.
6. Añadir los párrafos al marco de texto.
7. Guardar la presentación modificada.

Este código muestra cómo establecer una sangría de párrafo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Establecer una sangría francesa**

Una sangría francesa es un diseño de párrafo en el que la primera línea comienza a la izquierda de las líneas restantes. En Aspose.Slides, crea este efecto con la propiedad [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/). Establezca `indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/margin_left/) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría francesa, establezca un valor positivo de `margin_left` y un valor negativo de `indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceder a la diapositiva objetivo.
3. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma y eliminar el párrafo predeterminado.
5. Crear párrafos y establecer un valor positivo de [ParagraphFormat.margin_left](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/margin_left/) para cada párrafo.
6. Establecer un valor negativo de [ParagraphFormat.indent](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/indent/) para crear el efecto de sangría francesa.
7. Añadir los párrafos al marco de texto.
8. Guardar la presentación modificada.

Este código muestra cómo establecer una sangría francesa para un párrafo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Establecer propiedades de ejecución del párrafo final**

La propiedad [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) controla el formato del signo de fin de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al signo de fin del segundo párrafo:

1. Cargar una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y acceder a una diapositiva.
2. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) y borrar su párrafo predeterminado.
3. Crear dos párrafos y añadir porciones de texto a cada uno.
4. Crear un [PortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/) para el signo de fin del segundo párrafo.
5. Establecer [PortionFormat.font_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/font_height/) y [PortionFormat.latin_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/latin_font/).
6. Asignar el formato a [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) y guardar la presentación.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Utilice [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphcollection/add_from_html/) para convertir marcado HTML en párrafos y porciones dentro de un marco de texto.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Acceder a una diapositiva y añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).
3. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma y borrar su párrafo predeterminado.
4. Leer el archivo HTML origen.
5. Pasar la cadena HTML a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Guardar la presentación modificada.

Este ejemplo en Python importa HTML a un marco de texto:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportar texto de párrafo a HTML**

Utilice [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphcollection/export_to_html/) para exportar un rango seleccionado de párrafos como HTML.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y cargar la presentación deseada.
2. Acceder a la diapositiva y encontrar la [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) que contiene el texto.
3. Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) de la forma.
4. Llamar a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphcollection/export_to_html/) con el índice del párrafo inicial y el número de párrafos a exportar.
5. Escribir la cadena HTML devuelta en un archivo.

Este ejemplo en Python exporta todos los párrafos del primer cuadro de texto:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Renderizar un párrafo como imagen**

[Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) proporciona el método `get_image` para renderizar directamente un párrafo individual. El método devuelve un [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) que puede guardarse en un archivo o flujo con [IImage.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/save/). No es necesario renderizar la forma contenedora ni recortar manualmente un mapa de bits.

El método `get_image` puede devolver `None` si el párrafo no se encuentra en su colección principal, no tiene límites de renderizado válidos o no puede renderizarse. Compruebe el resultado antes de guardarlo y utilice la imagen devuelta como un gestor de contexto para liberar sus recursos.

#### **Renderizar un párrafo a escala por defecto**

Supongamos que disponemos de un archivo de presentación llamado `sample.pptx` con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

El siguiente ejemplo renderiza el segundo párrafo en una forma de texto normal a la escala por defecto y guarda la imagen devuelta en formato PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

El resultado:

![The paragraph image](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escala**

Passe factores de escala horizontal y vertical a `get_image` para controlar el tamaño del párrafo renderizado. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su ancho y altura predeterminados, y guarda el resultado como una imagen PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones originales, lo que resulta en cuatro veces más píxeles. Los factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores inferiores a `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para conservar la proporción del párrafo; factores diferentes en los ejes horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [Shape.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_image/) sigue siendo útil cuando la salida debe incluir el relleno, borde u otro contexto visual de la forma. Para una imagen solo del párrafo, utilice `Paragraph.get_image`.

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/wrap_text/) para desactivar el ajuste y que las líneas no se partan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utilice [Paragraph.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/get_rect/) para obtener el rectángulo delimitador del párrafo. [Portion.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/get_rect/) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/alignment/) es una configuración a nivel de párrafo y se aplica a todo el párrafo, independientemente del formato de las porciones individuales.

**¿Puedo establecer el idioma de revisión para parte de un párrafo?**

Sí. Establezca [PortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/language_id/) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.