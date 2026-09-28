---
title: محدودیت‌های متادیتای خروجی
type: docs
weight: 320
url: /fa/net/api-limitations/
keywords:
- محدودیت‌های API
- قالب خروجی
- برنامه
- تولیدکننده
- خواص سند
- متادیتا
- مولد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET متادیتای ثابت برنامه، سازنده و تولیدکننده را در فایل‌های ذخیره‌شده PPTX، PDF و ODP می‌نویسد، صرف‌نظر از نام برنامه‌ای که تنظیم می‌کنید."
---
## **Overview**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی فراداده‌های فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مربوط به فیلدهای متادیتا `Application`، `Creator`، `Producer` و generator در فایل‌های PPTX، PDF و ODP را توضیح می‌دهد.

## **Application and Producer**

وقتی ارائه‌ها را با Aspose.Slides for .NET ایجاد یا صادر می‌کنید، برخی فراداده‌های فنی در فایل نوشته می‌شود. دو فیلد که اغلب سؤال برانگیخته می‌کنند:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده است شناسایی می‌کند. در Aspose.Slides for .NET، این مقدار ثابت است و نام کتابخانه را به جای نام برنامه شما نشان می‌دهد، حتی اگر [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/nameofapplication/) را تنظیم کنید.

**Producer** موتور رندرینگ را که فایل نهایی را در هنگام خروج تولید کرده است شناسایی می‌کند. در خروجی‌های **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for .NET، هر دو این فیلد ثابت هستند و کتابخانه و نسخه آن را نشان می‌دهند.

**What’s restricted**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، مقدار خصوصیت Application به صورت «Aspose.Slides for .NET» نوشته می‌شود. برای **PDF**، خصوصیت‌های Creator و Producer به صورت «Aspose.Slides for .NET» به‌همراه نسخه کتابخانه نوشته می‌شوند. برای **ODP**، فیلد generator به صورت «Aspose.Slides for .NET» به‌همراه نسخه کتابخانه نوشته می‌شود. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوه بارگذاری یا ذخیره‌سازی فایل و مقادیری که به [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/nameofapplication/) اختصاص داده‌اید، اعمال می‌شود.

این محدودیت در فایل‌های **PPT** اعمال نمی‌شود: در یک فایل PPT، نام برنامه‌ای که در [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/nameofapplication/) تنظیم کرده‌اید ذخیره می‌شود.