---
title: Math Text
type: docs
weight: 160
url: /cpp/examples/elements/mathtext/
keywords:
- code example
- mathematical text
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Explore Aspose.Slides for C++ MathematicalText examples: create and format equations, fractions, matrices, and symbols with C++ in PPT, PPTX, and ODP presentations."
---

This article demonstrates working with mathematical text shapes and formatting equations using **Aspose.Slides for C++**.

## **Add Math Text**

Create a math shape containing a fraction and the Pythagorean formula.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Add a Math shape to the slide.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Access the math paragraph.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Add a simple fraction: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Add equation: c² = a² + b².
    auto mathBlock = MakeObject<MathematicalText>(u"c")
        ->SetSuperscript(u"2")
        ->Join(u"=")
        ->Join(MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        ->Join(u"+")
        ->Join(MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
    mathParagraph->Add(mathBlock);

    presentation->Dispose();
}
```

## **Access Math Text**

Locate a shape that contains a math paragraph on the slide.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Find the first shape that contains a math paragraph.
    auto mathShape = SharedPtr<IAutoShape>();
    for (auto&& shape : slide->get_Shapes()) {
        if (ObjectExt::Is<IAutoShape>(shape)) {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto hasMath = false;
            for (auto&& paragraph : textFrame->get_Paragraphs()) {
                for (auto&& textPortion : paragraph->get_Portions()) {
                    if (ObjectExt::Is<MathPortion>(textPortion)) {
                        hasMath = true;
                        break;
                    }
                }
                if (hasMath) break;
            }
            if (hasMath) {
                mathShape = autoShape;
                break;
            }
        }
    }

    if (mathShape != nullptr) {
        auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
        auto textPortion = paragraph->get_Portion(0);
        auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

        // Example: create a fraction (not added here).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Use mathParagraph or fraction as needed...
    }

    presentation->Dispose();
}
```

## **Remove Math Text**

Delete a math shape from the slide.

```cpp
static void RemoveMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);

    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Remove the math shape.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Format Math Text**

Set font properties for a math portion.

```cpp
static void FormatMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    textPortion->get_PortionFormat()->set_FontHeight(20);

    presentation->Dispose();
}
```
