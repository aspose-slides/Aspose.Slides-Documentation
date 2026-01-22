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
- familia tipográfica
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Formato y estilo del texto en presentaciones PowerPoint y OpenDocument usando JavaScript y Aspose.Slides para Node.js. Personaliza fuentes, colores, alineación y más."
---

## **Resaltar texto**

El método [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) se ha añadido a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Permite resaltar una parte del texto con color de fondo utilizando una muestra de texto, similar a la herramienta Resaltar color de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
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
Aspose ofrece un sencillo, [servicio de edición de PowerPoint en línea gratuito](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Resaltar texto usando expresión regular**

El método [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) se ha añadido a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Permite resaltar una parte del texto con color de fondo utilizando una expresión regular, similar a la herramienta Resaltar color de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
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


## **Establecer color de fondo del texto**

Aspose.Slides permite especificar el color preferido para el fondo de un texto.

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


Este código JavaScript muestra cómo establecer el color de fondo solo para una porción de texto:
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


## **Alinear párrafos de texto**

El formato del texto es uno de los elementos clave al crear cualquier tipo de documento o presentación. Sabemos que Aspose.Slides for Node.js via Java admite añadir texto a diapositivas, pero en este tema veremos cómo controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides for Node.js via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Acceda a las formas de marcador de posición presentes en la diapositiva y conviértala a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Obtenga el párrafo (que necesita alinearse) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) expuesto por [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Alinee el párrafo. Un párrafo puede alinearse a derecha, izquierda, centro y justificar.
6. Grabe la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Acceder a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo a AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Cambiar el texto en ambos marcadores de posición
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Obtener el primer párrafo de los marcadores de posición
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Alinear el párrafo de texto al centro
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Guardar la presentación como archivo PPTX
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer transparencia para el texto**

Este artículo demuestra cómo establecer la propiedad de transparencia para cualquier forma de texto usando Aspose.Slides for Node.js via Java. Para establecer la transparencia en el texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de la sombra.
4. Grabe la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // establecer la transparencia a cero por ciento
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer espacio entre caracteres para el texto**

Aspose.Slides permite establecer el espacio entre letras en un cuadro de texto. De esta forma, puede ajustar la densidad visual de una línea o bloque de texto ampliando o condensando el espacio entre caracteres.

Este código JavaScript muestra cómo ampliar el espacio para una línea de texto y condensar el espacio para otra línea:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// expandir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// condensar
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Gestionar propiedades de fuente del párrafo**

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para cumplir con estilos corporativos. El formateo del texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for Node.js via Java para configurar las propiedades de fuente de los párrafos de texto en diapositivas. Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides for Node.js via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Acceda a las formas de marcador de posición en la diapositiva y conviértala a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Obtenga el [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) expuesto por [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Justifique el párrafo.
1. Acceda a la Porción de texto del párrafo.
1. Defina la fuente usando FontData y establezca la fuente de la Porción de texto en consecuencia.
   1. Establezca la fuente en negrita.
   1. Establezca la fuente en cursiva.
1. Establezca el color de la fuente usando el [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) expuesto por el objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
1. Grabe la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Acceder a una diapositiva usando su posición
    var slide = pres.getSlides().get_Item(0);
    // Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo a AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Acceder al primer párrafo
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Acceder a la primera porción
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
    // Establecer el color de la fuente
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


## **Gestionar familia tipográfica del texto**

Una porción se utiliza para contener texto con estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for Node.js via Java para crear un cuadro de texto con algún texto y luego definir una fuente concreta, y varias otras propiedades de la categoría de familia tipográfica. Para crear un cuadro de texto y establecer las propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) del tipo [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
4. Elimine el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Acceda al TextFrame del AutoShape.
6. Añada algún texto al TextFrame.
7. Acceda al objeto Portion asociado al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. Defina la fuente a usar para la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Establezca otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades correspondientes del objeto Portion.
10. Grabe la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```javascript
// Instanciar Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir un AutoShape del tipo Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Eliminar cualquier estilo de relleno asociado al AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Acceder al TextFrame asociado al AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Acceder a la Porción asociada al TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Establecer la fuente para la Porción
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Establecer la fuente en negrita
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Establecer la fuente en cursiva
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Establecer la fuente subrayada
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


## **Establecer tamaño de fuente para el texto**

Aspose.Slides permite elegir el tamaño de fuente preferido para el texto existente en un párrafo y para otros textos que puedan añadirse al párrafo más tarde.

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
        // Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto del párrafo.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Establece el tamaño de fuente a 20 pt para las porciones de texto actuales del párrafo.
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


## **Establecer rotación del texto**

Aspose.Slides for Node.js via Java permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Rote el texto](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Guarde el archivo en disco.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir un AutoShape del tipo Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Añadir un TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accediendo al TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Crear el objeto Paragraph para el TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Crear el objeto Portion para el párrafo
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Guardar la presentación
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer ángulo de rotación personalizado para TextFrame**

Aspose.Slides for Node.js via Java ahora admite establecer ángulo de rotación personalizado para TextFrame. En este tema veremos, con ejemplo, cómo establecer la propiedad RotationAngle en Aspose.Slides. Se han añadido los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) y [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) a la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat), lo que permite fijar el ángulo de rotación personalizado para TextFrame. Para establecer RotationAngle, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Añada un gráfico a la diapositiva.
3. [Establezca la propiedad RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Grabe la presentación como un archivo PPTX.

En el ejemplo siguiente, establecemos la propiedad RotationAngle.
```javascript
    // Crear una instancia de la clase Presentation
    var pres = new aspose.slides.Presentation();
    try {
        // Obtener la primera diapositiva
        var slide = pres.getSlides().get_Item(0);
        // Añadir un AutoShape del tipo Rectangle
        var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
        // Añadir un TextFrame al rectángulo
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


## **Espaciado de líneas del párrafo**

Aspose.Slides proporciona propiedades bajo [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que permiten gestionar el espaciado de líneas de un párrafo. Las tres propiedades se usan de la siguiente manera:

* Para especificar el espaciado de líneas de un párrafo en porcentaje, use un valor positivo. 
* Para especificar el espaciado de líneas de un párrafo en puntos, use un valor negativo.

Por ejemplo, puede aplicar un espaciado de 16 pt a un párrafo estableciendo la propiedad `SpaceBefore` a -16.

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


## **Establecer la propiedad AutofitType para TextFrame**

En este tema exploraremos las distintas propiedades de formato de un cuadro de texto. Este artículo cubre cómo establecer la propiedad AutofitType de un cuadro de texto, el anclaje del texto y la rotación del texto en una presentación. Aspose.Slides for Node.js via Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier cuadro de texto. AutofitType puede establecerse en [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) o [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). Si se establece en [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal), la forma permanece igual mientras el texto se ajusta sin cambiar la forma; si se establece en [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape), la forma se modifica de modo que solo contenga el texto necesario. Para establecer la propiedad AutofitType de un cuadro de texto, siga los pasos a continuación:

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
    // Añadir un TextFrame al rectángulo
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


## **Establecer ancla de TextFrame**

Aspose.Slides for Node.js via Java permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca el texto dentro de la forma. AnchorType puede establecerse en [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) o [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). Para establecer el ancla de cualquier TextFrame, siga los pasos a continuación:

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
    // Añadir un AutoShape del tipo Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Añadir un TextFrame al rectángulo
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


## **Tabs y EffectiveTabs en la presentación**

Todas las tabulaciones de texto se dan en píxeles.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figura: 2 pestañas explícitas y 2 pestañas predeterminadas**|
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las pestañas (de la colección Tabs y las pestañas predeterminadas).
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) muestra la distancia entre pestañas predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera pestaña explícita (Position = 731), index = 1 la segunda (Position = 1241). Si intenta obtener la siguiente pestaña con index = 2 devolverá la primera pestaña predeterminada (Position = 1470) etc.
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la siguiente tabulación tras algún texto. Por ejemplo, tiene el texto: "Hello World!". Para representar ese texto debe saber dónde comenzar a dibujar "world!". Primero calcule la longitud de "Hello" en píxeles y llame a GetTabAfterPosition con ese valor. Obtendrá la siguiente posición de tabulación para dibujar "world!".

## **Establecer estilo de texto predeterminado**

Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación a la vez, puede usar el método `getDefaultTextStyle` de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y establecer el formato preferido. El ejemplo de código a continuación muestra cómo establecer la fuente negrita predeterminada (14 pt) para el texto de todas las diapositivas en una nueva presentación.
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


## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recupera esa porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para manejar esto, compruebe [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)—si indica `All`, convierta la cadena devuelta a mayúsculas para que la salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![The All Caps effect](all_caps_effect.png)

El ejemplo de código a continuación muestra cómo extraer el texto con el efecto **All Caps** aplicado:
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

Para modificar texto en una tabla de una diapositiva, es necesario usar el objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Puede iterar todas las celdas de la tabla y cambiar el texto en cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat`.

**¿Cómo aplicar un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, utilice la propiedad Fill Format en [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Establezca Fill Format a `Gradient`, donde puede definir los colores de inicio y fin del degradado, así como otras propiedades como dirección y transparencia para crear el efecto degradado en el texto.