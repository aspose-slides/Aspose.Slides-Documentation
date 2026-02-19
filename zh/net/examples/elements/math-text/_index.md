---
title: 数学文本
type: docs
weight: 160
url: /zh/net/examples/elements/math-text/
keywords:
- 数学文本
- 添加数学文本
- 访问数学文本
- 删除数学文本
- 格式化数学文本
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的 MathematicalText 示例：在 PPT、PPTX 和 ODP 演示文稿中使用 C# 创建和格式化方程式、分数、矩阵和符号。"
---
本文演示了使用 **Aspose.Slides for .NET** 处理数学文本形状并格式化公式。

## **添加数学文本**

创建一个包含分数和勾股公式的数学形状。

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 向幻灯片添加数学形状。
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 访问数学段落。
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // 添加一个简单分数：x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // 添加公式：c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **访问数学文本**

定位幻灯片上包含数学段落的形状。

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // 找到第一个包含数学段落的形状。
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 示例：创建一个分数（此处未添加）。
        var fraction = new MathematicalText("x").Divide("y");

        // 根据需要使用 mathParagraph 或 fraction。
    }
}
```

## **删除数学文本**

从幻灯片中删除数学形状。

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

## **格式化数学文本**

设置数学部分的字体属性。

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