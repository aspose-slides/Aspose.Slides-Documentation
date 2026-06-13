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
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از جاوااسکریپت برای دریافت سریع‌تر بینش‌ها و ارزیابی هوشمند محتوا بررسی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توان اطلاعات ارائه را در Aspose.Slides بررسی کرد. همچنین توضیح می‌دهد چگونه می‌توان قالب فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کرد، ویژگی‌های سند آن را خواند و در صورت نیاز آن ویژگی‌ها را به‌روزرسانی کرد.

مثال‌ها بر پایهٔ API‌های [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی قالب ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید متوجه شوید که ارائه در حال حاضر به چه قالبی (PPT، PPTX، ODP و سایر) است.

می‌توانید قالب یک ارائه را بدون بارگذاری آن بررسی کنید. به این کد جاوااسکریپت نگاه کنید:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **دریافت ویژگی‌های ارائه**

این کد جاوااسکریپت نشان می‌دهد چگونه می‌توانید ویژگی‌های ارائه (اطلاعاتی دربارهٔ ارائه) را دریافت کنید:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

ممکن است بخواهید [خواص زیر کلاس DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) را مشاهده کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) را فراهم می‌کند که به شما اجازه می‌دهد تغییراتی در ویژگی‌های ارائه اعمال کنید.

فرض کنید یک ارائه PowerPoint با ویژگی‌های سند زیر داریم.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه می‌توانید برخی از ویژگی‌های ارائه را ویرایش کنید:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده‌اند.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر در مورد یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها برای شما مفید باشند:

- [بررسی اینکه آیا یک ارائه رمزگذاری شده است](https://docs.aspose.com/slides/fa/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [بررسی اینکه آیا یک ارائه محافظت نوشتنی (فقط‑خواندنی) است](https://docs.aspose.com/slides/fa/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [بررسی اینکه آیا یک ارائه قبل از بارگذاری با رمز عبور محافظت می‌شود](https://docs.aspose.com/slides/fa/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأیید رمز عبوری که برای محافظت از ارائه استفاده شده است](https://docs.aspose.com/slides/fa/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **سؤال‌وپاسخ**

**چگونه می‌توانم بررسی کنم آیا فونت‌ها تعبیه شده‌اند و کدام‌ها؟**

به دنبال [اطلاعات فونت تعبیه‌شده](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) در سطح ارائه بگردید، سپس آن ورودی‌ها را با مجموعهٔ [فونت‌های واقعی استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا تعیین کنید کدام فونت‌ها برای رندر کردن حیاتی هستند.

**چگونه می‌توانم به سرعت تشخیص دهم آیا فایل اسلایدهای مخفی دارد و تعداد آنها چقدر است؟**

از طریق [مجموعه اسلایدها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) حلقه بزنید و پرچم [قابلیت نمایش](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/gethidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت اسلاید سفارشی استفاده می‌شود و آیا از پیش‌فرض‌ها متفاوت هستند؟**

بله. اندازهٔ فعلی [اسلاید](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslidesize/) و جهت آن را با پیش‌تنظیمات استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار برای چاپ و خروجی‌گیری کمک می‌کند.

**آیا روش سریعی برای مشاهده این که آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [نمودارها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) را پیمایش کنید، [منبع دادهٔ آنها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) را بررسی کنید و تعیین کنید داده‌ها داخلی هستند یا مبتنی بر لینک، شامل هر لینک خراب.

**چگونه می‌توانم اسلایدهای «سنگین» را که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلید، تعداد اشیاء را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و مولتی‌مدیا باشید؛ یک امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط بحرانی عملکرد را مشخص کنید.