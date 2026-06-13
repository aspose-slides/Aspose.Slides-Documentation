---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/java/api-limitations/
keywords:
- محدودیت‌های API
- قالب صادرات
- برنامه
- تولیدکننده
- ویژگی‌های سند
- متاداده
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides for Java را بدانید: خروجی‌ها متادادهٔ ثابت Application/Producer را در فرمت‌های PPT، PPTX، ODP و PDF تعیین می‌کنند—که به شما کمک می‌کند ادغام‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **بررسی کلی**

زمانی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی متاداده‌های فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مرتبط با فیلدهای متادادهٔ `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **برنامه و تولیدکننده**

زمانی که ارائه‌ها را با Aspose.Slides for Java ایجاد یا صادر می‌کنید، برخی متاداده‌های فنی در فایل نوشته می‌شود. دو فیلد که اغلب سؤال برانگیخته می‌کنند عبارتند از:

**Application** برنامه‌ای را شناسایی می‌کند که یک ارائهٔ **PPTX** را ایجاد یا آخرین بار ذخیره کرده است. در Aspose.Slides for Java، این مقدار ثابت است و به جای نام برنامهٔ شما، فروشندهٔ کتابخانه را نشان می‌دهد، حتی اگر از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) استفاده کنید.

**Producer** موتور رندری را شناسایی می‌کند که فایل نهایی را در زمان صادرات تولید کرده است. در صادرات **PDF**، متاداده از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for Java، هر دو این فیلدها ثابت هستند و نشانگر کتابخانه و نسخهٔ آن می‌باشند.

**چه‌چیزهایی محدود است**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، مقدار ویژگی Application به صورت "Aspose.Slides for Java" نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت "Aspose.Slides for Java x.x.x." نوشته می‌شوند. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوهٔ بارگذاری یا ذخیره‌سازی فایل و مقادیری که با [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) اختصاص می‌دهید، اعمال می‌شود.