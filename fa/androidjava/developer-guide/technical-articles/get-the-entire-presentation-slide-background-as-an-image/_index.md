---
title: دریافت پس‌زمینه کامل اسلاید از یک ارائه به عنوان تصویر
linktitle: پس‌زمینه کامل اسلاید
type: docs
weight: 95
url: /fa/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- پس‌زمینه اسلاید
- پس‌زمینه نهایی
- استخراج پس‌زمینه
- پس‌زمینه کامل
- پس‌زمینه به تصویر
- پس‌زمینه PPT
- پس‌زمینه PPTX
- پس‌زمینه ODP
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "استخراج پس‌زمینه کامل اسلایدها به‌صورت تصویر از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java، برای ساده‌سازی جریان‌های کاری بصری."
---
## **نمای کلی**

در ارائه‌های PowerPoint، پس‌زمینه اسلاید می‌تواند از عناصر متعددی تشکیل شود، از جمله تصویر پس‌زمینه اسلاید، تم ارائه، طرح رنگی و اشیائی که بر روی اسلاید اصلی یا اسلاید چیدمان قرار گرفته‌اند.

این مقاله نشان می‌دهد چگونه پس‌زمینه کامل اسلاید را به‌صورت تصویر استخراج کنید با استفاده از Aspose.Slides for .NET. چون روش تک‌خطی برای این کار وجود ندارد، رویکرد شامل کلون‌کردن اسلاید انتخاب‌شده به یک ارائه موقت، حذف شکل‌های اسلاید و سپس تبدیل پس‌زمینهٔ حاصل به تصویر می‌شود.

## **استخراج پس‌زمینه کامل اسلاید**

Aspose.Slides for Android via Java روش ساده‌ای برای استخراج پس‌زمینهٔ کامل اسلایدهای یک ارائه به‌صورت تصویر ارائه نمی‌دهد، اما می‌توانید مراحل زیر را دنبال کنید:
1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
1. اندازهٔ اسلاید را از ارائه دریافت کنید.
1. یک اسلاید را انتخاب کنید.
1. یک ارائه موقت ایجاد کنید.
1. همان اندازهٔ اسلاید را در ارائه موقت تنظیم کنید.
1. اسلاید انتخاب‌شده را به ارائه موقت کلون کنید.
1. شکل‌های اسلاید کلون‌شده را حذف کنید.
1. اسلاید کلون‌شده را به تصویر تبدیل کنید.

کد زیر مثال استخراج پس‌زمینهٔ کامل اسلایدهای یک ارائه را به‌صورت تصویر نشان می‌دهد.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **سوالات متداول**

**آیا گرادیان‌ها، بافت‌ها یا پر کردن‌های تصویری پیچیده از اسلاید اصلی در تصویر پس‌زمینهٔ حاصل حفظ می‌شود؟**

بله. Aspose.Slides گرادیان، تصویر و بافت‌های تعریف‌شده بر روی اسلاید، چیدمان یا اصلی را رندر می‌کند. اگر نیاز به جداسازی ظاهر از اسلایدهای اصلی به ارث‌برده‌شده دارید، قبل از خروجی‌گیری، [یک پس‌زمینهٔ اختصاصی](/slides/fa/androidjava/presentation-background/) برای اسلاید فعلی تنظیم کنید.

**آیا می‌توانم قبل از ذخیره‌سازی، یک واترمارک به تصویر پس‌زمینهٔ حاصل اضافه کنم؟**

بله. می‌توانید یک شکل یا تصویر [واترمارک](/slides/fa/androidjava/watermark/) را بر روی یک [کپی کار](/slides/fa/androidjava/clone-slides/) از اسلاید (در پشت سایر محتوا) قرار دهید و سپس خروجی بگیرید. این کار به شما امکان می‌دهد تصویر پس‌زمینه‌ای با واترمارک تعبیه‌شده تولید کنید.

**آیا می‌توانم پس‌زمینهٔ یک چیدمان یا اسلاید اصلی خاص را بدون وابستگی به اسلاید موجود دریافت کنم؟**

بله. اسلاید اصلی یا چیدمان موردنظر را دسترسی پیدا کنید، آن را بر روی یک [اسلاید موقت](/slides/fa/androidjava/clone-slides/) با اندازهٔ موردنیاز اعمال کنید و سپس آن اسلاید را خروجی بگیرید تا پس‌زمینهٔ استخراج‌شده از آن چیدمان یا اسلاید اصلی به‌دست آید.

**آیا محدودیت‌های licence بر خروجی تصویر تأثیر می‌گذارد؟**

ویژگی‌های رندرینگ در هنگام داشتن یک [license معتبر](/slides/fa/androidjava/licensing/) به‌صورت کامل در دسترس هستند. در حالت ارزیابی، خروجی ممکن است شامل محدودیت‌هایی مانند واترمارک باشد. license را یک بار برای هر فرآیند قبل از اجرای خروجی‌های دسته‌ای فعال کنید.