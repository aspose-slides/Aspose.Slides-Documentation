---
title: 在 Android 上将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/androidjava/convert-powerpoint-to-html/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 HTML
- 演示文稿转 HTML
- 幻灯片转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- 将 PowerPoint 保存为 HTML
- 将演示文稿保存为 HTML
- 将幻灯片保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- 导出 PPT 为 HTML
- 导出 PPTX 为 HTML
- Android
- Java
- Aspose.Slides
description: "在 Android 上将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides for Android via Java 导出 PPT 和 PPTX 文件、选定的幻灯片、批注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for Android via Java 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需要一次 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 加载并使用 [SaveFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/) 调用 `save`。当需要控制导出布局、字体、图像、批注、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/)。

本指南侧重于实际的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者批注和评论。
- 控制图像质量和裁剪的图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入方式和引用方式。

默认情况下，HTML 导出会生成一个自包含的 HTML 文档，大多数资源都会被嵌入。这对于共享单个文件很方便，但会增大输出大小。对于 Web 发布，请考虑使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠可用的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 加载它，并使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/) 保存。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

此示例会写入一个 HTML 文件。演示文稿对象在 `finally` 块中被释放，从而在导出后释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `SlidesLayoutOptions`：添加批注、讲义或其他布局信息。
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `SlideImageFormat`：更改幻灯片的表示方式，例如使用 SVG。
- `PicturesCompression`：控制图像 DPI 和输出大小。
- `DeletePicturesCroppedAreas`：保留或移除裁剪的图像数据。
- `SvgResponsiveLayout`：使导出的 SVG 内容适应其容器。
- `ShowHiddenSlides`：在需要时包含隐藏的幻灯片。

以下章节分别展示最常用的选项，以便您仅组合工作流所需的部分。

## **将选定幻灯片转换为 HTML**

接受幻灯片编号的 `Presentation.save` 重载使用基于 1 的幻灯片位置。下面的循环会将每张幻灯片保存为单独的 HTML 文件。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

当网站或应用需要每张幻灯片对应一个 HTML 页面时，请使用此模式。如果每张幻灯片应使用相同布局，请创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/) 实例并将其传递给每个 `save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmlformatter/) 提供响应式 HTML 输出。当导出页面需要更好地适应浏览器宽度时使用它。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

对于基于 SVG 的响应式布局，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/) 上设置 `SvgResponsiveLayout`。当幻灯片内容以可伸缩的 SVG 标记导出时，这非常有用。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **包含演讲者批注和评论**

通过 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 来包含演讲者批注或评论。默认情况下批注和批注是隐藏的，除非您指定它们的位置。

假设源演示文稿包含演讲者批注：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

下面的代码会将幻灯片内容连同幻灯片下方的演讲者批注一起导出。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

导出的 HTML 包含批注区域：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

要导出评论，请设置 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。如果只需要评论，请省略 `NotesPosition`。如果需要同时包含批注和评论，请同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减小输出大小。当需要更高图像质量时，请将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/picturescompression/) 中的某个值。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

默认情况下，导出时可能会移除图像的裁剪区域。仅在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留它会增加 HTML 大小。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **添加 CSS**

对于简单的样式，只需将 CSS 字符串传递给 `HtmlFormatter.createDocumentFormatter`。这会更改外围的 HTML 文档，而 Aspose.Slides 仍负责渲染幻灯片内容。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

如果需要自定义文档头、链接的 CSS 文件或围绕幻灯片和形状的自定义标记，请实现 [IHtmlFormattingController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihtmlformattingcontroller/) 并使用 `createCustomFormatter` 将其传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmlformatter/)。

## **嵌入字体**

如果目标环境可能没有安装演示文稿使用的字体，请使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 将字体嵌入 HTML。嵌入可提升视觉保真度，但会增加输出大小。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

仅当您确信目标浏览器或系统已经提供这些字体时才排除它们。对于品牌字体或不常见的字体，嵌入通常更安全。

## **链接字体文件而非嵌入**

为了减小 HTML 文件大小，您可以将字体数据写入单独的 WOFF 文件，并在 HTML 中添加 `@font-face` 规则。下面的辅助类扩展了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 并覆盖了 `writeFont`。

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

在此示例中，字体文件保存到 `html-output/fonts`，HTML 使用类似 `fonts/BrandFont-normal-400.woff` 的 URL 引用它们。如果 HTML 文件和字体部署到其他位置，请选择合适的 `fontUrlPrefix` 以匹配部署后的 URL 路径。

## **外部保存资源**

自包含的 HTML 易于迁移，但嵌入的 Base64 资源会导致文件变大。如果您的应用需要外部图像文件，请实现 [ILinkEmbedController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 并将其传递给 [HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/) 构造函数。

外部化资源时，请有意识地选择两条路径：

- 文件系统输出路径，您的应用在此写入生成的图像、字体、音频或视频。
- URL 路径，浏览器从 HTML 文档加载这些文件时使用的路径。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放它们的 HTML。其构造函数接受：

- `path`：生成的媒体文件写入的目录。
- `fileName`：正在生成的 HTML 文件名。
- `baseUri`：HTML 中指向媒体文件的绝对 URI 前缀。

如果 HTML 文件为 `html-output/presentation.html`，媒体文件保存在 `html-output/media`，则 `path` 应指向磁盘上的媒体目录，而 `baseUri` 应指向浏览器视角下的同一目录。对于本地预览，您可以使用 `file:///` URI；对于部署的应用，则使用已发布媒体目录的绝对 URL。

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

请为每次导出作业使用唯一的输出目录，尤其在服务器应用中。共享输出路径可能导致不同转换的文件相互覆盖。

## **性能与资源管理**

HTML 转换是渲染操作，处理时间和内存占用取决于幻灯片数量、图像分辨率、字体、特效、图表以及嵌入的媒体。更高的 `PicturesCompression` DPI 值、嵌入字体、SVG 输出以及保留裁剪图像区域可以提升保真度，但通常会增加输出大小。

批量转换时：

- 及时释放每个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例。
- 为不同作业使用独立的输出目录。
- 除非保真度要求，否则避免嵌入常用字体。
- 当 HTML 用于预览或缩略图时，降低图像 DPI。
- 在部署路径确定之前，保持源演示文稿、生成的 HTML 和外部资源在同一位置。

## **常见问题解答**

**HTML 输出中超链接会被保留吗？**

会。演示文稿中的超链接会导出到 HTML，并在目标 URL 有效时保持可点击。

**我可以并行转换演示文稿为 HTML 吗？**

可以，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例。请使用独立的演示实例、独立的流以及独立的输出目录来处理不同的文件。详情请参阅 [multithreading guidance](/slides/zh/androidjava/multithreading/)。

**Presentation 对象是线程安全的吗？**

不是。单个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例应在同一线程上加载、修改、保存并释放。并行工作时，请为每个线程或进程创建独立的实例。

**生成的 HTML 文件为什么很大？**

默认导出会将资源直接嵌入 HTML。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增加大小。使用外部资源、排除常用字体的嵌入，并在对保真度要求不高时降低 `PicturesCompression`，可以减小输出。

**媒体导出应如何选择 baseUri？**

从浏览器的视角选择 `baseUri` 并将其作为绝对 URI 传入。对于本地预览，可以通过 `mediaDirectory.toUri().toString()` 获得；部署时则使用已发布媒体目录的绝对 URL。文件系统的 `path` 与浏览器的 `baseUri` 不必是相同的字符串，但必须指向相同的资源位置。

**我可以包含隐藏的幻灯片吗？**

可以。将 [HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/) 的 `ShowHiddenSlides` 设置为 `true`，即可在需要时导出隐藏幻灯片。