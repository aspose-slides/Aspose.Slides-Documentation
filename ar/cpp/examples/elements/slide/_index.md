---
title: شريحة
type: docs
weight: 10
url: /ar/cpp/examples/elements/slide/
keywords:
- مثال على الكود
- شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "التحكم في الشرائح باستخدام Aspose.Slides for C++: إنشاء، استنساخ، إعادة ترتيب، تغيير الحجم، تعيين الخلفيات، وتطبيق الانتقالات باستخدام C++ لعروض PPT، PPTX، وODP."
---
توفر هذه المقالة مجموعة من الأمثلة التي توضح كيفية العمل مع الشرائح باستخدام **Aspose.Slides for C++**. ستتعلم كيفية إضافة، والوصول إلى، واستنساخ، وإعادة ترتيب، وإزالة الشرائح باستخدام الصنف `Presentation`.

كل مثال أدناه يتضمن شرحًا مختصرًا يليه مقطع شفري بلغة C++.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب أولاً اختيار تخطيط. في هذا المثال، نستخدم التخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **ملاحظة:** كل تخطيط شريحة مستمد من شريحة رئيسية، التي تحدد التصميم العام وبنية العنصر النائب. توضح الصورة أدناه كيفية تنظيم الشرائح الرئيسية وتخطيطاتها المرتبطة في PowerPoint.

![العلاقة بين الشريحة الرئيسة والتصميم](master-layout-slide.png)

## **الوصول إلى الشرائح حسب الفهرس**

يمكنك الوصول إلى الشرائح باستخدام فهرسها، أو العثور على فهرس شريحة بناءً على مرجع. هذا مفيد للتنقل عبر الشرائح أو تعديل شرائح معينة.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // أضف شريحة فارغة أخرى.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // الوصول إلى الشرائح حسب الفهرس.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // احصل على فهرس الشريحة من مرجع، ثم الوصول إليها حسب الفهرس.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **استنساخ شريحة**

يوضح هذا المثال كيفية استنساخ شريحة موجودة. تُضاف الشريحة المستنسخة تلقائيًا إلى نهاية مجموعة الشرائح.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **إعادة ترتيب الشرائح**

يمكنك تغيير ترتيب الشرائح بنقل واحدة إلى فهرس جديد. في هذه الحالة، ننقل الشريحة المستنسخة إلى الموضع الأول.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **إزالة شريحة**

لإزالة شريحة، ما عليك سوى الإشارة إليها واستدعاء `Remove`. يضيف هذا المثال شريحة ثانية ثم يزيل الأصلية، مخلفًا الشريحة الجديدة فقط.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```