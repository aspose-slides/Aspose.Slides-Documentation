---
title: Открыть презентацию
linktitle: Открыть презентацию
type: docs
weight: 20
url: /php-java/open-presentation/
keywords: "Открыть PowerPoint, PPTX, PPT, Открыть презентацию, Загрузить презентацию, Java"
description: "Откройте или загрузите презентацию PPT, PPTX, ODP"
---

Кроме создания презентаций PowerPoint с нуля, Aspose.Slides позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержание на слайдах, добавлять новые слайды или удалять существующие и т. д.

## Открыть презентацию

Чтобы открыть существующую презентацию, просто создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и передайте путь к файлу (презентации, которую вы хотите открыть) в его конструктор.

Этот код на PHP показывает, как открыть презентацию и узнать, сколько слайдов в ней содержится:

```php
  # Создает экземпляр класса Presentation и передает путь к файлу в его конструктор
  $pres = new Presentation("Presentation.pptx");
  try {
    # Выводит общее количество слайдов в презентации
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Открыть защищенную паролем презентацию**

Когда вам нужно открыть защищенную паролем презентацию, вы можете передать пароль через свойство [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) (из класса [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)), чтобы расшифровать презентацию и загрузить ее. Этот код на PHP демонстрирует операцию:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("ВАШ_ПАРОЛЬ");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # Выполните некоторые действия с расшифрованной презентацией
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Открыть большую презентацию

Aspose.Slides предоставляет параметры (в частности, свойство [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-)) в классе [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions), чтобы вы могли загружать большие презентации.

Этот Java демонстрирует операцию, при которой загружается большая презентация (например, размером 2 ГБ):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # Большая презентация загружена и может быть использована, но потребление памяти остается низким.
    # вносит изменения в презентацию.
    $pres->getSlides()->get_Item(0)->setName("Очень большая презентация");
    # Презентация будет сохранена в другой файл. Потребление памяти остается низким во время операции
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="Информация" %}}

Чтобы избежать определенных ограничений при взаимодействии с потоком, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через ее поток приведет к копированию содержимого презентации и замедлит загрузку. Поэтому, когда вы собираетесь загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не ее поток.

Когда вы хотите создать презентацию, содержащую большие объекты (видео, аудио, большие изображения и т. д.), вы можете использовать [Blob facility](https://docs.aspose.com/slides/php-java/manage-blob/) для снижения потребления памяти.

{{%/alert %}} 

## Загрузить презентацию

Aspose.Slides предоставляет [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) с единственным методом, чтобы вы могли управлять внешними ресурсами. Этот код на PHP показывает, как использовать интерфейс `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # загружает заменяющее изображение
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # устанавливает заменяющий url
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # пропускает все другие изображения
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## Загрузить презентацию без встроенных бинарных объектов

Презентация PowerPoint может содержать следующие типы встроенных бинарных объектов:

- VBA проект ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- Встроенные данные OLE объектов ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Бинарные данные ActiveX контролов ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Используя свойство [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), вы можете загрузить презентацию без встроенных бинарных объектов.

Это свойство может быть полезным для удаления потенциально вредоносного бинарного содержимого.

Код демонстрирует, как загрузить и сохранить презентацию без вредоносного содержимого:

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## Открыть и сохранить презентацию

Шаги для открытия и сохранения презентации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) и передайте файл, который вы хотите открыть.
2. Сохраните презентацию.  

```php
  # Создает объект Presentation, представляющий файл PPT
  $pres = new Presentation();
  try {
    # ...выполните некоторые действия здесь...
    # Сохраняет вашу презентацию в файл
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```