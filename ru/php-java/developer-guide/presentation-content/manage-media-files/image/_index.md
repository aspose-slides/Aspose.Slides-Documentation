---
title: Изображение
type: docs
weight: 10
url: /php-java/image/
description: Работа с изображениями в слайдах PowerPoint-презентаций с использованием PHP. Добавление изображений с диска или из интернета в слайды PowerPoint с использованием PHP. Добавление изображений в образцы слайдов или в качестве фона слайдов с использованием PHP. Добавление SVG в PowerPoint-презентацию с использованием PHP. Преобразование SVG в фигуры в PowerPoint с использованием PHP. Добавление изображений как EMF в слайды с использованием PHP.
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять изображения из файла, интернета или других мест на слайды. Точно так же Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях с помощью различных процедур.

{{% alert title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры—[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—которые позволяют людям быстро создавать презентации из изображений.

{{% /alert %}} 

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение как объект рамки — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т. д. — смотрите [Рамка для изображения](https://docs.aspose.com/slides/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}}

Вы можете манипулировать операциями ввода/вывода, связанными с изображениями и PowerPoint-презентациями, чтобы преобразовать изображение из одного формата в другой. См. эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в этих популярных форматах: JPEG, PNG, GIF и других.

## **Добавление локально сохраненных изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Этот пример кода показывает, как добавить изображение на слайд:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление изображений из интернета на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить изображение напрямую из интернета.

Этот пример кода показывает, как добавить изображение из интернета на слайд:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[ЗАМЕНИТЕ НА URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление изображений в образцы слайдов**

Образец слайда — это верхний слайд, который хранит и управляет информацией (тема, макет и т. д.) о всех слайдах под ним. Когда вы добавляете изображение в образец слайда, это изображение появляется на каждом слайде под этим образцом слайда.

Этот пример кода на Java показывает, как добавить изображение в образец слайда:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление изображений в качестве фона слайда**

Вы можете решить использовать изображение в качестве фона для конкретного слайда или нескольких слайдов. В этом случае вам нужно ознакомиться с *[Установкой изображений в качестве фонов для слайдов](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

Чтобы создать объект изображения на основе SVG-изображения, вы можете сделать это следующим образом:

1. Создайте объект SvgImage, чтобы вставить его в ImageShapeCollection.
2. Создайте объект PPImage из ISvgImage.
3. Создайте объект PictureFrame, используя интерфейс IPPImage.

Этот пример кода показывает, как реализовать шаги выше для добавления SVG-изображения в презентацию:
```php
  # Создайте экземпляр класса Presentation, который представляет файл PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Преобразование SVG в набор фигур**
Конвертация SVG в набор фигур в Aspose.Slides аналогична функциональности PowerPoint, используемой для работы с изображениями SVG:

![Всплывающее меню PowerPoint](img_01_01.png)

Эта функциональность предоставляется одним из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) интерфейса [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG-файла в набор фигур:

```php
  # Создайте новую презентацию
  $presentation = new Presentation();
  try {
    # Читайте содержимое SVG-файла
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Создайте объект SvgImage
    $svgImage = new SvgImage($svgContent);
    # Получите размер слайда
    $slideSize = $presentation->getSlideSize()->getSize();
    # Преобразуйте SVG-изображение в группу фигур, масштабируя его под размер слайда
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Сохраните презентацию в формате PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Добавление изображений как EMF в слайды**
Aspose.Slides для PHP через Java позволяет вам генерировать EMF-изображения из листов Excel и добавлять изображения как EMF в слайды с Aspose.Cells.

Этот пример кода показывает, как выполнить описанную задачу:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Сохраните рабочую книгу в поток
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Информация" color="info" %}}

С помощью бесплатного конвертера Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать текст, создавать GIF из текста и т. д.

{{% /alert %}}