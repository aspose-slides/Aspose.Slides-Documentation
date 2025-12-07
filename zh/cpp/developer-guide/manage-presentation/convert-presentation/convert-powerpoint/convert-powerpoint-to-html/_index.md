---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "在 C++ 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南，可快速、完美地保留布局、链接和图像。"
---

## **概述**

本文档说明如何使用 C++ 将 PowerPoint 演示文稿转换为 HTML 格式，涉及以下主题。

- [将 PowerPoint 转换为 HTML（C++）](#convert-powerpoint-to-html)
- [将 PPT 转换为 HTML（C++）](#convert-powerpoint-to-html)
- [将 PPTX 转换为 HTML（C++）](#convert-powerpoint-to-html)
- [将 ODP 转换为 HTML（C++）](#convert-powerpoint-to-html)
- [将 PowerPoint 幻灯片转换为 HTML（C++）](#convert-slide-to-html)

## **PowerPoint 转 HTML（C++）**

有关使用 C++ 将 PowerPoint 转换为 HTML 的示例代码，请参阅下文[将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)章节。代码可以在 Presentation 对象中加载 PPT、PPTX、ODP 等多种格式，并保存为 HTML。

## **关于 PowerPoint 转 HTML 转换**
使用 [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。

**Aspose.Slides** 提供许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) 类），用于定义 PowerPoint 转 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿的媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。
* 将 PowerPoint 演示文稿转换为使用原始或嵌入字体的 HTML。
* 将 PowerPoint 演示文稿转换为使用新 CSS 样式的 HTML。

{{% alert color="primary" %}} 

使用自有 API，Aspose 开发了免费的[演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器：[[PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)]、[[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)]、[[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html)] 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您还可以查看其他 [Aspose 免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除了本文档中描述的转换流程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。  
   * 在 _Presentation_ 类中加载 **.ppt** 以 **将 PPT 转换为 HTML（C++）**  
   * 在 _Presentation_ 类中加载 **.pptx** 以 **将 PPTX 转换为 HTML（C++）**  
   * 在 _Presentation_ 类中加载 **.odp** 以 **将 ODP 转换为 HTML（C++）**  
3. 使用 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) 方法将对象保存为 HTML 文件。

下面的代码演示了如何在 C++ 中将 PowerPoint 转换为 HTML：
```cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// 将演示文稿保存为 HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **将 PowerPoint 转换为响应式 HTML**
Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) 类，可生成响应式 HTML 文件。以下代码演示了在 C++ 中将 PowerPoint 演示文稿转换为响应式 HTML：
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
下面的代码展示了如何在 C++ 中将 PowerPoint 转换为带备注的 HTML：
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saving notes pages
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **将 PowerPoint 转换为带原始字体的 HTML**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) 类，允许在转换为 HTML 时嵌入演示文稿中的所有字体。

若要防止某些字体被嵌入，可向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) 的参数化构造函数传递字体名称数组。常用字体（如 Calibri 或 Arial）在大多数系统中已有，无需嵌入；若嵌入这些字体，会导致生成的 HTML 文档体积不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) 支持继承，并提供了可被覆盖的 [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) 方法。
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// 排除默认演示文稿字体
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **将 PowerPoint 转换为带高质量图像的 HTML**
默认情况下，将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出的 HTML 中图像分辨率为 72 DPI，且会删除裁剪区域。若需获得更高质量的图像，需要将 `HtmlOptions` 类中的 `PicturesCompression` 属性设置为 96（即 `PicturesCompression::Dpi96`）或更高的[值](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8)。

下面的 C++ 代码展示了如何在转换为 HTML 时获取 150 DPI（`PicturesCompression::Dpi150`）的高质量图像：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


下面的 C++ 代码展示了如何输出包含全质量图像的 HTML：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **将幻灯片转换为 HTML**
若要将 PowerPoint 中的特定幻灯片转换为 HTML，需要实例化与转换整篇演示文稿相同的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类，然后使用 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) 方法保存为 HTML。可以使用 [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) 类指定其他转换选项：

下面的 C++ 代码演示了如何将 PowerPoint 演示文稿的单个幻灯片转换为 HTML：
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


## **导出 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程生成的 HTML 文件的样式。

下面的 C++ 示例代码展示了如何使用可覆盖的方法创建带有 CSS 文件链接的自定义 HTML 文档：
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


## **在将演示文稿转换为 HTML 时链接全部字体**
如果您不希望嵌入字体（以避免增大生成的 HTML 大小），可以实现自定义的 `LinkAllFontsHtmlController` 来链接全部字体。

下面的 C++ 代码演示了在转换为 HTML 时链接全部字体，并排除 “Calibri” 与 “Arial”（因为系统已存在这两种字体）：
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
下面的 C++ 代码演示了如何将 PowerPoint 演示文稿转换为响应式 HTML：
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```



## **将媒体文件导出为 HTML**
使用 Aspose.Slides for C++，您可以按以下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。  
2. 获取幻灯片的引用。  
3. 向幻灯片添加视频。  
4. 将演示文稿写入 HTML 文件。

下面的 C++ 代码展示了如何向演示文稿添加视频并保存为 HTML：
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


## **常见问题解答**

**Aspose.Slides 在将多个演示文稿批量转换为 HTML 时的性能如何？**

性能取决于演示文稿的大小和复杂度。Aspose.Slides 在批量操作时具有高效且可伸缩的特性。为了在转换大量演示文稿时获得最佳性能，建议尽可能使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**

是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。转换为 HTML 格式时，超链接会自动保留并保持可点击。

**在将演示文稿转换为 HTML 时，幻灯片数量是否有限制？**

使用 Aspose.Slides 时对幻灯片数量没有限制。您可以转换任意大小的演示文稿。但对于包含极大量幻灯片的演示文稿，性能可能会受服务器或系统可用资源的影响。