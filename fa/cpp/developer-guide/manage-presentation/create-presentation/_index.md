---
title: ایجاد ارائه‌ها در C++
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "ایجاد ارائه‌ها در C++ با Aspose.Slides—تولید فایل‌های PPT ، PPTX و ODP ، بهره‌مندی از پشتیبانی OpenDocument و ذخیره برنامه‌نویسی آن‌ها برای نتایج قابل اعتماد."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنید، محتوای ساده‌ای به اسلاید اضافه کنید و نتیجه را به‌عنوان یک فایل ذخیره کنید.

## **ایجاد یک ارائه PowerPoint**
برای افزودن یک خط ساده به اسلاید انتخاب‌شده از ارائه، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
3. یک AutoShape از نوع Line را با استفاده از متد AddAutoShape که توسط شیء Shapes ارائه می‌شود، اضافه کنید.
4. ارائه‌ی اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

در مثال زیر، ما یک خط به اولین اسلاید ارائه اضافه کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **سوالات متداول**

**کدام فرمت‌ها را می‌توانم برای ذخیره یک ارائه جدید استفاده کنم؟**

می‌توانید به فرمت‌های [PPTX, PPT, and ODP](/slides/fa/cpp/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/cpp/convert-powerpoint-to-xps/)، [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، [SVG](/slides/fa/cpp/convert-powerpoint-to-png/) و [images](/slides/fa/cpp/convert-powerpoint-to-png/) صادر کنید، و غیره.

**آیا می‌توانم از یک قالب (POTX/POTM) شروع کنم و به‌عنوان PPTX معمولی ذخیره کنم؟**

بله. قالب را بارگذاری کنید و به فرمت موردنظر ذخیره کنید؛ فرمت‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شوند](/slides/fa/cpp/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت عرض و ارتفاع اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

اندازهٔ [slide size](/slides/fa/cpp/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیم‌هایی مانند 4:3 و 16:9 یا ابعاد سفارشی) و تعیین کنید محتوا چگونه مقیاس‌بندی شود.

**واحدهای اندازه‌ها و مختصات چه هستند؟**

در واحد points: 1 اینچ برابر با 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (دارای فایل‌های رسانه‌ای فراوان) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [BLOB management strategies](/slides/fa/cpp/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و گردش کار مبتنی بر فایل را نسبت به جریان‌های صرفاً در‑حافظه ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟**

نمی‌توانید روی همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) از چندین [multiple threads](/slides/fa/cpp/multithreading/) عمل کنید. برای هر رشته یا فرآیند یک نمونهٔ جداگانه و مستقل اجرا کنید.

**چگونه علامت آب‌نماد آزمایشی و محدودیت‌ها را حذف کنم؟**

[Apply a license](/slides/fa/cpp/licensing/) یک‌بار برای هر فرآیند. فایل XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس در صورت وجود چندین رشته باید همگام‌سازی شود.

**آیا می‌توانم PPTX ایجاد‌شده را به‌صورت دیجیتالی امضا کنم؟**

بله. [Digital signatures](/slides/fa/cpp/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

**آیا ماکروها (VBA) در ارائه‌های ایجاد‌شده پشتیبانی می‌شوند؟**

بله. می‌توانید [create/edit VBA projects](/slides/fa/cpp/presentation-via-vba/) را انجام دهید و فایل‌های دارای ماکرو مانند PPTM/PPSM را ذخیره کنید.