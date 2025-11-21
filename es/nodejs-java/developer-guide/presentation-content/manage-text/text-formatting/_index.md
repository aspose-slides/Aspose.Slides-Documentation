---
title: Formatear texto de PowerPoint en JavaScript
linktitle: Formato de texto
type: docs
weight: 50
url: /es/nodejs-java/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuentes
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
description: "Aprenda a dar formato y estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Node.js mediante Java. Personalice fuentes, colores, alineación y más con potentes ejemplos de código JavaScript."
---

## **Resaltar Texto**

El método [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) se ha añadido a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Permite resaltar una parte del texto con color de fondo usando una muestra de texto, similar a la herramienta Color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta característica:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// resaltando todas las palabras 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// resaltando todas las ocurrencias separadas de 'the'
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose ofrece un sencillo [servicio gratuito de edición en línea de PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Resaltar Texto usando Expresión Regular**

El método [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) se ha añadido a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Permite resaltar una parte del texto con color de fondo usando una expresión regular, similar a la herramienta Color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta característica:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// resaltando todas las palabras con 10 símbolos o más
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Color de Fondo del Texto**

Aspose.Slides le permite especificar el color preferido para el fondo de un texto.

Este código JavaScript muestra cómo establecer el color de fondo para todo un texto:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este código JavaScript muestra cómo establecer el color de fondo solo para una parte del texto:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Alinear Párrafos de Texto**

El formato de texto es uno de los elementos clave al crear cualquier tipo de documento o presentación. Sabemos que Aspose.Slides para Node.js mediante Java permite agregar texto a diapositivas, pero en este tema veremos cómo controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides para Node.js mediante Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Acceda a las formas de marcador de posición presentes en la diapositiva y conviértalas a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Obtenga el párrafo (que necesita alinearse) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) expuesto por [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Alinee el párrafo. Un párrafo puede alinearse a la derecha, izquierda, centro o justificar.
6. Guarde la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Cambiar el texto en ambos marcadores de posición
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Obteniendo el primer párrafo de los marcadores de posición
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Alineando el párrafo de texto al centro
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Guardando la presentación como un archivo PPTX
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Transparencia para el Texto**

Este artículo demuestra cómo establecer la propiedad de transparencia a cualquier forma de texto usando Aspose.Slides para Node.js mediante Java. Para establecer la transparencia al texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de la sombra.
4. Guarde la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // establecer la transparencia al cero por ciento
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Espaciado de Caracteres para el Texto**

Aspose.Slides le permite establecer el espacio entre letras en un cuadro de texto. De esta forma, puede ajustar la densidad visual de una línea o bloque de texto ampliando o condensando el espaciado entre caracteres.

Este código JavaScript muestra cómo ampliar el espaciado para una línea de texto y cómo condensarlo para otra línea:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// expandir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// condensar
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Administrar Propiedades de Fuente del Párrafo**

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para cumplir con estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para Node.js mediante Java para configurar las propiedades de fuente de los párrafos de texto en diapositivas. Para administrar las propiedades de fuente de un párrafo usando Aspose.Slides para Node.js mediante Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Acceda a las formas de marcador de posición en la diapositiva y conviértalas a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Obtenga el [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) expuesto por [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Justifique el párrafo.
6. Acceda a la porción de texto del párrafo.
7. Defina la fuente usando FontData y establezca la Font de la porción de texto en consecuencia.
   1. Establezca la fuente en negrita.
   2. Establezca la fuente en cursiva.
8. Establezca el color de la fuente usando el método [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) expuesto por el objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Guarde la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accediendo a una diapositiva usando su posición
    var slide = pres.getSlides().get_Item(0);
    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Accediendo al primer Párrafo
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Accediendo a la primera porción
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definir nuevas fuentes
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Asignar nuevas fuentes a la porción
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Establecer la fuente en negrita
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Establecer la fuente en cursiva
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Establecer color de fuente
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Guardar el PPTX en disco
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Administrar Familia de Fuentes del Texto**

Una porción se usa para contener texto con estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para Node.js mediante Java para crear un cuadro de texto con algo de texto y luego definir una fuente determinada, así como varias propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) del tipo [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
4. Elimine el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Acceda al TextFrame del AutoShape.
6. Añada texto al TextFrame.
7. Acceda al objeto Portion asociado al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. Defina la fuente que se usará para la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Establezca otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades correspondientes del objeto Portion.
10. Guarde la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
// Instanciar Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Eliminar cualquier estilo de relleno asociado al AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Acceder al TextFrame asociado al AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Acceder a la Portion asociada al TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Establecer la fuente para la Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Establecer la propiedad Bold de la fuente
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Establecer la propiedad Italic de la fuente
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Establecer la propiedad Underline de la fuente
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Establecer la altura de la fuente
    port.getPortionFormat().setFontHeight(25);
    // Establecer el color de la fuente
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Guardar el PPTX en disco
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Tamaño de Fuente para el Texto**

Aspose.Slides le permite elegir el tamaño de fuente preferido para el texto existente en un párrafo y para otros textos que puedan añadirse al párrafo posteriormente.

Este código JavaScript muestra cómo establecer el tamaño de fuente para los textos contenidos en un párrafo:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Obtiene la primera forma, por ejemplo.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // Obtiene el primer párrafo, por ejemplo.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto en el párrafo.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Establece el tamaño de fuente a 20 pt para las porciones de texto actuales en el párrafo.
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Establecer Rotación del Texto**

Aspose.Slides para Node.js mediante Java permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Rote el texto](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Guarde el archivo en disco.
```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accessing the text frame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Create the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Create Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Save Presentation
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Ángulo de Rotación Personalizado para TextFrame**

Aspose.Slides para Node.js mediante Java ahora admite establecer un ángulo de rotación personalizado para TextFrame. En este tema veremos, con ejemplo, cómo establecer la propiedad RotationAngle en Aspose.Slides. Los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) y [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) se han añadido a las clases [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) y [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat), y permiten establecer el ángulo de rotación personalizado para TextFrame. Para establecer RotationAngle, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Añada un gráfico a la diapositiva.
3. [Establezca la propiedad RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Guarde la presentación como archivo PPTX.

En el ejemplo siguiente, establecemos la propiedad RotationAngle.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Añadir TextFrame al Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accediendo al TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Crear el objeto Paragraph para el TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Crear el objeto Portion para el párrafo
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Guardar la presentación
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Espaciado de Líneas del Párrafo**

Aspose.Slides proporciona propiedades bajo [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que permiten gestionar el espaciado de líneas para un párrafo. Las tres propiedades se utilizan de la siguiente manera:

* Para especificar el espaciado de líneas en porcentaje, use un valor positivo. 
* Para especificar el espaciado de líneas en puntos, use un valor negativo.

Por ejemplo, puede aplicar un espaciado de 16 pt a un párrafo estableciendo la propiedad `SpaceBefore` en –16.

Así es como se especifica el espaciado de líneas para un párrafo concreto:

1. Cargue una presentación que contenga un AutoShape con texto.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Acceda al TextFrame.
4. Acceda al Paragraph.
5. Establezca las propiedades del Paragraph.
6. Guarde la presentación.

Este código JavaScript muestra cómo especificar el espaciado de líneas para un párrafo:
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Obtener la referencia de una diapositiva por su índice
    var sld = pres.getSlides().get_Item(0);
    // Acceder al TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Acceder al párrafo
    var para = tf1.getParagraphs().get_Item(0);
    // Establecer propiedades del párrafo
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // Guardar la presentación
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer la Propiedad AutofitType para TextFrame**

En este tema exploraremos las distintas propiedades de formato de TextFrame. Este artículo cubre cómo establecer la propiedad AutofitType de TextFrame, anclar el texto y rotar el texto en la presentación. Aspose.Slides para Node.js mediante Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier TextFrame. AutofitType puede establecerse en [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) o [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). Si se establece en [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal), la forma permanecerá igual mientras el texto se ajusta sin que la forma cambie; si se establece en [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape), la forma se modificará de modo que solo contenga el texto necesario. Para establecer la propiedad AutofitType de un TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Establezca el AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) del TextFrame.
6. Guarde el archivo en disco.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Añadir TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accediendo al TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Crear el objeto Paragraph para el TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Crear el objeto Portion para el párrafo
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Guardar la presentación
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Anclaje de TextFrame**

Aspose.Slides para Node.js mediante Java permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca el texto dentro de la forma. AnchorType puede establecerse en [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) o [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). Para establecer el anclaje de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Establezca TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) del TextFrame.
6. Guarde el archivo en disco.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Añadir TextFrame al Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accediendo al TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // Crear el objeto Paragraph para el TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Crear el objeto Portion para el párrafo
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Guardar la presentación
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Tabs y EffectiveTabs en la Presentación**

Todas las tabulaciones de texto se dan en píxeles.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figura: 2 Tabs explícitos y 2 Tabs predeterminados**|
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.  
- La colección EffectiveTabs incluye todas las tabs (de la colección Tabs y las tabs predeterminadas).  
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.  
- La propiedad EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las tabs predeterminadas (3 y 4 en nuestro ejemplo).  
- EffectiveTabs.GetTabByIndex(index) con index = 0 devuelve la primera tab explícita (Position = 731), index = 1 la segunda tab (Position = 1241). Si se intenta obtener la siguiente tab con index = 2 devolverá la primera tab predeterminada (Position = 1470), etc.  
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la siguiente tabulación después de algún texto. Por ejemplo, tiene el texto: "Hello World!". Para renderizar ese texto debe saber dónde comenzar a dibujar "world!". Primero, calcule la longitud de "Hello" en píxeles y llame a GetTabAfterPosition con ese valor. Obtendrá la posición de la siguiente tab para dibujar "world!".

## **Establecer Estilo de Texto Predeterminado**

Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación a la vez, puede usar el método `getDefaultTextStyle` de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y establecer el formato preferido. El siguiente ejemplo muestra cómo establecer la fuente negrita predeterminada (14 pt) para el texto en todas las diapositivas de una nueva presentación.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Obtener el formato de párrafo de nivel superior.
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Extraer Texto con el Efecto All‑Caps**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando extrae una porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para manejar esto, verifique [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)—si indica `All`, convierta la cadena devuelta a mayúsculas para que su salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![The All Caps effect](all_caps_effect.png)

El siguiente ejemplo muestra cómo extraer el texto con el efecto **All Caps** aplicado:
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
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


## **FAQ**

**¿Cómo modificar texto en una tabla de una diapositiva?**

Para modificar texto en una tabla de una diapositiva, debe usar el objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Puede iterar todas las celdas de la tabla y cambiar el texto en cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat`.

**¿Cómo aplicar un degradado de color al texto en una diapositiva de PowerPoint?**

Para aplicar un degradado de color al texto, use la propiedad Fill Format en [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Establezca Fill Format en `Gradient`, donde podrá definir los colores de inicio y fin del degradado, junto con otras propiedades como dirección y transparencia para crear el efecto de degradado en el texto.