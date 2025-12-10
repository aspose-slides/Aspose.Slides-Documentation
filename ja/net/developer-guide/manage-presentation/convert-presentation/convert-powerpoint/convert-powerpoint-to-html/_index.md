---
title: PowerPoint プレゼンテーションを .NET で HTML に変換する
linktitle: PowerPoint から HTML へ
type: docs
weight: 30
url: /ja/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: ".NET で PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで高速かつ完璧な結果を実現します。"
---

## **概要**

Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを HTML に変換し、ワークフローを強化します。このガイドでは、詳細な手順、堅牢なコード例、テスト済みの手法を提供し、Web 表示に最適化された信頼性と効率性の高い変換プロセスを保証します。

Aspose.Slides は多数のオプションを提供します—主に [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) クラスから取得でき、PowerPoint（または OpenDocument）形式から HTML への変換プロセスを定義します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* スピーカーノートを含めるまたは除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* コメントを含めるまたは除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* 元のフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換します。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換します。

## **プレゼンテーションを HTML に変換する**

**Aspose.Slides** を使用すると、PowerPoint または OpenDocument のプレゼンテーション全体を以下の手順で HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

```c#
// プレゼンテーション ファイル (例: PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // プレゼンテーションを HTML として保存します。
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **プレゼンテーションをレスポンシブ HTML に変換する**

**Aspose.Slides** はレスポンシブ HTML ファイルを生成できる [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) クラスを提供します。このコードは C# で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：

```c#
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // プレゼンテーションを HTML として保存します。
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **スピーカーノート付きでプレゼンテーションを HTML に変換する**

PowerPoint または OpenDocument のプレゼンテーションをスピーカーノート付きで HTML に変換する際は、元のドキュメントの全体的な内容を正確に捉えることが重要です。このプロセスにより、スライドの視覚要素が正確に再現されるだけでなく、添付されたスピーカーノートも保持され、コンテンツに追加の文脈と洞察が加わります。

次のようなスライドを含む PowerPoint プレゼンテーションがあるとします：

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

このコードは C# で PowerPoint プレゼンテーションをスピーカーノート付きで HTML に変換する方法を示しています：

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // スピーカーノートのオプションを設定します。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 出力 HTML ドキュメントのオプションを設定します。
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // スピーカーノート付きでプレゼンテーションを HTML として保存します。
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


結果は以下の通りです：

![スライドとスピーカーノートを含む HTML ドキュメント](HTML_with_notes.png)

## **元のフォントでプレゼンテーションを HTML に変換する**

Aspose.Slides はプレゼンテーションを HTML に変換する際に、すべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) クラスを提供します。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) クラスのパラメータ付きコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial などの一般的なフォントは、ほとんどのシステムにすでにインストールされているため、埋め込む必要はありません。埋め込むと、生成される HTML ドキュメントのサイズが不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) クラスは継承をサポートし、オーバーライド対象となる [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) メソッドを提供します。

```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // デフォルトのプレゼンテーションフォントを除外します。
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **高品質画像でプレゼンテーションを HTML に変換する**

既定では、PowerPoint プレゼンテーションを HTML に変換すると、Aspose.Slides は 72 DPI の画像で小さな HTML ファイルを出力し、切り取られた領域を削除します。より高品質な画像を含む HTML ファイルを取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（すなわち `PicturesCompression.Dpi96`）またはそれ以上の値に設定する必要があります。詳細は [this reference](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression) に記載されています。

この C# コードは、150 DPI（`PicturesCompression.Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています：

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


この C# コードは、切り取られた領域を削除せずに PowerPoint プレゼンテーションを HTML に変換する方法を示しています：

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


## **プレゼンテーションスライドを HTML に変換する**

PowerPoint プレゼンテーションの特定のスライドを HTML に変換するには、全体のプレゼンテーションを HTML に変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) メソッドでファイルを HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) クラスを使用して追加の変換オプションを指定できます。

この C# コードは、PowerPoint プレゼンテーションのスピーカーノート付きスライドを HTML に変換する方法を示しています：

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

            // スライドを HTML ファイルに保存します。
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


## **HTML へエクスポートする際に CSS と画像を保存する**

新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換プロセスで生成された HTML ファイルの外観を簡単に変更できます。

この例の C#コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています：

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
    // カスタムヘッダーのテンプレート。
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


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンクする**

フォントを埋め込みたくない（結果の HTML のサイズ増加を防ぐ）場合は、独自の `LinkAllFontsHtmlController` を実装してすべてのフォントをリンクできます。

この C# コードは、すべてのフォントをリンクし、システムに既にインストールされているため除外する "Calibri" と "Arial" を除外しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // デフォルトのプレゼンテーションフォントを除外します。
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


この C# コードは、`LinkAllFontsHtmlController` の実装方法を示しています：

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
            string path = fontName + ".woff"; // パスのサニタイズが必要になる場合があります。

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


## **SVG 画像を含むプレゼンテーションをレスポンシブ HTML に変換する**

この C# コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：

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


## **メディアファイルを HTML にエクスポートする**

Aspose.Slides for .NET を使用して、以下の手順でメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドに動画を追加します。
4. プレゼンテーションを書き出して HTML ファイルにします。

この C# コードは、プレゼンテーションに動画を追加し、HTML として保存する方法を示しています：

```c#
// 新しいプレゼンテーションを作成します。
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

    // HTML オプションを設定します。
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // プレゼンテーションを HTML ファイルに保存します。
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 
Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました: [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html), など。

[![画像の代替テキスト](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータをご確認ください: [Aspose の無料コンバータ](https://products.aspose.app/slides/conversion).
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/net/conversion/html-to-tiff/)
{{% /alert %}}

## **よくある質問**

**Aspose.Slides が複数のプレゼンテーションを HTML に変換する際のパフォーマンスはどうですか？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ操作に対して高い効率性とスケーラビリティを備えています。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドや並列処理を使用することを推奨します。

**Aspose.Slides はハイパーリンクを HTML にエクスポートすることをサポートしていますか？**

はい、Aspose.Slides はハイパーリンクの埋め込みを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能な状態になります。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**

スライド数に制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、スライド数が非常に多い場合は、サーバーやシステムのリソースに応じてパフォーマンスが影響を受ける可能性があります。