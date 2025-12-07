---
title: C++ で PowerPoint プレゼンテーションを HTML に変換
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
description: "C++ で PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。Aspose.Slides の変換ガイドを使用して、レイアウト、リンク、画像を保持し、迅速かつ完璧な結果を実現します。"
---

## **概要**

このドキュメントでは、C++ を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックをカバーしています。

- [PowerPoint を C++ で HTML に変換](#convert-powerpoint-to-html)
- [PPT を C++ で HTML に変換](#convert-powerpoint-to-html)
- [PPTX を C++ で HTML に変換](#convert-powerpoint-to-html)
- [ODP を C++ で HTML に変換](#convert-powerpoint-to-html)
- [PowerPoint スライドを C++ で HTML に変換](#convert-slide-to-html)

## **C++ で PowerPoint を HTML に変換**

C++ のサンプルコードで PowerPoint を HTML に変換する方法については、以下のセクション [PowerPoint を HTML に変換](#convert-powerpoint-to-html) を参照してください。コードは PPT、PPTX、ODP などのさまざまな形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPoint を HTML に変換することについて**

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX から HTML** または **PPT から HTML**。

**Aspose.Slides** は、PowerPoint を HTML に変換するプロセスを定義する多数のオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) クラス）を提供します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* スピーカーノートを含むまたは除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* コメントを含むまたは除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* 元のフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換します。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換します。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました： [PPT を HTML に変換](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX を HTML に変換](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP を HTML に変換](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の [無料コンバータ](https://products.aspose.app/slides/conversion) も確認してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**

Aspose.Slides を使用すると、次の手順で PowerPoint プレゼンテーション全体を HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
- _Presentation_ クラスで **.ppt** をロードして **C++ で PPT を HTML に変換**
- _Presentation_ クラスで **.pptx** をロードして **C++ で PPTX を HTML に変換**
- _Presentation_ クラスで **.odp** をロードして **C++ で ODP を HTML に変換**
3. [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

このコードは、PowerPoint を HTML に変換する方法を示します：
```cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Saving the presentation to HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **PowerPoint をレスポンシブ HTML に変換**

Aspose.Slides は、レスポンシブ HTML ファイルを生成できる [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) クラスを提供しています。このコードは、C++ で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示します：
```cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// プレゼンテーションを HTML に保存
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **PowerPoint をノート付き HTML に変換**

このコードは、C++ でノート付きの PowerPoint を HTML に変換する方法を示します：
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// ノートページを保存
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **PowerPoint をオリジナルフォント付き HTML に変換**

Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスを提供しています。

特定のフォントが埋め込まれないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) のパラメータ化コンストラクタにフォント名の配列を渡すことができます。Calibri や Arial のような一般的なフォントは、ほとんどのシステムに既に存在するため、プレゼンテーションで使用しても埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML 文書のサイズが不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスは継承をサポートし、上書き対象となる [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) メソッドを提供します。 
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

既定では、PowerPoint を HTML に変換すると、Aspose.Slides は 72 DPI の画像と切り取られた領域が削除された小さな HTML を出力します。より高品質な画像を含む HTML ファイルを取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（つまり `PicturesCompression::Dpi96`）以上の値に設定する必要があります。[values](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8)。

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


C++ のこのコードは、150 DPI（`PicturesCompression::Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示します：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **スライドを HTML に変換**

PowerPoint の特定のスライドを HTML に変換するには、全体のプレゼンテーションを HTML に変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) メソッドで HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) クラスを使用して追加の変換オプションを指定できます：

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


## **HTML にエクスポートするときに CSS と画像を保存**

新しい CSS スタイル ファイルを使用すると、PowerPoint を HTML に変換した結果の HTML ファイルのスタイルを簡単に変更できます。

この例の C++ コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示します：

```cpp
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

フォントを埋め込みたくない（結果の HTML のサイズ増加を防ぐ）場合は、独自の `LinkAllFontsHtmlController` を実装してすべてのフォントをリンクすることができます。

この C++ コードは、すべてのフォントをリンクし、システムに既に存在する「Calibri」および「Arial」を除外して PowerPoint を HTML に変換する方法を示します：

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

この C++ コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示します：

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **メディアファイルを HTML にエクスポート**

Aspose.Slides for C++ を使用すると、次の手順でメディアファイルをエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドに動画を追加します。
4. プレゼンテーションを書き出して HTML ファイルにします。

この C++ コードは、プレゼンテーションに動画を追加し、HTML として保存する方法を示します：

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

// HTML オプションを設定
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Saves the file
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **よくある質問**

**複数のプレゼンテーションを HTML に変換する際の Aspose.Slides のパフォーマンスは？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理において非常に効率的かつスケーラブルです。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドや並列処理を使用することを推奨します。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**

はい、Aspose.Slides は埋め込みハイパーリンクの HTML へのエクスポートを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**

スライド数に制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、非常に多数のスライドを含む場合は、サーバーやシステムのリソースに依存してパフォーマンスが変わる可能性があります。