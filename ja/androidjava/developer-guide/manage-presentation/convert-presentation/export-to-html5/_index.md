---
title: Android でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に変換
type: docs
weight: 40
url: /ja/androidjava/export-to-html5/
keywords:
- PowerPoint を HTML5 に
- OpenDocument を HTML5 に
- プレゼンテーションを HTML5 に
- スライドを HTML5 に
- PPT を HTML5 に
- PPTX を HTML5 に
- ODP を HTML5 に
- PPT を HTML5 として保存
- PPTX を HTML5 として保存
- ODP を HTML5 として保存
- PPT を HTML5 にエクスポート
- PPTX を HTML5 にエクスポート
- ODP を HTML5 にエクスポート
- Android
- Java
- Aspose.Slides
description: "Java を介して Android 用 Aspose.Slides で PowerPoint および OpenDocument プレゼンテーションをレスポンシブ HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

本記事では、Aspose.Slides for Android for Java を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、図形アニメーションとスライド遷移の制御、コメントレイアウトについて解説します。また、HTML5 出力と標準 HTML エクスポートの SVG ベース出力を比較します。

## **PowerPoint を HTML5 にエクスポート**

次の例は、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用します。次の例では、アニメーションの再生を明示的に制御する方法を示します。入力パスをプレゼンテーションのパスに置き換えてください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML 文書に加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS と JavaScript ファイルも出力します。これらのファイルは、HTML 文書と一緒に移動または公開する際に保持してください。生成されたページは、パブリック CDN から jQuery と Anime.js をロードします。これらがなければ、スライドのナビゲーションやアニメーションは動作しません。
{{% /alert %}}

図形アニメーションやスライド遷移を再生せずにエクスポートするには、[Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) の中で [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) に `false` を渡します。これらの設定は互いに独立しているため、一方を有効にし、もう一方を無効にすることができます。この例では、生成されたページで両方のアニメーションを無効にした状態でプレゼンテーションをエクスポートしています。

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは異なるレンダリング手法を使用します。スライドの内容は HTML ページ内の SVG で表現されます。次の例は、このレンダリング手法を用いてプレゼンテーションを HTML 文書に変換します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

以下の簡略化されたマークアップは、生成されたページの構造を示しています。SVG 要素はレンダリングされたスライド内容を含み、プレースホルダーのテキストはその内容を表すもので、実際のエクスポート出力ではありません。

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
SVG ベースのエクスポートでは、PowerPoint の図形が個別の HTML 要素として公開されません。本記事で示した図形アニメーションやスライド遷移のオプションが必要な場合は、HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

HTML5 エクスポートは、ブラウザーでプレゼンテーションスライドを閲覧およびナビゲートするためのページを生成します。この例では、[setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) の両方を有効にし、エクスポートされたスライドビューで元のプレゼンテーションのエフェクトを再生できるようにしています。

図形アニメーションとスライド遷移が既に含まれているプレゼンテーションを使用して、これらの設定の効果を確認してください。これらを有効にしても、アニメーションが存在しないスライドに新しいエフェクトが追加されることはありません。エクスポート後、サポートファイルが利用可能な状態でブラウザーで生成された HTML5 文書を開きます。

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **コメント付きでプレゼンテーションを HTML5 文書に変換**

HTML5 出力に既存のスライドコメントを含めることができ、読者はスライド内容と一緒にフィードバックを見ることができます。このセクションの例は、以下に示すように、ソースプレゼンテーションにコメントが含まれていることを前提としています。コメントをエクスポートしますが、新しいコメントは作成しません。

![プレゼンテーションスライドの 2 つのコメント](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) オブジェクトを [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) の [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) メソッドに渡します。[setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) を使用して、[CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) 列挙体から `Right` を選択し、コメントを各スライドの右側に配置します。

以下の例は、このコメントレイアウトでプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションでは、表示するコメントテキストはありません。

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

下の画像は、スライドの横にコメントが表示されたエクスポートされた HTML5 文書を示しています。

![出力された HTML5 文書のコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` をターゲットとしたリンクテキストと、通常の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) に `true` を渡します。デフォルトは `false` で、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

次の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) を使用してエクスポートします：

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

エクスポートされたファイルは JavaScript ハイパーリンクを除外し、テキストと通常の HTTPS リンクは保持します。元のプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクをフィルタリングしますが、すべてのスクリプトや他のアクティブコンテンツを削除するわけではなく、CSP 準拠も保証しません。たとえば、HTML5 出力にはスライドのナビゲーションやアニメーション用のスクリプトが依然として含まれます。

## **よくある質問**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 エクスポートは、[shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) をそれぞれ有効または無効にするオプションを提供します。

**コメントはサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、既存のコメントは HTML5 出力に含めることができ、ノートとコメントの[レイアウト設定](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用して（例としてスライドの右側に）配置できます。

**セキュリティや CSP の観点で、JavaScript を呼び出すリンクをスキップできますか？**

はい、[setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 設定により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `false` です。[エクスポート時に JavaScript ハイパーリンクを除外]( /slides/ja/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照すると、HTML5 エクスポートの例とフィルタの範囲が示されています。この設定は、ナビゲーションやアニメーション用の HTML5 ビューアで使用される JavaScript を削除するものではありません。