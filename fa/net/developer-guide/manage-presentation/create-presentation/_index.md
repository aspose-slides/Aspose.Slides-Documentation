---
title: ایجاد ارائه‌ها در .NET
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/net/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با Aspose.Slides در .NET ارائه‌ها را ایجاد کنید—فایل‌های PPT، PPTX و ODP تولید کنید، از پشتیبانی OpenDocument بهره‌مند شوید و برای نتایج قابل اطمینان به‌صورت برنامه‌نویسی ذخیره کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد که چگونه یک ارائه در Aspose.Slides ایجاد کنید، محتوی ساده‌ای به یک اسلاید اضافه کنید و نتیجه را به صورت یک فایل ذخیره کنید. همچنین نحوه ایجاد و ذخیره یک ارائه جدید، باز کردن یک ارائه موجود در فرمت پشتیبانی شده و ذخیره آن به فرمت دیگری را نشان می‌دهد. علاوه بر این، مقاله شامل یک بخش پرسش‌های متداول کوتاه در مورد فرمت‌ها، قالب‌ها، اندازه اسلاید، واحدها، مصرف حافظه، رَش_threading، لایسنس، امضاهای دیجیتال و پشتیبانی VBA است.

## **ایجاد یک ارائه PowerPoint**

برای افزودن یک خط ساده به اسلاید انتخاب‌شدهٔ ارائه، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. مرجع یک اسلاید را با استفاده از Index آن دریافت کنید.
3. یک AutoShape از نوع Line را با استفاده از متد AddAutoShape که توسط شیء Shapes ارائه می‌شود اضافه کنید.
4. ارائه‌ تغییر یافته را به عنوان فایل PPTX بنویسید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```c#
// یک شیء Presentation ایجاد کنید که یک فایل ارائه را نمایندگی می‌کند
using (Presentation presentation = new Presentation())
{
    // دریافت اولین اسلاید
    ISlide slide = presentation.Slides[0];

    // یک AutoShape از نوع خط اضافه کنید
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **ایجاد و ذخیره یک ارائه**

<a name="csharp-create-save-presentation"><strong>مراحل: ایجاد و ذخیره ارائه در C#</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. _Presentation_ را به هر فرمت‌ که توسط [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) پشتیبانی می‌شود، ذخیره کنید.

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **باز کردن و ذخیره یک ارائه**

<a name="csharp-open-save-presentation"><strong>مراحل: باز کردن و ذخیره ارائه در C#</strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را با هر فرمت‌ که می‌خواهید مانند PPT، PPTX، ODP و غیره ایجاد کنید.
2. _Presentation_ را به هر فرمت‌ که توسط [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) پشتیبانی می‌شود، ذخیره کنید.

```c#
// هر فایل پشتیبانی‌شده‌ای را در Presentation بارگیری کنید، به عنوان مثال ppt، pptx، odp و غیره.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **سؤالات متداول**

**چه فرمت‌هایی می‌توانم یک ارائه جدید را در آن ذخیره کنم؟**

می‌توانید به [PPTX, PPT, and ODP](/slides/fa/net/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/net/convert-powerpoint-to-xps/)، [HTML](/slides/fa/net/convert-powerpoint-to-html/)، [SVG](/slides/fa/net/convert-powerpoint-to-png/) و [images](/slides/fa/net/convert-powerpoint-to-png/) نیز تبدیل کنید، و غیره.

**آیا می‌توانم از یک قالب (POTX/POTM) شروع کنم و به‌عنوان یک PPTX معمولی ذخیره کنم؟**

بله. قالب را بارگذاری کنید و به فرمت موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و فرمت‌های مشابه [پشتیبانی می‌شوند](/slides/fa/net/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

اندازۀ [slide size](/slides/fa/net/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) و نحوهٔ مقیاس‌بندی محتوا را انتخاب کنید.

**اندازه‌ها و مختصات بر حسب چه واحدی اندازه‌گیری می‌شوند؟**

در نقاط: 1 اینچ برابر با 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (دارای فایل‌های رسانه‌ای متعدد) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [BLOB management strategies](/slides/fa/net/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به‌جای جریان‌های کاملاً در‑حافظه، جریان‌های مبتنی بر فایل را ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید بر روی یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) از [multiple threads](/slides/fa/net/multithreading/) کار کنید. برای هر نخ یا فرایند، نمونه‌های جدا و ایزوله اجرا کنید.

**چگونه می‌توانم واترمارک نسخه آزمایشی و محدودیت‌ها را حذف کنم؟**

[اعمال لایسنس](/slides/fa/net/licensing/) را یک‌بار برای هر فرآیند اجرا کنید. XML لایسنس باید بدون تغییر باقی بماند و در صورت استفاده از چندین نخ، تنظیم لایسنس باید همزمان‌سازی شود.

**آیا می‌توانم PPTX ای که ایجاد می‌کنم را به‌صورت دیجیتالی امضا کنم؟**

بله. [Digital signatures](/slides/fa/net/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

**آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟**

بله. می‌توانید [create/edit VBA projects](/slides/fa/net/presentation-via-vba/) را انجام دهید و فایل‌های قابلیت ماکرو مانند PPTM/PPSM را ذخیره کنید.