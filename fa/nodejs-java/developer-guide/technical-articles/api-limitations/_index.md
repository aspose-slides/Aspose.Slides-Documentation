---
title: محدودیت‌های API
type: docs
weight: 320
url: /fa/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "محدودیت‌های Aspose.Slides برای Node.js را بدانید: صادرات، متادیتای ثابت Application/Producer را در PPT، PPTX، ODP و PDF تنظیم می‌کند—به شما کمک می‌کند تا ادغام‌ها را بدون شگفتی برنامه‌ریزی کنید."
---
## **مروری**

هنگامی که ارائه‌ها با Aspose.Slides ایجاد یا صادر می‌شوند، متادیتای فنی خاصی در فایل خروجی نوشته می‌شود. این مقاله محدودیت‌های مربوط به فیلدهای متادیتای `Application`، `Creator` و `Producer` در فایل‌های PPTX و PDF را توضیح می‌دهد.

## **Application و Producer**

هنگامی که با Aspose.Slides for Node.js via Java ارائه‌ها را ایجاد یا صادر می‌کنید، برخی از متادیتای فنی در فایل نوشته می‌شوند. دو فیلد که معمولاً سؤال برانگیخته می‌کنند عبارتند از:

**Application** برنامه‌ای را که یک ارائه **PPTX** را ایجاد یا آخرین بار ذخیره کرده است شناسایی می‌کند. در Aspose.Slides for Node.js via Java، این مقدار ثابت است و فروشنده کتابخانه را نمایش می‌دهد نه نام برنامه شما، حتی اگر از [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) استفاده کنید.

**Producer** موتور رندرینگ را که هنگام صادرات فایل نهایی تولید شده را شناسایی می‌کند. در صادرات **PDF**، متادیتا از فیلدهای **Creator** و **Producer** استفاده می‌کند. با Aspose.Slides for Node.js via Java، هر دو این فیلدها ثابت هستند و کتابخانه و نسخهٔ آن را منعکس می‌کنند.

**What’s restricted**

شما نمی‌توانید این فیلدها را از طریق API برای فرمت‌های فوق بازنویسی کنید. برای **PPTX**، ویژگی Application به صورت «Aspose.Slides for Node.js via Java» نوشته می‌شود. برای **PDF**، ویژگی‌های Creator و Producer به صورت «Aspose.Slides for Node.js via Java x.x.x.» نوشته می‌شوند. این رفتار به‌طور پیش‌فرض اعمال می‌شود و بدون توجه به نحوهٔ بارگذاری یا ذخیرهٔ فایل، و حتی با مقادیری که با [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) تعیین می‌کنید، اعمال می‌گردد.