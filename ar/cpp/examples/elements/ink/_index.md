---
title: حبر
type: docs
weight: 180
url: /ar/cpp/examples/elements/ink/
keywords:
- مثال على الكود
- حبر
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "العمل مع الحبر في Aspose.Slides for C++: رسم، استيراد وتحرير الضربات، تعديل اللون والعرض، وتصدير إلى PPT و PPTX و ODP باستخدام أمثلة C++."
---
توفر هذه المقالة أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for C++**.

> ❗ **ملاحظة:** تمثل أشكال الحبر مدخلات المستخدم من أجهزة متخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجيًا، ولكن يمكنك قراءة الحبر الموجود وتعديله.

## **الوصول إلى الحبر**

اقرأ العلامات من أول شكل حبر على الشريحة.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // استخدم tagName حسب الحاجة.
        }
    }

    presentation->Dispose();
}
```

## **إزالة الحبر**

احذف شكل الحبر من الشريحة إذا كان موجودًا.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```