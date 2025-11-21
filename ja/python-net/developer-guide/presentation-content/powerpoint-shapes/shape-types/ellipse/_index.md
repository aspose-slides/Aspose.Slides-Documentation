---
title: Python でプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/python-net/ellipse/
keywords:
- 楕円
- 形状
- 楕円を追加
- 楕円を作成
- 楕円を描画
- 書式設定された楕円
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP プレゼンテーションで楕円形を作成、書式設定、操作する方法を学びます（コード例付き）。"
---

## **楕円の作成**
このトピックでは、Aspose.Slides for Python via .NET を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for Python via .NET は、数行のコードでさまざまな形状を描画できる簡単な API を提供します。プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class のインスタンスを作成する
1. インデックスを使用してスライドの参照を取得する
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加する
1. 変更されたプレゼンテーションを書き出して PPTX ファイルに保存する

以下の例では、最初のスライドに楕円を追加しています。
```py
import aspose.slides as slides

# PPTX を表す Prseetation クラスのインスタンスを作成する
with slides.Presentation() as pres:
    # 最初のスライドを取得する
    sld = pres.slides[0]

    # 楕円タイプのオートシェイプを追加する
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #PPTX ファイルをディスクに保存する
```




## **書式設定された楕円の作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class のインスタンスを作成する。
1. インデックスを使用してスライドの参照を取得する。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加する。
1. 楕円の塗りつぶしタイプを Solid に設定する。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定する。
1. 楕円の線の色を設定する。
1. 楕円の線の幅を設定する。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルに保存する。

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX を表す Presentation クラスのインスタンスを作成する
with slides.Presentation() as pres:
    # 最初のスライドを取得する
    sld = pres.slides[0]

    # 楕円タイプのオートシェイプを追加する
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 楕円シェイプにいくつかの書式設定を適用する
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 楕円の線にいくつかの書式設定を適用する
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTX ファイルをディスクに保存する
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント** 単位で指定します。予測可能な結果を得るために、スライドサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置するには（スタック順序を制御するには）どうすればよいですか？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整できます。これにより楕円が他のオブジェクトと重なったり、背面のオブジェクトを表示したりできます。

**楕円の表示や強調をアニメーションさせるにはどうすればよいですか？**

[Apply](/slides/ja/python-net/shape-animation/) 入場、強調、または退出効果を形状に適用し、トリガーとタイミングを設定してアニメーションの開始時期と方法を制御します。