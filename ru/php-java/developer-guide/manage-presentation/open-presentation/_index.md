---
title: Открытие презентаций в PHP
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/php-java/open-presentation/
keywords:
- открыть PowerPoint
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
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument в PHP, задавать пароли открытия, управлять загрузкой ресурсов и уменьшать использование памяти с помощью Aspose.Slides for PHP via Java."
---
## **Введение**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ru/php-java/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете просматривать её структуру, редактировать слайды, управлять ресурсами и сохранять её в оригинальном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/). Например, вы можете указать пароль открытия, держать большие бинарные объекты вне памяти кучи Java, контролировать внешние ресурсы или исключить встроенные бинарные данные.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, передайте её путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Освободите презентацию после использования, чтобы файловые дескрипторы, временные данные и другие ресурсы были быстро освобождены.

Следующий пример PHP показывает, как открыть презентацию и получить количество её слайдов:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Открытие защищённых паролем презентаций**

Пароль открытия шифрует содержимое презентации. Чтобы загрузить полную презентацию, передайте правильный пароль в [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Загрузка завершается с ошибкой, если пароль отсутствует или неверен.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Для обнаружения пароля, проверки и процессов шифрования см. [Password-Protect Presentations](/slides/ru/php-java/password-protected-presentation/). Если зашифрованная презентация была преднамеренно сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/php-java/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) возвращает параметры, контролирующие, как Aspose.Slides обрабатывает крупные бинарные объекты, такие как изображения, аудио и видео. Вы можете оставить исходный файл заблокированным, разрешить временные файлы и ограничить количество BLOB‑данных, удерживаемых в памяти.

Следующий код PHP демонстрирует загрузку большой презентации (например, 2 ГБ):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Примечание" %}}

С [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) исходный файл остаётся заблокированным до тех пор, пока экземпляр презентации не будет освобождён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока этот экземпляр жив.

Aspose.Slides может копировать содержимое входного потока во время загрузки. Для больших презентаций путь к файлу обычно более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/php-java/manage-blob/) для дополнительных вариантов хранения и управления памятью.

{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) принимает реализацию Java‑интерфейса [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iresourceloadingcallback/) через PHP/Java Bridge. Обратный вызов может предоставлять заменяющие данные, перенаправлять ресурс, использовать загрузчик по умолчанию или пропускать ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо разрешать согласно специфическим для приложения правилам безопасности или хранения.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложение не нуждается или не хочет сохранять. Примеры включают:

- проекты VBA, доступные через [Presentation::getVbaProject](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getVbaProject);
- встроенные OLE‑данные, доступные через [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- данные ActiveX‑контролов, доступные через [Control::getActiveXControlBinary](https://reference.aspose.com/slides/ru/php-java/aspose.slides/control/#getActiveXControlBinary).

Установите [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) в `true`, чтобы удалить эти бинарные данные при загрузке. Сохраните загруженную презентацию, чтобы сохранить очищенный результат.

Эта опция уменьшает риск нежелательных встроенных полезных нагрузок, но не является полной системой обнаружения вредоносного ПО или очистки содержимого.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**Как можно определить, что файл повреждён и не может быть открыт?**

Aspose.Slides бросает исключение парсинга или формата при загрузке. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить причину.

**Что происходит, если необходимые шрифты отсутствуют?**

Презентацию всё ещё можно загрузить, но при рендеринге и экспорте могут быть заменены шрифты. Вы можете [configure font substitution](/slides/ru/php-java/font-substitution/) или [provide custom fonts](/slides/ru/php-java/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружает ли загрузка презентации также её встроенные медиа?**

Встроенные аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются согласно настроенному поведению загрузки ресурсов и могут быть недоступны, если их расположения недоступны.