---
title: .NET のプレゼンテーションから段落の境界を取得する
linktitle: 段落
type: docs
weight: 60
url: /ja/net/paragraph/
keywords:
- 段落の境界
- テキストポーションの境界
- 段落座標
- ポーション座標
- 段落サイズ
- テキストポーションサイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で段落とテキストポーションの境界を取得し、PowerPoint プレゼンテーションにおけるテキスト配置を最適化する方法を学びます。"
---

## **テキストフレーム内の段落とポーションの座標を取得する**
Aspose.Slides for .NET を使用すると、開発者は TextFrame の段落コレクション内の Paragraph の矩形座標を取得できるようになりました。また、段落のポーションコレクション内のポーションの座標も取得できます。本トピックでは、例を使って段落の矩形座標と段落内のポーションの位置を取得する方法を示します。

## **段落の長方形座標を取得する**
新しいメソッド **GetRect()** が追加されました。これにより段落の境界矩形を取得できます。
```c#
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **テーブルセルのテキストフレーム内の段落とポーションのサイズを取得する**
テーブルセルのテキストフレーム内で [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) または [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) のサイズと座標を取得するには、[IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) および [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) メソッドを使用できます。

このサンプルコードは上記の操作を示しています：
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


## **FAQ**

**段落およびテキストポーションの座標はどの単位で返されますか？**

ポイント単位です。1インチ = 72ポイントです。スライド上のすべての座標とサイズはこの単位が適用されます。

**ワードラップは段落の境界に影響しますか？**

はい。[wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) が [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) で有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換するには、pixels = points × (DPI / 72) を使用します。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[実効段落書式データ構造](/slides/ja/net/shape-effective-properties/) を使用します。インデント、間隔、ラップ、RTL などの最終的に統合された値を返します。