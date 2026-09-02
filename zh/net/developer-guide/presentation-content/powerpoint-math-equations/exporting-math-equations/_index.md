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
description: "使用 Aspose.Slides for .NET 直接将 PowerPoint 演示文稿中的数学公式导出为 LaTeX 或 MathML。"
---
## **简介**

Aspose.Slides for .NET 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片上的数学公式（来自特定演示文稿）并在另一个程序或平台中使用它们。

{{% alert color="primary" %}} 
您可以直接将公式导出为 LaTeX 或 MathML，MathML 是在网络和许多应用中使用的流行数学内容标准。
{{% /alert %}}

## **将数学公式导出为 LaTeX**

Aspose.Slides 能够直接将 PowerPoint 中的数学公式转换为 LaTeX；无需中间的 MathML 文件或外部转换器。数学公式以 [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 的形式存储在文本框中。使用 [MathPortion.MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/mathparagraph/) 获取 [IMathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathparagraph/)，然后调用 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathparagraph/tolatex/)。该方法返回一个字符串，您可以保存、显示、发送到其他应用程序或进一步处理。

下面的示例检查每张幻灯片上的所有文本框，查找所有数学部分，并将每个公式写入单独的 `.tex` 文件：

```csharp
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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextboxes/) 返回在幻灯片上找到的所有文本框。[MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 的类型检查将真正可编辑的公式与普通文本和图像区分开来。

LaTeX 引擎和文档模板并不都支持相同的命令、宏包或 Unicode 字符。请使用您应用程序所使用的 LaTeX 引擎测试返回的字符串。如果某个符号或 Office Math 元素在该环境中没有合适的表示，请在返回的字符串中用项目特定的命令替换它，或跳过该公式并记录问题以供审查。

## **将数学公式保存为 MathML**

虽然人们可以轻松手写 LaTeX 等某些公式格式的代码，但编写 MathML 的代码则相当困难，因为 MathML 旨在由应用程序自动生成。程序可以轻松读取和解析 MathML，因为它的代码采用 XML 形式，所以 MathML 常被用作许多领域的输出和打印格式。

此示例代码展示了如何将演示文稿中的数学公式导出为 MathML：

```c#
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

**到底导出到 MathML 的是段落还是单个公式块？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathblock/)）导出为 MathML。两种类型都提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 中，并具有 [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来源是什么——是 PowerPoint 特有的还是标准？**

导出面向标准 MathML（XML）。Aspose 使用的是 Presentation MathML——该标准的呈现子集，已在众多应用和网络中广泛使用。

**是否支持导出位于表格、SmartArt、组等中的公式？**

是的，如果这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），则会导出。如果公式以图像形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是公式内容的序列化，不会修改演示文稿文件。