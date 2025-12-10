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
- внешний ресурс
- бинарный объект
- .NET
- C#
- Aspose.Slides
description: "Открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) легко с помощью Aspose.Slides для .NET — быстро, надёжно, с полным набором функций."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получать информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Ниже приведён пример на C#, показывающий, как открыть презентацию и получить количество её слайдов:
```cs
// Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Выведите общее количество слайдов в презентации.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Открытие презентаций, защищённых паролем**

Когда необходимо открыть презентацию, защищённую паролем, укажите пароль через свойство [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) класса [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) для расшифровки и загрузки. Ниже показан соответствующий код на C#:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Выполните операции над расшифрованной презентацией.
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет параметры — в частности свойство [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) класса [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) — для загрузки больших презентаций.

Ниже пример кода на C#, демонстрирующий загрузку большой презентации (например, 2 ГБ):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Выберите поведение KeepLocked — файл презентации будет оставаться заблокированным в течение срока действия 
        // экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Большая презентация была загружена и может использоваться, при этом потребление памяти остается низким.

    // Внесите изменения в презентацию.
    presentation.Slides[0].Name = "Large presentation";

    // Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Не делайте этого! Будет выброшено исключение ввода-вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет освобождён.
    File.Delete(filePath);
}

// Это можно сделать здесь. Исходный файл больше не заблокирован объектом презентации.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Для обхода некоторых ограничений при работе с потоками Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить процесс загрузки. Поэтому, когда необходимо загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей большие объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете воспользоваться [BLOB management](/slides/ru/net/manage-blob/), чтобы снизить потребление памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/), позволяющий контролировать внешние ресурсы. Ниже пример кода на C#, показывающий, как использовать интерфейс `IResourceLoadingCallback`:
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


## **Загрузка презентаций без встроенных бинарных объектов**

Презентация PowerPoint может содержать следующие типы встроенных бинарных объектов:

- Проект VBA (доступно через [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Встроенные данные OLE‑объекта (доступно через [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Бинарные данные управления ActiveX (доступно через [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Используя свойство [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), можно загрузить презентацию без каких‑либо встроенных бинарных объектов.

Это свойство полезно для удаления потенциально вредоносного бинарного контента. Ниже пример кода на C#, демонстрирующий загрузку презентации без встроенного бинарного контента:
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Выполните операции над презентацией.
}
```


## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

При загрузке будет выброшено исключение парсинга/валидации формата. Такие ошибки часто указывают на неверную структуру ZIP‑архива или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют требуемые шрифты?**

Файл откроется, но последующее [рендеринг/экспорт](/slides/ru/net/convert-presentation/) может заменить шрифты. Используйте [настройку замен шрифтов](/slides/ru/net/font-substitution/) или [добавьте необходимые шрифты](/slides/ru/net/custom-font/) в среду выполнения.

**Что происходит с встроенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа‑файлы ссылаются на внешние пути, убедитесь, что эти пути доступны в вашей среде; в противном случае [рендеринг/экспорт](/slides/ru/net/convert-presentation/) может их опустить.