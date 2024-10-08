---
title: 在Java中将PowerPoint转换为HTML
linktitle: 将PowerPoint转换为HTML
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-html/
keywords: "Java PowerPoint到HTML, 转换PowerPoint演示文稿, PPTX, PPT, PPT到HTML, PPTX到HTML, PowerPoint到HTML, 将PowerPoint保存为HTML, 将PPT保存为HTML, 将PPTX保存为HTML, Java, Aspose.Slides, HTML导出"
description: "在Java中转换PowerPoint为HTML：将PPTX或PPT保存为HTML。在Java中将幻灯片保存为HTML"
---

## **概述**

本文解释了如何使用Java将PowerPoint演示文稿转换为HTML格式。它涵盖以下主题。

- 在Java中将PowerPoint转换为HTML
- 在Java中将PPT转换为HTML
- 在Java中将PPTX转换为HTML
- 在Java中将ODP转换为HTML
- 在Java中将PowerPoint幻灯片转换为HTML

## **Java PowerPoint到HTML**

有关将PowerPoint转换为HTML的Java示例代码，请参见下面的部分，即[将PowerPoint转换为HTML](#convert-powerpoint-to-html)。该代码可以将PPT、PPTX和ODP等多种格式加载到Presentation对象中，并将其保存为HTML格式。

## **关于PowerPoint到HTML的转换**
使用[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)，应用程序和开发人员可以将PowerPoint演示文稿转换为HTML：**PPTX到HTML**或**PPT到HTML**。

**Aspose.Slides**提供多个选项（主要来自[**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)类），定义PowerPoint到HTML的转换过程：

* 将整个PowerPoint演示文稿转换为HTML。
* 将PowerPoint演示文稿中的特定幻灯片转换为HTML。
* 将演示文稿媒体（图像、视频等）转换为HTML。
* 将PowerPoint演示文稿转换为响应式HTML。 
* 将PowerPoint演示文稿转换为包含或不包含演讲者备注的HTML。 
* 将PowerPoint演示文稿转换为包含或不包含评论的HTML。 
* 将PowerPoint演示文稿转换为HTML时使用原始或嵌入字体。 
* 在转换为HTML时使用新CSS样式。 

{{% alert color="primary" %}} 

使用其自己的API，Aspose开发了免费的[演示文稿到HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器：[PPT到HTML](https://products.aspose.app/slides/conversion/ppt-to-html)，[PPTX到HTML](https://products.aspose.app/slides/conversion/pptx-to-html)，[ODP到HTML](https://products.aspose.app/slides/conversion/odp-to-html)等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能还想查看Aspose的其他[免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除了这里描述的转换过程外，Aspose.Slides还支持涉及HTML格式的这些转换操作： 

* [HTML到图像](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML到JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML到XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML到TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **将PowerPoint转换为HTML**
使用Aspose.Slides，您可以通过以下方式将整个PowerPoint演示文稿转换为HTML：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
1. 使用[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)方法将对象保存为HTML文件。

以下代码演示了如何在Java中将PowerPoint转换为HTML：

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // 保存演示文稿为HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将PowerPoint转换为响应式HTML**
Aspose.Slides提供的[ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController)类允许您生成响应式HTML文件。以下代码展示了如何在Java中将PowerPoint演示文稿转换为响应式HTML：

```java
// 实例化一个表示演示文稿文件的Presentation对象
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // 保存演示文稿为HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将PowerPoint转换为带有备注的HTML**
以下代码演示了如何在Java中将PowerPoint转换为带有备注的HTML：

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

## **将PowerPoint转换为带有原始字体的HTML**

Aspose.Slides提供的[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController)类使您可以在将演示文稿转换为HTML时嵌入所有字体。

为了防止某些字体被嵌入，您可以将一个字体名称数组传递给[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController)类的参数化构造函数。常用的字体，如Calibri或Arial，在演示文稿中使用时不必嵌入，因为大多数系统已包含此类字体。当这些字体被嵌入时，生成的HTML文档会变得不必要地庞大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController)类支持继承，并提供[WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-)方法，旨在被重写。

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

## **将PowerPoint转换为带有高质量图像的HTML**

默认情况下，当您将PowerPoint转换为HTML时，Aspose.Slides输出的小HTML图像分辨率为72 DPI，并删除裁剪区域。要获得更高质量图像的HTML文件，您必须将`PicturesCompression`属性（来自`HtmlOptions`类）设置为96（即`PicturesCompression.Dpi96`）或更高[值](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression)。

以下Java代码演示了如何将PowerPoint演示文稿转换为HTML，同时获得150 DPI（即`PicturesCompression.Dpi150`）的高质量图像：

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

以下Java代码演示了如何输出带有全质量图像的HTML：

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

## **将幻灯片转换为HTML**
要将PowerPoint中的特定幻灯片转换为HTML，您必须实例化相同的[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类（用于将整个演示文稿转换为HTML），然后使用[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)方法将文件保存为HTML。可以使用[HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)类来指定其他转换选项：

以下Java代码展示了如何将PowerPoint演示文稿中的幻灯片转换为HTML：

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


## **在导出到HTML时保存CSS和图像**
使用新的CSS样式文件，您可以轻松更改PowerPoint到HTML转换过程中产生的HTML文件的样式。

以下Java代码展示了如何使用可覆盖的方法创建一个带有CSS文件链接的自定义HTML文档：

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

    // 自定义头模板
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

## **将所有字体链接到转换为HTML的演示文稿**

如果您不想嵌入字体（以避免增加生成的HTML的大小），您可以通过实现自己的`LinkAllFontsHtmlController`版本来链接所有字体。

以下Java代码展示了如何在将PowerPoint转换为HTML时链接所有字体，并排除“Calibri”和“Arial”（因为它们已经存在于系统中）：

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // 排除默认演示文稿字体
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

以下Java代码展示了如何实现`LinkAllFontsHtmlController`：

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

## **将PowerPoint转换为响应式HTML**
以下Java代码展示了如何将PowerPoint演示文稿转换为响应式HTML：

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


## **将媒体文件导出为HTML**
使用Aspose.Slides for Android via Java，您可以通过以下方式导出媒体文件：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
1. 获取幻灯片的引用。
1. 将视频添加到幻灯片。
1. 将演示文稿写入HTML文件。

以下Java代码展示了如何将视频添加到演示文稿中，然后将其保存为HTML： 

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

    // 设置HTML选项
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