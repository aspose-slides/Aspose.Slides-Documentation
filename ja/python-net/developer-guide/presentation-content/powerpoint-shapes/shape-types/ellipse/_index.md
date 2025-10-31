---
title: Python でプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/python-net/ellipse/
keywords:
- 楕円
- 図形
- 楕円の追加
- 楕円の作成
- 楕円の描画
- 書式設定済み楕円
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP プレゼンテーションで楕円形の作成、書式設定、操作方法を学びます。コード例が含まれています。"
---

## **楕円の作成**
このトピックでは、Aspose.Slides for Python via .NET を使用してスライドに楕円形の図形を追加する方法を開発者に紹介します。Aspose.Slides for Python via .NET は、数行のコードでさまざまな形状を描画できる簡単な API を提供します。プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成する
2. インデックスを使用してスライドの参照を取得する
3. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、楕円タイプの AutoShape を追加する
4. 変更したプレゼンテーションを PPTX ファイルとして保存する

以下の例では、最初のスライドに楕円を追加しています。

```py
import aspose.slides as slides

# PPTX を表す Presentation クラスのインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 楕円形の AutoShape を追加
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # PPTX ファイルをディスクに保存
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **書式設定済み楕円の作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成する
2. インデックスを使用してスライドの参照を取得する
3. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、楕円タイプの AutoShape を追加する
4. 楕円の塗りつぶしタイプを Solid に設定する
5. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定する
6. 楕円の線の色を設定する
7. 楕円の線の幅を設定する
8. 変更したプレゼンテーションを PPTX ファイルとして保存する

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX を表す Presentation クラスのインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 楕円形の AutoShape を追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 楕円形にいくつかの書式設定を適用
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 楕円形の線に書式設定を適用
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # PPTX ファイルをディスクに保存
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**  
座標とサイズは通常 **ポイント** 単位で指定します。予測可能な結果を得るために、スライドのサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置するには（スタック順を制御するには）どうすればよいですか？**  
オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整します。これにより、楕円が他のオブジェクトと重なるようにしたり、下にあるものを表示したりできます。

**楕円の出現や強調にアニメーションを付けるにはどうすればよいですか？**  
[Apply](/slides/ja/python-net/shape-animation/) を使用して、図形に入場、強調、または退出効果を適用し、トリガーとタイミングを設定してアニメーションの開始時期や方法を制御します。