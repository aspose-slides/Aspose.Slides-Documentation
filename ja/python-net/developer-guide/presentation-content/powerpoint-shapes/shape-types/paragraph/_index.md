---
title: 段落
type: docs
weight: 60
url: /python-net/paragraph/
keywords: "段落, ポーション, 段落座標, ポーション座標, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonにおけるPowerPointプレゼンテーションの段落とポーション"
---

## **TextFrame内の段落とポーションの座標を取得する**
Aspose.Slides for Python via .NETを使用すると、開発者はTextFrameの段落コレクション内の段落の矩形座標を取得できるようになりました。これにより、段落内のポーションコレクション内のポーションの座標も取得できます。本トピックでは、段落の矩形座標と段落内のポーションの位置を取得する方法を例を用いて示します。

## **段落の矩形座標を取得する**
新しいメソッド**GetRect()**が追加されました。これにより、段落の境界矩形を取得できます。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **テーブルセルのテキストフレーム内の段落とポーションのサイズを取得する** ##

テーブルセルのテキストフレーム内で[ポーション](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)または[段落](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)のサイズと座標を取得するには、[IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/)および[IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)メソッドを使用できます。

このサンプルコードは、説明した操作を示しています：

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