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
description: "在 C++ 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for C++ 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本转换只需加载一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 并使用 `Save` 调用并指定 [SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/)。需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/)。

本指南侧重于实用的 HTML 导出场景：

- 导出完整演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和批注。
- 控制图像质量和裁剪的图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入和引用方式。

默认情况下，HTML 导出会生成一个自包含的 HTML 文档，其中大多数资源都是嵌入的。这对于共享单个文件很方便，但会增加输出大小。对于网络发布，建议使用外部资源、降低图像 DPI，并仅嵌入在目标环境中不可靠的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 加载它，并使用 `SaveFormat::Html` 保存。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

此示例写入一个 HTML 文件。调用 `Dispose` 在导出后释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `SlidesLayoutOptions`：添加备注、批注、讲义或其他布局信息。
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `SlideImageFormat`：改变幻灯片的表示方式，例如作为 SVG。
- `PicturesCompression`：控制图像 DPI 和输出大小。
- `DeletePicturesCroppedAreas`：保留或删除裁剪的图像数据。
- `SvgResponsiveLayout`：使导出的 SVG 内容适配其容器。
- `ShowHiddenSlides`：在需要时包含隐藏的幻灯片。

以下章节分别展示最常用的选项，以便您仅组合工作流需要的选项。

## **将选定的幻灯片转换为 HTML**

`Presentation::Save` 的重载接受幻灯片编号，使用基于 1 的幻灯片位置。下面的循环将每个幻灯片保存为单独的 HTML 文件。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

当网站或应用程序需要每张幻灯片对应一个 HTML 页面时使用此模式。如果每张幻灯片应具有相同的布局，请创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 实例并将其传递给每个 `Save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmlformatter/) 提供响应式 HTML 输出。当导出的页面需要更好地适配浏览器宽度时使用它。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

对于基于 SVG 的响应式布局，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 上设置 `SvgResponsiveLayout`。当幻灯片内容以可伸缩的 SVG 标记导出时，这很有用。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **包含演讲者备注和批注**

通过 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notescommentslayoutingoptions/) 来包含演讲者备注或批注。默认情况下，备注和批注是隐藏的，除非您选择它们的位置。

假设源演示文稿包含演讲者备注：

![PowerPoint 中带有演讲者备注的幻灯片](slide_with_notes.png)

以下代码将在幻灯片下方导出带有演讲者备注的幻灯片内容。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

导出的 HTML 包含备注区域：

![带有幻灯片和演讲者备注的 HTML 输出](HTML_with_notes.png)

要导出批注，请设置 `CommentsPosition`，例如设为 `CommentsPositions::Right` 或 `CommentsPositions::Bottom`。如果只需要批注，省略 `NotesPosition`。如果需要同时包含备注和批注，请同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减少输出大小。当需要更高的图像质量时，将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/picturescompression/) 中的值。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

默认情况下，图像的裁剪区域可能会从导出结果中移除。仅在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留它会增加 HTML 大小。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **添加 CSS**

对于简单的样式设置，可将 CSS 字符串传递给 `HtmlFormatter::CreateDocumentFormatter`。这会更改外围 HTML 文档，而 Aspose.Slides 继续渲染幻灯片内容。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

如需自定义文档头部、链接的 CSS 文件或围绕幻灯片和形状的自定义标记，请实现 [IHtmlFormattingController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ihtmlformattingcontroller/) 并使用 `CreateCustomFormatter` 将其传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmlformatter/)。

## **嵌入字体**

如果目标环境可能没有安装演示文稿所使用的字体，请使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/embedallfontshtmlcontroller/) 将字体嵌入 HTML。嵌入可提高视觉保真度，但会增加输出大小。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

仅在确信目标浏览器或系统已提供这些字体时才排除嵌入。对于品牌字体或不常用的字体，嵌入通常更安全。

## **链接字体文件而不是嵌入它们**

为减少 HTML 文件大小，您可以将字体数据写入单独的 WOFF 文件，并在 HTML 中添加 `@font-face` 规则。以下辅助类扩展了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/embedallfontshtmlcontroller/) 并覆盖 `WriteFont`。

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

在此示例中，字体文件保存到 `html-output/fonts`，HTML 使用诸如 `fonts/BrandFont-normal-400.woff` 的 URL 引用它们。如果 HTML 文件和字体部署到其他位置，请选择 `fontUrlPrefix` 使其匹配部署后的 URL 路径。

## **外部保存资源**

自包含的 HTML 易于迁移，但嵌入的 Base64 资源会使文件变大。如果您的应用程序需要外部图像文件，请实现 [ILinkEmbedController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/) 并将其传递给 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 构造函数。

外部化资源时，请有意识地选择两个路径：

- 文件系统输出路径，您的应用程序在此写入生成的图像、字体、音频或视频。
- URL 路径，浏览器从 HTML 文档加载这些文件时使用的路径。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受以下参数：

- `path`：生成的媒体文件将写入的目录。
- `fileName`：正在生成的 HTML 文件名。
- `baseUri`：在 HTML 链接到媒体文件时使用的绝对 URI 前缀。

如果 HTML 文件为 `html-output/presentation.html`，媒体文件保存在 `html-output/media`，则 `path` 应指向磁盘上的媒体目录，而 `baseUri` 应指向浏览器视角下的相同目录。对于本地预览，您可以从媒体目录构建 `file:///` URI。对于已部署的应用程序，请使用已发布媒体目录的绝对 URL。

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

为每个导出任务使用唯一的输出目录，尤其是在服务器应用程序中。共享输出路径可能导致不同转换的文件相互覆盖。

## **性能与资源管理**

HTML 转换是一项渲染操作，处理时间和内存使用取决于幻灯片数量、图像分辨率、字体、效果、图表和嵌入的媒体。更高的 `PicturesCompression` DPI 值、嵌入的字体、SVG 输出以及保留的裁剪图像区域可以提升保真度，但通常会增加输出大小。

批量转换时：

- 及时释放每个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例。
- 为不同的任务使用独立的输出目录。
- 除非保真度要求，否则避免嵌入常用字体。
- 当 HTML 用于预览或缩略图时，降低图像 DPI。
- 在部署路径确定之前，保持源演示文稿、生成的 HTML 和外部资源放在一起。

## **FAQ**

**HTML 输出中会保留超链接吗？**

是的。演示文稿中的超链接会导出到 HTML，并在目标 URL 有效时保持可点击。

**我可以并行将演示文稿转换为 HTML 吗？**

可以，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例。请使用独立的演示实例、独立的流和独立的输出目录来处理不同的文件。详情请参见 [multithreading guidance](/slides/zh/cpp/multithreading/)。

**Presentation 对象是线程安全的吗？**

不是。单个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例应在同一线程上加载、修改、保存并释放。对于并行工作，请为每个线程或进程创建独立的实例。

**生成的 HTML 文件为何很大？**

默认导出会将资源直接嵌入 HTML。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域也会增加大小。当输出体积比最高保真度更重要时，请使用外部资源、排除常用字体的嵌入，并降低 `PicturesCompression`。

**在媒体导出时应如何选择 baseUri？**

请从浏览器的视角选择 `baseUri`，并将其作为绝对 URI 传递。对于本地预览，可以使用 `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` 从输出目录生成。对于部署，请使用已发布媒体目录的绝对 URL。文件系统的 `path` 与浏览器的 `baseUri` 不必是相同的字符串，但必须指向同一资源位置。

**我可以包含隐藏的幻灯片吗？**

可以。当必须导出隐藏幻灯片时，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 上将 `ShowHiddenSlides` 设置为 `true`。