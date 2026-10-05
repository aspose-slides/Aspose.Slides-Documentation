---
title: JavaでプレゼンテーションをHTML5に変換
linktitle: プレゼンテーションをHTML5に
type: docs
weight: 40
url: /ja/java/export-to-html5/
keywords:
- PowerPointをHTML5に
- OpenDocumentをHTML5に
- プレゼンテーションをHTML5に
- スライドをHTML5に
- PPTをHTML5に
- PPTXをHTML5に
- ODPをHTML5に
- PPTをHTML5として保存
- PPTXをHTML5として保存
- ODPをHTML5として保存
- PPTをHTML5にエクスポート
- PPTXをHTML5にエクスポート
- ODPをHTML5にエクスポート
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

このドキュメントでは、Aspose.Slides for Java を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、シェイプ アニメーションとスライド トランジションの制御、コメントのレイアウトについて取り上げ、HTML5 出力と標準 HTML エクスポートの SVG ベース出力を比較します。

## **PowerPoint を HTML5 にエクスポート**

次のサンプルは、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用しています。次のサンプルでは、アニメーションの再生を明示的に制御する方法を示します。入力パスはご自身のプレゼンテーションのパスに置き換えてください。

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
HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS および JavaScript ファイルも出力します。これらのファイルは HTML ドキュメントと一緒に保管し、出力を移動または公開する際に同梱してください。生成されたページは jQuery と Anime.js をパブリック CDN から読み込みます。これらが無いとスライドのナビゲーションとアニメーションは動作しません。
{{% /alert %}}

シェイプ アニメーションやスライド トランジションを再生せずにエクスポートするには、[setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) に `false` を渡します。これらは [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) の設定で独立しているため、どちらかだけを有効にしたり無効にしたりできます。以下の例は、両方のアニメーションを無効にした状態でプレゼンテーションをエクスポートします。

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

標準の HTML エクスポートは別のレンダリング手法を使用します。スライド内容は HTML ページ内の SVG として表現されます。次の例は、このレンダリング手法でプレゼンテーションを HTML ドキュメントに変換します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

以下の簡易マークアップは生成されたページの構造を示しています。SVG 要素はレンダリングされたスライド内容を含み、プレースホルダー テキストはその内容を表すもので、実際のエクスポート出力ではありません。

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
SVG ベースのエクスポートは PowerPoint のシェイプを個別の HTML 要素として公開しません。シェイプ アニメーションやスライド トランジションが必要な場合は、本記事で示した HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

HTML5 エクスポートは、ブラウザーでプレゼンテーション スライドを表示・ナビゲートするためのページを生成します。この例では [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) の両方を有効にし、エクスポートされたスライドビューが元のプレゼンテーションのエフェクトを再生できるようにしています。

シェイプ アニメーションとスライド トランジションが設定されたプレゼンテーションを使用すると、これらの設定の効果が確認できます。設定を有効にしても、対象のスライドにエフェクトが無ければ新たに効果が追加されることはありません。エクスポート後、サポートファイルが同梱された状態で生成された HTML5 ドキュメントをブラウザーで開いてください。

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

## **コメント付き HTML5 ドキュメントへの変換**

HTML5 出力に既存のスライド コメントを含めることができ、閲覧者はスライド内容と並んでフィードバックを見ることができます。このセクションの例は、コメントが含まれた元のプレゼンテーションを対象にしています（以下の図参照）。コメントはエクスポートされますが、新規に作成されることはありません。

![プレゼンテーションスライドのコメント2つ](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) オブジェクトを [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) の [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) メソッドに渡します。[setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) で [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) 列挙から `Right` を選択し、コメントを各スライドの右側に配置します。

以下の例は、このコメントレイアウトでプレゼンテーションを HTML5 にエクスポートします。コメントが無いプレゼンテーションの場合、表示されるコメントテキストはありません。

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

下図は、コメントがスライド横に表示されたエクスポート済み HTML5 ドキュメントです。

![出力 HTML5 ドキュメントのコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外する**

`hyperlinks.pptx` に `javascript:alert('Hello')` ターゲットのリンクテキストと通常の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) に `true` を渡します。デフォルトは `false` で、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

次の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) を使用してエクスポートします。

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

エクスポートされたファイルは JavaScript ハイパーリンクを除外しつつ、テキストと通常の HTTPS リンクは保持します。元のプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクのみをフィルタリングし、すべてのスクリプトや他のアクティブ コンテンツを削除するわけでも、CSP の遵守を保証するわけでもありません。たとえば、HTML5 出力にはスライド ナビゲーションとアニメーション用のスクリプトが依然として含まれます。

## **FAQ**

**HTML5 でオブジェクト アニメーションとスライド トランジションの再生を制御できますか？**

はい、HTML5 エクスポートは [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) を個別に有効または無効にするオプションを提供します。

**コメントはサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、既存のコメントを HTML5 出力に含めることができ、[layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の観点で JavaScript を呼び出すリンクを除外できますか？**

はい、[setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 設定により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `false` です。HTML5 エクスポートの例とフィルタの範囲については [Exclude JavaScript Hyperlinks During Export](/slides/ja/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照してください。この設定は、HTML5 ビューアがナビゲーションとアニメーションに使用する JavaScript を削除するものではありません。