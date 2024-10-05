---
title: JavaでPowerPointをHTMLに変換
linktitle: PowerPointをHTMLに変換
type: docs
weight: 30
url: /java/convert-powerpoint-to-html/
keywords: "Java PowerPoint to HTML, PowerPointプレゼンテーションの変換, PPTX, PPT, PPTをHTMLに, PPTXをHTMLに, PowerPointをHTMLに, PowerPointをHTMLとして保存, PPTをHTMLとして保存, PPTXをHTMLとして保存, Java, Aspose.Slides, HTMLエクスポート"
description: "JavaでPowerPointをHTMLに変換: PPTXまたはPPTをHTMLとして保存します。JavaでスライドをHTMLに保存します"
---

## **概要**

この記事では、Javaを使用してPowerPointプレゼンテーションをHTML形式に変換する方法を説明します。以下のトピックをカバーしています。

- JavaでPowerPointをHTMLに変換
- JavaでPPTをHTMLに変換
- JavaでPPTXをHTMLに変換
- JavaでODPをHTMLに変換
- JavaでPowerPointスライドをHTMLに変換

## **Java PowerPointをHTMLに変換**

PowerPointをHTMLに変換するためのJavaのサンプルコードについては、下記のセクションを参照してください、すなわち[PowerPointをHTMLに変換](#convert-powerpoint-to-html)。コードは、プレゼンテーションオブジェクトでPPT、PPTX、ODPなどのフォーマットを読み込み、HTML形式に保存できます。

## **PowerPointからHTMLへの変換について**
[**Aspose.Slides for Java**](https://products.aspose.com/slides/java/)を使用すると、アプリケーションと開発者はPowerPointプレゼンテーションをHTMLに変換できます：**PPTXをHTMLに**または**PPTをHTMLに**。

**Aspose.Slides**は、PowerPointからHTMLへの変換プロセスを定義する多くのオプション（ほとんどが[**HtmlOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions)クラスから）を提供します：

* PowerPointプレゼンテーション全体をHTMLに変換。
* PowerPointプレゼンテーションの特定のスライドをHTMLに変換。
* プレゼンテーションメディア（画像、動画など）をHTMLに変換。
* PowerPointプレゼンテーションをレスポンシブHTMLに変換。 
* スピーカーノートを含むまたは含まないHTMLにPowerPointプレゼンテーションを変換。 
* コメントを含むまたは含まないHTMLにPowerPointプレゼンテーションを変換。 
* 元のフォントまたは埋め込まれたフォントでHTMLにPowerPointプレゼンテーションを変換。 
* 新しいCSSスタイルを使用してHTMLにPowerPointプレゼンテーションを変換。 

{{% alert color="primary" %}} 

Asposeは独自のAPIを使用して、無料の[プレゼンテーションをHTMLに](https://products.aspose.app/slides/conversion/powerpoint-to-html)コンバータを開発しました：[PPTをHTMLに](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTXをHTMLに](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODPをHTMLに](https://products.aspose.app/slides/conversion/odp-to-html)など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の[無料のAsposeコンバータ](https://products.aspose.app/slides/conversion)もチェックしてみると良いでしょう。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

ここで説明されている変換プロセスに加えて、Aspose.SlidesはHTMLフォーマットに関するこれらの変換操作もサポートしています：

* [HTMLから画像](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTMLからJPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTMLからXML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTMLからTIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPointをHTMLに変換**
Aspose.Slidesを使用すると、次の方法でPowerPointプレゼンテーション全体をHTMLに変換できます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、オブジェクトをHTMLファイルとして保存します。

このコードは、JavaでPowerPointをHTMLに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // プレゼンテーションをHTMLに保存
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPointをレスポンシブHTMLに変換**
Aspose.Slidesは、レスポンシブHTMLファイルを生成するための[ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/ResponsiveHtmlController)クラスを提供しています。このコードは、JavaでPowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // プレゼンテーションをHTMLに保存
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ノート付きPowerPointをHTMLに変換**
このコードは、Javaでノート付きのPowerPointをHTMLに変換する方法を示しています：

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

## **オリジナルフォント付きPowerPointをHTMLに変換**

Aspose.Slidesは、プレゼンテーションをHTMLに変換する際にすべてのフォントを埋め込むことができる[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController)クラスを提供しています。

特定のフォントが埋め込まれないようにするために、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController)クラスのパラメータ化されたコンストラクターにフォント名の配列を渡すことができます。カリブリやアリールなどの一般的なフォントは、プレゼンテーションで使用される場合、ほとんどのシステムにはすでに存在するため、埋め込む必要はありません。これらのフォントを埋め込むと、生成されるHTML文書が不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController)クラスは継承をサポートし、オーバーライドされることを意図した[WriteFont](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-)メソッドを提供します。 

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

## **高品質の画像でPowerPointをHTMLに変換**

デフォルトでは、PowerPointをHTMLに変換する際、Aspose.Slidesは72 DPIで画像を小さく出力し、トリミングされた領域を削除します。より高品質の画像を含むHTMLファイルを取得するには、`PicturesCompression`プロパティ（`HtmlOptions`クラスから）を96（つまり、`PicturesCompression.Dpi96`）以上に設定する必要があります[値](https://reference.aspose.com/slides/java/com.aspose.slides/PicturesCompression)。

このJavaコードは、150 DPI（つまり、`PicturesCompression.Dpi150`）で高品質の画像を得ながらPowerPointプレゼンテーションをHTMLに変換する方法を示しています：

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

このJavaコードは、フルクオリティの画像を含むHTMLを出力する方法を示しています：

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

## **スライドをHTMLに変換**
PowerPointで特定のスライドをHTMLに変換するには、全体のプレゼンテーションをHTMLに変換するために使用されたのと同じ[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスをインスタンス化し、[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、ファイルをHTMLとして保存する必要があります。[HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions)クラスを使用して追加の変換オプションを指定できます：

このJavaコードは、PowerPointプレゼンテーションのスライドをHTMLに変換する方法を示しています：

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // ファイルを保存
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1}, SaveFormat.Html, htmlOptions);
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


## **HTMLにエクスポートするときにCSSと画像を保存**
新しいCSSスタイルファイルを使用すると、PowerPointからHTMLへの変換プロセスの結果として生成されたHTMLファイルのスタイルを簡単に変更できます。

この例のJavaコードは、オーバーライド可能なメソッドを使用してCSSファイルへのリンク付きのカスタムHTMLドキュメントを作成する方法を示しています：

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
        generator.addHtml("<!-- 埋め込まれたフォント -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **プレゼンテーションをHTMLに変換するときにすべてのフォントをリンクする**

フォントを埋め込まずに、生成されるHTMLのサイズを増加させないようにしたい場合は、自分の`LinkAllFontsHtmlController`バージョンを実装することで、すべてのフォントをリンクすることができます。

このJavaコードは、PowerPointをHTMLに変換し、すべてのフォントをリンクし、"Calibri"および"Arial"を除外（すでにシステムに存在するため）する方法を示しています：

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

このJavaコードは、`LinkAllFontsHtmlController`がどのように実装されるかを示しています：

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
            String path = fontName + ".woff"; // いくつかのパスサニタイズが必要かもしれません
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

## **PowerPointをレスポンシブHTMLに変換**
このJavaコードは、PowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

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


## **メディアファイルをHTMLにエクスポート**
Aspose.Slides for Javaを使用して、次のようにメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドに動画を追加します。
1. プレゼンテーションをHTMLファイルとして書き出します。

このJavaコードは、プレゼンテーションに動画を追加し、その後HTMLとして保存する方法を示しています：

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

    // HTMLオプションを設定
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