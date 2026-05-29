---
title: Android で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/androidjava/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーション を HTML に変換
- スライド を HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーション を HTML として保存
- スライド を HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- Android
- Java
- Aspose.Slides
description: "Android 上で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides for Android via Java を使用して、PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートします。"
---
## **概要**

Aspose.Slides for Android via Java は、Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、単一の [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) のロードと、[SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) を使用した `save` 呼び出しです。エクスポートされるレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/) を使用します。

このガイドは実用的な HTML エクスポートシナリオに焦点を当てます：

- プレゼンテーション全体または選択したスライドをエクスポートする。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成する。
- スピーカー ノートとコメントを含める。
- 画像品質と切り抜かれた画像データを制御する。
- フォントを埋め込むか、フォントファイルを別々に保存する。
- 外部リソースとメディア ファイルの書き込みおよび参照方法を選択する。

デフォルトでは、HTML エクスポートはほとんどのリソースが埋め込まれた自己完結型の HTML ドキュメントを生成します。これは 1 つのファイルを共有するのに便利ですが、出力サイズが増加する可能性があります。Web 発行の場合は、外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションを HTML に変換する**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) でロードし、[SaveFormat.Html](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) で保存します。

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

[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/) は HTML エクスポートの主要な構成クラスです。一般的な設定は次のとおりです。

- `SlidesLayoutOptions`: ノート、コメント、配布資料、またはその他のレイアウト情報を追加します。
- `HtmlFormatter`: HTML ドキュメントの構造を変更するか、コントローラにフォーマット処理を委譲します。
- `SlideImageFormat`: スライドの表現方法を変更します。例として SVG が挙げられます。
- `PicturesCompression`: 画像の DPI と出力サイズを制御します。
- `DeletePicturesCroppedAreas`: 切り抜かれた画像データを保持または削除します。
- `SvgResponsiveLayout`: エクスポートされた SVG コンテンツがコンテナに合わせて適応するようにします。
- `ShowHiddenSlides`: 必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローに必要なものだけを組み合わせて使用できます。

## **選択したスライドを HTML に変換する**

スライド番号を受け取る `Presentation.save` のオーバーロードは 1 ベースのスライド位置を使用します。以下のループは各スライドを別々の HTML ファイルとして保存します。

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

ウェブサイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用します。各スライドが同じレイアウトである必要がある場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/) インスタンスを作成し、各 `save` 呼び出しに渡します。

## **レスポンシブ HTML の作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページがブラウザ幅により適切に適応する必要がある場合に使用してください。

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

SVG ベースのレスポンシブレイアウトの場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/) で `SvgResponsiveLayout` を設定します。スライド内容がスケーラブルな SVG マークアップとしてエクスポートされる場合に有用です。

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

## **スピーカー ノートとコメントの含め方**

`HtmlOptions.SlidesLayoutOptions` を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notescommentslayoutingoptions/) を使用すると、スピーカー ノートやコメントを含めることができます。デフォルトではノートとコメントは非表示で、位置を指定しない限り出力されません。

ソースのプレゼンテーションにスピーカー ノートが含まれているとします：

![PowerPoint のスピーカーノート付きスライド](slide_with_notes.png)

以下のコードはスライドの下にスピーカー ノートを付加してエクスポートします。

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

![スライドとスピーカーノートを含む HTML 出力](HTML_with_notes.png)

コメントをエクスポートするには、`CommentsPosition` を設定します（例: `CommentsPositions.Right` または `CommentsPositions.Bottom`）。コメントだけが必要な場合は `NotesPosition` を省略します。ノートとコメントの両方が必要な場合は、両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。高品質な画像が必要な場合は、[PicturesCompression](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/picturescompression/) のいずれかの値を `PicturesCompression` に設定します。

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

デフォルトでは、画像の切り抜き領域はエクスポート出力から削除されることがあります。ユーザーが隠れた画像部分を復元または調査できる必要がある場合にのみ切り抜きデータを保持してください。保持すると HTML サイズが増加する可能性があります。

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

## **CSS の追加**

簡易的なスタイリングの場合は、CSS 文字列を `HtmlFormatter.createDocumentFormatter` に渡します。これにより、Aspose.Slides がスライド コンテンツのレンダリングを続行しながら、周囲の HTML ドキュメントを変更できます。

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

カスタム ドキュメント ヘッダー、リンクされた CSS ファイル、またはスライドやシェイプ周辺のカスタム マークアップが必要な場合は、[IHtmlFormattingController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihtmlformattingcontroller/) を実装し、`createCustomFormatter` と共に [HtmlFormatter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmlformatter/) に渡します。

## **フォントの埋め込み**

対象環境にプレゼンテーションのフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) を使用して HTML にフォントを埋め込みます。埋め込むことで視覚的忠実度は向上しますが、出力サイズは増加します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

フォントがターゲットのブラウザやシステムにすでに提供されていると確信できる場合にのみ除外してください。ブランド フォントや一般的でないフォントについては、埋め込みが通常は安全です。

## **フォントファイルへのリンク（埋め込みではなく）**

HTML ファイルサイズを削減するために、フォント データを個別の WOFF ファイルに書き込み、HTML に `@font-face` ルールを追加できます。以下のヘルパーは [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) を拡張し、`writeFont` をオーバーライドしています。

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

この例ではフォント ファイルは `html-output/fonts` に保存され、HTML は `fonts/BrandFont-normal-400.woff` などの URL で参照します。HTML ファイルとフォントを別の場所にデプロイする場合は、`fontUrlPrefix` をデプロイされた URL パスに合わせて選択してください。

## **リソースを外部に保存する**

自己完結型 HTML は移動が容易ですが、埋め込まれた Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、[ILinkEmbedController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) を実装し、[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/) コンストラクタに渡します。

リソースを外部化する際は、以下の 2 つのパスを意図的に選択します：

- ファイルシステム出力パス：アプリケーションが生成した画像、フォント、音声、動画を書き込む場所。
- URL パス：ブラウザが HTML ドキュメントからこれらのファイルを読み込む際に使用するパス。

## **メディア ファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) は動画と音声ファイルをエクスポートし、ブラウザで再生できる HTML を生成します。そのコンストラクタは次のパラメータを受け取ります：

- `path`: 生成されたメディア ファイルが書き込まれるディレクトリ。
- `fileName`: 生成される HTML ファイル名。
- `baseUri`: HTML のメディア ファイルへのリンクで使用される絶対 URI プレフィックス。

HTML ファイルが `html-output/presentation.html`、メディア ファイルが `html-output/media` に保存される場合、`path` はディスク上のメディア ディレクトリを指し、`baseUri` はブラウザから見た同じディレクトリを指す必要があります。ローカル プレビュー用にはメディア ディレクトリから `file:///` URI を構築できます。デプロイされたアプリケーションの場合は、公開されたメディア ディレクトリの絶対 URL を使用してください。

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

エクスポート ジョブごとに一意の出力ディレクトリを使用してください。サーバー アプリケーションでは特に重要です。共有出力パスを使用すると、異なる変換のファイルが上書きされる可能性があります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。`PicturesCompression` の DPI 値を高くしたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度は向上しますが、通常は出力サイズが増加します。

バッチ変換の際のポイント：

- すべての [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを速やかに破棄する。
- ジョブごとに別々の出力ディレクトリを使用する。
- 忠実度が必要でない限り、一般的なフォントの埋め込みを避ける。
- HTML がプレビューやサムネイル用の場合は、画像 DPI を下げる。
- ソースのプレゼンテーション、生成された HTML、外部リソースは、デプロイ パスが確定するまで一緒に保管する。

## **FAQ**

**Are hyperlinks preserved in HTML output?**  
はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な場合はクリック可能な状態で残ります。

**Can I convert presentations to HTML in parallel?**  
はい。ただし、1 つの [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。異なるファイルは別々のプレゼンテーション インスタンス、別々のストリーム、別々の出力ディレクトリで処理します。詳細は [multithreading guidance](/slides/ja/androidjava/multithreading/) を参照してください。

**Is a Presentation object thread-safe?**  
いいえ。単一の [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスは、ロード、変更、保存、破棄を同一スレッド上で行う必要があります。並列処理が必要な場合は、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**Why is the generated HTML file large?**  
デフォルトのエクスポートはリソースを HTML に直接埋め込むため、ファイルが大きくなることがあります。埋め込みフォント、高 DPI 画像、メディア、SVG コンテンツ、切り抜き画像領域の保持もサイズ増加の要因です。外部リソースを使用し、共通フォントの埋め込みを除外し、`PicturesCompression` を下げることで、サイズを小さくできます。

**How should I choose baseUri for media export?**  
`baseUri` はブラウザ視点でのパスを基に絶対 URI として設定してください。ローカル プレビューの場合は、出力ディレクトリから `mediaDirectory.toUri().toString()` で導出できます。デプロイ時は、公開されたメディア ディレクトリの絶対 URL を使用します。ファイルシステムの `path` とブラウザの `baseUri` が同一文字列である必要はありませんが、同じリソース位置を指す必要があります。

**Can I include hidden slides?**  
はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/) の `ShowHiddenSlides` を `true` に設定します。