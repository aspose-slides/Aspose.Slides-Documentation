---
title: Formato de texto de la presentación en Python
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
- anclaje del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Formatea y da estilo al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET. Personaliza fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides for Python a través de .NET. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje del texto, tabulaciones y configuraciones de idioma.

En los ejemplos a continuación, utilizaremos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

Para buscar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y reemplazar texto](/slides/es/python-net/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/default_portion_format/) para establecer el color de resaltado predeterminado para un párrafo, o use [PortionFormat.highlight_color](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/highlight_color/) para porciones de texto individuales.

El siguiente ejemplo de código muestra cómo establecer el color de fondo para el **párrafo completo**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer el color de resaltado para todo el párrafo.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El ejemplo de código a continuación demuestra cómo establecer el color de fondo para **porciones de texto con fuente en negrita**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

Utilice [ParagraphFormat.alignment](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/alignment/) para establecer la alineación del párrafo dentro de un cuadro de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer la alineación del párrafo al centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [PortionFormat.fill_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/fill_format/). En los ejemplos a continuación, `alpha = 50` es un valor de canal alfa ARGB en la escala 0‑255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer el color de relleno del texto a un color transparente.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con fuente en negrita**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

Utilice [BasePortionFormat.spacing](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/spacing/) para ampliar o condensar el espaciado entre caracteres en un cuadro de texto.

El siguiente código Python muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nota: Use valores negativos para comprimir el espaciado de caracteres.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Expandir espaciado de caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El ejemplo de código a continuación muestra cómo ampliar el espaciado de caracteres en **porciones de texto con fuente en negrita**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más ajustado que el mismo texto que se muestra en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para que la salida renderizada sea más cercana a PowerPoint en esos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) a un valor significativamente mayor que el tamaño real de la fuente:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Esta configuración impide que se aplique kerning a las porciones de texto coincidentes y puede ayudar a alinear el renderizado de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Administrar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/default_portion_format/) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/).

El siguiente código establece la fuente y el estilo de texto para todo el párrafo: aplica tamaño de fuente, negrita, cursiva, subrayado punteado y la fuente Times New Roman a todas las porciones del párrafo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Establecer las propiedades de fuente del párrafo.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El ejemplo de código a continuación aplica propiedades similares a **porciones de texto con fuente en negrita**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Establecer las propiedades de fuente de la porción de texto.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Establecer rotación del texto**

Utilice [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/text_vertical_type/) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a `VERTICAL270`, lo que rota el texto **90 grados en sentido antihorario**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Establecer rotación personalizada para cuadros de texto**

Utilice [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/rotation_angle/) para establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/).

El ejemplo de código a continuación rota el cuadro de texto 3 grados en sentido horario dentro de la forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![La rotación de texto personalizada](custom_text_rotation.png)

## **Establecer espaciado de línea de los párrafos**

Aspose.Slides proporciona [ParagraphFormat.space_after](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/space_before/) y [ParagraphFormat.space_within](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/space_within/) para controlar el espaciado de párrafo. Estas propiedades se usan de la siguiente manera:

* Use un valor positivo para especificar el espaciado de línea como porcentaje de la altura de la línea.
* Use un valor negativo para especificar el espaciado de línea en puntos.

El siguiente ejemplo de código muestra cómo especificar el espaciado de línea dentro del párrafo:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![El espaciado de línea dentro del párrafo](line_spacing.png)

## **Establecer tipo de ajuste automático para cuadros de texto**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/autofit_type/) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, desborda o redimensiona la forma automáticamente.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer anclaje de los cuadros de texto**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/anchoring_type/) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo en la parte superior, intermedia o inferior.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer tabulación del texto**

Utilice [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/default_tab_size/) y [ParagraphFormat.tabs](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/tabs/) para configurar las tabulaciones en un párrafo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Las tabulaciones del párrafo](paragraph_tabs.png)

## **Establecer idioma de revisión**

Aspose.Slides proporciona [PortionFormat.language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/language_id/), que permite establecer el idioma de revisión para una porción de texto. El idioma de revisión determina el idioma utilizado para la revisión ortográfica y gramatical en PowerPoint.

El siguiente ejemplo de código muestra cómo establecer el idioma de revisión para una porción de texto:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Establecer el Id de un idioma de revisión.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer idioma predeterminado**

Utilice [LoadOptions.default_text_language](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/default_text_language/) para definir el idioma predeterminado para el texto creado al cargar o crear una presentación.

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

Para aplicar formato de texto predeterminado a nivel de presentación, utilice [Presentation.default_text_style](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/default_text_style/).

El siguiente ejemplo de código muestra cómo establecer una fuente en negrita predeterminada con un tamaño de 14 pt para todo el texto en todas las diapositivas de una nueva presentación.

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

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **Mayúsculas** hace que el texto aparezca en mayúsculas en la diapositiva aunque se haya escrito originalmente en minúsculas. Cuando recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/es/python-net/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `ALL`.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![El efecto de mayúsculas](all_caps_effect.png)

El ejemplo de código a continuación muestra cómo extraer el texto con el efecto **Mayúsculas** aplicado:

```python
import aspose.slides as slides

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

## **FAQ**

**¿Cómo modificar el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, use [Table](https://reference.aspose.com/slides/es/python-net/aspose.slides/table/). Recorra las celdas y actualice cada celda mediante [Cell.text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/cell/text_frame/) y el formato de párrafo mediante [Paragraph.paragraph_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/paragraph_format/).

**¿Cómo aplicar un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [PortionFormat.fill_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/portionformat/fill_format/). Establezca [FillFormat.fill_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/fillformat/fill_type/) a [FillType.GRADIENT](https://reference.aspose.com/slides/es/python-net/aspose.slides/filltype/) y configure las paradas de degradado, la dirección y la transparencia.