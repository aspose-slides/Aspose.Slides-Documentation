---
title: 数学文本
type: docs
weight: 160
url: /zh/net/examples/elements/math-text/
keywords:
- 数学文本示例
- 添加数学文本
- 访问数学文本
- 删除数学文本
- 格式化数学文本
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中处理数学文本：创建和编辑方程式、分数、根式、上下标、格式，并渲染 PPT 和 PPTX 的结果。"
---

演示如何使用 **Aspose.Slides for .NET** 处理数学文本形状并格式化公式。

## **添加数学文本**

创建一个包含分数和勾股公式的数学形状。
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 向幻灯片添加一个数学形状
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 访问数学段落
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // 添加一个简单分数：x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // 添加等式：c² = a² + b²
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

定位幻灯片中包含数学段落的形状。
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 查找包含数学段落的第一个形状
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 示例：创建一个分数（此处未添加）
        var fraction = new MathematicalText("x").Divide("y");

        // 根据需要使用 mathParagraph 或 fraction...
    }
}
```


## **删除数学文本**

从幻灯片中删除数学形状。
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


## **格式化数学文本**

为数学部分设置字体属性。
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
