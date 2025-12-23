---
title: Управление рамками изображений в презентациях с использованием PHP
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/php-java/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Упростите рабочий процесс и улучшите дизайн слайдов."
---

Рамка изображения — это форма, содержащая изображение; она похожа на картину в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Tip" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

## **Создать рамку изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [IPPImage]() путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения формы.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, предоставляемого объектом формы, связанным с указанным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код показывает, как создать рамку изображения:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создает экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляет рамку изображения с высотой и шириной, соответствующей картинке
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
Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. При сочетании рамки изображения с параметрами сохранения Aspose.Slides вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вам будут интересны следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **Создать рамку изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения формы.
5. Укажите относительную ширину и высоту изображения в рамке изображения.
6. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код показывает, как создать рамку изображения с относительным масштабом:
```php
  # Создает экземпляр класса Presentation, который представляет PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создает экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляет рамку изображения с высотой и шириной, эквивалентными картинке
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


## **Извлечь растровые изображения из рамок изображения**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) и сохранять их в форматы PNG, JPG и другие. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.
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


## **Извлечь SVG‑изображения из рамок изображения**

Когда презентация содержит графику SVG, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), Aspose.Slides для PHP через Java позволяет получить оригинальные векторные изображения с полной точностью. При обходе коллекции фигур слайда можно определить каждую [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), проверить, содержит ли базовый [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его оригинальном формате SVG.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки изображения:
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


## **Получить прозрачность изображения**

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


## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью вы можете изменить рамку изображения, чтобы она соответствовала определённым требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection), связанный с объектом презентации, который будет использоваться для заполнения формы.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) , предоставляемый объектом [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Установите цвет линии рамки изображения.
8. Установите ширину линии рамки изображения.
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке.
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (содержащую картинку) на слайд.
11. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует процесс форматирования рамки изображения:
```php
  # Создает экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создает экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляет рамку изображения с высотой и шириной, соответствующими изображению
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Применяет некоторое форматирование к PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Сохраняет файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}
Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетки из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этим сервисом.
{{% /alert %}}

## **Добавить изображение в виде ссылки**

Чтобы избежать больших размеров презентаций, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов напрямую в презентацию. Этот PHP‑код показывает, как добавить изображение и видео в заполнитель:
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
  # Создает новый объект изображения
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
    # Добавляет рамку изображения на слайд
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Обрезает изображение (значения в процентах)
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


## **Удалить обрезанные области изображения**

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, можете использовать метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Этот метод возвращает обрезанное изображение или оригинальное изображение, если обрезка не требуется.

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
Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Этот метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение в ходе операции обрезки. 
{{% /alert %}}

## **Блокировать соотношение сторон**

Если вы хотите, чтобы форма, содержащая изображение, сохраняла своё соотношение сторон даже после изменения размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Lock Aspect Ratio*.

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
    # установить, чтобы фигура сохраняла пропорции при изменении размера
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 
Этот параметр *Lock Aspect Ratio* сохраняет только соотношение сторон формы, а не изображения, которое она содержит. 
{{% /alert %}}

## **Использовать свойство StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) из интерфейса [IPictureFillFormat] и класса [PictureFillFormat], вы можете задать прямоугольник заливки.

Когда для изображения указано растягивание, исходный прямоугольник масштабируется, чтобы вписаться в заданный прямоугольник заливки. Каждая граница прямоугольника заливки задаётся процентным смещением от соответствующей границы ограничивающего прямоугольника формы. Положительный процент указывает на внутренний отступ, а отрицательный — на внешний выступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`.
4. Создайте изображение.
5. Установите тип заливки формы.
6. Установите режим заливки формы картинкой.
7. Добавьте заданное изображение для заливки формы.
8. Укажите смещения изображения от соответствующей границы ограничивающего прямоугольника формы.
9. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует процесс, в котором используется свойство StretchOff:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создает экземпляр класса ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет AutoShape типа Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Устанавливает тип заливки фигуры
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Устанавливает режим заливки изображения в фигуре
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Устанавливает изображение для заливки фигуры
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Задает смещения изображения от соответствующей границы ограничивающего прямоугольника фигуры
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
Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и др.), так и векторные изображения (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/). Список поддерживаемых форматов обычно перекрывается с возможностями механизма конвертации слайдов и изображений.

**Как добавление десятков больших изображений влияет на размер и производительность PPTX?**  
Встраивание больших изображений увеличивает размер файла и использование памяти; связывание изображений помогает уменьшить размер презентации, но требует доступа к внешним файлам. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для уменьшения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**  
Используйте [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) для [PictureFrame] (например, отключить перемещение или изменение размера). Механизм блокировки описан для фигур в отдельной [статье о защите](/slides/ru/php-java/applying-protection-to-presentation/) и поддерживается различными типами фигур, включая [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**  
Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/php-java/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт того, что оригинальный SVG хранится как вектор, подтверждается поведением извлечения.