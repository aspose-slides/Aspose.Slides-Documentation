---
title: Gestionar listas con viñetas y numeradas en presentaciones en Android
linktitle: Gestionar listas
type: docs
weight: 60
url: /es/androidjava/manage-lists/
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
description: "Aprenda a crear y dar formato a listas con viñetas, con imagen, multinivel y numeradas en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para Android mediante Java."
---
## **Descripción general**

Aspose.Slides for Android a través de Java le permite crear y dar formato a listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan mediante el formato del párrafo.

Utilice el método [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) para acceder a la configuración de lista a nivel de párrafo. El punto de entrada principal es [IParagraphFormat.getBullet](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), que devuelve un objeto [IBulletFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/). Con este objeto, puede establecer el tipo de viñeta, el símbolo, la imagen, el color, el tamaño, el estilo de numeración y el número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas usando un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- inspeccionar y cambiar el formato de lista en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada párrafos a un [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) y establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Symbol](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/bullettype/). A continuación, puede definir [IBulletFormat.setChar](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#getColor--) y [IBulletFormat.setHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) para controlar la apariencia de la viñeta.

El siguiente código Java muestra cómo crear una lista con viñetas en una diapositiva:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The symbol bullets](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Numbered](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/bullettype/). También puede elegir un formato de numeración con [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) o establecer [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) cuando la lista deba comenzar con un valor distinto de 1.

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

![The numbered bullets](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides le permite sustituir un símbolo de viñeta regular por una imagen. Las viñetas con imagen funcionan mejor con imágenes simples que sigan siendo legibles a un tamaño pequeño, como iconos o archivos PNG transparentes de pequeño tamaño.

{{% alert color="primary" %}}
Idealmente, si va a sustituir el símbolo de viñeta regular por una imagen, lo mejor es elegir un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que mantenga claridad y sea visualmente eficaz cuando se use como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [Presentation.getImages](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getImages--) y asigne el objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) devuelto a [IBulletFormat.getPicture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Picture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que tenemos un “image.png”:

![A picture for the bullets](picture_for_bullets.png)

El siguiente código Java muestra cómo crear viñetas con imagen en una diapositiva:

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

![The picture bullets](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [IParagraphFormat.setDepth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado debajo de él, y así sucesivamente.

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

![The multilevel list](multilevel_list.png)

## **Cambiar una lista existente**

Para modificar el formato de lista en una presentación existente, acceda al párrafo objetivo y actualice sus configuraciones de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#getBullet--). Los mismos métodos usados para crear listas pueden emplearse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código Java cambia el primer párrafo en un marco de texto para que use un estilo de lista numerada:

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

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite el diseño de texto y las características de viñeta correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice sus configuraciones de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), y guarde la presentación.

**¿Las listas pueden contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes usadas en la presentación admitan los caracteres que necesita.