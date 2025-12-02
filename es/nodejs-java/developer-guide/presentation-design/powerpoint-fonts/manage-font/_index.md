---
title: Administrar fuentes en presentaciones usando JavaScript
linktitle: Administrar fuentes
type: docs
weight: 10
url: /es/nodejs-java/manage-fonts/
keywords:
- administrar fuentes
- propiedades de fuentes
- párrafo
- formato de texto
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Controla fuentes con Aspose.Slides para Node.js vía Java: incrusta, sustituye y carga fuentes personalizadas para mantener claras y consistentes las presentaciones PPT, PPTX y ODP."
---

## **Administrar propiedades relacionadas con fuentes**
{{% alert color="primary" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a los estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia y la sensación del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for Node.js a través de Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.

{{% /alert %}} 

Para administrar las propiedades de fuente de un párrafo usando Aspose.Slides for Node.js a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenga una referencia a una diapositiva usando su índice.
1. Acceda a las formas [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Placeholder) en la diapositiva y conviértalas a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Obtenga el [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) expuesto por [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Justifique el párrafo.
1. Acceda a la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) de texto de un [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph).
1. Defina la fuente usando [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FontData) y establezca la **Font** de la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) de texto en consecuencia.
   1. Establezca la fuente en negrita.
   1. Establezca la fuente en cursiva.
1. Establezca el color de la fuente usando el [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FillFormat) expuesto por el objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Guarde la presentación modificada en un archivo PPTX.

A continuación se muestra la implementación de los pasos anteriores. Toma una presentación sin adornos y da formato a las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo de la fuente.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: El texto en el archivo de entrada**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: El mismo texto con formato actualizado**|
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accediendo a una diapositiva usando su posición
    var slide = pres.getSlides().get_Item(0);
    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Accediendo al primer párrafo
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Justificar el párrafo
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Accediendo a la primera porción
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Definir nuevas fuentes
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Asignar nuevas fuentes a la porción
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Establecer fuente en negrita
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Establecer fuente en cursiva
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Establecer color de fuente
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Guardar el PPTX en disco
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer propiedades de fuente del texto**
{{% alert color="primary" %}} 

Como se mencionó en **Administrar propiedades relacionadas con fuentes**, una [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) se usa para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for Node.js a través de Java para crear un cuadro de texto con algo de texto y luego definir una fuente concreta, y varias otras propiedades de la categoría de familia de fuentes.

{{% /alert %}} 

Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva usando su índice.
1. Agregue una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) de tipo **Rectangle** a la diapositiva.
1. Elimine el estilo de relleno asociado con la [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) del [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Agregue algo de texto al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Acceda al objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) asociado con el [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Defina la fuente a usar para la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Establezca otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades correspondientes expuestas por el objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Guarde la presentación modificada como un archivo PPTX.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides for Node.js a través de Java**|
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectángulo
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Eliminar cualquier estilo de relleno asociado con el AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Acceder al TextFrame asociado con el AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Acceder a la Portion asociada con el TextFrame
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
    // Guardar la presentación en disco
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
