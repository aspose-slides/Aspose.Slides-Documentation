---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/cpp/api-limitations/
keywords:
- محدودیت‌های API
- فرمت صادرات
- برنامه
- تولیدکننده
- خصوصیات سند
- متادیتا
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides for C++ را بشناسید: صادر کردن‌ها متادیتای ثابت Application/Producer را در PPT، PPTX، ODP و PDF تنظیم می‌کند—به شما کمک می‌کند تا ادغام‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **مروری کلی**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی متادیتاهای فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مربوط به فیلدهای متادیتای `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **Application و Producer**

هنگامی که ارائه‌ها را با Aspose.Slides for C++ ایجاد یا صادر می‌کنید، برخی متادیتاهای فنی در فایل نوشته می‌شود. دو فیلد که اغلب سوال برانگیزند:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده شناسایی می‌کند. در Aspose.Slides for C++، این مقدار ثابت است و فروشنده کتابخانه را نشان می‌دهد نه نام برنامه شما، حتی اگر از [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/fa/cpp/aspose.slides/documentproperties/set_nameofapplication/) استفاده کنید.

**Producer** موتور رندر را که فایل نهایی را در زمان صادرت تولید کرده است شناسایی می‌کند. در صادرت **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for C++، هر دو ثابت‌اند و کتابخانه و نسخه آن را نشان می‌دهند.

**چه چیزهایی محدود هستند**

نمی‌توانید این فیلدها را از طریق API برای فرمت‌های مذکور بازنویسی کنید. برای **PPTX**، ویژگی Application به صورت "Aspose.Slides for C++" نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت "Aspose.Slides for C++ x.x.x" نوشته می‌شوند. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوه بارگذاری یا ذخیره‌سازی فایل و صرف‌نظر از مقادیری که با استفاده از [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/fa/cpp/aspose.slides/documentproperties/set_nameofapplication/) اختصاص می‌دهید، اعمال می‌شود.