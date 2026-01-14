---
title: Оптимизация управления изображениями в презентациях с использованием PHP
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/php-java/image/
keywords:
- добавить изображение
- добавить картинку
- добавить растровое изображение
- заменить изображение
- заменить картинку
- из интернета
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Изображения в презентационных слайдах**

Изображения делают презентации более интересными и захватывающими. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других мест в слайды. Аналогично, Aspose.Slides позволяет добавлять изображения в слайды ваших презентаций различными способами. 

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение как объект кадра — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.п. — см. [Picture Frame](/slides/ru/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете управлять операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, чтобы преобразовать изображение из одного формата в другой. См. эти страницы: конвертировать [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает работу с изображениями в следующих популярных форматах: JPEG, PNG, GIF и другие. 

## **Добавление локально хранящихся изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд презентации. Этот пример кода показывает, как добавить изображение на слайд:
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

Если нужное вам изображение недоступно на компьютере, вы можете добавить его непосредственно из интернета. 

Этот пример кода показывает, как добавить изображение из интернета на слайд:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
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


## **Добавление изображений в мастер‑слайды**

Мастер‑слайд — это верхний слайд, который хранит и управляет информацией (тема, макет и др.) обо всех слайдах под ним. Поэтому, когда вы добавляете изображение в мастер‑слайд, это изображение появляется на каждом слайде, использующем данный мастер‑слайд. 

Этот пример кода на Java показывает, как добавить изображение в мастер‑слайд:
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

Вы можете решить использовать изображение в качестве фона для конкретного слайда или нескольких слайдов. В этом случае вам следует посмотреть, как [Set an Image as a Slide Background](/slides/ru/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/), принадлежащий классу [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

Чтобы создать объект изображения на основе SVG, вы можете сделать это следующим образом:

1. Создать объект SvgImage для вставки в ImageShapeCollection  
2. Создать объект PPImage из ISvgImage  
3. Создать объект PictureFrame, используя класс PPImage

Этот пример кода показывает, как реализовать описанные шаги для добавления SVG‑изображения в презентацию:
```php
  # Создать экземпляр класса Presentation, представляющего файл PPTX
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
Конвертация SVG в набор фигур в Aspose.Slides аналогична функционалу PowerPoint, используемому для работы с SVG‑изображениями:

![PowerPoint Popup Menu](img_01_01.png)

Эта функция предоставляется одной из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addgroupshape/) класса [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/), принимающего объект [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG‑файла в набор фигур:
```php
  # Создать новую презентацию
  $presentation = new Presentation();
  try {
    # Прочитать содержимое SVG файла
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

    # Создать объект SvgImage
    $svgImage = new SvgImage($svgContent);
    # Получить размер слайда
    $slideSize = $presentation->getSlideSize()->getSize();
    # Преобразовать изображение SVG в группу фигур, масштабируя его до размера слайда
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Сохранить презентацию в формате PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Добавление изображений в формате EMF на слайды**
Aspose.Slides for PHP via Java позволяет генерировать EMF‑изображения из листов Excel и добавлять их в слайды в формате EMF с помощью Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Сохранить рабочую книгу в поток
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


## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, которые используются в фигурах слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с использованием необработанных байтов, экземпляра [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/), либо другого изображения, уже находящегося в коллекции.

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Загрузите новое изображение из файла в массив байтов.  
3. Замените целевое изображение новым, используя массив байтов.  
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/), и замените целевое изображение этим объектом.  
5. В третьем подходе замените целевое изображение изображением, уже существующим в коллекции изображений презентации.  
6. Сохраните изменённую презентацию в файл PPTX.  
```php
// Создать экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation("sample.pptx");
try {
    // Первый способ.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Второй способ.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Третий способ.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Сохранить презентацию в файл.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать текст, создавать GIF‑изображения из текста и т.д. 

{{% /alert %}}

## **FAQ**

**Сохраняется ли исходное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/php-java/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Какой лучший способ заменить один и тот же логотип на десятках слайдов одновременно?**

Разместите логотип в мастер‑слайде или макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие данный ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете конвертировать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.

**Как установить изображение в качестве фона для нескольких слайдов одновременно?**

[Assign the image as the background](/slides/ru/php-java/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие данный мастер/макет, унаследуют фон.

**Как предотвратить «раздувание» презентации из‑за большого количества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющиеся графические элементы в мастере, где это уместно.