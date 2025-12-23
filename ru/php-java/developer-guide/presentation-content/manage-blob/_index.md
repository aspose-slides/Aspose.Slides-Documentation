---
title: Управление BLOB презентаций в PHP для эффективного использования памяти
linktitle: Управление BLOB
type: docs
weight: 10
url: /ru/php-java/manage-blob/
keywords:
- большой объект
- большой элемент
- большой файл
- добавить BLOB
- экспортировать BLOB
- добавить изображение как BLOB
- сократить память
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для PHP через Java, оптимизируя операции с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарном формате.

Aspose.Slides for PHP via Java позволяет использовать BLOB для объектов способом, который снижает потребление памяти при работе с крупными файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приводит к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы планируете загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/php-java/) for Java позволяет добавить большие файлы (в данном случае крупный видеофайл) с помощью процесса, включающего BLOB, чтобы снизить потребление памяти.

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Создаёт новую презентацию, в которую будет добавлено видео
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что
      # не планируем обращаться к файлу "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
      # остаётся низким в течение жизненного цикла объекта pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Экспорт большого файла через BLOB из презентации**

Aspose.Slides for PHP via Java позволяет экспортировать большие файлы (например, аудио или видеофайл) с помощью процесса, включающего BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но не загружать его в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код демонстрирует описанную операцию:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Блокирует исходный файл и НЕ загружает его в память
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Создаёт экземпляр Presentation, блокирует файл "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Сохраним каждое видео в файл. Чтобы предотвратить высокий расход памяти, нам нужен буфер, который будет использоваться
    # для передачи данных из видеопотока презентации в поток только что созданного видеофайла.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Перебирает видеоролики
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
      # таким как video.BinaryData - потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
      # загружает байты в память. Мы используем video.GetStream, который возвращает Stream и НЕ
      # требует загрузки всего видео в память.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Потребление памяти останется низким независимо от размера видео или презентации.
    }
    # При необходимости можно применить те же шаги к аудиофайлам.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **Добавление изображения как BLOB в презентацию**

С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) и класса [**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот PHP‑код показывает, как добавить большое изображение через процесс BLOB:
```php
  $pathToLargeImage = "large_image.jpg";
  # создаёт новую презентацию, в которую будет добавлено изображение.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
      # НЕ планируем обращаться к файлу "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
      # остаётся низким в течение жизненного цикла объекта pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Память и большие презентации**

Обычно для загрузки большой презентации компьютерам требуется значительный объём временной памяти. Вся содержимое презентации загружается в память, и файл, из которого была загружена презентация, перестаёт использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл размером 1,5 ГБ. Стандартный метод загрузки презентации описан в этом PHP‑коде:
```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Но этот метод потребляет около 1,6 ГБ временной памяти.

### **Загрузка большой презентации как BLOB**

С помощью процесса, включающего BLOB, вы можете загрузить большую презентацию, используя минимум памяти. Этот PHP‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Изменение папки для временных файлов**

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в стандартной папке для временных файлов. Если вы хотите хранить временные файлы в другой папке, можно изменить настройки хранилища, используя `TempFilesRootPath`:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
При использовании `TempFilesRootPath` Aspose.Slides не создаёт папку для временных файлов автоматически. Вы должны создать папку вручную.
{{% /alert %}}

## **Вопросы и ответы**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются опциями BLOB?**

Большие бинарные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также затрагивается обработкой BLOB при загрузке или сохранении. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и переключаться на временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB во время загрузки презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). Здесь задаётся лимит памяти для BLOB, разрешение или запрет временных файлов, путь к корневой папке для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как найти баланс между скоростью и памятью?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переносит большую часть работы во временные файлы, уменьшая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), чтобы подобрать оптимальный баланс для вашей нагрузки и среды.

**Помогают ли опции BLOB при открытии чрезвычайно больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) разработаны для таких сценариев: включение временных файлов и использование блокировки источника могут существенно снизить пиковое потребление RAM и стабилизировать обработку очень больших наборов слайдов.

**Могу ли я использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, обеспечивая предсказуемое потребление памяти во время обработки.