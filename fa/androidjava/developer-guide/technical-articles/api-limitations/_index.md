---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/androidjava/api-limitations/
keywords:
- محدودیت‌های API
- قالب خروجی
- برنامه
- تولیدکننده
- ویژگی‌های سند
- متادیتا
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides برای Android را بدانید: خروجی‌ها متادیتای ثابت Application/Producer را در PPT، PPTX، ODP و PDF تنظیم می‌کنند—که به شما کمک می‌کند یکپارچه‌سازی‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **نمای کلی**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی متادیتاهای فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مربوط به فیلدهای متادیتای `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **Application و Producer**

هنگامی که ارائه‌ها را با Aspose.Slides for Android via Java ایجاد یا صادر می‌کنید، برخی متادیتاهای فنی در فایل نوشته می‌شود. دو فیلد که اغلب پرسشی ایجاد می‌کنند:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده است شناسایی می‌کند. در Aspose.Slides for Android via Java، این مقدار ثابت است و فروشنده کتابخانه را نشان می‌دهد نه نام برنامه شما، حتی اگر از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) استفاده کنید.

**Producer** موتور رندرنگی را که فایل نهایی را در حین خروجی‌گیری تولید کرده است شناسایی می‌کند. در خروجی‌های **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for Android via Java، هر دو این فیلدها ثابت هستند و کتابخانه و نسخه آن را نشان می‌دهند.

**چه‌چیز محدود است**

شما نمی‌توانید این فیلدها را از طریق API برای قالب‌های فوق بازنویسی کنید. برای **PPTX**، مقدار ویژگی Application به صورت "Aspose.Slides for Android via Java" نوشته می‌شود. برای **PDF**، مقادیر ویژگی‌های Creator و Producer به صورت "Aspose.Slides for Android via Java x.x.x." نوشته می‌شوند. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوه بارگذاری یا ذخیره‌سازی فایل و صرف‌نظر از مقادیری که با استفاده از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) اختصاص داده می‌شود، اعمال می‌شود.