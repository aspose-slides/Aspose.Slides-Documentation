---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/php-java/api-limitations/
keywords:
- محدودیت‌های API
- فرمت صادرات
- برنامه
- تولیدکننده
- ویژگی‌های سند
- فراداده
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides for PHP را بدانید: صادرات، فرادادهٔ Application/Producer ثابت را در فایل‌های PPT، PPTX، ODP و PDF تنظیم می‌کند—به شما کمک می‌کند تا ادغام‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **مرور کلی**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، برخی فراداده‌های فنی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مرتبط با فیلدهای فرادادهٔ `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **Application و Producer**

هنگامی که ارائه‌ها را با Aspose.Slides for PHP via Java ایجاد یا صادر می‌کنید، برخی فراداده‌های فنی در فایل نوشته می‌شود. دو فیلد که معمولاً سؤالاتی را برمی‌انگیزند:

**Application** برنامه‌ای را شناسایی می‌کند که یک ارائهٔ **PPTX** را ایجاد یا آخرین بار ذخیره کرده است. در Aspose.Slides for PHP via Java، این مقدار ثابت است و فروشندهٔ کتابخانه را نشان می‌دهد نه نام برنامهٔ شما، حتی اگر از [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/setnameofapplication/) استفاده کنید.

**Producer** موتور رندرینگ را شناسایی می‌کند که فایل نهایی را در زمان صادرات تولید کرده است. در خروجی‌های **PDF**، فراداده از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for PHP via Java، هر دو این فیلدها ثابت هستند و کتابخانه و نسخهٔ آن را نشان می‌دهند.

**چه چیزهایی محدود است**

نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، ویژگی Application به صورت «Aspose.Slides for PHP via Java» نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت «Aspose.Slides for PHP via Java x.x.x.» نوشته می‌شوند. این رفتار به‌صورت پیش‌فرض است و صرف‌نظر از نحوهٔ بارگذاری یا ذخیره‌سازی فایل، و صرف‌نظر از مقادیری که با استفاده از [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/setnameofapplication/) اختصاص می‌دهید، اعمال می‌شود.