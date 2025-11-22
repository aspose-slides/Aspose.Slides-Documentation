---
title: Открыть презентацию на C#
linktitle: Открыть презентации
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
description: "Откройте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) легко с помощью Aspose.Slides для .NET — быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Следующий пример на C# показывает, как открыть презентацию и получить количество её слайдов:
```cs
// Создайте экземпляр класса Presentation и передайте путь к файлу в его конструктор.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Выведите общее количество слайдов в презентации.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Открытие защищённых паролем презентаций**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через свойство [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) класса [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) для расшифровки и загрузки. Следующий пример на C# демонстрирует эту операцию:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Выполните операции над расшифрованной презентацией.
}
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет параметры — в частности свойство [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) в классе [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) — позволяющие загружать большие презентации.

Следующий пример на C# демонстрирует загрузку большой презентации (например, 2 ГБ):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Выберите поведение KeepLocked — файл презентации останется заблокированным на протяжении всего времени
        // экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 МБ
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Большая презентация загружена и может быть использована, при этом потребление памяти остается низким.

    // Внесите изменения в презентацию.
    presentation.Slides[0].Name = "Large presentation";

    // Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Не делайте этого! Будет выброшено исключение ввода‑вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет освобождён.
    File.Delete(filePath);
}

// Здесь это можно сделать. Исходный файл больше не заблокирован объектом презентации.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить загрузку. Поэтому, когда необходимо загрузить большую презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей большие объекты (видео, аудио, изображения высокого разрешения и т.д.), вы можете использовать [BLOB management](/slides/ru/net/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/), который позволяет управлять внешними ресурсами. Следующий пример на C# показывает, как использовать интерфейс `IResourceLoadingCallback`:
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

- VBA‑проект (доступен через [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Встроенные данные OLE‑объекта (доступны через [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Бинарные данные управления ActiveX (доступны через [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Используя свойство [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), вы можете загрузить презентацию без каких-либо встроенных бинарных объектов.

Это свойство полезно для удаления потенциально вредоносного бинарного контента. Следующий пример на C# демонстрирует, как загрузить презентацию без встроенного бинарного контента:
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


## **Часто задаваемые вопросы**

**Как определить, что файл повреждён и не может быть открыт?**

При загрузке будет выброшено исключение парсинга/проверки формата. Такие ошибки часто указывают на недействительную структуру ZIP или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют необходимые шрифты?**

Файл откроется, но позже при [rendering/export](/slides/ru/net/convert-presentation/) может произойти подстановка шрифтов. [Configure font substitutions](/slides/ru/net/font-substitution/) или [add the required fonts](/slides/ru/net/custom-font/) в среду выполнения.

**Что происходит с встроенными мультимедийными файлами (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа‑файлы указаны внешними путями, убедитесь, что эти пути доступны в вашей среде; в противном случае при [rendering/export](/slides/ru/net/convert-presentation/) медиа могут быть пропущены.