---
title: 数式テキスト
type: docs
weight: 160
url: /ja/net/examples/elements/math-text/
keywords:
- 数式テキスト例
- 数式テキストの追加
- 数式テキストへのアクセス
- 数式テキストの削除
- 数式テキストの書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用して数式テキストを操作します。方程式、分数、根号、スクリプト、書式設定を作成・編集し、PPT と PPTX 用に結果をレンダリングします。"
---

**Aspose.Slides for .NET** を使用した数式テキストシェイプの操作と方程式の書式設定を示します。

## **数式テキストの追加**
分数とピタゴラスの定理を含む数式シェイプを作成します。
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // スライドに数式シェイプを追加
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 数式段落にアクセス
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // シンプルな分数を追加: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // 方程式を追加: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```


## **数式テキストへのアクセス**
スライド上で数式段落を含むシェイプを検索します。
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 最初に数式段落を含むシェイプを見つける
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 例: 分数を作成する（ここでは追加しません）
        var fraction = new MathematicalText("x").Divide("y");

        // 必要に応じて mathParagraph または fraction を使用...
    }
}
```


## **数式テキストの削除**
スライドから数式シェイプを削除します。
```csharp
static void Remove_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```


## **数式テキストの書式設定**
数式部分のフォントプロパティを設定します。
```csharp
static void Format_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```
