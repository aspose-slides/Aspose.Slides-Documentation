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
- уменьшить память
- потребление памяти
- большая презентация
- временный файл
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте данными BLOB в Aspose.Slides для PHP через Java, упрощая работу с файлами PowerPoint и OpenDocument для эффективной обработки презентаций."
---

## **О BLOB**

**BLOB** (**Binary Large Object**) обычно представляет собой большой объект (фото, презентацию, документ или медиа), сохранённый в бинарных форматах.  

Aspose.Slides for PHP via Java позволяет использовать BLOB для объектов способом, снижающим потребление памяти при работе с большими файлами.

{{% alert title="Info" color="info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через поток приводит к копированию содержимого презентации и замедляет загрузку. Поэтому, когда вы планируете загружать большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не её поток.
{{% /alert %}}

## **Использование BLOB для снижения потребления памяти**

### **Добавление большого файла через BLOB в презентацию**

[Aspose.Slides](/slides/ru/php-java/) for Java позволяет добавлять большие файлы (в данном случае большой видеофайл) с помощью процесса, включающего BLOB, чтобы снизить потребление памяти.  

Этот пример на Java показывает, как добавить большой видеофайл через процесс BLOB в презентацию:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Создает новую презентацию, к которой будет добавлено видео
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Добавим видео в презентацию - мы выбрали поведение KeepLocked, потому что мы не планируем
      # доступ к файлу "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Сохраняет презентацию. Пока выводится большая презентация, расход памяти
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

Aspose.Slides for PHP via Java позволяет экспортировать большие файлы (в данном случае аудио или видеофайл) с помощью процесса, включающего BLOB, из презентаций. Например, вам может потребоваться извлечь большой медиа‑файл из презентации, но вы не хотите, чтобы файл загружался в память вашего компьютера. При экспорте файла через процесс BLOB потребление памяти остаётся низким.  

Этот код демонстрирует описанную операцию:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Блокирует исходный файл и НЕ загружает его в память
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # создаёт экземпляр Presentation, блокируя файл "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Сохраним каждое видео в файл. Чтобы предотвратить высокое использование памяти, нам нужен буфер, который будет использоваться
    # для переноса данных из видеопотока презентации в поток нового видеофайла.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Перебирает видеоклипы
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Открывает видеопоток презентации. Обратите внимание, что мы намеренно избегали обращения к свойствам
      # таким как video.BinaryData — потому что это свойство возвращает массив байтов, содержащий полное видео, которое затем
      # приводит к загрузке байтов в память. Мы используем video.GetStream, который возвращает Stream и НЕ
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
    # При необходимости вы можете применить те же шаги к аудиофайлам.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **Добавление изображения как BLOB в презентацию**

С помощью методов класса [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) вы можете добавить большое изображение как поток, чтобы оно обрабатывалось как BLOB.  

Этот PHP‑код показывает, как добавить большое изображение через процесс BLOB:
```php
  $pathToLargeImage = "large_image.jpg";
  # создает новую презентацию, к которой будет добавлено изображение.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Добавим изображение в презентацию - мы выбираем поведение KeepLocked, потому что мы
      # НЕ планируем обращаться к файлу "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Сохраняет презентацию. Пока выводится большая презентация, потребление памяти
      # остаётся низким в течение жизненного цикла объекта pres.
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

Как правило, для загрузки большой презентации компьютерам требуется много временной памяти. Всё содержимое презентации загружается в память, а файл (из которого была загружена презентация) перестаёт использоваться.  

Рассмотрим большую презентацию PowerPoint (large.pptx), содержащую видеофайл объёмом 1,5 ГБ. Стандартный метод загрузки презентации описан в этом PHP‑коду:
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


Однако этот метод потребляет около 1,6 ГБ временной памяти.  

### **Загрузка большой презентации как BLOB**

С помощью процесса, включающего BLOB, вы можете загрузить большую презентацию, используя мало памяти. Этот PHP‑код описывает реализацию, где процесс BLOB используется для загрузки большого файла презентации (large.pptx):
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

Когда используется процесс BLOB, ваш компьютер создаёт временные файлы в папке по умолчанию для временных файлов. Если вы хотите, чтобы временные файлы хранились в другой папке, вы можете изменить настройки хранилища, используя `setTempFilesRootPath`:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
При использовании `setTempFilesRootPath` Aspose.Slides не создаёт автоматически папку для хранения временных файлов. Вам необходимо создать папку вручную.
{{% /alert %}}

## **FAQ**

**Какие данные в презентации Aspose.Slides рассматриваются как BLOB и управляются параметрами BLOB?**  
В качестве BLOB рассматриваются большие бинарные объекты, такие как изображения, аудио и видео. При загрузке или сохранении также происходит обработка всего файла презентации как BLOB. Эти объекты регулируются политиками BLOB, позволяющими управлять использованием памяти и при необходимости выгружать данные во временные файлы.

**Где я могу настроить правила обработки BLOB при загрузке презентации?**  
Используйте [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) вместе с [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). Здесь вы задаёте предел памяти для BLOB, разрешаете или запрещаете временные файлы, выбираете корневой путь для временных файлов и определяете поведение блокировки источника.

**Влияют ли настройки BLOB на производительность и как сбалансировать скорость и память?**  
Да. Хранение BLOB в памяти обеспечивает максимальную скорость, но увеличивает потребление ОЗУ; снижение лимита памяти переносит больше работы во временные файлы, уменьшая ОЗУ ценой дополнительного ввода‑вывода. Используйте метод [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/), чтобы достичь оптимального баланса для вашей нагрузки и среды.

**Помогают ли параметры BLOB при открытии чрезвычайно больших презентаций (например, гигабайтных)?**  
Да. [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) предназначены для таких сценариев: включение временных файлов и использование блокировки источника могут значительно снизить пиковое использование ОЗУ и стабилизировать обработку очень больших наборов слайдов.

**Могу ли я использовать политики BLOB при загрузке из потоков, а не из файлов на диске?**  
Да. Те же правила применимы к потокам: экземпляр презентации может владеть и блокировать входной поток (в зависимости от выбранного режима блокировки), а временные файлы используются, если это разрешено, обеспечивая предсказуемое использование памяти во время обработки.