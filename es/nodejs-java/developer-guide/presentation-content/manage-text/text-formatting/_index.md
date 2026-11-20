---
title: Formato de texto de presentación en JavaScript
linktitle: Formato de texto
type: docs
weight: 50
url: /es/nodejs-java/text-formatting/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatea y da estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Node.js a través de Java. Personaliza fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument mediante Aspose.Slides para Node.js a través de Java. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje de texto, tabulaciones y configuración de idioma.

A menos que se indique lo contrario, los ejemplos utilizan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma son basados en cero. Los ejemplos que seleccionan porciones en negrita usan formato efectivo, incluido el formato de negrita heredado:

![Texto de ejemplo](sample_text.png)

Para encontrar y resaltar texto literal o coincidencias de expresiones regulares, vea [Buscar y reemplazar texto](/slides/es/nodejs-java/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para establecer el color de resaltado predeterminado de un párrafo, o utilice [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) para porciones de texto individuales.

El siguiente ejemplo establece un resaltado gris claro como predeterminado para el primer párrafo. Los colores de resaltado explícitos en porciones individuales tienen prioridad sobre este predeterminado:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Establecer el color de resaltado para todo el párrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El siguiente ejemplo de código muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Establecer el color de resaltado para la porción de texto.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las porciones de texto gris](gray_text_portions.png)

## **Alinear párrafos de texto**

Utilice [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Establecer la alineación del párrafo al centro.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Alinear fuentes dentro de una línea**

Utilice [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) para alinear verticalmente porciones de texto con diferentes tamaños de fuente dentro de una línea. Esta configuración se aplica a todo el párrafo y controla la alineación dentro de cada una de sus líneas.

El siguiente ejemplo independiente crea cuatro cuadros de texto etiquetados en una diapositiva. Cada párrafo contiene el mismo texto a 18, 36 y 54 puntos, con una alineación de fuente diferente. Utiliza Arial, deshabilita el ajuste automático y el ajuste de línea, y mantiene los marcos de texto lo suficientemente grandes para una sola línea.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Comparación de alineación de fuente Baseline, Top, Center y Bottom con tamaños de fuente mixtos](font_alignment.png)

La alineación de fuentes utiliza métricas tipográficas, por lo que los bordes visibles de letras individuales no necesariamente se alinean exactamente. El ejemplo incluye una letra mayúscula y un descendente para ayudar a mostrar la diferencia entre alineación de línea base y alineación inferior. La disponibilidad y sustitución de fuentes, los caracteres utilizados y la diferencia en los tamaños de fuente afectan el resultado. Las dimensiones del marco, los márgenes, el interlineado, el ajuste de línea y el ajuste automático también influyen en el diseño; utilice las mismas fuentes y configuraciones de diseño al comparar modos.

Esta configuración difiere de [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), que controla la alineación horizontal del párrafo, y de [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), que posiciona el bloque de texto verticalmente dentro de su forma. El formato de superíndice y subíndice mediante [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) desplaza porciones individuales respecto a la línea base en lugar de establecer la alineación de fuente para las líneas del párrafo.

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). En los ejemplos a continuación, `alpha = 50` es un valor de canal alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Establecer el color de relleno del texto a color transparente.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Establecer la transparencia de la porción de texto.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las porciones de texto transparentes](transparent_text_portions.png)

## **Establecer espaciado de caracteres para el texto**

Utilice [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) para ampliar o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

El siguiente código JavaScript muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: Use valores negativos para comprimir el espaciado de caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Expandir el espaciado de caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El siguiente ejemplo de código muestra cómo ampliar el espaciado de caracteres en **porciones de texto con una fuente en negrita**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nota: Use valores negativos para comprimir el espaciado de caracteres.
            portion.getPortionFormat().setSpacing(3); // Expandir el espaciado de caracteres.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El espaciado de caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar el kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se acerque a PowerPoint en dichos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Comprueba los nombres de fuente efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para el texto coincidente por debajo del umbral, esta configuración evita el kerning y puede ayudar a alinear la representación de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Administrar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo a Times New Roman de 12 puntos con formato en negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Establecer las propiedades de fuente para el párrafo.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El siguiente ejemplo aplica Times New Roman de 13 puntos, formato cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Establecer las propiedades de fuente para la porción de texto.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Controlar la normalización de altura del texto**

Utilice [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) al reproducir tipografía de plantilla o investigar diferencias en la altura de los caracteres. En PowerPoint, habilitar la normalización estira o comprime verticalmente los caracteres individuales para otorgarles una altura visible uniforme dentro de la porción de texto. No garantiza alturas de texto iguales entre diferentes fuentes.

Establezca la propiedad a [NullableBool.True or False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) para habilitar o deshabilitar explícitamente la normalización. `NullableBool.NotDefined` deja la configuración local sin definir, de modo que la porción herede su valor, por ejemplo, del [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) del párrafo. No equivale a `False`. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) y lea [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) para obtener el valor booleano resuelto.

El siguiente ejemplo independiente requiere **Arial** instalado. Crea dos bloques de texto que contienen las mismas letras mayúsculas, minúsculas, descendentes y caracteres con acento a 54 puntos. Ambos párrafos habilitan la normalización por defecto. La porción superior la deshabilita explícitamente; la porción inferior la hereda. Los tamaños del marco, los márgenes y el espaciado de párrafo son idénticos, con ajuste de línea y ajuste automático desactivados para mantener la comparación coherente. El ejemplo imprime `False: false` y `NotDefined: true`, y luego guarda “text_height_normalization.pptx”.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación se exportó de la presentación guardada. La fila superior tiene la normalización desactivada (`False`); la fila inferior hereda la configuración activada (`NotDefined` → `True`). Mantenga Arial instalado para reproducir esta apariencia.

![Texto Arial de 54 puntos con normalización desactivada arriba y normalización heredada activada abajo](text_height_normalization.png)

La normalización cambia la altura de los caracteres sin modificar el valor asignado de [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), que especifica el tamaño de la fuente en puntos. El método de párrafo [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) controla el interlineado, mientras que [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) del marco de texto controla cómo el texto o su contenedor se ajusta automáticamente. Estas configuraciones sirven a propósitos diferentes y pueden afectar el diseño general de forma independiente. Para más información sobre formato de párrafo y herencia, vea [Administrar párrafo](/slides/es/nodejs-java/manage-paragraph/).

## **Aplicar y eliminar tachado**

Utilice [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) en una porción de texto para mostrar correcciones, términos cancelados o precios anteriores sin eliminar el texto original. Establézcalo en [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) para una o dos líneas a través del texto.

Para eliminar el tachado, pase [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Esto desactiva explícitamente el efecto, aun cuando el formato circundante especifique tachado. Por el contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) deja la configuración local sin definir, permitiendo que la porción herede el formato, por ejemplo, del párrafo. No garantiza que el tachado se elimine. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) para leer el formato resultante, incluidos los valores heredados.

El siguiente ejemplo independiente crea tres comparaciones de precios. Cada párrafo tiene porciones separadas para la etiqueta, el precio anterior y el precio actual, de modo que solo el precio anterior se ve afectado. La primera fila aplica y luego elimina el tachado; las demás filas conservan tachado simple y doble. Cambiar esta configuración preserva el texto y su resto de formato, incluida la negrita del precio anterior.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Aplicar tachado, luego eliminarlo explícitamente del primer precio anterior.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado, de arriba a abajo: sin tachado, tachado simple y tachado doble.

![Precios anteriores sin tachado, con tachado simple y con tachado doble](strikethrough.png)

## **Establecer rotación de texto**

Utilice [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), que rota el texto **90 grados en sentido antihorario**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Establecer rotación personalizada para marcos de texto**

Utilice [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) para establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

El siguiente ejemplo de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La rotación de texto personalizada](custom_text_rotation.png)

## **Establecer interlineado de párrafos**

Aspose.Slides proporciona [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) y [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar el espaciado de párrafos. Estas propiedades se usan de la siguiente manera:

* Use un valor positivo para especificar el interlineado como porcentaje de la altura de la línea.  
* Use un valor negativo para especificar el interlineado en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo al 200 % de la altura de la línea (doble espacio):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El interlineado dentro del párrafo](line_spacing.png)

## **Controlar la ruptura de línea**

Las reglas de ruptura de línea de los párrafos son útiles en bloques de texto estrechos y presentaciones que combinan texto latino y asiático oriental. Los siguientes métodos pertenecen a [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), por lo que se aplican a todo el párrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) controla las reglas de ruptura de línea latinas. En texto mixto, cambiarlo también puede cambiar dónde se envuelve el texto y la puntuación asiática adyacente.  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controla las reglas de ruptura de línea de Asia Oriental, incluidas restricciones de caracteres al principio y al final de una línea.

Estas reglas no sustituyen a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando se produce el ajuste, pero no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo independiente crea un bloque de texto estrecho que contiene chino y texto latino. Establece ambas opciones de ruptura de línea de forma explícita y guarda “line_breaking.pptx”. Para experimentar con cualquiera de las reglas, cambie el valor correspondiente manteniendo la otra configuración fija. El ejemplo usa Arial y SimSun de 24 puntos con un ancho de marco de 160 puntos y márgenes horizontales de marco de texto a cero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) se llama con [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar puntuación colgante**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la línea siguiente. Se aplica a todo el párrafo y difiere de una sangría colgante.

El siguiente ejemplo independiente habilita la puntuación colgante en un marco de texto de 100 puntos de ancho y guarda “hanging_punctuation.pptx”. Con Arial de 24 puntos y márgenes horizontales de marco de texto a cero, el punto final permanece después de “sentence” y se extiende más allá del borde derecho del texto. Establezca la propiedad a [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) para comparar: con esta configuración, el punto ocupa una línea separada. El ajuste de línea está habilitado y el ajuste automático está desactivado para mantener fijo el ancho disponible.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

No todas las marcas de puntuación pueden colgar. Las [condiciones de fuente y diseño descritas arriba](#control-line-breaking) también se aplican a esta comparación: cambiar la fuente, el ancho disponible, los márgenes o la configuración de ajuste automático puede eliminar la diferencia visible.

## **Establecer tipo de ajuste automático para marcos de texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, se desborda o redimensiona automáticamente la forma. El siguiente ejemplo configura la forma para redimensionarse y ajustarse a su texto y guarda el resultado en “autofit_type.pptx”.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para contar líneas después del ajuste automático y ver cómo cambian el texto o el ancho de la forma el resultado, vea [Contar líneas renderizadas](/slides/es/nodejs-java/manage-paragraph/). El número de líneas por sí solo no indica si el texto se desborda del contenedor.

## **Establecer ancla de los marcos de texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, media o inferior. El siguiente ejemplo ancla el texto en la parte inferior de la primera forma y guarda el resultado en “text_anchor.pptx”.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer tabulación de texto**

Use [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) y [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) para configurar las tabulaciones en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado a 100 puntos y añade una tabulación alineada a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las tabulaciones del párrafo](paragraph_tabs.png)

## **Establecer idioma de corrección**

Aspose.Slides proporciona [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), que permite establecer el idioma de corrección para una porción de texto. El idioma de corrección determina el idioma usado para la revisión ortográfica y gramatical en PowerPoint.

El siguiente ejemplo requiere “presentation.pptx” con un cuadro de texto como primera forma en la primera diapositiva y al menos un párrafo. Reemplaza el contenido del primer párrafo con “1。”, establece SimSun como su fuente y asigna el idioma de corrección chino simplificado (`zh-CN`). Guarda el resultado en “proofing_language.pptx”:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Establecer el Id de un idioma de corrección.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copiar metadatos de idioma**

Al copiar texto multilingüe de una plantilla, conserve tanto [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) como [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). El siguiente ejemplo independiente crea una porción de origen con inglés de EE. UU. como idioma y francés como idioma alternativo y copia el texto y los identificadores a una porción en una nueva presentación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Si la fuente no tiene idioma alternativo, null elimina el valor del destino.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para probar un origen sin idioma alternativo, omita la asignación de `"fr-FR"`. El identificador alternativo será entonces `null`, y la misma instrucción de copia preserva su ausencia sin introducir un valor predeterminado, incluso si el destino tenía previamente un idioma alternativo asignado.

Estos identificadores se almacenan como metadatos de idioma. Preservarlos no determina qué diccionario selecciona PowerPoint para la revisión ortográfica o gramatical.

## **Establecer idioma predeterminado**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir el idioma predeterminado del texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés de EE. UU. como idioma de texto predeterminado, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Añadir una nueva forma rectangular con texto.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Comprobar el idioma de la primera porción.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Establecer estilo de texto predeterminado**

Para aplicar formato de texto predeterminado a nivel de presentación, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminada para los párrafos de nivel superior en una nueva presentación y la guarda en “default_text_style.pptx”. El texto puede heredar estos valores predeterminados a menos que un formato más específico los sobrescriba.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Obtener el formato de párrafo de nivel superior.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque se haya escrito originalmente en minúsculas. Cuando recupera esa porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se introdujo. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere “sample2.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Su primera porción del primer párrafo contiene “Hello, Aspose!” con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto de mayúsculas](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Salida:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Preguntas frecuentes**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, use [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Recorra las celdas y actualice cada celda mediante [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) y el formato de párrafo mediante [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Establezca [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) en [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) y configure las paradas del degradado, la dirección y la transparencia.