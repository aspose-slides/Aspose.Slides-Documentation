---
title: Python 経由の Java でプレゼンテーションを HTML5 に変換
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

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。追加の Web 拡張機能なしでの基本的な HTML5 エクスポートと、シェイプ アニメーションおよびスライド遷移を制御するオプションについてカバーします。また、標準的な PowerPoint から HTML へのエクスポート手順を示し、スライド ビュー モードで HTML5 出力を生成する方法、そしてレイアウトを設定してエクスポートされたドキュメントにコメントを含める方法を解説します。

例を実行するには、Java 経由の Python 用 Aspose.Slides と互換性のある Java ランタイムが必要です。`pres.pptx`（コメントの例の場合は `sample.pptx`）を現在の作業ディレクトリに配置してください。各例は、JVM がまだ起動していない場合にのみ起動します。

## **PowerPoint を HTML5 にエクスポート**

[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) と [SaveFormat.Html5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Html5) を使用して、追加の Web 拡張機能なしでプレゼンテーションをエクスポートします：

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
HTML5 エクスポーターは、ブラウザーで表示できる HTML コンテンツを生成します。 
{{% /alert %}}

エクスポートの設定には [Html5Options](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/) を使用します。シェイプ アニメーションとスライド遷移を無効にするには、`False` を指定して [setAnimateShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateShapes) と [setAnimateTransitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateTransitions) を呼び出します：

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

標準的な HTML エクスポートには [SaveFormat.Html](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Html) を使用します。その他のオプションについては [Convert PowerPoint to HTML](/slides/ja/python-java/convert-powerpoint-to-html/) を参照してください：

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

この場合、プレゼンテーションのコンテンツは SVG を介して以下のように描画されます：

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
標準 HTML エクスポートはスライド コンテンツを SVG で描画し、HTML5 のシェイプ アニメーションやスライド遷移オプションは提供されません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

**Aspose.Slides** を使用すると、スライドがスライド ビュー モードで提示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この Python コードは、PowerPoint から HTML5 スライドビューへのエクスポート手順を示しています：

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

## **コメント付きで PowerPoint を HTML5 文書に変換**

PowerPoint のコメントは、ユーザーがスライド上にメモやフィードバックを残すためのツールです。特に共同プロジェクトで役立ち、複数のメンバーがメイン コンテンツを変更せずに特定のスライド要素に対して提案や備考を追加できます。各コメントには作成者の名前が表示されるため、誰がコメントしたかを簡単に追跡できます。

たとえば、`sample.pptx` ファイルに保存された次の PowerPoint プレゼンテーションがあるとします。

![プレゼンテーションスライド上の2つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 文書に変換する際、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/) クラスの [setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) メソッドにコメントの表示パラメーターを渡します。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) と [setCommentsPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) を使用し、[CommentsPositions.Right](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentspositions/#Right) を指定します。以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 文書に変換します。

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

「output.html」ドキュメントは以下の画像に示されています。

![出力された HTML5 文書のコメント](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateShapes) と [slide transitions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setAnimateTransitions) を個別に有効化または無効化できるオプションが提供されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、[layout settings](https://reference.aspose.com/slides/ja/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)があります。この設定は該当リンクを除去しますが、生成されたすべての HTML5 スクリプトがサイトのコンテンツ セキュリティ ポリシーに適合することを保証するものではありません。