---
title: Gestionar listas con viñetas y numeradas en presentaciones usando PHP
linktitle: Gestionar listas
type: docs
weight: 60
url: /es/php-java/manage-lists/
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
- PHP
- Aspose.Slides
description: "Aprenda a crear y dar formato a listas con viñetas, de imagen, multinivel y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java."
---
## **Visión general**

Aspose.Slides for PHP via Java le permite crear y dar formato a listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan a través de su formato de párrafo.

Utilice el método [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getParagraphFormat--) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [ParagraphFormat.getBullet](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#getBullet--) que devuelve un objeto [BulletFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/). Con este objeto, puede establecer el tipo de viñeta, símbolo, imagen, color, tamaño, estilo de numeración y número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas con un símbolo personalizado
- crear una viñeta de imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- inspeccionar y cambiar el formato de la lista en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) y establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType.Symbol](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/#Symbol). Luego puede establecer [BulletFormat.setChar](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#getColor--) y [BulletFormat.setHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setHeight-float-) para controlar la apariencia de la viñeta.

El siguiente código PHP muestra cómo crear una lista con viñetas en una diapositiva:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![Viñetas de símbolo](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType.Numbered](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/#Numbered). También puede elegir un formato de numeración con [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) o establecer [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) cuando la lista debe comenzar desde un valor distinto de 1.

El siguiente código PHP muestra cómo crear una lista numerada en una diapositiva:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![Viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta de imagen**

Aspose.Slides le permite reemplazar un símbolo de viñeta normal por una imagen. Las viñetas de imagen funcionan mejor con imágenes simples que siguen siendo legibles a un tamaño pequeño, como íconos o archivos PNG transparentes pequeños.

{{% alert color="primary" %}}
Idealmente, si planea reemplazar el símbolo de viñeta normal por una imagen, lo mejor es elegir un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.
{{% /alert %}}

Para crear una viñeta de imagen, añada una imagen a [Presentation.getImages](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getImages--) y asigne el objeto [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) devuelto a [BulletFormat.getPicture](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#getPicture--). Establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType.Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/#Picture) antes de asignar la imagen.

Supongamos que tenemos un "image.png":

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código PHP muestra cómo crear viñetas de imagen en una diapositiva:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![Viñetas de imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [ParagraphFormat.setDepth](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setDepth-short-) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado debajo de él, y así sucesivamente.

El siguiente código PHP muestra cómo crear una lista con viñetas multinivel:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![Lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para cambiar el formato de la lista en una presentación existente, acceda al párrafo objetivo y actualice sus configuraciones [ParagraphFormat.getBullet](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#getBullet--). Las mismas propiedades usadas para crear listas pueden emplearse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código PHP cambia el primer párrafo en un marco de texto para usar un estilo de lista numerada:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Preguntas frecuentes**

**¿Se pueden exportar listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite la distribución de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice sus configuraciones [ParagraphFormat.getBullet](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#getBullet--), y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes usadas en la presentación admitan los caracteres que necesita.