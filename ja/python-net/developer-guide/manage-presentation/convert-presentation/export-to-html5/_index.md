---
title: Python でプレゼンテーションを HTML5 に変換
linktitle: プレゼンテーションを HTML5 に
type: docs
weight: 40
url: /ja/python-net/export-to-html5/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションをレスポンシブな HTML5 にエクスポートします。書式設定、アニメーション、インタラクティブ性を保持します。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションを HTML5 に変換する方法を説明します。基本的なエクスポート、シェイプ アニメーションとスライド遷移の制御、コメントレイアウトについてカバーしています。また、HTML5 出力と標準 HTML エクスポートの SVG ベース出力を比較しています。

## **PowerPoint を HTML5 にエクスポート**

次の例は、作業ディレクトリからプレゼンテーションを読み込み、HTML5 形式で保存します。デフォルトのエクスポート設定を使用します。次の例では、アニメーションの再生を明示的に制御する方法を示します。入力パスをプレゼンテーションのパスに置き換えてください。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
HTML ドキュメントに加えて、エクスポートはスライドのスタイリング、アニメーション、エフェクト、ナビゲーション用の CSS および JavaScript ファイルを書き出します。出力を移動または公開する際は、これらのファイルを HTML ドキュメントと一緒に保持してください。生成されたページは jQuery と Anime.js をパブリック CDN からロードします。これらが無いと、スライドのナビゲーションとアニメーションは動作しません。
{{% /alert %}}

HTML5 エクスポートでシェイプ アニメーションやスライド遷移を再生せずにエクスポートするには、[animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) を [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) で `False` に設定します。これらの設定は独立しているため、一方だけを有効にし、もう一方を無効にすることができます。この例では、生成されたページで両方のアニメーションを無効にしてプレゼンテーションをエクスポートしています。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **PowerPoint を HTML にエクスポート**

標準の HTML エクスポートは異なるレンダリング手法を使用します。スライドのコンテンツは HTML ページ内の SVG として表現されます。次の例は、このレンダリング手法を使用してプレゼンテーションを HTML ドキュメントに変換します。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

以下の簡易マークアップは生成されたページの構造を示しています。SVG 要素はレンダリングされたスライドコンテンツを含み、プレースホルダー テキストはそのコンテンツを表すもので、実際のエクスポート出力ではありません。

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
SVG ベースのエクスポートは PowerPoint のシェイプを個別の HTML 要素として公開しません。この記事で示したシェイプ アニメーションやスライド遷移のオプションが必要な場合は、HTML5 エクスポートを使用してください。
{{% /alert %}}

## **PowerPoint を HTML5 スライドビューにエクスポート**

HTML5 エクスポートは、ブラウザでプレゼンテーションのスライドを表示およびナビゲートするためのページを生成します。この例では、[animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) の両方を有効にし、エクスポートされたスライドビューで元のプレゼンテーションのエフェクトを再生できるようにしています。

シェイプ アニメーションとスライド遷移が既に含まれているプレゼンテーションを使用して、これらの設定の効果を確認してください。これらを有効にしても、元々エフェクトがないスライドに新しいエフェクトが追加されることはありません。エクスポート後、サポートファイルが利用可能な状態でブラウザで生成された HTML5 ドキュメントを開きます。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **コメント付きでプレゼンテーションを HTML5 ドキュメントに変換**

既存のスライド コメントを HTML5 出力に含めることができ、読者はスライド コンテンツの横でフィードバックを見ることができます。このセクションの例は、以下に示すようにコメントが含まれていることを前提としています。コメントをエクスポートしますが、新しいコメントは作成しません。

![プレゼンテーションスライドの2つのコメント](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) オブジェクトを [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) の [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) プロパティに割り当てます。[comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) を [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) 列挙体の `RIGHT` に設定し、各スライドの右側にコメントを配置します。

以下の例は、このコメントレイアウトでプレゼンテーションを HTML5 にエクスポートします。コメントがないプレゼンテーションでは、表示するコメントテキストはありません。

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

下の画像は、コメントがスライドの横に表示されたエクスポートされた HTML5 ドキュメントを示しています。

![出力された HTML5 ドキュメントのコメント](two_comments_html5.png)

## **エクスポート時に JavaScript ハイパーリンクを除外**

`hyperlinks.pptx` に `javascript:alert('Hello')` ターゲットのリンクテキストと通常の `https://example.com/` リンクが含まれているとします。エクスポート時に JavaScript ハイパーリンクを除外するには、[Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) を `True` に設定します。デフォルトは `False` で、このオプションを有効にしない限りリンクはフィルタリングされません。

次の例は、作業ディレクトリからプレゼンテーションを読み込み、[Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) を使用してエクスポートします。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

エクスポートされたファイルは JavaScript ハイパーリンクを省略し、テキストと通常の HTTPS リンクは残ります。元のプレゼンテーションは変更されません。

このオプションは JavaScript ハイパーリンクをフィルタリングしますが、すべてのスクリプトや他のアクティブ コンテンツを削除するわけでも、CSP 準拠を保証するわけでもありません。たとえば、HTML5 出力にはスライド ナビゲーションとアニメーション用のスクリプトが依然として含まれています。

## **よくある質問**

**HTML5 でオブジェクト アニメーションやスライド遷移の再生を制御できますか？**

はい、HTML5 エクスポートでは、[shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) と [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) を個別に有効化または無効化するオプションが提供されています。

**コメントはサポートされていますか？ また、スライドに対してどこに配置できますか？**

はい、既存のコメントを HTML5 出力に含めることができ、[layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) を使用して（例としてスライドの右側に）配置できます。

**セキュリティまたは CSP の理由で JavaScript を呼び出すリンクをスキップできますか？**

はい、[skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) 設定により、保存時に JavaScript 呼び出しを含むハイパーリンクをスキップできます。デフォルトは `False` です。[エクスポート時に JavaScript ハイパーリンクを除外](/slides/ja/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) を参照してください。この設定は、ナビゲーションやアニメーションに使用される HTML5 ビューアの JavaScript を削除するものではありません。