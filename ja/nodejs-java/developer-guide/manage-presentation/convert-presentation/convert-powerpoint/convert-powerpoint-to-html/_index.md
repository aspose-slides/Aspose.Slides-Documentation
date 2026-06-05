---
title: Node.js で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
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
description: "Node.js で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides for Node.js via Java を使用して、PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートします。"
---
## **概要**

Aspose.Slides for Node.js via Java は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は単一の [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) の読み込みと、[SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) を使用した `save` 呼び出しです。エクスポートするレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は [HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) を使用してください。

このガイドは実用的な HTML エクスポートシナリオに焦点を当てます：

- プレゼンテーション全体または選択したスライドのエクスポート
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML の生成
- スピーカーノートとコメントの含め方
- 画像品質と切り抜き画像データの制御
- フォントの埋め込みまたはフォントファイルを別途保存
- 外部リソースやメディアファイルの書き込み方法と参照方法の選択

デフォルトでは、HTML エクスポートはほとんどのリソースが埋め込まれた自己完結型 HTML ドキュメントを生成します。これは 1 つのファイルで共有できて便利ですが、出力サイズが大きくなる可能性があります。Web 公開の場合は、外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用可能でないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションをHTMLに変換**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) で読み込み、[SaveFormat.Html](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) で保存します。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

この例は 1 つの HTML ファイルを書き込みます。プレゼンテーションオブジェクトは `finally` ブロックで破棄され、エクスポート後にファイルハンドルとレンダリングリソースが解放されます。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) は HTML エクスポート用の主要な構成クラスです。一般的な設定は次のとおりです：

- `SlidesLayoutOptions`: ノート、コメント、配布資料、その他のレイアウト情報を追加
- `HtmlFormatter`: HTML ドキュメント構造を変更したり、フォーマッタをコントローラに委譲したり
- `SlideImageFormat`: スライドの表現方法を変更、例として SVG
- `PicturesCompression`: 画像 DPI と出力サイズを制御
- `DeletePicturesCroppedAreas`: 切り抜き画像データを保持または削除
- `SvgResponsiveLayout`: エクスポートされた SVG コンテンツをコンテナに適応させる
- `ShowHiddenSlides`: 必要に応じて非表示スライドを含める

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローに必要なものだけを組み合わせて使用できます。

## **選択したスライドをHTMLに変換**

スライド番号を受け取る `Presentation.save` のオーバーロードは 1 ベースのスライド位置を使用します。以下のループは各スライドを個別の HTML ファイルとして保存します。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Web サイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用してください。すべてのスライドで同じレイアウトを使用する場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) インスタンスを作成し、各 `save` 呼び出しに渡します。

## **レスポンシブHTMLの作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページをブラウザ幅により適切に適応させる必要がある場合に使用してください。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG ベースのレスポンシブレイアウトを使用する場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) の `SvgResponsiveLayout` を設定します。これはスライド内容がスケーラブルな SVG マークアップとしてエクスポートされる場合に便利です。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **スピーカーノートとコメントの含め方**

`HtmlOptions.setSlidesLayoutOptions` で [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notescommentslayoutingoptions/) を使用し、スピーカーノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示で、位置を指定しない限り表示されません。

ソースプレゼンテーションにスピーカーノートが含まれているとします：

![PowerPoint のスピーカーノート付きスライド](slide_with_notes.png)

以下のコードはスライドコンテンツをスライド下部にノートを付けてエクスポートします。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

エクスポートされた HTML にはノート領域が含まれます：

![HTML 出力（スライドとスピーカーノート）](HTML_with_notes.png)

コメントをエクスポートするには `CommentsPosition` を設定します。例として `CommentsPositions.Right` または `CommentsPositions.Bottom` を使用できます。コメントだけが必要な場合は `NotesPosition` を省略してください。ノートとコメントの両方が必要な場合は両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。より高い画像品質が必要なときは、[PicturesCompression](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturescompression/) から適切な値を設定してください。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

デフォルトでは、画像の切り抜き領域はエクスポート結果から削除されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合にのみ切り抜きデータを保持してください。保持すると HTML サイズが増加します。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSSの追加**

シンプルなスタイリングの場合、`HtmlFormatter.createDocumentFormatter` に CSS 文字列を渡します。これにより Aspose.Slides がスライドコンテンツの描画を続行しながら、周囲の HTML ドキュメントを変更できます。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

カスタムドキュメントヘッダー、リンクされた CSS ファイル、またはスライドやシェイプの周囲にカスタムマークアップを追加したい場合は、[HtmlFormatter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmlformatter/) とフォーマットコントローラを使用してください。

## **フォントの埋め込み**

ターゲット環境にプレゼンテーションで使用したフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) を使用してフォントを HTML に埋め込みます。埋め込みは視覚的忠実度を向上させますが、出力サイズが大きくなります。

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

フォントがすでにターゲットのブラウザやシステムに存在すると確信できる場合のみ埋め込みを除外してください。ブランドフォントや一般的でないフォントについては、埋め込みが安全です。

## **フォントファイルをリンクで埋め込まずに使用**

HTML ファイルサイズを削減するために、フォントデータを別個の WOFF ファイルに書き出し、HTML に `@font-face` ルールを追加できます。Node.js via Java では、通常 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) を拡張した小さな Java ヘルパークラスを作成し、フォントバイトを書き出し、生成された HTML に `@font-face` ルールを注入します。そのヘルパーをコンパイルし、Node.js モジュールのクラスパスに追加し、`java.newInstanceSync` で JavaScript からインスタンス化してください。

ヘルパーを構築するときは、次の 2 つのパスを意図的に選択します：

- ファイルシステムの出力パス：生成されたフォントファイルを書き込む場所
- URL パス：ブラウザが HTML ドキュメントからフォントファイルを取得するために使用するパス

## **リソースを外部に保存**

自己完結型 HTML は移動が簡単ですが、Base64 埋め込みリソースによりファイルが大きくなることがあります。アプリケーションで外部画像、フォント、音声、ビデオファイルが必要な場合は、リソースを書き出しディレクトリに保存し、ブラウザが参照できる URL を生成するエクスポートコントローラを使用してください。ファイルシステムパスと URL パスをデプロイ環境のレイアウトに合わせて整合させます。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) はビデオおよびオーディオファイルをエクスポートし、ブラウザで再生できる HTML を生成します。そのコンストラクタは次のパラメータを受け取ります：

- `path`: 生成されたメディアファイルを書き出すディレクトリ
- `fileName`: 生成中の HTML ファイル名
- `baseUri`: HTML 内のメディアファイルへのリンクに使用する絶対 URI プレフィックス

HTML ファイルが `html-output/presentation.html`、メディアファイルが `html-output/media` に保存される場合、`path` はディスク上のメディアディレクトリを指し、`baseUri` はブラウザ側から同じディレクトリを指す URL である必要があります。ローカルプレビューの場合はメディアディレクトリから `file:///` URI を作成できます。デプロイされたアプリケーションでは、公開メディアディレクトリの絶対 URL を使用してください。

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

特にサーバーアプリケーションでは、エクスポートジョブごとに一意の出力ディレクトリを使用してください。共有出力パスは異なる変換間でファイルが上書きされる原因になります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング処理であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。`PicturesCompression` の DPI 値を上げたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度は向上しますが、通常は出力サイズが大きくなります。

バッチ変換の際は：

- 各 [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを速やかに破棄する
- ジョブごとに別々の出力ディレクトリを使用する
- 必要な場合以外は共通フォントを埋め込まない
- プレビューやサムネイル用の HTML では画像 DPI を下げる
- ソースプレゼンテーション、生成された HTML、外部リソースをデプロイパスが確定するまで一緒に保管する

## **FAQ**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な限りクリック可能です。

**プレゼンテーションを並列に HTML に変換できますか？**

はい、ただし 1 つの [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスをワーカー間で共有しないでください。異なるファイルは別々のプレゼンテーションインスタンス、別々のストリーム、別々の出力ディレクトリで処理します。詳細は [multithreading guidance](/slides/ja/nodejs-java/multithreading/) を参照してください。

**Presentation オブジェクトはスレッドセーフですか？**

いいえ。単一の [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスは 1 つのワーカー内で読み込み、変更、保存、破棄を行うべきです。並列処理を行う場合は、ワーカーごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きくなるのはなぜですか？**

デフォルトのエクスポートはリソースを HTML に直接埋め込むためです。埋め込まれたフォント、高 DPI 画像、メディア、SVG コンテンツ、切り抜き画像領域の保持もサイズを増大させます。外部リソースを使用し、共通フォントの埋め込みを除外し、`PicturesCompression` を下げることで、サイズを小さくできます。

**メディアエクスポートの baseUri はどう決めればよいですか？**

ブラウザ側の視点からの URI を absolute に指定してください。ローカルプレビューの場合は出力ディレクトリから `file:///` URI を作成できます。デプロイ時は公開メディアディレクトリの絶対 URL を使用します。ファイルシステムの `path` とブラウザの `baseUri` は文字列が同一である必要はありませんが、同じリソース位置を指す必要があります。

**非表示スライドを含めることはできますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) の `ShowHiddenSlides` を `true` に設定してください。