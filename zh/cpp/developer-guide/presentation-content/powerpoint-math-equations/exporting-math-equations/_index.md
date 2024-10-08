---
title: 导出数学方程
type: docs
weight: 30
url: /zh/cpp/exporting-math-equations/

---

# 从演示文稿中导出数学方程

Aspose.Slides for C++ 允许您从演示文稿中导出数学方程。例如，您可能需要提取幻灯片上的数学方程（来自特定演示文稿）并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将方程导出为 MathML，这是一种流行的数学方程和类似内容在网络和许多应用程序中使用的格式或标准。

{{% /alert %}}

虽然人类可以轻松为一些方程格式（如 LaTeX）编写代码，但在编写 MathML 的代码时却很困难，因为后者是由应用程序自动生成的。程序容易读取和解析 MathML，因为其代码采用 XML 格式，因此 MathML 在许多领域被广泛用作输出和打印格式。

以下示例代码演示了如何将数学方程从演示文稿导出为 MathML：

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