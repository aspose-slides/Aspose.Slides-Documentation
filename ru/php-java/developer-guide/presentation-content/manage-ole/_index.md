---
title: Управление OLE
type: docs
weight: 40
url: /php-java/manage-ole/
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) — это технология Microsoft, которая позволяет размещать данные и объекты, созданные в одном приложении, в другом приложении путем связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Диаграмма затем помещается на слайд PowerPoint. Эта диаграмма Excel считается объектом OLE. 

- Объект OLE может отображаться как значок. В этом случае, когда вы дважды щелкаете значок, диаграмма открывается в своем связанном приложении (Excel), или вам предлагается выбрать приложение для открытия или редактирования объекта. 
- Объект OLE может отображать фактическое содержимое — например, содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, интерфейс диаграммы загружается, и вы можете изменить данные диаграммы в приложении PowerPoint.

[Aspose.Slides для PHP через Java](https://products.aspose.com/slides/php-java/) позволяет вставлять OLE-объекты в слайды в виде рамок OLE-объектов ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)).

## **Добавление рамок OLE-объектов в слайды**
Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить эту диаграмму в слайд в виде рамки OLE-объекта с помощью Aspose.Slides для PHP через Java, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). 
1. Получите ссылку на слайд, используя его индекс. 
1. Откройте файл Excel, содержащий объект диаграммы Excel, и сохраните его в `MemoryStream`. 
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) на слайд, содержащий массив байтов и другую информацию об объекте OLE. 
1. Запишите измененную презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде рамки OLE-объекта с использованием Aspose.Slides для PHP через Java. 
**Обратите внимание**, что конструктор [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать подходящее приложение для открытия этого объекта OLE.

```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает доступ к первому слайду
    $sld = $pres->getSlides()->get_Item(0);
    # Загружает файл Excel в поток
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # Создает объект данных для встраивания
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # Добавляет форму рамки Ole-объекта
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # Записывает файл PPTX на диск
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Доступ к рамкам OLE-объектов**
Если объект OLE уже встроен в слайд, вы можете легко найти или получить доступ к этому объекту следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). 
1. Получите ссылку на слайд, используя его индекс. 
1. Получите доступ к форме рамки OLE-объекта.

   В нашем примере мы использовали ранее созданный PPTX, который имеет только одну форму на первом слайде. Затем мы *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). Это была желаемая рамка OLE-объекта, к которой нужно было получить доступ. 
1. После получения доступа к рамке OLE-объекта вы можете выполнять любые операции с ней.

В примере ниже рамка OLE-объекта (объект диаграммы Excel, встроенный в слайд) доступна — а затем данные файла записываются в файл Excel.

```php
  # Загружает PPTX в объект Presentation
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # Получает доступ к первому слайду
    $sld = $pres->getSlides()->get_Item(0);
    # Приводит форму к OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # Читает OLE-объект и записывает его на диск
    if (!java_is_null($oleObjectFrame)) {
      # Получает встроенные данные файла
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # Получает расширение встроенного файла
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # Создает путь для сохранения извлеченного файла
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # Сохраняет извлеченные данные
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Изменение данных OLE-объекта**

Если объект OLE уже встроен в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Откройте желаемую презентацию с встроенным OLE объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). 
1. Получите ссылку на слайд через его индекс. 
1. Получите доступ к форме рамки OLE-объекта.

   В нашем примере мы использовали ранее созданный PPTX, который имеет только одну форму на первом слайде. Затем мы *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). Это была желаемая рамка OLE-объекта, к которой нужно было получить доступ. 
1. После получения доступа к рамке OLE-объекта вы можете выполнять любые операции с ней. 
1. Создайте объект Workbook и получите доступ к данным OLE. 
1. Получите доступ к желаемому Листу и измените данные.
1. Сохраните обновленную книгу в потоках. 
1. Измените данные OLE-объекта из данных потока.

В примере ниже рамка OLE-объекта (объект диаграммы Excel, встроенный в слайд) доступна — а затем ее данные файла изменяются для изменения данных диаграммы:

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # Обходит все формы для рамки Ole
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # Читает данные объекта в Workbook
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # Изменяет данные рабочей книги
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # Изменяет данные объекта Ole
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Встраивание других типов файлов в слайды

Кроме диаграмм Excel, Aspose.Slides для PHP через Java позволяет встраивать другие типы файлов в слайды. Например, вы можете вставить HTML, PDF и ZIP файлы в качестве объектов на слайд. Когда пользователь дважды щелкает на вставленном объекте, объект автоматически запускается в соответствующей программе, или пользователю предлагается выбрать подходящую программу для открытия объекта.

В этом PHP коде показано, как встроить HTML и ZIP в слайд:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Установка типов файлов для встроенных объектов

При работе с презентациями вам может понадобиться заменить старые OLE-объекты новыми. Или вам может потребоваться заменить неподдерживаемый OLE-объект на поддерживаемый. 

Aspose.Slides для PHP через Java позволяет устанавливать тип файла для встроенного объекта. Таким образом, вы можете изменить данные рамки OLE или ее расширение.

Этот Java показывает, как установить тип файла для встроенного OLE-объекта:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("Текущее расширение встроенных данных: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Установка изображений значков и заголовков для встроенных объектов

После того, как вы встроите OLE-объект, предварительный просмотр, состоящий из изображения значка и заголовка, добавляется автоматически. Предварительный просмотр — это то, что пользователи видят перед тем, как получить доступ или открыть OLE-объект. 

Если вы хотите использовать определенное изображение и текст в качестве элементов в предварительном просмотре, вы можете установить изображение значка и заголовок, используя Aspose.Slides для PHP через Java.

Этот PHP код показывает, как установить изображение значка и заголовок для встроенного объекта:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("Мой заголовок");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Извлечение встроенных файлов

Aspose.Slides для PHP через Java позволяет вам извлекать файлы, встроенные в слайды в качестве OLE-объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего OLE-объект, который вы собираетесь извлечь.
2. Проходите по всем формам в презентации и получите доступ к форме [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe).
3. Получите доступ к данным встроенного файла из рамки OLE-объекта и запишите их на диск. 

Этот PHP код показывает, как извлечь файл, встроенный в слайд как OLE-объект:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # Сохраняет извлеченные данные
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
