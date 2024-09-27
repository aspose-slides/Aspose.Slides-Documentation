---
title: Управление BLOB
type: docs
weight: 10
url: /ru/php-java/manage-blob/
description: Управление BLOB в презентации PowerPoint с использованием PHP. Используйте BLOB для снижения потребления памяти в презентации PowerPoint с использованием PHP. Добавьте большой файл через BLOB в презентацию PowerPoint с использованием PHP. Экспортируйте большой файл через BLOB из презентации PowerPoint с использованием PHP. Загружайте большую презентацию PowerPoint как BLOB с использованием PHP.
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентация, документ или медиафайл), сохраненный в двоичных форматах.

Aspose.Slides для PHP через Java позволяет использовать BLOB для объектов так, чтобы уменьшить потребление памяти при обработке больших файлов.

{{% alert title="Информация" color="info" %}}

Чтобы обойти определенные ограничения при взаимодействии с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через ее поток приведет к копированию содержимого презентации и вызовет медленную загрузку. Поэтому, когда вы собираетесь загружать большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не ее поток.

{{% /alert %}}

## **Используйте BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/php-java/) для Java позволяет добавлять большие файлы (в этом случае большой видеофайл) через процесс, связанный с BLOB, для снижения потребления памяти.

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Создает новую презентацию, в которую будет добавлено видео
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Давайте добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы не собираемся
      # получать доступ к файлу "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Сохраняет презентацию. Хотя большая презентация выводится, потребление памяти
      # остается низким на протяжении всего жизненного цикла объекта pres
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
Aspose.Slides для PHP через Java позволяет экспортировать большие файлы (в этом случае аудио или видеофайл) через процесс, связанный с BLOB, из презентаций. Например, вам может понадобиться извлечь большой медиафайл из презентации, но вы не хотите, чтобы файл загружался в память вашего компьютера. Экспортируя файл через процесс BLOB, вы сохраняете низкое потребление памяти.

Этот код демонстрирует описанную операцию:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Блокирует исходный файл и НЕ загружает его в память
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # создаем экземпляр Презентации, блокируем файл "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Давайте сохраним каждое видео в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использоваться
    # для передачи данных из видеопотока презентации в поток для вновь созданного видеофайла.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Итерируемся по видео
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали доступа к свойствам
      # как video.BinaryData - потому что это свойство возвращает массив байтов, содержащий полное видео, что затем
      # вызывает загрузку байтов в память. Мы используем video.GetStream, который вернет Stream - и это НЕ
      # требует от нас загрузки всего видео в память.
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
    # Если необходимо, вы можете применить те же шаги для аудиофайлов.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Добавление изображения как BLOB в презентацию**
С помощью методов интерфейса [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) и класса [**ImageCollection** ](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection) вы можете добавить большое изображение как поток, чтобы оно считалось BLOB.

Этот код на PHP показывает, как добавить большое изображение через процесс BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # создает новую презентацию, в которую будет добавлено изображение.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Давайте добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы не собираемся
      # получать доступ к файлу "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Сохраняет презентацию. Хотя большая презентация выводится, потребление памяти
      # остается низким на протяжении всего жизненного цикла объекта pres
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

Обычно для загрузки большой презентации компьютерам требуется много временной памяти. Все содержимое презентации загружается в память, и файл (из которого была загружена презентация) перестает использоваться.

Рассмотрим большую презентацию PowerPoint (large.pptx), которая содержит видеофайл объемом 1,5 ГБ. Обычный метод загрузки презентации описан в этом коде на PHP:

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

С помощью процесса, связанного с BLOB, вы можете загрузить большую презентацию, используя при этом мало памяти. Этот код на PHP описывает реализацию, где используется процесс BLOB для загрузки большого файла презентации (large.pptx):

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

Когда используется процесс BLOB, ваш компьютер создает временные файлы в стандартной папке для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки хранения, используя `TempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Информация" color="info" %}}

Когда вы используете `TempFilesRootPath`, Aspose.Slides автоматически не создает папку для хранения временных файлов. Вам нужно создать папку вручную. 

{{% /alert %}}