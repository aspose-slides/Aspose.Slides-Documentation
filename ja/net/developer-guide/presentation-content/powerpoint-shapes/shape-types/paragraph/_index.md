---
title: 段落
type: docs
weight: 60
url: /ja/net/paragraph/
keywords: "段落, ポーション, 段落座標, ポーション座標, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションにおける C# または .NET の段落とポーション"
---

## **TextFrame の段落およびポーション座標の取得**
Aspose.Slides for .NET を使用すると、開発者は TextFrame の段落コレクション内の Paragraph の矩形座標を取得できるようになりました。また、段落のポーションコレクション内のポーションの座標も取得できます。このトピックでは、例を使って段落の矩形座標と、その段落内のポーションの位置を取得する方法を示します。

## **段落の矩形座標の取得**
新しいメソッド **GetRect()** が追加されました。これにより、段落の境界矩形を取得できます。
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **テーブルセルのテキストフレーム内の段落とポーションのサイズ取得**
テーブルセルのテキストフレーム内の [ポーション](https://reference.aspose.com/slides/net/aspose.slides/portion) または [段落](https://reference.aspose.com/slides/net/aspose.slides/paragraph) のサイズと座標を取得するには、[IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) および [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) メソッドを使用できます。

このサンプルコードは上記の操作を示しています。
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
ポイント単位です。1インチ = 72ポイントです。この単位はスライド上のすべての座標と寸法に適用されます。

**単語ラップは段落の境界に影響しますか？**  
はい。[wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) が [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) で有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに確実にマッピングできますか？**  
はい。ポイントをピクセルに変換するには、次の式を使用します: pixels = points × (DPI / 72)。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「effective」段落書式設定パラメータはどう取得しますか？**  
[effective paragraph formatting data structure](/slides/ja/net/shape-effective-properties/) を使用します。これにより、インデント、間隔、ラップ、RTL などの最終的な統合値が返されます。