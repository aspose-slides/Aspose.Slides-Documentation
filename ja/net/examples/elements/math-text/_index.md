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
description: "Aspose.Slides を使用して C# で数式テキストを操作します。方程式、分数、根号、スクリプト、書式設定を作成および編集し、PPT および PPTX 用に結果をレンダリングします。"
---

**Aspose.Slides for .NET** を使用して、数学テキストシェイプの操作と方程式の書式設定を示します。

## Add Math Text

分数とピタゴラスの定理を含む数式シェイプを作成します。
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // スライドに数式シェイプを追加します
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 数式段落にアクセスします
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // 単純な分数を追加します: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // 方程式を追加します: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```


## Access Math Text

スライド上に数式段落を含むシェイプを検索します。
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 数式段落を含む最初のシェイプを検索します
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 例: 分数を作成します（ここでは追加しません）
        var fraction = new MathematicalText("x").Divide("y");

        // 必要に応じて mathParagraph または fraction を使用します...
    }
}
```


## Remove Math Text

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


## Format Math Text

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
