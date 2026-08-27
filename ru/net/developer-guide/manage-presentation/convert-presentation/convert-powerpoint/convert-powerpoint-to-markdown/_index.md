---
title: Конвертировать презентации PowerPoint в Markdown в .NET
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/net/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентацию в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- экспортировать PPTX в MD
- экспорт изображений в Markdown
- ссылки на изображения CDN
- PowerPoint
- презентация
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown в .NET и управлять тем, где сохраняются и как ссылаются экспортированные растровые, метафайловые и SVG‑изображения."
---
## **Обзор**

Aspose.Slides for .NET может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и процессов контроля версий. Вы можете выбрать вариант Markdown, управлять тем, как отображается содержание слайдов, и решить, где хранить экспортированные изображения и как генерируемый Markdown будет на них ссылаться.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержание, установите свойство [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/exporttype/) в значение `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownexporttype/). `Sequential` рендерит элементы слайдов отдельно и в порядке, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные отношения. Значение `TextOnly` не генерирует ресурсы изображений, поэтому события сохранения изображений не вызываются в этом режиме.

## **Конвертировать презентацию в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/), а затем вызовите метод [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) с параметром `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Выберите вариант Markdown**

Свойство [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/flavor/) определяет спецификацию Markdown, используемую для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/net/aspose.slides.export/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Следующий пример экспортирует презентацию в формате CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Экспорт изображений с использованием поведения сохранения по умолчанию**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/) предоставляет два свойства для локально сохраняемых изображений:

- [BasePath](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/basepath/) указывает базовый каталог для документа Markdown и его ресурсов.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) задает подпапку для изображений. Значение по умолчанию — `Images`.

Следующий пример рендерит визуальное содержание, сохраняет изображения в `output/assets` и создает относительные ссылки на изображения в документе Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Это поведение также используется в качестве резервного варианта, когда пользовательский обработчик сохранения изображений возвращает `false`.

## **Настроить сохранение изображений и ссылки Markdown**

Используйте событие [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/imagesaving/) для ресурсов растровых и метафайлов, не являющихся SVG, генерируемых во время экспорта в Markdown. Делегат [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) принимает объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/), его [ImageFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/) и сгенерированную ссылку Markdown как параметр `ref string`. Сохраните или загрузите изображение в указанном формате и замените `link` ссылкой, которая должна появиться в выводе Markdown.

Ресурсы, генерируемые в формате SVG, обрабатываются отдельно. Подпишитесь на событие [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), делегат [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) которого получает объект [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/) и параметр `ref string link`. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML‑данные из свойства [ISvgImage.SvgData](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/svgdata/). В зависимости от режима экспорта и визуального группирования SVG в исходной презентации может быть растеризован или объединён с другим содержимым; полученный не‑SVG ресурс затем передаётся в `ImageSaving`. Подписывайтесь на оба события, когда каждый экспортируемый визуальный ресурс требует пользовательской обработки.

Значение, возвращаемое обработчиком, определяет, кто будет обрабатывать изображение:

- Верните `true` после того, как обработчик сохранил, загрузил, преобразовал или иначе обработал изображение и присвоил `link` допустимое значение. Aspose.Slides запишет это значение в документ Markdown и не выполнит сохранение по умолчанию.
- Верните `false`, чтобы позволить Aspose.Slides сохранить изображение локально и сгенерировать ссылку в соответствии с [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/basepath/) и [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Обработчик, возвращающий `true`, принимает на себя ответственность за изображение. Если он возвращает `true`, не присвоив действительную, непустую ссылку, экспорт завершается с ошибкой `InvalidOperationException`.
{{% /alert %}}

### **Сохранить изображения в каталог CDN‑источника и использовать внешние URL**

Следующий пример рассматривает `cdn-origin/presentations/quarterly-report` как смонтированный или синхронизированный каталог CDN‑источника. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в этот пользовательский каталог и заменяет сгенерированную локальную ссылку публичным URL CDN. Сам пример не выполняет сетевую загрузку: URL становится действительным только после того, как каталог будет смонтирован как источник CDN или его файлы опубликованы в CDN. Для объектного хранилища замените запись в файловую систему на операцию загрузки через SDK хранилища и присвойте `link` только после успешной загрузки.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Обработчик растровых изображений преднамеренно возвращает `false` для изображений размером менее 128 × 128 пикселей, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images`, используя поведение по умолчанию. Более крупные растровые и метафайлы, а также SVG‑ресурсы обрабатываются пользовательским кодом. Например, сгенерированная локальная ссылка `fallback-images/image1.png` становится `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют пути ОС только при записи файлов; ссылки, записываемые в Markdown, используют прямые слэши и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель каталогов, зависящий от платформы.

## **Часто задаваемые вопросы**

**Может ли один обработчик обрабатывать как растровые изображения, так и SVG‑изображения?**

Нет. Используйте [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/imagesaving/) для генерируемых растровых и метафайл‑ресурсов и [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) для ресурсов, генерируемых как SVG. Первый предоставляет объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) и [ImageFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/); второй предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/), SVG‑данные которого можно прочитать из [ISvgImage.SvgData](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/svgdata/). SVG‑источник, растеризованный во время экспорта, обрабатывается `ImageSaving`.

**Что происходит, когда обработчик сохранения изображения возвращает `false`?**

Aspose.Slides использует поведение сохранения по умолчанию. Расположение изображения и сгенерированная ссылка контролируются [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/basepath/) и [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ru/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Может ли обработчик предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его другому сервису, присвоить полученный URL переменной `link` и вернуть `true`. Обработчик должен полностью завершить обработку; возврат `true` предотвращает сохранение по умолчанию.

**Почему экспорт в Markdown бросает `InvalidOperationException` из обработчика?**

Это исключение возникает, когда обработчик возвращает `true`, но не предоставляет действительную ссылку. Присвойте относительный путь или внешний URL, который должен быть записан в Markdown, прежде чем вернуть `true`.

**Какой разделитель пути следует использовать в ссылках на изображения?**

В ссылках Markdown и URL используйте прямой слэш `/`. `Path.Combine` используйте только для путей файловой системы, а формирование или нормализацию ссылки в Markdown делайте отдельно.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/net/slide-transition/) и [animations](/slides/ru/net/powerpoint-animation/) не конвертируются.

**Можно ли конвертировать несколько презентаций в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций параллельно, но не делитесь одним экземпляром [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) между потоками. Следуйте [руководству по многопоточности](/slides/ru/net/multithreading/) и используйте отдельный экземпляр для каждого файла.