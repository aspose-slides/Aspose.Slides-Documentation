---
title: Formatear texto de presentación en Python vía Java
linktitle: Formato de texto
type: docs
weight: 50
url: /es/python-java/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia del texto
- espaciado entre caracteres
- propiedades de fuente
- familia tipográfica
- rotación del texto
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
description: "Formatear y dar estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python vía Java. Personalizar fuentes, colores, alineación y más."
---
## **Descripción general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para Python a través de Java. Cubre colores de fondo, transparencia, espaciado entre caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclado de texto, tabulaciones y configuraciones de idioma.

A menos que se indique lo contrario, los ejemplos usan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma son basados en cero. Los ejemplos que seleccionan porciones en negrita usan formato efectivo, incluido el formato en negrita heredado:

![Texto de ejemplo](sample_text.png)

Para encontrar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y reemplazar texto](/slides/es/python-java/search-and-replace-text/).

## **Establecer color de fondo del texto**

Use [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para establecer el color de resaltado predeterminado para un párrafo, o use [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) para porciones de texto individuales.

El siguiente ejemplo establece un resaltado gris claro como predeterminado para el primer párrafo. Los colores de resaltado explícitos en porciones individuales tienen prioridad sobre este predeterminado:

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

El siguiente ejemplo de código muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

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

Use [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

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

## **Alinear fuentes dentro de una línea**

Use [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) para alinear verticalmente porciones de texto con diferentes tamaños de fuente dentro de una línea. Esta configuración se aplica a todo el párrafo y controla la alineación dentro de cada una de sus líneas.

El siguiente ejemplo autodirigido crea cuatro cuadros de texto etiquetados en una diapositiva. Cada párrafo contiene el mismo texto a 18, 36 y 54 puntos, con una alineación de fuente diferente. Utiliza Arial, desactiva el ajuste automático y el ajuste de línea, y mantiene los marcos de texto lo suficientemente grandes para una sola línea.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Comparación de alineación de línea base, superior, central y inferior con tamaños de fuente mixtos](font_alignment.png)

La alineación de fuente utiliza métricas tipográficas, por lo que los bordes visibles de las letras individuales no necesariamente se alinean exactamente. El ejemplo incluye una letra mayúscula y un descendente para ayudar a mostrar la diferencia entre la alineación de línea base y la inferior. La disponibilidad y sustitución de fuentes, los caracteres usados y la diferencia de tamaños de fuente influyen en el resultado. Las dimensiones del marco, los márgenes, el interlineado, el ajuste de línea y el ajuste automático también afectan al diseño; utilice las mismas fuentes y configuraciones de diseño al comparar modos.

Esta configuración difiere de [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), que controla la alineación horizontal del párrafo, y de [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), que posiciona el bloque de texto verticalmente dentro de su forma. El formato de superíndice y subíndice mediante [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) desplaza porciones individuales respecto a la línea base en lugar de establecer la alineación de fuente para las líneas del párrafo.

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). En los ejemplos siguientes, `alpha = 50` es un valor de canal alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

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

    # Establecer el color de relleno del texto a color transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:

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

## **Establecer espaciado entre caracteres para el texto**

Use [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) para expandir o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

El siguiente código Python muestra cómo expandir el espaciado entre caracteres en el **párrafo completo**:

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

    # Nota: Use valores negativos para comprimir el espaciado entre caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Expandir el espaciado entre caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El espaciado entre caracteres en el párrafo](character_spacing_in_paragraph.png)

El siguiente ejemplo de código muestra cómo expandir el espaciado entre caracteres en **porciones de texto con una fuente en negrita**:

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
            # Nota: Use valores negativos para comprimir el espaciado entre caracteres.
            portion.getPortionFormat().setSpacing(3) # Expandir el espaciado entre caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![El espaciado entre caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se acerque más a PowerPoint en esos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Comprueba los nombres de fuentes efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

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
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para el texto coincidente por debajo del umbral, esta configuración evita el kerning y puede ayudar a que el renderizado de Aspose.Slides coincida con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Gestionar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo en Times New Roman de 12 puntos con formato en negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados.

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

El siguiente ejemplo aplica Times New Roman de 13 puntos, formato cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

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

## **Controlar normalización de altura del texto**

Use [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) al reproducir tipografía de plantilla o investigar diferencias en la altura de los caracteres. En PowerPoint, habilitar la normalización estira o comprime verticalmente los caracteres individuales para darles una altura visible uniforme dentro de la porción de texto. No garantiza alturas iguales entre diferentes fuentes.

Establezca la propiedad a [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) para habilitar o deshabilitar explícitamente la normalización. `NullableBool.NotDefined` deja la configuración local sin definir, de modo que la porción hereda su valor, por ejemplo, del [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) del párrafo. No equivale a `False`. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) y lea `getNormaliseHeight` en el formato efectivo devuelto para obtener el valor booleano resuelto.

El siguiente ejemplo autodirigido requiere **Arial** instalado. Crea dos bloques de texto que contienen las mismas letras mayúsculas, minúsculas, descendentes y caracteres acentuados a 54 puntos. Ambos párrafos habilitan la normalización por defecto. La porción superior la deshabilita explícitamente; la inferior la hereda. Los tamaños del marco, los márgenes y el espaciado de párrafos son idénticos, con el ajuste de línea y el autofit desactivados para mantener la comparación consistente. El ejemplo imprime `False: False` y `NotDefined: True`, luego guarda "text_height_normalization.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparación a continuación se exportó de la presentación guardada. La fila superior tiene la normalización desactivada (`False`); la fila inferior la hereda (`NotDefined` → `True`). Mantenga Arial instalado para reproducir esta apariencia.

![Texto Arial de 54 puntos con normalización desactivada arriba y normalización heredada activada abajo](text_height_normalization.png)

La normalización cambia la altura del carácter sin cambiar el valor asignado de [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), que especifica el tamaño de fuente en puntos. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) controla el interlineado, mientras que [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) controla cómo el texto o su contenedor se ajustan. Estas configuraciones sirven a propósitos diferentes y pueden afectar el diseño general de forma independiente. Para más información sobre formato de párrafo e herencia, consulte [Gestionar párrafo](/slides/es/python-java/manage-paragraph/).

## **Aplicar y eliminar tachado**

Use [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) en una porción de texto para mostrar correcciones, términos cancelados o precios anteriores sin eliminar el texto original. Establézcalo en [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) para una o dos líneas a través del texto.

Para eliminar el tachado, pase [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Esto desactiva explícitamente el efecto, incluso si el formato circundante especifica tachado. Por el contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) deja la configuración local sin definir, permitiendo que la porción herede el formato, por ejemplo, del párrafo. No garantiza que el tachado se elimine. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) para leer el formato resultante, incluidos los valores heredados.

El siguiente ejemplo autodirigido crea tres comparaciones de precios. Cada párrafo tiene porciones separadas para la etiqueta, el precio anterior y el precio actual, de modo que solo el precio anterior se ve afectado. La primera fila aplica y luego elimina el tachado; las demás filas conservan tachado simple y doble. Cambiar esta configuración preserva el texto y su resto de formato, incluida la negrita del precio anterior.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Aplicar tachado, luego eliminarlo explícitamente del primer precio anterior.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado, de arriba a abajo: sin tachado, tachado simple y tachado doble.

![Precios anteriores sin tachado, con tachado simple y con tachado doble](strikethrough.png)

## **Establecer rotación del texto**

Use [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), que gira el texto **90 grados en sentido antihorario**:

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

## **Mostrar dígitos uno al lado del otro en texto vertical**

Para mantener los dígitos de un número de dos cifras uno al lado del otro en una etiqueta vertical japonesa, coloque ambos dígitos en una sola porción de texto y llame a [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) sobre esa porción. Ambas etiquetas en este ejemplo usan [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) y MS Gothic de 40 puntos. Solo la configuración de [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) para los dígitos difiere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En PowerPoint, la etiqueta izquierda (`True`) muestra los dígitos en posición vertical y uno al lado del otro entre 和 y 年. En la etiqueta derecha (`False`), el par está girado 90 grados en sentido horario. Los caracteres japoneses circundantes permanecen verticales en ambas etiquetas.

![Comparación en PowerPoint de etiquetas de fecha vertical con dígitos verticales a la izquierda y dígitos girados a la derecha.](vertical_date.png)

## **Establecer rotación personalizada para marcos de texto**

Use [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) para establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

El siguiente ejemplo de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

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

![La rotación personalizada del texto](custom_text_rotation.png)

## **Establecer interlineado de párrafos**

Aspose.Slides proporciona [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) y [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar el espaciado de párrafos. Estas propiedades se usan de la siguiente manera:

* Use un valor positivo para especificar el interlineado como porcentaje de la altura de línea.
* Use un valor negativo para especificar el interlineado en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo en el 200 % de la altura de línea (doble espacio):

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

![El interlineado dentro del párrafo](line_spacing.png)

## **Controlar salto de línea**

Las reglas de salto de línea de párrafo son útiles en bloques de texto estrechos y presentaciones que combinan texto latino y de Asia Oriental. Los siguientes métodos pertenecen a [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), por lo que se aplican a un párrafo completo:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) controla las reglas de salto de línea latinas. En texto mixto, cambiarlo también puede cambiar dónde se ajusta el texto y la puntuación asiática adyacente.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controla las reglas de salto de línea de Asia Oriental, incluidas las restricciones de caracteres al principio y al final de una línea.

Estas reglas no reemplazan [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando ocurre el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo autodirigido crea un bloque de texto estrecho que contiene chino y texto latino. Establece ambas opciones de salto de línea explícitamente y guarda "line_breaking.pptx". Para experimentar con cualquiera de las reglas, cambie el valor correspondiente manteniendo la otra configuración fija. El ejemplo usa Arial de 24 puntos y SimSun con un ancho de marco de 160 puntos y márgenes horizontales del marco de texto en cero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) se llama con [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar puntuación colgante**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo autodirigido habilita la puntuación colgante en un marco de texto de 100 puntos de ancho y guarda "hanging_punctuation.pptx". Con Arial de 24 puntos y márgenes horizontales del marco de texto en cero, el punto final final permanece después de "sentence" y se extiende más allá del borde derecho del texto. Establezca la propiedad a [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) para comparar: con esta configuración, el punto ocupa una línea separada. El ajuste de línea está habilitado y el autofit está desactivado para mantener el ancho disponible fijo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

No todos los signos de puntuación pueden colgar. Las [condiciones de fuente y diseño descritas arriba](#control-line-breaking) también se aplican a esta comparación: cambiar la fuente, el ancho disponible, los márgenes o la configuración de autofit puede eliminar la diferencia visible.

## **Establecer tipo de ajuste automático para marcos de texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, se desborda o redimensiona la forma automáticamente. El siguiente ejemplo configura la forma para redimensionarse y ajustarse al texto y guarda el resultado en "autofit_type.pptx".

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

Para contar líneas después del ajuste automático y ver cómo cambia el texto o el ancho de la forma, consulte [Count Rendered Lines](/slides/es/python-java/manage-paragraph/). El recuento de líneas solo no indica si el texto se desborda de su contenedor.

## **Establecer anclaje de marcos de texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, intermedia o inferior. El siguiente ejemplo ancla el texto en la parte inferior de la primera forma y guarda el resultado en "text_anchor.pptx".

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

## **Establecer tabulación de texto**

Use [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) y [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) para configurar las tabulaciones en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado en 100 puntos y añade una tabulación alineada a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

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

Aspose.Slides proporciona [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), que permite establecer el idioma de revisión para una porción de texto. El idioma de revisión determina el idioma usado para la corrección ortográfica y gramatical en PowerPoint.

El siguiente ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva y al menos un párrafo. Reemplaza el contenido del primer párrafo con "1。", establece SimSun como su fuente y asigna el idioma de revisión chino simplificado (`zh-CN`). Guarda el resultado en "proofing_language.pptx":

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

### **Copiar metadatos de idioma**

Al copiar texto multilingüe desde una plantilla, conserve tanto [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) como [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). El siguiente ejemplo autodirigido crea una porción de origen con inglés de EE. UU como idioma y francés como idioma alternativo y copia el texto y los identificadores a una porción en una nueva presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Si el origen no tiene idioma alternativo, None borra el valor del destino.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para probar una fuente sin idioma alternativo, omita la asignación de `"fr-FR"`. El identificador alternativo será entonces `None`, y la misma instrucción de copia preserva su ausencia sin introducir un valor predeterminado, incluso si el destino tenía previamente un idioma alternativo asignado.

Estos identificadores almacenan metadatos de idioma. Preservarlos no establece qué diccionario selecciona PowerPoint para la corrección ortográfica o gramatical.

## **Establecer idioma predeterminado**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir el idioma predeterminado para el texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés de EE. UU como idioma de texto predeterminado, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

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

Para aplicar formato de texto predeterminado a nivel de presentación, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminada para los párrafos de nivel superior en una nueva presentación y lo guarda en "default_text_style.pptx". El texto puede heredar estos valores predeterminados a menos que un formato más específico los sobrescriba.

```python
import jpoute
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtener el formato de párrafo de nivel superior.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque se haya escrito originalmente en minúsculas. Cuando recupera esa porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se ingresó. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere "sample2.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Su primer párrafo contiene "Hello, Aspose!" con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto All Caps](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:

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

## **FAQ**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, use [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Iterate through the cells and update each cell through [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) and paragraph formatting through [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Set [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) to [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) y configure las paradas del degradado, la dirección y la transparencia.