---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/net/convert-powerpoint-to-html/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 HTML
- 演示文稿 转 HTML
- 幻灯片 转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- 将 PowerPoint 保存为 HTML
- 将演示文稿保存为 HTML
- 将幻灯片保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- 将 PPT 导出为 HTML
- 将 PPTX 导出为 HTML
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for .NET 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需一次 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 加载并使用 [Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 调用配合 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/)。当需要控制导出的布局、字体、图像、备注、评论、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/)。

本指南侧重于实用的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和评论。
- 控制图像质量和裁剪图像数据。
- 嵌入字体或单独保存字体文件。
- 选择如何写入和引用外部资源和媒体文件。

默认情况下，HTML 导出会生成一个自包含的 HTML 文档，大多数资源都已嵌入。这对于共享单个文件很方便，但可能会增加输出大小。对于 Web 发布，请考虑使用外部资源、降低图像 DPI，并仅嵌入在目标环境中不可靠的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，请使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 加载它，并使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 保存。

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

此示例会写入一个 HTML 文件。演示文稿对象在 `using` 声明中被释放，导出后会释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/) 是 HTML 导出的主要配置类。常见设置包括：

- `SlidesLayoutOptions`：添加备注、评论、讲义或其他布局信息。
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `SlideImageFormat`：更改幻灯片的表示方式，例如 SVG。
- `PicturesCompression`：控制图像 DPI 和输出大小。
- `DeletePicturesCroppedAreas`：保留或移除裁剪的图像数据。
- `SvgResponsiveLayout`：使导出的 SVG 内容适应其容器。
- `ShowHiddenSlides`：在需要时包含隐藏的幻灯片。

以下章节分别展示最常用的选项，您可以仅组合工作流所需的部分。

## **将选定的幻灯片转换为 HTML**

接受幻灯片编号的 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

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

当网站或应用需要每张幻灯片对应一个 HTML 页面时使用此模式。如果每张幻灯片应使用相同的布局，请创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/) 实例并将其传递给每个 `Save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmlformatter/) 提供响应式 HTML 输出。当导出页面需要更好地适应浏览器宽度时使用它。

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

对于基于 SVG 的响应式布局，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/) 上设置 `SvgResponsiveLayout`。当幻灯片内容以可伸缩的 SVG 标记导出时，这非常有用。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **包含演讲者备注和评论**

通过 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notescommentslayoutingoptions/) 可以包含演讲者备注或评论。除非指定其位置，否则备注和评论默认是隐藏的。

假设源演示文稿包含演讲者备注：

![PowerPoint 中带有演讲者备注的幻灯片](slide_with_notes.png)

下面的代码会在幻灯片下方导出演讲者备注。

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

导出的 HTML 包含备注区域：

![带有幻灯片和演讲者备注的 HTML 输出](HTML_with_notes.png)

要导出评论，请设置 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。如果只需要评论，请省略 `NotesPosition`。如果需要同时包含备注和评论，请同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减小输出大小。当需要更高图像质量时，请将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/net/aspose.slides.export/picturescompression/) 中的某个值。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

默认情况下，图像的裁剪区域可能会从导出结果中移除。仅在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留它会增加 HTML 大小。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **添加 CSS**

对于简易样式，可将 CSS 字符串传递给 [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmlformatter/createdocumentformatter/)。这会修改外围 HTML 文档，而 Aspose.Slides 继续渲染幻灯片内容。

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

若需自定义文档头部、链接的 CSS 文件或在幻灯片和形状周围添加自定义标记，请实现 [IHtmlFormattingController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ihtmlformattingcontroller/) 并使用 `CreateCustomFormatter` 将其传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmlformatter/)。

## **嵌入字体**

如果目标环境可能没有安装演示文稿使用的字体，请使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/embedallfontshtmlcontroller/) 将字体嵌入 HTML。嵌入可提升视觉保真度，但会增加输出大小。

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

仅当您确信目标浏览器或系统已经提供这些字体时才排除它们。对于品牌字体或不常见的字体，嵌入通常更安全。

## **链接字体文件而不是嵌入**

为降低 HTML 文件大小，您可以将字体数据写入单独的 WOFF 文件，并在 HTML 中添加 `@font-face` 规则。下面的帮助类扩展了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/embedallfontshtmlcontroller/) 并重写了 `WriteFont`。

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

在此示例中，字体文件保存到 `html-output/fonts`，HTML 使用如 `fonts/BrandFont-normal-400.woff` 的 URL 引用它们。如果 HTML 文件和字体部署到其他位置，请使用 `fontUrlPrefix` 使其匹配发布后的 URL 路径。

## **外部保存资源**

自包含的 HTML 易于搬迁，但嵌入的 Base64 资源会使文件变大。如果您的应用需要外部图像文件，请实现 [ILinkEmbedController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/) 并将其传递给 [HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/htmloptions/) 构造函数。

外部化资源时，请有意识地选择两条路径：

- 文件系统输出路径：您的应用写入生成的图像、字体、音频或视频的目录。
- URL 路径：浏览器从 HTML 文档加载这些文件时使用的路径。

完整的图像链接实现请参见 [Export Presentations to HTML with Externally Linked Images](/slides/zh/net/exporting-presentations-to-html-with-externally-linked-images/)。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受：

- `path`：生成的媒体文件写入的目录。
- `fileName`：正在生成的 HTML 文件名。
- `baseUri`：HTML 中指向媒体文件的链接所使用的绝对 URI 前缀。

如果 HTML 文件位于 `html-output/presentation.html`，而媒体文件保存在 `html-output/media`，则 `path` 应指向磁盘上的媒体目录，`baseUri` 则应指向浏览器视角下的同一目录。对于本地预览，可使用 `file:///` URI 从媒体目录构造；对于部署的应用，请使用已发布媒体目录的绝对 URL。

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

在服务器应用中，请为每个导出任务使用唯一的输出目录。共享的输出路径可能导致不同转换的文件相互覆盖。

## **性能和资源管理**

HTML 转换是一次渲染操作，处理时间和内存使用取决于幻灯片数量、图像分辨率、字体、特效、图表和嵌入的媒体。较高的 `PicturesCompression` DPI 值、嵌入字体、SVG 输出以及保留裁剪图像区域可以提升保真度，但通常会增大输出大小。

批量转换时：

- 及时释放每个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例。
- 为不同任务使用独立的输出目录。
- 除非保真度要求，否则不要嵌入常用字体。
- 当 HTML 用于预览或缩略图时，降低图像 DPI。
- 在部署路径确定之前，将源演示文稿、生成的 HTML 与外部资源一起保存。

## **常见问题**

**超链接会在 HTML 输出中保留下来吗？**

会。演示文稿中的超链接会导出为 HTML，并在目标 URL 有效时保持可点击。

**可以并行将演示文稿转换为 HTML 吗？**

可以，但请不要在多个线程间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例。不同文件应使用独立的演示文稿实例、独立的流和独立的输出目录。详情请参阅 [multithreading guidance](/slides/zh/net/multithreading/)。

**Presentation 对象是线程安全的吗？**

不是。单个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例应在同一线程上加载、修改、保存并释放。若要并行工作，请为每个线程或进程创建独立实例。

**生成的 HTML 文件为什么很大？**

默认导出会将资源直接嵌入 HTML。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增加大小。使用外部资源、排除常用字体、在对保真度要求不高时降低 `PicturesCompression`，可以减小文件体积。

**在媒体导出时应如何选择 baseUri？**

从浏览器的视角选择 `baseUri` 并以绝对 URI 形式传入。用于本地预览时，可通过 `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` 获得；用于部署时，请使用已发布媒体目录的绝对 URL。文件系统的 `path` 与浏览器的 `baseUri` 不必相同，但必须指向同一资源位置。

**可以包含隐藏的幻灯片吗？**

可以。当必须导出隐藏幻灯片时，将 [HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/) 的 `ShowHiddenSlides` 设置为 `true`。