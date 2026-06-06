---
title: Administrar listas con viñetas y numeradas en presentaciones en Java
linktitle: Administrar listas
type: docs
weight: 60
url: /es/java/manage-lists/
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
description: "Aprenda a crear y dar formato a listas con viñetas, imágenes, multinivel y numeradas en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Java."
---
## **Visión general**

Aspose.Slides for Java le permite crear y dar formato a listas con viñetas y numeradas en presentaciones PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan mediante su formato de párrafo.

Utilice el método [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getParagraphFormat--) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [IParagraphFormat.getBullet](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#getBullet--), que devuelve un objeto [IBulletFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/). Con este objeto, puede establecer el tipo de viñeta, el símbolo, la imagen, el color, el tamaño, el estilo de numeración y el número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas con un símbolo personalizado
- crear una viñeta de imagen
- crear una lista multinivel configurando la profundidad del párrafo
- crear una lista numerada
- inspeccionar y modificar el formato de listas en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/) a un [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) y establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Symbol](https://reference.aspose.com/slides/es/java/com.aspose.slides/bullettype/#Symbol). Luego puede establecer [IBulletFormat.setChar](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#getColor--) y [IBulletFormat.setHeight](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setHeight-float-) para controlar la apariencia de la viñeta.

El siguiente código Java muestra cómo crear una lista con viñetas en una diapositiva:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Los símbolos de viñetas](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Numbered](https://reference.aspose.com/slides/es/java/com.aspose.slides/bullettype/#Numbered). También puede elegir un formato de numeración con [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) o establecer [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) cuando la lista deba iniciar con un valor distinto de 1.

El siguiente código Java muestra cómo crear una lista numerada en una diapositiva:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta de imagen**

Aspose.Slides le permite reemplazar un símbolo de viñeta normal por una imagen. Las viñetas de imagen funcionan mejor con imágenes simples que siguen siendo legibles a un tamaño pequeño, como iconos o archivos PNG transparentes de poca dimensión.

{{% alert color="primary" %}}
Idealmente, si planea reemplazar el símbolo de viñeta regular por una imagen, lo mejor es elegir un gráfico sencillo con fondo transparente. Dichas imágenes funcionan bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que siga siendo clara y visualmente eficaz cuando se use como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta de imagen, añada una imagen a [Presentation.getImages](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getImages--) y asigne el objeto de imagen devuelto a [IBulletFormat.getPicture](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#getPicture--). Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Picture](https://reference.aspose.com/slides/es/java/com.aspose.slides/bullettype/#Picture) antes de asignar la imagen.

Supongamos que tenemos un "image.png":

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código Java muestra cómo crear viñetas de imagen en una diapositiva:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [IParagraphFormat.setDepth](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado bajo él, y así sucesivamente.

El siguiente código Java muestra cómo crear una lista con viñetas multinivel:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La lista multinivel](multilevel_list.png)

## **Modificar una lista existente**

Para cambiar el formato de una lista en una presentación existente, acceda al párrafo objetivo y actualice sus ajustes de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#getBullet--) . Las mismas propiedades utilizadas para crear listas pueden usarse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código Java cambia el primer párrafo en un marco de texto para usar un estilo de lista numerada:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Se pueden exportar listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite la disposición de texto y las características de viñeta correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice sus configuraciones de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#getBullet--) y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes utilizadas en la presentación admitan los caracteres que necesita.