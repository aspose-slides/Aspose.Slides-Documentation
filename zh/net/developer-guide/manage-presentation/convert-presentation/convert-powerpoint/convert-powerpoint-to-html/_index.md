---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中将 PowerPoint 演示文稿转换为响应式 HTML。通过 Aspose.Slides 转换指南，保持布局、链接和图像，实现快速且完美的结果。"
---

## **概述**

通过使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 HTML，提升您的工作流程。本指南提供详细的说明、强大的代码示例和经过测试的方法，以确保可靠且高效的转换过程，针对网页浏览进行优化。

Aspose.Slides 提供许多选项——主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) 类——用于定义从 PowerPoint（或 OpenDocument）格式到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图片、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。
* 将 PowerPoint 演示文稿转换为使用原始字体或嵌入字体的 HTML。
* 使用新的 CSS 样式将 PowerPoint 演示文稿转换为 HTML。

## **将演示文稿转换为 HTML**

使用 Aspose.Slides，您可以按以下方式将整个 PowerPoint 或 OpenDocument 演示文稿转换为 HTML：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将对象保存为 HTML 文件。

以下代码演示如何在 C# 中将 PowerPoint 演示文稿转换为 HTML：
```c#
// 实例化表示演示文稿文件（例如 PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // 将演示文稿保存为 HTML。
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **将演示文稿转换为响应式 HTML**

Aspose.Slides 提供 [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) 类，使您能够生成响应式 HTML 文件。以下代码演示如何在 C# 中将 PowerPoint 演示文稿转换为响应式 HTML：
```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // 将演示文稿保存为 HTML。
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **将演示文稿转换为带有演讲者备注的 HTML**

在将 PowerPoint 或 OpenDocument 演示文稿转换为带有演讲者备注的 HTML 时，必须完整捕捉原始文档的精髓。此过程确保幻灯片的视觉元素准确呈现，同时保留随附的演讲者备注，丰富内容并提供额外的上下文与洞见。

假设我们有一个包含以下幻灯片的 PowerPoint 演示文稿：

![A presentation slide with speaker notes](slide_with_notes.png)

以下代码演示如何在 C# 中将 PowerPoint 演示文稿转换为带有演讲者备注的 HTML：
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // 设置演讲者备注的选项。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 设置输出 HTML 文档的选项。
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // 将演示文稿保存为带有演讲者备注的 HTML。
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


结果如下：

![An HTML document with the slide and speaker notes](HTML_with_notes.png)

## **将演示文稿转换为使用原始字体的 HTML**

Aspose.Slides 提供 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类，允许在将演示文稿转换为 HTML 时嵌入所有字体。

若要防止某些字体被嵌入，您可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类的带参数构造函数传递字体名称数组。常用字体如 Calibri 或 Arial 无需嵌入，因为大多数系统已经包含这些字体。嵌入它们会不必要地增大生成的 HTML 文档大小。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类支持继承，并提供 [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) 方法，可供重写。
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // 排除默认演示文稿的字体。
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **将演示文稿转换为高质量图像的 HTML**

默认情况下，将 PowerPoint 演示文稿转换为 HTML 时，Aspose.Slides 会生成图像为 72 DPI 且删除裁剪区域的小型 HTML 文件。要获取具有更高质量图像的 HTML 文件，必须将 `PicturesCompression` 属性（来自 `HtmlOptions` 类）设置为 96（即 `PicturesCompression.Dpi96`）或更高值，详细说明请参阅 [this reference](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression)。

以下 C# 代码演示如何在将 PowerPoint 演示文稿转换为 HTML 时获取 150 DPI（即 `PicturesCompression.Dpi150`）的高质量图像：
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        PicturesCompression = PicturesCompression.Dpi150
    };

    presentation.Save("output_dpi_150.html", SaveFormat.Html, htmlOptions);
}
```


以下 C# 代码演示如何在将 PowerPoint 演示文稿转换为 HTML 时不删除裁剪区域：
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        DeletePicturesCroppedAreas = false
    };

    presentation.Save("output_no_crop.html", SaveFormat.Html, htmlOptions);
}
```


## **将演示文稿幻灯片转换为 HTML**

要将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML，您需要实例化相同的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类（用于将整个演示文稿转换为 HTML），然后使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将文件保存为 HTML。可使用 [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) 类指定其他转换选项。

以下 C# 代码演示如何将 PowerPoint 演示文稿中带有演讲者备注的幻灯片转换为 HTML：
```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("sample.pptx"))
    {
        NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull
        };

        HtmlOptions htmlOptions = new HtmlOptions
        {
            SlidesLayoutOptions = notesOptions,
            HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController())
        };

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            int slideIndex = i + 1;

            // 将幻灯片保存为 HTML 文件。
            string fileName = $"output_slide_{slideIndex}.html";
            presentation.Save(fileName, new[] { slideIndex }, SaveFormat.Html, htmlOptions);
        }
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


## **导出为 HTML 时保存 CSS 和图像**

使用新的 CSS 样式文件，您可以轻松更改从 PowerPoint 转换为 HTML 过程生成的 HTML 文件的外观。

本示例中的 C# 代码演示如何使用可重写的方法创建包含 CSS 文件链接的自定义 HTML 文档：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");

	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	presentation.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // 自定义头部模板。
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
        generator.AddHtml("<!-- Embedded fonts -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```


## **将演示文稿转换为 HTML 时链接所有字体**

如果您不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

以下 C# 代码演示如何在将 PowerPoint 演示文稿转换为 HTML 时链接所有字体并排除 "Calibri" 和 "Arial"（因为它们已在系统中安装）：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // 排除默认演示文稿的字体。
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


以下 C# 代码展示了 `LinkAllFontsHtmlController` 的实现方式：
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
            string path = fontName + ".woff"; // 可能需要对路径进行清理。

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


## **将包含 SVG 图像的演示文稿转换为响应式 HTML**

以下 C# 代码演示如何将 PowerPoint 演示文稿转换为响应式 HTML：
```c#
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    HtmlOptions saveOptions = new HtmlOptions
    {
        SvgResponsiveLayout = true
    };

    presentation.Save("SvgResponsiveLayout-out.html", SaveFormat.Html, saveOptions);
}
```


## **导出媒体文件为 HTML**

使用 Aspose.Slides for .NET，您可以按以下方式导出媒体文件：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 获取对幻灯片的引用。
1. 向幻灯片添加视频。
1. 将演示文稿写入为 HTML 文件。

以下 C# 代码演示如何向演示文稿添加视频，然后将其保存为 HTML：
```c#
// 创建一个新的演示文稿。
using (Presentation presentation = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = presentation.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = presentation.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // 设置 HTML 选项。
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // 将演示文稿保存为 HTML 文件。
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

Aspose 开发了免费的 [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

查看其他 [Aspose 免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

除了此处描述的转换过程外，Aspose.Slides 还支持以下 HTML 格式相关的转换操作：

* [HTML 转图片](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **常见问题**

**Aspose.Slides 在将多个演示文稿转换为 HTML 时的性能如何？**

性能取决于演示文稿的大小和复杂度。Aspose.Slides 在批量操作中具有高效且可扩展的特性。为了在转换大量演示文稿时获得最佳性能，建议尽可能使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**

是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。将演示文稿转换为 HTML 格式时，超链接会自动保留并保持可点击。

**在将演示文稿转换为 HTML 时，幻灯片数量是否有限制？**

使用 Aspose.Slides 时对幻灯片数量没有限制。您可以转换任意大小的演示文稿。但对于包含非常大量幻灯片的演示文稿，性能可能取决于服务器或系统的可用资源。