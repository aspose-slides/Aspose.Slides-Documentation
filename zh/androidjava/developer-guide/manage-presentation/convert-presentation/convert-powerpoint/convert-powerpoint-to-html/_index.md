---
title: 在 Android 上将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/androidjava/convert-powerpoint-to-html/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
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
description: "在 Java 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides for Android 转换指南，快速实现布局、链接和图像的完整保留，确保完美无瑕的结果。"
---

## **概述**

本文介绍如何使用 Java 将 PowerPoint 演示文稿转换为 HTML 格式。它涵盖以下主题。

- 在 Java 中将 PowerPoint 转换为 HTML
- 在 Java 中将 PPT 转换为 HTML
- 在 Java 中将 PPTX 转换为 HTML
- 在 Java 中将 ODP 转换为 HTML
- 在 Java 中将 PowerPoint 幻灯片转换为 HTML

## **在 Android 上将 PowerPoint 转换为 HTML**

有关将 PowerPoint 转换为 HTML 的 Java 示例代码，请参见以下章节，即[Convert PowerPoint to HTML](#convert-powerpoint-to-html)。该代码可以在 Presentation 对象中加载多种格式，如 PPT、PPTX 和 ODP，并将其保存为 HTML 格式。

## **关于 PowerPoint 转换为 HTML**

使用[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)，应用程序和开发人员可以将 PowerPoint 演示文稿转换为 HTML：**PPTX to HTML** 或 **PPT to HTML**。

**Aspose.Slides** 提供许多选项（主要来自[**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) 类），用于定义 PowerPoint 转换为 HTML 的过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。
* 将 PowerPoint 演示文稿转换为使用原始或嵌入字体的 HTML。
* 在使用新 CSS 样式时将 PowerPoint 演示文稿转换为 HTML。

{{% alert color="primary" %}} 

使用其自己的 API，Aspose 开发了免费[演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想查看 Aspose 的其他[免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除了本文所述的转换过程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作：

* [HTML 转图片](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}

## **将 PowerPoint 转换为 HTML**

使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 使用 [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法将对象保存为 HTML 文件。

以下代码演示如何在 Java 中将 PowerPoint 转换为 HTML：
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // 保存演示文稿为 HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 PowerPoint 转换为响应式 HTML**

Aspose.Slides 提供 [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) 类，可生成响应式 HTML 文件。以下代码演示如何在 Java 中将 PowerPoint 演示文稿转换为响应式 HTML：
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // 保存演示文稿为 HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 PowerPoint 转换为带备注的 HTML**

以下代码演示如何在 Java 中将 PowerPoint 转换为带备注的 HTML：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // 保存备注页
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 PowerPoint 转换为带原始字体的 HTML**

Aspose.Slides 提供 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) 类，可在将演示文稿转换为 HTML 时嵌入所有字体。

要防止嵌入某些字体，您可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) 类的带参数构造函数传递字体名称数组。常用字体，如 Calibri 或 Arial，在演示文稿中使用时无需嵌入，因为大多数系统已包含这些字体。如果嵌入这些字体，生成的 HTML 文档会不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) 类支持继承，并提供 [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) 方法，供重写。
```java
Presentation pres = new Presentation("input.pptx");
try {
    // 排除默认演示文稿字体
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 PowerPoint 转换为高质量图像的 HTML**

默认情况下，将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出的 HTML 较小，图像分辨率为 72 DPI 且裁剪区域被删除。若要获得图像质量更高的 HTML 文件，需将 `PicturesCompression` 属性（来自 `HtmlOptions` 类）设置为 96（即 `PicturesCompression.Dpi96`）或更高的[值](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression)。

下面的 Java 代码演示如何在获取 150 DPI 高质量图像（即 `PicturesCompression.Dpi150`）的同时，将 PowerPoint 演示文稿转换为 HTML：
```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setPicturesCompression(PicturesCompression.Dpi150);
    
    pres.save("OutputDoc-dpi150.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```


下面的 Java 代码演示如何输出具有完整质量图像的 HTML：
```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);

    pres.save("Outputdoc-noCrop.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将幻灯片转换为 HTML**

要将 PowerPoint 中的特定幻灯片转换为 HTML，需实例化相同的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类（用于将完整演示文稿转换为 HTML），然后使用 [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法将文件保存为 HTML。可使用 [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) 类指定其他转换选项：

下面的 Java 代码演示如何将 PowerPoint 演示文稿中的幻灯片转换为 HTML：
```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // 保存文件
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomFormattingController implements IHtmlFormattingController
{
    @Override
    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeSlideStart(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(String.format(SlideHeader, generator.getSlideIndex() + 1));
    }

    @Override
    public void writeSlideEnd(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(SlideFooter);
    }

    @Override
    public void writeShapeStart(IHtmlGenerator generator, IShape shape) { }

    @Override
    public void writeShapeEnd(IHtmlGenerator generator, IShape shape) { }

    private final String SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    private final String SlideFooter = "</div>";
}
```


## **导出为 HTML 时保存 CSS 和图像**

使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程生成的 HTML 文件的样式。

此示例中的 Java 代码演示如何使用可重写的方法创建带有 CSS 文件链接的自定义 HTML 文档：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
    HtmlOptions options = new HtmlOptions();
    options.setHtmlFormatter(HtmlFormatter.createCustomFormatter(htmlController));

    pres.save("pres.html", SaveFormat.Html, options);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // 自定义标题模板
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName) 
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **在将演示文稿转换为 HTML 时链接所有字体**

如果您不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自定义的 `LinkAllFontsHtmlController` 版本来链接所有字体。

下面的 Java 代码演示如何在链接所有字体并排除 "Calibri" 和 "Arial"（因为系统已存在这些字体）的情况下，将 PowerPoint 转换为 HTML：
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //排除默认演示文稿字体
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList,"C:/Windows/Fonts/");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter((IHtmlFormattingController) linkcont));

    pres.save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
finally {
    if (pres != null) pres.dispose();
}
```


下面的 Java 代码演示 `LinkAllFontsHtmlController` 的实现方式：
```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // 可能需要对路径进行清理
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```


## **将 PowerPoint 转换为响应式 HTML**

下面的 Java 代码演示如何将 PowerPoint 演示文稿转换为响应式 HTML：
```java
Presentation pres = new Presentation("SomePresentation.pptx");
try {
    HtmlOptions saveOptions = new HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **导出媒体文件为 HTML**

使用 Aspose.Slides for Android via Java，您可以按以下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 获取对幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写入为 HTML 文件。

下面的 Java 代码演示如何向演示文稿添加视频，然后将其保存为 HTML：
```java
// 加载演示文稿
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // 设置 HTML 选项
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // 保存文件
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**将多个演示文稿转换为 HTML 时，Aspose.Slides 的性能如何？**

性能取决于演示文稿的大小和复杂度。Aspose.Slides 在批量操作中具有高效且可扩展的性能。为在转换大量演示文稿时获得最佳性能，建议尽可能使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**

是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。将演示文稿转换为 HTML 格式时，超链接会自动保留并保持可点击。

**在将演示文稿转换为 HTML 时，是否对幻灯片数量有限制？**

使用 Aspose.Slides 转换时，对幻灯片数量没有限制。您可以转换任意大小的演示文稿。但对于包含大量幻灯片的演示文稿，性能可能取决于服务器或系统的可用资源。