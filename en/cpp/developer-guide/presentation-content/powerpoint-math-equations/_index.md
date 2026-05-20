---
title: Add Math Equations to PowerPoint Presentations in C++
linktitle: PowerPoint Math Equations
type: docs
weight: 80
url: /cpp/powerpoint-math-equations/
keywords:
- math equation
- math symbol
- math formula
- math text
- add math equation
- add math symbol
- add math formula
- add math text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Insert and edit math equations in PowerPoint PPT and PPTX with Aspose.Slides for C++, supporting OMML, formatting controls, and clear C++ code samples."
---

## **Overview**

PowerPoint stores equations as Office Math Markup Language (OMML). With Aspose.Slides for C++, you can create the same kind of math content programmatically: fractions, radicals, functions, limits, N-ary operators, matrices, arrays, and formatted math blocks.

In PowerPoint, users normally add equations from **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

The result is editable math text on the slide:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides builds that math text through three main objects:

- A math shape, created with [AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/), is the shape that contains the equation.
- [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) stores math content inside the shape text frame.
- [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) contains one or more [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) objects.

Most examples below use [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) and the fluent methods from [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) to keep the code short and readable.

For MathML export scenarios, see [Export Math Equations from Presentations in C++](/slides/cpp/exporting-math-equations/).

## **Create an Equation**

This example creates a math shape and adds the Pythagorean theorem:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        ->SetSuperscript(u"2")
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}}

`AddMathShape` creates a shape that already contains a math paragraph. Access the first `MathPortion`, get its `MathParagraph`, and add math blocks or math elements to it.

{{% /alert %}}

## **Add Fractions**

Use `Divide` to create a fraction. You can choose a fraction style with [MathFractionTypes](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        ->Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
```

For a stacked fraction, use `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Add Radicals**

Use `Radical` to create a square root, cube root, or other root. The current element becomes the base, and the argument becomes the degree.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        ->Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
```

## **Add Functions and Limits**

Use `AsArgumentOfFunction` or `Function` for functions such as `sin(x)`, `log(x)`, or custom function names. For limits, put `lim` in a [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) or use `SetLowerLimit`.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        ->SetLowerLimit(u"x→∞")
        ->Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
```

For a custom function name, make the function name the current element:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Add N-ary Operators and Integrals**

Use `Nary` for summations, unions, intersections, and other large operators. Use `Integral` for integrals. Both methods let you set lower and upper limits.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        ->SetSuperscript(u"k")
        ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
```

N-ary operators are for large operators with optional limits. Simple operators such as `+`, `-`, and `=` are usually added as `MathematicalText` and joined into the expression.

For an integral, use `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Add Matrices**

Use [MathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) for rows and columns. Matrices do not include brackets by default, so enclose the matrix when you need parentheses, brackets, or braces.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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
```

## **Add Equation Arrays**

Use `ToMathArray` when you need aligned equations or a vertical stack of expressions.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        ->Join(u"y")
        ->ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
```

## **Add Trigonometric Functions**

Use `AsArgumentOfFunction` when the argument is the current element and the function name is known.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        ->AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
```

## **Add Subscripts and Superscripts**

Use the subscript and superscript helpers for indexes and powers. When the indexes must appear on the left side of the base, use `SetSubSuperscriptOnTheLeft`.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        ->SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
```

## **Add Delimiters**

Use `Enclose` to put an expression inside delimiters. You can also pass a separator character for delimiter expressions that contain several elements.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        ->Join(u"y")
        ->Join(u"z")
        ->Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
```

## **Add a Border Box**

Use `ToBorderBox` when the equation itself should be framed.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        ->ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
```

## **Group Terms**

Use `Group` to place a grouping character above or below an expression. Add a limit to label the grouped terms.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        ->Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        ->SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
```

## **Format Math Elements**

Use formatting helpers only where they clarify the formula. For example, `Overbar` places a bar above a math element.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
```

## **Quick Reference**

| Task | Main API |
| --- | --- |
| Create a math shape | [ShapeCollection.AddMathShape](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/) |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Combine elements | [IMathElement.Join](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/) |
| Create fractions | [IMathElement.Divide](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Add superscript or subscript | [SetSuperscript](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Add functions | [Function](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Add radicals | [IMathElement.Radical](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Add limits | [SetLowerLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Add left-side scripts | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Add summations and integrals | [Nary](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) |
| Add equation arrays | [ToMathArray](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Add delimiters | [Enclose](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Add bars and borders | [Overbar](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Group terms | [Group](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Can I edit an existing PowerPoint equation?**

Yes. Open the presentation, find the shape that contains a `MathPortion`, get its `MathParagraph`, and update the math blocks in that paragraph.

**Are equations saved as editable PowerPoint math?**

Yes. When you save to PPTX, Aspose.Slides writes the equation as editable Office math content.

**Can I export equations to LaTeX?**

Aspose.Slides exports math equations to MathML. If you need LaTeX, export to MathML first and then convert MathML with a tool that supports your target LaTeX dialect.
