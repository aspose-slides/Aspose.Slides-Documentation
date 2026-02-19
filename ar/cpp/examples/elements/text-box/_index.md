---
title: مربع نص
type: docs
weight: 40
url: /ar/cpp/examples/elements/text-box/
keywords:
- مثال على الكود
- مربع نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخدم مربعات النص في Aspose.Slides لـ C++: أضف، نمّق، حاذِ، لفّ، اضبط تلقائيًا، ونمّط النص باستخدام C++ لعرض PPT و PPTX و ODP."
---
في Aspose.Slides، يتم تمثيل **مربع النص** بـ `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، لكن مربع النص النموذجي لا يحتوي على تعبئة أو حدود وعرض النص فقط.

يشرح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجيًا.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` بلا تعبئة أو حدود ويحتوي على بعض النص المنسق. إليك كيفية إنشاء واحد:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إنشاء شكل مستطيل (الإعدادات الافتراضية هي التعبئة مع الحد وعدم وجود نص).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // إزالة التعبئة والحد لتظهر كصندوق نص نموذجي.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // ضبط تنسيق النص.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // تعيين محتوى النص الفعلي.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكنه أن يعمل كمربع نص.

## **الوصول إلى مربعات النص حسب المحتوى**

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاحية محددة (مثل "Slide")، قم بالتكرار عبر الأشكال وتحقق من نصها:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // يمكن فقط للأشكال التلقائية أن تحتوي على نص قابل للتحرير.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // قم بعمل ما مع مربع النص المطابق.
            }
        }
    }

    presentation->Dispose();
}
```

## **إزالة مربعات النص حسب المحتوى**

يوضح هذا المثال كيفية العثور على جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية محددة وحذفها:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.