---
title: اسلاید چیدمان
type: docs
weight: 20
url: /fa/cpp/examples/elements/layout-slide/
keywords:
- مثال کد
- اسلاید چیدمان
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "در Aspose.Slides برای C++، اسلایدهای چیدمان اصلی را مدیریت کنید: انتخاب، اعمال و سفارشی‌سازی چیدمان‌های اسلاید، محل‌دارها و مسترها با مثال‌های C++ برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه با **Layout Slides** در Aspose.Slides for C++ کار کنید. یک layout slide طراحی و قالب‌بندی را که توسط اسلایدهای معمولی به ارث می‌برند، تعریف می‌کند. می‌توانید اسلایدهای چیدمان را اضافه، دسترسی پیدا کنید، کلون کنید و حذف نمایید، و همچنین اسلایدهای استفاده‌نشده را پاک‌سازی کنید تا اندازه ارائه کاهش یابد.

## **افزودن یک Layout Slide**

می‌توانید یک layout slide سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف کنید. به عنوان مثال، ممکن است یک جعبه متن اضافه کنید که در تمام اسلایدهای استفاده‌کننده از این چیدمان ظاهر شود.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // یک اسلاید چیدمان با نوع چیدمان خالی و نام سفارشی ایجاد کنید.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // یک جعبه متن به اسلاید چیدمان اضافه کنید.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // دو اسلاید با استفاده از این چیدمان اضافه کنید؛ هر دو متن را از چیدمان ارث می‌برند.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **یادداشت 1:** Layout slides به‌عنوان قالب برای اسلایدهای تک‌تک عمل می‌کنند. می‌توانید عناصر مشترک را یک‌بار تعریف کنید و در اسلایدهای متعدد دوباره استفاده کنید.

> 💡 **یادداشت 2:** وقتی اشکال یا متن را به یک layout slide اضافه می‌کنید، تمام اسلایدهایی که بر پایه آن چیدمان هستند، این محتوای مشترک را به‌صورت خودکار نمایش خواهند داد.
> تصویر زیر دو اسلاید را نشان می‌دهد که هر کدام یک جعبه متن را از همان layout slide به ارث می‌برند.

![اسلایدهای وراثت‌دار محتوا از Layout](layout-slide-result.png)

## **دسترسی به یک Layout Slide**

می‌توانید به Layout slides بر اساس اندیس یا نوع چیدمان (مانند `Blank`، `Title`، `SectionHeader` و غیره) دسترسی پیدا کنید.

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // با استفاده از اندیس یک اسلاید چیدمان را دسترسی پیدا کنید.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // با استفاده از نوع یک اسلاید چیدمان را دسترسی پیدا کنید.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **حذف یک Layout Slide**

اگر نیازی به یک layout slide خاص نیست، می‌توانید آن را حذف کنید.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // یک اسلاید چیدمان را بر اساس نوع دریافت کنید و حذف کنید.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **حذف Layout Slides استفاده‌نشده**

برای کاهش اندازه ارائه، ممکن است بخواهید layout slideهایی را که توسط هیچ اسلاید معمولی استفاده نمی‌شوند، حذف کنید.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // به صورت خودکار تمام اسلایدهای چیدمان را که توسط هیچ اسلایدی ارجاع داده نشده‌اند، حذف می‌کند.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **کلون کردن یک Layout Slide**

می‌توانید یک layout slide را با استفاده از متد `AddClone` تکثیر کنید.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // یک اسلاید چیدمان موجود را بر اساس نوع دریافت کنید.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // اسلاید چیدمان را به انتهای مجموعه اسلایدهای چیدمان کلون کنید.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **خلاصه:** Layout slides ابزارهای قدرتمندی برای مدیریت قالب‌بندی یکسان در سراسر اسلایدها هستند. Aspose.Slides کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی layout slideها را فراهم می‌کند.