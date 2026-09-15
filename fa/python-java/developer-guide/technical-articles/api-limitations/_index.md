---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/python-java/api-limitations/
keywords:
- محدودیت‌های API
- قالب خروجی
- برنامه
- تولیدکننده
- ویژگی‌های سند
- فراداده
- پاورپوینت
- سند باز
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "درباره محدودیت‌های Aspose.Slides برای Python via Java بیاموزید: متادیتای ثابت Application، Creator و Producer در فایل‌های PPTX و PDF."
---
## **بررسی کلی**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی متادیتاهای فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مرتبط با فیلدهای متادیتای `Application`، `Creator` و `Producer` را در فایل‌های PPTX و PDF توضیح می‌دهد.

## **Application و Producer**

هنگام ایجاد یا صادرات ارائه‌ها با Aspose.Slides for Python via Java، برخی متادیتاهای فنی در فایل نوشته می‌شود. دو فیلد که اغلب سوال ایجاد می‌کنند:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده است، شناسایی می‌کند. در Aspose.Slides for Python via Java، این مقدار ثابت است و به‌جای نام برنامه شما، نام فروشنده کتابخانه را نشان می‌دهد، حتی اگر از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#setnameofapplication) استفاده کنید.

**Producer** موتور رندرینگ را که فایل نهایی را در زمان صادرات تولید کرده است، شناسایی می‌کند. در صادرات **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for Python via Java، هر دو این فیلدها ثابت هستند و کتابخانه و نسخه آن را نشان می‌دهند.

**چه چیزی محدود است**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، مقدار ویژگی Application به صورت "Aspose.Slides for Java" نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت "Aspose.Slides for Java x.x.x." نوشته می‌شوند. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوه بارگذاری یا ذخیره‌سازی فایل و مقادیری که با [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#setnameofapplication) اختصاص می‌دهید، اعمال می‌شود.

## **سوالات متداول**

**آیا می‌توانم مقدار Application را در یک فایل PPTX با نام برنامه خود جایگزین کنم؟**

خیر. مقدار ثابت است، حتی اگر از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#setnameofapplication) استفاده کنید.

**آیا می‌توانم فیلدهای Creator و Producer را در صادرات PDF بازنویسی کنم؟**

خیر. هر دو فیلد ثابت هستند و کتابخانه و نسخه آن را نشان می‌دهند، صرف‌نظر از نحوه بارگذاری یا ذخیره‌سازی ارائه.