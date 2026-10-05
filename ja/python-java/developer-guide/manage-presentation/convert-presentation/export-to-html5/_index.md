---
title: Python via Java でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に
type: docs
weight: 40
url: /ja/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、図形アニメーションとスライド遷移の制御、コメントレイアウトについてカバーしています。また、HTML5 の出力を標準 HTML エクスポートの SVG ベースの出力と比較します。

例では Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。入力プレゼンテーションは現在の作業ディレクトリに配置してください。各例は、JVM がまだ起動していない場合にのみ起動します。

## **PowerPoint を HTML5 にエクスポート**

以下の例は、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用します。次の例ではアニメーションの再生を明示的に制御する方法を示します。入力パスをプレゼンテーションのパスに置き換えてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS および JavaScript ファイルを出力します。出力を移動または公開する際は、これらのファイルを HTML ドキュメントと一緒に保管してください。生成されたページは jQuery と Anime.js をパブリック CDN から読み込みます。これらがないと、スライドのナビゲーションやアニメーションは動作しません。
{{% /alert %}}

`False` を渡して [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) および [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) を [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) に設定します。これらの設定は独立しているため、一方を有効にし、他方を無効にすることができます。この例では、生成されたページで両方のアニメーションタイプを無効にした状態でプレゼンテーションをエクスポートしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは異なるレンダリング手法を使用します。スライドの内容は HTML ページ内の SVG として表現されます。以下の例は、このレンダリング手法を用いてプレゼンテーションを HTML ドキュメントに変換します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

以下の簡易マークアップは生成されたページの構造を示しています。SVG 要素はレンダリングされたスライドコンテンツを含み、プレースホルダーのテキストはそのコンテンツを示すもので、実際のエクスポート出力ではありません。

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
SVG ベースのエクスポートでは、PowerPoint の図形を個別の HTML 要素として公開しません。本記事で示した図形アニメーションやスライド遷移のオプションが必要な場合は、HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

HTML5 エクスポートは、ブラウザーでプレゼンテーションスライドを閲覧およびナビゲートするためのページを生成します。この例では、[setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) と [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) の両方を有効にし、エクスポートされたスライドビューで元のプレゼンテーションのエフェクトを再生できるようにします。

図形アニメーションとスライド遷移が既に含まれているプレゼンテーションを使用すると、これらの設定の効果を確認できます。これらを有効にしても、アニメーションがないスライドに新しいエフェクトが追加されるわけではありません。エクスポート後、サポートファイルが揃っている状態でブラウザーで生成された HTML5 ドキュメントを開いてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **プレゼンテーションをコメント付き HTML5 ドキュメントに変換**

既存のスライドコメントを HTML5 出力に含めることができ、読者はスライドコンテンツと一緒にフィードバックを確認できます。このセクションの例は、以下のようにコメントが含まれたソースプレゼンテーションを前提としています。コメントはエクスポートされますが、新しいコメントは作成されません。

![Two comments on the presentation slide](two_comments_pptx.png)

`[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/)` オブジェクトを `[Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/)` の `[setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions)` メソッドに渡します。`[setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)` を使用して、`[CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/)` 列挙から `Right` を選択し、各スライドの右側にコメントを配置します。

以下の例は、このコメントレイアウトでプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションでは、表示するコメントテキストはありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

![The comments in the output HTML5 document](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` ターゲットのリンクテキストと普通の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) に `True` を渡します。デフォルトは `False` で、オプションを有効にしない限りこれらのリンクはフィルタリングされません。

以下の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) を使用してエクスポートします：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

エクスポートされたファイルは、テキストと通常の HTTPS リンクは保持しつつ、JavaScript ハイパーリンクを除外します。ソースのプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクをフィルタリングしますが、すべてのスクリプトや他のアクティブコンテンツを削除するわけではなく、CSP 準拠も保証しません。たとえば、HTML5 の出力にはスライドのナビゲーションやアニメーション用のスクリプトが依然として含まれます。

## **よくある質問**

**HTML5 でオブジェクトのアニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 エクスポートでは、[shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) と [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) を個別に有効または無効にするオプションが提供されています。

**コメントはサポートされますか？ また、スライドに対してどこに配置できますか？**

はい、既存のコメントは HTML5 出力に含めることができ、ノートやコメントの [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) を使用して（例としてスライドの右側に）配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 設定により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `False` です。[Exclude JavaScript Hyperlinks During Export](/slides/ja/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照すると、HTML5 エクスポートの例とフィルタの適用範囲がわかります。この設定は、HTML5 ビューアがナビゲーションやアニメーションに使用する JavaScript を削除するものではありません。