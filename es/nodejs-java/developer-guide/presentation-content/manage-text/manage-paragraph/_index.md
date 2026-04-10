---
title: Gestionar párrafos de texto de PowerPoint en JavaScript
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/nodejs-java/manage-paragraph/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades del párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para Node.js mediante Java—optimiza alineación, espaciado y estilo en presentaciones PPT, PPTX y ODP en JavaScript."
---
Aspose.Slides proporciona todas las clases que necesita para trabajar con textos, párrafos y fragmentos de PowerPoint en Java.

* Aspose.Slides proporciona la clase [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) para permitirle añadir objetos que representan un párrafo. Un objeto `TextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) para permitirle añadir objetos que representan fragmentos. Un objeto `Paragraph` puede tener uno o varios fragmentos (colección de objetos de fragmento de texto).
* Aspose.Slides proporciona la clase [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) para permitirle añadir objetos que representan textos y sus propiedades de formato.

Un objeto `Paragraph` es capaz de manejar textos con diferentes propiedades de formato mediante sus objetos `Portion` subyacentes.

## **Añadir varios párrafos que contengan varias porciones**

Estos pasos le muestran cómo añadir un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 fragmentos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva pertinente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Obtenga el ITextFrame asociado al [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/).
5. Cree dos objetos [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) y añádalos a la colección `IParagraphs` del [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/).
6. Cree tres objetos [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) para cada nuevo `Paragraph` (dos objetos Portion para el párrafo predeterminado) y añada cada objeto `Portion` a la colección IPortion de cada `Paragraph`.
7. Asigne texto a cada fragmento.
8. Aplique las características de formato que prefiera a cada fragmento usando las propiedades de formato expuestas por el objeto `Portion`.
9. Guarde la presentación modificada.

Este código JavaScript es una implementación de los pasos para añadir párrafos que contienen fragmentos:

```javascript
// Instanciar una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectángulo
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Acceder al TextFrame del AutoShape
    var tf = ashp.getTextFrame();
    // Create Paragraphs and Portions with different text formats
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Guardar el PPTX en disco
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestionar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva pertinente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/).
7. Establezca el `Type` de viñeta del párrafo a `Symbol` y defina el carácter de viñeta.
8. Asigne el `Text` al párrafo.
9. Defina la `Indent` del párrafo para la viñeta.
10. Asigne un color a la viñeta.
11. Defina una altura para la viñeta.
12. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Añada el segundo párrafo y repita el proceso indicado en los pasos 7 a 13.
14. Guarde la presentación.

Este código JavaScript le muestra cómo añadir una viñeta de párrafo:

```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añade y accede al Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al marco de texto del autoshape
    var txtFrm = aShp.getTextFrame();
    // Elimina el párrafo predeterminado
    txtFrm.getParagraphs().removeAt(0);
    // Crea un párrafo
    var para = new aspose.slides.Paragraph();
    // Define el estilo y símbolo de viñeta del párrafo
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Define el texto del párrafo
    para.setText("Welcome to Aspose.Slides");
    // Define la sangría de la viñeta
    para.getParagraphFormat().setIndent(25);
    // Define el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// establecer IsBulletHardColor a true para usar el propio color de viñeta
    // Define la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    // Añade el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    // Crea el segundo párrafo
    var para2 = new aspose.slides.Paragraph();
    // Define el tipo y estilo de viñeta del párrafo
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Añade el texto del párrafo
    para2.setText("This is numbered bullet");
    // Define la sangría de la viñeta
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// establecer IsBulletHardColor a true para usar el propio color de viñeta
    // Define la altura de la viñeta
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Añade el párrafo al marco de texto
    txtFrm.getParagraphs().add(para2);
    // Guarda la presentación modificada
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestionar viñetas con imagen**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva pertinente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/).
7. Cargue la imagen en [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) y asigne la imagen.
9. Defina el `Text` del párrafo.
10. Defina la `Indent` del párrafo para la viñeta.
11. Asigne un color a la viñeta.
12. Defina una altura para la viñeta.
13. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añada el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

Este código JavaScript le muestra cómo añadir y gestionar viñetas con imagen:

```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = presentation.getSlides().get_Item(0);
    // Instancia la imagen para las viñetas
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Añade y accede al Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al textframe del autoshape
    var textFrame = autoShape.getTextFrame();
    // Elimina el párrafo predeterminado
    textFrame.getParagraphs().removeAt(0);
    // Crea un nuevo párrafo
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Define el estilo de viñeta del párrafo y la imagen
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Define la altura de la viñeta
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Añade el párrafo al text frame
    textFrame.getParagraphs().add(paragraph);
    // Guarda la presentación como archivo PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Guarda la presentación como archivo PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Gestionar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva pertinente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) y establezca la profundidad en 0.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad en 1.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad en 2.
9. Cree la cuarta instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad en 3.
10. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código JavaScript le muestra cómo añadir y gestionar viñetas multinivel:

```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añade y accede al Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al marco de texto del autoshape creado
    var text = aShp.addTextFrame("");
    // Borra el párrafo predeterminado
    text.getParagraphs().clear();
    // Añade el primer párrafo
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define el nivel de viñeta
    para1.getParagraphFormat().setDepth(0);
    // Añade el segundo párrafo
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define el nivel de viñeta
    para2.getParagraphFormat().setDepth(1);
    // Añade el tercer párrafo
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define el nivel de viñeta
    para3.getParagraphFormat().setDepth(2);
    // Añade el cuarto párrafo
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Define el nivel de viñeta
    para4.getParagraphFormat().setDepth(3);
    // Añade los párrafos a la colección
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Guarda la presentación como archivo PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestionar párrafo con lista numerada personalizada**

La clase [BulletFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) y otras que le permiten gestionar párrafos con numeración o formato personalizados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) a 2.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 3.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 7.
9. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código JavaScript le muestra cómo añadir y gestionar párrafos con numeración o formato personalizados:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al marco de texto del autoshape creado
    var textFrame = shape.getTextFrame();
    // Elimina el párrafo predeterminado existente
    textFrame.getParagraphs().removeAt(0);
    // Primera lista
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Establecer sangría de primera línea para un párrafo**

Utilice el método [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para controlar la sangría de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Use [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) cuando necesite mover todo el párrafo. Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) cuando necesite mover solo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de sangría para demostrar cómo la sangría de primera línea afecta el diseño del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) vacío al forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [Indent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

Este código le muestra cómo establecer la sangría de un párrafo:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

## **Establecer sangría colgante para un párrafo**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con el método [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/). Establezca la sangría a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo en `MarginLeft` y un valor negativo en `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) vacío al forma y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [MarginLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) para cada párrafo.
6. Establezca un valor negativo de [Indent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

Este código le muestra cómo establecer una sangría colgante para un párrafo:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

## **Gestionar propiedades de ejecución al final del párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtenga la referencia a la diapositiva que contiene el párrafo mediante su posición.
1. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Añada un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) con dos párrafos al rectángulo.
1. Establezca la `FontHeight` y el tipo de fuente para los párrafos.
1. Establezca las propiedades End para los párrafos.
1. Guarde la presentación modificada como archivo PPTX.

Este código JavaScript le muestra cómo establecer las propiedades End para los párrafos en PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Importar texto HTML en párrafos**

Aspose.Slides proporciona un soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva pertinente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
4. Añada y acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) del `AutoShape`.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/).
8. Añada el contenido del archivo HTML leído por el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

Este código JavaScript es una implementación de los pasos para importar textos HTML en párrafos:

```javascript
// Crear instancia vacía de presentación
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la diapositiva predeterminada inicial de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Añadir el AutoShape para alojar el contenido HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Añadir marco de texto a la forma
    ashape.addTextFrame("");
    // Borrar todos los párrafos del marco de texto añadido
    ashape.getTextFrame().getParagraphs().clear();
    // Cargar el archivo HTML usando StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Añadir texto del StreamReader HTML al marco de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Guardar la presentación
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exportar texto de párrafos a HTML**

Aspose.Slides proporciona un soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva pertinente mediante su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y añada el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte los párrafos que prefiera.

Este código JavaScript le muestra cómo exportar los textos de los párrafos de PowerPoint a HTML:

```javascript
// Cargar el archivo de presentación
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Acceder a la diapositiva predeterminada inicial de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Índice deseado
    var index = 0;
    // Accediendo a la forma añadida
    var ashape = slide.getShapes().get_Item(index);
    // Creando archivo HTML de salida
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extrayendo el primer párrafo como HTML
    // Escribiendo los datos de los párrafos a HTML proporcionando el índice inicial del párrafo y el número total de párrafos a copiar
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Guardar un párrafo como una imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/), como una imagen. Ambos ejemplos incluyen obtener la imagen de una forma que contiene el párrafo mediante los métodos `getImage` de la clase [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/), calcular los límites del párrafo dentro de la forma y exportarlo como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones de PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar sobre una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen independiente conservando las dimensiones y el formato exactos del texto.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guardar la forma en memoria como un bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Crear un bitmap de la forma desde la memoria.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como imagen con un factor de escala de `2`. Esto permite obtener una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para materiales impresos de alta calidad.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guardar la forma en memoria como un bitmap con escalado.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Crear un bitmap de la forma desde la memoria.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Use la configuración de ajuste del marco de texto ([setWrapText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/setwraptext/)) para desactivar el ajuste y evitar que las líneas se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en diapositiva de un párrafo específico?**

Puede recuperar el rectángulo delimitador del párrafo (e incluso de un único fragmento) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[setAlignment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setalignment/) es un método de configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de los fragmentos individuales.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte del párrafo (por ejemplo, una palabra)?**

Sí. El idioma se establece a nivel de fragmento ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.