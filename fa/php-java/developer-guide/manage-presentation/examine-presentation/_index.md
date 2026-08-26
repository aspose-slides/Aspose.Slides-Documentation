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
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌های ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای PHP بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های هوشمندانه‌تر محتوا به دست آورید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه اطلاعات ارائه را در Aspose.Slides بررسی کنیم. توضیح می‌دهد چگونه قالب فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کنیم، ویژگی‌های سند آن را بخوانیم و در صورت نیاز آن ویژگی‌ها را به‌روزرسانی کنیم.

مثال‌ها بر پایه APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی قالب ارائه**

قبل از کار بر روی یک ارائه، ممکن است بخواهید فرمت فعلی (PPT، PPTX، ODP و سایر) ارائه را بفهمید.

می‌توانید فرمت ارائه را بدون بارگذاری آن بررسی کنید. کد PHP زیر را ببینید:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **دریافت ویژگی‌های ارائه**

این کد PHP نشان می‌دهد چگونه ویژگی‌های ارائه (اطلاعات دربارهٔ ارائه) را دریافت کنید:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

ممکن است بخواهید [ویژگی‌ها تحت DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#DocumentProperties--) کلاس را ببینید.

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) را فراهم می‌کند که امکان تغییر ویژگی‌های ارائه را می‌دهد.

فرض کنید یک ارائه PowerPoint با ویژگی‌های سند زیر داریم.

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

نتایج تغییر ویژگی‌های سند در ادامه نمایش داده شده است.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای دریافت اطلاعات بیشتر دربارهٔ یک ارائه و ویژگی‌های امنیتی آن، ممکن است این پیوندها مفید باشند:

- [محافظت از ارائه‌ها با رمز عبور](/slides/fa/php-java/password-protected-presentation/)
- [محافظت از ارائه‌ها در نوشتن](/slides/fa/php-java/write-protected-presentation/)

## **پرسش‌های متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها؟**  
به دنبال اطلاعات [embedded-font] در سطح ارائه بگردید، سپس آن ورودی‌ها را با مجموعهٔ [fonts actually used across content] مقایسه کنید تا قلم‌های ضروری برای رندر را شناسایی کنید.

**چگونه می‌توانم به سرعت بفهمم آیا فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**  
در [slide collection] پیمایش کنید و برای هر اسلاید پرچم [visibility flag] آن را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت‌گیری سفارشی اسلایدها استفاده شده‌اند و آیا با پیش‌فرض‌ها متفاوت هستند؟**  
بله. اندازهٔ فعلی [slide size] و جهت‌گیری را با پیش‌فرض‌های استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار برای چاپ و خروجی کمک می‌کند.

**آیا روش سریعی وجود دارد تا ببینم آیا نمودارها به منابع دادهٔ خارجی ارجاع می‌دهند؟**  
بله. تمام [charts] را مرور کنید، منبع دادهٔ آن‌ها را با [data source] بررسی کنید و ببینید آیا داده داخلی است یا بر پایهٔ لینک، شامل لینک‌های خراب.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**  
برای هر اسلاید، تعداد اشیا را بشمارید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و مدیاهای چندرسانه‌ای بگردید؛ سپس امتیاز پیچیدگی تقریبی بدهید تا نقاط ضعف عملکردی شناسایی شوند.