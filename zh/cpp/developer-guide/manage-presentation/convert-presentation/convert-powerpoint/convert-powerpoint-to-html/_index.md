---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/cpp/convert-powerpoint-to-html/
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
- 将演示文稿保存为 HTML
- 将幻灯片保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- 导出 PPT 为 HTML
- 导出 PPTX 为 HTML
- C++
- Aspose.Slides
description: "在 C++ 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南，保持布局、链接和图像，实现快速且完美的结果。"
---

## **概述**

本文说明如何使用 C++ 将 PowerPoint 演示文稿转换为 HTML 格式。它涵盖以下主题。

- [在 C++ 中将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)
- [在 C++ 中将 PPT 转换为 HTML](#convert-powerpoint-to-html)
- [在 C++ 中将 PPTX 转换为 HTML](#convert-powerpoint-to-html)
- [在 C++ 中将 ODP 转换为 HTML](#convert-powerpoint-to-html)
- [在 C++ 中将 PowerPoint 幻灯片转换为 HTML](#convert-slide-to-html)

## **在 C++ 中将 PowerPoint 转换为 HTML**

有关在 C++ 中将 PowerPoint 转换为 HTML 的示例代码，请参见以下章节，即 [Convert PowerPoint to HTML](#convert-powerpoint-to-html)。代码可以在 Presentation 对象中加载 PPT、PPTX 和 ODP 等多种格式，并将其保存为 HTML 格式。

## **关于 PowerPoint 到 HTML 的转换**

使用 [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转为 HTML** 或 **PPT 转为 HTML**。 

**Aspose.Slides** 提供许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) 类），它们定义了 PowerPoint 到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。 
* 将 PowerPoint 演示文稿转换为使用原始或嵌入字体的 HTML。 
* 在使用新 CSS 样式的情况下将 PowerPoint 演示文稿转换为 HTML。 

{{% alert color="primary" %}} 

使用其自有 API，Aspose 开发了免费的 [演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器： [PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想查看其他 [Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除了此处描述的转换过程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作： 

* [HTML 转图像](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以按以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
   * 在 _Presentation_ 类中加载 **.ppt** 以 **在 C++ 中将 PPT 转换为 HTML**
   * 在 _Presentation_ 类中加载 **.pptx** 以 **在 C++ 中将 PPTX 转换为 HTML**
   * 在 _Presentation_ 类中加载 **.odp** 以 **在 C++ 中将 ODP 转换为 HTML**
3. 使用 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) 方法将对象保存为 HTML 文件。

此代码演示了如何在 C++ 中将 PowerPoint 转换为 HTML：
```cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// 将演示文稿保存为 HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **将 PowerPoint 转换为响应式 HTML**
Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) 类，允许您生成响应式 HTML 文件。此代码演示了如何在 C++ 中将 PowerPoint 演示文稿转换为响应式 HTML：
```cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// 将演示文稿保存为 HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **将 PowerPoint 转换为带备注的 HTML**
此代码演示了如何在 C++ 中将 PowerPoint 转换为带备注的 HTML：
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// 保存备注页面
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **将 PowerPoint 转换为带原始字体的 HTML**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) 类，允许在将演示文稿转换为 HTML 时嵌入所有字体。

要防止嵌入某些字体，可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) 类的带参数构造函数传递字体名称数组。诸如 Calibri 或 Arial 等常用字体在演示文稿中使用时不必嵌入，因为大多数系统已预装这些字体。当这些字体被嵌入时，生成的 HTML 文档会不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) 类支持继承，并提供了 [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) 方法，供覆盖使用。 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// exclude default presentation fonts
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **将 PowerPoint 转换为高质量图像的 HTML**
默认情况下，当您将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出分辨率为 72 DPI 且已删除裁剪区域的较小 HTML。要获得具有更高质量图像的 HTML 文件，必须将 `PicturesCompression` 属性（来自 `HtmlOptions` 类）设置为 96（即 `PicturesCompression::Dpi96`）或更高的 [值](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8)。

此 C++ 代码演示了如何在将 PowerPoint 演示文稿转换为 HTML 时获取 150 DPI 的高质量图像（即 `PicturesCompression::Dpi150`）：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


此代码演示了如何输出具有完整质量图像的 HTML：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **将幻灯片转换为 HTML**
要将 PowerPoint 中的特定幻灯片转换为 HTML，必须实例化相同的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类（用于将整个演示文稿转换为 HTML），然后使用 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) 方法将文件保存为 HTML。[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) 类可用于指定额外的转换选项：

此 C++ 代码演示了如何将 PowerPoint 演示文稿中的幻灯片转换为 HTML：
``` cpp
class CustomFormattingController : public IHtmlFormattingController
{
public:
    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteDocumentEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteSlideStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(String::Format(SlideHeader, generator->get_SlideIndex() + 1));
    }
    void WriteSlideEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(SlideFooter);
    }
    void WriteShapeStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}
    void WriteShapeEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}

private:
    static const String SlideHeader;
    static const String SlideFooter;
};

const String CustomFormattingController::SlideHeader = u"<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
const String CustomFormattingController::SlideFooter = u"</div>";
```

``` cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>();
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // 保存文件              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```


## **导出为 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改由 PowerPoint 转 HTML 转换过程生成的 HTML 文件的样式。 

本示例中的 C++ 代码演示了如何使用可覆盖的方法创建带有 CSS 文件链接的自定义 HTML 文档：
``` cpp
class CustomHeaderAndFontsController : public EmbedAllFontsHtmlController
{
public:
    CustomHeaderAndFontsController(String cssFileName)
        : m_cssFileName(cssFileName)
    {
    }

    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(System::String::Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    void WriteAllFonts(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(u"<!-- Embedded fonts -->");
        EmbedAllFontsHtmlController::WriteAllFonts(generator, presentation);
    }

private:
    static const String Header;
    String m_cssFileName;
};

const String CustomHeaderAndFontsController::Header = String(u"<!DOCTYPE html>\n") + 
u"<html>\n" + u"<head>\n" + 
u"<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">\n" + 
u"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" + 
u"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" + u"</head>";
```

``` cpp
void Run()
{
    // 文档目录的路径。
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **在将演示文稿转换为 HTML 时链接所有字体**
如果不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。 

此 C++ 代码演示了如何在链接所有字体且排除 “Calibri” 与 “Arial”（因为系统已存在）时将 PowerPoint 转换为 HTML：
```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        :   EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // 可能需要对路径进行清理
        IO::File::WriteAllBytes(IO::Path::Combine(m_basePath, path), fontData);

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face { ");
        generator->AddHtml(String::Format(u"font-family: '{0}'; ", fontName));
        generator->AddHtml(String::Format(u"src: url('{0}')", path));

        generator->AddHtml(u" }");
        generator->AddHtml(u"</style>");
    }

private:
    String m_basePath;
};
```

``` cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // 排除默认演示文稿字体
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **将 PowerPoint 转换为响应式 HTML**
此 C++ 代码演示了如何将 PowerPoint 演示文稿转换为响应式 HTML：
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **导出媒体文件为 HTML**
使用 Aspose.Slides for C++，您可以按以下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 获取对幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写入为 HTML 文件。

此 C++ 代码演示了如何向演示文稿添加视频并将其保存为 HTML： 
```cpp
 // 加载演示文稿
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// 设置 HTML 选项
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// 保存文件
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **常见问题**

**在将多个演示文稿转换为 HTML 时，Aspose.Slides 的性能如何？**

性能取决于演示文稿的大小和复杂度。Aspose.Slides 在批量操作中具有高效且可伸缩的特点。为获得最佳性能，建议在可能的情况下使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**

是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。转换为 HTML 格式时，超链接会自动保留并保持可点击。

**在将演示文稿转换为 HTML 时，幻灯片数量是否有限制？**

使用 Aspose.Slides 时，对幻灯片数量没有限制。您可以转换任意大小的演示文稿。但对于包含非常大量幻灯片的演示文稿，性能可能受服务器或系统可用资源的影响。