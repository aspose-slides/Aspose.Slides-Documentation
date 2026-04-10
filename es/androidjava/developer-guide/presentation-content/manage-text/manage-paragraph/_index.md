---
title: Gestionar párrafos de texto de PowerPoint en Android
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/androidjava/manage-paragraph/
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
- Android
- Java
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para Android—optimiza la alineación, el espaciado y el estilo en presentaciones PPT, PPTX y ODP en Java."
---
Aspose.Slides proporciona todas las interfaces y clases que necesitas para trabajar con textos, párrafos y fragmentos de PowerPoint en Java.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) para permitirte añadir objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/) para permitirte añadir objetos que representan fragmentos. Un objeto `IParagraph` puede tener uno o varios fragmentos (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/) para permitirte añadir objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato mediante sus objetos subyacentes `IPortion`.

## **Agregar varios párrafos que contengan varios fragmentos de texto**

Estos pasos te muestran cómo añadir un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 fragmentos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade un rectángulo [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Obtén el ITextFrame asociado al [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/).
5. Crea dos objetos [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/) y añádelos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/).
6. Crea tres objetos [IPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y añade cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establece algún texto para cada fragmento.
8. Aplica tus características de formato preferidas a cada fragmento usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarda la presentación modificada.

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectángulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Acceder al TextFrame del AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Crear párrafos y porciones con diferentes formatos de texto
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Escribir PPTX en disco
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Administrar viñetas de párrafo**

Las listas con viñetas te ayudan a organizar y presentar información de forma rápida y eficaz. Los párrafos con viñetas son siempre más fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade un [autoshape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/).
7. Establece el `Type` de viñeta del párrafo a `Symbol` y define el carácter de viñeta.
8. Establece el `Text` del párrafo.
9. Establece el `Indent` del párrafo para la viñeta.
10. Define un color para la viñeta.
11. Define una altura para la viñeta.
12. Añade el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Añade el segundo párrafo y repite el proceso descrito en los pasos 7 a 13.
14. Guarda la presentación.

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añade y accede a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Elimina el párrafo predeterminado
    txtFrm.getParagraphs().removeAt(0);

    // Crea un párrafo
    Paragraph para = new Paragraph();

    // Establece el estilo y símbolo de viñeta del párrafo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Establece el texto del párrafo
    para.setText("Welcome to Aspose.Slides");

    // Establece la sangría de la viñeta
    para.getParagraphFormat().setIndent(25);

    // Establece el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establecer IsBulletHardColor a true para usar un color de viñeta propio

    // Establece la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);

    // Añade el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);

    // Crea el segundo párrafo
    Paragraph para2 = new Paragraph();

    // Establece el tipo y estilo de viñeta del párrafo
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Añade texto al párrafo
    para2.setText("This is numbered bullet");

    // Establece la sangría de la viñeta
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establecer IsBulletHardColor a true para usar un color de viñeta propio

    // Establece la altura de la viñeta
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Añade el párrafo al marco de texto
    txtFrm.getParagraphs().add(para2);
    
    // Guarda la presentación modificada
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Administrar viñetas de imagen**

Las listas con viñetas te ayudan a organizar y presentar información de forma rápida y eficaz. Los párrafos con imagen son fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade un [autoshape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/).
7. Carga la imagen en [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/).
8. Establece el tipo de viñeta a [Picture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) y asigna la imagen.
9. Establece el `Text` del Paragraph.
10. Establece el `Indent` del Paragraph para la viñeta.
11. Define un color para la viñeta.
12. Define una altura para la viñeta.
13. Añade el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añade el segundo párrafo y repite el proceso basado en los pasos anteriores.
15. Guarda la presentación modificada.

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instancia la imagen para viñetas
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Añade y accede a Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Elimina el párrafo predeterminado
    textFrame.getParagraphs().removeAt(0);

    // Crea un nuevo párrafo
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Establece el estilo de viñeta del párrafo y la imagen
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Establece la altura de la viñeta
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Añade el párrafo al marco de texto
    textFrame.getParagraphs().add(paragraph);

    // Guarda la presentación como archivo PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Guarda la presentación como archivo PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Administrar viñetas multinivel**

Las listas con viñetas te ayudan a organizar y presentar información de forma rápida y eficaz. Las viñetas multinivel son fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade un [autoshape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) en la nueva diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/) y establece la profundidad en 0.
7. Crea la segunda instancia de párrafo a través de la clase `Paragraph` y establece la profundidad en 1.
8. Crea la tercera instancia de párrafo a través de la clase `Paragraph` y establece la profundidad en 2.
9. Crea la cuarta instancia de párrafo a través de la clase `Paragraph` y establece la profundidad en 3.
10. Añade los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarda la presentación modificada.

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añade y accede al Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame text = aShp.addTextFrame("");

    // Elimina el párrafo predeterminado
    text.getParagraphs().clear();

    // Añade el primer párrafo
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de viñeta
    para1.getParagraphFormat().setDepth((short)0);

    // Añade el segundo párrafo
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de viñeta
    para2.getParagraphFormat().setDepth((short)1);

    // Añade el tercer párrafo
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de viñeta
    para3.getParagraphFormat().setDepth((short)2);

    // Añade el cuarto párrafo
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de viñeta
    para4.getParagraphFormat().setDepth((short)3);

    // Añade los párrafos a la colección
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Guarda la presentación como archivo PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Administrar un párrafo con una lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) y otras que permiten gestionar párrafos con numeración o formato personalizados.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la diapositiva que contiene el párrafo.
3. Añade un [autoshape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo predeterminado en el `TextFrame`.
6. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/) y establece [NumberedBulletStartWith](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a 2.
7. Crea la segunda instancia de párrafo a través de la clase `Paragraph` y establece `NumberedBulletStartWith` a 3.
8. Crea la tercera instancia de párrafo a través de la clase `Paragraph` y establece `NumberedBulletStartWith` a 7.
9. Añade los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarda la presentación modificada.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame textFrame = shape.getTextFrame();

    // Elimina el párrafo predeterminado existente
    textFrame.getParagraphs().removeAt(0);

    // Primera lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Establecer sangría de primera línea para un párrafo**

Utiliza el método [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para controlar la sangría de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de líneas permanece alineado al cuerpo del párrafo.

Usa [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) cuando necesites mover todo el párrafo. Usa [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) cuando solo necesites mover la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de sangría para demostrar cómo afecta la sangría de primera línea al diseño del párrafo.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la diapositiva objetivo.
3. Añade un [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añade un [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/) vacío a la forma y elimina el párrafo predeterminado.
5. Crea varios párrafos y establece diferentes valores de [Indent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para ellos.
6. Añade los párrafos al marco de texto.
7. Guarda la presentación modificada.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

## **Establecer sangría francesa para un párrafo**

Una sangría francesa es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, creas este efecto con el método [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Establece la sangría a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) define la posición de la primera línea respecto a ese margen. Para crear una sangría francesa, establece un valor positivo en `MarginLeft` y un valor negativo en `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo en lugar de bajo el primer carácter de la primera línea.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la diapositiva objetivo.
3. Añade un [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añade un [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/) vacío a la forma y elimina el párrafo predeterminado.
5. Crea párrafos y establece un valor positivo de [MarginLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) para cada párrafo.
6. Establece un valor negativo de [Indent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para crear el efecto de sangría francesa.
7. Añade los párrafos al marco de texto.
8. Guarda la presentación modificada.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

El resultado:

![La sangría francesa de los párrafos](hanging_indent.png)

## **Administrar propiedades de ejecución de fin de párrafo**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
1. Obtén la referencia de la diapositiva que contiene el párrafo mediante su posición.
1. Añade un [autoshape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) rectangular a la diapositiva.
1. Añade un [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) con dos párrafos al rectángulo.
1. Establece `FontHeight` y el tipo de fuente para los párrafos.
1. Establece las propiedades End para los párrafos.
1. Escribe la presentación modificada como un archivo PPTX.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Importar texto HTML en párrafos**

Aspose.Slides proporciona un soporte mejorado para la importación de texto HTML en párrafos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Añade un [autoshape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Añade y accede al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo predeterminado en el `ITextFrame`.
6. Lee el archivo HTML fuente en un TextReader.
7. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/).
8. Añade el contenido del archivo HTML leído con el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphcollection/) del TextFrame.
9. Guarda la presentación modificada.

```java
// Crear una instancia de presentación vacía
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir el AutoShape para acomodar el contenido HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Añadir el marco de texto a la forma
    ashape.addTextFrame("");

    // Limpiar todos los párrafos en el marco de texto añadido
    ashape.getTextFrame().getParagraphs().clear();

    // Cargar el archivo HTML usando un lector de flujo
    TextReader tr = new StreamReader("file.html");

    // Añadir texto del lector de flujo HTML al marco de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Guardar la presentación
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportar texto de párrafo a HTML**

Aspose.Slides proporciona un soporte mejorado para la exportación de textos (contenidos en párrafos) a HTML.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y carga la presentación deseada.
2. Accede a la referencia de la diapositiva correspondiente mediante su índice.
3. Accede a la forma que contiene el texto que se exportará a HTML.
4. Accede al [TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/) de la forma.
5. Crea una instancia de `StreamWriter` y añade el nuevo archivo HTML.
6. Proporciona un índice de inicio a StreamWriter y exporta los párrafos que desees.

```java
// Cargar el archivo de presentación
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Índice deseado
    int index = 0;

    // Acceder a la forma añadida
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Crear archivo HTML de salida
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extrayendo el primer párrafo como HTML
    // Escribiendo datos de los párrafos a HTML proporcionando el índice de inicio del párrafo, el total de párrafos a copiar
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la interfaz [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/), como una imagen. Ambos ejemplos incluyen la obtención de la imagen de una forma que contiene el párrafo usando los métodos `getImage` de la interfaz [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/), el cálculo de los límites del párrafo dentro de la forma y su exportación como una imagen bitmap. Estos enfoques permiten extraer partes específicas del texto de presentaciones PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil para su uso posterior en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesitas guardar un párrafo específico como una imagen independiente conservando sus dimensiones y formato exactos.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guardar la forma en memoria como un bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crear un bitmap de la forma desde la memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. A continuación, se calculan los límites del párrafo teniendo en cuenta la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para su uso en materiales impresos de alta calidad.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guardar la forma en memoria como un bitmap con escalado.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crear un bitmap de la forma desde la memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo desactivar por completo el ajuste de línea dentro de un marco de texto?**

Sí. Utiliza la configuración de ajuste del marco de texto ([setWrapText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puedes recuperar el rectángulo delimitador del párrafo (e incluso de un único fragmento) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphformat/); se aplica a todo el párrafo independientemente del formato individual de los fragmentos.

**¿Puedo establecer un idioma de revisión ortográfica solo para una parte del párrafo (por ejemplo, una palabra)?**

Sí. El idioma se establece a nivel de fragmento ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.