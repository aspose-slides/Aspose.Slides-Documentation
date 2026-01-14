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
- sangría francesa
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
description: "Domina el formato de párrafos con Aspose.Slides para Node.js a través de Java—optimiza alineación, espaciado y estilo en presentaciones PPT, PPTX y ODP en JavaScript."
---

Aspose.Slides proporciona todas las clases que necesitas para trabajar con textos, párrafos y fragmentos de PowerPoint en Java.

* Aspose.Slides proporciona la clase [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) para permitirte añadir objetos que representan un párrafo. Un objeto `TextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) para permitirte añadir objetos que representan fragmentos. Un objeto `Paragraph` puede tener uno o varios fragmentos (colección de objetos de fragmento de texto).
* Aspose.Slides proporciona la clase [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) para permitirte añadir objetos que representan textos y sus propiedades de formato.

Un objeto `Paragraph` puede gestionar textos con diferentes propiedades de formato mediante sus objetos subyacentes `Portion`.

## **Agregar varios párrafos que contienen varios fragmentos**

Estos pasos te muestran cómo añadir un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 fragmentos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Obtén el ITextFrame asociado a la [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
5. Crea dos objetos [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) y añádelos a la colección `IParagraphs` del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. Crea tres objetos [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) para cada nuevo `Paragraph` (dos objetos Portion para el Paragraph predeterminado) y añade cada objeto `Portion` a la colección IPortion de cada `Paragraph`.
7. Establece algo de texto para cada fragmento.
8. Aplica las características de formato que prefieras a cada fragmento usando las propiedades de formato expuestas por el objeto `Portion`.
9. Guarda la presentación modificada.

Este código Javascript es una implementación de los pasos para añadir párrafos que contienen fragmentos:
```javascript
// Instanciar una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregar una AutoShape de tipo Rectángulo
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Acceder al TextFrame de la AutoShape
    var tf = ashp.getTextFrame();
    // Crear párrafos y fragmentos con diferentes formatos de texto
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

Las listas con viñetas te ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con viñetas son siempre más fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) a la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Establece el `Type` de la viñeta del párrafo a `Symbol` y define el carácter de la viñeta.
8. Establece el `Text` del párrafo.
9. Establece el `Indent` del párrafo para la viñeta.
10. Establece un color para la viñeta.
11. Establece una altura para la viñeta.
12. Añade el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Añade el segundo párrafo y repite el proceso descrito en los pasos 7 a 12.
14. Guarda la presentación.

Este código Javascript muestra cómo añadir una viñeta de párrafo:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añade y accede a AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al marco de texto de la AutoShape
    var txtFrm = aShp.getTextFrame();
    // Elimina el párrafo predeterminado
    txtFrm.getParagraphs().removeAt(0);
    // Crea un párrafo
    var para = new aspose.slides.Paragraph();
    // Establece el estilo y símbolo de viñeta del párrafo
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Establece el texto del párrafo
    para.setText("Welcome to Aspose.Slides");
    // Establece la sangría de la viñeta
    para.getParagraphFormat().setIndent(25);
    // Establece el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// establecer IsBulletHardColor a true para usar color propio de la viñeta
    // Establece la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    // Añade el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    // Crea el segundo párrafo
    var para2 = new aspose.slides.Paragraph();
    // Establece el tipo y estilo de viñeta del párrafo
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Añade el texto del párrafo
    para2.setText("This is numbered bullet");
    // Establece la sangría de la viñeta
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// establecer IsBulletHardColor a true para usar color propio de la viñeta
    // Establece la altura de la viñeta
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

Las listas con viñetas te ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con viñetas de imagen son fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Carga la imagen en [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Establece el tipo de viñeta a [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) y asigna la imagen.
9. Establece el `Text` del Paragraph.
10. Establece el `Indent` del párrafo para la viñeta.
11. Establece un color para la viñeta.
12. Establece una altura para la viñeta.
13. Añade el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añade el segundo párrafo y repite el proceso basado en los pasos anteriores.
15. Guarda la presentación modificada.

Este código Javascript muestra cómo añadir y gestionar viñetas con imagen:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = presentation.getSlides().get_Item(0);
    // Instancia la imagen para viñetas
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Añade y accede a AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al marco de texto de la AutoShape
    var textFrame = autoShape.getTextFrame();
    // Elimina el párrafo predeterminado
    textFrame.getParagraphs().removeAt(0);
    // Crea un nuevo párrafo
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Establece el estilo y la imagen de viñeta del párrafo
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Establece la altura de la viñeta
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Añade el párrafo al marco de texto
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

Las listas con viñetas te ayudan a organizar y presentar la información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) en la nueva diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) y establece la profundidad en 0.
7. Crea la segunda instancia de párrafo mediante la clase `Paragraph` y establece la profundidad en 1.
8. Crea la tercera instancia de párrafo mediante la clase `Paragraph` y establece la profundidad en 2.
9. Crea la cuarta instancia de párrafo mediante la clase `Paragraph` y establece la profundidad en 3.
10. Añade los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarda la presentación modificada.

Este código Javascript muestra cómo añadir y gestionar viñetas multinivel:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añade y accede a AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al marco de texto del AutoShape creado
    var text = aShp.addTextFrame("");
    // Elimina el párrafo predeterminado
    text.getParagraphs().clear();
    // Añade el primer párrafo
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Establece el nivel de viñeta
    para1.getParagraphFormat().setDepth(0);
    // Añade el segundo párrafo
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Establece el nivel de viñeta
    para2.getParagraphFormat().setDepth(1);
    // Añade el tercer párrafo
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Establece el nivel de viñeta
    para3.getParagraphFormat().setDepth(2);
    // Añade el cuarto párrafo
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Establece el nivel de viñeta
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

La clase [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) y otras que permiten gestionar párrafos con numeración o formato personalizado.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accede a la diapositiva que contiene el párrafo.
3. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) y establece [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) en 2.
7. Crea la segunda instancia de párrafo mediante la clase `Paragraph` y establece `NumberedBulletStartWith` en 3.
8. Crea la tercera instancia de párrafo mediante la clase `Paragraph` y establece `NumberedBulletStartWith` en 7.
9. Añade los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarda la presentación modificada.

Este código Javascript muestra cómo añadir y gestionar párrafos con numeración o formato personalizado:
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


## **Establecer sangría de párrafo**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Accede a la referencia de la diapositiva correspondiente mediante su índice.
1. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Añade un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) con tres párrafos al autoshape rectangular.
1. Oculta las líneas del rectángulo.
1. Establece la sangría para cada [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) mediante su propiedad BulletOffset.
1. Guarda la presentación modificada como archivo PPT.

Este código Javascript muestra cómo establecer una sangría de párrafo:
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir una forma de rectángulo
    var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
    // Añadir un TextFrame al rectángulo
    var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    // Ajustar el texto al contorno de la forma
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Ocultar las líneas del rectángulo
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // Obtener el primer párrafo en el TextFrame y establecer su sangría
    var para1 = tf.getParagraphs().get_Item(0);
    // Establecer el estilo y símbolo de viñeta del párrafo
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // Obtener el segundo párrafo en el TextFrame y establecer su sangría
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // Obtener el tercer párrafo en el TextFrame y establecer su sangría
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // Guardar la presentación en disco
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer sangría francesa para párrafo**

Este código Javascript muestra cómo establecer la sangría francesa para un párrafo:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gestionar propiedades de ejecución al final del párrafo**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtén la referencia de la diapositiva que contiene el párrafo mediante su posición.
1. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Añade un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) con dos párrafos al rectángulo.
1. Establece la `FontHeight` y el tipo de fuente para los párrafos.
1. Establece las propiedades End para los párrafos.
1. Guarda la presentación modificada como archivo PPTX.

Este código Javascript muestra cómo establecer las propiedades End para los párrafos en PowerPoint:
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

Aspose.Slides proporciona soporte mejorado para importar texto HTML en párrafos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
4. Añade y accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la AutoShape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Lee el archivo HTML fuente en un TextReader.
7. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
8. Añade el contenido del archivo HTML leído con TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarda la presentación modificada.

Este código Javascript es una implementación de los pasos para importar textos HTML en párrafos:
```javascript
// Crear instancia vacía de presentación
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Añadir la AutoShape para albergar el contenido HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Añadir un marco de texto a la forma
    ashape.addTextFrame("");
    // Vaciar todos los párrafos del marco de texto añadido
    ashape.getTextFrame().getParagraphs().clear();
    // Cargar el archivo HTML usando un lector de flujo
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Añadir texto del lector de flujo HTML al marco de texto
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

Aspose.Slides proporciona soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y carga la presentación deseada.
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Accede a la forma que contiene el texto que será exportado a HTML.
4. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la forma.
5. Crea una instancia de `StreamWriter` y añade el nuevo archivo HTML.
6. Proporciona un índice inicial a StreamWriter y exporta los párrafos que desees.

Este código Javascript muestra cómo exportar los textos de párrafos de PowerPoint a HTML:
```javascript
// Cargar el archivo de presentación
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Índice deseado
    var index = 0;
    // Acceder a la forma añadida
    var ashape = slide.getShapes().get_Item(index);
    // Crear archivo HTML de salida
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extraer el primer párrafo como HTML
    // Escribir los datos de los párrafos en HTML proporcionando el índice inicial del párrafo y el total de párrafos a copiar
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/), como una imagen. Ambos ejemplos incluyen la obtención de la imagen de una forma que contiene el párrafo mediante los métodos `getImage` de la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), el cálculo de los límites del párrafo dentro de la forma y la exportación como una imagen bitmap. Estos enfoques permiten extraer partes específicas del texto de presentaciones PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Example 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el cuadro de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesitas guardar un párrafo específico como una imagen separada manteniendo las dimensiones y el formato exactos del texto.
```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guardar la forma en memoria como un mapa de bits.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Crear un mapa de bits de la forma a partir de la memoria.
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

    // Recortar el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
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

**Example 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite obtener una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para usar en materiales impresos de alta calidad.
```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guardar la forma en memoria como un mapa de bits con escalado.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Crear un mapa de bits de la forma a partir de la memoria.
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

    // Recortar el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
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

**¿Puedo desactivar por completo el ajuste de línea dentro de un cuadro de texto?**

Sí. Usa la configuración de ajuste del cuadro de texto ([setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puedes obtener el rectángulo delimitador del párrafo (e incluso de un fragmento único) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) es un método de configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato de los fragmentos individuales.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte del párrafo (p. ej., una palabra)?**

Sí. El idioma se establece a nivel de fragmento ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.