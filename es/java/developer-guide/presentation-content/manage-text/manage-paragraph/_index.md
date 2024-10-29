---
title: Gestionar párrafos de PowerPoint en Java
type: docs
weight: 40
url: /es/java/manage-paragraph/
keywords: "Agregar párrafo de PowerPoint, Gestionar párrafos, Sangría de párrafo, Propiedades de párrafo, Texto HTML, Exportar texto de párrafo, Presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Crear y gestionar párrafos, texto, sangrías y propiedades en presentaciones de PowerPoint en Java"
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en Java.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) para permitirle agregar objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea a través de un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) para permitirle agregar objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) para permitirle agregar objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar múltiples párrafos que contienen múltiples porciones**

Estos pasos le muestran cómo agregar un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 porciones:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva relevante a través de su índice.
3. Agregar un rectángulo [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Obtener el ITextFrame asociado con [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
5. Crear dos objetos [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) y agregarlos a la colección `IParagraphs` de [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
6. Crear tres objetos [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos de Porción para el párrafo predeterminado) y agregar cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establecer algún texto para cada porción.
8. Aplicar sus características de formato preferidas a cada porción utilizando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guardar la presentación modificada.

Este código Java es una implementación de los pasos para agregar párrafos que contienen porciones:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectángulo
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

## **Gestionar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y entender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva relevante a través de su índice.
3. Agregar un [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) del autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Establecer el `Type` de viñeta para el párrafo a `Symbol` y establecer el carácter de viñeta.
8. Establecer el `Text` del párrafo.
9. Establecer la `Indent` del párrafo para la viñeta.
10. Establecer un color para la viñeta.
11. Establecer una altura de la viñeta.
12. Agregar el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Agregar el segundo párrafo y repetir el proceso dado en los pasos 7 a 13.
14. Guardar la presentación.

Este código Java le muestra cómo agregar una viñeta de párrafo:

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agrega y accede al Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Elimina el párrafo predeterminado
    txtFrm.getParagraphs().removeAt(0);

    // Crea un párrafo
    Paragraph para = new Paragraph();

    // Establece un estilo y símbolo de viñeta para el párrafo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Establece el texto del párrafo
    para.setText("Bienvenido a Aspose.Slides");

    // Establece la indentación de la viñeta
    para.getParagraphFormat().setIndent(25);

    // Establece el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establece IsBulletHardColor en true para usar el color de viñeta propio

    // Establece la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);

    // Agrega el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);

    // Crea el segundo párrafo
    Paragraph para2 = new Paragraph();

    // Establece el tipo y estilo de viñeta del párrafo
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Agrega el texto del párrafo
    para2.setText("Este es un número de viñeta");

    // Establece la indentación de la viñeta
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establece IsBulletHardColor en true para usar el color de viñeta propio

    // Establece la altura de la viñeta
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Agrega el párrafo al marco de texto
    txtFrm.getParagraphs().add(para2);
    
    // Guarda la presentación modificada
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos de imagen son fáciles de leer y entender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva relevante a través de su índice.
3. Agregar un [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) del autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Cargar la imagen en [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. Establecer el tipo de viñeta en [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) y establecer la imagen.
9. Establecer el `Text` del párrafo.
10. Establecer la `Indent` del párrafo para la viñeta.
11. Establecer un color para la viñeta.
12. Establecer una altura para la viñeta.
13. Agregar el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregar el segundo párrafo y repetir el proceso basado en los pasos anteriores.
15. Guardar la presentación modificada.

Este código Java le muestra cómo agregar y gestionar viñetas de imagen:

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
    // Agrega y accede al Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Elimina el párrafo predeterminado
    textFrame.getParagraphs().removeAt(0);

    // Crea un nuevo párrafo
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Bienvenido a Aspose.Slides");

    // Establece el estilo y la imagen de la viñeta del párrafo
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Establece la altura de la viñeta
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Agrega el párrafo al marco de texto
    textFrame.getParagraphs().add(paragraph);

    // Escribe la presentación como un archivo PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Escribe la presentación como un archivo PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gestionar viñetas de múltiples niveles**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas de múltiples niveles son fáciles de leer y entender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva relevante a través de su índice.
3. Agregar un [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) del autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) y establecer la profundidad en 0.
7. Crear la segunda instancia de párrafo a través de la clase `Paragraph` y establecer la profundidad en 1.
8. Crear la tercera instancia de párrafo a través de la clase `Paragraph` y establecer la profundidad en 2.
9. Crear la cuarta instancia de párrafo a través de la clase `Paragraph` y establecer la profundidad en 3.
10. Agregar los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guardar la presentación modificada.

Este código Java le muestra cómo agregar y gestionar viñetas de múltiples niveles:

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega y accede al Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame text = aShp.addTextFrame("");

    // Limpia el párrafo predeterminado
    text.getParagraphs().clear();

    // Agrega el primer párrafo
    IParagraph para1 = new Paragraph();
    para1.setText("Contenido");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de la viñeta
    para1.getParagraphFormat().setDepth((short)0);

    // Agrega el segundo párrafo
    IParagraph para2 = new Paragraph();
    para2.setText("Segundo Nivel");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de la viñeta
    para2.getParagraphFormat().setDepth((short)1);

    // Agrega el tercer párrafo
    IParagraph para3 = new Paragraph();
    para3.setText("Tercer Nivel");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de la viñeta
    para3.getParagraphFormat().setDepth((short)2);

    // Agrega el cuarto párrafo
    IParagraph para4 = new Paragraph();
    para4.setText("Cuarto Nivel");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Establece el nivel de la viñeta
    para4.getParagraphFormat().setDepth((short)3);

    // Agrega párrafos a la colección
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Escribe la presentación como un archivo PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar párrafos con lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) y otras que le permiten gestionar párrafos con numeración o formato personalizado.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceder a la diapositiva que contiene el párrafo.
3. Agregar un [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) del autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) y establecer [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en 2.
7. Crear la segunda instancia de párrafo a través de la clase `Paragraph` y establecer `NumberedBulletStartWith` en 3.
8. Crear la tercera instancia de párrafo a través de la clase `Paragraph` y establecer `NumberedBulletStartWith` en 7.
9. Agregar los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guardar la presentación modificada.

Este código Java le muestra cómo agregar y gestionar párrafos con numeración o formato personalizado:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accede al marco de texto del autoshape creado
    ITextFrame textFrame = shape.getTextFrame();

    // Elimina el párrafo existente predeterminado
    textFrame.getParagraphs().removeAt(0);

    // Primer lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("viñeta 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("viñeta 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("viñeta 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Establecer sangría de párrafo**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Acceder a la referencia de la diapositiva relevante a través de su índice.
1. Agregar un rectángulo [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva.
1. Agregar un [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) con tres párrafos al autoshape rectangular.
1. Ocultar las líneas del rectángulo.
1. Establecer la sangría para cada [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) a través de su propiedad BulletOffset.
1. Escribir la presentación modificada como un archivo PPT.

Este código Java le muestra cómo establecer la sangría de un párrafo:

```java
// Instanciar clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agregar una forma de rectángulo
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Agregar TextFrame al rectángulo
    ITextFrame tf = rect.addTextFrame("Esta es la primera línea \rEsta es la segunda línea \rEsta es la tercera línea");
    
    // Ajustar el texto para que se adapte a la forma
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Ocultar las líneas del rectángulo
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Obtener el primer párrafo en el TextFrame y establecer su sangría
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Establecer estilo y símbolo de viñeta del párrafo
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Obtener el segundo párrafo en el TextFrame y establecer su sangría
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Obtener el tercer párrafo en el TextFrame y establecer su sangría
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // Escribir la presentación en disco
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer sangría colgante para párrafo**

Este código Java le muestra cómo establecer la sangría colgante para un párrafo:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Ejemplo");

    Paragraph para2 = new Paragraph();
    para2.setText("Establecer sangría colgante para párrafo");

    Paragraph para3 = new Paragraph();
    para3.setText("Este código C# le muestra cómo establecer la sangría colgante para un párrafo: ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar propiedades del final del párrafo para párrafo**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Obtener la referencia de la diapositiva que contiene el párrafo a través de su posición.
1. Agregar un [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva.
1. Agregar un [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) con dos párrafos al rectángulo.
1. Establecer la `FontHeight` y el tipo de fuente para los párrafos.
1. Establecer las propiedades finales para los párrafos.
1. Escribir la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo establecer las propiedades finales para párrafos en PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Texto de ejemplo"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Texto de ejemplo 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath + "pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Importar texto HTML en párrafos**

Aspose.Slides proporciona un soporte mejorado para importar texto HTML en párrafos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Acceder a la referencia de la diapositiva relevante a través de su índice.
3. Agregar un [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Agregar y acceder al autoshape [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
5. Eliminar el párrafo predeterminado en el `ITextFrame`.
6. Leer el archivo HTML de origen en un TextReader.
7. Crear la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
8. Agregar el contenido del archivo HTML en el TextReader leído a la [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/) del TextFrame.
9. Guardar la presentación modificada.

Este código Java es una implementación de los pasos para importar textos HTML en párrafos:

```java
// Crear una instancia de presentación vacía
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar el AutoShape para acomodar el contenido HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Agregar marco de texto a la forma
    ashape.addTextFrame("");

    // Limpiar todos los párrafos en el marco de texto agregado
    ashape.getTextFrame().getParagraphs().clear();

    // Cargar el archivo HTML usando el lector de flujo
    TextReader tr = new StreamReader("file.html");

    // Agregar el texto desde el lector de flujo HTML en el marco de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Guardar la presentación
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportar texto de párrafos a HTML**

Aspose.Slides proporciona un soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y cargar la presentación deseada.
2. Acceder a la referencia de la diapositiva relevante a través de su índice.
3. Acceder a la forma que contiene el texto que se exportará a HTML.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) de la forma.
5. Crear una instancia de `StreamWriter` y agregar el nuevo archivo HTML.
6. Proporcionar un índice inicial a StreamWriter y exportar sus párrafos preferidos.

Este código Java le muestra cómo exportar los textos de párrafos de PowerPoint a HTML:

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

    // Extraer el primer párrafo como HTML
    // Escribir los datos de los párrafos en HTML proporcionando el índice inicial del párrafo, el total de párrafos a copiar
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```