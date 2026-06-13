---
title: افزودن مستطیل‌ها به ارائه‌ها در .NET
linktitle: مستطیل
type: docs
weight: 80
url: /fa/net/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ارائه‌های PowerPoint خود را با افزودن مستطیل‌ها با Aspose.Slides برای .NET - به‌راحتی اشکال را به‌صورت برنامه‌نویسی طراحی و ویرایش کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه با استفاده از Aspose.Slides اشکال مستطیل را به اسلایدهای PowerPoint اضافه کنید. شامل ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی‌شده، و ذخیره ارائه به‌روز‌شده به عنوان فایل PPTX می‌شود.

همچنین نحوه اعمال قالب‌بندی پایه مستطیل مانند رنگ پرشدن ثابت، رنگ خطوط و عرض خط را می‌بینید. علاوه بر این، سؤالات متداول مقاله به کارهای مرتبط با مستطیل اشاره می‌کند، از جمله گوشه‌های گرد، پرکردن با تصویر، افکت‌های بصری، پیوندهای ابرمتنی، قفل‌گذاری شکل، گزینه‌های خروجی و ویژگی‌های مؤثر.

## **ایجاد مستطیل ساده**
همانند مباحث قبلی، این مورد نیز درباره افزودن یک شکل است و این بار شکلی که بحث می‌کنیم مستطیل است. در این موضوع توضیح دادیم که توسعه‌دهندگان چگونه می‌توانند مستطیل‌های ساده یا قالب‌بندی‌شده را به اسلایدهای خود با استفاده از Aspose.Slides برای .NET اضافه کنند. برای افزودن یک مستطیل ساده به اسلاید انتخابی ارائه، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
1. با استفاده از متد AddAutoShape که توسط شیء IShapes ارائه می‌شود، یک IAutoShape از نوع Rectangle اضافه کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX بنویسید.

در مثال زیر، یک مستطیل ساده به اولین اسلاید ارائه اضافه شده است.

```c#
 // شیء کلاس Presentation را که نمایانگر PPTX است، ایجاد کنید
using (Presentation pres = new Presentation())
{

    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //PPTX فایل را روی دیسک ذخیره کنید
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **ایجاد مستطیل قالب‌بندی‌شده**
برای افزودن یک مستطیل قالب‌بندی‌شده به یک اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
1. با استفاده از متد AddAutoShape که توسط شیء IShapes ارائه می‌شود، یک IAutoShape از نوع Rectangle اضافه کنید.
1. نوع پرشدن مستطیل را به Solid تنظیم کنید.
1. رنگ مستطیل را با استفاده از ویژگی SolidFillColor.Color که توسط شیء FillFormat مرتبط با IShape ارائه می‌شود، تنظیم کنید.
1. رنگ خطوط مستطیل را تنظیم کنید.
1. عرض خطوط مستطیل را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.
   مراحل فوق در مثال زیر پیاده‌سازی شده‌اند.

```c#
// شیء کلاس Presentation را که نمایانگر PPTX است، ایجاد کنید
using (Presentation pres = new Presentation())
{

    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // مقداری قالب‌بندی به شکل مستطیل اعمال کنید
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // مقداری قالب‌بندی به خط مستطیل اعمال کنید
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //نوشتن فایل PPTX به دیسک
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**چگونه یک مستطیل با گوشه‌های گرد اضافه کنم؟**

از [نوع شکل گوشه‌گرد](https://reference.aspose.com/slides/fa/net/aspose.slides/shapetype/) استفاده کنید و شعاع گوشه را در ویژگی‌های شکل تنظیم کنید؛ گرد کردن می‌تواند به‌صورت جداگانه برای هر گوشه نیز از طریق تنظیمات هندسی اعمال شود.

**چگونه یک مستطیل را با تصویر (فتوپیوست) پر کنم؟**

نوع پرشدن [تصویر](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) را انتخاب کنید، منبع تصویر را تعیین کنید و حالت‌های [کشیدگی/چینش](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillmode/) را پیکربندی کنید.

**آیا می‌توان به یک مستطیل سایه یا نوردهی افزود؟**

بله. [سایهٔ خارجی/داخلی، نوردهی و لبه‌های نرم](/slides/fa/net/shape-effect/) موجود هستند و می‌توانید پارامترهای آن‌ها را تنظیم کنید.

**آیا می‌توانم یک مستطیل را به دکمه‌ای با پیوند ابرمتنی تبدیل کنم؟**

بله. می‌توانید یک [پیوند ابرمتنی](/slides/fa/net/manage-hyperlinks/) را به کلیک روی شکل اختصاص دهید (رفتن به اسلاید، فایل، آدرس وب یا ایمیل).

**چگونه می‌توانم از جابجایی و تغییرات مستطیل جلوگیری کنم؟**

از [قفل‌گذاری شکل](/slides/fa/net/applying-protection-to-presentation/) استفاده کنید: می‌توانید جابجایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا چیدمان حفظ شود.

**آیا می‌توانم یک مستطیل را به تصویر رستر یا SVG تبدیل کنم؟**

بله. می‌توانید [شکل را رندر کنید](http://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage/) به تصویر با اندازه/مقیاس مشخص یا آن را به عنوان SVG [صادرات کنید](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/) برای استفاده‌وب‌نما.

**چگونه به‌سرعت ویژگی‌های واقعی (effective) یک مستطیل را با در نظر گرفتن تم و ارث‌بری دریافت کنم؟**

از [ویژگی‌های مؤثر شکل](/slides/fa/net/shape-effective-properties/) استفاده کنید: API مقادیر محاسبه‌شده‌ای را برمی‌گرداند که سبک‌های تم، چیدمان و تنظیمات محلی را در نظر می‌گیرد و تحلیل قالب‌بندی را ساده می‌کند.