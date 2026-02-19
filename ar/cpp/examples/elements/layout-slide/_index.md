---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/cpp/examples/elements/layout-slide/
keywords:
- مثال برمجي
- شريحة تخطيط
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إتقان شرائح التخطيط في Aspose.Slides للغة C++: اختيار وتطبيق وتخصيص تخطيطات الشرائح وعناصر النائب والرؤوس باستخدام أمثلة C++ لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية العمل مع **شرائح التخطيط** في Aspose.Slides للغة C++. تحدد شريحة التخطيط التصميم والتنسيق الموروث من الشرائح العادية. يمكنك إضافة شرائح التخطيط، والوصول إليها، واستنساخها، وإزالتها، بالإضافة إلى تنظيف الشرائح غير المستخدمة لتقليل حجم العرض التقديمي.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق قابل لإعادة الاستخدام. على سبيل المثال، قد تضيف مربع نص يظهر في جميع الشرائح التي تستخدم هذا التخطيط.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // إضافة مربع نص إلى شريحة التخطيط.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // إضافة شريحتين باستخدام هذا التخطيط؛ سيورث كل منهما النص من التخطيط.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **ملاحظة 1:** تعمل شرائح التخطيط كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **ملاحظة 2:** عندما تضيف أشكالًا أو نصًا إلى شريحة التخطيط، ستظهر جميع الشرائح المعتمدة على ذلك التخطيط هذا المحتوى المشترك تلقائيًا.
> تُظهر اللقطة أدناه شريحتين، كل منهما ترث مربع نص من نفس شريحة التخطيط.

![شرائح ترث محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط عن طريق الفهرس أو بنوع التخطيط (مثلًا `Blank`، `Title`، `SectionHeader`، إلخ).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // الوصول إلى شريحة تخطيط عن طريق الفهرس.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // الوصول إلى شريحة تخطيط حسب النوع.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط معينة إذا لم تعد بحاجة إليها.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // الحصول على شريحة تخطيط حسب النوع وإزالتها.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض التقديمي، قد ترغب في إزالة شرائح التخطيط التي لا تستخدمها أي شريحة عادية.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // يزيل تلقائيًا جميع شرائح التخطيط التي لا يشير إليها أي شريحة.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **استنساخ شريحة تخطيط**

يمكنك تكرار شريحة التخطيط باستخدام طريقة `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // الحصول على شريحة تخطيط موجودة حسب النوع.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // استنساخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **ملخص:** شرائح التخطيط أدوات قوية لإدارة تنسيق متسق عبر الشرائح. يتيح Aspose.Slides تحكمًا كاملاً في إنشاء وإدارة وتحسين شرائح التخطيط.