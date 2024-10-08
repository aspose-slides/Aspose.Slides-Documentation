---
title: 在 C# .NET 中将 PowerPoint 转换为 HTML
linktitle: 将 PowerPoint 转换为 HTML
type: docs
weight: 30
url: /net/convert-powerpoint-to-html/
keywords: "C# PowerPoint 转 HTML, C# PPT 转 HTML, C# ODP 转 HTML, C# 幻灯片 转 HTML, 转换 PowerPoint 演示文稿, PPTX, PPT, PPT 转 HTML, PPTX 转 HTML, PowerPoint 转 HTML, 将 PowerPoint 保存为 HTML, 将 PPT 保存为 HTML, 将 PPTX 保存为 HTML, C#, Csharp, .NET, Aspose.Slides, HTML 导出"
description: "转换 PowerPoint HTML：将 PPTX 或 PPT 保存为 HTML。将幻灯片保存为 HTML"
---

## **概述**

本文解释了如何使用 C# 将 PowerPoint 演示文稿转换为 HTML 格式。它涵盖了以下主题。

- [在 C# 中将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)
- [在 C# 中将 PPT 转换为 HTML](#convert-powerpoint-to-html)
- [在 C# 中将 PPTX 转换为 HTML](#convert-powerpoint-to-html)
- [在 C# 中将 ODP 转换为 HTML](#convert-powerpoint-to-html)
- [在 C# 中将 PowerPoint 幻灯片转换为 HTML](#convert-slide-to-html)

## **C# PowerPoint 转 HTML**

有关将 PowerPoint 转换为 HTML 的 C# 示例代码，请参见下面的部分，即 [在 C# 中将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)。该代码可以在 Presentation 对象中加载多种格式，如 PPT、PPTX 和 ODP，并将其保存为 HTML 格式。

## **关于 PowerPoint 到 HTML 转换**
使用 [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)，应用程序和开发人员可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。 

**Aspose.Slides** 提供了多种选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) 类），定义了 PowerPoint 到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者注释的 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含评论的 HTML。 
* 将 PowerPoint 演示文稿转换为包含原始或嵌入字体的 HTML。 
* 将 PowerPoint 演示文稿转换为使用新 CSS 样式的 HTML。 

{{% alert color="primary" %}} 

使用其自己的 API，Aspose 开发了免费的 [演示文稿到 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器：[PPT 到 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 到 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 到 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能希望查看其他 [Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除了这里描述的转换过程，Aspose.Slides 还支持涉及 HTML 格式的这些转换操作： 

* [HTML 到图像](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML 到 JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML 到 XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML 到 TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用 [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将对象保存为 HTML 文件。

以下代码向您展示了如何在 C# 中将 PowerPoint 转换为 HTML：

```c#
// 实例化表示演示文稿文件的演示对象，例如 PPT、PPTX、ODP 等。
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // 将演示文稿保存为 HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **将 PowerPoint 转换为响应式 HTML**
Aspose.Slides 提供了 [ResponsiveHtmlController ](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) 类，允许您生成响应式 HTML 文件。以下代码向您展示了如何在 C# 中将 PowerPoint 演示文稿转换为响应式 HTML：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // 将演示文稿保存为 HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **将 PowerPoint 转换为带备注的 HTML**
以下代码向您展示了如何在 C# 中将 PowerPoint 转换为带备注的 HTML：

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // 保存备注页
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **将 PowerPoint 转换为带原始字体的 HTML**

Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类，允许您在将演示文稿转换为 HTML 时嵌入所有字体。

为了防止某些字体被嵌入，您可以将一个字体名称数组传递给 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类的参数化构造函数。流行字体，例如 Calibri 或 Arial，在演示文稿中使用时不必嵌入，因为大多数系统已经包含这些字体。当这些字体被嵌入时，生成的 HTML 文档会变得不必要的大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类支持继承，并提供 [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) 方法，旨在被重写。 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // 排除默认演示文稿字体
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **将 PowerPoint 转换为带高质量图像的 HTML**

默认情况下，当您将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出 72 DPI 和删除裁剪区域的小 HTML 图像。为了获得更高质量图像的 HTML 文件，您必须将 `PicturesCompression` 属性（来自 `HtmlOptions` 类）设置为 96（即 `PicturesCompression.Dpi96`）或更高 [值](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression)。

以下 C# 代码向您展示了如何在获得 150 DPI（即 `PicturesCompression.Dpi150`）的高质量图像时将 PowerPoint 演示文稿转换为 HTML：

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

以下 C# 代码向您展示了如何输出带有高质量图像的 HTML：

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **将幻灯片转换为 HTML**
要将 PowerPoint 中的特定幻灯片转换为 HTML，您必须实例化同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类（用于将整个演示文稿转换为 HTML），然后使用 [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将文件保存为 HTML。[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) 类可用于指定其他转换选项：

以下 C# 代码向您展示了如何将 PowerPoint 演示文稿中的一张幻灯片转换为 HTML：

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // 保存文件              
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Individual Slide" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
    }
}

public class CustomFormattingController : IHtmlFormattingController
{
    void IHtmlFormattingController.WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteSlideStart(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(string.Format(SlideHeader, generator.SlideIndex + 1));
    }

    void IHtmlFormattingController.WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(SlideFooter);
    }

    void IHtmlFormattingController.WriteShapeStart(IHtmlGenerator generator, IShape shape)
    {}

    void IHtmlFormattingController.WriteShapeEnd(IHtmlGenerator generator, IShape shape)
    {}

    private const string SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
    private const string SlideFooter = "</div>";
}
```


## **导出到 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改从 PowerPoint 到 HTML 转换过程中生成的 HTML 文件的样式。 

以下 C# 代码示例向您展示了如何使用可重写的方法创建一个自定义 HTML 文档并链接到 CSS 文件：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // 自定义头部模板
    const string Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "<head>\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
                            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" +
                            "</head>";


    private readonly string m_cssFileName;

    public CustomHeaderAndFontsController(string cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public override void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml(string.Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    public override void WriteAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml("<!-- 嵌入字体 -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **将所有字体链接到转换后的 HTML 演示文稿**

如果您不想嵌入字体（以避免增加生成 HTML 的大小），可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。 

以下 C# 代码向您展示了如何在转换 PowerPoint 为 HTML 时链接所有字体，并排除 "Calibri" 和 "Arial"（因为它们已经存在于系统中）： 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    // 排除默认演示文稿字体
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

以下 C# 代码展示了 `LinkAllFontsHtmlController` 的实现：

```c#
public class LinkAllFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string m_basePath;

    public LinkAllFontsHtmlController(string[] fontNameExcludeList, string basePath) : base(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    public override void WriteFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            string fontStyle,
            string fontWeight,
            byte[] fontData)
    {
        try
        {
            string fontName = substitutedFont == null ? originalFont.FontName : substitutedFont.FontName;
            string path = fontName + ".woff"; // 可能需要进行路径清理

            File.WriteAllBytes(Path.Combine(m_basePath, path), fontData);
            
            generator.AddHtml("<style>");
            generator.AddHtml("@font-face { ");
            generator.AddHtml("font-family: '" + fontName + "'; ");
            generator.AddHtml("src: url('" + path + "')");

            generator.AddHtml(" }");
            generator.AddHtml("</style>");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

## **将 PowerPoint 转换为响应式 HTML**
以下 C# 代码向您展示了如何将 PowerPoint 演示文稿转换为响应式 HTML：

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **导出媒体文件到 HTML**
使用 Aspose.Slides for .NET，您可以这样导出媒体文件：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的一个实例。
1. 获取幻灯片的引用。
1. 在幻灯片中添加视频。
1. 将演示文稿写入 HTML 文件。

以下 C# 代码向您展示了如何在演示文稿中添加视频并将其保存为 HTML： 

```c#
// 加载演示文稿
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // 设置 HTML 选项
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // 保存文件
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```