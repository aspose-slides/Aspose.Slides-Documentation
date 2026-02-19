---
title: نص رياضي
type: docs
weight: 160
url: /ar/cpp/examples/elements/math-text/
keywords:
- مثال برمجي
- نص رياضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استكشف أمثلة Aspose.Slides for C++ لـ MathematicalText: إنشاء وتنسيق المعادلات، الكسور، المصفوفات والرموز باستخدام C++ في عروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية العمل مع أشكال النص الرياضي وتنسيق المعادلات باستخدام **Aspose.Slides for C++**.

## **إضافة نص رياضي**

إنشاء شكل رياضي يحتوي على كسر وصيغة فيثاغورس.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إضافة شكل رياضي إلى الشريحة.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // الوصول إلى الفقرة الرياضية.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // إضافة كسر بسيط: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // إضافة معادلة: c² = a² + b².
    auto mathBlock = MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
    mathParagraph->Add(mathBlock);

    presentation->Dispose();
}
```

## **الوصول إلى نص رياضي**

تحديد شكل يحتوي على فقرة رياضية في الشريحة.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // ابحث عن الشكل الأول الذي يحتوي على فقرة رياضية.
    auto mathShape = SharedPtr<IAutoShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto hasMath = false;
            for (auto&& paragraph : textFrame->get_Paragraphs())
            {
                for (auto&& textPortion : paragraph->get_Portions())
                {
                    if (ObjectExt::Is<MathPortion>(textPortion))
                    {
                        hasMath = true;
                        break;
                    }
                }
                if (hasMath) break;
            }
            if (hasMath)
            {
                mathShape = autoShape;
                break;
            }
        }
    }

    if (mathShape != nullptr)
    {
        auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
        auto textPortion = paragraph->get_Portion(0);
        auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

        // مثال: إنشاء كسر (غير مضاف هنا).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Use mathParagraph or fraction as needed...
    }

    presentation->Dispose();
}
```

## **إزالة نص رياضي**

حذف شكل رياضي من الشريحة.

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

    // إزالة الشكل الرياضي.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **تنسيق نص رياضي**

تحديد خصائص الخط لجزء رياضي.

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