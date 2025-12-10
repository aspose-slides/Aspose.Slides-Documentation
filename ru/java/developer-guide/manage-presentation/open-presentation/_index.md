---
title: Открытие презентаций в Java
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Лёгко открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для Java - быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

В следующем примере на Java показано, как открыть презентацию и получить количество слайдов:
```java
// Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Выведите общее количество слайдов в презентации.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Открытие презентаций, защищённых паролем**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через метод [setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) класса [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) для расшифровки и загрузки. В следующем примере на Java продемонстрирована эта операция:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Perform operations on the decrypted presentation.
} finally {
    presentation.dispose();
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет возможности — в частности метод [getBlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) в классе [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) — чтобы помочь вам загружать большие презентации.

В следующем примере на Java показана загрузка большой презентации (например, 2 ГБ):
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
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Выберите поведение KeepLocked — файл презентации будет оставаться заблокированным в течение срока жизни
// экземпляра Presentation, но его не нужно загружать в память или копировать во временный файл.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 МБ

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Большая презентация загружена и может использоваться, при этом потребление памяти остаётся низким.

    // Внесите изменения в презентацию.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Не делайте этого! Будет выброшено исключение ввода-вывода, так как файл заблокирован до освобождения объекта презентации.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Это можно сделать здесь. Исходный файл больше не заблокирован объектом презентации.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Чтобы обойти определённые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить процесс загрузки. Поэтому, когда необходимо загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [BLOB management](/slides/ru/java/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) , который позволяет управлять внешними ресурсами. В следующем примере на Java показано, как использовать интерфейс `IResourceLoadingCallback`:
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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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

- VBA‑проект (доступный через [IPresentation.getVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Встроенные данные OLE‑объекта (доступные через [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Бинарные данные управления ActiveX (доступные через [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Используя метод [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), вы можете загрузить презентацию без каких-либо встроенных бинарных объектов.

Этот метод полезен для удаления потенциально вредоносного бинарного содержимого. В следующем примере на Java показано, как загрузить презентацию без какого-либо встроенного бинарного контента:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Выполните операции с презентацией.
} finally {
    presentation.dispose();
}
```


## **Часто задаваемые вопросы**

**Как узнать, что файл повреждён и его нельзя открыть?**

Во время загрузки вы получите исключение при разборе/проверке формата. Такие ошибки часто указывают на некорректную структуру ZIP или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют необходимые шрифты?**

Файл откроется, но последующее [rendering/export](/slides/ru/java/convert-presentation/) может заменить шрифты. [Configure font substitutions](/slides/ru/java/font-substitution/) или [add the required fonts](/slides/ru/java/custom-font/) в среду выполнения.

**Что происходит с вложенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа находятся по внешним путям, убедитесь, что эти пути доступны в вашей среде; в противном случае [rendering/export](/slides/ru/java/convert-presentation/) может исключить медиа.