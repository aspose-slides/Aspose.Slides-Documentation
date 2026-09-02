---
title: 从演示文稿中导出 C++ 的数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/cpp/exporting-math-equations/
keywords:
- 导出数学公式
- 将公式导出为 LaTeX
- PowerPoint 转 LaTeX
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 直接将 PowerPoint 演示文稿中的数学公式导出为 LaTeX 或 MathML。"
---
## **介绍**

Aspose.Slides for C++ 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片（来自特定演示文稿）上的数学公式，并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 
您可以直接将公式导出为 LaTeX 或 MathML，后者是 Web 和许多应用程序中使用的流行数学内容标准。
{{% /alert %}}

## **将数学公式导出为 LaTeX**

Aspose.Slides 可以直接将 PowerPoint 数学公式转换为 LaTeX；无需中间的 MathML 文件或外部转换器。数学公式以文本框的形式存储为一个 [IMathPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathportion/)。使用 [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) 获取一个 [IMathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathparagraph/)，随后调用 [IMathParagraph::ToLatex](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathparagraph/tolatex/)。该方法返回一个字符串，您可以保存、显示、发送给其他应用程序或进一步处理。

以下示例检查每一张幻灯片上的所有文本框，查找所有数学片段，并将每个公式写入单独的 `.tex` 文件：

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/getalltextboxes/) 返回幻灯片上找到的所有文本框。[IMathPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathportion/) 类型检查将真正的可编辑公式与普通文本和图像区分开来。

LaTeX 引擎和文档模板并不全部支持相同的命令、包或 Unicode 字符。请使用您应用程序使用的 LaTeX 引擎测试返回的字符串。如果某个符号或 Office Math 元素在该环境中没有合适的表示，请在返回的字符串中用项目特定的命令替换，或跳过该公式并记录问题以供审查。

## **将数学公式保存为 MathML**

虽然人们可以轻松编写 LaTeX 等某些公式格式的代码，但由于 MathML 旨在由应用程序自动生成，编写其代码会比较困难。程序能够轻松读取和解析 MathML，因为其代码是 XML，因此 MathML 在许多领域被广泛用作输出和打印格式。

以下示例代码展示了如何将演示文稿中的数学公式导出为 MathML：

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **常见问题**

**究竟是导出 MathML 的段落还是单个公式块？**

您可以将整个数学段落 ([MathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathparagraph/)) 或单个块 ([MathBlock](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathblock/)) 导出为 MathML。两种类型都提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于一个 [MathPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathportion/) 中，并且拥有一个 [MathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathparagraph/) 的图像和普通文本片段不是可导出的公式。

**演示文稿中的 MathML 来源是什么——它是 PowerPoint 特有的还是标准？**

导出目标是标准 MathML (XML)。Aspose 使用 Presentation MathML——标准的呈现子集——它在各类应用和网络中被广泛使用。

**是否支持导出表格、SmartArt、组等中的公式？**

是的，如果这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathparagraph/) 的文本片段（即真正的 PowerPoint 公式），则会被导出。如果公式以图像形式嵌入，则不会被导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。