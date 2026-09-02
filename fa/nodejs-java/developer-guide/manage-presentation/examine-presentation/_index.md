---
title: دریافت و به‌روزرسانی اطلاعات ارائه در جاوااسکریپت
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/nodejs-java/examine-presentation/
keywords:
- قالب ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های پاورپوینت و سند باز بررسی کنید با استفاده از جاوااسکریپت برای دریافت سریع‌تر بینش‌ها و ارزیابی هوشمندانه‌تری از محتوا."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه اطلاعات ارائه را در Aspose.Slides بررسی کنید. توضیح می‌دهد چگونه می‌توانید قالب فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کنید، ویژگی‌های سند آن را بخوانید و در صورت نیاز این ویژگی‌ها را به‌روزرسانی کنید.

مثال‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی قالب ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید قالب (PPT، PPTX، ODP و غیره) که ارائه در حال حاضر دارد را بیابید.

می‌توانید قالب ارائه را بدون بارگذاری فایل بررسی کنید. این کد جاوااسکریپت را ببینید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **دریافت ویژگی‌های ارائه**

این کد جاوااسکریپت به شما نشان می‌دهد چگونه ویژگی‌های ارائه (اطلاعات دربارهٔ ارائه) را دریافت کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

ممکن است بخواهید [ویژگی‌های تحت کلاس DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) را مشاهده کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) را فراهم می‌کند که امکان تغییر ویژگی‌های ارائه را می‌دهد.

فرض کنید یک ارائهٔ PowerPoint با ویژگی‌های سند زیر داریم.

![ویژگی‌های سند اصلی ارائهٔ PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از ویژگی‌های ارائه را ویرایش کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده است.

![ویژگی‌های سند تغییر یافتهٔ ارائهٔ PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این پیوندها مفید باشند:

- [رمزنگاری ارائه‌ها](/slides/fa/nodejs-java/password-protected-presentation/)
- [قفل‌کردن نوشتن در ارائه‌ها](/slides/fa/nodejs-java/write-protected-presentation/)

## **FAQ**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

به دنبال [اطلاعات قلم‌های جاسازی‌شده](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) در سطح ارائه بگردید، سپس این ورودی‌ها را با مجموعهٔ [قلم‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا قلم‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم به سرعت تشخیص دهم که فایل اسلایدهای مخفی دارد و چه تعداد؟**

از طریق [کلیکسیون اسلایدها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) پیمایش کنید و پرچم [قابلیت نمایش هر اسلاید](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/gethidden/) را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با مقادیر پیش‌فرض متفاوت هستند؟**

بله. اندازهٔ فعلی [اسلاید](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslidesize/) و جهت آن را با پیش‌تنظیم‌های استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار هنگام چاپ و خروجی‌گیری کمک می‌کند.

**آیا راهی سریع برای مشاهده این‌که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [نمودارها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) را طی کنید، منبع دادهٔ آن‌ها را بررسی کنید ([نوع منبع داده](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)) و ببینید داده داخلی است یا بر پایهٔ لینک، شامل هر لینک شکسته‌ای.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیا را بشمارید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و مولتی‌مدیا بگردید؛ یک امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط داغ عملکردی ممکن را علامت‌گذاری کنید.