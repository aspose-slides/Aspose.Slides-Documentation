---
title: Gestionar viñetas
type: docs
weight: 60
url: /es/nodejs-java/manage-bullet/
keywords: "Viñetas, Listas con viñetas, Números, Listas numeradas, Viñetas con imágenes, Viñetas multinivel, Presentación de PowerPoint, Java, Aspose.Slides para Node.js via Java"
description: "Crear listas con viñetas y numeradas en una presentación de PowerPoint en JavaScript"
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma forma que lo haces en Word y otros editores de texto. **Aspose.Slides for Node.js via Java** también permite usar viñetas y números en diapositivas de tus presentaciones.

## **¿Por qué usar listas con viñetas?**

Las listas con viñetas te ayudan a organizar y presentar información de forma rápida y eficiente. 

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores a la información importante
- permite a tus lectores o espectadores escanear los puntos clave fácilmente
- comunica y entrega los detalles importantes de manera eficiente.

## **¿Por qué usar listas numeradas?**

Las listas numeradas también ayudan a organizar y presentar información. Idealmente, deberías usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada debe ser referenciada (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (del paso 1 al paso 15) en el procedimiento **Creating Bullets** a continuación:

1. Crea una instancia de la clase de presentación. 
2. Realiza varias tareas (del paso 3 al paso 14).
3. Guarda la presentación. 

## **Creating Bullets**

Este tema también forma parte de la serie de temas sobre la gestión de párrafos de texto. Esta página ilustrará cómo podemos gestionar viñetas de párrafo. Las viñetas son más útiles cuando algo debe describirse paso a paso. Además, el texto se ve bien organizado con el uso de viñetas. Los párrafos con viñetas son siempre más fáciles de leer y comprender. Veremos cómo los desarrolladores pueden usar esta pequeña pero poderosa característica de Aspose.Slides for Node.js via Java. Sigue los pasos a continuación para gestionar las viñetas de párrafo usando Aspose.Slides for Node.js via Java:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. Añade un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) de la forma añadida.
1. Elimina el párrafo predeterminado del TextFrame.
1. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph).
1. Establece el tipo de viñeta del párrafo.
1. Establece el tipo de viñeta a [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) y define el carácter de la viñeta.
1. Establece el texto del párrafo.
1. Establece la sangría del párrafo para definir la viñeta.
1. Establece el color de la viñeta.
1. Establece la altura de las viñetas.
1. Añade el párrafo creado a la colección de párrafos del TextFrame.
1. Añade el segundo párrafo y repite el proceso indicado en los pasos **7 a 13**.
1. Guarda la presentación.

Este fragmento de código en Java—una implementación de los pasos anteriores—muestra cómo crear una lista con viñetas en una diapositiva:
```javascript
    // Instanciar una clase Presentation que representa un archivo PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // Accediendo a la primera diapositiva
        var slide = pres.getSlides().get_Item(0);
        // Agregando y accediendo a Autoshape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Accediendo al marco de texto del autoshape creado
        var txtFrm = aShp.getTextFrame();
        // Eliminando el párrafo predeterminado existente
        txtFrm.getParagraphs().removeAt(0);
        // Creando un párrafo
        var para = new aspose.slides.Paragraph();
        // Estableciendo el estilo de viñeta y el símbolo del párrafo
        para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar(8226);
        // Estableciendo el texto del párrafo
        para.setText("Welcome to Aspose.Slides");
        // Estableciendo la sangría de la viñeta
        para.getParagraphFormat().setIndent(25);
        // Estableciendo el color de la viñeta
        para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // establecer IsBulletHardColor a true para usar un color de viñeta propio
        para.getParagraphFormat().getBullet().isBulletHardColor();
        // Estableciendo la altura de la viñeta
        para.getParagraphFormat().getBullet().setHeight(100);
        // Añadiendo el párrafo al marco de texto
        txtFrm.getParagraphs().add(para);
        // guardando la presentación como archivo PPTX
        pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        pres.dispose();
    }
```


## **Creating Picture Bullets**

Aspose.Slides for Node.js via Java te permite cambiar las viñetas de las listas con viñetas. Puedes sustituir las viñetas por símbolos personalizados o imágenes. Si deseas agregar interés visual a una lista o llamar aún más la atención a las entradas, puedes usar tu propia imagen como viñeta.

{{% alert color="primary" %}} 

Idealmente, si planeas reemplazar el símbolo de viñeta estándar por una imagen, deberías seleccionar una imagen gráfica simple con fondo transparente. Ese tipo de imágenes funciona mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas será reducida a un tamaño muy pequeño, por lo que recomendamos encarecidamente seleccionar una imagen que se vea bien (como reemplazo del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide)
1. Añade un autoshape en la diapositiva seleccionada
1. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) de la forma añadida
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. Crea la primera instancia de párrafo usando la clase Paragraph
1. Carga la imagen desde disco en [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage)
1. Establece el tipo de viñeta a Picture y asigna la imagen
1. Establece el texto del párrafo
1. Establece la sangría del párrafo para definir la viñeta
1. Establece el color de la viñeta
1. Establece la altura de las viñetas
1. Añade el párrafo creado a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. Añade el segundo párrafo y repite el proceso indicado en los pasos anteriores
1. Guarda la presentación

Este código JavaScript muestra cómo crear una viñeta con imagen en una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Instanciar la imagen para viñetas
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Añadiendo y accediendo al Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accediendo al marco de texto del autoshape creado
    var txtFrm = aShp.getTextFrame();
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().removeAt(0);
    // Creando un nuevo párrafo
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Estableciendo el estilo de viñeta del párrafo y la imagen
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Estableciendo la altura de la viñeta
    para.getParagraphFormat().getBullet().setHeight(100);
    // Añadiendo el párrafo al marco de texto
    txtFrm.getParagraphs().add(para);
    // Guardando la presentación como archivo PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Creating Multilevel Bullets**

Para crear una lista con viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista principal—sigue estos pasos:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. Añade un autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Crea la primera instancia de párrafo usando la clase Paragraph y establece la profundidad en 0.
1. Crea la segunda instancia de párrafo usando la clase Paragraph y establece la profundidad en 1.
1. Crea la tercera instancia de párrafo usando la clase Paragraph y establece la profundidad en 2.
1. Crea la cuarta instancia de párrafo usando la clase Paragraph y establece la profundidad en 3.
1. Añade los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Guarda la presentación.

Este código, que implementa los pasos anteriores, muestra cómo crear una lista de viñetas multinivel en JavaScript:
```javascript
// Instanciar una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadiendo y accediendo al Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accediendo al marco de texto del autoshape creado
    var txtFrm = aShp.addTextFrame("");
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().clear();
    // Creando el primer párrafo
    var para1 = new aspose.slides.Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Estableciendo el nivel de viñeta
    para1.getParagraphFormat().setDepth(0);
    // Creando el segundo párrafo
    var para2 = new aspose.slides.Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Estableciendo el nivel de viñeta
    para2.getParagraphFormat().setDepth(1);
    // Creando el tercer párrafo
    var para3 = new aspose.slides.Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Estableciendo el nivel de viñeta
    para3.getParagraphFormat().setDepth(2);
    // Creando el cuarto párrafo
    var para4 = new aspose.slides.Paragraph();
    // Estableciendo el estilo de viñeta del párrafo y el símbolo
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Estableciendo el nivel de viñeta
    para4.getParagraphFormat().setDepth(3);
    // Añadiendo el párrafo al marco de texto
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // guardando la presentación como archivo PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Create Custom Numbered List**

Aspose.Slides for Node.js via Java proporciona una API sencilla para gestionar párrafos con formato de numeración personalizado. Para añadir una lista numerada personalizada en un párrafo, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide).
1. Añade un autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Crea la primera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 2
1. Crea la segunda instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 3
1. Crea la tercera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** en 7
1. Añade los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Guarda la presentación.

Este código JavaScript muestra cómo crear una lista numerada en una diapositiva:
```javascript
// Instanciar una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadiendo y accediendo al Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accediendo al marco de texto del autoshape creado
    var txtFrm = aShp.addTextFrame("");
    // Eliminando el párrafo predeterminado existente
    txtFrm.getParagraphs().clear();
    // Primera lista
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // Segunda lista
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Se pueden exportar las listas con viñetas y numeradas creadas con Aspose.Slides a otros formatos como PDF o imágenes?**

Sí, Aspose.Slides conserva totalmente el formato y la estructura de las listas con viñetas y numeradas al exportar presentaciones a formatos como PDF, imágenes y otros, garantizando resultados consistentes.

**¿Es posible importar listas con viñetas o numeradas desde presentaciones existentes?**

Sí, Aspose.Slides permite importar y editar listas con viñetas o numeradas de presentaciones existentes mientras conserva su formato y apariencia originales.

**¿Aspose.Slides admite listas con viñetas y numeradas en presentaciones creadas en varios idiomas?**

Sí, Aspose.Slides admite plenamente presentaciones multilingües, permitiendo crear listas con viñetas y numeradas en cualquier idioma, incluido el uso de caracteres especiales o no latinos.