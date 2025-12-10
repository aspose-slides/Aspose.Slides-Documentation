---
title: 从演示文稿中导出 C++ 的数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/cpp/exporting-math-equations/
keywords:
- 导出数学公式
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 中的数学公式无缝导出为 MathML——保持格式并提升兼容性。"
---

## **从演示文稿导出数学公式**

Aspose.Slides for C++ 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片（特定演示文稿）上的数学公式，并将在其他程序或平台中使用它们。

{{% alert color="primary" %}} 
您可以将公式导出为 MathML，这是一种在 Web 和许多应用程序中常见的数学公式及类似内容的流行格式或标准。 
{{% /alert %}}

虽然人类可以轻松编写 LaTeX 等某些公式格式的代码，但他们在编写 MathML 代码时会感到困难，因为后者旨在由应用程序自动生成。程序可以轻松读取和解析 MathML，因为其代码采用 XML，因而 MathML 在许多领域常被用作输出和打印格式。

下面的示例代码演示了如何将演示文稿中的数学公式导出为 MathML：
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")
                ->SetSuperscript(u"2"))
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"c")
                ->SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```


## **常见问题**

**究竟是导出 MathML 的段落还是单个公式块？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)）导出为 MathML。这两种类型都提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) 中，并具有 [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来源是什么——是 PowerPoint 专有的还是标准的？**

导出目标是标准的 MathML（XML）。Aspose 使用的是 Presentation MathML——标准的演示子集，已在各类应用程序和 Web 中广泛使用。

**是否支持导出表格、SmartArt、组合等中的公式？**

是的，若这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），则会导出。若公式以图像形式嵌入，则不会。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。