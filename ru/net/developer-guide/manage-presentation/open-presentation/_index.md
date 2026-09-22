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
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument на C#, задавать пароли открытия, управлять загрузкой ресурсов и уменьшать использование памяти с помощью Aspose.Slides for .NET."
---
## **Введение**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ru/net/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете исследовать её структуру, редактировать слайды, управлять ресурсами и сохранять её в исходном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/). Например, можно задать пароль открытия, хранить крупные двоичные объекты за пределами управляемой памяти, управлять внешними ресурсами или исключать встроенные двоичные данные.

## **Открытие презентаций**

После загрузки файла или потока вы можете [определить оригинальный формат презентации](/slides/ru/net/detect-presentation-source-format/), чтобы выбрать способ обработки в вашем приложении.

Чтобы открыть существующую презентацию, передайте путь к файлу конструктору [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Освобождайте объект презентации после использования, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

Следующий пример на C# демонстрирует, как открыть презентацию и получить количество её слайдов:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Открытие защищённых паролем презентаций**

Пароль открытия шифрует содержимое презентации. Чтобы загрузить полностью презентацию, задайте правильный пароль в [LoadOptions.Password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Загрузка будет неудачной, если пароль отсутствует или неверен.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Для обнаружения пароля, проверки и процессов шифрования см. [Защита презентаций паролем](/slides/ru/net/password-protected-presentation/). Если зашифрованная презентация была специально сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Управление свойствами презентации](/slides/ru/net/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/blobmanagementoptions/) управляет тем, как Aspose.Slides обрабатывает крупные двоичные объекты, такие как изображения, аудио и видео. Вы можете оставлять исходный файл заблокированным, разрешать временные файлы и ограничивать количество BLOB‑данных, сохраняемых в памяти.

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
С `PresentationLockingBehavior.KeepLocked` исходный файл остаётся заблокированным, пока объект `Presentation` не будет освобождён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока объект жив.

Aspose.Slides может копировать содержимое входного потока при загрузке. Для больших презентаций путь к файлу, как правило, более эффективен, чем поток. См. [Управление BLOB](/slides/ru/net/manage-blob/) для дополнительных вариантов хранения и управления памятью.
{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/resourceloadingcallback/) принимает реализацию [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/iresourceloadingcallback/). Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо разрешать в соответствии со специфическими для приложения правилами безопасности или хранения.

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

## **Загрузка презентаций без встроенных двоичных объектов**

Презентация может содержать встроенные двоичные данные, которые приложению не нужны или которые оно не хочет сохранять. Примеры включают:

- VBA‑проекты, доступные через [IPresentation.VbaProject](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/vbaproject/);
- встроенные OLE‑данные, доступные через [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- данные элементов управления ActiveX, доступные через [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ru/net/aspose.slides/icontrol/activexcontrolbinary/).

Установите [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) в `true`, чтобы удалить эти двоичные данные при загрузке. Сохраните загруженную презентацию, чтобы сохранить полученный очищенный результат.

Эта опция уменьшает риск нежелательных встроенных полезных нагрузок, однако она не является полноценной системой обнаружения вредоносного кода или очистки содержимого.

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

## **Часто задаваемые вопросы**

**Как можно определить, что файл повреждён и не может быть открыт?**

Aspose.Slides генерирует исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неправильного пароля, чтобы приложение могло точно сообщить о причине.

**Что происходит, если отсутствуют требуемые шрифты?**

Презентацию всё ещё можно загрузить, но при рендеринге и экспорте могут быть подставлены шрифты. Вы можете [настроить замену шрифтов](/slides/ru/net/font-substitution/) или [предоставить пользовательские шрифты](/slides/ru/net/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружает ли загрузка презентации также встроенные медиа?**

Встроенные аудио и видео становятся доступны через объектную модель презентации. Внешние ресурсы разрешаются в соответствии с настроенным поведением загрузки ресурсов и могут быть недоступны, если их расположения недоступны.