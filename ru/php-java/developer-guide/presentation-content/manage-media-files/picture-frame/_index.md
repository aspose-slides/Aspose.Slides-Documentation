---
title: Рамка для изображения
type: docs
weight: 10
url: /php-java/picture-frame/
keywords: "Добавить рамку для изображения, создать рамку для изображения, добавить изображение, создать изображение, извлечь изображение, свойство StretchOff, форматирование рамки для изображения, свойства рамки для изображения, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Добавить рамку для изображения в презентацию PowerPoint"

---

Рамка для изображения — это фигура, которая содержит изображение. Она похожа на картину в рамке.

Вы можете добавить изображение на слайд с помощью рамки для изображения. Таким образом, вы можете отформатировать изображение, форматируя рамку.

{{% alert  title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt), которые позволяют быстро создавать презентации из изображений.

{{% /alert %}} 

## **Создать рамку для изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection), связанную с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, предоставленного объектом фигуры, связанным с упомянутым слайдом.
6. Добавьте рамку для изображения (с содержащейся картинкой) на слайд.
7. Запишите измененную презентацию в файл PPTX.

Этот код PHP демонстрирует, как создать рамку для изображения:

```php
  # Создание экземпляра класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получаем первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создаем экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляем рамку для изображения с высотой и шириной, эквивалентными высоте и ширине изображения
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Записываем файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Рамки для изображения позволяют быстро создавать слайды презентации на основе изображений. Когда вы комбинируете рамку для изображения с параметрами сохранения Aspose.Slides, вы можете манипулировать операциями ввода/вывода для конвертации изображений из одного формата в другой. Вам может быть интересно увидеть эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Создать рамку для изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку для изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection), связанное с объектом презентации, который будет использоваться для заполнения фигуры.
5. Укажите относительную ширину и высоту изображения в рамке.
6. Запишите измененную презентацию в файл PPTX.

Этот код PHP демонстрирует, как создать рамку для изображения с относительным масштабом:

```php
  # Создание экземпляра класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получаем первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создаем экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляем рамку для изображения с высотой и шириной, эквивалентными изображению
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Устанавливаем относительное масштабирование ширины и высоты
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Записываем файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Извлечение изображения из рамки для изображения**

Вы можете извлечь изображения из объектов [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) и сохранить их в формате PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

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

## **Получить прозрачность изображения**

Aspose.Slides позволяет получать прозрачность изображения. Этот код PHP демонстрирует операцию:

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Прозрачность изображения: " . $transparencyValue);
    }
  }
```

## **Форматирование рамки для изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые могут быть применены к рамке для изображения. Используя эти параметры, вы можете изменить рамку для изображения, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) путем добавления изображения в [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection), связанное с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения с помощью метода [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), предоставленного объектом [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection), связанным с упомянутым слайдом.
6. Добавьте рамку для изображения (с содержащейся картинкой) на слайд.
7. Установите цвет линии рамки для изображения.
8. Установите ширину линии рамки для изображения.
9. Поверните рамку для изображения, задав ей положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку для изображения (с содержащейся картинкой) на слайд.
11. Запишите измененную презентацию в файл PPTX.

Этот код PHP демонстрирует процесс форматирования рамки для изображения:

```php
  # Создание экземпляра класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получаем первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создаем экземпляр класса Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Добавляем Рамку для изображения с высотой и шириной, эквивалентными изображению
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Применяем некоторые форматы к PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Записываем файл PPTX на диск
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Совет" color="primary" %}}

Aspose недавно разработала [бесплатный создатель коллажей](https://products.aspose.app/slides/collage). Если вам когда-либо нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG изображения, [создать сетки из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете использовать этот сервис. 

{{% /alert %}}

## **Добавить изображение в виде ссылки**

Чтобы избежать больших размеров презентации, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентации. Этот код PHP показывает, как добавить изображение и видео в заполнители:

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

## **Обрезка изображения**

Этот код PHP показывает, как обрезать существующее изображение на слайде:

```php
  $pres = new Presentation();
  # Создание нового объекта изображения
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
    # Добавление рамки для изображения на слайд
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Обрезка изображения (значения в процентах)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Сохранение результата
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Удаление обрезанных областей изображения

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, вы можете использовать метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Этот метод возвращает обрезанное изображение или исходное изображение, если обрезка не требуется.

Этот код PHP демонстрирует операцию:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Получаем рамку для изображения с первого слайда
    $picFrame = $slide->getShapes()->get_Item(0);
    # Удаляем обрезанные области изображения рамки и возвращаем обрезанное изображение
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Сохраняем результат
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 

Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [рамке для изображения](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), эта настройка может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Этот метод конвертирует WMF/EMF метафайлы в растровое изображение PNG в операции обрезки. 

{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла свое соотношение сторон даже после изменения размеров изображения, вы можете использовать метод [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Блокировать соотношение сторон*.

Этот код PHP демонстрирует, как заблокировать соотношение сторон фигуры:

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
    # Установим фигуру на сохранение соотношения сторон при изменении размера
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 

Этот параметр *Блокировать соотношение сторон* сохраняет только соотношение сторон фигуры, а не изображения, которое она содержит.

{{% /alert %}}

## **Использовать свойство StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) и [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) и класса [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat), вы можете указать заполненный прямоугольник.

Когда для изображения указывается растяжение, исходный прямоугольник масштабируется, чтобы вписаться в указанный заполненный прямоугольник. Каждый край заполненного прямоугольника определяется процентным отступом от соответствующего края ограничивающего прямоугольника фигуры. Положительный процент указывает на внутренний отступ, в то время как отрицательный процент указывает на внешний отступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заливки фигуры.
6. Установите режим заливки изображения фигуры.
7. Добавьте установленное изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующего края ограничивающего прямоугольника фигуры.
9. Запишите измененную презентацию в файл PPTX.

Этот код PHP демонстрирует процесс использования свойства StretchOff:

```php
  # Создание экземпляра класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получаем первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создаем экземпляр класса ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляем AutoShape, установленный в прямоугольник
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Устанавливаем тип заливки фигуры
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Устанавливаем режим заливки изображения фигуры
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Устанавливаем изображение для заполнения фигуры
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Указываем смещения изображения от соответствующего края ограничивающего прямоугольника фигуры
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Записываем файл PPTX на диск
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```