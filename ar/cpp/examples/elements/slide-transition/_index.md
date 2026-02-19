---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/cpp/examples/elements/slide-transition/
keywords:
- مثال برمجي
- انتقال شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحكم في انتقالات الشرائح في Aspose.Slides for C++: أضف، خصّص، وسلسّل التأثيرات والمدة باستخدام أمثلة C++ لعروض PPT وPPTX وODP."
---
توضح هذه المقالة تطبيق تأثيرات انتقال الشرائح وتوقيتها باستخدام **Aspose.Slides for C++**.

## **إضافة انتقال شريحة**

تطبيق تأثير انتقال تلاشي على الشريحة الأولى.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // تطبيق انتقال تلاشي.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **الوصول إلى انتقال شريحة**

قراءة نوع الانتقال المعين حاليًا إلى شريحة.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // الوصول إلى نوع الانتقال.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **إزالة انتقال شريحة**

مسح أي تأثير انتقال عن طريق تعيين النوع إلى `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // إزالة الانتقال عن طريق تعيين None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **تعيين مدة الانتقال**

تحديد مدة عرض الشريحة قبل الانتقال تلقائيًا.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // بالمللي ثانية.

    presentation->Dispose();
}
```