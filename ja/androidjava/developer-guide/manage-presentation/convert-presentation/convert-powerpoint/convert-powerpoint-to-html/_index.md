---
title: AndroidでPowerPointプレゼンテーションをHTMLに変換
linktitle: PowerPointをHTMLに変換
type: docs
weight: 30
url: /ja/androidjava/convert-powerpoint-to-html/
keywords:
  - PowerPointを変換
  - プレゼンテーションを変換
  - スライドを変換
  - PPTを変換
  - PPTXを変換
  - PowerPointをHTMLに変換
  - プレゼンテーションをHTMLに変換
  - スライドをHTMLに変換
  - PPTをHTMLに変換
  - PPTXをHTMLに変換
  - PowerPointをHTMLとして保存
  - プレゼンテーションをHTMLとして保存
  - スライドをHTMLとして保存
  - PPTをHTMLとして保存
  - PPTXをHTMLとして保存
  - PPTをHTMLにエクスポート
  - PPTXをHTMLにエクスポート
  - Android
  - Java
  - Aspose.Slides
description: "JavaでPowerPointプレゼンテーションをレスポンシブHTMLに変換します。Aspose.Slides for Androidを使用した変換ガイドで、レイアウト、リンク、画像を保持し、迅速かつ完璧な結果を実現します."
---

## **概要**

この記事では、Java を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを取り上げます。

- Java で PowerPoint を HTML に変換する
- Java で PPT を HTML に変換する
- Java で PPTX を HTML に変換する
- Java で ODP を HTML に変換する
- Java で PowerPoint スライドを HTML に変換する

## **Android での PowerPoint から HTML への変換**

PowerPoint を HTML に変換する Java のサンプルコードについては、以下のセクション、つまり [Convert PowerPoint to HTML](#convert-powerpoint-to-html) を参照してください。このコードは PPT、PPTX、ODP などのさまざまな形式を Presentation オブジェクトにロードし、HTML 形式で保存できます。

## **PowerPoint から HTML への変換について**

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX to HTML** または **PPT to HTML**。

**Aspose.Slides** は、PowerPoint を HTML に変換するプロセスを定義する多くのオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) クラス）を提供します：

* PowerPoint プレゼンテーション全体を HTML に変換する。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換する。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換する。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換する。
* スピーカーノートを含めるか除外するか選択して、PowerPoint プレゼンテーションを HTML に変換する。
* コメントを含めるか除外するか選択して、PowerPoint プレゼンテーションを HTML に変換する。
* オリジナルフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換する。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換する。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の [free converters from Aspose](https://products.aspose.app/slides/conversion) も確認してください。

{{% /alert %}} 

## **PowerPoint を HTML に変換する**

Aspose.Slides を使用すると、以下の手順で PowerPoint プレゼンテーション全体を HTML に変換できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用して、オブジェクトを HTML ファイルとして保存します。

このコードは Java で PowerPoint を HTML に変換する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // プレゼンテーションを HTML に保存します
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint をレスポンシブ HTML に変換する**

Aspose.Slides は、レスポンシブ HTML ファイルの生成を可能にする [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) クラスを提供します。このコードは Java で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // プレゼンテーションを HTML に保存します
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint をノート付き HTML に変換する**

このコードは Java でノート付きの PowerPoint を HTML に変換する方法を示しています：
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


## **PowerPoint を元のフォントで HTML に変換する**

Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) クラスを提供します。

埋め込む必要のないフォントを除外したい場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) のパラメータ化されたコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial などの一般的なフォントは、ほとんどのシステムにすでに存在するため埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML 文書が不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) メソッドを提供します。このメソッドはオーバーライドすることが想定されています。
```java
Presentation pres = new Presentation("input.pptx");
try {
    // デフォルトのプレゼンテーションフォントを除外する
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```


## **高品質画像で PowerPoint を HTML に変換する**

デフォルトでは、PowerPoint を HTML に変換すると Aspose.Slides は 72 DPI の画像とトリミングされた領域を削除した小さな HTML を出力します。より高品質な画像を含む HTML を取得するには、`PicturesCompression` プロパティ（`HtmlOptions` クラスから）を 96（`PicturesCompression.Dpi96`）以上の値に設定する必要があります。[values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression)。

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


この Java コードは、フルクオリティの画像で HTML を出力する方法を示しています：
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


## **スライドを HTML に変換する**

PowerPoint の特定のスライドを HTML に変換するには、全体のプレゼンテーションを変換する際と同じ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドで HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) クラスを使用して、追加の変換オプションを指定できます。

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


## **HTML エクスポート時に CSS と画像を保存する**

新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成された HTML ファイルのスタイルを簡単に変更できます。

この例の Java コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています：
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

    // カスタムヘッダー テンプレート
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


## **HTML に変換する際にすべてのフォントをリンクする**

フォントを埋め込みたくない（生成される HTML のサイズ増加を防ぐ）場合は、独自の `LinkAllFontsHtmlController` バージョンを実装してすべてのフォントをリンクできます。

この Java コードは、すべてのフォントをリンクし、システムに既に存在する「Calibri」および「Arial」を除外して PowerPoint を HTML に変換する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // デフォルトのプレゼンテーションフォントを除外
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


この Java コードは、`LinkAllFontsHtmlController` の実装方法を示しています：
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


## **PowerPoint をレスポンシブ HTML に変換する**

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


## **メディアファイルを HTML にエクスポートする**

Aspose.Slides for Android via Java を使用すると、以下の手順でメディア ファイルをエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドにビデオを追加します。
4. プレゼンテーションを書き出して HTML ファイルとして保存します。

この Java コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています：
```java
// プレゼンテーションを読み込む
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // HTML オプションを設定
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

**What is the performance of Aspose.Slides when converting multiple presentations to HTML?**  
パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理に対して高い効率性とスケーラビリティを提供します。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドまたは並列処理を使用することを推奨します。

**Does Aspose.Slides support exporting hyperlinks to HTML?**  
はい、Aspose.Slides は埋め込みハイパーリンクの HTML へのエクスポートを完全にサポートします。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**Is there any limit on the number of slides when converting presentations to HTML?**  
Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、スライド数が非常に多い場合は、サーバーまたはシステムのリソースに応じてパフォーマンスが影響を受ける可能性があります。