---
title: 将 PowerPoint 演示文稿转换为 .NET 中的 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/net/convert-powerpoint-to-html/
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
- 将 PPT 导出为 HTML
- 将 PPTX 导出为 HTML
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南，保留布局、链接和图像，实现快速、完美的结果。"
---

## **概述**

通过使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 HTML，提升您的工作流。本指南提供详细的说明、可靠的代码示例以及经过测试的方法，确保可靠高效的转换过程，并针对网页查看进行优化。

Aspose.Slides 提供了许多选项——主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) 类——用于定义从 PowerPoint（或 OpenDocument）格式到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含评论的 HTML。
* 将 PowerPoint 演示文稿转换为使用原始字体或嵌入字体的 HTML。
* 使用新的 CSS 样式将 PowerPoint 演示文稿转换为 HTML。

## **将演示文稿转换为 HTML**

使用 Aspose.Slides，您可以按照以下方式将整个 PowerPoint 或 OpenDocument 演示文稿转换为 HTML：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将对象保存为 HTML 文件。

此代码展示了如何在 C# 中将 PowerPoint 演示文稿转换为 HTML：
```c#
 // 实例化表示演示文稿文件的 Presentation 类（例如 PPT、PPTX、ODP 等）。
 using (Presentation presentation = new Presentation("presentation.pptx"))
 {
     // 将演示文稿保存为 HTML。
     presentation.Save("output.html", SaveFormat.Html);
 }
```


## **将演示文稿转换为响应式 HTML**

Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) 类，可生成响应式 HTML 文件。以下代码演示了如何在 C# 中将 PowerPoint 演示文稿转换为响应式 HTML：
```c#
 // 实例化表示演示稿文件的 Presentation 类。
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // 将演示稿保存为 HTML。
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **将演示文稿转换为包含演讲者备注的 HTML**

将 PowerPoint 或 OpenDocument 演示文稿转换为包含演讲者备注的 HTML 时，需要完整保留原始文档的精髓。此过程确保不仅幻灯片的视觉元素被准确呈现，伴随的演讲者备注也被保留下来，为内容增添额外的上下文和洞见。

假设我们有如下带有演讲者备注的幻灯片：

![A presentation slide with speaker notes](slide_with_notes.png)

此代码演示了如何在 C# 中将 PowerPoint 演示文稿转换为包含演讲者备注的 HTML：
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


结果：

![An HTML document with the slide and speaker notes](HTML_with_notes.png)

## **将演示文稿转换为使用原始字体的 HTML**

Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类，允许在将演示文稿转换为 HTML 时嵌入所有字体。

若要避免嵌入某些字体，可向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 的参数化构造函数传递字体名称数组。诸如 Calibri 或 Arial 等常用字体无需嵌入，因为大多数系统已经预装这些字体。嵌入它们只会不必要地增大生成的 HTML 文档体积。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) 类支持继承，并提供了可覆盖的 [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) 方法。
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

默认情况下，将 PowerPoint 演示文稿转换为 HTML 时，Aspose.Slides 会输出图像分辨率为 72 DPI 且删除裁剪区域的小 HTML 文件。若需获得更高质量的图像，需要将 `HtmlOptions` 类的 `PicturesCompression` 属性设置为 96（即 `PicturesCompression.Dpi96`）或更高的值，详见 [此参考](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression)。

以下 C# 代码演示了如何在将 PowerPoint 演示文稿转换为 HTML 时获取 150 DPI（即 `PicturesCompression.Dpi150`）的高质量图像：
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


以下 C# 代码展示了如何在将 PowerPoint 演示文稿转换为 HTML 时保留裁剪区域：
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

要将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML，需要实例化用于整体转换的同一 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类，然后使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将文件保存为 HTML。可使用 [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) 类指定其他转换选项。

此 C# 代码演示了如何将 PowerPoint 演示文稿中带有演讲者备注的幻灯片转换为 HTML：
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

            // 保存幻灯片为HTML文件。
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

使用新的 CSS 样式文件，您可以轻松更改由 PowerPoint 转 HTML 过程生成的 HTML 文件的外观。

本示例中的 C# 代码演示了如何使用可覆盖的方法创建包含指向 CSS 文件链接的自定义 HTML 文档：
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
    // 自定义标题模板。
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

如果不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自定义的 `LinkAllFontsHtmlController` 来链接所有字体。

此 C# 代码展示了如何在将 PowerPoint 演示文稿转换为 HTML 时链接所有字体，并排除 “Calibri” 和 “Arial”（因为它们已预装在系统中）：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // 排除默认演示文稿字体。
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


此 C# 代码展示了 `LinkAllFontsHtmlController` 的实现方式：
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

此 C# 代码展示了如何将 PowerPoint 演示文稿转换为响应式 HTML：
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


## **将媒体文件导出为 HTML**

使用 Aspose.Slides for .NET，您可以按以下步骤导出媒体文件：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 获取对幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写出为 HTML 文件。

此 C# 代码演示了如何向演示文稿添加视频，然后将其保存为 HTML：
```c#
// 创建一个新演示文稿。
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

Aspose 开发了免费 [演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器： [PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

了解更多 Aspose 提供的其他免费转换器：
{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

除本文档中描述的转换过程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **常见问题**

**Aspose.Slides 在将多个演示文稿批量转换为 HTML 时的性能如何？**

性能取决于演示文稿的大小和复杂度。Aspose.Slides 在批量操作时具有高效且可扩展的特性。为获得最佳性能，建议在可能的情况下使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**

是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。转换为 HTML 格式时，超链接会自动保留下来并保持可点击。

**在将演示文稿转换为 HTML 时，幻灯片数量是否有限制？**

使用 Aspose.Slides 转换时对幻灯片数量没有限制，您可以转换任意大小的演示文稿。但对于幻灯片数量非常巨大的演示文稿，性能可能受服务器或系统可用资源的影响。