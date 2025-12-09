---
title: JavaでPowerPointプレゼンテーションをHTMLに変換
linktitle: PowerPointをHTMLへ
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-html/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをHTMLへ
- プレゼンテーションをHTMLへ
- スライドをHTMLへ
- PPTをHTMLへ
- PPTXをHTMLへ
- PowerPointをHTMLとして保存
- プレゼンテーションをHTMLとして保存
- スライドをHTMLとして保存
- PPTをHTMLとして保存
- PPTXをHTMLとして保存
- PPTをHTMLにエクスポート
- PPTXをHTMLにエクスポート
- Java
- Aspose.Slides
description: "JavaでPowerPointプレゼンテーションをレスポンシブHTMLに変換します。レイアウト、リンク、画像を保持し、Aspose.Slidesの変換ガイドで高速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、Java を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを取り上げます。

- Java で PowerPoint を HTML に変換する
- Java で PPT を HTML に変換する
- Java で PPTX を HTML に変換する
- Java で ODP を HTML に変換する
- Java で PowerPoint スライドを HTML に変換する

## **Java PowerPoint を HTML に変換**

PowerPoint を HTML に変換する Java のサンプルコードについては、以下のセクション、すなわち[PowerPoint を HTML に変換](#convert-powerpoint-to-html)をご覧ください。コードは PPT、PPTX、ODP などのさまざまな形式を Presentation オブジェクトで読み込み、HTML 形式で保存できます。

## **PowerPoint を HTML に変換する方法について**

Using [**Aspose.Slides for Java**](https://products.aspose.com/slides/java/), applications and developers can convert a PowerPoint presentation to HTML: **PPTX to HTML** or **PPT to HTML**.  

**Aspose.Slides** は、PowerPoint を HTML に変換するプロセスを定義する多くのオプションを提供します（主に [**HtmlOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) クラスから）。

* PowerPoint プレゼンテーション全体を HTML に変換する。
* PowerPoint プレゼンテーション内の特定のスライドを HTML に変換する。
* プレゼンテーションのメディア（画像、動画等）を HTML に変換する。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換する。
* スピーカーノートを含むか除外した状態で PowerPoint プレゼンテーションを HTML に変換する。
* コメントを含むか除外した状態で PowerPoint プレゼンテーションを HTML に変換する。
* 元のフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換する。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換する。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の[無料コンバータ](https://products.aspose.app/slides/conversion)もご覧ください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関わる以下の変換操作もサポートしています。

* [HTML を画像に変換](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML を JPG に変換](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML を XML に変換](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML を TIFF に変換](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション全体を次のように HTML に変換できます。

1. Presentation クラスのインスタンスを作成します。
1. Save メソッドを使用して、オブジェクトを HTML ファイルとして保存します。

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


## **PowerPoint をレスポンシブ HTML に変換**

Aspose.Slides は、レスポンシブ HTML ファイルを生成できる [ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/ResponsiveHtmlController) クラスを提供します。このコードは、Java で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています。

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


## **ノート付きで PowerPoint を HTML に変換**

このコードは、Java でノート付きの PowerPoint を HTML に変換する方法を示しています。

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


## **元のフォントで PowerPoint を HTML に変換**

Aspose.Slides は、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができる [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) クラスを提供します。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) クラスのパラメータ化されたコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial などの一般的なフォントは、プレゼンテーションで使用されても、ほとんどのシステムに既に存在するため埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML ドキュメントが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) メソッドを提供します。このメソッドはオーバーライドすることを想定しています。

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


## **高品質画像で PowerPoint を HTML に変換**

デフォルトでは、PowerPoint を HTML に変換すると、Aspose.Slides は 72 DPI の画像で小さな HTML を出力し、切り取られた領域は削除されます。より高品質な画像を含む HTML ファイルを取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（すなわち `PicturesCompression.Dpi96`）以上の[値](https://reference.aspose.com/slides/java/com.aspose.slides/PicturesCompression)に設定する必要があります。

この Java コードは、150 DPI（`PicturesCompression.Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています。

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


この Java コードは、フルクオリティの画像を使用した HTML を出力する方法を示しています。

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

PowerPoint の特定のスライドを HTML に変換するには、全体のプレゼンテーションを HTML に変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドでファイルを HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) クラスを使用して、追加の変換オプションを指定できます。

この Java コードは、PowerPoint プレゼンテーションのスライドを HTML に変換する方法を示しています。

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


## **HTML にエクスポートする際に CSS と画像を保存**

新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換プロセスで生成された HTML ファイルのスタイルを簡単に変更できます。

この例の Java コードは、オーバーライド可能なメソッドを使用して、CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています。

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

    // カスタムヘッダーテンプレート
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


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**

フォントを埋め込みたくない（結果の HTML のサイズ増加を避ける）場合は、独自の `LinkAllFontsHtmlController` を実装してすべてのフォントをリンクできます。

この Java コードは、すべてのフォントをリンクし、システムに既に存在する "Calibri" と "Arial" を除外して PowerPoint を HTML に変換する方法を示しています。

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


この Java コードは、`LinkAllFontsHtmlController` の実装方法を示しています。

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
            String path = fontName + ".woff"; // 一部のパスのサニタイズが必要になる場合があります
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

この Java コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています。

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


## **メディアファイルを HTML にエクスポート**

Aspose.Slides for Java を使用すると、次の手順でメディアファイルをエクスポートできます。

1. Presentation クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにビデオを追加します。
1. プレゼンテーションを書き出して HTML ファイルにします。

この Java コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています。

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
