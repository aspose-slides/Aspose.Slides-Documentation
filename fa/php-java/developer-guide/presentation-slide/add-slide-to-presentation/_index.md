---
title: "افزودن اسلایدها به ارائه‌ها در PHP"
linktitle: "افزودن اسلاید"
type: docs
weight: 10
url: /fa/php-java/add-slide-to-presentation/
keywords:
  - "افزودن اسلاید"
  - "ایجاد اسلاید"
  - "اسلاید خالی"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "PHP"
  - "Aspose.Slides"
description: "به راحتی اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود با استفاده از Aspose.Slides for PHP via Java اضافه کنید — درج اسلاید بدون درز و کارآمد در عرض چند ثانیه."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد اسلایدها را به ارائه‌های PowerPoint به‌صورت برنامه‌نویسی اضافه کنید. یک ارائه شامل اسلایدهای **Master / Layout** و اسلایدهای **Normal** است و اسلایدهای عادی بر اساس یک اندیس مبتنی بر صفر مرتب می‌شوند. هر اسلاید یک شناسه منحصر به‌فرد دارد و پرونده‌های ارائه بدون اسلاید پشتیبانی نمی‌شوند.

این مقاله نحوه‌ی ایجاد شیء `Presentation`، دسترسی به مجموعه اسلایدهای آن، افزودن یک اسلاید خالی، کار با اسلاید تازه اضافه‌شده و ذخیره‌ی ارائه‌ی به‌روز شده را توضیح می‌دهد. همچنین نکات مرتبطی مانند درج اسلاید در موقعیت خاص، استفاده از لایه‌ها و درک اسلاید خالی موجود در یک ارائه‌ی تازه ایجاد شده را پوشش می‌دهد.

## **افزودن اسلاید به یک ارائه**

قبل از صحبت در مورد افزودن اسلایدها به فایل‌های ارائه، برخی نکات درباره اسلایدها را بررسی می‌کنیم. هر فایل ارائه PowerPoint شامل اسلاید **Master / Layout** و سایر اسلایدهای **Normal** است. این به این معناست که یک فایل ارائه حداقل یک اسلاید یا بیشتر دارد. مهم است بدانید که فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for PHP via Java پشتیبانی نمی‌شوند. هر اسلاید یک Id منحصر به‌فرد دارد و تمام اسلایدهای Normal بر اساس یک اندیس مبتنی بر صفر مرتب می‌شوند.

Aspose.Slides for PHP via Java به توسعه‌دهندگان اجازه می‌دهد اسلایدهای خالی به ارائه خود اضافه کنند. برای افزودن یک اسلاید خالی در ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
- شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) را با استفاده از متد [getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#getSlides--) (مجموعه‌ای از اشیاء Slide محتوا) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) در دسترس است، دریافت کنید.
- با فراخوانی متد [**addEmptySlide**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/#addEmptySlide) که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) ارائه می‌شود، یک اسلاید خالی به انتهای مجموعه اسلایدهای محتوا اضافه کنید.
- برخی کارها را با اسلاید خالی تازه اضافه‌شده انجام دهید.
- در نهایت، فایل ارائه را با استفاده از شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) بنویسید.

```php
  # اینستنس‌سازی کلاس Presentation که نمایانگر فایل ارائه است
  $pres = new Presentation();
  try {
    # اینستنس‌سازی کلاس SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # افزودن یک اسلاید خالی به مجموعه Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # انجام برخی کارها بر روی اسلاید تازه افزوده‌شده
    # ذخیره کردن فایل PPTX روی دیسک
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **پرسش‌های متداول**

**آیا می‌توانم اسلاید جدیدی را در موقعیت خاصی وارد کنم، نه فقط در انتها؟**

بله. کتابخانه از مجموعه اسلایدها و عملیات‌های [insert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/insertclone/) پشتیبانی می‌کند، بنابراین می‌توانید اسلاید را در شاخص مورد نیاز اضافه کنید نه فقط در انتها.

**آیا تم/استایل‌ها هنگام افزودن اسلاید بر پایه یک لایه حفظ می‌شوند؟**

بله. یک لایه قالب‌بندی را از مستر خود به ارث می‌برد و اسلاید جدید نیز از لایه انتخاب‌شده و مستر مرتبط با آن ارث می‌برد.

**کدام اسلاید در یک ارائه «خالی» جدید قبل از افزودن اسلایدها موجود است؟**

یک ارائه تازه ایجاد شده از پیش شامل یک اسلاید خالی با اندیس صفر است. این نکته هنگام محاسبه اندیس‌های درج مهم است.

**چگونه می‌توانم «لایه مناسب» را برای اسلاید جدید انتخاب کنم اگر مستر گزینه‌های زیادی دارد؟**

به‌طور کلی لایه‌ی [LayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) که ساختار مورد نیاز (مانند [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidelayouttype/)) را دارد انتخاب کنید. اگر چنین لایه‌ای موجود نیست، می‌توانید آن را به مستر [add it to the master](/slides/fa/php-java/slide-layout/) اضافه کنید و سپس از آن استفاده کنید.