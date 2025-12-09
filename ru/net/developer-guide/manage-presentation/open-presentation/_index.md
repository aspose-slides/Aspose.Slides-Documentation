---
title: Открытие презентаций в .NET
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/net/open-presentation/
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
- внешние ресурсы
- бинарный объект
- .NET
- C#
- Aspose.Slides
description: "Легко открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для .NET — быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и передайте в его конструктор путь к файлу.

Следующий пример на C# показывает, как открыть презентацию и получить количество её слайдов:
```cs
// Создайте объект класса Presentation и передайте путь к файлу в его конструктор.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Выведите общее количество слайдов в презентации.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Открытие защищённых паролем презентаций**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через свойство [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) класса [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) для её расшифровки и загрузки. Следующий код на C# демонстрирует эту операцию:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Выполняйте операции над расшифрованной презентацией.
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет возможности — в частности свойство [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) в классе [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) — для загрузки больших презентаций.

Следующий код на C# демонстрирует загрузку большой презентации (например, 2 ГБ):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Выберите поведение KeepLocked — файл презентации останется заблокированным в течение всей жизни 
        // экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 МБ
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Большая презентация загружена и может использоваться, при этом потребление памяти остаётся низким.

    // Внесите изменения в презентацию.
    presentation.Slides[0].Name = "Large presentation";

    // Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Не делайте этого! Будет выброшено исключение ввода‑вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет освобождён.
    File.Delete(filePath);
}

// Здесь можно выполнить это. Исходный файл больше не заблокирован объектом презентации.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Для обхода некоторых ограничений при работе с потоками Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить процесс. Поэтому, когда необходимо загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей крупные объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [управление BLOB](/slides/ru/net/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/), позволяющий управлять внешними ресурсами. Следующий код на C# показывает, как использовать интерфейс `IResourceLoadingCallback`:
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Загрузить заменяющее изображение.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Установить заменяющий URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Пропустить все остальные изображения.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Загрузка презентаций без внедрённых бинарных объектов**

Презентация PowerPoint может содержать следующие типы внедрённых бинарных объектов:

- VBA‑проект (доступен через [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Встроенные данные OLE‑объекта (доступны через [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Бинарные данные управления ActiveX (доступны через [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

С помощью свойства [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) вы можете загрузить презентацию без каких‑либо внедрённых бинарных объектов.

Это свойство полезно для удаления потенциально вредоносного бинарного контента. Следующий код на C# демонстрирует, как загрузить презентацию без внедрённого бинарного контента:
```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Выполняйте операции над презентацией.
}
```


## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

Во время загрузки будет выброшено исключение парсинга/валидации формата. Такие ошибки часто указывают на недействительную ZIP‑структуру или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют требуемые шрифты?**

Файл откроется, но дальнейшее [рендеринг/экспорт](/slides/ru/net/convert-presentation/) может заменить шрифты. [Настройте подстановку шрифтов](/slides/ru/net/font-substitution/) или [добавьте необходимые шрифты](/slides/ru/net/custom-font/) в среду выполнения.

**Как обрабатываются встроенные медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа ссылаются на внешние пути, убедитесь, что эти пути доступны в вашей среде; иначе при [рендеринге/экспорте](/slides/ru/net/convert-presentation/) медиа могут быть пропущены.