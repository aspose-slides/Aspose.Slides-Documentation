---
title: متن ریاضی
type: docs
weight: 160
url: /fa/cpp/examples/elements/math-text/
keywords:
- مثال کد
- متن ریاضی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مثال‌های Aspose.Slides برای C++ در مورد متن ریاضی را بررسی کنید: ایجاد و قالب‌بندی معادلات، کسرها، ماتریکس‌ها و نمادها با C++ در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه کار با اشکال متن ریاضی و قالب‌بندی معادلات را با استفاده از **Aspose.Slides for C++** نشان می‌دهد.

## **افزودن متن ریاضی**

یک شکل ریاضی شامل یک کسر و فرمول فیثاغورث ایجاد کنید.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک شکل ریاضی به اسلاید اضافه کنید.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // دسترسی به پاراگراف ریاضی.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // یک کسر ساده اضافه کنید: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // یک معادله اضافه کنید: c² = a² + b².
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

## **دسترسی به متن ریاضی**

یک شکل حاوی پاراگراف ریاضی در اسلاید را پیدا کنید.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // اولین شکلی که شامل پاراگراف ریاضی است را پیدا کنید.
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

        // مثال: یک کسر ایجاد کنید (در اینجا اضافه نشده است).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // در صورت نیاز از mathParagraph یا fraction استفاده کنید...
    }

    presentation->Dispose();
}
```

## **حذف متن ریاضی**

یک شکل ریاضی را از اسلاید حذف کنید.

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

    // حذف شکل ریاضی.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **قالب‌بندی متن ریاضی**

ویژگی‌های قلم را برای بخش ریاضی تنظیم کنید.

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