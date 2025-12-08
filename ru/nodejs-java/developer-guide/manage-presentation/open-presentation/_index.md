---
title: Открыть презентацию на JavaScript
linktitle: Открыть презентации
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
description: "Легко открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для Node.js — быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получать информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Следующий пример на JavaScript демонстрирует, как открыть презентацию и получить количество слайдов:
```js
// Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Выведите общее количество слайдов в презентации.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Открытие защищённых паролем презентаций**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через метод [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword) класса [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) , чтобы расшифровать и загрузить её. Следующий код на JavaScript демонстрирует эту операцию:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Выполните операции над расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет параметры — в частности метод [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) класса [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) , который помогает загружать большие презентации.

Следующий код на JavaScript демонстрирует загрузку большой презентации (например, 2 ГБ):
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Выберите поведение KeepLocked — файл презентации останется заблокированным на весь срок
// жизни экземпляра Presentation, но его не нужно загружать в память или копировать во временный файл.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 МБ

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Большая презентация загружена и может использоваться, при этом потребление памяти остаётся низким.
    
    // Внесите изменения в презентацию.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Не делайте этого! Будет выброшено исключение ввода/вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет освобождён.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Здесь это можно сделать. Исходный файл больше не заблокирован объектом презентации.
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить процесс загрузки. Поэтому, если вам необходимо загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [BLOB management](/slides/ru/nodejs-java/manage-blob/), чтобы снизить расход памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) , который позволяет управлять внешними ресурсами. Следующий код на JavaScript показывает, как использовать интерфейс `IResourceLoadingCallback`:
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Загрузить заменяющее изображение.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Задать заменяющий URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Пропустить все остальные изображения.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **Загрузка презентаций без встроенных бинарных объектов**

PowerPoint‑презентация может содержать следующие типы встроенных бинарных объектов:

- VBA‑проект (доступен через [Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject));
- Встроенные данные OLE‑объекта (доступны через [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Бинарные данные ActiveX‑контрола (доступны через [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

С помощью метода [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) можно загрузить презентацию без каких‑либо встроенных бинарных объектов.

Этот метод полезен для удаления потенциально вредоносного бинарного содержимого. Следующий код на JavaScript демонстрирует, как загрузить презентацию без любого встроенного бинарного контента:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Выполните операции над презентацией.
} finally {
    presentation.dispose();
}
```


## **Вопросы и ответы**

**Как определить, что файл повреждён и не может быть открыт?**

При загрузке вы получите исключение парсинга/валидации формата. Такие ошибки часто указывают на некорректную структуру ZIP‑архива или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют требуемые шрифты?**

Файл откроется, но при последующем [отрисовывании/экспорте](/slides/ru/nodejs-java/convert-presentation/) шрифты могут быть заменены. [Настройте замену шрифтов](/slides/ru/nodejs-java/font-substitution/) или [добавьте требуемые шрифты](/slides/ru/nodejs-java/custom-font/) в среду выполнения.

**Что происходит с встроенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа‑файлы указаны через внешние пути, убедитесь, что эти пути доступны в вашей среде; иначе при [отрисовывании/экспорте](/slides/ru/nodejs-java/convert-presentation/) медиа могут быть опущены.