---
title: ライン
type: docs
weight: 50
url: /ja/python-net/line/
keywords: "ライン, PowerPoint 図形, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにラインを追加する"
---

Aspose.Slides for Python via .NETは、スライドにさまざまな種類の図形を追加することをサポートしています。このトピックでは、スライドにラインを追加することで図形の操作を始めます。Aspose.Slides for Python via .NETを使用することで、開発者は単純なラインを作成するだけでなく、スライド上にいくつかのファンシーなラインも描画できます。
## **単純なラインを作成する**
プレゼンテーションの選択したスライドに単純なラインを追加するには、以下の手順に従ってください。

- [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapesオブジェクトが公開している[add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドを使用して、ラインタイプのオートシェイプを追加します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しました。

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationExクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # ラインタイプのオートシェイプを追加
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    #PPTXをディスクに書き込む
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **矢印形のラインを作成する**
Aspose.Slides for Python via .NETでは、開発者がラインのいくつかのプロパティを設定して、より魅力的に見せることも可能です。ラインを矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapesオブジェクトが公開しているAddAutoShapeメソッドを使用して、ラインタイプのオートシェイプを追加します。
- Aspose.Slides for Python via .NETが提供するスタイルの1つにラインスタイルを設定します。
- ラインの幅を設定します。
- Aspose.Slides for Python via .NETが提供するスタイルの1つにラインの[ダッシュスタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)を設定します。
- ラインの始点の[矢印ヘッドスタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/)と長さを設定します。
- ラインの終点の矢印ヘッドスタイルと長さを設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationExクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # ラインタイプのオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # ラインにいくつかのフォーマットを適用
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    #PPTXをディスクに書き込む
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```