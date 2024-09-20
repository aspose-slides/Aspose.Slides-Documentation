---
title: Открыть презентацию в Java
linktitle: Открыть презентацию
type: docs
weight: 20
url: /java/open-presentation/
keywords: "Открыть PowerPoint, PPTX, PPT, Открыть презентацию, Загрузить презентацию, Java"
description: "Открыть или загрузить презентацию PPT, PPTX, ODP в Java"
---

Кроме создания презентаций PowerPoint с нуля, Aspose.Slides позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о презентации, редактировать презентацию (содержимое на ее слайдах), добавлять новые слайды или удалять существующие и т. д.

## Открыть презентацию

Чтобы открыть существующую презентацию, вам просто нужно создать экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и передать путь к файлу (то есть к презентации, которую вы хотите открыть) в его конструктор.

Этот код на Java демонстрирует, как открыть презентацию и также узнать количество слайдов, которые она содержит:

```java
// Создает экземпляр класса Presentation и передает путь к файлу в его конструктор
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Выводит общее количество слайдов в презентации
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Открыть презентацию с защитой паролем**

Когда вам нужно открыть защищенную паролем презентацию, вы можете передать пароль через свойство [Password](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getPassword--) (из класса [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)), чтобы расшифровать и загрузить презентацию. Этот код на Java демонстрирует операцию:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("ВАШ_ПАРОЛЬ");
Presentation pres = new Presentation("pres.pptx", loadOptions);
try {
// Выполните некоторые действия с расшифрованной презентацией
} finally {
    if (pres != null) pres.dispose();
}
```

## Открыть большую презентацию

Aspose.Slides предоставляет опции (в частности, свойство [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-)) в классе [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) для загрузки больших презентаций.

Этот код на Java демонстрирует операцию, в которой загружается большая презентация (например, размером 2 ГБ):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // Большая презентация загружена и может быть использована, но потребление памяти остается низким.
    // вносит изменения в презентацию.
    pres.getSlides().get_Item(0).setName("Очень большая презентация");

    // Презентация будет сохранена в другой файл. Потребление памяти остается низким во время операции.
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="Информация" %}}

Чтобы обойти некоторые ограничения при взаимодействии с потоком, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации через ее поток приведет к копированию содержимого презентации и замедлению загрузки. Поэтому, когда вы намерены загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не ее поток.

Когда вы хотите создать презентацию, содержащую крупные объекты (видео, аудио, большие изображения и т. д.), вы можете использовать [возможности Blob](https://docs.aspose.com/slides/java/manage-blob/), чтобы уменьшить потребление памяти.

{{%/alert %}}

## Загрузить презентацию

Aspose.Slides предоставляет [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) с единственным методом, который позволяет управлять внешними ресурсами. Этот код на Java демонстрирует, как использовать интерфейс `IResourceLoadingCallback`:

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // загружает заменяющее изображение
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // устанавливает заменяющий URL
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // пропускает все остальные изображения
        return ResourceLoadingAction.Skip;
    }
}
```

## Загрузить презентацию без встроенных бинарных объектов

Презентация PowerPoint может содержать следующие типы встроенных бинарных объектов:

- VBA проект ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- Встроенные данные OLE объектов ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Данные бинарных ActiveX контролов ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Используя свойство [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), вы можете загрузить презентацию без каких-либо встроенных бинарных объектов.

Это свойство может быть полезно для удаления потенциально вредоносного бинарного содержимого.

Код демонстрирует, как загрузить и сохранить презентацию без какого-либо вредоносного содержимого:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## Открыть и сохранить презентацию

Шаги для открытия и сохранения презентации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и передайте файл, который вы хотите открыть.
2. Сохраните презентацию.  

```java
// Создает объект Presentation, представляющий файл PPT
Presentation pres = new Presentation();
try {
    // ...выполните некоторые действия здесь...
    
    // Сохраняет вашу презентацию в файл
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```