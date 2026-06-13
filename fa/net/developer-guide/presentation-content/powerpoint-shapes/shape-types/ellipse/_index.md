---
title: افزودن بیضی‌ها به ارائه‌ها در .NET
linktitle: بیضی
type: docs
weight: 30
url: /fa/net/ellipse/
keywords:
- بیضی
- شکل
- افزودن بیضی
- ایجاد بیضی
- رسم بیضی
- بیضی قالب‌بندی‌شده
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه بیضی‌ها را در Aspose.Slides برای .NET در ارائه‌های PPT و PPTX ایجاد، قالب‌بندی و دستکاری کنید—نمونه کدهای C# گنجانده شده."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه می‌توان با استفاده از Aspose.Slides به اسلایدهای PowerPoint اشکال بیضی اضافه کرد. در آن ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده و ذخیره‌سازی ارائه به‌روز شده به‌صورت فایل PPTX پوشش داده شده است. همچنین به سؤالات مرتبط مانند کار با موقعیت و اندازه بیضی، کنترل ترتیب لایه‌ها و اعمال انیمیشن‌ها اشاره می‌شود.

## **ایجاد بیضی**
برای افزودن یک بیضی ساده به اسلاید انتخاب‌شدهٔ ارائه، مراحل زیر را دنبال کنید:

1. ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)
1. دریافت مرجع اسلاید با استفاده از شاخص آن
1. افزودن یک AutoShape از نوع Ellipse با استفاده از متد AddAutoShape که توسط شیء IShapes ارائه می‌شود
1. نوشتن ارائهٔ تغییر یافته به‌صورت فایل PPTX

در مثال زیر، یک بیضی به اولین اسلاید اضافه شده است.

```c#
// نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
// دریافت اسلاید اول
// افزودن AutoShape از نوع بیضی
//فایل PPTX را در دیسک بنویسید
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Write the PPTX file to disk
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **ایجاد بیضی قالب‌بندی‌شده**
برای افزودن یک بیضی با قالب‌بندی بهتر به اسلاید، مراحل زیر را دنبال کنید:

1. ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)
1. دریافت مرجع اسلاید با استفاده از شاخص آن
1. افزودن یک AutoShape از نوع Ellipse با استفاده از متد AddAutoShape که توسط شیء IShapes ارائه می‌شود
1. تنظیم نوع پر کردن بیضی به Solid
1. تنظیم رنگ بیضی با استفاده از ویژگی SolidFillColor.Color که توسط شیء FillFormat مرتبط با شیء IShape در دسترس است
1. تنظیم رنگ خطوط بیضی
1. تنظیم عرض خطوط بیضی
1. نوشتن ارائهٔ تغییر یافته به‌صورت فایل PPTX

در مثال زیر، یک بیضی قالب‌بندی‌شده به اولین اسلاید ارائه اضافه شده است.

```c#
 // نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
 using (Presentation pres = new Presentation())
 {
 
     // دریافت اسلاید اول
     ISlide sld = pres.Slides[0];
 
     // افزودن AutoShape از نوع بیضی
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // اعمال برخی قالب‌بندی‌ها بر روی شکل بیضی
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // اعمال برخی قالب‌بندی‌ها بر روی خط بیضی
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     //فایل PPTX را در دیسک بنویسید
     pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
 }
```

## **سؤالات متداول**

**چگونه موقعیت و اندازه دقیق یک بیضی را نسبت به واحدهای اسلاید تنظیم کنم؟**

مختصات و اندازه‌ها معمولاً **بر حسب نقطه** مشخص می‌شوند. برای نتایج قابل پیش‌بینی، محاسبات خود را بر اساس اندازه اسلاید پایه‌گذاری کنید و میلی‌متر یا اینچ مورد نیاز را قبل از اختصاص به‌نقطه تبدیل کنید.

**چگونه می‌توانم یک بیضی را بالای یا زیر اشیای دیگر قرار دهم (کنترل ترتیب لایه‌ها)؟**

با تغییر ترتیب رسم شیء، می‌توانید آن را به جلو یا به عقب برانید. این کار اجازه می‌دهد بیضی روی اشیای دیگر قرار گیرد یا اشیایی که زیر آن هستند را نشان دهد.

**چگونه می‌توانم ظاهر یا تأکید یک بیضی را انیمیشن کنم؟**

[اعمال](/slides/fa/net/shape-animation/) اثرات ورودی، تأکید یا خروجی بر روی شکل، و پیکربندی محرک‌ها و زمان‌بندی را برای تعیین زمان و نحوهٔ پخش انیمیشن انجام دهید.