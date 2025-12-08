---
title: Pythonでプレゼンテーションに長方形を追加
linktitle: 長方形
type: docs
weight: 80
url: /ja/python-net/rectangle/
keywords:
- 長方形を追加
- 長方形を作成
- 長方形シェイプ
- シンプルな長方形
- 書式設定された長方形
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して長方形を追加し、PowerPoint および OpenDocument のプレゼンテーションを強化します。形状をプログラムで簡単にデザインおよび変更できます。"
---

## **シンプルな長方形の作成**
前のトピックと同様に、これも図形の追加についてで、今回は長方形について説明します。このトピックでは、開発者が Aspose.Slides for Python via .NET を使用してスライドにシンプルまたは書式設定された長方形を追加する方法を説明しました。プレゼンテーションの選択されたスライドにシンプルな長方形を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しています。
```py
import aspose.slides as slides

# PPTX を表す Presentation クラスのインスタンス化
# 最初のスライドを取得
# 矩形タイプのオートシェイプを追加
#Write PPTX ファイルを書き込み保存
    with slides.Presentation() as pres:
        # Get the first slide
        sld = pres.slides[0]

        # Add autoshape of rectangle type
        sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

        #Write the PPTX file to disk
        pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **書式設定された長方形の作成**
スライドに書式設定された長方形を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
1. 長方形の塗りつぶしタイプを Solid に設定します。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、長方形の色を設定します。
1. 長方形の線の色を設定します。
1. 長方形の線の幅を設定します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルに保存します。

上記の手順は以下の例で実装されています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX を表す Presentation クラスをインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 矩形タイプのオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 矩形シェイプにいくつかの書式設定を適用
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 矩形の線にいくつかの書式設定を適用
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write PPTX ファイルをディスクに書き込む
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**長方形に角丸を付けるにはどうすればよいですか？**

丸みのある角の [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリの調整により、コーナーごとに丸みを適用することも可能です。

**画像（テクスチャ）で長方形を塗りつぶすにはどうすればよいですか？**

画像の [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) を構成します。

**長方形に影やグローを付けることはできますか？**

はい。調整可能なパラメータで設定できる [Outer/inner shadow, glow, and soft edges](/slides/ja/python-net/shape-effect/) が利用可能です。

**長方形をハイパーリンク付きのボタンに変えることはできますか？**

はい。シェイプのクリックに対して [Assign a hyperlink](/slides/ja/python-net/manage-hyperlinks/) を設定すれば、スライド、ファイル、ウェブアドレス、またはメールへのジャンプが可能です。

**長方形を移動や変更から保護するにはどうすればよいですか？**

[Use shape locks](/slides/ja/python-net/applying-protection-to-presentation/) を使用します。これにより、レイアウトを維持するために、移動、サイズ変更、選択、テキスト編集などを禁止できます。

**長方形をラスター画像または SVG に変換できますか？**

はい。指定したサイズ/スケールで画像に [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) したり、ベクター用途として [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) したりできます。

**テーマや継承を考慮した長方形の実際（有効）プロパティをすばやく取得するには？**

[Use the shape’s effective properties](/slides/ja/python-net/shape-effective-properties/) を使用します。API はテーマスタイル、レイアウト、ローカル設定を考慮した計算済みの値を返すため、書式分析が簡素化されます。