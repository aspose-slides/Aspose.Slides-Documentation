---
title: اسلاید
type: docs
weight: 10
url: /fa/cpp/examples/elements/slide/
keywords:
- مثال کد
- اسلاید
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کنترل اسلایدها در Aspose.Slides برای C++: ایجاد، کلون، مرتب‌سازی، تغییر اندازه، تنظیم پس‌زمینه‌ها و اعمال انتقال‌ها با C++ برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نشان می‌دهد چگونه می‌توان با اسلایدها با استفاده از **Aspose.Slides for C++** کار کرد. شما یاد خواهید گرفت چگونه اسلایدها را اضافه، دسترسی، کلون، مرتب‌سازی و حذف کنید با استفاده از کلاس `Presentation`.

هر مثال زیر شامل توضیح کوتاهی است که به دنبال آن قطعه کد C++ قرار دارد.

## **Add a Slide**

برای افزودن یک اسلاید جدید، ابتدا باید یک طرح‌بندی انتخاب کنید. در این مثال، ما از طرح‌بندی `Blank` استفاده می‌کنیم و یک اسلاید خالی به ارائه اضافه می‌کنیم.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Note:** هر طرح‌بندی اسلاید از یک اسلاید اصلی مشتق می‌شود که طراحی کلی و ساختار نگهدارنده‌ها را تعریف می‌کند. تصویر زیر نشان می‌دهد اسلایدهای اصلی و طرح‌بندی‌های مرتبط با آن‌ها در PowerPoint چگونه سازماندهی شده‌اند.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

می‌توانید اسلایدها را با استفاده از ایندکس آن‌ها دسترسی پیدا کنید یا ایندکس یک اسلاید را بر اساس یک مرجع پیدا کنید. این برای مرور یا تغییر اسلایدهای خاص مفید است.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // افزودن یک اسلاید خالی دیگر.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // دسترسی به اسلایدها بر اساس ایندکس.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // دریافت ایندکس اسلاید از یک مرجع، سپس دسترسی به آن بر اساس ایندکس.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clone a Slide**

این مثال نشان می‌دهد چگونه یک اسلاید موجود را کلون کنید. اسلاید کلون‌شده به‌صورت خودکار به انتهای مجموعه اسلایدها اضافه می‌شود.

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

## **Reorder Slides**

می‌توانید ترتیب اسلایدها را با جابه‌جایی یک اسلاید به ایندکس جدید تغییر دهید. در این مورد، یک اسلاید کلون‌شده را به موقعیت اول منتقل می‌کنیم.

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

## **Remove a Slide**

برای حذف یک اسلاید، به سادگی آن را ارجاع دهید و `Remove` را فراخوانی کنید. این مثال یک اسلاید دوم اضافه می‌کند و سپس اسلاید اصلی را حذف می‌کند، طوری که فقط اسلاید جدید باقی می‌ماند.

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