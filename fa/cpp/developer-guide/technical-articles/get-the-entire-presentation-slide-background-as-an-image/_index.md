---
title: دریافت کل پس‌زمینه اسلاید از یک ارائه به‌صورت تصویر
linktitle: کل پس‌زمینه اسلاید
type: docs
weight: 95
url: /fa/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- پس‌زمینه اسلاید
- پس‌زمینه نهایی
- استخراج پس‌زمینه
- کل پس‌زمینه
- پس‌زمینه به تصویر
- پس‌زمینه PPT
- پس‌زمینه PPTX
- پس‌زمینه ODP
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "استخراج تمام پس‌زمینه‌های اسلاید به‌صورت تصاویر از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++، برای ساده‌سازی جریان‌های کاری بصری."
---
## **بررسی کلی**

در ارائه‌های PowerPoint، پس‌زمینهٔ اسلاید می‌تواند از چندین عنصر تشکیل شود، از جمله تصویر پس‌زمینهٔ اسلاید، تم ارائه، طرح رنگی، و اشیائی که بر روی اسلاید اصلی یا اسلاید چیدمان قرار گرفته‌اند.

این مقاله نشان می‌دهد چگونه می‌توان کل پس‌زمینهٔ اسلاید را به‌عنوان تصویر با استفاده از Aspose.Slides استخراج کرد. از آنجا که روش واحدی برای این کار وجود ندارد، رویکرد شامل کلون کردن اسلاید انتخاب‌شده به یک ارائه موقت، حذف اشکال اسلاید، و سپس تبدیل پس‌زمینهٔ اسلاید حاصل به تصویر می‌شود.

## **استخراج کل پس‌زمینهٔ اسلاید**

Aspose.Slides for C++ روش ساده‌ای برای استخراج کل پس‌زمینهٔ اسلاید ارائه نمی‌دهد، اما می‌توانید با دنبال کردن مراحل زیر این کار را انجام دهید:
1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید.
1. اندازهٔ اسلاید را از ارائه دریافت کنید.
1. یک اسلاید را انتخاب کنید.
1. یک ارائهٔ موقت ایجاد کنید.
1. اندازهٔ اسلاید یکسان را در ارائهٔ موقت تنظیم کنید.
1. اسلاید انتخاب‌شده را به ارائهٔ موقت کلون کنید.
1. اشکال‌های اسلاید کلون‌شده را حذف کنید.
1. اسلاید کلون‌شده را به تصویر تبدیل کنید.

کد زیر مثال استخراج کل پس‌زمینهٔ اسلاید ارائه را به‌عنوان تصویر نشان می‌دهد.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **سوالات متداول**

**آیا گرادیانت‌ها، بافت‌ها یا پرکردن‌های تصویری پیچیده از اسلاید مستر در تصویر پس‌زمینهٔ حاصل حفظ می‌شوند؟**

بله. Aspose.Slides پررنگ‌های گرادیان، تصویر و بافت تعریف‌شده بر روی اسلاید، چیدمان یا مستر را رندر می‌کند. اگر نیاز به جداسازی ظاهر از مسترهای ارث‌بری داشته باشید، [پس‌زمینهٔ اختصاصی تنظیم کنید](/slides/fa/cpp/presentation-background/) بر روی اسلاید فعلی قبل از صادر کردن.

**آیا می‌توانم قبل از ذخیرهٔ تصویر پس‌زمینه یک واترمارک اضافه کنم؟**

بله. می‌توانید [یک واترمارک](/slides/fa/cpp/watermark/) به‌صورت شکل یا تصویر بر روی یک [کپی کاری از اسلاید](/slides/fa/cpp/clone-slides/) (قرار گرفته پشت محتواهای دیگر) اضافه کنید و سپس صادر کنید. این امکان را می‌دهد تا تصویری پس‌زمینه‌ای با واترمارک تعبیه‌شده تولید کنید.

**آیا می‌توانم پس‌زمینهٔ یک چیدمان یا مستر خاص را بدون وابستگی به اسلاید موجود دریافت کنم؟**

بله. مستر یا چیدمان مورد نظر را دسترسی پیدا کنید، آن را بر روی یک [اسلاید موقت](/slides/fa/cpp/clone-slides/) با اندازهٔ مورد نیاز اعمال کنید و سپس آن اسلاید را صادر کنید تا پس‌زمینهٔ استخراج‌شده از آن چیدمان یا مستر به‌دست آید.

**آیا محدودیت‌های مجوزی وجود دارد که بر خروجی تصویر تأثیر بگذارد؟**

ویژگی‌های رندرینگ با یک [مجوز معتبر](/slides/fa/cpp/licensing/) به‌طور کامل در دسترس هستند. در حالت ارزیابی، ممکن است خروجی شامل محدودیت‌هایی مانند واترمارک باشد. مجوز را یک‌بار در هر فرآیند قبل از اجرای صادرات دسته‌ای فعال کنید.