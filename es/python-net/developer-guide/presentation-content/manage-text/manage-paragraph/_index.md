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
description: "Aprenda a crear y dar formato a párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides for Python via .NET."
---
## **Descripción general**

Aspose.Slides for Python via .NET representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) representa el contenedor de texto en una forma y brinda acceso a su colección de párrafos.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) representa un párrafo en un marco de texto y brinda acceso a sus porciones y al formato a nivel de párrafo.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varias porciones.

## **Crear y dar formato a párrafos**

Cree párrafos en el marco de texto de una forma y utilice porciones para dar formato a ejecuciones individuales de texto. Esta sección muestra cómo combinar varias porciones dentro de cada párrafo y aplicar diferentes colores, tamaños de fuente y estilos.

### **Crear párrafos con múltiples porciones**

El siguiente ejemplo en Python crea tres párrafos, cada uno con tres ejecuciones de texto en su colección [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Reutiliza el párrafo predeterminado y su porción vacía, luego agrega los párrafos y porciones restantes. El formato se aplica mediante [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): la primera porción de cada párrafo es roja, en negrita y de 15 puntos; la segunda es azul, cursiva y de 18 puntos. La tercera porción conserva su formato predeterminado:

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
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear listas con viñetas y numeradas**

Organice el texto de los párrafos en listas con símbolos, números o imágenes personalizadas. Los ejemplos de esta sección cubren el formato de viñetas, listas multinivel y números de inicio personalizados.

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la lectura de elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Este ejemplo en Python agrega una viñeta de símbolo y un elemento numerado al mismo marco de texto. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) selecciona el tipo de viñeta, mientras que [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) suministra el símbolo y [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) elige el estilo de numeración. Ambos elementos utilizan viñetas negras con una altura del 100 % y una sangría de párrafo de 25 puntos:

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

### **Usar viñetas con imagen**

Las viñetas con imagen le permiten usar una imagen personalizada en lugar de un símbolo o número.

El ejemplo requiere `bullets.png` en el directorio de trabajo. Este ejemplo en Python agrega una imagen a la colección de imágenes de la presentación como un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) y la usa como viñeta de párrafo. Establece [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) para usar una viñeta de imagen y asigna la imagen mediante [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) se configura al 100 % para dimensionar la viñeta respecto al texto del párrafo:

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

Establezca [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) para situar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

Este ejemplo en Python asigna valores de [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) de 0 a 3 a cuatro párrafos, creando una jerarquía dentro de un mismo marco de texto. Cada párrafo usa una viñeta de símbolo, con [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) alternando entre una viñeta redonda y un guion para distinguir los niveles adyacentes:

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

Utilice [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) para establecer el número inicial que se muestra en un párrafo numerado.

Este ejemplo en Python establece [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) para usar numeración en tres párrafos y asigna valores de [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) de 2, 3 y 7. El valor inicial se configura por separado para cada párrafo, lo que permite que los números mostrados omitan valores:

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

## **Controlar el diseño del párrafo y sus propiedades finales**

Ajuste los márgenes e indentaciones del párrafo para controlar la posición de la primera línea y de las líneas envueltas. También puede dar formato al marcador de fin del párrafo por separado del texto visible.

### **Establecer una sangría de primera línea**

Utilice la propiedad [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) para controlar la sangría de la primera línea de un párrafo. Esta propiedad solo desplaza la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de las líneas permanecen alineadas con el cuerpo del párrafo.

Utilice [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) cuando necesite mover todo el párrafo. Utilice [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) cuando sólo necesite mover la primera línea.

El siguiente ejemplo asigna a tres párrafos la misma [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) de 20 puntos y valores de [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) de 0, 20 y 40 puntos. Las primeras líneas comienzan en desplazamientos progresivamente mayores, mientras que las líneas envueltas conservan el mismo margen izquierdo:

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

![La sangría de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría colgante**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de las líneas. En Aspose.Slides, crea este efecto con la propiedad [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Establezca `indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo en `margin_left` y un valor negativo en `indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

El siguiente ejemplo en Python combina valores de [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) de 40 y 60 puntos con valores de [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) de -20 y -30 puntos. En cada párrafo, la primera línea comienza a la izquierda de las líneas envueltas; el segundo párrafo tiene una sangría colgante más profunda:

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

![La sangría colgante de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución al final del párrafo**

La propiedad [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) controla el formato del marcador de fin del párrafo. El ejemplo carga `Test.pptx`, que debe contener al menos una diapositiva, y crea un [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) con [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) establecido en 48 puntos y [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) en Times New Roman. Asigna este formato al marcador de fin del segundo párrafo, dejando sin cambios las porciones de texto visibles:

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

## **Contar líneas renderizadas**

Para reglas de párrafo que afectan el ajuste automático y la puntuación al final de línea, consulte [Control Line Breaking](/slides/es/python-net/text-formatting/#control-line-breaking) y [Control Hanging Punctuation](/slides/es/python-net/text-formatting/#control-hanging-punctuation).

Utilice [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) para contar las líneas que ocupa un párrafo después del diseño del texto, incluido el ajuste automático. Esto es útil al comprobar la longitud del texto y el diseño en plantillas de presentaciones.

Un párrafo es un elemento de [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), y puede ocupar varias líneas renderizadas. Un salto de línea explícito dentro de un párrafo fuerza una nueva línea sin crear otro párrafo. El ajuste automático genera líneas basándose en el ancho disponible sin insertar saltos de línea explícitos en el texto. Por lo tanto, contar párrafos o caracteres de salto de línea no proporciona el recuento de líneas renderizadas.

El siguiente ejemplo crea una forma de texto, cuenta sus líneas, reduce el ancho de la forma y luego reemplaza el texto por una cadena más corta. El ejemplo habilita [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) y deshabilita [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) para que el ancho de la forma controle el ajuste sin reducir automáticamente el texto ni redimensionar la forma. Cada medición utiliza [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Las dimensiones de la forma están en puntos. Finalmente, el ejemplo agrega otro párrafo y suma los recuentos de líneas en todo el marco de texto.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Con este texto y estas dimensiones, estrechar la forma incrementa el recuento de líneas, mientras que reemplazar el texto por la cadena corta lo reduce. Los recuentos exactos pueden variar según la disponibilidad y sustitución de fuentes, el tamaño de fuente, los márgenes, la indentación, el ajuste y la configuración de autofit. Utilice las fuentes y ajustes de diseño previstos para el entorno de destino al comprobar una plantilla.

El número de líneas por sí solo no determina si el texto se desborda de su contenedor. También importan la altura disponible, la altura de línea, el espaciado de párrafo y línea, y el comportamiento de autofit; incluso una sola línea puede superar el ancho disponible cuando el ajuste está desactivado.

## **Importar y exportar contenido de párrafos**

Use HTML para introducir texto en una presentación o exportar párrafos existentes para usarlos fuera de ella. Esta sección también muestra cómo renderizar párrafos individuales como imágenes, incluidos los párrafos en celdas de tabla.

### **Importar texto HTML en párrafos**

Utilice [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) para convertir marcado HTML en párrafos y porciones en un marco de texto.

Este ejemplo en Python lee HTML de `file.html` en el directorio de trabajo y pasa el marcado a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Elimina el párrafo predeterminado del marco de texto para que éste contenga sólo el contenido importado. La forma rectangular deja un margen de 10 puntos en cada lado de la diapositiva:

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

Utilice [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) para exportar un rango seleccionado de párrafos como HTML. Al reutilizar el texto de una presentación en un sitio web, puede que desee conservar el énfasis local sin trasladar la fuente, el tamaño o los estilos del cuadro de texto de la presentación. Establezca [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) para controlar hasta dónde sigue el exportador la herencia del formato.

Descargue [la presentación de ejemplo](text-inheritance.pptx) y colóquela en el directorio de trabajo de la aplicación. Su primera diapositiva contiene una sola forma de texto con el texto "Inherited text; explicit red 18pt". La entrada usa deliberadamente varios niveles de formato:

- El estilo de texto predeterminado de la presentación usa Calibri y un tamaño de 28 pt.
- El estilo de texto de primer nivel del marco de texto usa texto azul e itálica.
- El párrafo establece explícitamente texto en negrita.
- La segunda porción, "explicit red 18pt", establece explícitamente texto rojo y un tamaño de 18 pt.

El siguiente ejemplo completo exporta los mismos párrafos tres veces. Pasa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) al método de exportación y escribe cada resultado como un archivo HTML UTF‑8 separado:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

El HTML generado contiene el siguiente CSS para la primera porción, "Inherited text; ". La tabla enumera las declaraciones relevantes; otras propiedades generadas se omiten por claridad.

| Salida | CSS relevante para la primera porción | Apariencia |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, negrita, cursiva a 28 pt en Calibri, si esa fuente está disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, negrita, cursiva; la página o el navegador suministran la familia de fuentes y el tamaño. |
| `ParagraphOnly.html` | `font-weight:bold` | Texto en negrita; la página o el navegador suministran la familia de fuentes, el tamaño, el color y el estilo cursiva. |

La segunda porción conserva `color:#ff0000`, `font-size:18pt` y `font-weight:bold` en los tres resultados. También conserva la cursiva en `ALL` y `TEXT_BOX`, pero no en `PARAGRAPH_ONLY`. Restringir la herencia, por tanto, no elimina el formato asignado explícitamente a un párrafo o porción.

Abra los archivos en el mismo navegador para compararlos. En los dos modos restringidos, las propiedades CSS omitidas se resuelven mediante los estilos de la página de destino o los valores predeterminados del navegador, por lo que la apariencia resultante depende del entorno donde se utilice el HTML.

### **Renderizar un párrafo como imagen**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). No es necesario renderizar la forma contenedora ni recortar manualmente un mapa de bits.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) puede devolver `None` si el párrafo no se encuentra en su colección principal, no tiene límites de renderizado válidos o no puede renderizarse. Verifique el resultado antes de guardarlo y libere la imagen devuelta después de usarla.

#### **Renderizar un párrafo a escala predeterminada**

El ejemplo usa `sample.pptx`, una presentación con una diapositiva cuya primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo selecciona el segundo párrafo en el índice 1 y llama a [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) sin parámetros de escala. Verifica que la forma contiene el párrafo requerido y que el renderizado devuelve una imagen antes de invocar [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) para guardarla en formato PNG. El gestor de contexto libera los recursos de la imagen tras su uso.

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

![La imagen del párrafo](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escalado**

Use la sobrecarga de [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) que acepta los parámetros `scale_x` y `scale_y` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda a doble anchura y altura respecto al valor predeterminado y guarda el resultado como una imagen PNG.

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

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones predeterminadas, lo que genera cuatro veces más píxeles. Los factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, aunque también aumentan el uso de memoria y el tamaño del archivo. Los factores inferiores a `1` producen imágenes más pequeñas con menos detalle. Use factores iguales para conservar la relación de aspecto del párrafo; los factores diferentes en horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) sigue siendo útil cuando la salida debe incluir el relleno, el borde o cualquier otro contexto visual de la forma. Para una imagen exclusivamente del párrafo, use [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) para desactivar el ajuste y que las líneas no se partan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo concreto?**

Utilice [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) para obtener el rectángulo delimitador del párrafo. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de las porciones individuales.

Para alinear verticalmente porciones de diferentes tamaños de fuente dentro de cada línea, consulte [Align Fonts Within a Line](/slides/es/python-net/text-formatting/#align-fonts-within-a-line).

**¿Puedo establecer el idioma de revisión para una parte del párrafo?**

Sí. Establezca [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.