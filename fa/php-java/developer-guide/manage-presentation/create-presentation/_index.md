---
title: ایجاد ارائه‌ها در PHP
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "با Aspose.Slides برای PHP از طریق Java، ارائه‌ها را ایجاد کنید — فایل‌های PPT، PPTX و ODP تولید کرده و به‌صورت برنامه‌نویسی ذخیره کنید تا نتایج قابل اعتماد به دست آید."
---
## **مرور**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنید، محتوای ساده‌ای به یک اسلاید اضافه کنید و نتیجه را به صورت فایل ذخیره کنید. همچنین نحوهٔ ایجاد و ذخیرهٔ ارائهٔ جدید، باز کردن ارائهٔ موجود در یک قالب پشتیبانی‌شده و ذخیرهٔ آن به قالب دیگر را نشان می‌دهد. به‌علاوه، مقاله شامل یک بخش پرسش‌های متداول کوتاه دربارهٔ قالب‌ها، الگوها، اندازه اسلاید، واحدها، مصرف حافظه، پردازش‌های چندنخی، مجوزها، امضای دیجیتال و پشتیبانی از VBA است.

## **ایجاد یک ارائه**

برای افزودن یک خط ساده به اسلاید انتخاب‌شدهٔ ارائه، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. با استفاده از Index آن، ارجاع یک اسلاید را به دست آورید.
3. یک AutoShape از نوع خط را با استفاده از متد addAutoShape که توسط شی Shapes ارائه شده است، اضافه کنید.
4. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.

در مثال زیر، یک خط به اولین اسلاید ارائه افزوده شده است.

```php
  # یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
  $pres = new Presentation();
  try {
    # اسلاید اول را دریافت کنید
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape از نوع خط اضافه کنید
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**به چه قالب‌هایی می‌توانم یک ارائهٔ جدید را ذخیره کنم؟**

می‌توانید به قالب‌های [PPTX, PPT, و ODP](/slides/fa/php-java/save-presentation/) ذخیره کنید و به فرمت‌های [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/php-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/php-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/php-java/convert-powerpoint-to-png/) و [images](/slides/fa/php-java/convert-powerpoint-to-png/) صادر کنید.

**آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به صورت PPTX عادی ذخیره کنم؟**

بله. الگو را بارگذاری کنید و به قالب مورد نظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و قالب‌های مشابه [پشتیبانی می‌شوند](/slides/fa/php-java/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت عرض و ارتفاع اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

ابعاد [slide size](/slides/fa/php-java/slide-size/) را تنظیم کنید (شامل پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) و نحوه مقیاس‌بندی محتوا را تعیین کنید.

**اندازه‌ها و مختصات بر چه واحدی اندازه‌گیری می‌شوند؟**

در نقاط (points): 1 اینچ برابر با 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با تعداد زیاد فایل‌های رسانه‌ای) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [BLOB management strategies](/slides/fa/php-java/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به‌ جای جریان‌های صرفاً در حافظه، گردش‌کار مبتنی بر فایل را ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید بر روی یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) از [multiple threads](/slides/fa/php-java/multithreading/) همزمان کار کنید. برای هر رشته یا فرآیند، یک نمونهٔ جداگانه و مستقل اجرا کنید.

**چگونه می‌توانم واترمارک آزمایشی و محدودیت‌ها را حذف کنم؟**

[Apply a license](/slides/fa/php-java/licensing/) را یک‌بار برای هر فرآیند اجرا کنید. فایل XML مجوز باید بدون تغییر باقی بماند و تنظیمات مجوز در صورت استفاده از چندین رشته باید همگام‌سازی شود.

**آیا می‌توانم فایل PPTX را به صورت دیجیتال امضا کنم؟**

بله. [Digital signatures](/slides/fa/php-java/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

**آیا ماکروها (VBA) در ارائه‌های ایجادشده پشتیبانی می‌شوند؟**

بله. می‌توانید [create/edit VBA projects](/slides/fa/php-java/presentation-via-vba/) را انجام دهید و فایل‌های ماکروفعال مانند PPTM/PPSM را ذخیره کنید.