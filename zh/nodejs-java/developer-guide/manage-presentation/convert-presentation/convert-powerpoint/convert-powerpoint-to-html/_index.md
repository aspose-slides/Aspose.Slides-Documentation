---
title: 在 Node.js 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/nodejs-java/convert-powerpoint-to-html/
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
- 将 演示文稿 保存为 HTML
- 将 幻灯片 保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- 导出 PPT 为 HTML
- 导出 PPTX 为 HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides for Node.js via Java 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for Node.js via Java 可在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需加载一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 并使用 [SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 调用 `save`。当需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/)。

本指南侧重于实际的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和批注。
- 控制图像质量和裁剪图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入和引用方式。

默认情况下，HTML 导出生成一个自包含的 HTML 文档，大多数资源都已嵌入。这对于共享单个文件很方便，但会增加输出大小。对于 Web 发布，建议使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠可用的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 加载并使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 保存。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

此示例写入一个 HTML 文件。演示文稿对象在 `finally` 块中被释放，释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `SlidesLayoutOptions`：添加备注、批注、讲义或其他布局信息。
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `SlideImageFormat`：更改幻灯片的表示方式，例如作为 SVG。
- `PicturesCompression`：控制图像 DPI 和输出大小。
- `DeletePicturesCroppedAreas`：保留或移除裁剪的图像数据。
- `SvgResponsiveLayout`：使导出的 SVG 内容适应其容器。
- `ShowHiddenSlides`：在需要时包含隐藏的幻灯片。

下面的章节分别展示最常用的选项，以便仅组合工作流所需的部分。

## **将选定的幻灯片转换为 HTML**

接受幻灯片编号的 `Presentation.save` 重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

当网站或应用程序需要每张幻灯片对应一个 HTML 页面时，请使用此模式。如果每张幻灯片应使用相同布局，请创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 实例，并将其传递给每个 `save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmlformatter/) 提供响应式 HTML 输出。当导出页面需要更好地适应浏览器宽度时使用它。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

对于基于 SVG 的响应式布局，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 上设置 `SvgResponsiveLayout`。这在幻灯片内容以可伸缩 SVG 标记导出时非常有用。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **包含演讲者备注和批注**

通过 `HtmlOptions.setSlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 将演讲者备注或批注包含进来。默认情况下，备注和批注是隐藏的，除非你指定它们的位置。

假设源演示文稿包含演讲者备注：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

以下代码在幻灯片下方导出带有演讲者备注的幻灯片内容。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

导出的 HTML 包含备注区域：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

要导出批注，请设置 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。如果只需要批注，省略 `NotesPosition`。如果需要同时包含备注和批注，请同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减小输出大小。当需要更高图像质量时，请将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturescompression/) 中的相应值。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

默认情况下，裁剪的图像区域可能会从导出输出中移除。仅当用户必须能够恢复或检查这些隐藏的图像部分时才保留裁剪数据。保留它会增加 HTML 大小。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **添加 CSS**

对于简单样式，可将 CSS 字符串传递给 `HtmlFormatter.createDocumentFormatter`。这会更改外围 HTML 文档，而 Aspose.Slides 继续渲染幻灯片内容。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

若需自定义文档头、链接的 CSS 文件或在幻灯片和形状周围添加自定义标记，请使用带有格式化控制器的 [HtmlFormatter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmlformatter/)。

## **嵌入字体**

如果目标环境可能未安装演示文稿使用的字体，请使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) 在 HTML 中嵌入字体。嵌入可提高视觉保真度，但会增大输出大小。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

仅当你确信目标浏览器或系统已经提供这些字体时才排除嵌入。对于品牌字体或不常见的字体，嵌入通常更安全。

## **链接字体文件而非嵌入**

为减小 HTML 文件大小，可以将字体数据写入单独的 WOFF 文件，并在 HTML 中添加 `@font-face` 规则。在 Node.js via Java 中，这通常通过一个继承自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) 的小型 Java 辅助类实现，该类将字体字节写入输出目录并将 `@font-face` 规则注入生成的 HTML。编译该辅助类并将其添加到 Node.js 模块的类路径，然后在 JavaScript 中使用 `java.newInstanceSync` 实例化它。

构建此类辅助工具时，请有意识地选择两条路径：

- 文件系统输出路径：生成的字体文件写入的位置。
- URL 路径：浏览器从 HTML 文档加载这些字体文件时使用的路径。

## **外部保存资源**

自包含的 HTML 易于移动，但嵌入的 Base64 资源会使文件变大。如果你的应用需要外部图像、字体、音频或视频文件，请使用能够将资源写入指定目录并生成浏览器可见 URL 的导出控制器。保持文件系统路径与 URL 路径在部署布局中保持一致。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受：

- `path`：生成的媒体文件写入的目录。
- `fileName`：正在生成的 HTML 文件名。
- `baseUri`：HTML 中指向媒体文件的链接使用的绝对 URI 前缀。

如果 HTML 文件位于 `html-output/presentation.html`，媒体文件保存在 `html-output/media`，则 `path` 应指向磁盘上的媒体目录，而 `baseUri` 应指向浏览器视角下相同的目录。对于本地预览，可以使用 `file:///` URI；对于已部署的应用，则使用已发布媒体目录的绝对 URL。

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

在服务器应用中，请为每次导出作业使用唯一的输出目录。共享的输出路径可能导致不同转换的文件相互覆盖。

## **性能与资源管理**

HTML 转换是一次渲染操作，处理时间和内存使用取决于幻灯片数量、图像分辨率、字体、效果、图表以及嵌入的媒体。较高的 `PicturesCompression` DPI 值、嵌入字体、SVG 输出以及保留裁剪图像区域可以提升保真度，但通常会增加输出大小。

批量转换时：

- 及时释放每个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例。
- 为不同作业使用独立的输出目录。
- 除非保真度要求，否则不要嵌入常用字体。
- 当 HTML 用于预览或缩略图时降低图像 DPI。
- 在部署路径确定之前，保持源演示文稿、生成的 HTML 与外部资源放在一起。

## **常见问题**

**HTML 输出中会保留超链接吗？**

会。演示文稿中的超链接会导出到 HTML，并在目标 URL 有效时保持可点击。

**可以并行转换演示文稿为 HTML 吗？**

可以，但不要在多个工作线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例。请为不同文件使用独立的演示文稿实例、独立的流和独立的输出目录。详情请参阅 [multithreading guidance](/slides/zh/nodejs-java/multithreading/)。

**Presentation 对象是线程安全的吗？**

不是。单个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例应在同一工作线程中完成加载、修改、保存和释放。并行工作时，请为每个工作线程或进程创建独立的实例。

**生成的 HTML 文件为何很大？**

默认导出会将资源直接嵌入 HTML。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增加大小。可改用外部资源、排除常用字体的嵌入，并在对输出大小更敏感时降低 `PicturesCompression`。

**媒体导出时应如何选择 baseUri？**

从浏览器的视角选择 `baseUri` 并以绝对 URI 形式传入。本地预览时，可从输出目录生成 `file:///` URI；部署时，请使用已发布媒体目录的绝对 URL。文件系统的 `path` 与浏览器的 `baseUri` 不必是相同的字符串，但必须指向相同的资源位置。

**可以包含隐藏的幻灯片吗？**

可以。将 [HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 的 `ShowHiddenSlides` 设置为 `true`，即可导出隐藏的幻灯片。