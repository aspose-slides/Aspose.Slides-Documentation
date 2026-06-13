---
title: ایجاد ارائه‌ها در JavaScript
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ارائه‌ها را با Aspose.Slides ایجاد کنید—فایل‌های PPT، PPTX و ODP تولید کنید، از پشتیبانی OpenDocument بهره‌مند شوید و آن‌ها را به‌صورت برنامه‌نویسی ذخیره کنید تا نتایج قابل اطمینان داشته باشید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنیم، محتوای ساده‌ای به یک اسلاید اضافه کنیم، و نتیجه را به عنوان یک فایل ذخیره کنیم.

## **ایجاد ارائه PowerPoint**

برای افزودن یک خط ساده صاف به اسلاید انتخاب شده‌ی ارائه، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از Index آن به دست آورید.
1. یک AutoShape از نوع Line را با استفاده از متد addAutoShape که توسط شیء Shapes ارائه می‌شود، اضافه کنید.
1. ارائه‌ی تغییر یافته را به عنوان یک فایل PPTX بنویسید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```javascript
// یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // افزودن یک AutoShape از نوع خط
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**چه فرمت‌هایی را می‌توانم برای ذخیره یک ارائه جدید استفاده کنم؟**

می‌توانید به فرمت‌های [PPTX, PPT, and ODP](/slides/fa/nodejs-java/save-presentation/) ذخیره کنید و به فرمت‌های [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/nodejs-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/nodejs-java/convert-powerpoint-to-png/) و [images](/slides/fa/nodejs-java/convert-powerpoint-to-png/) و غیره صادر کنید.

**آیا می‌توانم از یک قالب (POTX/POTM) شروع کنم و به عنوان یک PPTX معمولی ذخیره کنم؟**

بله. قالب را بارگذاری کنید و به فرمت مورد نظر ذخیره کنید؛ POTX/POTM/PPTM و فرمت‌های مشابه [پشتیبانی می‌شوند](/slides/fa/nodejs-java/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

اندازه [اندازه اسلاید](/slides/fa/nodejs-java/slide-size/) (شامل پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) و نحوهٔ مقیاس‌بندی محتوا را انتخاب کنید.

**اندازه‌ها و مختصات به چه واحدی اندازه‌گیری می‌شوند؟**

در پوینت: 1 اینچ برابر با 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای متعدد) را برای کاهش استفاده از حافظه مدیریت کنم؟**

از [استراتژی‌های مدیریت BLOB](/slides/fa/nodejs-java/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و نسبت به جریان‌های صرفاً حافظه‌ای، گردش کار مبتنی بر فایل را ترجیح بدهید.

**آیا می‌توانم ارائه‌ها را به صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید بر روی همان نمونهٔ [ارائه](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) از [چندین رشته](/slides/fa/nodejs-java/multithreading/) کار کنید. برای هر رشته یا فرآیند، نمونه‌های جداگانه و ایزوله‌ای اجرا کنید.

**چگونه واترمارک و محدودیت‌های نسخه آزمایشی را حذف کنم؟**

[اعمال یک لایسنس](/slides/fa/nodejs-java/licensing/) یک بار برای هر فرآیند. XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس باید در صورت حضور چندین رشته همگام‌سازی شود.

**آیا می‌توانم PPTX ای که ایجاد می‌کنم را به صورت دیجیتال امضا کنم؟**

بله. [امضای دیجیتال](/slides/fa/nodejs-java/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

**آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟**

بله. می‌توانید [ایجاد/ویرایش پروژه‌های VBA](/slides/fa/nodejs-java/presentation-via-vba/) کنید و فایل‌های دارای ماکرو مانند PPTM/PPSM را ذخیره کنید.