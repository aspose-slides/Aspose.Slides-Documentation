---
title: PHP で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "PHP で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートできます。"
---
## **概要**

Aspose.Slides for PHP via Java は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、単一の [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) の読み込みと、[SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) を使用した `save` 呼び出しです。エクスポートされたレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) を使用します。

このガイドでは実用的な HTML エクスポートシナリオに焦点を当てます：

- プレゼンテーション全体または選択したスライドをエクスポートする。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成する。
- スピーカーノートとコメントを含める。
- 画像品質と切り抜かれた画像データを制御する。
- フォントを埋め込むか、フォントファイルを別々に保存する。
- 外部リソースやメディアファイルの書き込みおよび参照方法を選択する。

デフォルトでは、HTML エクスポートはほとんどのリソースが埋め込まれた単一の HTML ドキュメントを生成します。これは 1 つのファイルで共有するのに便利ですが、出力サイズが大きくなる可能性があります。Web 公開の場合は、外部リソースの使用、画像 DPI の低減、およびターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションを HTML に変換する**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) で読み込み、[SaveFormat.Html](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) で保存します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

この例は 1 つの HTML ファイルを書き出します。プレゼンテーションオブジェクトは `finally` ブロックで破棄され、エクスポート後にファイルハンドルとレンダリングリソースが解放されます。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) は HTML エクスポートの主要な設定クラスです。一般的な設定は次のとおりです。

- `SlidesLayoutOptions`: ノート、コメント、配布資料、またはその他のレイアウト情報を追加します。
- `HtmlFormatter`: HTML ドキュメントの構造を変更したり、フォーマッティングをコントローラーに委任したりします。
- `SlideImageFormat`: スライドの表現方法を変更します。例として SVG があります。
- `PicturesCompression`: 画像の DPI と出力サイズを制御します。
- `DeletePicturesCroppedAreas`: 切り抜かれた画像データを保持または削除します。
- `SvgResponsiveLayout`: エクスポートされた SVG コンテンツがコンテナに適応するようにします。
- `ShowHiddenSlides`: 必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローで必要なものだけを組み合わせて使用できます。

## **選択したスライドを HTML に変換する**

`save` のオーバーロードでスライド番号を受け取る場合は、1 から始まるスライド位置を使用します。以下のループは各スライドを別々の HTML ファイルに保存します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

ウェブサイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用します。各スライドが同じレイアウトである場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) インスタンスを作成し、各 `save` 呼び出しに渡します。

## **レスポンシブ HTML の作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/php-java/aspose.slides/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmlformatter/) を介してレスポンシブ HTML 出力を提供します。エクスポートされたページがブラウザ幅により適切に適応する必要がある場合に使用します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

SVG ベースのレスポンシブレイアウトの場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) の `SvgResponsiveLayout` を設定します。スライドコンテンツがスケーラブルな SVG マークアップとしてエクスポートされる場合に便利です。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **スピーカーノートとコメントの含め方**

`HtmlOptions.SlidesLayoutOptions` を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/) を使用し、スピーカーノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示で、位置を指定しない限り表示されません。

ソースプレゼンテーションにスピーカーノートが含まれているとします：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

以下のコードはスライドコンテンツをスライド下部にスピーカーノートを付けてエクスポートします。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

エクスポートされた HTML にはノート領域が含まれます：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

コメントをエクスポートするには、`CommentsPosition` を設定します。例えば `CommentsPositions.Right` または `CommentsPositions.Bottom` です。コメントだけが必要な場合は `NotesPosition` を省略します。ノートとコメントの両方が必要な場合は、両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを減らすことができます。より高い画像品質が必要な場合は、[PicturesCompression](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturescompression/) の値で `PicturesCompression` を設定します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

デフォルトでは、画像の切り抜き領域はエクスポート結果から削除されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合にのみ切り抜きデータを保持してください。保持すると HTML のサイズが増加する可能性があります。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **CSS の追加**

簡単なスタイリングの場合は、`createDocumentFormatter` を介して CSS 文字列を [HtmlFormatter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmlformatter/) に渡します。これにより、Aspose.Slides がスライドコンテンツのレンダリングを続けながら、周囲の HTML ドキュメントが変更されます。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

カスタムドキュメントヘッダー、リンクされた CSS ファイル、またはスライドやシェイプ周辺のカスタムマークアップが必要な場合は、カスタムフォーマッティングコントローラーを使用し、`createCustomFormatter` で [HtmlFormatter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmlformatter/) に渡します。

## **フォントの埋め込み**

ターゲット環境にプレゼンテーションのフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/php-java/aspose.slides/embedallfontshtmlcontroller/) を使用して HTML にフォントを埋め込みます。埋め込むことで視覚的忠実度が向上しますが、出力サイズが増加します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

ターゲットのブラウザーやシステムが既にフォントを提供していると確信できる場合にのみ、フォントを除外してください。ブランドフォントやあまり一般的でないフォントについては、埋め込みが通常安全です。

## **フォントファイルをリンクして埋め込みを回避する**

HTML ファイルサイズを削減するために、フォントデータを別々の WOFF ファイルに書き出し、HTML に `@font-face` ルールを追加できます。PHP via Java では、このシナリオは通常、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/php-java/aspose.slides/embedallfontshtmlcontroller/) を拡張した小さな Java ヘルパークラスで実装され、フォントバイトを出力ディレクトリに書き込み、生成された HTML に `@font-face` ルールを注入します。そのヘルパーをコンパイルし、PHP Java Bridge のクラスパスに追加し、PHP から `new Java(...)` でインスタンス化します。

そのようなヘルパーを作成する際は、意図的に 2 つのパスを選択してください：

- ファイルシステムの出力パス：生成されたフォントファイルが書き込まれる場所。
- URL パス：ブラウザーが HTML ドキュメントからフォントファイルを読み込む際に使用するパス。

## **リソースを外部に保存する**

自己完結型 HTML は移動が容易ですが、埋め込まれた Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) のコンストラクタにカスタムリンク/埋め込みコントローラーを提供します。

リソースを外部化する際は、意図的に 2 つのパスを選択してください：

- ファイルシステムの出力パス：アプリケーションが生成した画像、フォント、音声、または動画を書き込む場所。
- URL パス：ブラウザーが HTML ドキュメントからそれらのファイルを読み込む際に使用するパス。

これらのパスをデプロイメントレイアウトと一致させておくことで、生成された HTML がウェブサーバーや別のディレクトリに移動された後でも外部リソースを正しく読み込めます。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/php-java/aspose.slides/videoplayerhtmlcontroller/) はビデオとオーディオファイルをエクスポートし、ブラウザーで再生できる HTML を生成します。そのコンストラクタは以下を受け取ります：

- `path`: 生成された HTML とメディアファイルが使用する出力ディレクトリ。
- `fileName`: 生成中の HTML ファイル名。
- `baseUri`: メディアファイルへの HTML リンクで使用される絶対 URI プレフィックス。

HTML ファイルが `html-output/presentation.html` の場合、`path` は `html-output` を指し、`baseUri` はブラウザーから見た同じディレクトリを指す必要があります。ローカルプレビューの場合は、出力ディレクトリから `file:///` URI を作成できます。デプロイされたアプリケーションでは、公開された出力ディレクトリの絶対 URL を使用してください。

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

特にサーバーアプリケーションでは、エクスポートジョブごとに固有の出力ディレクトリを使用してください。共有出力パスを使用すると、異なる変換からのファイルが相互に上書きされる可能性があります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。`PicturesCompression` の DPI 値を高くしたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度が向上しますが、通常は出力サイズが増加します。

バッチ変換の場合：

- `Presentation` インスタンスは速やかに破棄してください。
- ジョブごとに別々の出力ディレクトリを使用してください。
- 忠実度が必要でない限り、一般的なフォントの埋め込みは避けてください。
- HTML がプレビューやサムネイル用の場合は、画像 DPI を下げてください。
- デプロイパスが最終決定になるまで、ソースプレゼンテーション、生成された HTML、外部リソースを一緒に保管してください。

## **FAQ**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な場合はクリック可能なままです。

**プレゼンテーションを並行して HTML に変換できますか？**

はい、可能ですが、スレッド間で単一の [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを共有しないでください。別々のプレゼンテーションインスタンス、別々のストリーム、別々の出力ディレクトリで異なるファイルを処理してください。

**Presentation オブジェクトはスレッド セーフですか？**

いいえ。単一の [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスは 1 つのスレッドで読み込み、変更、保存、破棄するべきです。並列処理を行う場合は、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きいのはなぜですか？**

デフォルトのエクスポートではリソースが HTML に直接埋め込まれます。埋め込みフォント、高 DPI 画像、メディア、SVG コンテンツ、切り抜き画像領域の保持もサイズを増加させます。サイズを小さくしたい場合は外部リソースを使用し、一般的なフォントの埋め込みを除外し、`PicturesCompression` を下げてください。

**メディアエクスポートの baseUri はどのように選択すべきですか？**

`baseUri` はブラウザーから見た視点で選択し、絶対 URI として渡してください。ローカルプレビューの場合は、Java のファイル URI を使用して出力ディレクトリから導出できます。デプロイ時は、公開されたメディアディレクトリの絶対 URL を使用します。ファイルシステムの `path` とブラウザーの `baseUri` は同じ文字列である必要はありませんが、同じリソース位置を指し示す必要があります。

**非表示スライドを含めることはできますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) の `ShowHiddenSlides` を `true` に設定してください。