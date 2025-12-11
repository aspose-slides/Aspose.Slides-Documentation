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
description: "Легко открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для Android через Java — быстро, надёжно, полностью функционально."
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


## **Открытие презентаций, защищённых паролем**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через метод [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) класса [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) для расшифровки и загрузки. Ниже приведён Java‑код, демонстрирующий эту операцию:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Выполните операции над расшифрованной презентацией.
} finally {
    presentation.dispose();
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет параметры — в частности метод [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) класса [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) — которые помогают загружать большие презентации.

Следующий Java‑код демонстрирует загрузку большой презентации (например, 2 ГБ):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// It is OK to do it here. The source file is no longer locked by the presentation object.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить загрузку. Поэтому, когда необходимо загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [BLOB management](/slides/ru/androidjava/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/), который позволяет управлять внешними ресурсами. Следующий Java‑код показывает, как использовать интерфейс `IResourceLoadingCallback`:
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

- проект VBA (доступен через [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- встроенные данные OLE‑объекта (доступны через [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- бинарные данные ActiveX‑контроля (доступны через [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

С помощью метода [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) вы можете загрузить презентацию без каких‑либо встроенных бинарных объектов.

Этот метод полезен для удаления потенциально вредоносного бинарного контента. Следующий Java‑код демонстрирует, как загрузить презентацию без встроенного бинарного контента:
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

**Как определить, что файл повреждён и его нельзя открыть?**

Вы получите исключение при разборе/валидации формата во время загрузки. Такие ошибки часто указывают на недействительную структуру ZIP‑архива или повреждённые записи PowerPoint.

**Что произойдёт, если при открытии недостаёт требуемых шрифтов?**

Файл откроется, но позже [rendering/export](/slides/ru/androidjava/convert-presentation/) может заменить шрифты. [Configure font substitutions](/slides/ru/androidjava/font-substitution/) или [add the required fonts](/slides/ru/androidjava/custom-font/) добавьте необходимые шрифты в среду выполнения.

**Что насчёт встроенных медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа указаны через внешние пути, убедитесь, что эти пути доступны в вашей среде; иначе [rendering/export](/slides/ru/androidjava/convert-presentation/) может опустить медиа.