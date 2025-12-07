---
title: C++でPowerPointプレゼンテーションをHTMLに変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/cpp/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- C++
- Aspose.Slides
description: "C++でPowerPointプレゼンテーションをレスポンシブHTMLに変換します。レイアウト、リンク、画像を保持し、Aspose.Slidesの変換ガイドで高速かつ完璧な結果を得られます。"
---

## **概要**

この記事では、C++ を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法について説明します。以下のトピックを取り上げます。

- [PowerPoint を HTML に変換（C++）](#convert-powerpoint-to-html)
- [PPT を HTML に変換（C++）](#convert-powerpoint-to-html)
- [PPTX を HTML に変換（C++）](#convert-powerpoint-to-html)
- [ODP を HTML に変換（C++）](#convert-powerpoint-to-html)
- [PowerPoint スライドを HTML に変換（C++）](#convert-slide-to-html)

## **PowerPoint を HTML に変換（C++）**

C++ のサンプルコードで PowerPoint を HTML に変換する方法については、以下のセクション、すなわち [PowerPoint を HTML に変換](#convert-powerpoint-to-html)をご覧ください。コードは PPT、PPTX、ODP などの形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPoint を HTML に変換するについて**

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX から HTML** または **PPT から HTML**。

**Aspose.Slides** は、PowerPoint を HTML に変換するプロセスを定義する多数のオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) クラス）を提供します。

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーション内の特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* PowerPoint プレゼンテーションを、スピーカーノートを含める・除外する形で HTML に変換します。
* PowerPoint プレゼンテーションを、コメントを含める・除外する形で HTML に変換します。
* PowerPoint プレゼンテーションを、元のフォントまたは埋め込みフォントで HTML に変換します。
* PowerPoint プレゼンテーションを、新しい CSS スタイルを使用して HTML に変換します。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の [無料コンバータ](https://products.aspose.app/slides/conversion) もぜひご確認ください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関連する以下の変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション全体を次のように HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
   * Load **.ppt** in _Presentation_ class to **C++ で PPT を HTML に変換**
   * Load **.pptx** in _Presentation_ class to **C++ で PPTX を HTML に変換**
   * Load **.odp** in _Presentation_ class to **C++ で ODP を HTML に変換**
3. [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) メソッドを使用して、オブジェクトを HTML ファイルとして保存します。

```cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// プレゼンテーションを HTML に保存
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **PowerPoint をレスポンシブ HTML に変換**

Aspose.Slides は、レスポンシブ HTML ファイルを生成できる [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) クラスを提供します。このコードは、C++ で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：

```cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// プレゼンテーションを HTML に保存
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **PowerPoint をノート付き HTML に変換**

このコードは、C++ でノート付きの PowerPoint を HTML に変換する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// ノートページを保存
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **PowerPoint を元のフォント付き HTML に変換**

Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスを提供します。

特定のフォントの埋め込みを防止するには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスのパラメータ化されたコンストラクタにフォント名の配列を渡します。Calibri や Arial のような一般的なフォントは、プレゼンテーションで使用されても、ほとんどのシステムに既に存在するため埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML ドキュメントが不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) メソッドを提供します。このメソッドはオーバーライドすることを想定しています。

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// exclude default presentation fonts
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **PowerPoint を高品質画像付き HTML に変換**

既定では、PowerPoint を HTML に変換すると、Aspose.Slides は 72 DPI の画像と切り取られた領域が削除された小さな HTML を出力します。より高品質な画像を持つ HTML ファイルを取得するには、`PicturesCompression` プロパティ（`HtmlOptions` クラス）を 96（すなわち `PicturesCompression::Dpi96`）以上の [値](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8) に設定する必要があります。

この C++ コードは、150 DPI（`PicturesCompression::Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


この C++ コードは、フル品質の画像を使用した HTML を出力する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **スライドを HTML に変換**

PowerPoint の特定のスライドを HTML に変換するには、全体のプレゼンテーションを HTML に変換する際に使用するのと同じ [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) メソッドでファイルを HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) クラスを使用して、追加の変換オプションを指定できます：

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


## **HTML にエクスポートする際に CSS と画像を保存**

新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML ファイルのスタイルを簡単に変更できます。

この例の C++ コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています：

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
    // ドキュメント ディレクトリへのパス。
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**

フォントを埋め込みたくない（結果の HTML のサイズ増加を防ぐ）場合は、独自の `LinkAllFontsHtmlController` を実装してすべてのフォントをリンクできます。

この C++コードは、すべてのフォントをリンクし、システムに既に存在するため "Calibri" と "Arial" を除外して PowerPoint を HTML に変換する方法を示しています：

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

この C++コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **メディアファイルを HTML にエクスポート**

Aspose.Slides for C++ を使用すると、次の手順でメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにビデオを追加します。
1. プレゼンテーションを書き出して HTML ファイルにします。

```cpp
 // プレゼンテーションを読み込みます
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


## **よくある質問**

**複数のプレゼンテーションを HTML に変換する際の Aspose.Slides のパフォーマンスはどの程度ですか？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理において非常に効率的かつスケーラブルです。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドや並列処理を使用することが最適なパフォーマンスを得るために推奨されます。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**

はい、Aspose.Slides は埋め込みハイパーリンクを HTML にエクスポートすることを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**

Aspose.Slides を使用する場合、スライド数に制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、スライド数が非常に多いプレゼンテーションの場合、パフォーマンスはサーバーやシステムの利用可能なリソースに依存することがあります。