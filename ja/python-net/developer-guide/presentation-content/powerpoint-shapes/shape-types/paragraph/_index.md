---
title: Pythonでプレゼンテーションから段落の境界を取得
linktitle: 段落
type: docs
weight: 60
url: /ja/python-net/paragraph/
keywords:
- 段落の境界
- テキスト部分の境界
- 段落の座標
- 部分の座標
- 段落のサイズ
- テキスト部分のサイズ
- テキストフレーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにおけるテキスト配置を最適化するために、段落とテキスト部分の境界を取得する方法を学びます。"
---

## **テキストフレーム内の段落と部分の座標を取得**
Aspose.Slides for Python via .NET を使用すると、開発者は TextFrame の段落コレクション内の Paragraph の矩形座標を取得できます。また、段落の部分コレクション内の Portion の座標も取得できます。このトピックでは、例を使って段落の矩形座標と段落内の部分の位置を取得する方法を示します。

## **段落の矩形座標を取得**
新しいメソッド **GetRect()** が追加されました。これにより段落の境界矩形を取得できます。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **テーブルセルのテキストフレーム内の段落と部分のサイズを取得** ##

テーブルセルのテキストフレーム内で、[部分](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) または [段落](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) のサイズと座標を取得するには、[IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) と [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) メソッドを使用できます。

このサンプルコードは上記の操作を示しています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**段落およびテキスト部分の座標はどの単位で返されますか？**

ポイント単位です。1インチ = 72ポイントです。これはスライド上のすべての座標と寸法に適用されます。

**単語の折り返しは段落の境界に影響しますか？**

はい。[折り返し](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) が [テキストフレーム](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) で有効になっている場合、テキストはエリア幅に合わせて改行され、段落の実際の境界が変わります。

**段落の座標をエクスポート画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換するには、pixels = points × (DPI / 72) を使用します。結果はレンダリング/エクスポート時に選択された DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[実効段落書式設定データ構造](/slides/ja/python-net/shape-effective-properties/) を使用します。インデント、間隔、折り返し、RTL などの最終的に統合された値を返します。