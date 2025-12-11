---
title: Administrar párrafos de texto de PowerPoint en Android
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/androidjava/manage-paragraph/
keywords:
- agregar texto
- agregar párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades de párrafo
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
description: "Domina el formato de párrafos con Aspose.Slides para Android—optimiza alineación, espaciado y estilo en presentaciones PPT, PPTX y ODP en Java."
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en Java.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) para permitirle agregar objetos que representan un párrafo. Un objeto `ITextFame` puede contener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) para permitirle agregar objetos que representan porciones. Un objeto `IParagraph` puede contener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) para permitirle agregar objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar varios párrafos que contienen varias porciones de texto**

Estos pasos le muestran cómo agregar un marco de texto que contenga 3 párrafos y cada párrafo contenga 3 porciones:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar un rectángulo [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Obtener el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
5. Crear dos objetos [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) y añadirlos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
6. Crear tres objetos [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y añadir cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establecer algún texto para cada porción.
8. Aplicar sus características de formato preferidas a cada porción usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guardar la presentación modificada.

Este código Java es una implementación de los pasos para agregar párrafos que contienen porciones:
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

    //Guardar PPTX en disco
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **Administrar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Establecer el `Type` de viñeta del párrafo a `Symbol` y definir el carácter de la viñeta.
8. Establecer el `Text` del párrafo.
9. Establecer la `Indent` del párrafo para la viñeta.
10. Definir un color para la viñeta.
11. Definir una altura para la viñeta.
12. Añadir el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Añadir el segundo párrafo y repetir el proceso descrito en los pasos 7 a 13.
14. Guardar la presentación.

Este código Java le muestra cómo agregar una viñeta de párrafo:
```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añade y accede a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accede al cuadro de texto del autoshape
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
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establecer IsBulletHardColor a verdadero para usar el propio color de viñeta

    // Establece la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);

    // Añade el párrafo al cuadro de texto
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
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // establecer IsBulletHardColor a verdadero para usar el propio color de viñeta

    // Establece la altura de la viñeta
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Añade el párrafo al cuadro de texto
    txtFrm.getParagraphs().add(para2);
    
    // Guarda la presentación modificada
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **Administrar viñetas con imágenes**

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Cargar la imagen en [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. Establecer el tipo de viñeta a [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) y asignar la imagen.
9. Establecer el `Text` del párrafo.
10. Establecer la `Indent` del párrafo para la viñeta.
11. Definir un color para la viñeta.
12. Definir una altura para la viñeta.
13. Añadir el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añadir el segundo párrafo y repetir el proceso basado en los pasos anteriores.
15. Guardar la presentación modificada.

Este código Java le muestra cómo agregar y administrar viñetas con imágenes:
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
    // Añade y accede a AutoShape
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

Las listas con viñetas le ayudan a organizar y presentar la información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) y establecer la profundidad en 0.
7. Crear la segunda instancia de párrafo mediante la clase `Paragraph` y establecer la profundidad en 1.
8. Crear la tercera instancia de párrafo mediante la clase `Paragraph` y establecer la profundidad en 2.
9. Crear la cuarta instancia de párrafo mediante la clase `Paragraph` y establecer la profundidad en 3.
10. Añadir los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guardar la presentación modificada.

Este código Java le muestra cómo agregar y administrar viñetas multinivel:
```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añade y accede a Autoshape
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

La interfaz [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) y otras que le permiten gestionar párrafos con numeración o formato personalizados.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acceder a la diapositiva que contiene el párrafo.
3. Agregar una [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `TextFrame`.
6. Crear la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) y establecer [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en 2.
7. Crear la segunda instancia de párrafo mediante la clase `Paragraph` y establecer `NumberedBulletStartWith` en 3.
8. Crear la tercera instancia de párrafo mediante la clase `Paragraph` y establecer `NumberedBulletStartWith` en 7.
9. Añadir los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guardar la presentación modificada.

Este código Java le muestra cómo agregar y administrar párrafos con numeración o formato personalizados:
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



## **Establecer sangría de párrafo**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
1. Agregar un rectángulo [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Añadir un [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) con tres párrafos al rectángulo autoshape.
1. Ocultar las líneas del rectángulo.
1. Establecer la sangría para cada [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) mediante su propiedad `BulletOffset`.
1. Guardar la presentación modificada como un archivo PPT.

Este código Java le muestra cómo establecer una sangría de párrafo:
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añadir una forma rectangular
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Añadir TextFrame al rectángulo
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // Ajustar el texto al tamaño de la forma
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Ocultar las líneas del rectángulo
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Obtener el primer párrafo del TextFrame y establecer su sangría
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Configurar el estilo y símbolo de viñeta del párrafo
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Obtener el segundo párrafo del TextFrame y establecer su sangría
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Obtener el tercer párrafo del TextFrame y establecer su sangría
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


## **Establecer sangría colgante para un párrafo**

Este código Java le muestra cómo establecer la sangría colgante para un párrafo:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Example");

    Paragraph para2 = new Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");

    Paragraph para3 = new Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");

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


## **Administrar propiedades de ejecución de final de párrafo**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener la referencia de la diapositiva que contiene el párrafo mediante su posición.
1. Agregar un rectángulo [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Añadir un [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) con dos párrafos al rectángulo.
1. Establecer el `FontHeight` y el tipo de fuente para los párrafos.
1. Establecer las propiedades de Final para los párrafos.
1. Guardar la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo establecer las propiedades de Final para los párrafos en PowerPoint:
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

Aspose.Slides ofrece soporte mejorado para importar texto HTML en párrafos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Agregar una [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
4. Añadir y acceder al [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de la autoshape.
5. Eliminar el párrafo predeterminado en el `ITextFrame`.
6. Leer el archivo HTML fuente en un TextReader.
7. Crear la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. Añadir el contenido del archivo HTML leído por el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) del TextFrame.
9. Guardar la presentación modificada.

Este código Java es una implementación de los pasos para importar textos HTML en párrafos:
```java
// Crear instancia vacía de presentación
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar AutoShape para alojar el contenido HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Agregar cuadro de texto a la forma
    ashape.addTextFrame("");

    // Limpiar todos los párrafos del cuadro de texto agregado
    ashape.getTextFrame().getParagraphs().clear();

    // Cargar el archivo HTML usando StreamReader
    TextReader tr = new StreamReader("file.html");

    // Añadir texto del lector de flujo HTML al cuadro de texto
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Guardar presentación
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **Exportar texto de párrafo a HTML**

Aspose.Slides ofrece soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y cargar la presentación deseada.
2. Acceder a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceder a la forma que contiene el texto que se exportará a HTML.
4. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) de la forma.
5. Crear una instancia de `StreamWriter` y añadir el nuevo archivo HTML.
6. Proporcionar un índice inicial a StreamWriter y exportar los párrafos que desee.

Este código Java le muestra cómo exportar textos de párrafos de PowerPoint a HTML:
```java
// Cargar el archivo de presentación
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Acceder a la primera diapositiva predeterminada de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Índice deseado
    int index = 0;

    // Accediendo a la forma agregada
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Crear archivo HTML de salida
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extraer el primer párrafo como HTML
    // Escribir datos de los párrafos a HTML proporcionando el índice inicial del párrafo, el total de párrafos a copiar
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la interfaz [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/), como una imagen. Ambos ejemplos incluyen la obtención de la imagen de una forma que contiene el párrafo mediante los métodos `getImage` de la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), el cálculo de los límites del párrafo dentro de la forma y la exportación como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar sobre una nueva imagen bitmap, que se guarda en formato PNG. Este método es particularmente útil cuando necesita guardar un párrafo específico como una imagen independiente conservando las dimensiones y el formato exactos del texto.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Guarda la forma en memoria como un mapa de bits.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Crea un mapa de bits de la forma desde la memoria.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calcula los límites del segundo párrafo.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Calcula las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recorta el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


El resultado:

![The paragraph image](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para materiales impresos de alta calidad.
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

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Utilice la configuración de ajuste del marco de texto ([setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) para desactivar el ajuste, de modo que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede obtener el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/); se aplica a todo el párrafo sin importar el formato de las porciones individuales.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte del párrafo (por ejemplo, una palabra)?**

Sí. El idioma se establece a nivel de porción ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.