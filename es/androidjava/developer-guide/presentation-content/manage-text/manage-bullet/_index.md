---
title: Administrar listas con viñetas y numeradas en presentaciones en Android
linktitle: Administrar listas
type: docs
weight: 60
url: /es/androidjava/manage-bullet/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta de imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a gestionar listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java. Guía paso a paso."
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides for Android via Java** también permite usar viñetas y números en las diapositivas de tus presentaciones.

## **¿Por qué usar listas con viñetas?**

Las listas con viñetas te ayudan a organizar y presentar información rápida y eficientemente. 

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores a información importante
- permite que tus lectores o espectadores escaneen fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

## **¿Por qué usar listas numeradas?**

Las listas numeradas también ayudan a organizar y presentar información. Idealmente, deberías usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada debe referenciarse (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (paso 1 al paso 15) en el procedimiento **Creating Bullets** a continuación:

1. Crear una instancia de la clase Presentation. 
2. Realizar varias tareas (paso 3 al paso 14).
3. Guardar la presentación. 

## **Create Bullets**
Este tema también forma parte de la serie de temas sobre la gestión de párrafos de texto. Esta página ilustrará cómo podemos gestionar viñetas de párrafo. Las viñetas son más útiles cuando algo se describe en pasos. Además, el texto se ve bien organizado con el uso de viñetas. Los párrafos con viñetas siempre son más fáciles de leer y comprender. Veremos cómo los desarrolladores pueden usar esta característica pequeña pero poderosa de Aspose.Slides for Android via Java. Sigue los pasos a continuación para gestionar las viñetas de párrafo usando Aspose.Slides for Android via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Acceder a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Añadir una [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) en la diapositiva seleccionada.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) de la forma añadida.
1. Eliminar el párrafo predeterminado en el TextFrame.
1. Crear la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
1. Establecer el tipo de viñeta del párrafo.
1. Establecer el tipo de viñeta a [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) y definir el carácter de la viñeta.
1. Establecer el texto del párrafo.
1. Establecer la sangría del párrafo para definir la viñeta.
1. Establecer el color de la viñeta.
1. Establecer la altura de las viñetas.
1. Añadir el párrafo creado a la colección de párrafos del TextFrame.
1. Añadir el segundo párrafo y repetir el proceso descrito en los pasos **7 a 13**.
1. Guardar la presentación.

Este código de ejemplo en Java—una implementación de los pasos anteriores—muestra cómo crear una lista con viñetas en una diapositiva:
```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accediendo al marco de texto del autoshape creado
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);
    
    // Creando un párrafo
    Paragraph para = new Paragraph();
    
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Estableciendo el texto del párrafo
    para.setText("Welcome to Aspose.Slides");
    
    // Estableciendo la sangría de la viñeta
    para.getParagraphFormat().setIndent(25);
    
    // Estableciendo el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // Establecer IsBulletHardColor en true para usar un color de viñeta propio
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Estableciendo la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Añadiendo el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    
    // Guardando la presentación como archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Create Picture Bullets**

Aspose.Slides for Android via Java permite cambiar las viñetas en listas con viñetas. Puedes sustituir las viñetas por símbolos o imágenes personalizadas. Si deseas añadir interés visual a una lista o llamar aún más la atención sobre las entradas de una lista, puedes usar tu propia imagen como viñeta.

{{% alert color="primary" %}} 

Idealmente, si planeas reemplazar el símbolo de viñeta regular por una imagen, deberías seleccionar una gráfica simple con fondo transparente. Ese tipo de imágenes funciona mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, por lo que recomendamos encarecidamente seleccionar una imagen que se vea bien (como reemplazo del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)
1. Acceder a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)
1. Añadir una autoshape en la diapositiva seleccionada
1. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forma añadida
1. Eliminar el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Crear la primera instancia de párrafo usando la clase Paragraph
1. Cargar la imagen desde disco en [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
1. Establecer el tipo de viñeta a Picture y asignar la imagen
1. Establecer el texto del párrafo
1. Establecer la sangría del párrafo para definir la viñeta
1. Establecer el color de la viñeta
1. Establecer la altura de las viñetas
1. Añadir el párrafo creado a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Añadir el segundo párrafo y repetir el proceso descrito en los pasos anteriores
1. Guardar la presentación

Este código Java muestra cómo crear una viñeta con imagen en una diapositiva:
```java
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanciar la imagen para viñetas
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto del autoshape creado
    ITextFrame txtFrm = aShp.getTextFrame();
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);

    // Creando nuevo párrafo
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Estableciendo el estilo de viñeta del párrafo y la imagen
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Estableciendo la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);

    // Añadiendo el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);

    // Guardando la presentación como archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Create Multilevel Bullets**

Para crear una lista con viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista principal—sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Acceder a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Añadir una autoshape en la diapositiva seleccionada.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forma añadida.
1. Eliminar el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Crear la primera instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 0.
1. Crear la segunda instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 1.
1. Crear la tercera instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 2.
1. Crear la cuarta instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 3.
1. Añadir los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Guardar la presentación.

Este código, que implementa los pasos anteriores, muestra cómo crear una lista con viñetas multinivel en Java:
```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accediendo al marco de texto del autoshape creado
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().clear();
    
    // Creando el primer párrafo
    Paragraph para1 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Creando el segundo párrafo
    Paragraph para2 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Creando el tercer párrafo
    Paragraph para3 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Creando el cuarto párrafo
    Paragraph para4 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Añadiendo el párrafo al marco de texto
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Guardando la presentación como archivo PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Create Custom Numbered Lists**
Aspose.Slides for Android via Java proporciona una API sencilla para gestionar párrafos con formato de números personalizado. Para añadir una lista numérica personalizada en un párrafo, sigue los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Acceder a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Añadir una autoshape en la diapositiva seleccionada.
1. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forma añadida.
1. Eliminar el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Crear la primera instancia de párrafo usando la clase Paragraph y establecer **NumberedBulletStartWith** a 2
1. Crear la segunda instancia de párrafo usando la clase Paragraph y establecer **NumberedBulletStartWith** a 3
1. Crear la tercera instancia de párrafo usando la clase Paragraph y establecer **NumberedBulletStartWith** a 7
1. Añadir los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Guardar la presentación.

Este código Java muestra cómo crear una lista numerada en una diapositiva:
```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto del autoshape creado
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().clear();

    // Primera lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Segunda lista
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Se pueden exportar las listas con viñetas y numeradas creadas con Aspose.Slides a otros formatos como PDF o imágenes?**

Sí, Aspose.Slides conserva completamente el formato y la estructura de las listas con viñetas y numeradas al exportar presentaciones a formatos como PDF, imágenes y otros, garantizando resultados consistentes.

**¿Es posible importar listas con viñetas o numeradas desde presentaciones existentes?**

Sí, Aspose.Slides permite importar y editar listas con viñetas o numeradas de presentaciones existentes conservando su formato y apariencia originales.

**¿Aspose.Slides admite listas con viñetas y numeradas en presentaciones creadas en varios idiomas?**

Sí, Aspose.Slides admite completamente presentaciones multilingües, permitiendo crear listas con viñetas y numeradas en cualquier idioma, incluido el uso de caracteres especiales o no latinos.