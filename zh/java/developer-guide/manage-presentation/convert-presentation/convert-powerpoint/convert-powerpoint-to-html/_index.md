---
title: 在 Java 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "在 Java 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for Java 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需加载一个[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)并使用[SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)调用`save`。当需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/)。

本指南侧重于实际的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。  
- 生成固定布局、响应式或基于 SVG 的 HTML。  
- 包含演讲者备注和批注。  
- 控制图像质量和裁剪图像数据。  
- 嵌入字体或单独保存字体文件。  
- 选择外部资源和媒体文件的写入方式及引用方式。

默认情况下，HTML 导出生成一个自包含的 HTML 文档，其中大多数资源都已嵌入。这对于共享单个文件很方便，但会增加输出大小。对于网页发布，建议使用外部资源、降低图像 DPI，并仅嵌入在目标环境中不可靠的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，请使用[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)加载并使用[SaveFormat.Html](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)保存。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

此示例写入一个 HTML 文件。演示文稿对象在`finally`块中释放，确保在导出后释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `SlidesLayoutOptions`：添加备注、批注、讲义或其他布局信息。  
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。  
- `SlideImageFormat`：更改幻灯片的表示方式，例如使用 SVG。  
- `PicturesCompression`：控制图像 DPI 和输出大小。  
- `DeletePicturesCroppedAreas`：保留或删除裁剪的图像数据。  
- `SvgResponsiveLayout`：使导出的 SVG 内容自适应其容器。  
- `ShowHiddenSlides`：在需要时包含隐藏幻灯片。

下面的章节分别展示最常用的选项，便于根据工作流只组合需要的部分。

## **将选定幻灯片转换为 HTML**

接受幻灯片编号的`Presentation.save`重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

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

当网站或应用需要每张幻灯片对应一个 HTML 页面时使用此模式。如果每张幻灯片应使用相同布局，创建一个[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/)实例并将其传递给每个`save`调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmlformatter/) 提供响应式 HTML 输出。当导出的页面需要更好地适应浏览器宽度时使用它。

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

对于基于 SVG 的响应式布局，在[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/)上设置`SvgResponsiveLayout`。当幻灯片内容以可缩放的 SVG 标记导出时，这非常有用。

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

## **包含演讲者备注和批注**

通过 `HtmlOptions.setSlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notescommentslayoutingoptions/) 来包含演讲者备注或批注。默认情况下，备注和批注是隐藏的，除非指定其位置。

假设源演示文稿包含演讲者备注：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

下面的代码将在幻灯片下方导出演讲者备注。

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

导出的 HTML 包含备注区域：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

要导出批注，请设置`CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。如果只需要批注，请省略 `NotesPosition`。如果需要同时包含备注和批注，请同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减小输出大小。当需要更高图像质量时，将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/java/com.aspose.slides/picturescompression/) 中的相应值。

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

默认情况下，图像的裁剪区域可能会从导出结果中移除。仅在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留它会增加 HTML 大小。

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

对于简单的样式，向 `HtmlFormatter.createDocumentFormatter` 传递 CSS 字符串即可。这会更改围绕幻灯片内容的 HTML 文档，而 Aspose.Slides 仍负责渲染幻灯片本身。

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

如需自定义文档头、链接的 CSS 文件或在幻灯片和形状周围加入自定义标记，请实现 [IHtmlFormattingController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ihtmlformattingcontroller/) 并通过 `createCustomFormatter` 将其传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmlformatter/)。

## **嵌入字体**

如果目标环境可能没有安装演示文稿使用的字体，请使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/embedallfontshtmlcontroller/) 在 HTML 中嵌入字体。嵌入可以提升视觉保真度，但会增加输出大小。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

仅在确信目标浏览器或系统已经提供这些字体时才排除它们。对于品牌字体或不常见字体，嵌入通常更安全。

## **链接字体文件而非嵌入**

为了减小 HTML 文件大小，可将字体数据写入独立的 WOFF 文件，并在 HTML 中添加 `@font-face` 规则。下面的帮助类继承自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/embedallfontshtmlcontroller/) 并覆盖 `writeFont`。

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
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
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

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

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

在此示例中，字体文件保存到 `html-output/fonts`，HTML 使用类似 `fonts/BrandFont-normal-400.woff` 的 URL 引用它们。如果 HTML 文件和字体部署到其他位置，请设置 `fontUrlPrefix` 以匹配部署后的 URL 路径。

## **外部保存资源**

自包含的 HTML 易于移动，但嵌入的 Base64 资源会导致文件变大。如果应用需要外部图像文件，请实现 [ILinkEmbedController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 并将其实例传递给 [HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/) 的构造函数。

在外部化资源时，需要明确两条路径：

- 文件系统输出路径：应用写入生成的图像、字体、音频或视频的目录。  
- URL 路径：浏览器从 HTML 文档加载这些文件时使用的路径。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受：

- `path`：生成的媒体文件将写入的目录。  
- `fileName`：正在生成的 HTML 文件名。  
- `baseUri`：HTML 中指向媒体文件的绝对 URI 前缀。

如果 HTML 文件为 `html-output/presentation.html`，媒体文件保存在 `html-output/media`，则 `path` 应指向磁盘上的媒体目录，而 `baseUri` 应指向浏览器视角下的同一目录。对于本地预览，可使用 `file:///` URI；对于已部署的应用，请使用已发布媒体目录的绝对 URL。

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

在服务器应用中，务必为每次导出作业使用唯一的输出目录。共享输出路径会导致不同转换的文件相互覆盖。

## **性能与资源管理**

HTML 转换属于渲染操作，处理时间和内存占用受幻灯片数量、图像分辨率、字体、特效、图表以及嵌入媒体的影响。更高的 `PicturesCompression` DPI 值、嵌入字体、SVG 输出以及保留裁剪图像区域可以提升保真度，但通常会增加输出大小。

批量转换时：

- 及时释放每个[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)实例。  
- 为不同作业使用独立的输出目录。  
- 除非保真度要求，否则不要嵌入常用字体。  
- 当 HTML 用于预览或缩略图时，降低图像 DPI。  
- 在部署路径确定之前，保持源演示文稿、生成的 HTML 和外部资源在同一位置。

## **常见问题**

**HTML 输出中是否保留超链接？**

是的。演示文稿中的超链接会导出到 HTML，并在目标 URL 有效时保持可点击。

**可以并行转换演示文稿为 HTML 吗？**

可以，但不要在多个线程之间共享同一个[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)实例。使用独立的演示文稿实例、独立的流和独立的输出目录处理不同文件。详见[多线程指南](/slides/zh/java/multithreading/)。

**Presentation 对象是否线程安全？**

不安全。单个[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)实例应在同一线程中完成加载、修改、保存和释放。若需并行处理，请为每个线程或进程创建独立实例。

**生成的 HTML 文件为什么很大？**

默认导出会将资源直接嵌入 HTML。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增加文件大小。使用外部资源、排除常用字体并在不需要最高保真度时降低 `PicturesCompression` 可以减小体积。

**如何为媒体导出选择 baseUri？**

请从浏览器的视角选择 `baseUri` 并以绝对 URI 形式传入。本地预览时，可使用 `mediaDirectory.toUri().toString()` 生成；部署时则使用已发布媒体目录的绝对 URL。文件系统 `path` 与浏览器 `baseUri` 不必是相同字符串，但必须指向同一资源位置。

**可以包含隐藏幻灯片吗？**

可以。当需要导出隐藏幻灯片时，在[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/)上将 `ShowHiddenSlides` 设置为 `true`。