---
title: Pythonでプレゼンテーションにライン シェイプを作成する
linktitle: ライン
type: docs
weight: 50
url: /ja/python-net/line/
keywords:
- ライン
- ラインの作成
- ラインの追加
- プレーンライン
- ラインの構成
- ラインのカスタマイズ
- ダッシュスタイル
- 矢じり
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションでラインの書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

## **概要**

Aspose.Slides for Python via .NET は、スライドにさまざまな種類のシェイプを追加することをサポートしています。このトピックでは、シェイプの操作を開始し、スライドにラインを追加します。Aspose.Slides を使用すると、開発者はシンプルなラインだけでなく、装飾的なラインもスライドに描画できます。

## **プレーンラインの作成**

Aspose.Slides を使用して、スライドにプレーンラインをシンプルな区切りやコネクタとして追加します。プレゼンテーション内の選択したスライドにプレーンラインを追加するには、次の手順に従います。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. ShapeCollection オブジェクトの `add_auto_shape` メソッドを使用して、タイプ `LINE` の AutoShape を追加します。  
4. プレゼンテーションを PPTX ファイルとして保存します。  

以下の例では、プレゼンテーションの最初のスライドにラインを追加します。

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

## **矢ジリ形状のラインの作成**

Aspose.Slides では、ラインのプロパティを設定して視覚的に魅力的にすることができます。以下では、ラインを矢じりの形に見せるためにいくつかのプロパティを設定します。手順は次の通りです。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. ShapeCollection オブジェクトの `add_auto_shape` メソッドを使用して、タイプ `LINE` の AutoShape を追加します。  
4. ラインのスタイルを設定します。  
5. ライン幅を設定します。  
6. ラインのダッシュスタイルを設定します。  
7. ラインの開始点の矢じりスタイルと長さを設定します。  
8. ラインの終了点の矢じりスタイルと長さを設定します。  
9. プレゼンテーションを PPTX ファイルとして保存します。  

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

## **よくある質問**

**通常のラインをコネクタに変換して、形状に「スナップ」させることはできますか？**

いいえ。通常のライン（タイプが LINE の AutoShape）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の Connector タイプと、接続用の対応 API を使用してください。

**ラインのプロパティがテーマから継承されていて、最終的な値が分かりにくい場合はどうすればよいですか？**

テーマや継承を考慮した実際のプロパティは、ILineFormatEffectiveData および ILineFillFormatEffectiveData クラスを通じて確認できます。これらのクラスは継承やテーマスタイルをすでに反映しています。

**ラインを編集（移動、サイズ変更）できないようにロックできますか？**

はい。シェイプにはロックオブジェクトが用意されており、編集操作を禁止できます。