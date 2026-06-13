---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/cpp/examples/elements/slide-transition/
keywords:
- مثال کد
- انتقال اسلاید
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تبدیل اسلایدهای اصلی در Aspose.Slides برای C++: افزودن، شخصی‌سازی و ترتیب‌گذاری افکت‌ها و مدت زمان‌ها با مثال‌های C++ برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه اعمال افکت‌های انتقال اسلاید و زمان‌بندی‌ها را با **Aspose.Slides for C++** نشان می‌دهد.

## **افزودن انتقال اسلاید**

یک افکت انتقال محو را بر روی اولین اسلاید اعمال کنید.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // اعمال یک انتقال محو.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **دسترسی به انتقال اسلاید**

نوع انتقال اختصاص داده شده به اسلاید را بخوانید.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // دسترسی به نوع انتقال.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **حذف انتقال اسلاید**

با تنظیم نوع به `None`، هر افکت انتقالی را پاک کنید.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // حذف انتقال با تنظیم به none.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **تنظیم مدت زمان انتقال**

مشخص کنید اسلاید تا چه مدت قبل از پیشرفت خودکار نمایش داده شود.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // در میلی‌ثانیه.

    presentation->Dispose();
}
```