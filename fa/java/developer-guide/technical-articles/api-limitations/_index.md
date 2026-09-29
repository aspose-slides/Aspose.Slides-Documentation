---
title: محدودیت‌های متادیتای خروجی
type: docs
weight: 320
url: /fa/java/api-limitations/
keywords:
- محدودیت‌های API
- فرمت خروجی
- برنامه
- تولیدکننده
- ویژگی‌های سند
- متادیتا
- ژنراتور
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides for Java متادیتای ثابت برنامه، سازنده و تولیدکننده را به فایل‌های ذخیره‌شده PPTX، PDF و ODP می‌نویسد، صرف‌نظر از نام برنامه‌ای که تنظیم می‌کنید."
---
## **بررسی کلی**

زمانی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی متادیتاهای فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مربوط به فیلدهای متادیتا `Application`، `Creator`، `Producer` و generator در فایل‌های PPTX، PDF و ODP را توضیح می‌دهد.

## **Application و Producer**

زمانی که ارائه‌ها را با Aspose.Slides for Java ایجاد یا صادر می‌کنید، برخی متادیتاهای فنی در فایل نوشته می‌شود. دو فیلد که معمولاً سؤال برانگیخته می‌کنند:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده است، شناسایی می‌کند. در Aspose.Slides for Java، این مقدار ثابت است و نام کتابخانه را نشان می‌دهد نه نام برنامه شما، حتی اگر از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) استفاده کنید.

**Producer** موتور رندرینگ را که فایل نهایی را در حین صادرات تولید کرده است، شناسایی می‌کند. در صادرات **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for Java، هر دو این فیلدها ثابت هستند و نشان‌دهنده کتابخانه و نسخه آن هستند.

**چه چیزهایی محدود شده‌اند**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، ویژگی Application به صورت "Aspose.Slides for Java" نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت "Aspose.Slides for Java" به‌همراه نسخه کتابخانه نوشته می‌شوند. برای **ODP**، فیلد generator به صورت "Aspose.Slides for Java" به‌همراه نسخه کتابخانه نوشته می‌شود. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوه بارگذاری یا ذخیرهٔ فایل، و صرف‌نظر از مقادیری که با استفاده از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) اختصاص می‌دهید، اعمال می‌شود.

این محدودیت برای فایل‌های **PPT** اعمال نمی‌شود: در یک فایل PPT، نام برنامه‌ای که با استفاده از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) تنظیم می‌کنید، ذخیره می‌شود.