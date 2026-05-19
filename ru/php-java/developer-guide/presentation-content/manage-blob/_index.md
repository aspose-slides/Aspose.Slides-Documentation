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
## **Обзор**

Aspose.Slides предоставляет обработку на основе BLOB для больших двоичных данных в презентациях, помогая уменьшить потребление памяти при работе с крупными изображениями, аудио, видео и файлами презентаций.

В этой статье показано, как использовать обработку на основе BLOB для добавления больших мультимедийных файлов в презентацию, экспорта больших медиаданных из презентации и более эффективной загрузки больших презентаций. Также объясняется, как во время обработки можно использовать временные файлы и как изменить папку, в которой они хранятся.

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиаданные), сохранённый в двоичном формате.

Aspose.Slides for PHP via Java позволяет использовать BLOB для объектов таким образом, чтобы уменьшить потребление памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}

Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через её поток приведёт к копированию содержимого презентации и замедлит загрузку. Поэтому, когда вы планируете загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.

{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/php-java/) for Java позволяет добавлять большие файлы (в данном случае большой видеофайл) через процесс, использующий BLOB, чтобы снизить потребление памяти.

Этот пример Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Создаёт новую презентацию, в которую будет добавлено видео
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Добавим видео в презентацию — мы выбрали поведение KeepLocked, потому что мы
      # не планируем получать доступ к файлу "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
      # остается низким в течение жизненного цикла объекта pres
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

Aspose.Slides for PHP via Java позволяет экспортировать большие файлы (в данном случае аудио‑ или видеофайл) из презентаций через процесс, использующий BLOB. Например, вам может потребоваться извлечь большой медиафайл из презентации, но не загружать его полностью в память компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код демонстрирует описанную операцию:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Блокирует исходный файл и НЕ загружает его в память
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Создать экземпляр Presentation, заблокировать файл "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Сохраним каждое video в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использоваться
    # для передачи данных из видеопотока презентации в поток для вновь созданного видеофайла.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Iterates through the videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегаем доступа к свойствам
      # таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
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
    # При необходимости вы можете применить те же шаги к аудиофайлам.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Добавление изображения как BLOB в презентацию**

С помощью методов класса [ImageCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imagecollection/) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.

Этот PHP‑код показывает, как добавить большое изображение через процесс BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # создаёт новую презентацию, в которую будет добавлено изображение.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Добавим изображение в презентацию — мы выбираем поведение KeepLocked, потому что мы
      # НЕ планируем получать доступ к файлу "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
      # остается низким в течение жизненного цикла объекта pres
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

Обычно для загрузки большой презентации компьютерам требуется значительное количество временной памяти. Весь контент презентации загружается в память, и файл, из которого была загружена презентация, перестаёт использоваться.

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

Через процесс, использующий BLOB, можно загрузить большую презентацию, используя минимум памяти. Этот PHP‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):

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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в стандартной папке для временных файлов. Если необходимо хранить временные файлы в другой папке, можно изменить настройки хранилища с помощью `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}

При использовании `setTempFilesRootPath` Aspose.Slides не создаёт папку для временных файлов автоматически. Папку нужно создать вручную.

{{% /alert %}}

### **Освобождение объектов Presentation для высвобождения памяти**

При обработке больших презентаций убедитесь, что экземпляр [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) правильно освобождается, чтобы освободить занятую им память. Вызовите `dispose()` после завершения работы с презентацией, чтобы освободить неуправляемые ресурсы.

```php
$presentation = new Presentation("large.pptx");

# ...обработать презентацию...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Явно освобождаем ресурсы.
$presentation->dispose();
```

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и контролируются параметрами BLOB?**

Большие двоичные объекты, такие как изображения, аудио и видео, рассматриваются как BLOB. Сам файл презентации также участвует в обработке BLOB при загрузке или сохранении. Эти объекты управляются политиками BLOB, позволяющими контролировать использование памяти и запись во временные файлы при необходимости.

**Где я могу настроить правила обработки BLOB во время загрузки презентации?**

Используйте [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/) совместно с [BlobManagementOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/blobmanagementoptions/). Здесь задаётся ограничение памяти для BLOB, разрешение или запрет временных файлов, путь к корневой папке для временных файлов и поведение блокировки источника.

**Влияют ли настройки BLOB на производительность, и как сбалансировать скорость и память?**

Да. Хранение BLOB в памяти максимизирует скорость, но увеличивает потребление ОЗУ; уменьшение лимита памяти переводит большую часть работы во временные файлы, снижая ОЗУ за счёт дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) для достижения оптимального баланса под вашу нагрузку и окружение.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, в гигабайтах)?**

Да. [BlobManagementOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут существенно сократить пиковое потребление ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Можно ли использовать политики BLOB при загрузке из потоков вместо файлов на диске?**

Да. Те же правила применяются к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, обеспечивая предсказуемое использование памяти во время обработки.