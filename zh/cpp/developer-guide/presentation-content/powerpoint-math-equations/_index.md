---
title: 在 C++ 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/cpp/powerpoint-math-equations/
keywords:
- 数学等式
- 数学符号
- 数学公式
- 数学文本
- 添加数学等式
- 添加数学符号
- 添加数学公式
- 添加数学文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 C++ 示例代码。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for C++，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **Insert > Equation** 添加公式：

![PowerPoint 插入选项卡，已选择 Equation 命令](powerpoint-math-equations_1.png)

结果是在幻灯片上可编辑的数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 一个数学形状，由 [AddMathShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shapecollection/) 创建，用于包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathportion/) 将数学内容存储在形状的文本框中。
- [MathParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathematicaltext/) 和来自 [IMathElement](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/) 的流式方法，以保持代码简洁易读。

有关 MathML 导出场景，请参阅 [在 C++ 中从演示文稿导出数学公式](/slides/zh/cpp/exporting-math-equations/)。

## **创建公式**

此示例创建一个数学形状并添加勾股定理：

![公式 c² = a² + b²](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` 创建一个已经包含数学段落的形状。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 `Divide` 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathfractiontypes/) 选择分数样式。

![显示 1 除以 x 的倾斜数学分数](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

对于堆叠分数，使用 `MathFractionTypes::Bar`：

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **添加根式**

使用 `Radical` 创建平方根、立方根或其他根式。当前元素成为底数，参数成为指数。

![一个 n 次根式，x 位于根号下](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **添加函数和极限**

使用 `AsArgumentOfFunction` 或 `Function` 来表示 `sin(x)`、`log(x)` 等函数或自定义函数名。对于极限，在 [MathLimit](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathlimit/) 中放置 `lim`，或使用 `SetLowerLimit`。

![当 x 趋近于无穷大时的极限](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

对于自定义函数名，将函数名设为当前元素：

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **添加 N 元运算符和积分**

使用 `Nary` 进行求和、并集、交集等大型运算符。使用 `Integral` 进行积分。两者都可以设置上下限。

![带有上下限的求和符号](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

N 元运算符用于带可选上下限的大型运算符。像 `+`、`-`、`=` 这样的简单运算符通常作为 `MathematicalText` 添加并组合到表达式中。

对于积分，使用 `Integral`：

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathmatrix/) 来定义行列。矩阵默认不包含括号，因此在需要圆括号、方括号或大括号时请自行包裹矩阵。

![一个两行矩阵，其中一个单元格为空](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **添加公式数组**

当需要对齐的公式或垂直堆叠的表达式时，使用 `ToMathArray`。

![垂直数学数组，x 位于 y 上方](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **添加三角函数**

当参数是当前元素且函数名已知时，使用 `AsArgumentOfFunction`。

![三角函数 cos 作用于 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **添加下标和上标**

使用下标和上标助手来表示索引和幂。当索引需要出现在基数左侧时，使用 `SetSubSuperscriptOnTheLeft`。

![首字母 Y，左侧下标 1，右侧上标 n](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **添加分隔符**

使用 `Enclose` 将表达式放入分隔符中。对于包含多个元素的分隔符表达式，还可以设置分隔字符。

![包含 x、y、z 并以竖线分隔的分隔符表达式](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **添加带边框的框**

当公式本身需要加框时，使用 `ToBorderBox`。

![带框的公式，a² = b² + c²](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **分组项**

使用 `Group` 在表达式上方或下方放置分组字符。添加限制以标记分组的项。

![表达式 x + y 被分组，下面带有标签任意文本](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **格式化数学元素**

仅在有助于阐明公式时使用格式化助手。例如，`Overbar` 在数学元素上方添加横线。

![数学表达式 ABC 带有上划线](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathematicaltext/) |
| 合并元素 | [IMathElement.Join](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/join/) |
| 创建分数 | [IMathElement.Divide](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/divide/) |
| 添加上标或下标 | [SetSuperscript](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| 添加函数 | [Function](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 添加根式 | [IMathElement.Radical](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/radical/) |
| 添加极限 | [SetLowerLimit](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 添加左侧脚本 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 添加求和和积分 | [Nary](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/integral/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/mathmatrix/) |
| 添加公式数组 | [ToMathArray](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| 添加分隔符 | [Enclose](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| 添加横线和边框 | [Overbar](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分组项 | [Group](https://reference.aspose.com/slides/zh/cpp/aspose.slides.mathtext/imathelement/group/) |

## **常见问题**

**是否可以编辑现有的 PowerPoint 公式？**

可以。打开演示文稿，找到包含 `MathPortion` 的形状，获取其 `MathParagraph`，并更新该段落中的数学块。

**公式是否保存为可编辑的 PowerPoint 数学内容？**

是的。保存为 PPTX 时，Aspose.Slides 会将公式写入为可编辑的 Office 数学内容。

**是否可以将公式导出为 LaTeX？**

Aspose.Slides 将数学公式导出为 MathML。如果需要 LaTeX，请先导出为 MathML，然后使用支持目标 LaTeX 方言的工具将 MathML 转换为 LaTeX。