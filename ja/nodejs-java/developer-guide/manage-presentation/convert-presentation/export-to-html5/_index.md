---
title: JavaScriptでプレゼンテーションをHTML5に変換
linktitle: プレゼンテーションをHTML5に
type: docs
weight: 40
url: /ja/nodejs-java/export-to-html5/
keywords:
- PowerPoint を HTML5 に
- OpenDocument を HTML5 に
- プレゼンテーション を HTML5 に
- スライド を HTML5 に
- PPT を HTML5 に
- PPTX を HTML5 に
- ODP を HTML5 に
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides for Node.js via Java を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、図形アニメーションとスライド遷移の制御、コメントレイアウトについて扱います。また、HTML5 出力と標準 HTML エクスポートの SVG ベース出力を比較します。

## **PowerPoint を HTML5 にエクスポート**

次の例は、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用しています。次の例では、アニメーションの再生を明示的に制御する方法を示します。入力パスはプレゼンテーションのパスに置き換えてください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS および JavaScript ファイルを生成します。出力を移動または公開する際は、これらのファイルを HTML ドキュメントと一緒に保持してください。生成されたページは jQuery と Anime.js をパブリック CDN からロードします。これらがない場合、スライドのナビゲーションとアニメーションは動作しません。

{{% /alert %}}

形状アニメーションやスライド遷移を再生せずにエクスポートするには、[Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) の中で [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) と [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) に `false` を渡します。これらの設定は独立しているため、一方だけ有効にし、他方を無効にすることができます。以下の例は、生成されたページで両方のアニメーションが無効化された状態でプレゼンテーションをエクスポートします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは別のレンダリング方式を使用します。スライドの内容は HTML ページ内の SVG として表現されます。次の例は、このレンダリング方式を使用してプレゼンテーションを HTML ドキュメントに変換します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

以下の簡易マークアップは、生成されたページの構造を示しています。SVG 要素にはレンダリングされたスライド内容が含まれ、プレースホルダー テキストはその内容を表すもので、実際のエクスポート出力ではありません。

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

SVG ベースのエクスポートは PowerPoint の図形を個別の HTML 要素として公開しません。この記事で示した図形アニメーションとスライド遷移のオプションが必要な場合は、HTML5 エクスポートを使用してください。

{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

HTML5 エクスポートは、ブラウザでプレゼンテーション スライドを表示およびナビゲートするためのページを生成します。この例では、[setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) と [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) の両方を有効にして、エクスポートされたスライド ビューが元のプレゼンテーションのエフェクトを再生できるようにしています。

すでに図形アニメーションとスライド遷移を含むプレゼンテーションを使用して、これらの設定の効果を確認してください。有効にしても、アニメーションが設定されていないスライドに新しいエフェクトは追加されません。エクスポート後、サポート ファイルが利用可能な状態でブラウザで生成された HTML5 ドキュメントを開きます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **コメント付き HTML5 ドキュメントにプレゼンテーションを変換**

既存のスライド コメントを HTML5 出力に含めることができ、読者はスライド内容と共にフィードバックを見ることができます。このセクションの例は、ソース プレゼンテーションにコメントが含まれていることを前提としています（下図参照）。コメントはエクスポートされますが、新しいコメントは作成されません。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

[Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) の [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) メソッドに [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) オブジェクトを渡します。[setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) で [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) 列挙体の `Right` を選択し、各スライドの右側にコメントを配置します。

以下の例は、このコメントレイアウトでプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションは表示するコメントテキストがありません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

下の画像は、コメントがスライドの横に表示されたエクスポート済み HTML5 ドキュメントを示しています。

![出力 HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` ターゲットのリンクテキストと普通の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) に `true` を渡します。デフォルトは `false` で、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

次の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) を使用してエクスポートします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

エクスポートされたファイルは JavaScript ハイパーリンクを除外し、テキストと普通の HTTPS リンクは残ります。ソース プレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクのみをフィルタリングし、すべてのスクリプトや他のアクティブ コンテンツを削除するわけでも、CSP 準拠を保証するわけでもありません。たとえば、HTML5 出力にはスライド ナビゲーションとアニメーション用のスクリプトが依然として含まれます。

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド 遷移の再生を制御できますか？**

はい、HTML5 エクスポートでは [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) と [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) を個別に有効または無効にするオプションが提供されています。

**コメントはサポートされますか？また、スライドに対してどこに配置できますか？**

はい、既存のコメントを HTML5 出力に含めることができ、[layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) を使用してスライドの右側などに配置できます。

**セキュリティや CSP の観点から JavaScript を呼び出すリンクをスキップできますか？**

はい、[setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 設定により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `false` です。HTML5 エクスポートの例とフィルタの範囲については、[Exclude JavaScript Hyperlinks During Export](/slides/ja/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照してください。この設定は、ナビゲーションとアニメーションのために HTML5 ビューアが使用する JavaScript を除去するものではありません。