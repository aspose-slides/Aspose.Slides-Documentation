---
title: Python でプレゼンテーションにライン シェイプを作成する
linktitle: ライン
type: docs
weight: 50
url: /ja/python-net/line/
keywords:
- 線
- 線の作成
- 線の追加
- プレーンな線
- 線の構成
- 線のカスタマイズ
- 破線スタイル
- 矢尻
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでラインの書式設定を操作する方法を学びます。プロパティ、メソッド、例をご紹介します。"
---

## **概要**

Aspose.Slides for Python via .NET は、スライドにさまざまな種類のシェイプを追加することをサポートしています。このトピックでは、シェイプの操作を開始し、スライドに線を追加します。Aspose.Slides を使用すると、開発者は単純な線だけでなく、装飾的な線もスライドに描画できます。

## **プレーンな線の作成**

Aspose.Slides を使用して、スライドにプレーンな線をシンプルな区切りまたはコネクタとして追加します。プレゼンテーション内の選択したスライドにプレーンな線を追加するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線が追加されています。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # タイプ LINE のオートシェイプを追加します。
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **矢印形状の線の作成**

Aspose.Slides では、線のプロパティを設定して視覚的に魅力的にできます。以下では、線を矢印のように見せるためにいくつかのプロパティを設定します。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. [線のスタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) を設定します。
5. 線の幅を設定します。
6. 線の [破線スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) を設定します。
7. 線の開始点の [矢尻スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) と長さを設定します。
8. 線の終了点の矢尻スタイルと長さを設定します。
9. プレゼンテーションを PPTX ファイルとして保存します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # タイプ LINE のオートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 線の書式設定を適用します。
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```


## **よくある質問**

**通常の線をコネクタに変換して、シェイプに「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) の [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。シェイプにスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/python-net/connector/) を使用してください。

**テーマから継承された線のプロパティが最終値を把握しにくい場合、どうすればよいですか？**

[有効なプロパティを読む](/slides/ja/python-net/shape-effective-properties/) を [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) クラスを通じて行います—これらはすでに継承およびテーマスタイルを考慮しています。

**線を編集（移動、サイズ変更）できないようにロックできますか？**

はい。シェイプは [ロック オブジェクト](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) を提供し、[編集操作の禁止](/slides/ja/python-net/applying-protection-to-presentation/) を行うことができます。