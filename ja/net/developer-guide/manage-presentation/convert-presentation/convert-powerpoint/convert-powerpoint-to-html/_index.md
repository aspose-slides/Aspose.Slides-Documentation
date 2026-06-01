---
title: .NET で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint から HTML へ
type: docs
weight: 30
url: /ja/net/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint から HTML へ
- プレゼンテーションから HTML へ
- スライドから HTML へ
- PPT から HTML へ
- PPTX から HTML へ
- PowerPoint を HTML として保存
- プレゼンテーション を HTML として保存
- スライド を HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- .NET
- C#
- Aspose.Slides
description: ".NET で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択スライド、ノート、フォント、画像、SVG、メディアをエクスポートします。"
---
## **概要**

Aspose.Slides for .NET は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) のロードと [Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) の呼び出しを [SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) と共に行うだけです。エクスポートするレイアウト、フォント、画像、ノート、コメント、SVG 出力、リンクリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/) を使用します。

このガイドは実用的な HTML エクスポートシナリオに焦点を当てています:

- プレゼンテーション全体または選択したスライドをエクスポートします。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成します。
- 発表者ノートとコメントを含めます。
- 画像品質と切り抜き画像データを制御します。
- フォントを埋め込むか、フォントファイルを別々に保存します。
- 外部リソースとメディアファイルの書き出し方法と参照方法を選択します。

既定では、HTML エクスポートはほとんどのリソースが埋め込まれた自己完結型 HTML ドキュメントを生成します。ファイル 1 つで共有できるので便利ですが、出力サイズが大きくなる可能性があります。ウェブ公開の場合は、外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションを HTML に変換**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) でロードし、[SaveFormat.Html](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) で保存します。

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

この例は 1 つの HTML ファイルを書き出します。`using` 宣言によりプレゼンテーションオブジェクトが破棄され、エクスポート後にファイルハンドルとレンダリングリソースが解放されます。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/) は HTML エクスポートのメイン構成クラスです。一般的な設定は以下のとおりです:

- `SlidesLayoutOptions`: ノート、コメント、配布資料、またはその他のレイアウト情報を追加します。
- `HtmlFormatter`: HTML ドキュメントの構造を変更したり、フォーマット処理をコントローラに委譲したりします。
- `SlideImageFormat`: スライドの表現方法を変更します。例: SVG として出力。
- `PicturesCompression`: 画像の DPI と出力サイズを制御します。
- `DeletePicturesCroppedAreas`: 切り抜かれた画像データを保持または削除します。
- `SvgResponsiveLayout`: エクスポートされた SVG コンテンツがコンテナに合わせて適応するようにします。
- `ShowHiddenSlides`: 必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示します。ワークフローで必要なものだけを組み合わせて使用できます。

## **選択したスライドを HTML に変換**

スライド番号を受け取る [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) のオーバーロードは 1 から始まるスライド位置を使用します。以下のループは各スライドを別々の HTML ファイルに保存します。

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

ウェブサイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用します。各スライドが同じレイアウトであるべき場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/) インスタンスを作成し、各 `Save` 呼び出しに渡します。

## **レスポンシブ HTML の作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページをブラウザ幅により適切に適応させたいときに使用します。

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

SVG ベースのレスポンシブレイアウトの場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/) で `SvgResponsiveLayout` を設定します。スライド内容がスケーラブルな SVG マークアップとしてエクスポートされる場合に便利です。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **発表者ノートとコメントの含め方**

`HtmlOptions.SlidesLayoutOptions` 経由で [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notescommentslayoutingoptions/) を使用すると、発表者ノートまたはコメントを含めることができます。ノートとコメントはデフォルトで非表示で、位置を指定しなければ表示されません。

元のプレゼンテーションに発表者ノートが含まれているとします:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

以下のコードはスライドコンテンツをスライド下に発表者ノートを付けてエクスポートします。

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

コメントをエクスポートするには、`CommentsPosition` を設定します。例: `CommentsPositions.Right` または `CommentsPositions.Bottom`。コメントだけが必要な場合は `NotesPosition` を省略します。ノートとコメントの両方が必要な場合は両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。高画質が必要なときは、[PicturesCompression](https://reference.aspose.com/slides/ja/net/aspose.slides.export/picturescompression/) から適切な `PicturesCompression` 値を設定します。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

既定では、画像の切り抜き領域はエクスポート結果から除去されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合にのみ切り抜きデータを保持してください。保持すると HTML サイズが増加します。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **CSS の追加**

シンプルなスタイリングの場合、CSS 文字列を [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmlformatter/createdocumentformatter/) に渡します。これにより Aspose.Slides がスライドコンテンツの描画を続けながら、周囲の HTML ドキュメントが変更されます。

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

カスタムドキュメントヘッダー、リンクされた CSS ファイル、スライドやシェイプ周囲のカスタムマークアップが必要な場合は、[IHtmlFormattingController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ihtmlformattingcontroller/) を実装し、`CreateCustomFormatter` と共に [HtmlFormatter](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmlformatter/) に渡します。

## **フォントの埋め込み**

対象環境にプレゼンテーションで使用したフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/embedallfontshtmlcontroller/) でフォントを HTML に埋め込みます。埋め込みは視覚的な忠実度を向上させますが、出力サイズが大きくなります。

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

ターゲットのブラウザやシステムが既にフォントを提供していると確信できる場合にのみフォントを除外してください。ブランドフォントやあまり一般的でないフォントは、埋め込む方が安全です。

## **フォントファイルを埋め込まずにリンク**

HTML ファイルサイズを削減するため、フォントデータを別々の WOFF ファイルに書き出し、HTML に `@font-face` ルールを追加できます。以下のヘルパーは [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/embedallfontshtmlcontroller/) を拡張し、`WriteFont` をオーバーライドします。

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

この例ではフォントファイルは `html-output/fonts` に保存され、HTML は `fonts/BrandFont-normal-400.woff` などの URL で参照します。HTML ファイルとフォントを別の場所にデプロイする場合は、`fontUrlPrefix` をデプロイ先の URL パスに合わせて設定してください。

## **リソースを外部に保存**

自己完結型 HTML は移動が容易ですが、埋め込み Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、[ILinkEmbedController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/) を実装し、[HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/htmloptions/) コンストラクタに渡します。

リソースを外部化するときは、次の 2 つのパスを意図的に選択します:

- ファイルシステムの出力パス（アプリケーションが生成した画像、フォント、音声、動画を書き込む場所）。
- URL パス（HTML ドキュメントからブラウザがこれらのファイルを読み込む際に使用するパス）。

フル画像リンク実装の例は、[Export Presentations to HTML with Externally Linked Images](/slides/ja/net/exporting-presentations-to-html-with-externally-linked-images/) を参照してください。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/videoplayerhtmlcontroller/) は動画と音声ファイルをエクスポートし、ブラウザで再生できる HTML を生成します。コンストラクタは次のパラメータを受け取ります:

- `path`: 生成されたメディアファイルが書き込まれるディレクトリ。
- `fileName`: 生成中の HTML ファイル名。
- `baseUri`: メディアファイルへの HTML リンクで使用される絶対 URI プレフィックス。

HTML ファイルが `html-output/presentation.html` でメディアファイルが `html-output/media` に保存される場合、`path` はディスク上のメディアディレクトリを指し、`baseUri` はブラウザ側から見た同じディレクトリを指す必要があります。ローカルプレビューの場合はメディアディレクトリから `file:///` URI を作成できます。デプロイされたアプリケーションでは、公開メディアディレクトリの絶対 URL を使用してください。

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

エクスポートジョブごとに固有の出力ディレクトリを使用してください。特にサーバーアプリケーションでは、共有出力パスにより異なる変換のファイルが上書きされる恐れがあります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であり、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。`PicturesCompression` の DPI 値を高くしたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度は向上しますが、通常は出力サイズが増加します。

バッチ変換のポイント:

- `[Presentation]` インスタンスはすぐに破棄してください。
- ジョブごとに別々の出力ディレクトリを使用します。
- 品質上必要でない限り、一般的なフォントの埋め込みは避けます。
- プレビューやサムネイル用の HTML では画像 DPI を下げます。
- デプロイ先が確定するまで、元のプレゼンテーション、生成された HTML、外部リソースを一緒に保管します。

## **よくある質問**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な場合はクリック可能です。

**プレゼンテーションを並列に HTML に変換できますか？**

はい、ただし 1 つの [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。別々のファイルは別々のプレゼンテーションインスタンス、別々のストリーム、別々の出力ディレクトリで処理します。詳細は [multithreading guidance](/slides/ja/net/multithreading/) を参照してください。

**Presentation オブジェクトはスレッドセーフですか？**

いいえ。単一の [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスは 1 つのスレッド上でロード、変更、保存、破棄する必要があります。並列処理が必要な場合は、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きいのはなぜですか？**

既定のエクスポートはリソースを HTML に直接埋め込むためです。埋め込みフォント、高 DPI 画像、メディア、SVG コンテンツ、切り抜き画像領域の保持はサイズを増加させます。外部リソースを使用し、一般的なフォントの埋め込みを除外し、`PicturesCompression` を下げることで、サイズを小さくできます。

**メディアエクスポート用の baseUri はどのように選択すべきですか？**

ブラウザ側から見た基準 URI を絶対 URI として設定し、`baseUri` に渡してください。ローカルプレビューの場合は `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` で取得できます。デプロイ時は公開メディアディレクトリの絶対 URL を使用します。`path` と `baseUri` は文字列として同一である必要はありませんが、同じリソース位置を指す必要があります。

**非表示スライドを含めることはできますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/) の `ShowHiddenSlides = true` を設定してください。