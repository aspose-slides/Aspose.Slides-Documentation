---
title: دریافت تمام پس‌زمینهٔ اسلاید از یک ارائه به‌صورت تصویر
linktitle: تمام پس‌زمینهٔ اسلاید
type: docs
weight: 95
url: /fa/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- پس‌زمینه اسلاید
- پس‌زمینه نهایی
- استخراج پس‌زمینه
- تمام پس‌زمینه
- پس‌زمینه به تصویر
- پس‌زمینه PPT
- پس‌زمینه PPTX
- پس‌زمینه ODP
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "استخراج پس‌زمینه‌های کامل اسلاید به‌صورت تصویر از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java، جریان‌های بصری را ساده می‌کند."
---
## **بررسی کلی**

در ارائه‌های PowerPoint، پس‌زمینه یک اسلاید می‌تواند از چندین عنصر شامل تصویر پس‌زمینه اسلاید، تم ارائه، طرح رنگ و اشیائی که روی اسلاید مستر یا اسلاید قالب قرار گرفته‌اند، تشکیل شود.

این مقاله نشان می‌دهد چگونه می‌توان تمام پس‌زمینه اسلاید را به‌صورت تصویر با استفاده از Aspose.Slides استخراج کرد. از آنجا که روشی واحد برای این کار وجود ندارد، رویکرد شامل کلون کردن اسلاید انتخاب شده به یک ارائه موقت، حذف اشکال اسلاید و سپس تبدیل پس‌زمینه حاصل به تصویر است.

## **دریافت تمام پس‌زمینه اسلاید**

Aspose.Slides for Node.js via Java does not provide a simple method to extract the entire presentation slide background as an image, but you can follow the steps below to do this:
1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
1. اندازه اسلاید را از ارائه دریافت کنید.
1. یک اسلاید را انتخاب کنید.
1. یک ارائه موقت ایجاد کنید.
1. اندازه اسلاید یکسان را در ارائه موقت تنظیم کنید.
1. اسلاید انتخاب‌شده را به ارائه موقت کلون کنید.
1. اشکال را از اسلاید کلون‌شده حذف کنید.
1. اسلاید کلون‌شده را به تصویر تبدیل کنید.

مثال کد زیر تمام پس‌زمینه اسلاید ارائه را به‌صورت تصویر استخراج می‌کند.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **سوالات متداول**

**آیا گرادیان‌ها، بافت‌ها یا پرکننده‌های تصویری پیچیده از اسلاید مستر در تصویر پس‌زمینه حاصل حفظ می‌شوند؟**

بله. Aspose.Slides پرکننده‌های گرادیان، تصویر و بافت تعریف شده بر روی اسلاید، قالب یا مستر را رندر می‌کند. اگر نیاز دارید ظاهر را از مسترهای ارث‌برده جدا کنید، قبل از خروجی‌گیری بر روی اسلاید فعلی یک پس‌زمینهٔ اختصاصی [تنظیم پس‌زمینهٔ اختصاصی](/slides/fa/nodejs-java/presentation-background/) تنظیم کنید.

**آیا می‌توانم قبل از ذخیره‌سازی، یک واترمارک به تصویر پس‌زمینهٔ حاصل اضافه کنم؟**

بله. می‌توانید یک شکل یا تصویر [اضافه کردن واترمارک](/slides/fa/nodejs-java/watermark/) را بر روی یک [کپی اسلاید](/slides/fa/nodejs-java/clone-slides/) کاری (در پشت محتوای دیگر قرار گرفته) اضافه کنید و سپس خروجی بگیرید. این کار به شما امکان می‌دهد تصویر پس‌زمینه‌ای با واترمارک یکپارچه تولید کنید.

**آیا می‌توانم پس‌زمینهٔ یک قالب یا مستر خاص را بدون ارتباط با اسلاید موجود دریافت کنم؟**

بله. مستر یا قالب موردنظر را دسترسی پیدا کنید، آن را بر روی یک [اسلاید موقت](/slides/fa/nodejs-java/clone-slides/) با اندازهٔ موردنیاز اعمال کنید و سپس آن اسلاید را خروجی بگیرید تا پس‌زمینه استخراج‌شده از آن قالب یا مستر به‌دست آید.

**آیا محدودیت‌های لایسنس وجود دارد که بر خروجی تصویر تأثیر بگذارد؟**

ویژگی‌های رندر با یک [مجوز معتبر](/slides/fa/nodejs-java/licensing/) به‌طور کامل در دسترس هستند. در حالت ارزیابی، خروجی ممکن است شامل محدودیت‌هایی مانند واترمارک باشد. لایسنس را یک بار برای هر فرآیند فعال کنید قبل از اجرای خروجی‌های دسته‌ای.