---
title: ポーション
type: docs
weight: 70
url: /net/portion/
keywords: "ポーション, PowerPoint シェイプ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションのポーションを取得"
---

## **ポーションの位置座標を取得**
**GetCoordinates()** メソッドが IPortion および Portion クラスに追加され、ポーションの開始位置の座標を取得できるようになりました:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "座標 X =" + point.X + " 座標 Y =" + point.Y);
        }
    }
}
```