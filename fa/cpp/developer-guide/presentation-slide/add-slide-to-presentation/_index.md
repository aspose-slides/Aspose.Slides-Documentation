---
title: افزودن اسلایدها به ارائه‌ها در C++
linktitle: افزودن اسلاید
type: docs
weight: 10
url: /fa/cpp/add-slide-to-presentation/
keywords:
- افزودن اسلاید
- ایجاد اسلاید
- اسلاید خالی
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به راحتی اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود با Aspose.Slides برای C++ اضافه کنید — درج اسلاید بی‌وقفه و کارآمد در عرض ثانیه‌ها."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد تا اسلایدها را به صورت برنامه‌نویسی به ارائه‌های PowerPoint اضافه کنید. یک ارائه شامل اسلایدهای Master/Layout و اسلایدهای معمولی است و اسلایدهای معمولی بر اساس یک اندیس صفر‑پایه مرتب می‌شوند. هر اسلاید یک شناسه یکتا دارد و فایل‌های ارائه بدون اسلاید توسط Aspose.Slides پشتیبانی نمی‌شوند.

این مقاله توضیح می‌دهد چگونه یک شیء `Presentation` ایجاد کنید، به مجموعه اسلایدهای آن دسترسی پیدا کنید، یک اسلاید خالی اضافه کنید، با اسلاید تازه اضافه شده کار کنید و ارائه به‌روزرسانی‌شده را ذخیره کنید. همچنین نکات مرتبطی مانند افزودن اسلایدها در موقعیت خاص، استفاده از Layoutها و درک اسلاید خالی موجود در یک ارائه تازه‌ساخته را پوشش می‌دهد.

## **افزودن اسلاید به یک ارائه**

قبل از بحث درباره افزودن اسلایدها به فایل‌های ارائه، بیایید چند نکته در مورد اسلایدها را بررسی کنیم. هر فایل ارائه PowerPoint شامل اسلایدهای Master / Layout و سایر اسلایدهای Normal است. این به این معنی است که یک فایل ارائه حداقل یک اسلاید دارد. مهم است بدانید که فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for C++ پشتیبانی نمی‌شوند. هر اسلاید یک Id یکتا دارد و تمام اسلایدهای Normal بر اساس یک اندیس صفر‑پایه مرتب می‌شوند. Aspose.Slides for C++ به توسعه‌دهندگان امکان می‌دهد اسلایدهای خالی را به ارائه خود اضافه کنند. برای افزودن اسلاید خالی به ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
- کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/) را با تنظیم یک مرجع به ویژگی Slides (مجموعه‌ای از اشیای Slide محتوایی) که توسط شیء Presentation ارائه شده است، نمونه‌سازی کنید.
- با فراخوانی متدهای AddEmptySlide که توسط شیء ISlideCollection ارائه شده‌اند، یک اسلاید خالی را به انتهای مجموعه اسلایدهای محتوا در ارائه اضافه کنید.
- کارهایی را با اسلاید خالی تازه اضافه‌شده انجام دهید.
- در نهایت، فایل ارائه را با استفاده از شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) نویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **پرسش‌های متداول**

**آیا می‌توانم یک اسلاید جدید را در موقعیت خاصی وارد کنم، نه فقط در انتها؟**

بله. کتابخانه از مجموعه‌های اسلاید و عملیات‌های [insert](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidecollection/insertclone/) پشتیبانی می‌کند، بنابراین می‌توانید اسلاید را در ایندکس مورد نیاز اضافه کنید نه فقط در انتها.

**آیا تم/استایل‌ها هنگام افزودن اسلاید بر پایه یک Layout حفظ می‌شوند؟**

بله. یک Layout قالب‌بندی را از Master خود به ارث می‌برد و اسلاید جدید از Layout انتخاب‌شده و Master مربوطه به ارث می‌برد.

**کدام اسلاید در یک ارائه «خالی» جدید قبل از افزودن اسلایدها وجود دارد؟**

یک ارائه تازه ساخته‌شده از پیش شامل یک اسلاید خالی با ایندکس صفر است. این نکته هنگام محاسبه ایندکس‌های درج مهم است.

**چگونه می‌توانم «Layout» مناسب برای یک اسلاید جدید را انتخاب کنم اگر Master گزینه‌های زیادی داشته باشد؟**

به طور کلی، [LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/layoutslide/) که ساختار مورد نیاز را داشته باشد (مانند [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidelayouttype/)) انتخاب کنید. اگر چنین Layoutی موجود نباشد، می‌توانید [به Master اضافه کنید](/slides/fa/cpp/slide-layout/) و سپس استفاده کنید.