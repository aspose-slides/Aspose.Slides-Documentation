---
title: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /ru/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- экспорт слайда
- экспорт PPT
- экспорт PPTX
- экспорт ODP
- PowerPoint в HTML
- OpenDocument в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- связанное изображение
- внешнее связанное изображение
- связанный ресурс
- внешний ресурс
- .NET
- C#
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML на платформе .NET с использованием Aspose.Slides, при котором изображения и другие ресурсы сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно как данные Base64. Это удобно, когда нужен один переносимый файл, но не всегда лучший формат для веб‑сайта, CMS или конвейера серверного преобразования.

Используйте внешние связанные ресурсы, когда необходимо:

- уменьшить размер HTML‑документа;
- кэшировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- исследовать, заменять, сжимать или пост‑обрабатывать сгенерированные ресурсы после экспорта;
- сохранить структуру вывода более близкой к тому, что ожидает веб‑приложение.

Для общего рабочего процесса конвертации HTML см. [Преобразование презентаций PowerPoint в HTML](/slides/ru/net/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсами.

## **Как работает экспорт связанных ресурсов**

[ILinkEmbedController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, встраивать данные в HTML или сохранять их внешне и записывать ссылку.

У интерфейса есть три метода:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) решает, должен ли ресурс быть связанным или встроенным.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/geturl/) возвращает URL, который будет записан в сгенерированный HTML или к другому связанному ресурсу.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — отдельные понятия. Например, пример ниже записывает файлы ресурсов в `html-output/assets` на диске, тогда как HTML содержит относительные URL, такие как `assets/resource-1.svg`. Браузер разрешает эти URL относительно файла, содержащего ссылку. Поэтому ссылка из `presentation.html` к SVG‑файлу использует `assets/resource-1.svg`, а ссылка из этого SVG‑файла к изображению, сохранённому в той же папке `assets`, использует `resource-4.jpg`.

## **Экспорт HTML со связанными ресурсами**

Следующий пример на C# создаёт выходной каталог, сохраняет туда HTML‑файл и хранит связанные ресурсы в подпапке `assets`. Контроллер связывает общие ресурсы изображений, шрифтов, аудио, видео и CSS, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Не распознанные ресурсы остаются встроенными.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

После экспорта в выходном каталоге будет следующая структура:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Точные файлы зависят от содержимого презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, чем использовался в исходной презентации, если это дает меньший или более подходящий файл. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL для развертывания**

В примере используется относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загружает `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой, пример использует параметр `referrer` в [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/geturl/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте иной префикс URL, когда файлы развернуты в другом месте:

- Используйте `assets/`, когда каталог ресурсов находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог ресурсов находится на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружены в CDN или на статический файловый сервер.

URL, возвращаемый [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/geturl/), должен соответствовать окончательному развернутому местоположению файла, записанного [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). В серверных приложениях используйте уникальный выходной каталог или префикс объектного хранилища для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда вместо этого встраивать**

Встроенный Base64‑HTML всё ещё полезен, когда вывод должен быть одним файлом, например вложением письма, офлайн‑просмотром или документом, который будет перемещён без сопутствующей папки ресурсов. Связанные ресурсы более подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кэшироваться браузерами независимо от HTML.

## **FAQ**

**Можно ли внешне разместить только изображения и оставить остальные ресурсы встроенными?**

Да. В [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) возвращайте `LinkEmbedDecision.Link` только для тех типов контента, которые вы хотите сохранять в отдельные файлы, и `LinkEmbedDecision.Embed` для остальных.

**Почему расширение экспортированного изображения отличается от исходной презентации?**

Aspose.Slides может перекодировать растровые изображения при экспорте в HTML, чтобы уменьшить размер или повысить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от результата рендеринга.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранённой одинаковой относительной структуре папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не создадите иной префикс URL.

**Должны ли серверные приложения повторно использовать один и тот же выходной каталог?**

Нет. Используйте уникальный выходной каталог или префикс хранилища для каждой задачи конвертации. Это предотвращает конфликты имён файлов и перезапись ресурсов, сгенерированных другим экспортом.