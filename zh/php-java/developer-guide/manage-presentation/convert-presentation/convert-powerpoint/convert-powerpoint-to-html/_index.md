---
title: 在 PHP 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "在 PHP 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for PHP via Java 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换是加载一个单独的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 并使用 [SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 调用 `save`。当需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/)。

本指南侧重于实用的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和批注。
- 控制图像质量和裁剪的图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入方式以及引用方式。

默认情况下，HTML 导出会生成一个自包含的 HTML 文档，绝大多数资源都嵌入其中。这对于共享单个文件很方便，但会增加输出大小。进行 Web 发布时，建议使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠可用的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，请使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 加载并使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 保存。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

此示例写入一个 HTML 文件。演示文稿对象在 `finally` 块中被释放，从而在导出后释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `SlidesLayoutOptions`：添加备注、批注、讲义或其他布局信息。
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `SlideImageFormat`：更改幻灯片的呈现方式，例如作为 SVG。
- `PicturesCompression`：控制图像 DPI 和输出大小。
- `DeletePicturesCroppedAreas`：保留或删除裁剪的图像数据。
- `SvgResponsiveLayout`：使导出的 SVG 内容适应其容器。
- `ShowHiddenSlides`：在需要时包含隐藏的幻灯片。

以下章节分别展示最常用的选项，便于仅组合工作流所需的部分。

## **将选定的幻灯片转换为 HTML**

接受幻灯片编号的 `save` 重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

当网站或应用需要每张幻灯片一个 HTML 页面时使用此模式。如果每张幻灯片应使用相同的布局，创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 实例并将其传递给每个 `save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/php-java/aspose.slides/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmlformatter/) 提供响应式 HTML 输出。当导出的页面需要更好地适应浏览器宽度时使用它。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

对于基于 SVG 的响应式布局，在 [HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 上设置 `SvgResponsiveLayout`。当幻灯片内容以可缩放的 SVG 标记导出时，这非常有用。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **包含演讲者备注和批注**

通过 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notescommentslayoutingoptions/) 可包含演讲者备注或批注。默认情况下备注和批注是隐藏的，除非指定它们的位置。

假设源演示文稿包含演讲者备注：

![PowerPoint 中带有演讲者备注的幻灯片](slide_with_notes.png)

以下代码将幻灯片内容导出，并在幻灯片下方附加演讲者备注。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

导出的 HTML 包含备注区域：

![带有幻灯片和演讲者备注的 HTML 输出](HTML_with_notes.png)

若要导出批注，设置 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。如果只需要批注，省略 `NotesPosition`。如果需要同时包含备注和批注，则同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以降低输出大小。当需要更高图像质量时，将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturescompression/) 中的相应值。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

默认情况下，图像的裁剪区域可能会从导出结果中移除。仅在用户必须能够恢复或检查这些隐藏图像部分时保留裁剪数据。保留它会增加 HTML 大小。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **添加 CSS**

对于简单的样式设置，可通过 `createDocumentFormatter` 将 CSS 字符串传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmlformatter/)。这会更改外围的 HTML 文档，而 Aspose.Slides 仍继续渲染幻灯片内容。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

若需要自定义文档头、链接的 CSS 文件或在幻灯片和形状周围添加自定义标记，请使用自定义格式化控制器并通过 `createCustomFormatter` 将其传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmlformatter/)。

## **嵌入字体**

如果目标环境可能没有安装演示文稿使用的字体，可使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/php-java/aspose.slides/embedallfontshtmlcontroller/) 将字体嵌入 HTML。嵌入可提升视觉保真度，但会增加输出大小。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

仅在确信目标浏览器或系统已提供这些字体时才排除嵌入。对于品牌字体或不常见字体，嵌入通常更安全。

## **链接字体文件而不是嵌入它们**

为降低 HTML 文件大小，可以将字体数据写入独立的 WOFF 文件，并在 HTML 中添加 `@font-face` 规则。在 PHP via Java 中，这种场景通常通过一个继承自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/php-java/aspose.slides/embedallfontshtmlcontroller/) 的小型 Java 辅助类实现，该类将字体字节写入输出目录，并将 `@font-face` 规则注入生成的 HTML。编译该辅助类、将其加入 PHP Java Bridge 类路径，然后在 PHP 中使用 `new Java(...)` 实例化。

构建此类辅助时，请有意识地选择两个路径：

- 文件系统输出路径，生成的字体文件写入此处。
- URL 路径，浏览器从 HTML 文档中加载这些字体文件时使用的路径。

## **外部保存资源**

自包含的 HTML 易于移动，但嵌入的 Base64 资源会使文件变大。如果应用需要外部图像文件，请向 [HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 构造函数提供自定义链接/嵌入控制器。

外部化资源时，同样需要有意识地选择两个路径：

- 文件系统输出路径，应用在此写入生成的图像、字体、音频或视频。
- URL 路径，浏览器从 HTML 文档中加载这些文件时使用的路径。

确保这些路径与部署布局保持一致，以便生成的 HTML 在迁移到 Web 服务器或其他目录后仍能加载外部资源。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受：

- `path`：生成的 HTML 和媒体文件使用的输出目录。
- `fileName`：正在生成的 HTML 文件名。
- `baseUri`：HTML 中指向媒体文件链接使用的绝对 URI 前缀。

如果 HTML 文件是 `html-output/presentation.html`，则 `path` 应指向 `html-output`，`baseUri` 应指向浏览器视角下的同一目录。针对本地预览，可从输出目录构建 `file:///` URI；针对已部署的应用，则使用已发布输出目录的绝对 URL。

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

在服务器应用中，请为每个导出作业使用唯一的输出目录。共享输出路径可能导致不同转换的文件相互覆盖。

## **性能和资源管理**

HTML 转换是一种渲染操作，处理时间和内存使用取决于幻灯片数量、图像分辨率、字体、效果、图表和嵌入的媒体。更高的 `PicturesCompression` DPI 值、嵌入的字体、SVG 输出以及保留的裁剪图像区域可以提升保真度，但通常会增加输出大小。

批量转换时：

- 及时释放每个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例。
- 为不同的任务使用独立的输出目录。
- 除非对保真度有要求，否则避免嵌入常用字体。
- 当 HTML 用于预览或缩略图时降低图像 DPI。
- 在部署路径确定之前，保持源演示文稿、生成的 HTML 和外部资源在同一位置。

## **常见问题**

**HTML 输出中超链接是否被保留？**

是的。演示文稿中的超链接会导出到 HTML，并在目标 URL 有效时保持可点击。

**我可以并行将演示文稿转换为 HTML 吗？**

可以，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例。请使用独立的演示文稿实例、独立的流和独立的输出目录来处理不同的文件。

**Presentation 对象是线程安全的吗？**

不是。单个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例应在同一线程上完成加载、修改、保存和释放。进行并行工作时，请为每个线程或进程创建独立的实例。

**生成的 HTML 文件为什么很大？**

默认导出会直接在 HTML 中嵌入资源。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增加大小。使用外部资源、排除常用字体的嵌入，并在对输出大小比最高保真度更重要时降低 `PicturesCompression`。

**我应该如何选择媒体导出的 baseUri？**

请从浏览器的视角选择 `baseUri` 并将其作为绝对 URI 传入。对于本地预览，可根据输出目录生成 Java 文件 URI。部署时，请使用已发布媒体目录的绝对 URL。文件系统 `path` 与浏览器 `baseUri` 不必是相同的字符串，但必须描述相同的资源位置。

**我可以包含隐藏的幻灯片吗？**

可以。当必须导出隐藏幻灯片时，在 [HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 上将 `ShowHiddenSlides` 设置为 `true`。