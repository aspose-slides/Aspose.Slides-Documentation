---
title: مدیریت فوقانی و زیرنویس در ارائه‌ها در .NET
linktitle: فوقانی و زیرنویس
type: docs
weight: 80
url: /fa/net/superscript-and-subscript/
keywords:
- فوقانی
- زیرنویس
- افزودن فوقانی
- افزودن زیرنویس
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "در Aspose.Slides for .NET، بر فراز و زیرنویس را به‌خوبی مدیریت کنید و ارائه‌های خود را با قالب‌بندی متن حرفه‌ای برای حداکثر تأثیر ارتقا دهید."
---
## **نمای کلی**

Aspose.Slides for .NET امکاناتی برای ادغام متن فوقانی و زیرنویس در ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) شما فراهم می‌کند. چه نیاز به برجسته‌سازی فرمول‌های شیمیایی، معادلات ریاضی یا توضیح محتوا با پانویس داشته باشید، این گزینه‌های قالب‌بندی تخصصی به حفظ وضوح و دقت کمک می‌کنند. در این مقاله، خواهید آموخت که چگونه به‌صورت یکپارچه سبک‌های فوقانی و زیرنویس را اعمال کنید و نتایج حرفه‌ای را در هر اسلاید تضمین کنید.

## **اضافه کردن متن فوقانی و زیرنویس**

می‌توانید متن فوقانی و زیرنویس را داخل هر پاراگرافی در یک ارائه اضافه کنید. برای انجام این کار با Aspose.Slides، باید از ویژگی `Escapement` کلاس [PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/portionformat/) استفاده کنید.

این ویژگی به شما امکان تنظیم متن فوقانی یا زیرنویس را می‌دهد، با مقادیری بین -100٪ (زیرنویس) تا 100٪ (فوقانی).

مراحل اجرایی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص آن، یک مرجع به اسلاید دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) از نوع `Rectangle` به اسلاید اضافه کنید.
1. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) مرتبط با [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) دسترسی پیدا کنید.
1. پاراگراف‌های موجود را پاک کنید.
1. یک [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph/) جدید برای متن فوقانی ایجاد کنید و آن را به مجموعه پاراگراف‌های [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) اضافه کنید.
1. یک شیء بخش متن جدید ایجاد کنید.
1. مقدار ویژگی `Escapement` را برای بخش متن بین 0 تا 100 تنظیم کنید تا فوقانی اعمال شود (0 به معنی عدم وجود فوقانی است).
1. متنی برای [Portion](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/) تنظیم کنید و آن را به مجموعه بخش‌های پاراگراف اضافه کنید.
1. یک [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph/) دیگر برای متن زیرنویس ایجاد کنید و آن را به مجموعه پاراگراف اضافه کنید.
1. یک شیء بخش متن جدید ایجاد کنید.
1. مقدار ویژگی `Escapement` را برای بخش متن بین 0 تا -100 تنظیم کنید تا زیرنویس اعمال شود (0 به معنی عدم وجود زیرنویس است).
1. متنی برای [Portion](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/) تنظیم کنید و آن را به مجموعه بخش‌های پاراگراف اضافه کنید.
1. ارائه را به عنوان فایل PPTX ذخیره کنید.

کد C# زیر این مراحل را اجرا می‌کند:

```c#
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک جعبه متن ایجاد کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // یک پاراگراف برای متن فوقانی ایجاد کنید.
    IParagraph superPar = new Paragraph();

    // یک بخش متن با متن معمولی ایجاد کنید.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // یک بخش متن با متن فوقانی ایجاد کنید.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // یک پاراگراف برای متن زیرنویس ایجاد کنید.
    IParagraph paragraph2 = new Paragraph();

    // یک بخش متن با متن معمولی ایجاد کنید.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // یک بخش متن با متن زیرنویس ایجاد کنید.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // پاراگراف‌ها را به جعبه متن اضافه کنید.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![متن فوقانی و زیرنویس](superscript_and_subscript.png)

## **پرسش‌های متداول**

**آیا متن فوقانی و زیرنویس هنگام صادرات به PDF یا سایر فرمت‌ها حفظ می‌شوند؟**

بله، Aspose.Slides for .NET به‌درستی قالب‌بندی فوقانی و زیرنویس را هنگام صادرات ارائه‌ها به PDF، PPT/PPTX، تصاویر و سایر فرمت‌های پشتیبانی‌شده حفظ می‌کند. این قالب‌بندی تخصصی در تمام فایل‌های خروجی دست نخورده باقی می‌ماند.

**آیا می‌توان متن فوقانی و زیرنویس را با سایر سبک‌های قالب‌بندی مانند بولد یا ایتالیک ترکیب کرد؟**

بله، Aspose.Slides به شما امکان می‌دهد تا سبک‌های مختلف متنی را در یک بخش متن ترکیب کنید. می‌توانید بولد، ایتالیک، زیرخط را فعال کنید و به‌صورت همزمان فوقانی یا زیرنویس را با تنظیم ویژگی‌های مربوطه در [PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/portionformat/) اعمال کنید.

**آیا قالب‌بندی فوقانی و زیرنویس برای متن داخل جدول‌ها، نمودارها یا SmartArt کار می‌کند؟**

بله، Aspose.Slides for .NET قالب‌بندی را در اکثر اشیاء، از جمله جدول‌ها و عناصر نمودارها پشتیبانی می‌کند. هنگام کار با SmartArt، باید به عناصر مناسب (مانند [SmartArtNode](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartartnode/)) و محفظه‌های متنی آن‌ها دسترسی پیدا کنید و سپس ویژگی‌های [PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/portionformat/) را به‌طور مشابه تنظیم کنید.