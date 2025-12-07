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
description: "C++ で PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで高速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、C++ を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [C++ で PowerPoint を HTML に変換](#convert-powerpoint-to-html)
- [C++ で PPT を HTML に変換](#convert-powerpoint-to-html)
- [C++ で PPTX を HTML に変換](#convert-powerpoint-to-html)
- [C++ で ODP を HTML に変換](#convert-powerpoint-to-html)
- [C++ で PowerPoint スライドを HTML に変換](#convert-slide-to-html)

## **C++ で PowerPoint を HTML に変換**

C++ のサンプルコードで PowerPoint を HTML に変換する方法は、以下のセクション「[C++ で PowerPoint を HTML に変換](#convert-powerpoint-to-html)」をご参照ください。このコードは PPT、PPTX、ODP などの形式を Presentation オブジェクトで読み込み、HTML 形式で保存します。

## **PowerPoint を HTML に変換する概要**
[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX から HTML** または **PPT から HTML**。

**Aspose.Slides** は、主に [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) クラスから提供される多数のオプションを通じて、PowerPoint から HTML への変換プロセスを定義します。

* PowerPoint プレゼンテーション全体を HTML に変換
* 特定のスライドだけを HTML に変換
* プレゼンテーションのメディア（画像、動画など）を HTML に変換
* レスポンシブ HTML に変換
* スピーカーノートを含める／除外した HTML に変換
* コメントを含める／除外した HTML に変換
* オリジナルフォントまたは埋め込みフォントで HTML に変換
* 新しい CSS スタイルを使用した HTML に変換

{{% alert color="primary" %}} 

独自の API を利用して、Aspose は無料の [プレゼンテーションから HTML へのコンバータ](https://products.aspose.app/slides/conversion/powerpoint-to-html) を提供しています： [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP から HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の無料コンバータについては、[Aspose の無料コンバータ一覧](https://products.aspose.app/slides/conversion) をご覧ください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

本記事で説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関する以下の変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **C++ で PowerPoint を HTML に変換**
Aspose.Slides を使用すると、次の手順で PowerPoint プレゼンテーション全体を HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
   * **.ppt** を _Presentation_ クラスで読み込み、**C++ で PPT を HTML に変換**  
   * **.pptx** を _Presentation_ クラスで読み込み、**C++ で PPTX を HTML に変換**  
   * **.odp** を _Presentation_ クラスで読み込み、**C++ で ODP を HTML に変換**  
3. [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

以下のコードは、C++ で PowerPoint を HTML に変換する方法を示しています：
```cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// プレゼンテーションを HTML に保存します
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **C++ でレスポンシブ HTML に変換**
Aspose.Slides は [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) クラスを提供し、レスポンシブ HTML ファイルの生成を可能にします。以下のコードは、C++ でプレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// プレゼンテーションを HTML に保存します
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **ノート付きで PowerPoint を HTML に変換**
以下のコードは、C++ でノートを含む PowerPoint を HTML に変換する方法を示しています：
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saving notes pages
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **オリジナルフォント付きで PowerPoint を HTML に変換**
Aspose.Slides は [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスを提供し、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができます。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) のパラメータ化コンストラクタにフォント名の配列を渡します。たとえば Calibri や Arial など、システムに標準搭載されているフォントは埋め込む必要がありません。これらのフォントを埋め込むと、HTML ドキュメントが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) クラスは継承可能で、[WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77) メソッドをオーバーライドして使用できます。 
```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// デフォルトのプレゼンテーションフォントを除外
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```


## **高品質画像付きで PowerPoint を HTML に変換**
デフォルトでは、PowerPoint を HTML に変換すると Aspose.Slides は 72 DPI の小さな画像と切り取られた領域を削除した HTML を出力します。高品質画像を含む HTML を取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（例：`PicturesCompression::Dpi96`）以上の値に設定する必要があります。詳しい値は [こちら](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8) を参照してください。

以下の C++ コードは、150 DPI（`PicturesCompression::Dpi150`）の高品質画像を含む HTML に変換する方法を示しています：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


以下のコードは、フル品質画像を含む HTML を出力する方法を示しています：
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **スライドを HTML に変換**
PowerPoint の特定のスライドを HTML に変換するには、全体のプレゼンテーションを変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) メソッドで HTML として保存します。追加の変換オプションは [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) クラスで指定できます。

以下の C++ コードは、PowerPoint プレゼンテーションのスライドを HTML に変換する方法を示しています：
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
新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換で生成される HTML のスタイルを簡単に変更できます。

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
フォントを埋め込まず（結果の HTML のサイズ増加を防ぐため）にすべてのフォントをリンクしたい場合は、独自の `LinkAllFontsHtmlController` 実装を作成します。

以下の C++ コードは、すべてのフォントをリンクしつつ「Calibri」と「Arial」（システムに既に存在するため）を除外して PowerPoint を HTML に変換する方法を示しています：
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


## **レスポンシブ HTML に変換**
この C++ コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **メディア ファイルを HTML にエクスポート**
Aspose.Slides for C++ を使用すると、次の手順でメディア ファイルをエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. スライドへの参照を取得します。  
3. スライドに動画を追加します。  
4. プレゼンテーションを書き出して HTML ファイルにします。

以下の C++ コードは、プレゼンテーションに動画を追加し、HTML として保存する方法を示しています：
```cpp
 // プレゼンテーションを読み込む
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

// ファイルを保存
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **FAQ**

**複数のプレゼンテーションを HTML に変換する際の Aspose.Slides のパフォーマンスはどうですか？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理に対して高い効率性とスケーラビリティを備えています。多数のプレゼンテーションを変換する場合は、可能な限りマルチスレッドまたは並列処理を使用することを推奨します。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**

はい、Aspose.Slides は埋め込みハイパーリンクの HTML へのエクスポートを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**

Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、スライド数が非常に多い場合は、サーバーまたはシステムの利用可能なリソースに応じてパフォーマンスが左右されることがあります。