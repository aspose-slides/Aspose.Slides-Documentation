---
title: Конвертировать презентации PowerPoint в HTML в .NET
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/net/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентацию в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- экспортировать PPT в HTML
- экспортировать PPTX в HTML
- .NET
- C#
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в HTML в .NET. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for .NET может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Базовое преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и вызова [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) с использованием [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/) когда необходимо управлять экспортируемым макетом, шрифтами, изображениями, заметками, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта HTML:

- Экспорт всей презентации или выбранных слайдов.
- Генерация HTML с фиксированным макетом, адаптивным или основанным на SVG.
- Включение заметок докладчика и комментариев.
- Управление качеством изображений и данными обрезанных областей.
- Встраивание шрифтов или отдельное сохранение файлов шрифтов.
- Выбор способа записи и ссылки на внешние ресурсы и медиа‑файлы.

По умолчанию экспорт HTML создаёт автономный HTML‑документ, в котором большинство ресурсов встроено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе рассмотрите внешние ресурсы, уменьшите DPI изображений и встраивайте только те шрифты, которые недоступны в целевой среде.

## **Преобразование презентации в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и сохраните с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

В этом примере записывается один HTML‑файл. Объект презентации освобождается объявлением `using`, которое закрывает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Использование HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/) — основной класс конфигурации экспорта HTML. Общие параметры включают:

- `SlidesLayoutOptions`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: меняет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: меняет способ представления слайдов, например как SVG.
- `PicturesCompression`: управляет DPI изображений и размером вывода.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные обрезанных изображений.
- `SvgResponsiveLayout`: заставляет экспортированный SVG‑контент адаптироваться к контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды, если требуется.

В следующих разделах показаны самые распространённые варианты параметров отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Преобразование выбранных слайдов в HTML**

Перегрузка [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/), принимающая номера слайдов, использует позицию слайдов, начинающуюся с 1. Ниже приводится цикл, сохраняющий каждый слайд в отдельный HTML‑файл.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если у всех слайдов одинаковый макет, создайте один объект [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/) и передайте его в каждый вызов `Save`.

## **Создание адаптивного HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/responsivehtmlcontroller/) предоставляет адаптивный HTML‑вывод через [HtmlFormatter](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmlformatter/). Используйте его, когда экспортированная страница должна лучше подстраиваться под ширину браузера.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Для адаптивного макета на основе SVG установите `SvgResponsiveLayout` в [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая разметка SVG.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Включение заметок докладчика и комментариев**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notescommentslayoutingoptions/) через `HtmlOptions.SlidesLayoutOptions`, чтобы включить заметки докладчика или комментарии. По умолчанию заметки и комментарии скрыты, если только вы не зададите их положения.

Предположим, исходная презентация содержит заметки докладчика:

![Слайд с заметками докладчика в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками докладчика под слайдом.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Экспортированный HTML включает область заметок:

![HTML‑вывод со слайдом и заметками докладчика](HTML_with_notes.png)

Чтобы экспортировать комментарии, установите `CommentsPosition`, например в `CommentsPositions.Right` или `CommentsPositions.Bottom`. Если нужны только комментарии, опустите `NotesPosition`. Если нужны и заметки, и комментарии, задайте оба свойства.

## **Управление качеством изображений и обрезанными областями**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Установите `PicturesCompression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/net/aspose.slides.export/picturescompression/), когда требуется более высокое качество изображений.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

По умолчанию обрезанные области изображений могут быть удалены из экспортированного вывода. Сохраняйте обрезанные данные только тогда, когда пользователи должны иметь возможность восстановить или изучить скрытые части изображения. Сохранение увеличивает размер HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Добавление CSS**

Для простого оформления передайте строку CSS в [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Это изменит окружающий HTML‑документ, пока Aspose.Slides продолжает рендерить содержимое слайда.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Для пользовательского заголовка документа, связанного CSS‑файла или пользовательской разметки вокруг слайдов и фигур реализуйте [IHtmlFormattingController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ihtmlformattingcontroller/) и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmlformatter/) с помощью `CreateCustomFormatter`.

## **Встраивание шрифтов**

Если в целевой среде шрифты презентации могут быть не установлены, встраивайте шрифты в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/embedallfontshtmlcontroller/). Встраивание улучшает визуальное соответствие, но увеличивает размер вывода.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Исключайте шрифты только тогда, когда уверены, что целевые браузеры или системы уже предоставляют их. Для фирменных или редких шрифтов встраивание обычно безопаснее.

## **Связывание файлов шрифтов вместо их встраивания**

Чтобы уменьшить размер HTML‑файла, можно записать данные шрифтов в отдельные файлы WOFF и добавить правила `@font-face` в HTML. Помощник ниже расширяет [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/embedallfontshtmlcontroller/) и переопределяет `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```
```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

В этом примере файлы шрифтов сохраняются в `html-output/fonts`, а HTML ссылается на них через URL‑ы, например `fonts/BrandFont-normal-400.woff`. Если HTML‑файл и шрифты развёртываются в другом месте, выберите `fontUrlPrefix`, соответствующий пути URL‑а развертывания.

## **Сохранение ресурсов во внешних файлах**

Автономный HTML удобно перемещать, но встроенные ресурсы Base64 делают файл большим. Если приложению нужны внешние файлы изображений, реализуйте [ILinkEmbedController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/ilinkembedcontroller/) и передайте его в конструктор [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/htmloptions/).

При внешнем размещении ресурсов выбирайте два пути сознательно:

- Путь вывода в файловой системе, куда приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

Для полной реализации связывания изображений смотрите [Export Presentations to HTML with Externally Linked Images](/slides/ru/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Экспорт медиа‑файлов**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/videoplayerhtmlcontroller/) экспортирует видео и аудио файлы и генерирует HTML, способный воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, в который будут записаны сгенерированные медиа‑файлы.
- `fileName`: имя генерируемого HTML‑файла.
- `baseUri`: абсолютный префикс URI, используемый в HTML‑ссылках на медиа‑файлы.

Если HTML‑файл находится по пути `html-output/presentation.html`, а медиа‑файлы сохраняются в `html-output/media`, `path` должен указывать на каталог медиа‑файлов на диске, а `baseUri` — на тот же каталог с точки зрения браузера. Для локального предварительного просмотра можно построить URI `file:///` из каталога медиа. Для развернутого приложения используйте абсолютный URL опубликованного каталога медиа.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Используйте каталоги вывода, уникальные для каждой задачи экспорта, особенно в серверных приложениях. Общие пути вывода могут привести к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конверсия HTML — это операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI в `PicturesCompression`, встроенные шрифты, вывод SVG и сохранённые обрезанные области изображений могут повысить точность, но обычно увеличивают размер вывода.

Для пакетного преобразования:

- Своевременно освобождайте каждый объект [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для разных задач.
- Избегайте встраивания общих шрифтов, если только не требуется высокий уровень точности.
- Уменьшайте DPI изображений, когда HTML нужен для предварительного просмотра или миниатюр.
- Храните исходную презентацию, сгенерированный HTML и внешние ресурсы вместе, пока не будут окончательно определены пути развертывания.

## **Часто задаваемые вопросы**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, если целевой URL действителен.

**Могу ли я конвертировать презентации в HTML параллельно?**

Да, но не делите один объект [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) между потоками. Обрабатывайте разные файлы отдельными экземплярами презентаций, отдельными потоками и отдельными каталогами вывода. См. руководство по [multithreading guidance](/slides/ru/net/multithreading/) для деталей.

**Объект Presentation потокобезопасен?**

Нет. Один экземпляр [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) должен быть загружен, изменён, сохранён и освобождён в одном потоке. Для параллельной работы создавайте отдельный экземпляр на каждый поток или процесс.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может встраивать ресурсы прямо в HTML. Встроенные шрифты, изображения высокого DPI, медиа, SVG‑контент и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте общие шрифты из встраивания и уменьшайте `PicturesCompression`, когда важнее небольшой размер вывода, чем максимальная точность.

**Как выбрать baseUri для экспорта медиа?**

Выберите `baseUri` с точки зрения браузера и передайте его как абсолютный URI. Для локального предварительного просмотра можно получить его из каталога вывода с помощью `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Для развертывания используйте абсолютный URL опубликованного каталога медиа. Путь в файловой системе (`path`) и браузерный `baseUri` не обязаны быть одинаковыми строками, но должны указывать на одно и то же местоположение ресурса.

**Могу ли я включать скрытые слайды?**

Да. Установите `ShowHiddenSlides = true` в [HtmlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/) когда необходимо экспортировать скрытые слайды.