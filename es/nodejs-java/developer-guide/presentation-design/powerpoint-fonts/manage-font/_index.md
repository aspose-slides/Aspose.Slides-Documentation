---
title: Gestionar fuentes en presentaciones usando JavaScript
linktitle: Gestionar fuentes
type: docs
weight: 10
url: /es/nodejs-java/manage-fonts/
keywords:
- gestionar fuentes
- propiedades de fuente
- párrafo
- formato de texto
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Controla fuentes con Aspose.Slides para Node.js mediante Java: incrusta, sustituye y carga fuentes personalizadas para mantener las presentaciones PPT, PPTX y ODP claras y consistentes."
---

## **Administrar propiedades relacionadas con la fuente**
{{% alert color="primary" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a los estilos corporativos. El formato de texto ayuda a los usuarios a variar el aspecto y la sensación del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para Node.js a través de Java para configurar las propiedades de fuente de los párrafos de texto en diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides para Node.js a través de Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Acceder a las formas [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) de la diapositiva y convertirlas a tipo [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Obtener el [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Justificar el párrafo.
1. Acceder al [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) de texto de un [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
1. Definir la fuente mediante [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) y establecer la **Font** del [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) de texto en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
1. Establecer el color de la fuente mediante el [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) expuesto por el objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Guardar la presentación modificada en un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo de la fuente.

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
    // Accediendo a una diapositiva mediante su posición
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
    // Establecer color de la fuente
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


## **Establecer propiedades de la fuente del texto**
{{% alert color="primary" %}} 

Como se menciona en **Administrar propiedades relacionadas con la fuente**, un [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) se utiliza para contener texto con estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para Node.js a través de Java para crear un cuadro de texto con algo de texto y luego definir una fuente concreta, así como varias otras propiedades de la categoría de familia tipográfica.

{{% /alert %}} 

Para crear un cuadro de texto y establecer las propiedades de fuente del texto que contiene:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) de tipo **Rectangle** a la diapositiva.
1. Eliminar el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Acceder al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) del [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Añadir texto al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. Acceder al objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) asociado al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. Definir la fuente que se utilizará para el [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Establecer otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura mediante las propiedades correspondientes expuestas por el objeto [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Guardar la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides para Node.js a través de Java**|
```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar una AutoShape de tipo Rectángulo
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Eliminar cualquier estilo de relleno asociado a la AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Acceder al TextFrame asociado a la AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Acceder a la Porción asociada al TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Establecer la Fuente para la Porción
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Establecer la propiedad Negrita de la Fuente
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Establecer la propiedad Cursiva de la Fuente
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Establecer la propiedad Subrayado de la Fuente
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Establecer la Altura de la Fuente
    port.getPortionFormat().setFontHeight(25);
    // Establecer el color de la Fuente
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
