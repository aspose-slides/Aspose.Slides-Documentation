---
title: C++でPowerPointプレゼンテーションをHTMLに変換
linktitle: PowerPointからHTMLへ
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-html/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからHTMLへ
- プレゼンテーションからHTMLへ
- スライドからHTMLへ
- PPTをHTMLに変換
- PPTXをHTMLに変換
- PowerPointをHTMLとして保存
- プレゼンテーションをHTMLとして保存
- スライドをHTMLとして保存
- PPTをHTMLとして保存
- PPTXをHTMLとして保存
- PPTをHTMLにエクスポート
- PPTXをHTMLにエクスポート
- C++
- Aspose.Slides
description: "C++でPowerPointプレゼンテーションをレスポンシブHTMLに変換します。レイアウト、リンク、画像を保持し、Aspose.Slidesの変換ガイドで高速かつ完璧な結果を実現します。"
---

## **PowerPoint to HTML 変換について**
Using [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), applications and developers can convert a PowerPoint presentation to HTML: **PPTX to HTML** or **PPT to HTML**. 

**Aspose.Slides** provides many options (mostly from the [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class) that define the PowerPoint to HTML conversion process:

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、ビデオなど）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* スピーカーノートの有無にかかわらず、PowerPoint プレゼンテーションを HTML に変換します。
* コメントの有無にかかわらず、PowerPoint プレゼンテーションを HTML に変換します。
* 元のフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換します。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換します。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [プレゼンテーションから HTML へのコンバータ](https://products.aspose.app/slides/conversion/powerpoint-to-html) を開発しました: [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html), など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータもぜひご覧ください。[Aspose の無料コンバータ](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています： 

* [HTML を画像に変換](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML を JPG に変換](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML を XML に変換](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML を TIFF に変換](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**
Using Aspose.Slides, you can convert an entire PowerPoint presentation to HTML this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
   * Load **.ppt** in _Presentation_ class to **Convert PPT to HTML in C++**
   * Load **.pptx** in _Presentation_ class to **Convert PPTX to HTML in C++**
   * Load **.odp** in _Presentation_ class to **Convert ODP to HTML in C++**
3. Use the [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) method to save the object as an HTML file.

```cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// プレゼンテーションを HTML に保存します
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **PowerPoint をレスポンシブ HTML に変換**
Aspose.Slides provides the [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) class that allows you to generate responsive HTML files. This code shows you how to convert a PowerPoint presentation to responsive HTML in C++:
```cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// プレゼンテーションを HTML に保存します
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **PowerPoint をノート付き HTML に変換**
This code shows you how to convert a PowerPoint to HTML with notes in C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// ノートページを保存
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **PowerPoint を元フォント付き HTML に変換**
Aspose.Slides provides the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/) class that allows you to embed all the fonts in a presentation while converting the presentation to HTML.

To prevent certain fonts from being embedded, you can pass an array of font names to a parameterized constructor from the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/) class. Popular fonts, such as Calibri or Arial, when used in a presentation, do not have to be embedded because most systems already contain such fonts. When those fonts are embedded, the resulting HTML document becomes unnecessarily large.

The [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/) class supports inheritance and provides the [WriteFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedallfontshtmlcontroller/writefont/) method, which is meant to be overwritten. 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// デフォルトのプレゼンテーションフォントを除外する
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **PowerPoint を高品質画像付き HTML に変換**
By default, when you convert PowerPoint to HTML, Aspose.Slides outputs small HTML with images at 72 DPI and deleted cropped areas. To obtain HTML files with higher quality images, you have to set the `PicturesCompression` property (from the `HtmlOptions` class) to 96 (i.e., `PicturesCompression::Dpi96`) or higher [values](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

This C++ code shows you how to convert a PowerPoint presentation to HTML while obtaining high quality images at 150 DPI (i.e. `PicturesCompression::Dpi150`):
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


This code in C++ shows you how to output HTML with full quality images:
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **スライドを HTML に変換**
To convert a specific slide in a PowerPoint to HTML, you have to instantiate the same [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class (used to convert entire presentations to HTML) and then use the [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) method to save the file as HTML. The [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) class can be used to specify additional conversion options:

This C++ code shows you how to convert a slide in a PowerPoint presentation to HTML:
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

    // ファイルを保存              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```


## **HTML エクスポート時に CSS と画像を保存**
Using new CSS style files, you can easily change the style of the HTML file resulting from the PowerPoint to HTML conversion process. 

The C++ code in this example shows you how to use overridable methods to create a custom HTML document with a link to a CSS file:
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
    // ドキュメントディレクトリへのパス。
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**
If you do not want to embed fonts (to avoid increasing the size of the resulting HTML), you can link all fonts by implementing your own `LinkAllFontsHtmlController` version. 

This C++ code shows you how to convert a PowerPoint to HTML while linking all fonts and excluding "Calibri" and "Arial" (since they already exist in the system): 
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
        String path = String::Format(u"{0}.woff", fontName); // パスのサニタイズが必要になる場合があります
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

    // デフォルトのプレゼンテーションフォントを除外
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```


## **PowerPoint をレスポンシブ HTML に変換**
This C++ code shows you how to convert a PowerPoint presentation to responsive HTML:
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **メディアファイルを HTML にエクスポート**
Using Aspose.Slides for C++, you can export media files this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Get a reference to the slide.
1. Add a video to the slide.
1. Write the presentation as a HTML file.

This C++ code shows you how to add a video to the presentation and then save it as HTML: 
```cpp
 // プレゼンテーションをロードします
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// HTML オプションを設定します
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// ファイルを保存します
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **FAQ**

**What is the performance of Aspose.Slides when converting multiple presentations to HTML?**

Performance depends on the size and complexity of presentations. Aspose.Slides is highly efficient and scalable for batch operations. To achieve optimal performance when converting many presentations, it’s recommended to use multithreading or parallel processing whenever possible.

**Does Aspose.Slides support exporting hyperlinks to HTML?**

Yes, Aspose.Slides fully supports exporting embedded hyperlinks to HTML. When you convert presentations to HTML format, hyperlinks are preserved automatically and remain clickable.

**Is there any limit on the number of slides when converting presentations to HTML?**

There is no limit on the number of slides when using Aspose.Slides. You can convert presentations of any size. However, for presentations containing a very large number of slides, performance may depend on the available resources of your server or system.