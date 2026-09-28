---
title: Formatear texto de presentación en JavaScript
linktitle: Formateo de texto
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
- propiedad autofit
- anclaje del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatear y dar estilo al texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para Node.js a través de Java. Personaliza fuentes, colores, alineación y más."
---
## **Descripción general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para Node.js a través de Java. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de autofit, anclaje de texto, tabulaciones y configuraciones de idioma.

A menos que se indique lo contrario, los ejemplos utilizan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma son base cero. Los ejemplos que seleccionan porciones en negrita utilizan formato efectivo, incluido el formato de negrita heredado:

![Texto de ejemplo](sample_text.png)

Para buscar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Search and Replace Text](/slides/es/nodejs-java/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) para establecer el color de resaltado predeterminado de un párrafo, o use [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) para porciones de texto individuales.

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

El ejemplo de código a continuación muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

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

Utilice [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, a la derecha, justificado, etc.

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

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). En los ejemplos siguientes, `alpha = 50` es un valor alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

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

Utilice [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) para expandir o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

El siguiente código JavaScript muestra cómo expandir el espaciado de caracteres en el **párrafo completo**:

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

El ejemplo de código a continuación muestra cómo expandir el espaciado de caracteres en **porciones de texto con una fuente en negrita**:

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

### **Desactivar el interletraje para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede aparecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar datos de interletraje para ciertas fuentes, incluso cuando la fuente contiene información de interletraje válida y el interletraje está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se aproxime más a PowerPoint en dichos casos, puede desactivar el interletraje para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Comprueba los nombres de fuente efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el interletraje para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

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

Para el texto coincidente por debajo del umbral, esta configuración evita el interletraje y puede ayudar a alinear la representación de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Gestionar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo a Times New Roman 12 puntos con negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Establecer las propiedades de fuente del párrafo.
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

El siguiente ejemplo aplica Times New Roman 13 puntos, formato cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

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

## **Establecer rotación del texto**

Utilice [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textverticaltype/), que rota el texto **90 grados en sentido antihorario**:

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

Utilice [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) para establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/).

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

## **Establecer espaciado de línea de los párrafos**

Aspose.Slides proporciona [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) y [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) para controlar el espaciado de los párrafos. Estas propiedades se utilizan de la siguiente forma:

* Use un valor positivo para especificar el espaciado de línea como un porcentaje de la altura de la línea.
* Use un valor negativo para especificar el espaciado de línea en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo al 200 % de la altura de la línea (interlineado doble):

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

![El espaciado de línea dentro del párrafo](line_spacing.png)

## **Controlar salto de línea**

Las reglas de salto de línea de los párrafos son útiles en bloques de texto estrechos y presentaciones que mezclan texto latino y asiático oriental. Los siguientes métodos pertenecen a [ParagraphFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/), por lo que se aplican a un párrafo completo:

- [setLatinLineBreak](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) controla las reglas de salto de línea latinas. En texto mixto, cambiarlo también puede alterar dónde se envuelve el texto y la puntuación asiática oriental adyacente.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) controla las reglas de salto de línea del asiático oriental, incluidas las restricciones de caracteres al comienzo y al final de una línea.

Estas reglas no sustituyen a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando ocurre el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo autónomo crea un bloque de texto estrecho que contiene chino y texto latino. Establece ambas opciones de salto de línea explícitamente y guarda “line_breaking.pptx”. Para experimentar con cualquiera de las reglas, cambie el valor correspondiente manteniendo la otra configuración fija. El ejemplo utiliza Arial 24 pt y SimSun con un ancho de marco de 160 pt y márgenes horizontales del marco de texto a cero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) se llama con [TextAutofitType.None](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos:

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo autónomo habilita la puntuación colgante en un marco de texto de 100 pt de ancho y guarda “hanging_punctuation.pptx”. Con Arial 24 pt y márgenes horizontales del marco a cero, el punto final permanece después de “sentence” y se extiende más allá del borde derecho del texto. Establezca la propiedad a [NullableBool.False](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/nullablebool/) para comparar: con esta configuración, el punto ocupa una línea separada. El ajuste de línea está habilitado y el autofit está deshabilitado para mantener el ancho disponible fijo.

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

No todas las marcas de puntuación pueden colgar. El resultado visible depende de la disponibilidad de la fuente y del diseño: cambiar la fuente, el ancho disponible, los márgenes o la configuración de autofit puede eliminar la diferencia visible.

## **Establecer tipo de autofit para marcos de texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, desborda o redimensiona la forma automáticamente. El siguiente ejemplo configura la forma para redimensionarse y ajustarse a su texto y guarda el resultado en “autofit_type.pptx”.

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

Para contar líneas después del ajuste automático y ver cómo cambia el texto o el ancho de la forma, consulte [Count Rendered Lines](/slides/es/nodejs-java/manage-paragraph/). El recuento de líneas por sí solo no indica si el texto desborda su contenedor.

## **Establecer anclaje de los marcos de texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, media o inferior. El siguiente ejemplo ancla el texto al fondo de la primera forma y guarda el resultado en “text_anchor.pptx”.

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

## **Establecer tabulación del texto**

Utilice [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) y [ParagraphFormat.getTabs](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#getTabs--) para configurar las tabulaciones en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado en 100 puntos y añade una tabulación alineada a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

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

Aspose.Slides proporciona [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), que permite establecer el idioma de corrección para una porción de texto. El idioma de corrección determina el idioma utilizado para la revisión ortográfica y gramatical en PowerPoint.

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

    // Establecer el Id del idioma de corrección.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer idioma predeterminado**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para definir el idioma predeterminado del texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés de EE. UU. como idioma de texto predeterminado, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

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

Para aplicar formato de texto predeterminado a nivel de presentación, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminada para los párrafos de nivel superior en una nueva presentación y la guarda en “default_text_style.pptx”. El texto puede heredar estos valores predeterminados salvo que un formato más específico los sobrescriba.

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

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque se haya escrito originalmente en minúsculas. Cuando recupera una porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere “sample2.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Su primer párrafo contiene “Hello, Aspose!” con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto All Caps](all_caps_effect.png)

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

Para modificar el texto en una tabla de una diapositiva, use [Table](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/table/). Recorra las celdas y actualice cada celda mediante [Cell.getTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/cell/#getTextFrame--) y el formato de párrafo mediante [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Establezca [FillFormat.setFillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) a [FillType.Gradient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filltype/) y configure las paradas del degradado, la dirección y la transparencia.