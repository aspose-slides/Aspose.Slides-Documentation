---
title: JavaScript で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に
type: docs
weight: 30
url: /ja/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。Aspose.Slides の変換ガイドを使用して、レイアウト、リンク、画像を保持し、迅速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、JavaScript を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを取り上げます。

- JavaScript で PowerPoint を HTML に変換
- JavaScript で PPT を HTML に変換
- JavaScript で PPTX を HTML に変換
- JavaScript で ODP を HTML に変換
- JavaScript で PowerPoint スライドを HTML に変換

## **JavaScript PowerPoint to HTML**

JavaScript のサンプルコードについては、以下のセクション、すなわち [Convert PowerPoint to HTML](#convert-powerpoint-to-html) を参照してください。コードは PPT、PPTX、ODP などの形式を Presentation オブジェクトに読み込み、HTML 形式で保存できます。

## **PowerPoint の HTML 変換について**
[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) を使用すると、アプリケーションと開発者は PowerPoint プレゼンテーションを HTML に変換できます：**PPTX to HTML** または **PPT to HTML**。

**Aspose.Slides** は多くのオプション（主に [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) クラス）を提供し、PowerPoint の HTML 変換プロセスを定義します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーションの特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* PowerPoint プレゼンテーションをスピーカーノートを含むか除外した HTML に変換します。
* PowerPoint プレゼンテーションをコメントを含むか除外した HTML に変換します。
* PowerPoint プレゼンテーションをオリジナルまたは埋め込みフォントの HTML に変換します。
* 新しい CSS スタイルを使用した PowerPoint プレゼンテーションを HTML に変換します。

{{% alert color="primary" %}} 

独自の API を使用して、Aspose は無料の [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) コンバータを開発しました：[PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) など。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の Aspose の無料コンバータもご確認ください。

{{% /alert %}} 

## **PowerPoint を HTML に変換**
Aspose.Slides を使用して、PowerPoint プレゼンテーション全体を HTML に変換する方法は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
2. [save] メソッドを使用してオブジェクトを HTML ファイルとして保存します。

このコードは JavaScript で PowerPoint を HTML に変換する方法を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // プレゼンテーションを HTML に保存する
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint をレスポンシブ HTML に変換**
Aspose.Slides は ResponsiveHtmlController クラスを提供し、レスポンシブ HTML ファイルの生成を可能にします。このコードは JavaScript で PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // プレゼンテーションを HTML に保存する
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint をノート付き HTML に変換**
このコードは JavaScript でノート付きの PowerPoint を HTML に変換する方法を示しています:
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


## **PowerPoint をオリジナルフォント付き HTML に変換**

Aspose.Slides は EmbedAllFontsHtmlController クラスを提供し、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができます。

特定のフォントの埋め込みを防止するには、EmbedAllFontsHtmlController のパラメータ化コンストラクタにフォント名の配列を渡すことができます。Calibri や Arial など、システムに既に存在する一般的なフォントは埋め込む必要はなく、埋め込むと HTML が不必要に大きくなります。

EmbedAllFontsHtmlController クラスは継承をサポートし、WriteFont メソッドを提供します。このメソッドはオーバーライドすることを想定しています。
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // デフォルトのプレゼンテーション フォントを除外
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

既定では、PowerPoint を HTML に変換すると、Aspose.Slides は 72 DPI の画像と削除された切り取り領域を含む小さな HTML を出力します。高品質画像を含む HTML を取得するには、HtmlOptions クラスの setPicturesCompression メソッドに `96`（例: PicturesCompression.Dpi96）またはそれ以上の値を渡す必要があります。

この JavaScript コードは、150 DPI（`PicturesCompression.Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています:
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


このコードは、フルクオリティの画像を含む HTML を出力する方法を示しています:
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
PowerPoint の特定のスライドを HTML に変換するには、Presentation クラスのインスタンスを作成し（全体変換と同様）、[save] メソッドで HTML として保存します。HtmlOptions クラスを使用して追加の変換オプションを指定できます。

この JavaScript コードは、PowerPoint プレゼンテーションのスライドを HTML に変換する方法を示しています:
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


## **HTML にエクスポートする際の CSS と画像の保存**
新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換結果のスタイルを簡単に変更できます。

この例の JavaScript コードは、CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成するためにオーバーライド可能なメソッドを使用する方法を示しています:
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


Java で CustomHeaderAndFontsController を実装し、コンパイルして \aspose.slides.via.java\lib\ に配置する必要があります。この Java コードは CustomHeaderAndFontsController の実装例です:
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


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**
フォントを埋め込まずに HTML のサイズ増加を防ぎたい場合は、独自の LinkAllFontsHtmlController を実装してすべてのフォントをリンクできます。

この JavaScript コードは、フォントをリンクし、"Calibri" と "Arial" を除外して PowerPoint を HTML に変換する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // デフォルトのプレゼンテーション フォントを除外
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


LinkAllFontsHtmlController を Java で実装し、コンパイルして \aspose.slides.via.java\lib\ に配置する必要があります。この Java コードは LinkAllFontsHtmlController の実装例です:
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
            String path = fontName + ".woff"; // パスのサニタイズが必要な場合があります
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
この JavaScript コードは、PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています:
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
Aspose.Slides for Node.js via Java を使用して、メディアファイルをエクスポートできます：

1. Presentation クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドにビデオを追加します。
4. プレゼンテーションを HTML ファイルとして書き出します。

この JavaScript コードは、プレゼンテーションにビデオを追加し、HTML として保存する方法を示しています:
```javascript
// プレゼンテーションの読み込み
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // HTML オプションの設定
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // ファイルの保存
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
パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理において高い効率性とスケーラビリティを備えています。多数のプレゼンテーションを変換する際は、可能な限りマルチスレッドまたは並列処理を使用することが推奨されます。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**  
はい、Aspose.Slides は埋め込まれたハイパーリンクの HTML へのエクスポートを完全にサポートしています。プレゼンテーションを HTML に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**  
Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、非常に多くのスライドを含むプレゼンテーションの場合、サーバーやシステムの利用可能なリソースに応じてパフォーマンスが影響を受けることがあります。