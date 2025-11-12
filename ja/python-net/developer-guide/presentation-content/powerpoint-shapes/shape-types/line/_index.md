---
title: Pythonでプレゼンテーションにラインシェイプを作成する
linktitle: ライン
type: docs
weight: 50
url: /ja/python-net/line/
keywords:
- ライン
- ラインの作成
- ラインの追加
- 単純ライン
- ラインの設定
- ラインのカスタマイズ
- 破線スタイル
- 矢じり
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでラインの書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

## **概要**

Aspose.Slides for Python via .NET は、スライドにさまざまな種類のシェイプを追加する機能をサポートしています。本トピックでは、スライドにラインを追加してシェイプの操作を開始します。Aspose.Slides を使用すると、単純なラインだけでなく、装飾的なラインもスライドに描画できます。

## **単純ラインの作成**

Aspose.Slides を使用して、スライドに単純なラインを区切り線やコネクタとして追加します。プレゼンテーションの対象スライドに単純ラインを追加するには、次の手順に従います。

1. [プレゼンテーション] クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. [ShapeCollection] オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape] を追加します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # LINE タイプのオートシェイプを追加します。
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **矢じり付きラインの作成**

Aspose.Slides では、ラインのプロパティを設定して視覚的に魅力的にできます。以下では、ラインを矢じりの形にするためにいくつかのプロパティを設定します。手順は次の通りです。

1. [プレゼンテーション] クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. [ShapeCollection] オブジェクトの `add_auto_shape` メソッドを使用して、`LINE` タイプの [AutoShape] を追加します。
4. [ラインスタイル] を設定します。
5. ライン幅を設定します。
6. ラインの [破線スタイル] を設定します。
7. ラインの開始点に対して [矢じりスタイル] と長さを設定します。
8. ラインの終了点に対して矢じりスタイルと長さを設定します。
9. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # LINE タイプのオートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # ラインに書式設定を適用します。
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

**通常のラインをコネクタに変換して、図形に「スナップ」させることはできますか？**

いいえ。通常のライン（[AutoShape] の [LINE] タイプ）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector] タイプと、接続用の [対応する API](/slides/ja/python-net/connector/) を使用してください。

**ラインのプロパティがテーマから継承されており、最終的な値を把握しにくい場合はどうすればよいですか？**

[有効プロパティを読む](/slides/ja/python-net/shape-effective-properties/) には、[ILineFormatEffectiveData] と [ILineFillFormatEffectiveData] クラスを使用します。これらは継承とテーマスタイルをすでに考慮した状態で情報を提供します。

**ラインの編集（移動、サイズ変更）をロックすることはできますか？**

はい。シェイプは [ロック オブジェクト] を提供しており、[編集操作の禁止](/slides/ja/python-net/applying-protection-to-presentation/) が可能です。