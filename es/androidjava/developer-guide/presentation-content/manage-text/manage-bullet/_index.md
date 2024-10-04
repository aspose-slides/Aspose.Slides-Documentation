---
title: Gestionar viñetas
type: docs
weight: 60
url: /es/androidjava/manage-bullet/
keywords: "Viñetas, Listas con viñetas, Números, Listas numeradas, Viñetas de imagen, viñetas multinivel, Presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Crear listas con viñetas y numeradas en presentaciones de PowerPoint en Java"
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides para Android a través de Java** también te permite usar viñetas y números en las diapositivas de tus presentaciones.

## ¿Por qué usar listas con viñetas?

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente.

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores hacia información importante
- permite a tus lectores o espectadores escanear fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

## ¿Por qué usar listas numeradas?

Las listas numeradas también ayudan a organizar y presentar información. Lo ideal es que uses números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada tiene que ser referenciada (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (paso 1 al paso 15) en el procedimiento de **Creación de viñetas** a continuación:

1. Crea una instancia de la clase de presentación.
2. Realiza varias tareas (paso 3 al paso 14).
3. Guarda la presentación.

## Creación de viñetas
Este tema también es parte de la serie de temas sobre gestión de párrafos de texto. Esta página ilustrará cómo podemos gestionar las viñetas de los párrafos. Las viñetas son más útiles cuando algo se describe en pasos. Además, el texto se ve bien organizado con el uso de viñetas. Los párrafos con viñetas son siempre más fáciles de leer y entender. Veremos cómo los desarrolladores pueden utilizar esta pequeña pero poderosa característica de Aspose.Slides para Android a través de Java. Por favor, sigue los pasos a continuación para gestionar las viñetas del párrafo usando Aspose.Slides para Android a través de Java:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. Agrega un [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) de la forma añadida.
5. Elimina el párrafo predeterminado en el TextFrame.
6. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
7. Establece el tipo de viñeta del párrafo.
8. Establece el tipo de viñeta a [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) y establece el carácter de la viñeta.
9. Establece el texto del párrafo.
10. Establece la sangría del párrafo para establecer la viñeta.
11. Establece el color de la viñeta.
12. Establece la altura de las viñetas.
13. Agrega el párrafo creado en la colección de párrafos del TextFrame.
14. Agrega el segundo párrafo y repite el proceso indicado en los pasos **7 a 13**.
15. Guarda la presentación.

Este código de ejemplo en Java—una implementación de los pasos anteriores—te muestra cómo crear una lista con viñetas en una diapositiva:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Acceso a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accediendo al marco de texto de Autoshape creado
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Eliminar el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);
    
    // Crear un párrafo
    Paragraph para = new Paragraph();
    
    // Establecer el estilo de viñeta del párrafo y símbolo
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Establecer texto del párrafo
    para.setText("Bienvenido a Aspose.Slides");
    
    // Establecer sangría de la viñeta
    para.getParagraphFormat().setIndent(25);
    
    // Establecer color de la viñeta
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // establecer IsBulletHardColor a verdadero para usar el color de viñeta propio
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Establecer altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Agregar el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    
    // guardar la presentación como un archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Creación de viñetas de imagen

Aspose.Slides para Android a través de Java te permite cambiar las viñetas en listas con viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizadas. Si deseas añadir interés visual a una lista o atraer aún más la atención a las entradas de la lista, puedes usar tu propia imagen como la viñeta.

{{% alert color="primary" %}} 

Idealmente, si tienes la intención de reemplazar el símbolo de viñeta regular con una imagen, querrás seleccionar una imagen gráfica simple con un fondo transparente. Tales imágenes funcionan mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, así que te recomendamos encarecidamente seleccionar una imagen que se vea bien (como un reemplazo para el símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta de imagen, sigue estos pasos:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)
3. Agrega un autoshape en la diapositiva seleccionada
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forma añadida
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
6. Crea la primera instancia de párrafo usando la clase Paragraph
7. Carga la imagen desde el disco en [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
8. Establece el tipo de viñeta a Picture y establece la imagen
9. Establece el texto del párrafo
10. Establece la sangría del párrafo para establecer la viñeta
11. Establece el color de la viñeta
12. Establece la altura de las viñetas
13. Agrega el párrafo creado a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
14. Agrega el segundo párrafo y repite el proceso dado en los pasos anteriores
15. Guarda la presentación

Este código Java te muestra cómo crear una viñeta de imagen en una diapositiva:

```java
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanciar la imagen para las viñetas
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto de Autoshape creado
    ITextFrame txtFrm = aShp.getTextFrame();
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);

    // Crear un nuevo párrafo
    Paragraph para = new Paragraph();
    para.setText("Bienvenido a Aspose.Slides");

    // Establecer estilo de viñeta del párrafo y la imagen
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Establecer altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);

    // Agregar el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);

    // Escribir la presentación como un archivo PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Creación de viñetas multinivel

Para crear una lista con viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista principal con viñetas—sigue estos pasos:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. Agrega un autoshape en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forma añadida.
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. Crea la primera instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 0.
7. Crea la segunda instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 1.
8. Crea la tercera instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 2.
9. Crea la cuarta instancia de párrafo usando la clase Paragraph y con la profundidad establecida en 3.
10. Agrega los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
11. Guarda la presentación.

Este código, que es una implementación de los pasos anteriores, te muestra cómo crear una lista de viñetas multinivel en Java:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Acceso a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accediendo al marco de texto de Autoshape creado
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
    // Estableciendo el nivel de la viñeta
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Creando el segundo párrafo
    Paragraph para2 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para2.setText("Segundo nivel");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Estableciendo el nivel de la viñeta
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Creando el tercer párrafo
    Paragraph para3 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para3.setText("Tercer nivel");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Estableciendo el nivel de la viñeta
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Creando el cuarto párrafo
    Paragraph para4 = new Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y símbolo
    para4.setText("Cuarto nivel");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Estableciendo el nivel de la viñeta
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Agregando el párrafo al marco de texto
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Guardando la presentación como un archivo PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Crear lista numerada personalizada
Aspose.Slides para Android a través de Java proporciona una API simple para gestionar párrafos con formato de números personalizados. Para agregar una lista numerada personalizada en un párrafo, sigue los pasos a continuación:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
3. Agrega un autoshape en la diapositiva seleccionada.
4. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forma añadida.
5. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
6. Crea la primera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 2.
7. Crea la segunda instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 3.
8. Crea la tercera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 7.
9. Agrega los párrafos creados en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
10. Guarda la presentación.

Este código Java te muestra cómo crear una lista numerada en una diapositiva:

```java
// Instanciar una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Acceso a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadiendo y accediendo a Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accediendo al marco de texto de Autoshape creado
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