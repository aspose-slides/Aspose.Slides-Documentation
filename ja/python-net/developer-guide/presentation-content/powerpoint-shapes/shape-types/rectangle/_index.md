---
title: Python でプレゼンテーションに長方形を追加する
linktitle: 長方形
type: docs
weight: 80
url: /ja/python-net/rectangle/
keywords:
- 長方形を追加
- 長方形を作成
- 長方形のシェイプ
- シンプルな長方形
- 書式設定された長方形
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して長方形を追加し、PowerPoint と OpenDocument のプレゼンテーションを強化します。プログラムで簡単に図形をデザインおよび変更できます。"
---

## **シンプルな長方形を作成**
以前のトピックと同様に、今回も図形の追加について説明しますが、対象となる図形は長方形です。このトピックでは、開発者が Aspose.Slides for Python via .NET を使用してスライドにシンプルまたは書式設定された長方形を追加する方法を解説しました。プレゼンテーションの選択したスライドにシンプルな長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
4. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しています。

```py
import aspose.slides as slides

# PPTX を表す Presentation クラスのインスタンスを生成します
with slides.Presentation() as pres:
    # 最初のスライドを取得します
    sld = pres.slides[0]

    # 長方形タイプのオートシェイプを追加します
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # PPTX ファイルをディスクに保存します
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **書式設定された長方形を作成**
スライドに書式設定された長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
4. 長方形の塗りつぶしタイプを Solid（単色）に設定します。
5. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、長方形の色を設定します。
6. 長方形の線の色を設定します。
7. 長方形の線の幅を設定します。
8. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

上記の手順は、以下の例で実装されています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX を表す Presentation クラスのインスタンスを生成します
with slides.Presentation() as pres:
    # 最初のスライドを取得します
    sld = pres.slides[0]

    # 長方形タイプのオートシェイプを追加します
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 長方形シェイプにいくつかの書式設定を適用します
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 長方形の線にいくつかの書式設定を適用します
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # PPTX ファイルをディスクに保存します
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**角が丸い長方形はどう追加しますか？**  
角丸の [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリの調整により、コーナーごとに丸めることも可能です。

**画像（テクスチャ）で長方形を塗りつぶすには？**  
画像（テクスチャ）で長方形を塗りつぶすには、ピクチャ [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) を設定します。

**長方形に影やグローを付けることはできますか？**  
はい。[外部/内部影、グロー、ソフトエッジ](/slides/ja/python-net/shape-effect/) は、調整可能なパラメータで利用できます。

**長方形をハイパーリンク付きのボタンに変換できますか？**  
はい。シェイプをクリックしたときに [ハイパーリンクを割り当てる](/slides/ja/python-net/manage-hyperlinks/) ことで、スライド、ファイル、ウェブアドレス、またはメールへジャンプできます。

**長方形を移動や変更から保護するには？**  
[シェイプロックを使用する](/slides/ja/python-net/applying-protection-to-presentation/): 移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**長方形をラスタ画像または SVG に変換できますか？**  
はい。指定したサイズ/スケールで画像に [シェイプをレンダリング](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) したり、ベクター用途のために [SVG としてエクスポート](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) したりできます。

**テーマや継承を考慮した長方形の実際（有効）プロパティをすばやく取得するには？**  
[シェイプの有効プロパティを使用する](/slides/ja/python-net/shape-effective-properties/): API はテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返し、書式分析を簡素化します。