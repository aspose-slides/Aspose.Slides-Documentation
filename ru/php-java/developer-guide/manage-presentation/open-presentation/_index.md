---
title: Открытие презентаций в PHP
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/php-java/open-presentation/
keywords:
- открыть PowerPoint
- открыть OpenDocument
- открыть презентацию
- открыть PPTX
- открыть PPT
- открыть ODP
- загрузить презентацию
- загрузить PPTX
- загрузить PPT
- загрузить ODP
- защищённая презентация
- большая презентация
- внешний ресурс
- бинарный объект
- PHP
- Aspose.Slides
description: "С лёгкостью открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для PHP через Java — быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получать информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Следующий пример на PHP показывает, как открыть презентацию и получить количество слайдов:
```php
// Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
$presentation = new Presentation("Sample.pptx");
try {
    // Выведите общее количество слайдов в презентации.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **Открытие защищённых паролем презентаций**

Когда требуется открыть презентацию, защищённую паролем, передайте пароль через метод [setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) класса [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) для расшифровки и загрузки. Следующий код на PHP демонстрирует эту операцию:
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Выполняйте операции над расшифрованной презентацией.
} finally {
    $presentation->dispose();
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет возможности — в частности метод [getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) класса [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) — чтобы помочь вам загрузить большие презентации.

Следующий пример на PHP демонстрирует загрузку большой презентации (например, 2 ГБ):
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// It is OK to do it here. The source file is no longer locked by the presentation object.
unlink($filePath);
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлять процесс загрузки. Поэтому, когда вам необходимо загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете воспользоваться [BLOB management](/slides/ru/php-java/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) , который позволяет управлять внешними ресурсами. Следующий код на PHP показывает, как использовать интерфейс `IResourceLoadingCallback`:
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Загрузить заменяющее изображение.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Установить заменяющий URL.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Пропустить все остальные изображения.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **Загрузка презентаций без встроенных бинарных объектов**

Презентация PowerPoint может содержать следующие типы встроенных бинарных объектов:

- VBA‑проект (доступен через [Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject));
- Встроенные данные OLE‑объекта (доступны через [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Бинарные данные управления ActiveX (доступны через [Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary)).

С помощью метода [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) вы можете загрузить презентацию без каких-либо встроенных бинарных объектов.

Этот метод полезен для удаления потенциально вредоносного бинарного контента. Следующий пример на PHP демонстрирует, как загрузить презентацию без любого встроенного бинарного содержимого:
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Выполнять операции над презентацией.
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Как определить, что файл повреждён и его невозможно открыть?**

Во время загрузки вы получите исключение парсинга/валидации формата. Такие ошибки часто указывают на некорректную структуру ZIP‑архива или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют требуемые шрифты?**

Файл откроется, но позже при [рендеринге/экспорте](/slides/ru/php-java/convert-presentation/) могут быть заменены шрифты. [Настройте замену шрифтов](/slides/ru/php-java/font-substitution/) или [добавьте требуемые шрифты](/slides/ru/php-java/custom-font/) в среду выполнения.

**Что происходит с встроенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа ссылаются через внешние пути, убедитесь, что эти пути доступны в вашей среде; иначе при [рендеринге/экспорте](/slides/ru/php-java/convert-presentation/) медиа могут быть опущены.