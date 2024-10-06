---
title: 段落
type: docs
weight: 60
url: /ja/net/paragraph/
keywords: "段落, ポーション, 段落座標, ポーション座標, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションの段落とポーション"
---

## **TextFrame内の段落とポーションの座標を取得する**
Aspose.Slides for .NETを使用すると、開発者はTextFrameの段落コレクション内の段落の矩形座標を取得できます。また、段落内のポーションのポーションコレクション内の座標を取得することも可能です。このトピックでは、段落の矩形座標と段落内のポーションの位置を取得する方法を例を使って説明します。

## **段落の矩形座標を取得する**
新しいメソッド**GetRect()**が追加されました。これは、段落の境界矩形を取得することを可能にします。

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **テーブルセルのテキストフレーム内の段落とポーションのサイズを取得する** ##

テーブルセルのテキストフレーム内で[ポーション](https://reference.aspose.com/slides/net/aspose.slides/portion)や[段落](https://reference.aspose.com/slides/net/aspose.slides/paragraph)のサイズと座標を取得するには、[IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect)メソッドと[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect)メソッドを使用できます。

このサンプルコードは、説明した操作を示しています：

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```