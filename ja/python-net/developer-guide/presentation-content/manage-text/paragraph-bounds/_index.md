---
title: Python でプレゼンテーションから段落境界を取得する
linktitle: 段落境界
type: docs
weight: 43
url: /ja/python-net/paragraph-bounds/
keywords:
- 段落境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET 経由で Python 用 Aspose.Slides の段落境界を取得し、PowerPoint および OpenDocument プレゼンテーションでのテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides で段落の境界、サイズ、座標を取得する方法を説明します。[Paragraph.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/get_rect/) を使用して [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) から段落の矩形を取得する方法、テーブルセルのテキストフレーム内の段落座標を取得する方法、測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、効果的な段落書式設定値などの重要な詳細をハイライトします。

## **段落の矩形座標を取得する**

段落のバウンディング矩形を取得するには、[Paragraph.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/get_rect/) を使用します。

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **テーブルセル TextFrame 内の段落のサイズを取得する**

[Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) のサイズと座標をテーブルセルのテキストフレーム内で取得するには、[Paragraph.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/get_rect/) を使用します。返される矩形はテーブルセルのテキストフレームに対して相対的であるため、スライドレベルの座標が必要な場合はテーブルの位置とセルのオフセットを加算してください。

以下の例では、テーブルセル内の段落の境界を取得し、スライド上に矩形を描画してその境界を可視化します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**段落の座標はどの単位で測定されますか？**

ポイント単位で測定されます。1インチは 72 ポイントに相当します。この単位はスライド上のすべての座標と寸法に適用されます。

**文字折り返しは段落の境界に影響しますか？**

はい。[TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/wrap_text/) が [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) で有効になっている場合、テキストはエリアの幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに確実に変換できますか？**

はい。ポイントをピクセルに変換するには、次の式を使用します: ピクセル = ポイント × (DPI / 72)。結果は、レンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[effective paragraph formatting data structure](/slides/ja/python-net/shape-effective-properties/) を使用します。インデント、間隔、折り返し、RTL などの最終的に統合された値を返します。