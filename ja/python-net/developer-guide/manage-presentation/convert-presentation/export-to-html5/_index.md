---
title: HTML5にエクスポート
type: docs
weight: 40
url: /ja/python-net/export-to-html5/
keywords:
- PowerPointをHTMLに
- スライドをHTMLに
- HTML5
- HTMLエクスポート
- プレゼンテーションをエクスポート
- プレゼンテーションを変換
- スライドを変換
- Java
- Aspose.Slides for Python via .NET
description: "PythonでPowerPointをHTML5にエクスポート"
---

{{% alert title="情報" color="info" %}}

**Aspose.Slides 21.9** では、HTML5エクスポートのサポートを実装しました。ただし、Web拡張機能を使用してPowerPointをHTMLにエクスポートしたい場合は、[この記事](/slides/ja/net/web-extensions/)をご覧ください。

{{% /alert %}}

ここでは、Web拡張機能や依存関係なしにPowerPointをHTMLに変換するプロセスを説明します。この方法では、自分のテンプレートを使用して、エクスポートプロセスや生成されるHTML、CSS、JavaScript、およびアニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPointをHTML5にエクスポート**

このPythonコードは、Web拡張機能や依存関係なしにプレゼンテーションをHTML5にエクスポートする方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}}

この場合、クリーンなHTMLが得られます。

{{% /alert %}}

次のように、シェイプアニメーションやスライドトランジションの設定を指定することができます。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **PowerPointをHTMLにエクスポート**

このPythonコードは、標準のPowerPointからHTMLへのプロセスを示しています。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

この場合、プレゼンテーションの内容は、次のような形式でSVGを通じてレンダリングされます。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> スライドの内容がここに入ります </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}}

この方法を使用してPowerPointをHTMLにエクスポートすると、SVGレンダリングのため、特定の要素にスタイルを適用したりアニメーションさせたりすることはできません。

{{% /alert %}}

## **PowerPointをHTML5スライドビューにエクスポート**

**Aspose.Slides** は、PowerPointプレゼンテーションをスライドビューモードでスライドが表示されるHTML5ドキュメントに変換することを可能にします。この場合、生成されたHTML5ファイルをブラウザで開くと、ウェブページ上でスライドビューモードのプレゼンテーションを見ることができます。

このPythonコードは、PowerPointからHTML5スライドビューエクスポートプロセスを示しています。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # スライドトランジション、アニメーション、およびシェイプアニメーションを含むプレゼンテーションをHTML5にエクスポート
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # プレゼンテーションを保存
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## コメント付きのプレゼンテーションをHTML5文書に変換

PowerPointのコメントは、ユーザーがプレゼンテーションスライドにメモやフィードバックを残すためのツールです。特に複数の人が特定のスライド要素に対する提案やコメントを追加できる共同プロジェクトで便利です。各コメントは著者の名前を表示するため、誰がコメントを残したかを簡単に追跡できます。

以下のPowerPointプレゼンテーションが「sample.pptx」ファイルに保存されているとしましょう。

![プレゼンテーションスライドに対する二つのコメント](two_comments_pptx.png)

PowerPointプレゼンテーションをHTML5文書に変換するとき、出力ドキュメントにプレゼンテーションからのコメントを含めるかどうかを簡単に指定できます。これを行うには、[Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/)クラスの`notes_comments_layouting`プロパティでコメントの表示パラメーターを指定する必要があります。

以下のコード例は、スライドの右側にコメントが表示されるHTML5文書にプレゼンテーションを変換します。

```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

「output.html」ドキュメントは以下の画像のようになります。

![出力HTML5文書のコメント](two_comments_html5.png)