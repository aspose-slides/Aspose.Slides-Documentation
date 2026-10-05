---
title: PHPでプレゼンテーションをHTML5に変換
linktitle: プレゼンテーションをHTML5へ
type: docs
weight: 40
url: /ja/php-java/export-to-html5/
keywords:
- PowerPointをHTML5へ
- OpenDocumentをHTML5へ
- プレゼンテーションをHTML5へ
- スライドをHTML5へ
- PPTをHTML5へ
- PPTXをHTML5へ
- ODPをHTML5へ
- PPTをHTML5として保存
- PPTXをHTML5として保存
- ODPをHTML5として保存
- PPTをHTML5にエクスポート
- PPTXをHTML5にエクスポート
- ODPをHTML5にエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、シェイプ アニメーションとスライド トランジションの制御、コメント レイアウトについてカバーします。また、HTML5 の出力と標準 HTML エクスポートの SVG ベースの出力を比較します。

## **PowerPoint を HTML5 にエクスポート**

以下の例は、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用します。次の例では、アニメーションの再生を明示的に制御する方法を示します。入力パスをプレゼンテーションへのパスに置き換えてください。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS と JavaScript ファイルを出力します。出力を移動または公開する際は、これらのファイルを HTML ドキュメントと一緒に保持してください。生成されたページは、パブリック CDN から jQuery と Anime.js も読み込みます。これらが無いと、スライドのナビゲーションやアニメーションは実行されません。
{{% /alert %}}

シェイプ アニメーションやスライド トランジションを再生せずにエクスポートするには、[setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) と [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) に `false` を渡して [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) を使用します。これらの設定は独立しているため、一方を有効にし、もう一方を無効にすることができます。例では、生成されたページで両方のアニメーションタイプを無効にしてプレゼンテーションをエクスポートしています。

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは異なるレンダリング手法を使用します。スライドの内容は HTML ページ内の SVG として表現されます。以下の例は、このレンダリング手法を使用してプレゼンテーションを HTML ドキュメントに変換します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

以下の簡略化されたマークアップは、生成されたページの構造を示しています。SVG 要素はレンダリングされたスライド内容を含み、プレースホルダー テキストはその内容を表すもので、実際のエクスポート出力ではありません。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG ベースのエクスポートでは、PowerPoint のシェイプが個別の HTML 要素として公開されません。この記事で示したシェイプ アニメーションおよびスライド トランジションのオプションが必要な場合は、HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

HTML5 エクスポートは、ブラウザーでプレゼンテーションのスライドを閲覧およびナビゲートするためのページを生成します。この例では、[setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) と [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) の両方を有効にし、エクスポートされたスライドビューでソースプレゼンテーションのエフェクトを再生できるようにしています。シェイプ アニメーションとスライド トランジションが既に含まれているプレゼンテーションを使用して、これらの設定の効果を確認してください。有効にしても、効果がないスライドに新しいエフェクトは追加されません。エクスポート後、サポートファイルが利用可能な状態でブラウザーで生成された HTML5 ドキュメントを開きます。

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションをコメント付き HTML5 ドキュメントに変換**

HTML5 出力に既存のスライドコメントを含めることで、読者はスライド内容とともにフィードバックを見ることができます。このセクションの例は、以下のようにコメントが含まれているソースプレゼンテーションを前提としています。コメントをエクスポートしますが、新しいコメントは作成しません。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) オブジェクトを [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) の [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) メソッドに渡します。[setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) を使用して、[CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) 列挙体から `Right` を選択し、各スライドの右側にコメントを配置します。

以下の例は、このコメントレイアウトでプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションでは、表示するコメントテキストはありません。

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

以下の画像は、スライドの横にコメントが表示されたエクスポートされた HTML5 ドキュメントを示しています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` をターゲットとするリンクテキストと、通常の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) に `true` を渡します。デフォルトは `false` で、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

以下の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) を使用してエクスポートします。

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

エクスポートされたファイルは、テキストと通常の HTTPS リンクは保持しつつ、JavaScript ハイパーリンクを除外します。ソースプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクをフィルタリングしますが、すべてのスクリプトやその他のアクティブ コンテンツを削除するわけでも、CSP 準拠を保証するわけでもありません。たとえば、HTML5 出力にはスライド ナビゲーションやアニメーション用のスクリプトが依然として含まれます。

## **よくある質問**

**オブジェクト アニメーションおよびスライド トランジションが HTML5 で再生されるかどうか制御できますか？**

はい、HTML5 エクスポートでは、[shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) と [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) を個別に有効または無効にするオプションが用意されています。

**コメントはサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、既存のコメントは HTML5 出力に含めることができ、ノートとコメントの [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) を使用して（例としてスライドの右側に）配置できます。

**セキュリティまたは CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 設定を使用すると、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `false` です。[エクスポート時に JavaScript ハイパーリンクを除外](/slides/ja/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照してください。この設定は、HTML5 ビューアがナビゲーションやアニメーションに使用する JavaScript を削除するものではありません。