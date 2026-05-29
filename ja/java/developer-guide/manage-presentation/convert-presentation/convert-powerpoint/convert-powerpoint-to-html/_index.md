---
title: Java で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Java で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートします。"
---
## **概要**

Aspose.Slides for Java は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を読み込んで `save` を呼び出し、[SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) を指定するだけです。エクスポートしたレイアウト、フォント、画像、ノート、コメント、SVG 出力、リンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) を使用します。

このガイドでは、実践的な HTML エクスポートシナリオに焦点を当てます：

- プレゼンテーション全体または選択したスライドをエクスポートする。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成する。
- 発表者ノートとコメントを含める。
- 画像品質と切り抜き画像データを制御する。
- フォントを埋め込むか、フォントファイルを別々に保存する。
- 外部リソースやメディアファイルの書き込み方法と参照方法を選択する。

既定では、HTML エクスポートはほとんどのリソースが埋め込まれた単一の HTML ドキュメントを生成します。1 つのファイルで共有できるため便利ですが、出力サイズが大きくなる可能性があります。Web 公開の場合は、外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションをHTMLに変換**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) で読み込み、[SaveFormat.Html](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) で保存します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

この例は 1 つの HTML ファイルを書き込みます。`finally` ブロックでプレゼンテーション オブジェクトを破棄し、エクスポート後にファイル ハンドルとレンダリング リソースを解放します。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) は HTML エクスポート用の主要な構成クラスです。一般的な設定は以下のとおりです：

- `SlidesLayoutOptions`：ノート、コメント、配布資料、またはその他のレイアウト情報を追加します。
- `HtmlFormatter`：HTML ドキュメント構造を変更したり、フォーマッティングをコントローラに委譲したりします。
- `SlideImageFormat`：スライドの表現方法を変更します（例：SVG）。
- `PicturesCompression`：画像 DPI と出力サイズを制御します。
- `DeletePicturesCroppedAreas`：切り抜かれた画像データを保持または削除します。
- `SvgResponsiveLayout`：エクスポートされた SVG コンテンツをコンテナに適応させます。
- `ShowHiddenSlides`：必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローに必要なものだけを組み合わせて使用できます。

## **選択したスライドをHTMLに変換**

スライド番号を受け取る `Presentation.save` のオーバーロードは 1 ベースのスライド位置を使用します。以下のループは各スライドを個別の HTML ファイルに保存します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

ウェブサイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用します。各スライドが同じレイアウトであるべき場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) インスタンスを作成し、各 `save` 呼び出しに渡します。

## **レスポンシブHTMLの作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページをブラウザ幅により良く適応させる必要がある場合に使用してください。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG ベースのレスポンシブ レイアウトの場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) の `SvgResponsiveLayout` を設定します。スライド コンテンツをスケーラブルな SVG マークアップとしてエクスポートする場合に便利です。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **発表者ノートとコメントの含め方**

`HtmlOptions.setSlidesLayoutOptions` を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notescommentslayoutingoptions/) を使用し、発表者ノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示になっており、位置を指定しない限り表示されません。

元のプレゼンテーションに発表者ノートが含まれていると仮定します：

![PowerPoint のスライドに発表者ノートが付いた画像](slide_with_notes.png)

以下のコードはスライド コンテンツをスライドの下に発表者ノートを付けてエクスポートします。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

エクスポートされた HTML にはノート領域が含まれます：

![スライドと発表者ノートを含むHTML出力](HTML_with_notes.png)

コメントをエクスポートするには、`CommentsPosition` を設定します。例として `CommentsPositions.Right` や `CommentsPositions.Bottom` が使用できます。コメントのみが必要な場合は `NotesPosition` を省略してください。ノートとコメントの両方が必要な場合は、両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。より高い画像品質が必要な場合は、[PicturesCompression](https://reference.aspose.com/slides/ja/java/com.aspose.slides/picturescompression/) から取得できる `PicturesCompression` の値を設定してください。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

デフォルトでは、画像の切り抜き領域はエクスポート出力から削除されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合のみ、切り抜きデータを保持してください。保持すると HTML サイズが増加する可能性があります。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSSの追加**

簡易的なスタイリングが必要な場合は、CSS 文字列を `HtmlFormatter.createDocumentFormatter` に渡します。これにより、Aspose.Slides がスライド コンテンツのレンダリングを継続しながら、周囲の HTML ドキュメントを変更できます。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

カスタム ドキュメント ヘッダー、リンクされた CSS ファイル、またはスライドやシェイプ周りのカスタム マークアップが必要な場合は、[IHtmlFormattingController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihtmlformattingcontroller/) を実装し、`createCustomFormatter` とともに [HtmlFormatter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmlformatter/) に渡してください。

## **フォントの埋め込み**

対象環境にプレゼンテーションで使用されたフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/embedallfontshtmlcontroller/) を使用してフォントを HTML に埋め込みます。埋め込みにより視覚的忠実度は向上しますが、出力サイズが増加します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

フォントは、対象のブラウザやシステムがすでに提供していると確信できる場合にのみ除外してください。ブランド フォントや一般的でないフォントについては、埋め込みが通常は安全です。

## **フォントファイルをリンクして埋め込みを回避する方法**

HTML ファイルのサイズを削減するために、フォント データを個別の WOFF ファイルに書き出し、HTML に `@font-face` ルールを追加できます。以下のヘルパーは [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/embedallfontshtmlcontroller/) を拡張し、`writeFont` をオーバーライドしています。

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

この例ではフォント ファイルは `html-output/fonts` に保存され、HTML は `fonts/BrandFont-normal-400.woff` のような URL で参照します。HTML ファイルとフォントが別の場所にデプロイされる場合は、`fontUrlPrefix` を選択してデプロイ先の URL パスに合わせてください。

## **リソースを外部に保存**

自己完結型 HTML は移動が容易ですが、埋め込まれた Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、[ILinkEmbedController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) を実装し、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) のコンストラクタに渡してください。

リソースを外部化する際は、以下の 2 つのパスを明確に選択します：

- ファイル システム上の出力パス（アプリケーションが生成した画像、フォント、音声、動画を書き込む場所）。
- URL パス（HTML ドキュメントからブラウザがそれらのファイルを読み込む際に使用するパス）。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/videoplayerhtmlcontroller/) は動画および音声ファイルをエクスポートし、ブラウザで再生できる HTML を生成します。そのコンストラクタは次の引数を取ります：

- `path`：生成されたメディア ファイルを書き込むディレクトリ。
- `fileName`：生成される HTML ファイル名。
- `baseUri`：メディア ファイルへの HTML リンクで使用される絶対 URI プレフィックス。

HTML ファイルが `html-output/presentation.html`、メディア ファイルが `html-output/media` に保存される場合、`path` はディスク上のメディア ディレクトリを指し、`baseUri` はブラウザ側から見た同じディレクトリを指す必要があります。ローカル プレビューの場合は、`mediaDirectory.toUri().toString()` で `file:///` URI を構築できます。デプロイされたアプリケーションでは、公開されたメディア ディレクトリの絶対 URL を使用してください。

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

サーバー アプリケーションなどでは、エクスポート ジョブごとに一意の出力ディレクトリを使用してください。共有出力パスを使用すると、異なる変換からのファイルが上書きされる可能性があります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込まれたメディアに依存します。`PicturesCompression` の DPI 値を高くしたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度は向上しますが、通常は出力サイズが増加します。

バッチ変換の際は：

- 各 [Presentation] インスタンスは速やかに破棄してください。
- ジョブごとに別々の出力ディレクトリを使用してください。
- 必要な精度がない限り、一般的なフォントの埋め込みは避けてください。
- プレビューやサムネイル用の HTML では画像 DPI を下げてください。
- デプロイ先のパスが確定するまで、元のプレゼンテーション、生成された HTML、外部リソースを一緒に保管してください。

## **FAQ**

**HTML出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な限りクリック可能なままです。

**プレゼンテーションを並列でHTMLに変換できますか？**

はい、ただし 1 つの [Presentation] インスタンスをスレッド間で共有しないでください。異なるファイルは別々のプレゼンテーション インスタンス、別々のストリーム、別々の出力ディレクトリで処理します。詳細は [multithreading guidance](/slides/ja/java/multithreading/) を参照してください。

**Presentation オブジェクトはスレッドセーフですか？**

いいえ。単一の [Presentation] インスタンスは 1 つのスレッド上でロード、変更、保存、破棄する必要があります。並列作業を行う場合は、スレッドごとに独立したインスタンスを作成してください。

**生成されたHTMLファイルが大きいのはなぜですか？**

既定のエクスポートはリソースを HTML に直接埋め込むためです。埋め込まれたフォント、高 DPI 画像、メディア、SVG コンテンツ、保持された切り抜き画像領域などがサイズを増大させます。外部リソースを使用し、一般的なフォントの埋め込みを除外し、`PicturesCompression` を下げることで、最大忠実度よりもサイズを小さくすることができます。

**メディアエクスポートの baseUri はどのように選べばよいですか？**

ブラウザ側から見たパスを基準に絶対 URI を選択し、`baseUri` として渡してください。ローカル プレビューの場合は出力ディレクトリから `file:///` URI を作成できます。デプロイ時は公開されたメディア ディレクトリの絶対 URL を使用してください。ファイルシステムの `path` とブラウザの `baseUri` は文字列として同一である必要はありませんが、同じリソース位置を指す必要があります。

**非表示スライドを含められますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/) の `ShowHiddenSlides` を `true` に設定してください。