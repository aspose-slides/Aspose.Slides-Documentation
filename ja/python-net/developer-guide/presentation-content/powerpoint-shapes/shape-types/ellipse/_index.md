---
title: 楕円
type: docs
weight: 30
url: /python-net/ellipse/
keywords: "楕円, PowerPoint 形状, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Python で PowerPoint プレゼンテーションに楕円を作成する"
---


## **楕円の作成**
このトピックでは、Aspose.Slides for Python via .NETを使用して、スライドに楕円形状を追加する方法を開発者に紹介します。Aspose.Slides for Python via .NETは、数行のコードでさまざまな種類の形状を描画するための簡単なAPIセットを提供します。プレゼンテーションの選択したスライドに単純な楕円を追加するには、以下のステップに従ってください：

1. [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、楕円型のAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、最初のスライドに楕円を追加しました。

```py
import aspose.slides as slides

# PPTXを表すPresentationクラスのインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 楕円型のオートシェイプを追加
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #PPTXファイルをディスクに書き込む
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **フォーマットされた楕円の作成**
スライドにより良いフォーマットの楕円を追加するには、以下のステップに従ってください：

1. [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、楕円型のAutoShapeを追加します。
1. 楕円の塗りつぶしタイプをソリッドに設定します。
1. IShapeオブジェクトに関連するFillFormatオブジェクトによって公開されたSolidFillColor.Colorプロパティを使用して、楕円の色を設定します。
1. 楕円の線の色を設定します。
1. 楕円の線の幅を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにフォーマットされた楕円を追加しました。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXを表すPresentationクラスのインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 楕円型のオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 楕円形状にいくつかのフォーマットを適用
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 楕円の線にいくつかのフォーマットを適用
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTXファイルをディスクに書き込む
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```