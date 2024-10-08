---
title: 在 Java 中将 PowerPoint 转换为 HTML
linktitle: 将 PowerPoint 转换为 HTML
type: docs
weight: 30
url: /java/convert-powerpoint-to-html/
keywords: "Java PowerPoint 转 HTML, 转换 PowerPoint 演示文稿, PPTX, PPT, PPT 转 HTML, PPTX 转 HTML, PowerPoint 转 HTML, 将 PowerPoint 保存为 HTML, 将 PPT 保存为 HTML, 将 PPTX 保存为 HTML, Java, Aspose.Slides, HTML 导出"
description: "在 Java 中将 PowerPoint 转换为 HTML：将 PPTX 或 PPT 保存为 HTML。在 Java 中将幻灯片保存为 HTML"
---

## **概述**

本文解释了如何使用 Java 将 PowerPoint 演示文稿转换为 HTML 格式。它涵盖以下主题。

- 在 Java 中将 PowerPoint 转换为 HTML
- 在 Java 中将 PPT 转换为 HTML
- 在 Java 中将 PPTX 转换为 HTML
- 在 Java 中将 ODP 转换为 HTML
- 在 Java 中将 PowerPoint 幻灯片转换为 HTML

## **Java PowerPoint 转 HTML**

要获取将 PowerPoint 转换为 HTML 的 Java 示例代码，请参见下面的部分，即 [将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)。该代码可以在演示对象中加载多种格式，如 PPT、PPTX 和 ODP，并将其保存为 HTML 格式。

## **关于 PowerPoint 到 HTML 转换**
使用 [**Aspose.Slides for Java**](https://products.aspose.com/slides/java/)，应用程序和开发人员可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。

**Aspose.Slides** 提供了许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) 类），定义 PowerPoint 到 HTML 转换的过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包括或不包括演讲者备注的 HTML。
* 将 PowerPoint 演示文稿转换为包括或不包括注释的 HTML。
* 将 PowerPoint 演示文稿转换为包括原始或嵌入字体的 HTML。
* 在使用新 CSS 样式的同时将 PowerPoint 演示文稿转换为 HTML。

{{% alert color="primary" %}} 

使用其自己的 API，Aspose 开发了免费的 [演示文稿到 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器：[PPT 到 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 到 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 到 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能还想查看其他 [Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除了此处描述的转换过程，Aspose.Slides 还支持涉及 HTML 格式的这些转换操作：

* [HTML 转图像](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}


## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 使用 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法将对象保存为 HTML 文件。

该代码向您展示了如何在 Java 中将 PowerPoint 转换为 HTML：

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
Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/ResponsiveHtmlController) 类，允许您生成响应式 HTML 文件。该代码向您展示了如何在 Java 中将 PowerPoint 演示文稿转换为响应式 HTML：

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
该代码向您展示了如何在 Java 中将 PowerPoint 转换为带备注的 HTML：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // 保存备注页面
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将 PowerPoint 转换为包含原始字体的 HTML**

Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) 类，允许您在将演示文稿转换为 HTML 时嵌入所有字体。

为防止某些字体被嵌入，您可以将字体名称数组传递给来自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) 类的参数化构造函数。大多数系统已经包含 Calibri 或 Arial 等流行字体，因此在演示文稿中使用时不必嵌入这些字体。当这些字体被嵌入时，生成的 HTML 文档会变得不必要地庞大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) 类支持继承并提供 [WriteFont](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) 方法，旨在被覆盖。

```java
Presentation pres = new Presentation("input.pptx");
try {
    // 排除默认的演示文稿字体
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

默认情况下，当您将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出小的 HTML，图像为 72 DPI，并删除裁剪区域。要获得更高质量的图像 HTML 文件，您必须将 `PicturesCompression` 属性（来自 `HtmlOptions` 类）设置为 96（即 `PicturesCompression.Dpi96`）或更高的 [值](https://reference.aspose.com/slides/java/com.aspose.slides/PicturesCompression)。

以下 Java 代码展示了如何在将 PowerPoint 演示文稿转换为 HTML 的同时获得 150 DPI（即 `PicturesCompression.Dpi150`）的高质量图像：

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

以下 Java 代码向您展示了如何输出具有全质量图像的 HTML：

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
要将 PowerPoint 中的特定幻灯片转换为 HTML，您必须实例化同一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类（用于将整个演示文稿转换为 HTML），然后使用 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法将文件保存为 HTML。可以使用 [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) 类来指定附加转换选项：

该 Java 代码向您展示了如何将 PowerPoint 演示文稿中的幻灯片转换为 HTML：

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


## **在导出为 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改从 PowerPoint 转换为 HTML 过程中生成的 HTML 文件的样式。

此示例中的 Java 代码向您展示了如何使用可重写的方法创建一个自定义 HTML 文档，并链接到 CSS 文件：

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

    // 自定义头部模板
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
        generator.addHtml("<!-- 嵌入的字体 -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **在将演示文稿转换为 HTML 时链接所有字体**

如果您不希望嵌入字体（以避免增加生成的 HTML 的大小），您可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

该 Java 代码向您展示了如何将 PowerPoint 转换为 HTML，同时链接所有字体并排除 "Calibri" 和 "Arial"（因为它们已经存在于系统中）：

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // 排除默认的演示文稿字体
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

该 Java 代码展示了如何实现 `LinkAllFontsHtmlController`：

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
            String path = fontName + ".woff"; // 可能需要一些路径清理
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
以下 Java 代码展示了如何将 PowerPoint 演示文稿转换为响应式 HTML：

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


## **导出媒体文件到 HTML**
使用 Aspose.Slides for Java，您可以通过以下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 获取对幻灯片的引用。
1. 向幻灯片添加视频。
1. 将演示文稿写入 HTML 文件。

该 Java 代码向您展示了如何向演示文稿添加视频，然后将其保存为 HTML：

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