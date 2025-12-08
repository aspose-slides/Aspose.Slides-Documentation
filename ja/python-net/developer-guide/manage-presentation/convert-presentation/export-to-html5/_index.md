---
title: PythonでプレゼンテーションをHTML5に変換
linktitle: HTML5へエクスポート
type: docs
weight: 40
url: /ja/python-net/export-to-html5/
keywords:
- PowerPoint を HTML5 に変換
- OpenDocument を HTML5 に変換
- プレゼンテーション を HTML5 に変換
- スライド を HTML5 に変換
- PPT を HTML5 に変換
- PPTX を HTML5 に変換
- ODP を HTML5 に変換
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーション を変換
- スライド を変換
- HTML5 エクスポート
- プレゼンテーションをエクスポート
- スライドをエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint と OpenDocument のプレゼンテーションを、.NET 経由で Python 用 Aspose.Slides を使用してレスポンシブな HTML5 にエクスポートします。書式、アニメーション、インタラクティブ機能を保持します。"
---

{{% alert title="Info" color="info" %}}

Aspose.Slides 21.9 では、HTML5 エクスポートのサポートを実装しました。ただし、WebExtensions を使用して PowerPoint を HTML にエクスポートしたい場合は、代わりに[この記事](/slides/ja/net/web-extensions/)をご覧ください。

{{% /alert %}} 

ここでの HTML5 エクスポートプロセスにより、WebExtensions や依存関係なしで PowerPoint を HTML に変換できます。独自のテンプレートを使用することで、エクスポートプロセスや生成される HTML、CSS、JavaScript、アニメーション属性を定義する非常に柔軟なオプションを適用できます。

## **PowerPoint を HTML5 にエクスポート**

この Python コードは、WebExtensions や依存関係なしでプレゼンテーションを HTML5 にエクスポートする方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```


{{% alert color="primary" %}} 

この場合、クリーンな HTML が得られます。

{{% /alert %}}

このように、シェイプ アニメーションとスライド トランジションの設定を指定することもできます。
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```


## **PowerPoint を HTML にエクスポート**

この Python コードは、標準的な PowerPoint から HTML へのプロセスを示しています。
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```


この場合、プレゼンテーションのコンテンツは SVG を介して次のようにレンダリングされます。
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

この方法で PowerPoint を HTML にエクスポートすると、SVG でのレンダリングのため、特定の要素にスタイルを適用したりアニメーションを付けたりすることはできません。

{{% /alert %}}

## **PowerPoint を HTML5 スライド ビューにエクスポート**

**Aspose.Slides** を使用すると、PowerPoint プレゼンテーションをスライドがスライド ビュー モードで表示される HTML5 ドキュメントに変換できます。この場合、生成された HTML5 ファイルをブラウザーで開くと、Web ページ上でスライド ビュー モードのプレゼンテーションが表示されます。

この Python コードは、PowerPoint から HTML5 スライド ビューへのエクスポートプロセスを示しています。
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # スライドの遷移、アニメーション、およびシェイプアニメーションを含むプレゼンテーションをHTML5にエクスポート
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # プレゼンテーションを保存
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```


## **プレゼンテーションをコメント付き HTML5 ドキュメントに変換**

PowerPoint のコメントは、ユーザーがプレゼンテーション スライドにメモやフィードバックを残すためのツールです。特に共同プロジェクトでは、複数のユーザーがメインコンテンツを変更せずに特定のスライド要素に提案や意見を追加できるため便利です。各コメントには作成者の名前が表示されるので、誰がコメントしたかを追跡しやすくなります。

例えば、以下の PowerPoint プレゼンテーションが "sample.pptx" ファイルに保存されているとします。

![プレゼンテーション スライド上の 2 つのコメント](two_comments_pptx.png)

PowerPoint プレゼンテーションを HTML5 ドキュメントに変換する際、出力ドキュメントにプレゼンテーションのコメントを含めるかどうかを簡単に指定できます。そのためには、[Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) クラスの `notes_comments_layouting` プロパティでコメントの表示パラメータを指定する必要があります。

以下のコード例は、スライドの右側にコメントを表示した HTML5 ドキュメントにプレゼンテーションを変換します。
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```


下の画像に「output.html」ドキュメントが示されています。

![出力された HTML5 ドキュメント内のコメント](two_comments_html5.png)

## **よくある質問**

**HTML5 でオブジェクト アニメーションやスライド トランジションの再生を制御できますか？**

はい、HTML5 では、[shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) を個別に有効化または無効化するオプションが提供されています。

**コメントの出力はサポートされていますか？また、スライドに対してどこに配置できますか？**

はい、HTML5 でコメントを追加でき、[layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) を使用してスライドの右側など任意の位置に配置できます。

**セキュリティや CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、保存時に JavaScript 呼び出し付きハイパーリンクをスキップできる[設定](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) があり、厳格なセキュリティ ポリシーへの準拠に役立ちます。