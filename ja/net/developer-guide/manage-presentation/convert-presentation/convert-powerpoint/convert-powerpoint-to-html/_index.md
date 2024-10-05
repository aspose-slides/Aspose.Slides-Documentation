---
title: C# .NETでPowerPointをHTMLに変換する
linktitle: PowerPointをHTMLに変換する
type: docs
weight: 30
url: /net/convert-powerpoint-to-html/
keywords: "C# PowerPoint to HTML, C# PPT to HTML, C# ODP to HTML, C# Slide to HTML, PowerPointプレゼンテーションを変換, PPTX, PPT, PPTをHTMLに, PPTXをHTMLに, PowerPointをHTMLに, PowerPointをHTMLとして保存, PPTをHTMLとして保存, PPTXをHTMLとして保存, C#, Csharp, .NET, Aspose.Slides, HTMLエクスポート"
description: "PowerPoint HTMLに変換: PPTXまたはPPTをHTMLとして保存。スライドをHTMLとして保存"
---

## **概要**

この記事では、C#を使用してPowerPointプレゼンテーションをHTML形式に変換する方法を説明します。以下のトピックをカバーします。

- [C#でPowerPointをHTMLに変換する](#convert-powerpoint-to-html)
- [C#でPPTをHTMLに変換する](#convert-powerpoint-to-html)
- [C#でPPTXをHTMLに変換する](#convert-powerpoint-to-html)
- [C#でODPをHTMLに変換する](#convert-powerpoint-to-html)
- [C#でPowerPointスライドをHTMLに変換する](#convert-slide-to-html)

## **C# PowerPointをHTMLに変換する**

PowerPointをHTMLに変換するC#のサンプルコードについては、以下のセクションを参照してください。つまり、[PowerPointをHTMLに変換する](#convert-powerpoint-to-html)。このコードは、PPT、PPTX、ODPなどの形式をPresentationオブジェクトに読み込み、HTML形式に保存できます。

## **PowerPointをHTMLに変換するについて**
[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)を使用すると、アプリケーションと開発者はPowerPointプレゼンテーションをHTMLに変換できます：**PPTXをHTMLに**または**PPTをHTMLに**。 

**Aspose.Slides**は、PowerPointをHTMLに変換するプロセスを定義する多くのオプション（ほとんどが[**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)クラスから）を提供しています：

* PowerPointプレゼンテーション全体をHTMLに変換する。
* PowerPointプレゼンテーション内の特定のスライドをHTMLに変換する。
* プレゼンテーションメディア（画像、動画など）をHTMLに変換する。
* PowerPointプレゼンテーションをレスポンシブHTMLに変換する。 
* スピーカーノートを含めるか除外してPowerPointプレゼンテーションをHTMLに変換する。 
* コメントを含めるか除外してPowerPointプレゼンテーションをHTMLに変換する。 
* 元のフォントまたは埋め込まれたフォントを使用してPowerPointプレゼンテーションをHTMLに変換する。 
* 新しいCSSスタイルを使用してPowerPointプレゼンテーションをHTMLに変換する。 

{{% alert color="primary" %}} 

独自のAPIを使用して、Asposeは無料の[プレゼンテーションをHTMLに](https://products.aspose.app/slides/conversion/powerpoint-to-html)変換ツールを開発しました：[PPTをHTMLに](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTXをHTMLに](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODPをHTMLに](https://products.aspose.app/slides/conversion/odp-to-html)など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の[Asposeの無料変換ツール](https://products.aspose.app/slides/conversion)をチェックしてみてください。

{{% /alert %}} 

{{% alert title="注" color="warning" %}} 

ここで説明されている変換プロセスに加えて、Aspose.SlidesはHTML形式に関するこれらの変換操作もサポートしています： 

* [HTMLを画像に変換する](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTMLをJPGに変換する](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTMLをXMLに変換する](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTMLをTIFFに変換する](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPointをHTMLに変換する**
Aspose.Slidesを使用すると、全体のPowerPointプレゼンテーションをこのようにHTMLに変換できます：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)メソッドを使用してオブジェクトをHTMLファイルとして保存します。

このコードは、C#でPowerPointをHTMLに変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します（例：PPT、PPTX、ODPなど）。
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // プレゼンテーションをHTMLとして保存します
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **PowerPointをレスポンシブHTMLに変換する**
Aspose.Slidesは、レスポンシブHTMLファイルを生成するための[ResponsiveHtmlController ](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller)クラスを提供しています。このコードは、C#でPowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // プレゼンテーションをHTMLとして保存します
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **ノート付きでPowerPointをHTMLに変換する**
このコードは、C#でノート付きのPowerPointをHTMLに変換する方法を示しています：

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // ノートページを保存します
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **元のフォント付きでPowerPointをHTMLに変換する**

Aspose.Slidesは、プレゼンテーションをHTMLに変換する際にすべてのフォントを埋め込むことを可能にする[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)クラスを提供します。

特定のフォントが埋め込まれるのを防ぐために、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)クラスのパラメータ化されたコンストラクターにフォント名の配列を渡すことができます。CalibriやArialなどの一般的なフォントは、プレゼンテーションで使用される場合、ほとんどのシステムに既に含まれているため、埋め込む必要はありません。これらのフォントが埋め込まれると、生成されるHTML文書は不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)クラスは継承をサポートし、オーバーライドされることを意図した[WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont)メソッドを提供します。 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // デフォルトのプレゼンテーションフォントを除外します
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **高品質の画像でPowerPointをHTMLに変換する**

デフォルトでは、PowerPointをHTMLに変換する際、Aspose.Slidesは72DPIの小さなHTMLを出力し、切り取られた領域は削除されます。より高品質な画像を持つHTMLファイルを取得するには、`HtmlOptions`クラスから`PicturesCompression`プロパティを96（つまり`PicturesCompression.Dpi96`）以上の[値](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression)に設定する必要があります。

このC#コードは、150 DPI（つまり`PicturesCompression.Dpi150`）で高品質画像を取得しながらPowerPointプレゼンテーションをHTMLに変換する方法を示しています：

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

このC#コードは、フルクオリティの画像付きHTMLを出力する方法を示しています：

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **スライドをHTMLに変換する**
特定のスライドをPowerPointからHTMLに変換するには、全体のプレゼンテーションをHTMLに変換するために使用されたのと同じ[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスをインスタンス化し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)メソッドを使用してファイルをHTMLとして保存する必要があります。[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**)クラスを使用して追加の変換オプションを指定できます：

このC#コードは、PowerPointプレゼンテーション内のスライドをHTMLに変換する方法を示しています：

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // ファイルを保存
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Individual Slide" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
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


## **HTMLにエクスポートする際にCSSと画像を保存する**
新しいCSSスタイルファイルを使用することで、PowerPointをHTMLに変換するプロセスから生成されたHTMLファイルのスタイルを簡単に変更できます。 

この例のC#コードは、オーバーライド可能なメソッドを使用してCSSファイルへのリンクを持つカスタムHTMLドキュメントを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // カスタムヘッダーテンプレート
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
        generator.AddHtml("<!-- 埋め込まれたフォント -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **プレゼンテーションをHTMLに変換する際にすべてのフォントをリンクする**

埋め込んだフォント（生成されたHTMLのサイズを増加させないように）を使用したくない場合は、自分自身の`LinkAllFontsHtmlController`バージョンを実装することで、すべてのフォントをリンクすることができます。 

このC#コードは、"Calibri"と"Arial"を除外し、すべてのフォントをリンクしながらPowerPointをHTMLに変換する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    // デフォルトのプレゼンテーションフォントを除外します
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

このC#コードは、`LinkAllFontsHtmlController`がどのように実装されているかを示しています：

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
            string path = fontName + ".woff"; // 一部のパスのサニタイズが必要になるかもしれません

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

## **PowerPointをレスポンシブHTMLに変換する**
このC#コードは、PowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **メディアファイルをHTMLにエクスポートする**
Aspose.Slides for .NETを使用して、次のようにメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドに動画を追加します。
1. プレゼンテーションをHTMLファイルとして書き出します。

このC#コードは、プレゼンテーションに動画を追加し、その後HTMLとして保存する方法を示しています： 

```c#
// プレゼンテーションを読み込みます
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // HTMLオプションを設定します
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // ファイルを保存します
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```