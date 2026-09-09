---
title: Formatear texto de presentación en Python mediante Java
linktitle: Formato de texto
type: docs
weight: 50
url: /es/python-java/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia del texto
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
- Java
- Aspose.Slides
description: "Da formato y estilo al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python mediante Java. Personaliza fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python mediante Java. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje de texto, tabulaciones y configuración de idioma.

En los ejemplos a continuación, utilizaremos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente contenido:

![Texto de muestra](sample_text.png)

Para encontrar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y reemplazar texto](/slides/es/python-java/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para establecer el color de resaltado predeterminado de un párrafo, o [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/) para porciones de texto individuales.

El siguiente ejemplo de código muestra cómo establecer el color de fondo para el **párrafo completo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Establecer el color de resaltado para todo el párrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El ejemplo de código a continuación demuestra cómo establecer el color de fondo para **porciones de texto con fuente en negrita**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Establecer el color de resaltado para la porción de texto.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las porciones de texto gris](gray_text_portions.png)

## **Alinear párrafos de texto**

Utilice [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setAlignment) para definir la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Establecer la alineación del párrafo al centro.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/). En los ejemplos siguientes, `alpha = 50` es un valor de canal alfa ARGB en la escala 0‑255, no un porcentaje de transparencia.

El ejemplo de código a continuación muestra cómo aplicar transparencia al **párrafo completo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Establecer el color de relleno del texto a un color transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con fuente en negrita**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Establecer la transparencia de la porción de texto.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las porciones de texto transparentes](transparent_text_portions.png)

## **Establecer espaciado de caracteres para el texto**

Utilice [PortionFormat.setSpacing](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/) para ampliar o condensar el espacio entre caracteres en un cuadro de texto.

El siguiente código Python muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nota: Use valores negativos para comprimir el espaciado de caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Expandir el espaciado de caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El ejemplo de código a continuación muestra cómo ampliar el espaciado de caracteres en **porciones de texto con fuente en negrita**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Nota: Use valores negativos para comprimir el espaciado de caracteres.
            portion.getPortionFormat().setSpacing(3) # Expandir el espaciado de caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El espaciado de caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar el kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información válida de kerning y el kerning está activado en la configuración de PowerPoint.

Para que la salida renderizada se aproxime a PowerPoint en dichos casos, puede desactivar el kerning para las porciones de texto que utilizan la fuente afectada. Establezca [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/) a un valor significativamente mayor que el tamaño real de la fuente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Esta configuración impide que se aplique kerning a las porciones de texto coincidentes y puede ayudar a alinear la renderización de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Administrar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/).

El siguiente código establece la fuente y el estilo de texto para todo el párrafo: aplica tamaño de fuente, negrita, cursiva, subrayado punteado y la fuente Times New Roman a todas las porciones del párrafo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Establecer las propiedades de fuente del párrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El ejemplo de código a continuación aplica propiedades similares a **porciones de texto con fuente en negrita**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Establecer las propiedades de fuente para la porción de texto.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Establecer rotación del texto**

Utilice [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setTextVerticalType) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a `Vertical270`, que rota el texto **90 grados en sentido antihorario**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Establecer rotación personalizada para marcos de texto**

Utilice [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setRotationAngle) para definir un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).

El ejemplo de código a continuación rota el marco de texto 3 grados en sentido horario dentro de la forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Rotación personalizada del texto](custom_text_rotation.png)

## **Establecer espaciado entre líneas de los párrafos**

Aspose.Slides ofrece [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setSpaceBefore) y [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar el espaciado de los párrafos. Estas propiedades se utilizan de la siguiente manera:

* Use un valor positivo para especificar el espaciado como porcentaje de la altura de línea.
* Use un valor negativo para especificar el espaciado en puntos.

El siguiente ejemplo de código muestra cómo especificar el espaciado entre líneas dentro del párrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El espaciado entre líneas dentro del párrafo](line_spacing.png)

## **Establecer tipo de ajuste automático para marcos de texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, se desborda o redimensiona automáticamente la forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer anclaje de los marcos de texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAnchoringType) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo en la parte superior, central o inferior.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer tabulación del texto**

Utilice [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) y [ParagraphFormat.getTabs](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#getTabs) para configurar las tabulaciones en un párrafo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las tabulaciones del párrafo](paragraph_tabs.png)

## **Establecer idioma de revisión**

Aspose.Slides proporciona [PortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/), que permite establecer el idioma de revisión para una porción de texto. El idioma de revisión determina el idioma utilizado para la corrección ortográfica y gramatical en PowerPoint.

El siguiente ejemplo de código muestra cómo establecer el idioma de revisión para una porción de texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Establecer el Id de un idioma de revisión.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer idioma predeterminado**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir el idioma predeterminado del texto creado al cargar o crear una presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma rectangular con texto.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Comprobar el idioma de la primera porción.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Establecer estilo de texto predeterminado**

Para aplicar formato de texto predeterminado a nivel de presentación, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDefaultTextStyle).

El siguiente ejemplo de código muestra cómo establecer una fuente en negrita de 14 pt como predeterminada para todo el texto en todas las diapositivas de una nueva presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtener el formato del párrafo de nivel superior.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **Todas en mayúsculas** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando se recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se introdujo. Para que coincida con el texto mostrado, consulte [TextCapType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![El efecto Todas en mayúsculas](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **Todas en mayúsculas** aplicado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Salida:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Preguntas más frecuentes**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, use [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/). Recorra las celdas y actualice cada celda mediante [Cell.getTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/cell/#getTextFrame) y el formato del párrafo mediante [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#getParagraphFormat).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [PortionFormat.getFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/). Establezca [FillFormat.setFillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#setFillType) a [FillType.Gradient](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/#Gradient) y configure las paradas del degradado, la dirección y la transparencia.