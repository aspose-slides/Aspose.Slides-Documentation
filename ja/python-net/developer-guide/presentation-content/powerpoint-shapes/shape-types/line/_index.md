---
title: Pythonでプレゼンテーションにライン シェイプを作成する
linktitle: ライン
type: docs
weight: 50
url: /ja/python-net/line/
keywords:
- line
- create line
- add line
- plain line
- configure line
- customize line
- dash style
- arrow head
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

## **概要**

Aspose.Slides for Python via .NET は、スライドにさまざまな種類のシェイプを追加する機能を提供します。この項目では、スライドにラインを追加してシェイプの操作を開始します。Aspose.Slides を使用すれば、単純なラインだけでなく、装飾的なラインもスライド上に描画できます。

## **単純なラインの作成**

Aspose.Slides を使用して、スライドに単純なラインを追加し、区切り線やコネクタとして利用します。プレゼンテーションの選択したスライドに単純なラインを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しています。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Save the presentation as a PPTX file.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **矢印形状のラインの作成**

Aspose.Slides では、ラインのプロパティを設定して視覚的に魅力的にすることができます。以下では、ラインを矢印のように見せるためにいくつかのプロパティを設定します。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. [ライン スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) を設定します。
1. ラインの幅を設定します。
1. ラインの [ダッシュ スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) を設定します。
1. ラインの開始点に対する [矢尻スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) と長さを設定します。
1. ラインの終了点に対する矢尻スタイルと長さを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents the PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply formatting to the line.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Save the presentation as a PPTX file.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**通常のラインをコネクタに変換して、図形に「スナップ」させることはできますか？**

いいえ。通常のライン（[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) の `LINE` タイプ）は自動的にコネクタになりません。図形にスナップさせたい場合は、専用の [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) タイプと、接続用の [対応 API](/slides/ja/python-net/connector/) を使用してください。

**ラインのプロパティがテーマから継承されており、最終的な値が分かりにくい場合はどうすればよいですか？**

[Effective properties](/slides/ja/python-net/shape-effective-properties/) を [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) クラスで読み取ります。これらは継承やテーマ スタイルを既に考慮した上で値を提供します。

**ラインを編集（移動、サイズ変更）できないようにロックできますか？**

はい。シェイプは [ロック オブジェクト](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) を提供しており、[編集操作の禁止](/slides/ja/python-net/applying-protection-to-presentation/) が可能です。