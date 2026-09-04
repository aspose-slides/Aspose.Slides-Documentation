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
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument на C#, задавать пароли для открытия, контролировать загрузку ресурсов и уменьшать использование памяти с помощью Aspose.Slides for .NET."
---
## **Введение**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ru/net/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете изучать её структуру, редактировать слайды, управлять ресурсами и сохранять её в исходном или другом поддерживаемом формате.

Поведение загрузки можно настроить через класс [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/). Например, можно указать пароль для открытия, хранить большие бинарные объекты вне управляемой памяти, контролировать внешние ресурсы или опустить встроенные бинарные данные.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, передайте её путь к файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Освобождайте презентацию после использования, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

Следующий пример на C# показывает, как открыть презентацию и получить количество её слайдов:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Открытие презентаций, защищённых паролем**

Пароль открытия шифрует содержимое презентации. Чтобы загрузить всю презентацию, присвойте правильный пароль свойству [LoadOptions.Password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Загрузка завершится ошибкой, если пароль отсутствует или неверен.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Для обнаружения пароля, его проверки и рабочих процессов шифрования см. [Password-Protect Presentations](/slides/ru/net/password-protected-presentation/). Если зашифрованная презентация была преднамеренно сохранена с общедоступными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/net/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/blobmanagementoptions/) управляет тем, как Aspose.Slides обрабатывает большие бинарные объекты, такие как изображения, аудио и видео. Вы можете оставить исходный файл заблокированным, разрешить временные файлы и ограничить объём BLOB‑данных, хранящихся в памяти.

Следующий код на C# демонстрирует загрузку большой презентации (например, 2 ГБ):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}

При `PresentationLockingBehavior.KeepLocked` исходный файл остаётся заблокированным, пока объект `Presentation` не будет освобождён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока этот объект существует.

Aspose.Slides может копировать содержимое входного потока при загрузке. Для больших презентаций путь к файлу, как правило, более эффективен, чем поток. См. [Manage BLOBs](/slides/ru/net/manage-blob/) для дополнительных вариантов хранения и управления памятью.

{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/resourceloadingcallback/) принимает реализацию [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/iresourceloadingcallback/). Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо разрешать согласно правилам безопасности или хранения вашего приложения.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложению не нужны или он не хочет сохранять. Примеры:

- VBA‑проекты, доступные через [IPresentation.VbaProject](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/vbaproject/);
- встроенные OLE‑данные, доступные через [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- данные ActiveX‑управлений, доступные через [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ru/net/aspose.slides/icontrol/activexcontrolbinary/).

Установите [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) в `true`, чтобы удалить эти бинарные данные при загрузке. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Эта опция уменьшает риск нежелательных встроенных нагрузок, но не является полной системой обнаружения вредоносного кода или санитизации содержимого.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить причину.

**Что происходит, если отсутствуют требуемые шрифты?**

Презентацию всё ещё можно загрузить, но при рендеринге и экспорте могут использоваться заменяющие шрифты. Вы можете [настроить замену шрифтов](/slides/ru/net/font-substitution/) или [предоставить собственные шрифты](/slides/ru/net/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружается ли вместе с презентацией её встроенное медиа?**

Встроенное аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются согласно настроенному поведению загрузки ресурсов и могут быть недоступны, если их местоположения недоступны.