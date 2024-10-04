---
title: Administrar párrafos de PowerPoint en Java
type: docs
weight: 40
url: /androidjava/manage-paragraph/
keywords: "Agregar párrafo de PowerPoint, Administrar párrafos, Sangría de párrafo, Propiedades de párrafo, Texto HTML, Exportar texto de párrafo, Presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Crear y gestionar párrafos, texto, sangrías y propiedades en presentaciones de PowerPoint en Java"
---

Aspose.Slides proporciona todas las interfaces y clases que necesitas para trabajar con textos, párrafos y porciones de PowerPoint en Java.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) para permitirte agregar objetos que representan un párrafo. Un objeto `ITextFrame` puede tener uno o varios párrafos (cada párrafo se crea a través de un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) para permitirte agregar objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) para permitirte agregar objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos `IPortion` subyacentes.

## **Agregar múltiples párrafos que contengan múltiples porciones**

Estos pasos te muestran cómo agregar un marco de texto que contenga 3 párrafos y cada párrafo contenga 3 porciones:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva relevante a través de su índice.
3. Agrega un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Rectángulo a la diapositiva.
4. Obtén el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
5. Crea dos objetos [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) y agrégales a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
6. Crea tres objetos [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo por defecto) y agrega cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establece algún texto para cada porción.
8. Aplica tus características de formato preferidas a cada porción utilizando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarda la presentación modificada.

Este código Java es una implementación de los pasos para agregar párrafos que contienen porciones:

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega un AutoShape de tipo Rectángulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accede al TextFrame del AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Crea Párrafos y Porciones con diferentes formatos de texto
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

    //Escribe PPTX en el disco
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gestionar viñetas en párrafos**

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva relevante a través de su índice.
3. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo por defecto en el `TextFrame`.
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Establece el `Tipo` de viñeta para el párrafo como `Símbolo` y establece el carácter de la viñeta.
8. Establece el `Texto` del párrafo.
9. Establece la `Sangría` del párrafo para la viñeta.
10. Establece un color para la viñeta.
11. Establece una altura para la viñeta.
12. Agrega el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Agrega el segundo párrafo y repite el proceso dado en los pasos 7 a 13.
14. Guarda la presentación.

Este código Java te muestra cómo agregar una viñeta de párrafo:

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

    // Elimina el párrafo por defecto
    txtFrm.getParagraphs().removeAt(0);

    // Crea un párrafo
    Paragraph para = new Paragraph();

    // Establece un estilo de viñeta de párrafo y símbolo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Establece el texto del párrafo
    para.setText("Bienvenido a Aspose.Slides");

    // Establece la sangría de la viñeta
    para.getParagraphFormat().setIndent(25);

    // Establece el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establece IsBulletHardColor como verdadero para usar el color de viñeta propio

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
    para2.setText("Este es un párrafo numerado");

    // Establece la sangría de la viñeta
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establece IsBulletHardColor como verdadero para usar el color de viñeta propio

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


## **Administrar viñetas de imagen**

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva relevante a través de su índice.
3. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo por defecto en el `TextFrame`.
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Carga la imagen en [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. Establece el tipo de viñeta como [Imagen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) y establece la imagen.
9. Establece el `Texto` del párrafo.
10. Establece la `Sangría` del párrafo para la viñeta.
11. Establece un color para la viñeta.
12. Establece una altura para la viñeta.
13. Agrega el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agrega el segundo párrafo y repite el proceso basado en los pasos anteriores.
15. Guarda la presentación modificada.

Este código Java te muestra cómo agregar y gestionar viñetas de imagen:

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instancia la imagen para bulletes
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Agrega y accede al Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al textframe del autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Elimina el párrafo por defecto
    textFrame.getParagraphs().removeAt(0);

    // Crea un nuevo párrafo
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Bienvenido a Aspose.Slides");

    // Establece el estilo de viñeta de párrafo y la imagen
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

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente. Las viñetas de múltiples niveles son fáciles de leer y comprender.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva relevante a través de su índice.
3. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) en la nueva diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo por defecto en el `TextFrame`.
6. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) y establece la profundidad en 0.
7. Crea la segunda instancia de párrafo a través de la clase `Paragraph` y establece la profundidad en 1.
8. Crea la tercera instancia de párrafo a través de la clase `Paragraph` y establece la profundidad en 2.
9. Crea la cuarta instancia de párrafo a través de la clase `Paragraph` y establece la profundidad en 3.
10. Agrega los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarda la presentación modificada.

Este código Java te muestra cómo agregar y gestionar viñetas de múltiples niveles:

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

    // Limpia el párrafo por defecto
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

    // Agrega los párrafos a la colección
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


## **Gestionar párrafo con lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) y otras que te permiten gestionar párrafos con numeración o formato personalizado.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accede a la diapositiva que contiene el párrafo.
3. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) del autoshape.
5. Elimina el párrafo por defecto en el `TextFrame`.
6. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) y establece [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en 2.
7. Crea la segunda instancia de párrafo a través de la clase `Paragraph` y establece `NumberedBulletStartWith` en 3.
8. Crea la tercera instancia de párrafo a través de la clase `Paragraph` y establece `NumberedBulletStartWith` en 7.
9. Agrega los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarda la presentación modificada.

Este código Java te muestra cómo agregar y gestionar párrafos con numeración o formato personalizado:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al marco de texto del autoshape creado
    ITextFrame textFrame = shape.getTextFrame();

    // Elimina el párrafo existente por defecto
    textFrame.getParagraphs().removeAt(0);

    // Primer párrafo
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


## **Establecer sangría en párrafo**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Accede a la referencia de la diapositiva relevante a través de su índice.
1. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Rectángulo a la diapositiva.
1. Agrega un [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) con tres párrafos al autoshape.
1. Oculta las líneas del rectángulo.
1. Establece la sangría para cada [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) a través de su propiedad BulletOffset.
1. Escribe la presentación modificada como un archivo PPT.

Este código Java te muestra cómo establecer una sangría en un párrafo:

```java
// Instancia la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agrega una forma rectangular
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Agrega un TextFrame al rectángulo
    ITextFrame tf = rect.addTextFrame("Esta es la primera línea \rEsta es la segunda línea \rEsta es la tercera línea");
    
    // Ajusta el texto para que se ajuste a la forma
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Oculta las líneas del rectángulo
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Obtiene el primer párrafo en el TextFrame y establece su sangría
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Estableciendo el estilo de viñeta y símbolo del párrafo
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Obtiene el segundo párrafo en el TextFrame y establece su sangría
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Obtiene el tercer párrafo en el TextFrame y establece su sangría
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    //Escribe la presentación en disco
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer sangría colgante en párrafo**

Este código Java te muestra cómo establecer la sangría colgante para un párrafo:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Ejemplo");

    Paragraph para2 = new Paragraph();
    para2.setText("Establecer sangría colgante para párrafo");

    Paragraph para3 = new Paragraph();
    para3.setText("Este código C# te muestra cómo establecer la sangría colgante para un párrafo: ");

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

## **Gestionar propiedades de ejecución final del párrafo**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtiene la referencia para la diapositiva que contiene el párrafo a través de su posición.
1. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Agrega un [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) con dos párrafos al rectángulo.
1. Establece el `FontHeight` y el tipo de fuente para los párrafos.
1. Establece las propiedades finales para los párrafos.
1. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo establecer las propiedades finales para los párrafos en PowerPoint: 

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

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Importar texto HTML a párrafos**

Aspose.Slides proporciona un mejor soporte para importar texto HTML a párrafos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accede a la referencia de la diapositiva relevante a través de su índice.
3. Agrega un [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Agrega y accede al `autoshape` [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
5. Elimina el párrafo por defecto en el `ITextFrame`.
6. Lee el archivo HTML de origen en un TextReader.
7. Crea la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. Agrega el contenido del archivo HTML en el TextReader leído a la colección de [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) del TextFrame.
9. Guarda la presentación modificada.

Este código Java es una implementación de los pasos para importar textos HTML en párrafos:

```java
// Crea una instancia vacía de presentación
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva por defecto de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadiendo el AutoShape para acomodar el contenido HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Añadiendo marco de texto a la forma
    ashape.addTextFrame("");

    // Limpiando todos los párrafos en el marco de texto añadido
    ashape.getTextFrame().getParagraphs().clear();

    // Cargando el archivo HTML utilizando un lector de flujo
    TextReader tr = new StreamReader("file.html");

    // Añadiendo el texto del lector de flujo HTML al marco de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Guardando la presentación
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exportar texto de párrafos a HTML**

Aspose.Slides proporciona un mejor soporte para exportar textos (contenidos en párrafos) a HTML.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y carga la presentación deseada.
2. Accede a la referencia de la diapositiva relevante a través de su índice.
3. Accede a la forma que contiene el texto que se exportará a HTML.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) de la forma.
5. Crea una instancia de `StreamWriter` y agrega el nuevo archivo HTML.
6. Proporciona un índice de inicio a StreamWriter y exporta los párrafos que prefieras.

Este código Java te muestra cómo exportar los textos de párrafo de PowerPoint a HTML:

```java
// Carga el archivo de presentación
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Accede a la primera diapositiva por defecto de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Índice deseado
    int index = 0;

    // Acceso a la forma añadida
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Crea el archivo HTML de salida
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extrae el primer párrafo como HTML
    // Escribe los datos de los párrafos en HTML proporcionando el índice inicial del párrafo, el total de párrafos que se copiarán
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```