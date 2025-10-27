---
title: Pythonでプレゼンテーションから段落の境界を取得する
linktitle: 段落
type: docs
weight: 60
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/paragraph/
keywords:
- 段落の境界
- テキスト部分の境界
- 段落座標
- 部分座標
- 段落サイズ
- テキスト部分サイズ
- テキストフレーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint や OpenDocument のプレゼンテーションでテキスト配置を最適化するために、段落およびテキスト部分の境界を取得する方法を学びます。"
---

## **テキストフレーム内の段落と部分の座標を取得する**
Aspose.Slides for Python via .NET を使用すると、開発者は TextFrame の段落コレクション内の段落の矩形座標を取得できます。また、段落の部分コレクション内の部分の座標も取得可能です。このトピックでは、例を用いて段落の矩形座標と段落内の部分の位置を取得する方法を示します。

## **段落の矩形座標を取得する**
新しいメソッド **GetRect()** が追加されました。このメソッドにより段落の境界矩形を取得できます。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **テーブルセルのテキストフレーム内の段落および部分のサイズを取得する** ##

テーブルセルのテキストフレーム内で [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) または [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) のサイズと座標を取得するには、[IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) および [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) メソッドを使用できます。

このサンプルコードは、上記の操作を示しています。

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

**段落やテキスト部分の座標はどの単位で返されますか？**

ポイント単位です。1インチ = 72ポイントです。スライド上のすべての座標と寸法はこの単位で表されます。

**ワードラップは段落の境界に影響しますか？**

はい。[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) で [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) が有効になっている場合、テキストはエリアの幅に合わせて改行され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに正確にマッピングできますか？**

はい。ポイントをピクセルに変換するには次の式を使用します: pixels = points × (DPI / 72)。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実際の」段落書式設定パラメータを取得するにはどうすればよいですか？**

[実際の段落書式設定データ構造](/slides/ja/python-net/shape-effective-properties/) を使用してください。インデント、間隔、ラップ、RTL などの最終的な統合値を返します。