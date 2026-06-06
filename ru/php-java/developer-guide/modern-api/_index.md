---
title: "Расширьте обработку изображений с помощью Modern API"
linktitle: "Modern API"
type: docs
weight: 237
url: /ru/php-java/modern-api/
keywords:
- "modern API"
- "рисование"
- "миниатюра слайда"
- "слайд в изображение"
- "миниатюра фигуры"
- "фигура в изображение"
- "миниатюра презентации"
- "презентация в изображения"
- "добавить изображение"
- "добавить картинку"
- PHP
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на PHP Modern API для беспроблемной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

Исторически Aspose Slides имеет зависимость от java.awt и в публичном API содержит следующие классы из него:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Чтобы избавиться от зависимостей от этих классов, мы добавили так называемый «Modern API» — то есть API, который следует использовать вместо устаревшего, подписи которого содержат зависимости от [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлен устаревшим, и его поддержка удалена из публичного API Slides.

В текущих версиях рассматривайте публичный API, зависящий от типов java.awt, как устаревший/наследуемый. Используйте Modern API для нового кода и при миграции существующих рабочих процессов обработки изображений.

## **Modern API**

В публичный API добавлены следующие классы и перечисления:

- [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) — представляет растровое или векторное изображение.
- [ImageFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/) — представляет файловый формат изображения.
- [Images](https://reference.aspose.com/slides/ru/php-java/aspose.slides/images/) — методы для создания экземпляров и работы с классом [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/).

Обратите внимание, что [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) подлежит освобождению (его следует освобождать после использования).

Используйте `getImage` для рендеринга одного слайда или фигуры. Используйте `getImages` для рендеринга нескольких слайдов презентации. Методы [Images](https://reference.aspose.com/slides/ru/php-java/aspose.slides/images/) позволяют загружать изображения, `addImage` с [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) — добавлять их в презентацию, и `replaceImage` с [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) — обновлять существующее изображение презентации.

Типичный сценарий использования нового API может выглядеть следующим образом:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# создать одноразовый экземпляр IImage из файла на диске.
$image = Images::fromFile("image.png");

# создать изображение PowerPoint, добавив экземпляр IImage в коллекцию изображений презентации.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# добавить элемент изображения на слайд №1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# получить экземпляр IImage, представляющий слайд №1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# сохранить изображение на диск.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Замена старого кода на Modern API**

Как правило, вам потребуется заменить вызовы, использующие [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) и [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html), на новые методы, использующие [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/).

Устаревший/наследуемый API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Получение миниатюры слайда**

Устаревший/наследуемый API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Получение миниатюры фигуры**

Устаревший/наследуемый API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Получение миниатюры презентации**

Устаревший/наследуемый API:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Добавление изображения в презентацию**

Устаревший/наследуемый API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Устаревшие методы и их замена в Modern API**

### **Presentation**
| Подпись метода | Подпись метода‑замены |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Подпись метода | Подпись метода‑замены |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Подпись метода | Подпись метода‑замены |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| Подпись метода | Подпись метода‑замены |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Подпись метода | Подпись метода‑замены |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Подпись метода | Подпись метода‑замены |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Подпись метода | Подпись метода‑замены |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Подпись метода | Подпись метода‑замены |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Поддержка Graphics2D в API**

Методы с [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлены устаревшими и не имеют прямой замены в Modern API.

Используйте методы Modern API для рендеринга изображений вместо API, который рендерит в [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Почему был удалён [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

Поддержка [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлена устаревшей в публичном API для унификации работы с рендерингом и изображениями, устранения привязки к платформенно‑специфичным зависимостям и перехода к кросс‑платформенному подходу с использованием [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/). Используйте `getImage` или `getImages` вместо рендеринга в [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**В чём практическая выгода [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) по сравнению с [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями и упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/).

**Повлияет ли Modern API на производительность генерации миниатюр?**

Переход от `getThumbnail` к `getImage` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с параметрами и размерами, сохраняя поддержку опций рендеринга. Конкретный выигрыш или потеря зависят от сценария, но функционально замены эквивалентны.