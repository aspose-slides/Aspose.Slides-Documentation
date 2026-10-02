---
title: Formato de texto de presentación en Python
linktitle: Formato de texto
type: docs
weight: 50
url: /es/python-net/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuente
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad de ajuste automático
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Formatee y estilice el texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python mediante .NET. Personalice fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python mediante .NET. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuentes, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje de texto, tabulaciones y configuraciones de idioma.

A menos que se indique lo contrario, los ejemplos utilizan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma son basados en cero. Los ejemplos que seleccionan porciones en negrita usan formato efectivo, incluido el formato de negrita heredado:

![Texto de ejemplo](sample_text.png)

Para buscar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y reemplazar texto](/slides/es/python-net/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) para establecer el color de resaltado predeterminado para un párrafo, o utilice [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) para porciones de texto individuales.

El siguiente ejemplo establece un resaltado gris claro como predeterminado para el primer párrafo. Los colores de resaltado explícitos en porciones individuales tienen prioridad sobre este valor predeterminado:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer el color de resaltado para todo el párrafo.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El siguiente ejemplo de código muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Establecer el color de resaltado para la porción de texto.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las porciones de texto gris](gray_text_portions.png)

## **Alinear párrafos de texto**

Utilice [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) para establecer la alineación de párrafos dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer la alineación del párrafo al centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Alinear fuentes dentro de una línea**

Utilice [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) para alinear verticalmente las porciones de texto de diferentes tamaños de fuente dentro de una línea. Esta configuración se aplica a todo el párrafo y controla la alineación dentro de cada una de sus líneas.

El siguiente ejemplo independiente crea cuatro cuadros de texto etiquetados en una diapositiva. Cada párrafo contiene el mismo texto en tamaños de 18, 36 y 54 puntos, con una alineación de fuente diferente. Utiliza Arial, deshabilita el ajuste automático y el ajuste de línea, y mantiene los marcos de texto lo suficientemente grandes para una sola línea.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Comparación de la alineación de fuentes Baseline, Top, Center y Bottom con tamaños de fuente mixtos](font_alignment.png)

La alineación de fuentes utiliza métricas tipográficas, por lo que los bordes visibles de las letras individuales no siempre se alinean exactamente. El ejemplo incluye tanto una letra mayúscula como un descendente para ayudar a mostrar la diferencia entre la alineación de línea base y la alineación inferior. La disponibilidad y sustitución de fuentes, los caracteres utilizados y la diferencia de tamaños de fuente afectan el resultado. Las dimensiones del marco, los márgenes, el interlineado, el ajuste de línea y el ajuste automático también influyen en el diseño; utilice las mismas fuentes y configuraciones de diseño al comparar los modos.

Esta configuración difiere de [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), que controla la alineación horizontal del párrafo, y de [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), que posiciona el bloque de texto verticalmente dentro de su forma. El formato de superíndice y subíndice a través de [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) desplaza porciones individuales respecto a la línea base en lugar de establecer la alineación de fuente para las líneas del párrafo.

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). En los ejemplos siguientes, `alpha = 50` es un valor de canal alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer un relleno negro semitransparente para el texto.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Establecer la transparencia de la porción de texto.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las porciones de texto transparentes](transparent_text_portions.png)

## **Establecer espaciado de caracteres para el texto**

Utilice [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) para ampliar o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

El siguiente código Python muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nota: Use valores negativos para comprimir el espaciado de caracteres.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Expandir espaciado de caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El siguiente ejemplo de código muestra cómo ampliar el espaciado de caracteres en **porciones de texto con una fuente en negrita**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nota: Use valores negativos para comprimir el espaciado de caracteres.
            portion.portion_format.spacing = 3  # Expandir espaciado de caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El espaciado de caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar el kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede suceder porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para acercar la salida renderizada a la de PowerPoint en dichos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere “presentation.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Verifica los nombres de fuentes efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Para el texto coincidente por debajo del umbral, esta configuración evita el kerning y puede ayudar a alinear la renderización de Aspose.Slides con la salida visual de PowerPoint para las fuentes afectadas por este comportamiento específico de PowerPoint.

## **Gestionar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo a Times New Roman de 12 puntos con formato en negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer las propiedades de fuente para el párrafo.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El siguiente ejemplo aplica Times New Roman de 13 puntos, formato cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Establecer las propiedades de fuente para la porción de texto.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Establecer rotación del texto**

Utilice [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), que rota el texto **90 grados en sentido antihorario**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Establecer rotación personalizada para marcos de texto**

Utilice [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) para establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

El siguiente ejemplo de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La rotación personalizada del texto](custom_text_rotation.png)

## **Establecer interlineado de los párrafos**

Aspose.Slides ofrece [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) y [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) para controlar el espaciado de párrafos. Estas propiedades se utilizan de la siguiente manera:

* Use un valor positivo para especificar el interlineado como porcentaje de la altura de la línea.
* Use un valor negativo para especificar el interlineado en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo al 200 % de la altura de la línea (doble espacio):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El interlineado dentro del párrafo](line_spacing.png)

## **Controlar el salto de línea**

Las reglas de salto de línea de los párrafos son útiles en bloques de texto estrechos y presentaciones que mezclan texto latino y asiático oriental. Las siguientes propiedades pertenecen a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), por lo que se aplican a un párrafo completo:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) controla las reglas de salto de línea latinas. En texto mixto, cambiarlo también puede cambiar dónde se envuelven el texto asiático oriental adyacente y la puntuación.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) controla las reglas de salto de línea del asiático oriental, incluidas las restricciones sobre los caracteres al comienzo y al final de una línea.

Estas reglas no sustituyen a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando ocurre el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo independiente crea un bloque de texto estrecho que contiene texto chino y latino. Establece ambas propiedades de salto de línea de forma explícita y guarda “line_breaking.pptx”. Para experimentar con cualquiera de las reglas, cambie el valor de esa propiedad manteniendo los demás ajustes fijos. El ejemplo utiliza Arial de 24 puntos y SimSun con un ancho de marco de 160 puntos y márgenes horizontales del marco en cero. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) se establece en [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar puntuación colgante**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo independiente habilita la puntuación colgante en un marco de texto de 100 puntos de ancho y guarda “hanging_punctuation.pptx”. Con Arial de 24 puntos y márgenes horizontales del marco en cero, el punto final permanece después de “sentence” y se extiende más allá del borde derecho del texto. Establezca la propiedad a [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) para comparar: con estos ajustes, el punto ocupa una línea separada. El ajuste de línea está habilitado y el ajuste automático deshabilitado para mantener el ancho disponible fijo.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

No todos los signos de puntuación pueden colgar. El resultado visible depende de las [condiciones de fuente y diseño](#control-line-breaking): cambiar la fuente, el ancho disponible, los márgenes o los ajustes de ajuste automático puede eliminar la diferencia visible.

## **Establecer tipo de ajuste automático para marcos de texto**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) determina cómo se comporta el texto cuando excede los límites de su contenedor. Úselo para controlar si el texto se reduce, desborda o redimensiona la forma automáticamente. El siguiente ejemplo configura la forma para redimensionarse y ajustarse al texto y guarda el resultado en “autofit_type.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Para contar líneas después del ajuste automático y ver cómo cambia el resultado al modificar el ancho del texto o de la forma, consulte [Contar líneas renderizadas](/slides/es/python-net/manage-paragraph/). El número de líneas por sí solo no indica si el texto se desborda de su contenedor.

## **Establecer ancla de los marcos de texto**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, media o inferior. El siguiente ejemplo ancla el texto en la parte inferior de la primera forma y guarda el resultado en “text_anchor.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer tabulación del texto**

Utilice [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) y [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) para configurar las tabulaciones en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado a 100 puntos y añade una tabulación alineada a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las tabulaciones del párrafo](paragraph_tabs.png)

## **Establecer idioma de revisión**

Aspose.Slides proporciona [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), que permite establecer el idioma de revisión para una porción de texto. El idioma de revisión determina el idioma utilizado para la corrección ortográfica y gramatical en PowerPoint.

El siguiente ejemplo requiere “presentation.pptx” con un cuadro de texto como primera forma en la primera diapositiva y al menos un párrafo. Reemplaza el contenido del primer párrafo por “1。”, establece SimSun como su fuente y asigna el idioma de revisión chino simplificado (`zh-CN`). Guarda el resultado en “proofing_language.pptx”:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Establecer el idioma de revisión a chino simplificado.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer idioma predeterminado**

Utilice [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) para definir el idioma predeterminado del texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés de EE. UU. como idioma de texto predeterminado, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Añadir una nueva forma rectangular con texto.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Comprobar el idioma de la primera porción.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Establecer estilo de texto predeterminado**

Para aplicar formato de texto predeterminado a nivel de presentación, utilice [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminada para los párrafos de nivel superior en una nueva presentación y lo guarda en “default_text_style.pptx”. El texto puede heredar estos valores predeterminados a menos que un formato más específico los sobrescriba.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtener el formato de párrafo de nivel superior.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer texto con el efecto Todo en mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `ALL`.

El ejemplo requiere “sample2.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Su primer párrafo contiene “Hello, Aspose!” con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto Todo en mayúsculas](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **Preguntas frecuentes**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla en una diapositiva, use [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Itera a través de las celdas y actualiza cada celda mediante [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) y el formato de párrafo mediante [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Establezca [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) a [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) y configure las paradas de degradado, la dirección y la transparencia.