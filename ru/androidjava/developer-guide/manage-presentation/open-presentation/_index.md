---
title: Открытие презентаций на Android
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) без труда с помощью Aspose.Slides для Android через Java — быстро, надёжно, полнофункционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получать информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Следующий пример на Java показывает, как открыть презентацию и получить количество слайдов:
```java
// Создайте объект класса Presentation и передайте путь к файлу в его конструктор.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Выведите общее количество слайдов в презентации.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Открытие защищённых паролем презентаций**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через метод [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) класса [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) для расшифровки и загрузки. Следующий код на Java демонстрирует эту операцию:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Выполняйте операции с расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет параметры — в частности метод [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) класса [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) — которые помогают загружать большие презентации.

Следующий код на Java демонстрирует загрузку большой презентации (например, 2 ГБ):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Выберите поведение KeepLocked — файл презентации останется заблокированным в течение
// экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Большая презентация загружена и может использоваться, при этом потребление памяти остается низким.

    // Внесите изменения в презентацию.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Не делайте этого! Будет выброшено исключение ввода-вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет освобождён.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Можно выполнить это здесь. Исходный файл больше не заблокирован объектом презентации.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Чтобы обойти определённые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить загрузку. Поэтому, когда необходимо загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей большие объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [BLOB management](/slides/ru/androidjava/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/), который позволяет управлять внешними ресурсами. Следующий код на Java показывает, как использовать интерфейс `IResourceLoadingCallback`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Загрузить заменяющее изображение.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Используйте любой метод для получения байтов
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Установить заменяющий URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Пропустить все остальные изображения.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Загрузка презентаций без встроенных бинарных объектов**

Презентация PowerPoint может содержать следующие типы встроенных бинарных объектов:

- VBA‑проект (доступно через [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Встроенные данные OLE‑объекта (доступно через [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Бинарные данные управления ActiveX (доступно через [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

С помощью метода [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) вы можете загрузить презентацию без каких-либо встроенных бинарных объектов.

Этот метод полезен для удаления потенциально вредоносного бинарного контента. Следующий код на Java демонстрирует, как загрузить презентацию без встроенного бинарного контента:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Выполните операции над презентацией.
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Как понять, что файл повреждён и его нельзя открыть?**

Во время загрузки возникнет исключение парсинга/валидации формата. Такие ошибки часто указывают на недопустимую структуру ZIP‑файла или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют требуемые шрифты?**

Файл откроется, но при последующем [rendering/export](/slides/ru/androidjava/convert-presentation/) могут быть заменены шрифты. [Configure font substitutions](/slides/ru/androidjava/font-substitution/) или [add the required fonts](/slides/ru/androidjava/custom-font/) в среде выполнения.

**Что происходит с встроенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа ссылки указаны во внешних путях, убедитесь, что эти пути доступны в вашей среде; иначе при [rendering/export](/slides/ru/androidjava/convert-presentation/) медиа могут быть пропущены.