---
title: 在 .NET 中从演示文稿导出数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/net/exporting-math-equations/
keywords:
- 导出数学公式
- 将公式导出为 LaTeX
- PowerPoint 转 LaTeX
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，直接将 PowerPoint 演示文稿中的数学公式导出为 LaTeX 或 MathML。"
---
## **介绍**

Aspose.Slides for .NET 允许您从演示文稿中导出数学公式。例如，您可能需要从幻灯片（特定演示文稿）中提取数学公式并在其他程序或平台中使用它们。

{{% alert color="info" %}} 
您可以直接将公式导出为 LaTeX 或 MathML，后者是用于 Web 和许多应用程序的流行数学内容标准。
{{% /alert %}}

## **导出数学公式为 LaTeX**

Aspose.Slides 可以直接将 PowerPoint 数学公式转换为 LaTeX；无需中间 MathML 文件或外部转换器。数学公式存储在文本框中，形式为 [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/)。使用 [MathPortion.MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/mathparagraph/) 获取 [IMathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathparagraph/)，然后调用 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathparagraph/tolatex/)。该方法返回一个字符串，您可以保存、显示、发送给其他应用程序或进一步处理。

以下示例检查每张幻灯片上的每个文本框，查找所有数学部分，并将每个公式写入单独的 `.tex` 文件：

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextboxes/) 返回幻灯片上找到的所有文本框。[MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 类型检查将真正可编辑的公式与普通文本和图像分离。

LaTeX 引擎和文档模板并不全部支持相同的命令、包或 Unicode 字符。请使用您应用程序使用的 LaTeX 引擎测试返回的字符串。如果某个符号或 Office Math 元素在该环境中没有合适的表示，请在返回的字符串中用项目特定的命令替换它，或跳过该公式并记录问题以供审查。

## **将数学公式保存为 MathML**

虽然人们可以轻松编写 LaTeX 等某些公式格式的代码，但编写 MathML 代码却比较困难，因为后者旨在由应用程序自动生成。程序能够轻松读取和解析 MathML，因为其代码是 XML，所以 MathML 在许多领域被广泛用作输出和打印格式。

此示例代码演示如何将演示文稿中的数学公式导出为 MathML：

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **常见问题**

**到底是导出整个段落还是单个公式块到 MathML？**  
您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathblock/)）导出为 MathML。两种类型都提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**  
公式存在于 [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 中，并且具有 [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来自何处——是 PowerPoint 特有的还是标准？**  
导出目标是标准 MathML（XML）。Aspose 使用的是 Presentation MathML——标准的呈现子集，已在各类应用和 Web 中广泛使用。

**是否支持导出表格、SmartArt、组合等内部的公式？**  
是的，只要这些对象包含具有 [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），就会被导出。如果公式以图像形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**  
不会。写入 MathML 只是对公式内容的序列化，不会更改演示文稿文件。