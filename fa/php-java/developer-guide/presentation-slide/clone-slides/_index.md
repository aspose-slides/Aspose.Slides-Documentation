---
title: کلون اسلایدهای ارائه در PHP
linktitle: کلون اسلایدها
type: docs
weight: 35
url: /fa/php-java/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای PHP تکثیر کنید. مثال‌های کد واضح ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید و کار دستی را حذف کنید."
---
## **مقدمه**

کلون‌سازی فرآیند ساخت یک کپی دقیق یا نسخه‌ای مشابه از چیزی است. Aspose.Slides for PHP via Java همچنین امکان ساخت یک کپی یا کلون از هر اسلایدی و سپس درج آن اسلاید کلون‌شده به ارائه‌ی جاری یا هر ارائه‌ی دیگری که باز باشد را فراهم می‌کند. فرآیند کلون‌سازی اسلاید یک اسلاید جدید ایجاد می‌کند که می‌توان آن را توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی اصلاح کرد. چندین روش ممکن برای کلون‌کردن یک اسلاید وجود دارد:

- کلون در انتها داخل یک ارائه.
- کلون در موقعیت دیگری داخل ارائه.
- کلون در انتها در یک ارائه دیگر.
- کلون در موقعیت دیگری در یک ارائه دیگر.
- کلون در موقعیت خاصی در یک ارائه دیگر.

در Aspose.Slides for PHP via Java، (مجموعه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Slide) ) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) آشکار می‌شود، متدهای [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) و [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) را برای انجام انواع کلون‌سازی اسلاید فوق ارائه می‌دهد.

## **کلون یک اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه، در انتهای اسلایدهای موجود استفاده کنید، بر اساس مراحل زیر از متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) را با ارجاع به مجموعه اسلایدهای ارائه‌ای که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ارائه می‌شود، دریافت کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود، فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) پاس دهید.
1. فایل ارائه‌ی تغییر یافته را بنویسید.

در مثال زیر، یک اسلاید (در موقعیت اول – شاخص صفر – ارائه) را تا انتهای ارائه کلون کرده‌ایم.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # اسلاید موردنظر را به انتهای مجموعه اسلایدها در همان ارائه کلون کنید
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # ارائه تغییر یافته را روی دیسک ذخیره کنید
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **کلون یک اسلاید به موقعیت دیگری داخل یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection) را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ارائه می‌شود، دریافت کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلایدی که باید کلون شود همراه با شاخص موقعیت جدید را به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) پاس دهید.
1. فایل ارائه‌ی تغییر یافته را به صورت PPTX بنویسید.

در مثال زیر، یک اسلاید (در شاخص صفر – موقعیت 1 – ارائه) را به شاخص 1 – موقعیت 2 – ارائه کلون کرده‌ایم.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # اسلاید موردنظر را به انتهای مجموعه اسلایدها در همان ارائه کلون کنید
    $slds = $pres->getSlides();
    # اسلاید موردنظر را به شاخص مشخص شده در همان ارائه کلون کنید
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # ارائه تغییر یافته را روی دیسک ذخیره کنید
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **کلون یک اسلاید در انتهای یک ارائه دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در فایل ارائه دیگری، در انتهای اسلایدهای موجود استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه مقصدی است که اسلاید به آن اضافه می‌شود، ایجاد کنید.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection) را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) که توسط شیء Presentation ارائه مقصد ارائه می‌شود، دریافت کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلاید از ارائه منبع را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) پاس دهید.
1. فایل ارائه مقصد تغییر یافته را بنویسید.

در مثال زیر، یک اسلاید (از شاخص اول ارائه منبع) را به انتهای ارائه مقصد کلون کرده‌ایم.

```php
  # نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    $destPres = new Presentation();
    try {
      # کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # ارائه مقصد را روی دیسک ذخیره کنید
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **کلون یک اسلاید به موقعیت دیگری در یک ارائه دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در فایل ارائه دیگری در موقعیت خاصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه منبع است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه‌ای است که اسلاید به آن اضافه می‌شود، ایجاد کنید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائه مقصد ارائه می‌شود، دریافت کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلاید از ارائه منبع همراه با موقعیت مورد نظر را به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) پاس دهید.
1. فایل ارائه مقصد تغییر یافته را بنویسید.

در مثال زیر، یک اسلاید (از شاخص صفر ارائه منبع) را به شاخص 1 (موقعیت 2) ارائه مقصد کلون کرده‌ایم.

```php
  # نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    $destPres = new Presentation();
    try {
      # کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # ذخیره ارائه مقصد بر روی دیسک
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **کلون یک اسلاید در موقعیت خاصی در یک ارائه دیگر**
اگر نیاز دارید یک اسلاید همراه با اسلاید مستر را از یک ارائه کلون کنید و در ارائه دیگری استفاده کنید، ابتدا باید اسلاید مستر مورد نظر را از ارائه منبع به ارائه مقصد کلون کنید. سپس باید از آن اسلاید مستر برای کلون کردن اسلاید با مستر استفاده کنید. متد [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) یک اسلاید مستر از ارائه مقصد را به‌جای ارائه منبع انتظار دارد. برای کلون کردن اسلاید با مستر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه منبع است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه مقصد است که اسلاید به آن کلون می‌شود، ایجاد کنید.
1. به اسلایدی که باید کلون شود همراه با اسلاید مستر دسترسی پیدا کنید.
1. کلاس [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ارائه مقصد ارائه می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterSlideCollection) ارائه می‌شود فراخوانی کنید و مستری که از PPTX منبع باید کلون شود را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) پاس دهید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) را با تنظیم ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ارائه مقصد ارائه می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلایدی که از ارائه منبع باید کلون شود همراه با اسلاید مستر را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) پاس دهید.
1. فایل ارائه مقصد تغییر یافته را بنویسید.

در مثال زیر، یک اسلاید همراه با مستر (در شاخص صفر ارائه منبع) را به انتهای ارائه مقصد با استفاده از مستر اسلاید منبع کلون کرده‌ایم.

```php
  # ایجاد نمونه کلاس Presentation برای بارگذاری فایل ارائه منبع
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # ایجاد نمونه کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    $destPres = new Presentation();
    try {
      # ایجاد ISlide از مجموعه اسلایدها در ارائه منبع همراه با
      # اسلاید مستر
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # کلون اسلاید مستر موردنظر از ارائه منبع به مجموعه مسترها در
      # ارائه مقصد
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # کلون اسلاید مستر موردنظر از ارائه منبع به مجموعه مسترها در
      # ارائه مقصد
      $iSlide = $masters->addClone($SourceMaster);
      # کلون اسلاید موردنظر از ارائه منبع با مستر موردنظر به انتهای
      # مجموعه اسلایدها در ارائه مقصد
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # ذخیره ارائه مقصد بر روی دیسک
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **کلون یک اسلاید در انتهای یک بخش مشخص**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، از متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) که توسط کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection) ارائه می‌شود استفاده کنید. Aspose.Slides for PHP via Java امکان کلون کردن اسلایدی از بخش اول و سپس درج آن اسلاید کلون‌شده در بخش دوم همان ارائه را فراهم می‌کند.

کد زیر نشان می‌دهد چگونه یک اسلاید را کلون کنید و اسلاید کلون‌شده را در یک بخش مشخص درج کنید.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # ذخیرهٔ ارائه مقصد بر روی دیسک
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **اطمینان از سازگاری اندازه اسلاید**

هنگام کلون کردن اسلایدها به یک ارائه دیگر، اطمینان حاصل کنید که اندازه اسلاید ارائه مقصد با ارائه منبع یکسان باشد. اگر اندازه اسلایدها متفاوت باشد، Aspose.Slides به‌صورت خودکار اشکال کلون‌شده را بازسازی نمی‌کند—مختصات و ابعاد اصلی آن‌ها حفظ می‌شود، که ممکن است منجر به عدم هم‌راستایی محتوا یا خروج آن از مرزهای اسلاید شود.

می‌توانید قبل از کلون کردن مستر و اسلاید، اندازه اسلاید ارائه مقصد را به اندازه منبع تنظیم کنید:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

این کار را قبل از کلون کردن مستر و اسلاید انجام دهید.

## **FAQ**

**آیا یادداشت‌های گوینده و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر آن‌ها را نمی‌خواهید، پس از درج [آن‌ها را حذف کنید](/slides/fa/php-java/presentation-notes/).

**چگونه نمودارها و منابع داده آن‌ها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های داخلی کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE‑embedded) پیوند داده شده باشد، آن پیوند به‌عنوان یک [OLE object](/slides/fa/php-java/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، دسترسی به داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در یک شاخص اسلاید خاص درج کنید و در یک [section](/slides/fa/php-java/slide-section/) انتخابی قرار دهید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن انتقال دهید.