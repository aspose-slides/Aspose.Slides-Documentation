---
title: C# で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/net/convert-powerpoint-to-html/
keywords:
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- PowerPoint プレゼンテーションを変換
- PowerPoint 変換
- プレゼンテーション変換
- HTML 変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- HTML エクスポート
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションを HTML に変換する方法を学びます。このガイドでは、スライドをウェブフレンドリーな形式に変換するための手順、コードサンプル、ベストプラクティスを提供します。"
---

## **概要**

Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションを HTML に変換することで、ワークフローを向上させます。このガイドでは、詳細な手順、堅牢なコード例、検証済みの方法を提供し、Web 表示に最適化された信頼性の高い効率的な変換プロセスを実現します。

Aspose.Slides は多数のオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) クラスから）を提供し、PowerPoint（または OpenDocument）形式から HTML への変換プロセスを定義します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、ビデオなど）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* PowerPoint プレゼンテーションを、講演者ノートを含めるか除外するか選択して HTML に変換します。
* PowerPoint プレゼンテーションを、コメントを含めるか除外するか選択して HTML に変換します。
* PowerPoint プレゼンテーションを、元のフォントまたは埋め込みフォントで HTML に変換します。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換します。

## **プレゼンテーションを HTML に変換する**

Aspose.Slides を使用すると、PowerPoint または OpenDocument のプレゼンテーション全体を次の手順で HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

このコードは C# で PowerPoint プレゼンテーションを HTML に変換する方法を示しています：
```c#
// プレゼンテーションファイル（例: PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // プレゼンテーションを HTML として保存します。
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **プレゼンテーションをレスポンシブ HTML に変換する**

Aspose.Slides は [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) クラスを提供し、レスポンシブ HTML ファイルの生成を可能にします。このコードは C# で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
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


## **講演者ノート付きでプレゼンテーションを HTML に変換する**

PowerPoint または OpenDocument のプレゼンテーションを講演者ノート付きで HTML に変換する際は、元のドキュメントの完全な内容を捉えることが重要です。このプロセスにより、スライドのビジュアル要素が正確に表現されるだけでなく、添付された講演者ノートも保持され、コンテンツに追加の文脈と洞察が加わります。

次のようなスライドを含む PowerPoint プレゼンテーションがあるとします：

![講演者ノート付きのプレゼンテーション スライド](slide_with_notes.png)

このコードは C# で PowerPoint プレゼンテーションを講演者ノート付きで HTML に変換する方法を示しています：
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // 講演者ノートのオプションを設定します。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 出力 HTML ドキュメントのオプションを設定します。
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // 講演者ノート付きでプレゼンテーションを HTML として保存します。
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


結果：

![スライドと講演者ノートを含む HTML ドキュメント](HTML_with_notes.png)

## **元のフォントでプレゼンテーションを HTML に変換する**

Aspose.Slides は [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) クラスを提供し、プレゼンテーションのすべてのフォントを埋め込んだ状態で HTML に変換できます。

特定のフォントを埋め込みたくない場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) クラスのパラメータ付きコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial などの一般的なフォントは、ほとんどのシステムに既にインストールされているため埋め込む必要はありません。埋め込むと結果の HTML ドキュメントのサイズが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) メソッドがオーバーライド対象として提供されています。
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

既定では、PowerPoint プレゼンテーションを HTML に変換すると、Aspose.Slides は 72 DPI の画像とトリミングされた領域の削除を行い、サイズの小さい HTML ファイルを出力します。より高品質な画像を含む HTML を取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（`PicturesCompression.Dpi96`）またはそれ以上に設定する必要があります。詳細は [このリファレンス](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression) を参照してください。

この C# コードは、画像解像度を 150 DPI（`PicturesCompression.Dpi150`）に設定して高品質画像付きの HTML に変換する方法を示しています：
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


この C# コードは、トリミング領域を削除せずに HTML に変換する方法を示しています：
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


## **スライドを HTML に変換する**

PowerPoint プレゼンテーションの特定のスライドを HTML に変換するには、全体プレゼンテーションの変換に使用したのと同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) メソッドで HTML として保存します。追加の変換オプションは [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) クラスで指定できます。

この C# コードは、講演者ノート付きのスライドを HTML に変換する方法を示しています：
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

            // スライドを HTML ファイルとして保存します。
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


## **HTML エクスポート時に CSS と画像を保存する**

新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換で生成された HTML の外観を簡単に変更できます。

この例の C# コードは、CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成するためにオーバーライド可能なメソッドを使用する方法を示しています：
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
    // カスタムヘッダーテンプレート。
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


## **フォントを埋め込まずにリンクする**

結果の HTML のサイズを増やしたくない場合は、フォントを埋め込む代わりにすべてのフォントへのリンクを作成できます。独自の `LinkAllFontsHtmlController` 実装を作成してください。

この C# コードは、"Calibri" と "Arial"（システムに既にインストールされているため）を除外し、すべてのフォントをリンクする方法を示しています：
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


この C# コードは、`LinkAllFontsHtmlController` の実装例を示しています：
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


## **メディア ファイルを HTML にエクスポートする**

Aspose.Slides for .NET を使用すると、メディア ファイルを次の手順でエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにビデオを追加します。
1. プレゼンテーションを HTML ファイルとして書き出します。

この C# コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています：
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

Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを提供しています: [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の無料コンバータについては、[Aspose の無料コンバータ](https://products.aspose.app/slides/conversion) をご確認ください。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

本稿で説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関する以下の変換操作もサポートしています:

* [HTML to image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**複数のプレゼンテーションを HTML に変換する際の Aspose.Slides のパフォーマンスは？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理において非常に効率的かつスケーラブルです。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドまたは並列処理を使用することを推奨します。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**

はい、Aspose.Slides は埋め込みハイパーリンクの HTML へのエクスポートを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能な状態になります。

**プレゼンテーションを HTML に変換する際のスライド数に制限はありますか？**

Aspose.Slides ではスライド数に制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、スライド数が非常に多い場合は、サーバーまたはシステムのリソースに応じてパフォーマンスが変わる可能性があります。