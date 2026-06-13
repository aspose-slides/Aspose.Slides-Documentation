---
title: ایجاد ارائه‌ها در اندروید
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "در جاوا با Aspose.Slides برای اندروید، ارائه‌ها را ایجاد کنید—فایل‌های PPT، PPTX و ODP تولید کنید، از پشتیبانی OpenDocument بهره‌مند شوید و آن‌ها را به‌صورت برنامه‌نویسی ذخیره کنید تا نتایج قابل اعتماد به دست آید."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنید، محتوی ساده‌ای به یک اسلاید اضافه کنید و نتیجه را به عنوان یک فایل ذخیره کنید. همچنین نحوه ایجاد و ذخیره یک ارائه جدید، باز کردن یک ارائه موجود در یک قالب پشتیبانی‌شده، و ذخیره آن به قالب دیگری را نشان می‌دهد.

## **ایجاد یک ارائه پاورپوینت**
برای افزودن یک خط ساده به اسلاید انتخاب‌شده از ارائه، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. با استفاده از ایندکس آن، مرجع یک اسلاید را به دست آورید.
1. با استفاده از متد addAutoShape که توسط شیء Shapes فراهم شده، یک AutoShape از نوع خط اضافه کنید.
1. ارائه‌ی اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

در مثال زیر، ما یک خط به اسلاید اول ارائه اضافه کرده‌ایم.

```java
// یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // یک AutoShape از نوع خط اضافه کنید
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**کدام قالب‌ها را می‌توانم برای ذخیره یک ارائه جدید استفاده کنم؟**

می‌توانید به‌صورت [PPTX، PPT و ODP](/slides/fa/androidjava/save-presentation/) ذخیره کنید و به‌صورت [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، [SVG](/slides/fa/androidjava/convert-powerpoint-to-png/) و [images](/slides/fa/androidjava/convert-powerpoint-to-png/) صادر کنید، و غیره.

**آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به‌صورت یک PPTX معمولی ذخیره کنم؟**

بله. الگو را بارگذاری کنید و به قالب موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شوند](/slides/fa/androidjava/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت تصویر اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

اندازه [اسلاید](/slides/fa/androidjava/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیمات 4:3 و 16:9 یا ابعاد سفارشی) و نحوه‌ی مقیاس‌گذاری محتوا را انتخاب کنید.

**واحدهای اندازه و مختصات به چه صورت هستند؟**

به واحد پوینت: 1 اینچ برابر با 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای زیاد) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [استراتژی‌های مدیریت BLOB](/slides/fa/androidjava/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به‌جای جریان‌های صرفاً در‑حافظه، روی گردش‌کارهای مبتنی بر فایل ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید بر روی همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) از [چندین نخ](/slides/fa/androidjava/multithreading/) کار کنید. برای هر نخ یا فرایند نمونه‌های جداگانه و ایزوله اجرا کنید.

**چگونه علامت آب‌نما و محدودیت‌های نسخه آزمایشی را حذف کنم؟**

[اعمال یک لایسنس](/slides/fa/androidjava/licensing/) یک‌بار برای هر فرآیند. فایل XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس در صورت استفاده از چندین نخ، باید همگام‌سازی شود.

**آیا می‌توانم PPTX ای که ایجاد می‌کنم را به‌صورت دیجیتال امضا کنم؟**

بله. [امضاهای دیجیتال](/slides/fa/androidjava/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شوند.

**آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟**

بله. می‌توانید [پروژه‌های VBA را ایجاد/ویرایش](/slides/fa/androidjava/presentation-via-vba/) کنید و فایل‌های دارای ماکرو مانند PPTM/PPSM را ذخیره کنید.