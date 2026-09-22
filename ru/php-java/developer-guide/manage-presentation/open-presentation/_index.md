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

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ru/php-java/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете изучать её структуру, редактировать слайды, управлять ресурсами и сохранять её в исходном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/). Например, вы можете указать пароль открытия, хранить большие бинарные объекты за пределами памяти кучи Java, контролировать внешние ресурсы или исключать встроенные бинарные данные.

## **Открытие презентаций**

После загрузки файла или потока вы можете [определить исходный формат презентации](/slides/ru/php-java/detect-presentation-source-format/), чтобы выбрать способ обработки его вашим приложением.

Чтобы открыть существующую презентацию, передайте её путь к файлу конструктору [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Освободите презентацию после использования, чтобы файловые дескрипторы, временные данные и другие ресурсы были быстро освобождены.

Следующий пример на PHP показывает, как открыть презентацию и получить количество её слайдов:

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

Пароль открытия шифрует содержимое презентации. Чтобы загрузить полную презентацию, передайте правильный пароль в [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword) и передайте параметры конструктору [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Загрузка не удалась, если пароль отсутствует или неверен.

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

Для обнаружения пароля, проверки и схем шифрования см. [Защита презентаций паролем](/slides/ru/php-java/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с общедоступными свойствами документа, эти свойства можно прочитать без пароля; см. [Управление свойствами презентации](/slides/ru/php-java/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) возвращает параметры, управляющие тем, как Aspose.Slides обрабатывает большие двоичные объекты, такие как изображения, аудио и видео. Вы можете удерживать исходный файл заблокированным, разрешать временные файлы и ограничивать объём данных BLOB, сохраняемых в памяти.

Следующий код на PHP демонстрирует загрузку большой презентации (например, 2 ГБ):

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

{{% alert color="info" title="Note" %}}
С [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) исходный файл остается заблокированным до тех пор, пока экземпляр презентации не будет освобождён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока этот экземпляр жив.

Aspose.Slides может копировать содержимое входного потока при загрузке. Для больших презентаций путь к файлу, как правило, более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/php-java/manage-blob/) для получения дополнительных вариантов хранения и управления памятью.
{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) принимает реализацию Java-интерфейса [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iresourceloadingcallback/) через PHP/Java Bridge. Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо разрешать в соответствии с правилами безопасности или хранения, специфичными для приложения.

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

## **Загрузка презентаций без встроенных двоичных объектов**

Презентация может содержать встроенные двоичные данные, которые приложение не нуждается или не хочет сохранять. Примеры включают:

- VBA‑проекты, доступные через [Presentation::getVbaProject](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getVbaProject);
- встроенные OLE‑данные, доступные через [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- данные элементов управления ActiveX, доступные через [Control::getActiveXControlBinary](https://reference.aspose.com/slides/ru/php-java/aspose.slides/control/#getActiveXControlBinary).

Установите [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) в `true`, чтобы удалить эти двоичные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Эта опция снижает риск наличия нежелательных встроенных полезных нагрузок, но не является полноценной системой обнаружения вредоносного кода или очистки содержимого.

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

## **Вопросы и ответы**

**Как понять, что файл повреждён и его нельзя открыть?**

Aspose.Slides бросает исключение парсинга или формата при загрузке. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить о причине.

**Что происходит, если требуемые шрифты отсутствуют?**

Презентацию всё ещё можно загрузить, но при рендеринге и экспорте могут использоваться заменяющие шрифты. Вы можете [настроить замену шрифтов](/slides/ru/php-java/font-substitution/) или [предоставить пользовательские шрифты](/slides/ru/php-java/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружает ли загрузка презентации также встроенные медиафайлы?**

Встроенные аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются в соответствии с настроенным поведением загрузки ресурсов и могут быть недоступны, если их расположения недоступны.