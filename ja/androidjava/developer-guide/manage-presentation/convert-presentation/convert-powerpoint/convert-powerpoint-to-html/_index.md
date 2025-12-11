---
title: Android で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Java で PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides for Android の変換ガイドで高速かつ完璧な結果を得られます。"
---

## **概要**

本記事では、Java を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックをカバーしています。

- Java で PowerPoint を HTML に変換
- Java で PPT を HTML に変換
- Java で PPTX を HTML に変換
- Java で ODP を HTML に変換
- Java で PowerPoint スライドを HTML に変換

## **Android での PowerPoint から HTML への変換**

PowerPoint を HTML に変換する Java サンプルコードは、以下のセクション [PowerPoint を HTML に変換](#convert-powerpoint-to-html) をご参照ください。このコードは PPT、PPTX、ODP など複数の形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPoint から HTML への変換について**
[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX から HTML** または **PPT から HTML**。

**Aspose.Slides** は、（主に [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) クラスから）以下のような多数のオプションを提供し、PowerPoint から HTML への変換プロセスを定義します。

* PowerPoint プレゼンテーション全体を HTML に変換
* PowerPoint プレゼンテーション内の特定のスライドを HTML に変換
* プレゼンテーションのメディア（画像、動画等）を HTML に変換
* レスポンシブ HTML に PowerPoint を変換
* スピーカーノートを含めるか除外した HTML に PowerPoint を変換
* コメントを含めるか除外した HTML に PowerPoint を変換
* 元のフォントまたは埋め込みフォントで HTML に PowerPoint を変換
* 新しい CSS スタイルを使用した HTML に PowerPoint を変換

{{% alert color="primary" %}} 

独自 API を使用して、Aspose は無料の [プレゼンテーションから HTML への変換](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しています： [PPT から HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX から HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP から HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータもご確認ください: [https://products.aspose.app/slides/conversion](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注記" color="warning" %}} 

本記事で説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint を HTML に変換**
Aspose.Slides を使用して、PowerPoint プレゼンテーション全体を HTML に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

以下のコードは、Java で PowerPoint を HTML に変換する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    //    プレゼンテーションを HTML に保存
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```



## **PowerPoint をレスポンシブ HTML に変換**
Aspose.Slides は、レスポンシブ HTML ファイルを生成できる [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) クラスを提供します。以下のコードは、Java で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // プレゼンテーションを HTML に保存
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint をノート付き HTML に変換**
以下のコードは、Java でノートを含む PowerPoint を HTML に変換する方法を示しています：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // ノートページを保存
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint を元のフォント付き HTML に変換**

Aspose.Slides は、プレゼンテーション内のすべてのフォントを埋め込みながら HTML に変換できる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) クラスを提供します。

特定のフォントを埋め込みたくない場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) のパラメータ化されたコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial など、ほとんどのシステムに既にインストールされているフォントは埋め込む必要がありません。これらのフォントを埋め込むと、生成される HTML 文書が不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) メソッドをオーバーライドできるようにしています。
```java
Presentation pres = new Presentation("input.pptx");
try {
    // デフォルトのプレゼンテーションフォントを除外
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint を高品質画像付き HTML に変換**

既定では、PowerPoint を HTML に変換すると、Aspose.Slides は 72 DPI の小さな画像とトリミングされた領域を削除した HTML を出力します。高品質画像を含む HTML ファイルを取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（例：`PicturesCompression.Dpi96`）以上の値に設定する必要があります。詳細は [こちら](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression) を参照してください。

この Java コードは、150 DPI（`PicturesCompression.Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています：
```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setPicturesCompression(PicturesCompression.Dpi150);
    
    pres.save("OutputDoc-dpi150.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```


この Java コードは、フルクオリティ画像で HTML を出力する方法を示しています：
```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);

    pres.save("Outputdoc-noCrop.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライドを HTML に変換**
PowerPoint の特定のスライドを HTML に変換するには、プレゼンテーション全体を HTML に変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスをインスタンス化し、[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドで HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) クラスを使用して追加の変換オプションを指定できます：

この Java コードは、PowerPoint プレゼンテーションのスライドを HTML に変換する方法を示しています：
```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

	// ファイルを保存
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomFormattingController implements IHtmlFormattingController
{
    @Override
    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeSlideStart(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(String.format(SlideHeader, generator.getSlideIndex() + 1));
    }

    @Override
    public void writeSlideEnd(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(SlideFooter);
    }

    @Override
    public void writeShapeStart(IHtmlGenerator generator, IShape shape) { }

    @Override
    public void writeShapeEnd(IHtmlGenerator generator, IShape shape) { }

    private final String SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    private final String SlideFooter = "</div>";
}
```



## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML ファイルのスタイルを簡単に変更できます。

この例の Java コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを持つカスタム HTML ドキュメントを作成する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
    HtmlOptions options = new HtmlOptions();
    options.setHtmlFormatter(HtmlFormatter.createCustomFormatter(htmlController));

    pres.save("pres.html", SaveFormat.Html, options);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // カスタムヘッダーのテンプレート
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName) 
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **プレゼンテーションを HTML に変換するときにすべてのフォントをリンク**

フォントを埋め込みたくない（HTML のサイズ増加を防ぎたい）場合は、独自の `LinkAllFontsHtmlController` 実装でフォントをすべてリンクできます。

この Java コードは、"Calibri" と "Arial"（システムに既に存在する）を除外し、すべてのフォントをリンクした状態で PowerPoint を HTML に変換する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //デフォルトのプレゼンテーションフォントを除外
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList,"C:/Windows/Fonts/");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter((IHtmlFormattingController) linkcont));

    pres.save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
finally {
    if (pres != null) pres.dispose();
}
```


この Java コードは、`LinkAllFontsHtmlController` の実装例を示しています：
```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // パスのサニタイズが必要になる場合があります
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```


## **PowerPoint をレスポンシブ HTML に変換**
この Java コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```java
Presentation pres = new Presentation("SomePresentation.pptx");
try {
    HtmlOptions saveOptions = new HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```



## **メディア ファイルを HTML にエクスポート**
Aspose.Slides for Android via Java を使用すると、メディア ファイルを次の手順でエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにビデオを追加します。
1. プレゼンテーションを書き出して HTML ファイルにします。

この Java コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています：
```java
// プレゼンテーションの読み込み
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // HTML オプションの設定
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // ファイルを保存
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Aspose.Slides の複数プレゼンテーションを HTML に変換する際のパフォーマンスは？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理において高い効率とスケーラビリティを提供します。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドや並列処理を使用することを推奨します。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**

はい、Aspose.Slides は埋め込みハイパーリンクの HTML へのエクスポートを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際のスライド数に制限はありますか？**

Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、非常に多くのスライドを含むプレゼンテーションの場合、サーバーやシステムの利用可能なリソースに応じてパフォーマンスが左右されることがあります。