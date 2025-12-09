---
title: 在 JavaScript 中将 PowerPoint 转换为 HTML
linktitle: 将 Powerpoint 转换为 HTML
type: docs
weight: 30
url: /zh/nodejs-java/convert-powerpoint-to-html/
keywords: "Java PowerPoint 转 HTML, Convert PowerPoint 演示文稿, PPTX, PPT, PPT 转 HTML, PPTX 转 HTML, PowerPoint 转 HTML, 将 PowerPoint 保存为 HTML, 将 PPT 保存为 HTML, 将 PPTX 保存为 HTML, Java, Aspose.Slides, HTML 导出"
description: "在 JavaScript 中将 PowerPoint 转换为 HTML。将 PPTX 或 PPT 保存为 HTML。将幻灯片保存为 HTML。"
---

## **概述**

本文介绍如何使用 JavaScript 将 PowerPoint 演示文稿转换为 HTML 格式。内容包括以下主题。

- 使用 JavaScript 将 PowerPoint 转换为 HTML
- 使用 JavaScript 将 PPT 转换为 HTML
- 使用 JavaScript 将 PPTX 转换为 HTML
- 使用 JavaScript 将 ODP 转换为 HTML
- 使用 JavaScript 将 PowerPoint 幻灯片转换为 HTML

## **JavaScript PowerPoint 转 HTML**

为了获取将 PowerPoint 转换为 HTML 的 JavaScript 示例代码，请参阅下面的章节，即[Convert PowerPoint to HTML](#convert-powerpoint-to-html)。该代码能够在 Presentation 对象中加载 PPT、PPTX 和 ODP 等多种格式并保存为 HTML。

## **关于 PowerPoint 转 HTML 转换**

使用 [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。

**Aspose.Slides** 提供许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) 类），用于定义 PowerPoint 转 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。  
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。  
* 将演示文稿媒体（图像、视频等）转换为 HTML。  
* 将 PowerPoint 演示文稿转换为响应式 HTML。  
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。  
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。  
* 将 PowerPoint 演示文稿转换为使用原始字体或嵌入字体的 HTML。  
* 在使用新 CSS 样式的情况下将 PowerPoint 演示文稿转换为 HTML。  

{{% alert color="primary" %}} 

使用其自己的 API，Aspose 开发了免费的 [演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器：[PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想查看其他来自 Aspose 的 [免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除本文描述的转换过程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作： 

* [HTML 转图像](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)  
* [HTML 转 JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)  
* [HTML 转 XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)  
* [HTML 转 TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)  

{{% /alert %}}

## **将 PowerPoint 转换为 HTML**

使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法将对象保存为 HTML 文件。  

以下代码展示了如何在 JavaScript 中将 PowerPoint 转换为 HTML：

```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // 将演示文稿保存为 HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为响应式 HTML**

Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) 类，可生成响应式 HTML 文件。以下代码展示了如何在 JavaScript 中将 PowerPoint 演示文稿转换为响应式 HTML：

```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // 将演示文稿保存为 HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为带备注的 HTML**

以下代码展示了如何在 JavaScript 中将 PowerPoint 转换为带备注的 HTML：

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // 保存备注页
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为带原始字体的 HTML**

Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) 类，可在将演示文稿转换为 HTML 时嵌入所有字体。

为防止嵌入某些字体，您可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) 类的带参数构造函数传递字体名称数组。像 Calibri 或 Arial 这样常用的字体在演示文稿中使用时不必嵌入，因为大多数系统已包含这些字体。若嵌入这些字体，生成的 HTML 文档会不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) 类支持继承，并提供了 [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) 方法，供重写使用。

```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // 排除默认演示文稿字体
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为高质量图像的 HTML**

默认情况下，将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出的 HTML 较小，图像分辨率为 72 DPI 并删除裁剪区域。要获得更高质量图像的 HTML 文件，需要向 `HtmlOptions` 类的 `setPicturesCompression` 方法传入 `96`（即 `PicturesCompression.Dpi96`）或更高的[值](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression)。

以下 JavaScript 代码展示了如何在转换 PowerPoint 演示文稿为 HTML 时以 150 DPI（即 `PicturesCompression.Dpi150`）获取高质量图像：

```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


以下 JavaScript 代码展示了如何输出带完整质量图像的 HTML：

```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将幻灯片转换为 HTML**

要将 PowerPoint 中的特定幻灯片转换为 HTML，需要实例化相同的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类（用于将整个演示文稿转换为 HTML），然后使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法将文件保存为 HTML。[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) 类可用于指定其他转换选项：

以下 JavaScript 代码展示了如何将 PowerPoint 演示文稿中的幻灯片转换为 HTML：

```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // 保存文件
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **导出为 HTML 时保存 CSS 与图像**

使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程生成的 HTML 文件的样式。

本示例中的 JavaScript 代码展示了如何使用可重写方法创建带有 CSS 文件链接的自定义 HTML 文档：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


您需要在 Java 中实现 CustomHeaderAndFontsController，编译后添加到模块位置 \aspose.slides.via.java\lib\。

以下 Java 代码展示了 `CustomHeaderAndFontsController` 的实现方式：

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
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **将演示文稿转换为 HTML 时链接所有字体**

如果您不想嵌入字体（以避免增加生成的 HTML 大小），可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

以下 JavaScript 代码展示了如何在链接所有字体的同时将 PowerPoint 转换为 HTML，并排除 "Calibri" 和 "Arial"（因为系统已存在这些字体）：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 排除默认演示文稿字体
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


您需要在 Java 中实现 LinkAllFontsHtmlController，编译后添加到模块位置 \aspose.slides.via.java\lib\。

以下 Java 代码展示了 `LinkAllFontsHtmlController` 的实现方式：

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
            String path = fontName + ".woff"; // 可能需要进行路径清理
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

以下 JavaScript 代码展示了如何将 PowerPoint 演示文稿转换为响应式 HTML：

```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将媒体文件导出为 HTML**

使用 Aspose.Slides for Node.js via Java，您可以按如下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 获取该幻灯片的引用。  
1. 向幻灯片添加视频。  
1. 将演示文稿写为 HTML 文件。  

以下 JavaScript 代码展示了如何向演示文稿添加视频，然后保存为 HTML：

```javascript
// 加载演示文稿
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // 设置 HTML 选项
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // 保存文件
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**在将多个演示文稿转换为 HTML 时，Aspose.Slides 的性能如何？**  
性能取决于演示文稿的大小和复杂度。Aspose.Slides 对批量操作具有高效且可扩展的性能。为了在转换大量演示文稿时获得最佳性能，建议尽可能使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**  
是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。转换为 HTML 格式时，超链接会自动保留并保持可点击。

**在将演示文稿转换为 HTML 时，是否对幻灯片数量有限制？**  
使用 Aspose.Slides 时对幻灯片数量没有限制，您可以转换任意规模的演示文稿。但是，对于包含大量幻灯片的演示文稿，性能可能取决于服务器或系统的可用资源。