---
title: JavaScript で PowerPoint を HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/nodejs-java/convert-powerpoint-to-html/
keywords: "Java PowerPoint を HTML に変換, PowerPoint プレゼンテーションを変換, PPTX, PPT, PPT を HTML に変換, PPTX を HTML に変換, PowerPoint を HTML に変換, PowerPoint を HTML として保存, PPT を HTML として保存, PPTX を HTML として保存, Java, Aspose.Slides, HTML エクスポート"
description: "JavaScript で PowerPoint を HTML に変換します。JavaScript で PPTX または PPT を HTML として保存します。JavaScript でスライドを HTML として保存します。"
---

## **概要**

この記事では、JavaScript を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。次のトピックをカバーします。

- JavaScript で PowerPoint を HTML に変換
- JavaScript で PPT を HTML に変換
- JavaScript で PPTX を HTML に変換
- JavaScript で ODP を HTML に変換
- JavaScript で PowerPoint スライドを HTML に変換

## **JavaScript PowerPoint to HTML**

PowerPoint を HTML に変換する JavaScript のサンプルコードについては、以下のセクション、つまり [PowerPoint を HTML に変換](#convert-powerpoint-to-html) を参照してください。コードは PPT、PPTX、ODP などのさまざまな形式を Presentation オブジェクトでロードし、HTML 形式で保存できます。

## **PowerPoint を HTML に変換する概要**
**Aspose.Slides for Node.js via Java**（https://products.aspose.com/slides/nodejs-java/）を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX to HTML** または **PPT to HTML**。

**Aspose.Slides** は、PowerPoint を HTML に変換するプロセスを定義する多くのオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) クラス）を提供します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* スピーカーノートを含むまたは除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* コメントを含むまたは除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* 元のフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換します。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換します。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

[Aspose の他の無料コンバータ](https://products.aspose.app/slides/conversion) を確認したくなるかもしれません。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関する以下の変換操作もサポートしています：

* [HTML を画像に変換](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML を JPG に変換](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML を XML に変換](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML を TIFF に変換](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint を HTML に変換**
Aspose.Slides を使用すると、PowerPoint プレゼンテーション全体を HTML に変換できます。方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

このコードは、JavaScript で PowerPoint を HTML に変換する方法を示しています：
```javascript
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // プレゼンテーションを HTML に保存します
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint をレスポンシブ HTML に変換**
Aspose.Slides は [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) クラスを提供し、レスポンシブ HTML ファイルを生成できます。このコードは、JavaScript で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```javascript
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // プレゼンテーションを HTML に保存します
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint をノート付き HTML に変換**
このコードは、JavaScript で PowerPoint をノート付き HTML に変換する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // ノートページを保存
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint を元のフォント付き HTML に変換**
Aspose.Slides は [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) クラスを提供し、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができます。

特定のフォントを埋め込まないようにするには、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) のパラメータ化されたコンストラクターにフォント名の配列を渡すことができます。Calibri や Arial のような一般的なフォントは、プレゼンテーションで使用されても、ほとんどのシステムに既に存在するため埋め込む必要はありません。これらのフォントを埋め込むと、生成される HTML ドキュメントが不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) クラスは継承をサポートし、上書きすることを意図した [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) メソッドを提供します。
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // デフォルトのプレゼンテーションフォントを除外
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint を高品質画像付き HTML に変換**
デフォルトでは、PowerPoint を HTML に変換すると、Aspose.Slides は 72 DPI の小さな画像と切り取られた領域が削除された小さな HTML を出力します。より高品質な画像を含む HTML ファイルを取得するには、`HtmlOptions` クラスの `setPicturesCompression` メソッドに `96`（`PicturesCompression.Dpi96`）またはそれ以上の [値](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression) を指定する必要があります。

この JavaScript コードは、150 DPI（`PicturesCompression.Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


この JavaScript コードは、フルクオリティの画像を含む HTML を出力する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **スライドを HTML に変換**
PowerPoint の特定のスライドを HTML に変換するには、全体のプレゼンテーションを HTML に変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスをインスタンス化し、[save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) メソッドで HTML として保存します。[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) クラスを使用して追加の変換オプションを指定できます：
```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // ファイルを保存
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **HTML へのエクスポート時に CSS と画像を保存**
新しい CSS スタイル ファイルを使用すると、PowerPoint から HTML への変換プロセスで生成された HTML ファイルのスタイルを簡単に変更できます。

この例の JavaScriptコードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


CustomHeaderAndFontsController を Java で実装し、コンパイルして、モジュールの場所 \aspose.slides.via.java\lib\ に追加する必要があります。

この Java コードは、`CustomHeaderAndFontsController` の実装方法を示しています：
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
フォントを埋め込まず（結果の HTML のサイズ増大を防ぐため）すべてのフォントをリンクしたい場合は、独自の `LinkAllFontsHtmlController` バージョンを実装できます。

この JavaScript コードは、すべてのフォントをリンクし、システムに既に存在する "Calibri" と "Arial" を除外した状態で PowerPoint を HTML に変換する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // デフォルトのプレゼンテーションフォントを除外
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


LinkAllFontsHtmlController を Java で実装し、コンパイルして、モジュールの場所 \aspose.slides.via.java\lib\ に追加する必要があります。

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
            String path = fontName + ".woff"; // パスの正規化が必要になる場合があります
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
この JavaScript コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **メディアファイルを HTML にエクスポート**
Aspose.Slides for Node.js via Java を使用すると、メディアファイルを次のようにエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにビデオを追加します。
1. プレゼンテーションを書き出し、HTML ファイルとして保存します。

この JavaScript コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています：
```javascript
// プレゼンテーションを読み込む
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // HTML オプションを設定
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // ファイルを保存
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**複数のプレゼンテーションを HTML に変換する際の Aspose.Slides のパフォーマンスはどうですか？**
パフォーマンスはプレゼンテーションのサイズや複雑さに依存します。Aspose.Slides はバッチ処理に対して非常に効率的でスケーラブルです。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドや並列処理を使用することを推奨します。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**
はい、Aspose.Slides は埋め込まれたハイパーリンクを HTML にエクスポートすることを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**
スライド数に制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、非常に多くのスライドを含むプレゼンテーションの場合、パフォーマンスはサーバーやシステムのリソースに依存する可能性があります。