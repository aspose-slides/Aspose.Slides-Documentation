---
title: "PythonでプレゼンテーションをHTML5に変換"
linktitle: "HTML5にエクスポート"
type: docs
weight: 40
url: /ja/python-net/export-to-html5/
keywords:
- "PowerPointからHTML5へ"
- "OpenDocumentからHTML5へ"
- "プレゼンテーションからHTML5へ"
- "スライドからHTML5へ"
- "PPTからHTML5へ"
- "PPTXからHTML5へ"
- "ODPからHTML5へ"
- "PowerPointを変換"
- "OpenDocumentを変換"
- "プレゼンテーションを変換"
- "スライドを変換"
- "HTML5エクスポート"
- "プレゼンテーションをエクスポート"
- "スライドをエクスポート"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ性を保持します。"
---

{{% alert title="Info" color="info" %}}
**Aspose.Slides 21.9** では、HTML5 エクスポートのサポートを実装しました。ただし、WebExtensions を使用して PowerPoint を HTML にエクスポートしたい場合は、代わりに [この記事](/slides/ja/net/web-extensions/) を参照してください。
{{% /alert %}} 

ここでの HTML5 エクスポートプロセスにより、WebExtensions や依存関係なしで PowerPoint を HTML に変換できます。この方法では、独自のテンプレートを使用して、エクスポートプロセスと生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。 

## **PowerPoint を HTML5 にエクスポート**

この Python コードは、WebExtensions や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
この場合、クリーンな HTML が得られます。 
{{% /alert %}}

以下のように、シェイプアニメーションとスライド遷移の設定を指定することもできます：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **PowerPoint を HTML にエクスポート**

この Python コードは、標準的な PowerPoint から HTML へのプロセスを示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

この場合、プレゼンテーションの内容は以下のように SVG でレンダリングされます：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
この方法で PowerPoint を HTML にエクスポートすると、SVG レンダリングのため、特定の要素にスタイルを適用したりアニメーションさせたりすることができません。 
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューでエクスポート**

**Aspose.Slides** を使用すると、スライドがスライドビュー モードで表示される HTML5 ドキュメントに PowerPoint プレゼンテーションを変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライドビュー モードのプレゼンテーションが表示されます。 

この Python コードは、PowerPoint から HTML5 スライドビューへのエクスポートプロセスを示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # スライド遷移、アニメーション、シェイプアニメーションを含むプレゼンテーションを HTML5 にエクスポート
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # プレゼンテーションを保存
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

PowerPoint のコメントは、プレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトで、複数の担当者がメイン コンテンツを変更せずに特定のスライド要素に対して提案や注釈を追加できる点で有用です。各コメントには作成者の名前が表示され、誰がコメントしたかがすぐに分かります。

たとえば、"sample.pptx" ファイルに保存された以下の PowerPoint プレゼンテーションがあるとします。

![Two comments on the presentation slide](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換するとき、出力ドキュメントにプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) クラスの `notes_comments_layouting` プロパティでコメントの表示パラメータを指定します。

以下のコード例は、スライドの右側にコメントを表示した状態でプレゼンテーションを HTML5 ドキュメントに変換します。
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

"output.html" ドキュメントは以下の画像に示されています。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 では [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) を個別に有効化または無効化するオプションが用意されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、コメントは HTML5 に追加でき、[layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) を使用してスライドの右側など、任意の位置に配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクを除外できますか？**

はい、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできる [setting](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) が用意されており、厳格なセキュリティ ポリシーに対応できます。