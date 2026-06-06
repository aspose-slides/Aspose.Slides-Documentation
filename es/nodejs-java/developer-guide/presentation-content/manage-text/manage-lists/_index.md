---
title: Gestionar listas con viñetas y numeradas en presentaciones usando JavaScript
linktitle: Gestionar listas
type: docs
weight: 60
url: /es/nodejs-java/manage-lists/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a crear y formatear listas con viñetas, con imágenes, multinivel y numeradas en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Node.js a través de Java."
---
## **Descripción general**

Aspose.Slides for Node.js via Java le permite crear y formatear listas con viñetas y numeradas en presentaciones PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas opciones de viñeta se controlan a través de su formato de párrafo.

Utilice la clase [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es `Paragraph.getParagraphFormat().getBullet()`, que devuelve un objeto [BulletFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/). Con este objeto, puede establecer el tipo de viñeta, el símbolo, la imagen, el color, el tamaño, el estilo de numeración y el número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas usando un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- examinar y cambiar el formato de lista en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) y establezca `BulletFormat.setType` a [BulletType.Symbol](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bullettype/). A continuación, puede definir `BulletFormat.setChar`, `BulletFormat.getColor` y `BulletFormat.setHeight` para controlar la apariencia de la viñeta.

El siguiente código JavaScript demuestra cómo crear una lista con viñetas en una diapositiva:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Los símbolos de viñeta](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca `BulletFormat.setType` a [BulletType.Numbered](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bullettype/). También puede elegir un formato de numeración con `BulletFormat.setNumberedBulletStyle` o establecer `BulletFormat.setNumberedBulletStartWith` cuando la lista deba iniciar con un valor distinto de 1.

El siguiente código JavaScript muestra cómo crear una lista numerada en una diapositiva:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides le permite sustituir un símbolo de viñeta estándar por una imagen. Las viñetas con imagen funcionan mejor con imágenes simples que sigan siendo legibles a un tamaño pequeño, como iconos o archivos PNG transparentes de dimensiones reducidas.

{{% alert color="primary" %}}
Lo ideal es que, si piensa sustituir el símbolo de viñeta estándar por una imagen, elija un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que siga siendo clara y visualmente eficaz cuando se use como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) con `Presentation.getImages().addImage` y asigne el objeto [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) devuelto a `BulletFormat.getPicture().setImage`. Establezca `BulletFormat.setType` a [BulletType.Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que tenemos un "image.png":

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código JavaScript muestra cómo crear viñetas con imagen en una diapositiva:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

El resultado:

![Las viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice `ParagraphFormat.setDepth` para ubicar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado debajo de él, y así sucesivamente.

El siguiente código JavaScript muestra cómo crear una lista con viñetas multinivel:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para modificar el formato de una lista en una presentación existente, acceda al párrafo objetivo y actualice sus ajustes `ParagraphFormat.getBullet`. Las mismas propiedades utilizadas para crear listas pueden emplearse para examinar o modificar listas cargadas desde un archivo PPT, PPTX u ODP.

El siguiente código JavaScript cambia el primer párrafo de un marco de texto para usar un estilo de lista numerada:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Se pueden exportar listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite el diseño de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, examine o actualice sus ajustes `ParagraphFormat.getBullet` y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes usadas en la presentación admitan los caracteres que necesita.