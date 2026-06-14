---
title: 數學文字
type: docs
weight: 160
url: /zh-hant/net/examples/elements/math-text/
keywords:
- 數學文字
- 新增數學文字
- 取得數學文字
- 移除數學文字
- 格式化數學文字
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的 MathematicalText 範例：使用 C# 在 PPT、PPTX 和 ODP 簡報中建立與格式化方程式、分數、矩陣與符號。"
---
本文示範如何使用 **Aspose.Slides for .NET** 來處理數學文字圖形並格式化方程式。

## **新增數學文字**

建立包含分數與畢氏定理的數學圖形。

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 在投影片上新增數學圖形。
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 取得數學段落。
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // 新增簡單分數：x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // 新增方程式：c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **存取數學文字**

在投影片上找到包含數學段落的圖形。

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // 找到第一個包含數學段落的圖形。
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 範例：建立一個分數（此處未加入）。
        var fraction = new MathematicalText("x").Divide("y");

        // 根據需要使用 mathParagraph 或 fraction...
    }
}
```

## **移除數學文字**

從投影片中刪除數學圖形。

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

## **格式化數學文字**

設定數學部分的字型屬性。

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