---
title: Gestionar listas con viñetas y numeradas en presentaciones usando Java
linktitle: Gestionar listas
type: docs
weight: 60
url: /es/java/manage-bullet/
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
- Java
- Aspose.Slides
description: "Aprenda a gestionar listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Java. Guía paso a paso."
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides for Java** también te permite usar viñetas y números en las diapositivas de tus presentaciones. 

## **¿Por qué usar listas con viñetas?**

Las listas con viñetas te ayudan a organizar y presentar la información de forma rápida y eficiente. 

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- atrae la atención de tus lectores o espectadores a la información importante
- permite a tus lectores o espectadores escanear fácilmente los puntos clave
- comunica y entrega los detalles importantes de manera eficiente.

## **¿Por qué usar listas numeradas?**

Las listas numeradas también ayudan a organizar y presentar la información. Idealmente, deberías usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada debe referenciarse (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (del paso 1 al paso 15) en el procedimiento **Creating Bullets** a continuación:

1. Crea una instancia de la clase Presentation. 
2. Ejecuta varias tareas (del paso 3 al paso 14). 
3. Guarda la presentación. 

## **Crear viñetas**

Este tema también forma parte de la serie de temas sobre la gestión de párrafos de texto. Esta página ilustrará cómo podemos gestionar viñetas de párrafo. Las viñetas son más útiles cuando algo se describe en pasos. Además, el texto se ve bien organizado al usar viñetas. Los párrafos con viñetas siempre son más fáciles de leer y entender. Veremos cómo los desarrolladores pueden usar esta característica pequeña pero potente de Aspose.Slides for Java. Sigue los pasos a continuación para gestionar las viñetas de párrafo usando Aspose.Slides for Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
1. Añade un [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) en la diapositiva seleccionada. 
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) de la forma añadida. 
1. Elimina el párrafo predeterminado en el TextFrame. 
1. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph). 
1. Establece el tipo de viñeta del párrafo. 
1. Establece el tipo de viñeta a [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) y define el carácter de la viñeta. 
1. Establece el texto del párrafo. 
1. Establece la sangría del párrafo para fijar la viñeta. 
1. Establece el color de la viñeta. 
1. Establece la altura de las viñetas. 
1. Añade el párrafo creado a la colección de párrafos del TextFrame. 
1. Añade el segundo párrafo y repite el proceso indicado en los pasos **7 a 13**. 
1. Guarda la presentación. 

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir y acceder a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Acceder al marco de texto del autoshape creado
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Eliminar el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);
    
    // Crear un párrafo
    Paragraph para = new Paragraph();
    
    // Establecer el estilo de viñeta y el símbolo del párrafo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Establecer el texto del párrafo
    para.setText("Welcome to Aspose.Slides");
    
    // Establecer la sangría de la viñeta
    para.getParagraphFormat().setIndent(25);
    
    // Establecer el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // establecer IsBulletHardColor a true para usar un color propio de viñeta
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Establecer la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Añadir el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    
    // Guardar la presentación como archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Crear viñetas con imágenes**

Aspose.Slides for Java te permite cambiar las viñetas de las listas con viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizados. Si deseas añadir interés visual a una lista o llamar aún más la atención sobre las entradas de una lista, puedes usar tu propia imagen como viñeta. 

{{% alert color="primary" %}} 

Idealmente, si deseas reemplazar el símbolo de viñeta estándar por una imagen, deberías seleccionar una imagen gráfica sencilla con fondo transparente. Estas imágenes funcionan mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, por lo que recomendamos encarecidamente seleccionar una imagen que se vea bien (como sustituto del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
1. Añade una autoshape en la diapositiva seleccionada. 
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forma añadida. 
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
1. Crea la primera instancia de párrafo usando la clase Paragraph. 
1. Carga la imagen desde el disco en [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). 
1. Establece el tipo de viñeta a Picture y asigna la imagen. 
1. Establece el texto del párrafo. 
1. Establece la sangría del párrafo para fijar la viñeta. 
1. Establece el color de la viñeta. 
1. Establece la altura de las viñetas. 
1. Añade el párrafo creado a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
1. Añade el segundo párrafo y repite el proceso indicado en los pasos anteriores. 
1. Guarda la presentación. 

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

    // Añadir y acceder a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto del autoshape creado
    ITextFrame txtFrm = aShp.getTextFrame();
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);

    // Creando un nuevo párrafo
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


## **Crear viñetas multinivel**

Para crear una lista con viñetas que contenga elementos en diferentes niveles — listas adicionales bajo la lista principal — sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
1. Añade una autoshape en la diapositiva seleccionada. 
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forma añadida. 
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
1. Crea la primera instancia de párrafo usando la clase Paragraph y con profundidad establecida en 0. 
1. Crea la segunda instancia de párrafo usando la clase Paragraph y con profundidad establecida en 1. 
1. Crea la tercera instancia de párrafo usando la clase Paragraph y con profundidad establecida en 2. 
1. Crea la cuarta instancia de párrafo usando la clase Paragraph y con profundidad establecida en 3. 
1. Añade los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
1. Guarda la presentación. 

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
    // Estableciendo el estilo de viñeta y el símbolo del párrafo
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Creando el segundo párrafo
    Paragraph para2 = new Paragraph();
    // Estableciendo el estilo de viñeta y el símbolo del párrafo
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Creando el tercer párrafo
    Paragraph para3 = new Paragraph();
    // Estableciendo el estilo de viñeta y el símbolo del párrafo
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de viñeta
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Creando el cuarto párrafo
    Paragraph para4 = new Paragraph();
    // Estableciendo el estilo de viñeta y el símbolo del párrafo
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


## **Crear listas numeradas personalizadas**

Aspose.Slides for Java ofrece una API sencilla para gestionar párrafos con formato de números personalizado. Para añadir una lista numerada personalizada en un párrafo, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
1. Añade una autoshape en la diapositiva seleccionada. 
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forma añadida. 
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
1. Crea la primera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** a 2 
1. Crea la segunda instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** a 3 
1. Crea la tercera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** a 7 
1. Añade los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
1. Guarda la presentación. 

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

Sí, Aspose.Slides conserva totalmente el formato y la estructura de las listas con viñetas y numeradas cuando las presentaciones se exportan a formatos como PDF, imágenes y otros, garantizando resultados consistentes.

**¿Es posible importar listas con viñetas o numeradas desde presentaciones existentes?**

Sí, Aspose.Slides permite importar y editar listas con viñetas o numeradas de presentaciones existentes conservando su formato y apariencia originales.

**¿Aspose.Slides admite listas con viñetas y numeradas en presentaciones creadas en varios idiomas?**

Sí, Aspose.Slides admite completamente presentaciones multilingües, permitiendo crear listas con viñetas y numeradas en cualquier idioma, incluida la utilización de caracteres especiales o no latinos.