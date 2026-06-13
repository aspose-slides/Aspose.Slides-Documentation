---
title: دریافت و به‌روزرسانی اطلاعات ارائه در PHP
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/php-java/examine-presentation/
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
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌ها را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توان اطلاعات ارائه را در Aspose.Slides بررسی کرد. توضیح می‌دهد چگونه بدون بارگیری کامل فایل، قالب فعلی یک ارائه را تعیین کنید، ویژگی‌های سند آن را بخوانید و در صورت لزوم این ویژگی‌ها را به‌روز کنید.

مثال‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی قالب یک ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید بدانید که در حال حاضر این ارائه در چه قالبی (PPT، PPTX، ODP و سایرین) است.

می‌توانید قالب ارائه را بدون بارگیری آن بررسی کنید. کد PHP زیر را ببینید:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **دریافت ویژگی‌های ارائه**

این کد PHP نشان می‌دهد چگونه ویژگی‌های ارائه (اطلاعات درباره ارائه) را دریافت کنید:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

شاید بخواهید [ویژگی‌های موجود در DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#DocumentProperties--) را ببینید.

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) را فراهم می‌کند که امکان اعمال تغییرات بر روی ویژگی‌های ارائه را می‌دهد.

فرض کنید یک ارائه PowerPoint داریم که ویژگی‌های سند آن در زیر نشان داده شده است.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از ویژگی‌های ارائه را ویرایش کنیم:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده‌اند.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر درباره یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها مفید باشند:

- [بررسی اینکه آیا یک ارائه رمزگذاری شده است](https://docs.aspose.com/slides/fa/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [بررسی اینکه آیا یک ارائه محافظت شده از نوشتن (فقط-خواندنی) است](https://docs.aspose.com/slides/fa/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [بررسی اینکه آیا یک ارائه قبل از بارگیری محافظت شده با رمز عبور است](https://docs.aspose.com/slides/fa/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأیید رمز عبوری که برای محافظت از یک ارائه استفاده شده است](https://docs.aspose.com/slides/fa/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها تعبیه شده‌اند و کدام‌ها هستند؟**

به دنبال [اطلاعات قلم‌های تعبیه‌شده](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getembeddedfonts/) در سطح ارائه بگردید، سپس این ورودی‌ها را با مجموعهٔ [قلم‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا قلم‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم به سرعت تشخیص دهم که آیا فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

از طریق [مجموعه اسلایدها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) عبور کنید و پرچم [قابلیت نمایش](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/gethidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت سفارشی اسلاید استفاده شده است و آیا از پیش‌فرض‌ها متفاوت است؟**

بله. اندازه و جهت فعلی [اسلاید](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getslidesize/) را با پیش‌تنظیمات استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار برای چاپ و خروجی کمک می‌کند.

**آیا راه سریع برای مشاهده اینکه نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. همهٔ [نمودارها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/) را مرور کنید، [منبع داده](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/getdatasourcetype/) آن‌ها را بررسی کنید و مشخص کنید که داده داخلی است یا مبتنی بر لینک، شامل هر لینک شکسته‌ای.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیاء را حساب کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و محتواهای چندرسانه‌ای باشید؛ یک امتیاز کلی پیچیدگی تخمینی اختصاص دهید تا نقاط بحرانی عملکردی را شناسایی کنید.