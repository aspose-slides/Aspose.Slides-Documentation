---
title: Открытие презентаций в JavaScript
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument в JavaScript, задавать пароли при открытии, управлять загрузкой ресурсов и уменьшать использование памяти с помощью Aspose.Slides для Node.js через Java."
---
## **Введение**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/ru/nodejs-java/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете просматривать её структуру, редактировать слайды, управлять ресурсами и сохранять её в исходном или другом поддерживаемом формате.

Поведение загрузки можно настроить через класс [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/). Например, можно указать пароль для открытия, удерживать крупные бинарные объекты вне памяти Node.js, контролировать внешние ресурсы или опустить встроенные бинарные данные.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, передайте её путь к файлу конструктору [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). После использования освобождайте презентацию, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

Ниже приведён пример JavaScript, показывающий, как открыть презентацию и получить количество её слайдов:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Открытие презентаций, защищённых паролем**

Пароль при открытии шифрует содержимое презентации. Чтобы загрузить полную презентацию, передайте правильный пароль методу [LoadOptions.setPassword](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setPassword) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Загрузка будет неудачной, если пароль отсутствует или неверен.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Для обнаружения пароля, проверки и процессов шифрования см. раздел [Password-Protect Presentations](/slides/ru/nodejs-java/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с открытыми свойствами документа, эти свойства можно прочитать без пароля; см. раздел [Manage Presentation Properties](/slides/ru/nodejs-java/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) возвращает параметры, которые управляют тем, как Aspose.Slides обрабатывает крупные бинарные объекты, такие как изображения, аудио и видео. Вы можете удерживать исходный файл заблокированным, разрешать использование временных файлов и ограничивать количество BLOB‑данных, сохраняемых в памяти.

Ниже показан JavaScript‑код, демонстрирующий загрузку большой презентации (например, 2 ГБ):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}

С помощью [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) исходный файл остаётся заблокированным до тех пор, пока экземпляр презентации не будет освобождён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока такой экземпляр существует.

Aspose.Slides может копировать содержимое входного потока во время его загрузки. Для больших презентаций путь к файлу, как правило, более эффективен, чем поток. См. раздел [Manage BLOBs](/slides/ru/nodejs-java/manage-blob/) для дополнительных вариантов хранения и управления памятью.

{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) принимает реализацию [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iresourceloadingcallback/). Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо разрешать в соответствии с правилами безопасности или хранения, специфическими для приложения.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложение не нуждается или не хочет сохранять. Примеры включают:

- проекты VBA, доступные через [Presentation.getVbaProject](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getVbaProject);
- встроенные OLE‑данные, доступные через [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- данные элементов управления ActiveX, доступные через [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Установите [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) в `true`, чтобы удалить эти бинарные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Эта опция уменьшает риск нежелательных встроенных полезных нагрузок, но не является полноценной системой обнаружения вредоносного кода или очистки контента.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Как определить, что файл повреждён и не может быть открыт?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить о причине.

**Что происходит, если отсутствуют требуемые шрифты?**

Презентацию всё равно можно загрузить, но при рендеринге и экспорте шрифты могут быть заменены. Вы можете [настроить замену шрифтов](/slides/ru/nodejs-java/font-substitution/) или [предоставить пользовательские шрифты](/slides/ru/nodejs-java/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружается ли вместе с презентацией её встроенное медиа?**

Встроенные аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются согласно настроенному поведению загрузки ресурсов и могут быть недоступны, если их местоположения недоступны.