---
title: شريحة ماستر
type: docs
weight: 30
url: /ar/cpp/examples/elements/master-slide/
keywords:
- مثال كود
- شريحة ماستر
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استكشف أمثلة شرائح الماستر في Aspose.Slides للـ C++: إنشاء، تعديل، وتنسيق الماسترات والعناصر النائبة والسمات في ملفات PPT و PPTX و ODP باستخدام كود C++ واضح."
---
تشكل شرائح الماستر المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. **شريحة الماستر** تحدد عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من شرائح الماستر، و**الشرائح العادية** ترث من شرائح التخطيط.

توضح هذه المقالة كيفية إنشاء وتعديل وإدارة شرائح الماستر باستخدام Aspose.Slides للـ C++.

## **إضافة شريحة ماستر**

يعرض هذا المثال كيفية إنشاء شريحة ماستر جديدة عن طريق استنساخ الشريحة الافتراضية. ثم يضيف شريطًا يحمل اسم الشركة إلى جميع الشرائح عبر وراثة التخطيط.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // استنساخ شريحة الماستر الافتراضية.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // إضافة شريط يحمل اسم الشركة إلى أعلى شريحة الماستر.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // تعيين شريحة الماستر الجديدة إلى شريحة تخطيط.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // تعيين شريحة التخطيط إلى الشريحة الأولى في العرض التقديمي.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **ملاحظة 1:** توفر شرائح الماستر وسيلة لتطبيق العلامة التجارية المتسقة أو عناصر التصميم المشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الماستر ستنعكس تلقائيًا على شرائح التخطيط والشرائح العادية التابعة.  
> 💡 **ملاحظة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة الماستر تُورَث إلى شرائح التخطيط، وبالتالي إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات.  
> الصورة أدناه توضح كيف يتم عرض مربع نص تم إضافته إلى شريحة الماستر تلقائيًا على الشريحة النهائية.

![مثال على وراثة الماستر](master-slide-banner.png)

## **الوصول إلى شريحة ماستر**

يمكنك الوصول إلى شرائح الماستر باستخدام مجموعة ماستر العرض التقديمي. إليك كيفية استرجاعها والعمل معها:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // تغيير نوع الخلفية.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **إزالة شريحة ماستر**

يمكن إزالة شرائح الماستر إما بواسطة الفهرس أو بواسطة المرجع.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // إزالة شريحة ماستر بواسطة الفهرس.
    presentation->get_Masters()->RemoveAt(0);

    // إزالة شريحة ماستر بواسطة المرجع.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **إزالة شرائح ماستر غير المستخدمة**

تحتوي بعض العروض التقديمية على شرائح ماستر غير مستخدمة. إزالة هذه الشرائح يمكن أن تساعد في تقليص حجم الملف.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // إزالة جميع شرائح الماستر غير المستخدمة (حتى تلك التي تم وضع علامة Preserve عليها).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```