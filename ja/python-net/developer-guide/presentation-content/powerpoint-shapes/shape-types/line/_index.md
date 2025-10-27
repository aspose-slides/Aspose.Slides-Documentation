---
title: Python を使用したプレゼンテーションでの直線シェイプの作成
linktitle: 直線
type: docs
weight: 50
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/line/
keywords:
- 直線
- 直線の作成
- 直線の追加
- 標準直線
- 直線の構成
- 直線のカスタマイズ
- 破線スタイル
- 矢印ヘッド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションでの直線書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルを紹介します。"
---

## **概要**

Aspose.Slides for Python via .NET は、スライドにさまざまな種類のシェイプを追加することをサポートしています。このトピックでは、スライドに直線を追加してシェイプの操作を開始します。Aspose.Slides を使用すると、単純な直線だけでなく、スライド上に装飾的な直線も描画できます。

## **標準直線の作成**

Aspose.Slides を使用して、スライドに標準の直線を追加し、区切りや接続線として利用します。プレゼンテーションの特定のスライドに標準直線を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンス化
with slides.Presentation() as presentation:

    # 最初のスライドを取得
    slide = presentation.slides[0]

    # LINE タイプのオートシェイプを追加
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # プレゼンテーションを PPTX ファイルとして保存
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **矢印形状の直線の作成**

Aspose.Slides では、直線のプロパティを設定して視覚的に魅力的にすることができます。以下では、直線を矢印のように見せるためにいくつかのプロパティを設定します。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. [線のスタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) を設定します。  
1. 線幅を設定します。  
1. 線の [破線スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) を設定します。  
1. 線の開始点の [矢印ヘッドスタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) と長さを設定します。  
1. 線の終了点の矢印ヘッドスタイルと長さを設定します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンス化
with slides.Presentation() as presentation:
    # 最初のスライドを取得
    slide = presentation.slides[0]

    # LINE タイプのオートシェイプを追加
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 線の書式設定を適用
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # プレゼンテーションを PPTX ファイルとして保存
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**通常の直線をコネクタに変換して、図形に「スナップ」させることはできますか？**

いいえ。通常の直線（[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) の [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) タイプと、接続用の [対応 API](/slides/ja/python-net/connector/) を使用してください。

**直線のプロパティがテーマから継承されており、最終的な値が分かりにくい場合はどうすればよいですか？**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) クラスを使用して、[有効プロパティを取得](/slides/ja/python-net/shape-effective-properties/) してください。これらは継承とテーマスタイルを考慮した結果を返します。

**直線を編集（移動やサイズ変更）できないようにロックできますか？**

はい。シェイプには [ロックオブジェクト](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) が用意されており、[編集操作を禁止](/slides/ja/python-net/applying-protection-to-presentation/) することができます。