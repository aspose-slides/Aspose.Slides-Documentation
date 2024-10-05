---
title: C++でPowerPointをHTMLに変換する
linktitle: PowerPointをHTMLに変換
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-html/
keywords: "C++ PowerPoint to HTML, PowerPointプレゼンテーションを変換, PPTX, PPT, PPTをHTMLに, PPTXをHTMLに, PowerPointをHTMLに, PowerPointをHTMLとして保存, PPTをHTMLとして保存, PPTXをHTMLとして保存, C++, CPP, Aspose.Slides, HTMLエクスポート"
description: "C++でPowerPointをHTMLに変換します。C++でPPTXまたはPPTをHTMLとして保存します。C++でスライドをHTMLとして保存します。"
---

## **概要**

この記事では、C++を使用してPowerPointプレゼンテーションをHTML形式に変換する方法を説明します。以下のトピックをカバーしています。

- [C++でPowerPointをHTMLに変換](#convert-powerpoint-to-html)
- [C++でPPTをHTMLに変換](#convert-powerpoint-to-html)
- [C++でPPTXをHTMLに変換](#convert-powerpoint-to-html)
- [C++でODPをHTMLに変換](#convert-powerpoint-to-html)
- [C++でPowerPointスライドをHTMLに変換](#convert-slide-to-html)

## **C++ PowerPointをHTMLに変換**

PowerPointをHTMLに変換するためのC++のサンプルコードについては、下記のセクション、つまり[C++でPowerPointをHTMLに変換](#convert-powerpoint-to-html)を参照してください。コードは、PPT、PPTX、ODPなどのさまざまな形式のプレゼンテーションオブジェクトをロードし、HTML形式で保存できます。

## **PowerPointからHTMLへの変換について**
[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)を使用すると、アプリケーションや開発者はPowerPointプレゼンテーションをHTMLに変換できます：**PPTXをHTMLに**または**PPTをHTMLに**。

**Aspose.Slides**は、PowerPointからHTMLへの変換プロセスを定義する多くのオプション（主に[**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)クラスから）を提供します：

* PowerPointプレゼンテーション全体をHTMLに変換します。
* PowerPointプレゼンテーション内の特定のスライドをHTMLに変換します。
* プレゼンテーションメディア（画像、動画など）をHTMLに変換します。
* PowerPointプレゼンテーションをレスポンシブHTMLに変換します。
* 発表者のノートを含めたり除外したりして、PowerPointプレゼンテーションをHTMLに変換します。
* コメントを含めたり除外したりして、PowerPointプレゼンテーションをHTMLに変換します。
* 元のフォントまたは埋め込みフォントを使用してPowerPointプレゼンテーションをHTMLに変換します。
* 新しいCSSスタイルを使用してPowerPointプレゼンテーションをHTMLに変換します。

{{% alert color="primary" %}} 

独自のAPIを使用して、Asposeは無料の[プレゼンテーションをHTMLに](https://products.aspose.app/slides/conversion/powerpoint-to-html)変換ツールを開発しました：[PPTをHTMLに](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTXをHTMLに](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODPをHTMLに](https://products.aspose.app/slides/conversion/odp-to-html)など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の[無料のAspose変換ツール](https://products.aspose.app/slides/conversion)も確認してみてください。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

ここで説明されている変換プロセスの他に、Aspose.SlidesはHTML形式を使用したこれらの変換操作もサポートしています：

* [HTMLから画像へ](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTMLからJPGへ](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTMLからXMLへ](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTMLからTIFFへ](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPointをHTMLに変換する**
Aspose.Slidesを使用することで、次の手順でPowerPointプレゼンテーション全体をHTMLに変換できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
   * **.ppt**を_Presentation_クラスにロードして**C++でPPTをHTMLに変換**
   * **.pptx**を_Presentation_クラスにロードして**C++でPPTXをHTMLに変換**
   * **.odp**を_Presentation_クラスにロードして**C++でODPをHTMLに変換**
3. [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020)メソッドを使用してオブジェクトをHTMLファイルとして保存します。

このコードは、C++でPowerPointをHTMLに変換する方法を示しています：

```cpp
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// プレゼンテーションをHTMLとして保存
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```

## **PowerPointをレスポンシブHTMLに変換する**
Aspose.Slidesは、レスポンシブHTMLファイルを生成するための[ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller)クラスを提供しています。このコードは、C++でPowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```cpp
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// プレゼンテーションをHTMLとして保存
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```

## **ノート付きのPowerPointをHTMLに変換する**
このコードは、C++でノート付きのPowerPointをHTMLに変換する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// ノートページを保存
pres->Save(u"Output.html", SaveFormat::Html, opt);
```

## **元のフォント付きでPowerPointをHTMLに変換する**
Aspose.Slidesは、プレゼンテーションをHTMLに変換する際にすべてのフォントを埋め込むことができる[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller)クラスを提供しています。

特定のフォントが埋め込まれないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller)クラスのパラメータ化コンストラクタにフォント名の配列を渡すことができます。プレゼンテーションで使用される人気のフォント、例えばCalibriやArialは、ほとんどのシステムに既に含まれているため、埋め込む必要はありません。これらのフォントが埋め込まれると、結果として得られるHTMLドキュメントが不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller)クラスは継承をサポートし、上書きされることを意図した[WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77)メソッドを提供します。

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// デフォルトのプレゼンテーションフォントを除外
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```

## **高品質画像でPowerPointをHTMLに変換する**
デフォルトでは、PowerPointをHTMLに変換する際、Aspose.Slidesは72 DPIの小さなHTMLと切り取られた領域を削除した画像を出力します。高品質の画像を持つHTMLファイルを得るには、`HtmlOptions`クラスの`PicturesCompression`プロパティを96（つまり、`PicturesCompression::Dpi96`）以上の値に設定する必要があります[値](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8)。

このC++コードは、150 DPI（つまり、`PicturesCompression::Dpi150`）で高品質画像を取得しながらPowerPointプレゼンテーションをHTMLに変換する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```

このC++コードは、フルクオリティ画像でHTMLを出力する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```

## **スライドをHTMLに変換する**
PowerPointの特定のスライドをHTMLに変換するには、全体のプレゼンテーションをHTMLに変換する際に使用するのと同じ[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスをインスタンス化し、[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020)メソッドを使用してファイルをHTMLとして保存する必要があります。[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)クラスを使用して追加の変換オプションを指定できます：

このC++コードは、PowerPointのプレゼンテーション内のスライドをHTMLに変換する方法を示しています：

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

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>());
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

## **HTMLにエクスポートする際にCSSと画像を保存**
新しいCSSスタイルファイルを使用することで、PowerPointをHTMLに変換するプロセスから得られるHTMLファイルのスタイルを簡単に変更できます。

この例のC++コードは、オーバーライド可能なメソッドを使用してCSSファイルへのリンクを持つカスタムHTMLドキュメントを作成する方法を示しています：

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
        generator->AddHtml(u"<!-- 埋め込まれたフォント -->");
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
    // ドキュメントディレクトリへのパス
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```

## **プレゼンテーションをHTMLに変換する際にすべてのフォントをリンクする**
フォントを埋め込まない（結果として得られるHTMLのサイズを増加させない）場合、独自の`LinkAllFontsHtmlController`バージョンを実装することで、すべてのフォントをリンクできます。

このC++コードは、PowerPointをHTMLに変換する際にすべてのフォントをリンクし、「Calibri」と「Arial」を除外する方法を示しています（これらはすでにシステムに存在するため）：

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
        String path = String::Format(u"{0}.woff", fontName); // 一部のパスの正規化が必要な場合があります
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

## **PowerPointをレスポンシブHTMLに変換する**
このC++コードは、PowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **メディアファイルをHTMLにエクスポートする**
Aspose.Slides for C++を使用して、次の方法でメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドに動画を追加します。
1. プレゼンテーションをHTMLファイルとして書き出します。

このC++コードは、プレゼンテーションに動画を追加し、HTMLとして保存する方法を示しています：

```cpp
 // プレゼンテーションをロード
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// HTMLオプションを設定
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// ファイルを保存
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```