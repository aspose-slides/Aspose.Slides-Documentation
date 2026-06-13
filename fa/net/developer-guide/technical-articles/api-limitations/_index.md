---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/net/api-limitations/
keywords:
- محدودیت‌های API
- فرمت صادرات
- برنامه
- تولید کننده
- خواص سند
- فراداده
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides for .NET را بدانید: صادرات، متادیتاهای ثابت Application/Producer را در PPT، PPTX، ODP و PDF تنظیم می‌کند—به شما کمک می‌کند تا یکپارچه‌سازی‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **بررسی کلی**

زمانی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی متادیتاهای فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مربوط به فیلدهای متادیتای `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **Application و Producer**

هنگامی که ارائه‌ها را با Aspose.Slides for .NET ایجاد یا صادر می‌کنید، برخی متادیتاهای فنی در فایل نوشته می‌شود. دو فیلد که اغلب سؤال برانگیخته می‌کنند:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده شناسایی می‌کند. در Aspose.Slides for .NET، این مقدار ثابت است و فروشنده کتابخانه را نشان می‌دهد نه نام برنامه شما، حتی اگر شما[DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/nameofapplication/) را تنظیم کنید.

**Producer** موتور رندرینگ را که در حین صادر کردن فایل نهایی را تولید کرده است شناسایی می‌کند. در صادرات **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for .NET، هر دو این فیلدها ثابت هستند و کتابخانه و نسخه آن را نشان می‌دهند.

**چه چیزهایی محدود شده‌اند**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، ویژگی Application به صورت "Aspose.Slides for .NET" نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت "Aspose.Slides for .NET x.x.x" نوشته می‌شوند. این رفتار به‌صورت پیش‌فرض است و بدون توجه به نحوه بارگذاری یا ذخیره‌سازی فایل و بدون توجه به مقادیری که به[DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/nameofapplication/) اختصاص داده‌اید، اعمال می‌شود.