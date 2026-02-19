---
title: 数式テキスト
type: docs
weight: 160
url: /ja/net/examples/elements/math-text/
keywords:
- 数式テキスト
- 数式テキストの追加
- 数式テキストへのアクセス
- 数式テキストの削除
- 数式テキストの書式設定
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の MathematicalText の例を調査し、C# を使用して PPT、PPTX、ODP プレゼンテーションで方程式、分数、行列、記号を作成および書式設定します。"
---
この記事では、**Aspose.Slides for .NET** を使用して、数式テキストシェイプの操作と方程式の書式設定を行う方法を示します。

## **数式テキストの追加**

分数とピタゴラスの定理を含む数式シェイプを作成します。

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // スライドに数式シェイプを追加します。
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 数式段落にアクセスします。
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

## **数式テキストにアクセスする**

スライド上で数式段落を含むシェイプを検索します。

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // 数式段落を含む最初のシェイプを見つけます。
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 例: 分数を作成します（ここでは追加しません）。
        var fraction = new MathematicalText("x").Divide("y");

        // 必要に応じて mathParagraph または fraction を使用します...
    }
}
```

## **数式テキストの削除**

スライドから数式シェイプを削除します。

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

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
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```