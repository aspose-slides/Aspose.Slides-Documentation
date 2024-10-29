---
title: 長方形
type: docs
weight: 80
url: /ja/python-net/rectangle/
keywords: "長方形の作成, PowerPointの図形, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションに長方形を作成する"
---


## **単純な長方形の作成**
前のトピックと同様に、今回も図形の追加についてですが、今回は長方形について説明します。このトピックでは、開発者がAspose.Slides for Python via .NETを使用してスライドに単純または書式設定された長方形を追加する方法について説明します。プレゼンテーションの選択したスライドに単純な長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されるAddAutoShapeメソッドを使用して、長方形型のIAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに単純な長方形を追加しました。

```py
import aspose.slides as slides

# PPTXを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形型の自動図形を追加
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # PPTXファイルをディスクに保存
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **書式設定された長方形の作成**
スライドに書式設定された長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されるAddAutoShapeメソッドを使用して、長方形型のIAutoShapeを追加します。
1. 長方形の塗りつぶしタイプをソリッドに設定します。
1. IShapeオブジェクトに関連付けられたFillFormatオブジェクトによって公開されるSolidFillColor.Colorプロパティを使用して、長方形の色を設定します。
1. 長方形の線の色を設定します。
1. 長方形の線の幅を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。
   上記の手順は、以下の例に実装されています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形型の自動図形を追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 長方形にいくつかの書式設定を適用
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 長方形の線にいくつかの書式設定を適用
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # PPTXファイルをディスクに保存
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```