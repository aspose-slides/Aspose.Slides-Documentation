---
title: Administrar Viñetas
type: docs
weight: 60
url: /es/java/manage-bullet/
keywords: "Viñetas, Listas con viñetas, Números, Listas numeradas, Viñetas de imágenes, viñetas multinivel, Presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Crear listas con viñetas y listas numeradas en presentaciones de PowerPoint en Java"
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y listas numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides para Java** también te permite usar viñetas y números en las diapositivas de tus presentaciones.

## ¿Por qué usar listas con viñetas?

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente.

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores hacia información importante
- permite que tus lectores o espectadores escaneen fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

## ¿Por qué usar listas numeradas?

Las listas numeradas también ayudan en la organización y presentación de información. Idealmente, debes usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada tiene que ser referenciada (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (paso 1 a paso 15) en el procedimiento de **Crear Viñetas** a continuación:

1. Crea una instancia de la clase presentación.
2. Realiza varias tareas (paso 3 a paso 14).
3. Guarda la presentación.

## Crear Viñetas
Este tema también forma parte de la serie de temas sobre la gestión de párrafos de texto. Esta página ilustrará cómo podemos gestionar las viñetas de los párrafos. Las viñetas son más útiles donde algo debe describirse en pasos. Además, el texto se ve bien organizado con el uso de viñetas. Los párrafos con viñetas son siempre más fáciles de leer y entender. Veremos cómo los desarrolladores pueden utilizar esta pequeña pero poderosa característica de Aspose.Slides para Java. Por favor, sigue los pasos a continuación para gestionar las viñetas de los párrafos usando Aspose.Slides para Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Agrega una [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) de la forma añadida.
1. Elimina el párrafo predeterminado en el TextFrame.
1. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph).
1. Establece el tipo de viñeta del párrafo.
1. Establece el tipo de viñeta en [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) y configura el carácter de la viñeta.
1. Establece el Texto del Párrafo.
1. Establece la Sangría del Párrafo para configurar la viñeta.
1. Establece el Color de la Viñeta.
1. Establece la Altura de las Viñetas.
1. Agrega el párrafo creado en la colección de párrafos del TextFrame.
1. Agrega el segundo párrafo y repite el proceso indicado en los pasos **7 a 13**.
1. Guarda la presentación.

Este código de ejemplo en Java—una implementación de los pasos anteriores—te muestra cómo crear una lista con viñetas en una diapositiva:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregando y accediendo a la Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accediendo al marco de texto de la autoshape creada
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);
    
    // Creando un párrafo
    Paragraph para = new Paragraph();
    
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Estableciendo el texto del párrafo
    para.setText("Bienvenido a Aspose.Slides");
    
    // Estableciendo la sangría del párrafo
    para.getParagraphFormat().setIndent(25);
    
    // Estableciendo el color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // establecer IsBulletHardColor en true para usar el color de viñeta propio
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Estableciendo la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Agregando el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    
    // guardando la presentación como un archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Crear Viñetas de Imágenes

Aspose.Slides para Java te permite cambiar las viñetas en las listas de viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizadas. Si deseas agregar interés visual a una lista o llamar aún más la atención a las entradas de una lista, puedes utilizar tu propia imagen como viñeta.

{{% alert color="primary" %}} 

Idealmente, si tienes la intención de reemplazar el símbolo de viñeta regular con una imagen, es posible que desees seleccionar una imagen gráfica simple con un fondo transparente. Tales imágenes funcionan mejor como símbolos de viñetas personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, por lo que te recomendamos encarecidamente seleccionar una imagen que se vea bien (como reemplazo del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta de imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide)
1. Agrega una autoshape en la diapositiva seleccionada
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forma añadida
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)
1. Crea la primera instancia de párrafo usando la clase Paragraph
1. Carga la imagen del disco en [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage)
1. Establece el tipo de viñeta a Picture y configura la imagen
1. Establece el texto del párrafo
1. Establece la sangría del párrafo para configurar la viñeta
1. Establece el color de la viñeta
1. Establece la altura de las viñetas
1. Agrega el párrafo creado en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)
1. Agrega el segundo párrafo y repite el proceso indicado en los pasos anteriores
1. Guarda la presentación

Este código en Java muestra cómo crear una viñeta de imagen en una diapositiva:

```java
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanciando la imagen para las viñetas
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Agregando y accediendo a la Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto de la autoshape creada
    ITextFrame txtFrm = aShp.getTextFrame();
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);

    // Creando un nuevo párrafo
    Paragraph para = new Paragraph();
    para.setText("Bienvenido a Aspose.Slides");

    // Estableciendo el estilo de viñeta del párrafo y la imagen
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Estableciendo la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);

    // Agregando el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);

    // Escribiendo la presentación como un archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Crear Viñetas Multinivel

Para crear una lista con viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista de viñetas principal—sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Agrega una autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Crea la primera instancia de párrafo usando la clase Paragraph y estableciendo la profundidad en 0.
1. Crea la segunda instancia de párrafo usando la clase Paragraph y estableciendo la profundidad en 1.
1. Crea la tercera instancia de párrafo usando la clase Paragraph y estableciendo la profundidad en 2.
1. Crea la cuarta instancia de párrafo usando la clase Paragraph y estableciendo la profundidad en 3.
1. Agrega los párrafos creados en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Guarda la presentación.

Este código, que es una implementación de los pasos anteriores, te muestra cómo crear una lista con viñetas multinivel en Java:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregando y accediendo a la Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accediendo al marco de texto de la autoshape creada
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().clear();
    
    // Creando el primer párrafo
    Paragraph para1 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para1.setText("Contenido");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de la viñeta
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Creando el segundo párrafo
    Paragraph para2 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para2.setText("Segundo nivel");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de la viñeta
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Creando el tercer párrafo
    Paragraph para3 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para3.setText("Tercer nivel");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de la viñeta
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Creando el cuarto párrafo
    Paragraph para4 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para4.setText("Cuarto Nivel");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Estableciendo el nivel de la viñeta
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Agregando los párrafos al marco de texto
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // guardando la presentación como un archivo PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Crear Lista Numerada Personalizada
Aspose.Slides para Java proporciona una API sencilla para gestionar párrafos con formato de números personalizados. Para agregar una lista numerada personalizada en un párrafo, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Agrega una autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Crea la primera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 2
1. Crea la segunda instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 3
1. Crea la tercera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 7
1. Agrega los párrafos creados en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Guarda la presentación.

Este código en Java muestra cómo crear una lista numerada en una diapositiva:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregando y accediendo a la Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto de la autoshape creada
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().clear();

    // Primera lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("viñeta 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("viñeta 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Segunda lista
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("viñeta 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```