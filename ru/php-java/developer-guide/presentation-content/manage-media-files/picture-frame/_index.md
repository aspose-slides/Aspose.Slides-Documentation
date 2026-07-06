---
title: Управление кадрами изображений в презентациях с использованием PHP
linktitle: Кадр изображения
type: docs
weight: 10
url: /ru/php-java/picture-frame/
keywords:
- кадр изображения
- добавить кадр изображения
- создать кадр изображения
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование кадра изображения
- свойства кадра изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Добавляйте кадры изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Оптимизируйте рабочий процесс и улучшайте дизайн слайдов."
---
## **Введение**

Кадр изображения — это фигура, содержащая изображение, похожая на картину в раме. 

Вы можете добавить изображение на слайд через кадр изображения. Таким образом, вы форматируете изображение, форматируя кадр изображения.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание кадра изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) путем добавления изображения в [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/), связанную с объектом презентации, которое будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) на основе ширины и высоты изображения через метод `addPictureFrame`, доступный у объекта shape, ассоциированного с указанным слайдом.  
6. Добавьте кадр изображения (содержащий картинку) на слайд.  
7. Сохраните изменённую презентацию в файл PPTX.  

Этот PHP‑код показывает, как создать кадр изображения:

```php
  # Создаёт экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создаёт экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляет кадр изображения с высотой и шириной, соответствующими изображению
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Сохраняет файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Кадры изображения позволяют быстро создавать слайды презентации на основе изображений. При сочетании кадра изображения с параметрами сохранения Aspose.Slides вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вам будет интересна следующая информация: конвертировать [изображение в JPG](https://products.aspose.com/slides/ru/php-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/ru/php-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/ru/php-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/ru/php-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/ru/php-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/ru/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **Создание кадра изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложный кадр изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте изображение в коллекцию изображений презентации.  
4. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) путем добавления изображения в [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/), связанную с объектом презентации, которое будет использоваться для заполнения фигуры.  
5. Укажите относительные ширину и высоту изображения в кадре изображения.  
6. Сохраните изменённую презентацию в файл PPTX.  

Этот PHP‑код показывает, как создать кадр изображения с относительным масштабом:

```php
  # Создаёт экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создаёт экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляет кадр изображения с высотой и шириной, эквивалентными изображению
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Устанавливает относительный масштаб ширины и высоты
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Сохраняет файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Извлечение растровых изображений из кадров изображения**

Вы можете извлечь растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) и сохранить их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Извлечение SVG‑изображений из кадров изображения**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java позволяет получить оригинальные векторные изображения с полной точностью. Перебирая коллекцию фигур слайда, можно определить каждый [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/), проверить, содержит ли соответствующий [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его нативном формате SVG.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из кадра изображения:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот PHP‑код демонстрирует операцию:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Получение яркости и контраста изображения**

Aspose.Slides позволяет получить параметры яркости и контраста, применённые к изображению. Класс [Luminance](https://reference.aspose.com/slides/ru/php-java/aspose.slides/luminance/) представляет этот эффект преобразования изображения.

Этот PHP‑код демонстрирует, как получить настройки яркости и контраста из кадра изображения:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Форматирование кадра изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к кадру изображения. Используя эти параметры, вы можете изменить кадр изображения в соответствии с конкретными требованиями.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) путем добавления изображения в [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/), связанную с объектом презентации, которое будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [addPictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addpictureframe/), доступный у объекта [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/) ассоциированного со слайдом.  
6. Добавьте кадр изображения (содержащий картинку) на слайд.  
7. Установите цвет линии кадра изображения.  
8. Установите ширину линии кадра изображения.  
9. Поверните кадр изображения, задав ему положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.  
10. Добавьте кадр изображения (содержащий картинку) на слайд.  
11. Сохраните изменённую презентацию в файл PPTX.  

Этот PHP‑код демонстрирует процесс форматирования кадра изображения:

```php
  # Создаёт экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создаёт экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляет кадр изображения с высотой и шириной, эквивалентными изображению
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Применяет некоторое форматирование к PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Записывает файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения в виде ссылки**

Чтобы уменьшить размер презентации, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентацию. Этот PHP‑код показывает, как добавить изображение и видео в заполнитель:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Обрезка изображений**

Этот PHP‑код показывает, как обрезать существующее изображение на слайде:

```php
  $pres = new Presentation();
  # Создаёт новый объект изображения
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет кадр изображения на слайд
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Обрезает изображение (в процентах)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Сохраняет результат
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удаление обрезанных областей кадра изображения**

Если необходимо удалить обрезанные области изображения, находящегося в кадре, используйте метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Этот метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Этот PHP‑код демонстрирует операцию:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Получает PictureFrame с первого слайда
    $picFrame = $slide->getShapes()->get_Item(0);
    # Удаляет обрезанные области изображения PictureFrame и возвращает обрезанное изображение
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Сохраняет результат
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/), это может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Метод конвертирует метафайлы WMF/EMF в растровое PNG‑изображение при операции обрезки. 

{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации, используя метод [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Этот метод сжимает изображение, уменьшая его размер в зависимости от размеров фигуры и указанного разрешения, с опцией удаления обрезанных областей.

Он регулирует размер и разрешение изображения аналогично функции PowerPoint **Picture Format → Compress Pictures → Resolution**.

Ниже приведены примеры PHP, демонстрирующие сжатие изображения в презентации путем указания целевого разрешения и, при желании, удаления обрезанных областей:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Сжимает изображение с целевым разрешением 150 DPI (веб‑разрешение) и удаляет обрезанные области.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Проверяет результат сжатия.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Или указав пользовательское значение DPI напрямую:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Сжимает изображение до 150 DPI (веб-разрешение), удаляя обрезанные области.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод преобразует изображение в более низкое разрешение, исходя из размеров фигуры и заданного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие применено не будет. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG‑изображения высокого разрешения. 

{{% /alert %}}

## **Блокировка соотношения сторон**

Если требуется, чтобы форма, содержащая изображение, сохраняла своё соотношение сторон даже после изменения размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) для установки параметра *Lock Aspect Ratio*.

Этот PHP‑код показывает, как заблокировать соотношение сторон формы:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # установить сохранение соотношения сторон формы при изменении размеров
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон формы, а не изображения, которое она содержит. 

{{% /alert %}}

## **Использование свойства StretchOff**

С помощью методов [setStretchOffsetLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) и [setStretchOffsetBottom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) класса [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) можно задать прямоугольник заполнения.

Когда для изображения задаётся растягивание, исходный прямоугольник масштабируется, чтобы вписаться в указанный прямоугольник заполнения. Каждая сторона прямоугольника заполнения определяется процентным смещением от соответствующей стороны ограничивающего прямоугольника формы. Положительный процент задаёт внутреннее смещение, отрицательный — внешнее.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте прямоугольник `AutoShape`.  
4. Создайте изображение.  
5. Установите тип заливки формы.  
6. Установите режим заливки изображения формы.  
7. Добавьте изображение для заливки формы.  
8. Укажите смещения изображения от соответствующей стороны ограничивающего прямоугольника формы.  
9. Сохраните изменённую презентацию в файл PPTX.  

Этот PHP‑код демонстрирует процесс, в котором используется свойство StretchOff:

```php
  # Создаёт экземпляр класса Presentation, представляющего PPTX файл
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создаёт экземпляр класса ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет AutoShape с типом Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Устанавливает тип заливки формы
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Устанавливает режим заливки изображения формы
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Устанавливает изображение для заливки формы
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Задает смещения изображения от соответствующей стороны ограничивающего прямоугольника формы
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Записывает файл PPTX на диск
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, совпадает с возможностями механизма конвертации слайдов и изображений.

**Как добавление десятков больших изображений отразится на размере и производительности PPTX?**

Встраивание больших изображений увеличивает размер файла и потребление памяти; использование ссылок на изображения помогает снизить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для уменьшения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**

Используйте [блокировки фигур](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/getpictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размера). Механизм блокировки поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/) в оригинальном векторном виде. При [экспорте в PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/php-java/convert-powerpoint-to-png/) результат может быть растрирован в зависимости от настроек экспорта; факт сохранения оригинального SVG как вектора подтверждается поведением извлечения.