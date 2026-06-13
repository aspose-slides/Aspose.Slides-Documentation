---
title: محدودیت‌های API
type: docs
weight: 210
url: /fa/python-net/api-limitations/
keywords:
- محدودیت‌های API
- قالب صادرات
- برنامه
- تولیدکننده
- ویژگی‌های سند
- فراداده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides for Python را بدانید: صادرات، فراداده ثابت Application/Producer را در فایل‌های PPT، PPTX، ODP و PDF تنظیم می‌کند—تا به شما کمک کند یکپارچه‌سازی‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **بررسی کلی**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی فراداده‌های فنی به فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مرتبط با فیلدهای فراداده `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **Application و Producer**

هنگامی که ارائه‌ها را با Aspose.Slides for Python via .NET ایجاد یا صادر می‌کنید، برخی فراداده‌های فنی در فایل نوشته می‌شود. دو فیلد که غالباً سؤال برانگیزی دارند:

**Application** برنامه‌ای را شناسایی می‌کند که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده است. در Aspose.Slides for Python via .NET، این مقدار ثابت است و فروشنده کتابخانه را نشان می‌دهد نه نام برنامه شما، حتی اگر [DocumentProperties.name_of_application](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/name_of_application/) را تنظیم کنید.

**Producer** موتور رندرینگی را شناسایی می‌کند که فایل نهایی را هنگام صادر کردن تولید می‌کند. در صادرات **PDF**، فراداده از فیلدهای **Creator** و **Producer** استفاده می‌کند. در Aspose.Slides for Python via .NET، هر دو این فیلدها ثابت هستند و کتابخانه و نسخه آن را نشان می‌دهند.

**چه مواردی محدود هستند**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، ویژگی Application به صورت "Aspose.Slides for Python via .NET" نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت "Aspose.Slides for Python via .NET x.x.x" نوشته می‌شوند. این رفتار طوری است که از ابتدا طراحان آن تعیین کرده‌اند و بدون در نظر گرفتن نحوه بارگذاری یا ذخیره‌سازی فایل، و بدون در نظر گرفتن مقادیری که به [DocumentProperties.name_of_application](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/name_of_application/) اختصاص داده‌اید، اعمال می‌شود.