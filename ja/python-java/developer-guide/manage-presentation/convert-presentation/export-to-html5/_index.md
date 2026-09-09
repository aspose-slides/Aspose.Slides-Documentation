---
title: プレゼンテーションを Python (Java 経由) で HTML5 に変換
linktitle: プレゼンテーションを HTML5 に
type: docs
weight: 40
url: /ja/python-java/export-to-html5/
keywords:
- PowerPoint を HTML5 に変換
- OpenDocument を HTML5 に変換
- プレゼンテーションを HTML5 に変換
- スライドを HTML5 に変換
- PPT を HTML5 に変換
- PPTX を HTML5 に変換
- ODP を HTML5 に変換
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

このガイドでは、Aspose.Slides を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。追加の Web 拡張機能を使用しない基本的な HTML5 エクスポートと、図形アニメーションやスライド遷移を制御するオプションについて解説します。また、標準的な PowerPoint から HTML へのエクスポート手順、スライドビュー モードでの HTML5 出力の生成方法、レイアウトを設定してエクスポート ドキュメントにコメントを含める方法も紹介します。

例を実行するには、Python 用 Aspose.Slides for Java と対応する Java ランタイムが必要です。`pres.pptx`（コメントの例の場合は `sample.pptx`）を現在の作業ディレクトリに配置してください。各例は、JVM が起動していない場合にのみ起動します。

## **PowerPoint を HTML5 にエクスポート**

[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) と [SaveFormat.Html5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Html5) を使用して、追加の Web 拡張機能なしでプレゼンテーションをエクスポートします。

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

{{% alert color="info" title="注意" %}} 
HTML5 エクスポーターは、ブラウザーで表示できる HTML コンテンツを生成します。 
{{% /alert %}}

[Html5Options](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/) を使用してエクスポートを構成します。`False` を指定して [setAnimateShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateShapes) と [setAnimateTransitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateTransitions) を呼び出すと、図形アニメーションとスライド遷移が無効になります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint を HTML にエクスポート**

標準的な HTML エクスポートには [SaveFormat.Html](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Html) を使用します。詳細なオプションは [Convert PowerPoint to HTML](/slides/ja/python-java/convert-powerpoint-to-html/) を参照してください。

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

この場合、プレゼンテーションのコンテンツは SVG を使用して以下のように描画されます。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="警告" color="warning" %}} 
標準 HTML エクスポートは SVG を介してスライドコンテンツを描画し、HTML5 の図形アニメーションおよびスライド遷移オプションは提供されません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションを HTML5 ドキュメントに変換し、スライドをスライドビュー モードで表示できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。

この Python コードは、PowerPoint を HTML5 スライドビューにエクスポートする手順を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **コメント付きの HTML5 ドキュメントへプレゼンテーションを変換**

PowerPoint のコメントは、スライド上の特定の要素に対してユーザーがメモやフィードバックを残すためのツールです。共同作業プロジェクトで特に有用で、複数のメンバーが主コンテンツを変更せずに提案や指摘を追加できます。各コメントには作成者の名前が表示されるため、誰がコメントしたかを簡単に把握できます。

以下の例は、"sample.pptx" ファイルに保存された PowerPoint プレゼンテーションです。

![プレゼンテーションスライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/) クラスの [setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) メソッドにコメント表示パラメータを渡します。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) と [setCommentsPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) を使用し、[CommentsPositions.Right](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentspositions/#Right) を指定します。次のコード例は、スライドの右側にコメントを表示した HTML5 ドキュメントへプレゼンテーションを変換します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

以下の画像は、出力された "output.html" ドキュメントの様子を示しています。

![出力 HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **FAQ**

**HTML5 で図形アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateShapes) と [slide transitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateTransitions) を個別に有効または無効にするオプションが用意されています。

**コメントをエクスポートできますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 にコメントを追加でき、[layout settings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の観点から JavaScript 呼び出しを行うリンクを除外できますか？**

はい、[setting](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。この設定はハイパーリンクを除去しますが、生成された HTML5 スクリプトがサイトのコンテンツセキュリティポリシーを満たすことを自動的に保証するものではありません。