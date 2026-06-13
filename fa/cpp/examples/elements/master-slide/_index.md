---
title: اسلاید اصلی
type: docs
weight: 30
url: /fa/cpp/examples/elements/master-slide/
keywords:
- مثال کد
- اسلاید اصلی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "نمونه‌های اسلاید اصلی Aspose.Slides برای C++ را بررسی کنید: ایجاد، ویرایش و استایل‌دهی به اسلایدهای اصلی، جای‌نگهدارها و تم‌ها در فرمت‌های PPT، PPTX و ODP با کد واضح C++."
---
اسلایدهای اصلی سطح بالای سلسله‌مراتبی وراثت اسلایدها در PowerPoint را تشکیل می‌دهند. یک **master slide** عناصر طراحی مشترک مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **Layout slides** از اسلایدهای اصلی وراثت می‌گیرند و **normal slides** از اسلایدهای چیدمان وراثت می‌گیرند.

این مقاله نشان می‌دهد چگونه می‌توان اسلایدهای اصلی را با استفاده از Aspose.Slides for C++ ایجاد، تغییر و مدیریت کرد.

## **افزودن اسلاید اصلی**

این مثال نشان می‌دهد چگونه یک اسلاید اصلی جدید را با کلون کردن اسلاید پیش‌فرض ایجاد کنیم. سپس بنر نام شرکت را از طریق وراثت چیدمان به تمام اسلایدها اضافه می‌کند.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // کلون اسلاید اصلی پیش‌فرض.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // افزودن بنر با نام شرکت به بالای اسلاید اصلی.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // انتساب اسلاید اصلی جدید به اسلاید چیدمان.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // انتساب اسلاید چیدمان به اولین اسلاید در ارائه.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **یادداشت 1:** اسلایدهای اصلی روشی برای اعمال برندسازی یکسان یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در اسلاید اصلی انجام شود، به‌طور خودکار در اسلایدهای چیدمان وابسته و اسلایدهای عادی بازتاب می‌یابد.

> 💡 **یادداشت 2:** هر شکل یا قالب‌بندی که به یک اسلاید اصلی اضافه شود، توسط اسلایدهای چیدمان ارث‌بری می‌شود و به‌نوبه خود، تمام اسلایدهای عادی که از آن چیدمان‌ها استفاده می‌کنند، آن را دریافت می‌کنند.  
> تصویر زیر نشان می‌دهد چگونه یک جعبه متن اضافه شده به اسلاید اصلی به‌صورت خودکار در اسلاید نهایی رندر می‌شود.

![مثال وراثت اسلاید اصلی](master-slide-banner.png)

## **دسترسی به اسلاید اصلی**

می‌توانید با استفاده از مجموعه اسلایدهای اصلی ارائه، به اسلایدهای اصلی دسترسی پیدا کنید. در اینجا نحوه بازیابی و کار با آن‌ها آورده شده است:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // نوع پس‌زمینه را تغییر دهید.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **حذف اسلاید اصلی**

اسلایدهای اصلی می‌توانند با استفاده از ایندکس یا ارجاع حذف شوند.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // اسلاید اصلی را بر اساس اندیس حذف کنید.
    presentation->get_Masters()->RemoveAt(0);

    // اسلاید اصلی را بر اساس ارجاع حذف کنید.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **حذف اسلایدهای اصلی استفاده‌نشده**

برخی ارائه‌ها شامل اسلایدهای اصلی هستند که استفاده نمی‌شوند. حذف این اسلایدها می‌تواند به کاهش حجم فایل کمک کند.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // تمام اسلایدهای اصلی استفاده‌نشده (حتی آنهایی که به عنوان Preserve علامت‌گذاری شده‌اند) را حذف کنید.
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```