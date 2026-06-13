---
title: دسترسی به اسلایدهای ارائه در PHP
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/php-java/access-slide-in-presentation/
keywords:
- دسترسی به اسلاید
- ایندکس اسلاید
- شناسه اسلاید
- موقعیت اسلاید
- تغییر موقعیت
- ویژگی‌های اسلاید
- شماره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java دسترسی و مدیریت کنید. با مثال‌های کد بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه می‌توان به اسلایدها در یک ارائه دسترسی پیدا کرد و آنها را مدیریت کرد با استفاده از Aspose.Slides. نشان می‌دهد چگونه اسلایدها را بر اساس ایندکس صفر مبنا از مجموعه اسلایدها بازیابی کرد و چگونه با استفاده از متد `getSlideById` به اسلایدی با شناسهٔ یکتا دسترسی پیدا کرد.

همچنین خواهید آموخت چگونه موقعیت یک اسلاید را با استفاده از متد `setSlideNumber` تغییر دهید و چگونه شمارهٔ شروع اسلاید برای یک ارائه را با متد `setFirstSlideNumber` تعریف کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگذاری کنید، به ارجاعات اسلاید دست یابید، ترتیب یا شماره‌گذاری اسلایدها را به‌روز کنید و ارائهٔ اصلاح‌شده را ذخیره نمایید.

## **دسترسی به اسلاید بر اساس ایندکس**

تمام اسلایدهای یک ارائه به صورت عددی بر اساس موقعیت اسلاید، از صفر آغاز می‌شوند. اسلاید اول از طریق ایندکس ۰ قابل دسترسی است؛ اسلاید دوم از طریق ایندکس ۱؛ و به همین ترتیب.

کلاس Presentation، که نمایانگر یک فایل ارائه است، تمام اسلایدها را به عنوان یک مجموعهٔ [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) (مجموعه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/)) ارائه می‌دهد. این کد PHP نشان می‌دهد چگونه از طریق ایندکس به یک اسلاید دسترسی پیدا کنید:

```php
  # یک شیء Presentation ایجاد می‌کند که یک فایل ارائه را نمایندگی می‌کند
  $pres = new Presentation("demo.pptx");
  try {
    # یک اسلاید را با استفاده از ایندکس اسلاید آن دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **دسترسی به اسلاید بر اساس شناسه**

هر اسلاید در یک ارائه دارای شناسهٔ یکتایی است. می‌توانید با استفاده از متد [getSlideById](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlideById-long-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ارائه می‌شود) به آن شناسه دسترسی داشته باشید. این کد PHP نشان می‌دهد چگونه یک شناسهٔ معتبر برای اسلاید فراهم کنید و از طریق متد [getSlideById](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlideById-long-) به آن اسلاید دسترسی پیدا کنید:

```php
  # یک شیء Presentation ایجاد می‌کند که یک فایل ارائه را نمایندگی می‌کند
  $pres = new Presentation("demo.pptx");
  try {
    # یک شناسه اسلاید دریافت می‌کند
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # از طریق شناسه آن به اسلاید دسترسی پیدا می‌کند
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **تغییر موقعیت اسلاید**

Aspose.Slides به شما اجازه می‌دهد موقعیت یک اسلاید را تغییر دهید. به عنوان مثال، می‌توانید تعیین کنید که اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید (که می‌خواهید موقعیت آن را تغییر دهید) را از طریق ایندکس آن دریافت کنید.
1. موقعیت جدیدی برای اسلاید از طریق متد [setSlideNumber](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#setSlideNumber) تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد PHP عملیاتی را نشان می‌دهد که در آن اسلاید در موقعیت ۱ به موقعیت ۲ منتقل می‌شود:

```php
  # یک شیء Presentation ایجاد می‌کند که یک فایل ارائه را نمایندگی می‌کند
  $pres = new Presentation("Presentation.pptx");
  try {
    # اسلایدی که موقعیت آن تغییر خواهد کرد را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # موقعیت جدید را برای اسلاید تنظیم می‌کند
    $sld->setSlideNumber(2);
    # ارائهٔ اصلاح‌شده را ذخیره می‌کند
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

اسلاید اول تبدیل به اسلاید دوم شد؛ اسلاید دوم تبدیل به اسلاید اول شد. هنگامی که موقعیت یک اسلاید را تغییر می‌دهید، سایر اسلایدها به‌صورت خودکار تنظیم می‌شوند.

## **تنظیم شماره اسلاید**

با استفاده از متد [setFirstSlideNumber](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ارائه می‌شود)، می‌توانید شمارهٔ جدیدی برای اسلاید اول در یک ارائه تعریف کنید. این عملیات باعث بازمحاسبهٔ شماره‌های دیگر اسلایدها می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. شمارهٔ اسلاید را دریافت کنید.
1. شمارهٔ اسلاید را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد PHP عملیاتی را نشان می‌دهد که در آن شمارهٔ اسلاید اول برابر با ۱۰ تنظیم می‌شود:

```php
  # یک شیء Presentation ایجاد می‌کند که یک فایل ارائه را نمایندگی می‌کند
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # شماره اسلاید را دریافت می‌کند
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # شماره اسلاید را تنظیم می‌کند
    $pres->setFirstSlideNumber(10);
    # ارائهٔ اصلاح‌شده را ذخیره می‌کند
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

اگر مایل باشید اسلاید اول را نادیده بگیرید، می‌توانید شماره‌گذاری را از اسلاید دوم آغاز کنید (و شماره‌گذاری اسلاید اول را مخفی کنید) به این شکل:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # شماره اسلاید اول ارائه را تنظیم می‌کند
    $presentation->setFirstSlideNumber(0);
    # نمایش شماره اسلاید برای تمام اسلایدها
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # مخفی کردن شماره اسلاید برای اسلاید اول
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # ارائهٔ اصلاح‌شده را ذخیره می‌کند
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **سؤالات متداول**

**آیا شمارهٔ اسلایدی که کاربر می‌بیند با ایندکس صفر مبنی مجموعه مطابقت دارد؟**

عدد نمایش داده شده روی اسلاید می‌تواند از مقدار دلخواهی (مثلاً ۱۰) شروع شود و لزوماً با ایندکس برابر نیست؛ این رابطه توسط تنظیم [first slide number](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/setfirstslidenumber/) ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر ایندکس‌بندی تأثیر می‌گذارند؟**

بله. یک اسلاید مخفی همچنان در مجموعه باقی می‌ماند و در ایندکس‌بندی حساب می‌شود؛ «مخفی» به نمایش اشاره دارد، نه به موقعیت آن در مجموعه.

**آیا ایندکس یک اسلاید هنگام افزودن یا حذف اسلایدهای دیگر تغییر می‌کند؟**

بله. ایندکس‌ها همیشه ترتیب فعلی اسلایدها را نشان می‌دهند و هنگام عملیات درج، حذف و جابه‌جایی دوباره محاسبه می‌شوند.