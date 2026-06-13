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
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدهای PowerPoint را به سرعت با Aspose.Slides برای PHP تکثیر کنید. با مثال‌های کد واضح ما، ایجاد فایل‌های PPT را در چند ثانیه خودکار کنید و کارهای دستی را حذف کنید."
---
## **معرفی**

کلون کردن فرآیندی است که یک کپی دقیق یا نسخه‌ای مشابه از چیزی ایجاد می‌کند. Aspose.Slides for PHP via Java همچنین امکان ایجاد یک کپی یا کلون از هر اسلایدی و سپس وارد کردن آن اسلاید کلون‌شده به ارائهٔ فعلی یا هر ارائه باز دیگری را فراهم می‌کند. فرآیند کلون‌سازی اسلاید، اسلاید جدیدی ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی، اصلاح شود. چندین روش ممکن برای کلون‌سازی یک اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگر داخل ارائه.
- کلون در انتهای یک ارائه دیگر.
- کلون در موقعیت دیگر در یک ارائه دیگر.
- کلون در موقعیت مشخصی در یک ارائه دیگر.

در Aspose.Slides for PHP via Java، (یک مجموعه از اشیای [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Slide)) که توسط شیء [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) نمایان می‌شود، متدهای [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) و [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) را برای انجام انواع کلون‌سازی اسلاید فوق ارائه می‌کند.

## **کلون یک اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائهٔ موجود در انتهای اسلایدهای فعلی استفاده کنید، متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را طبق مراحل زیر به کار ببرید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) را با ارجاع به مجموعه اسلایدهای ارائه که توسط شیء [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) باز می‌شود دریافت کنید.  
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلاید مورد نظر برای کلون را به عنوان پارامتر به متد [addClone] پاس دهید.  
1. فایل ارائهٔ تغییر یافته را بنویسید.

در مثال زیر، ما اسلایدی (که در اولین موقعیت – اندیس صفر – ارائه قرار داشت) را به انتهای ارائه کلون کرده‌ایم.

```php
  # ایجاد یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # کلون اسلاید مورد نظر به انتهای مجموعه اسلایدها در همان ارائه
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # نوشتن ارائهٔ تغییر یافته به دیسک
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **کلون یک اسلاید به موقعیت دیگری داخل همان ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در موقعیتی متفاوت استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) استفاده کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection) را با ارجاع به مجموعه [اسلایدها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) که توسط شیء [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) باز می‌شود دریافت کنید.  
1. متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلاید مورد نظر برای کلون به همراه اندیس موقعیت جدید را به عنوان پارامتر به متد [insertClone] پاس دهید.  
1. ارائهٔ تغییر یافته را به قالب PPTX بنویسید.

در مثال زیر، ما اسلایدی (که در اندیس صفر – موقعیت 1 – ارائه قرار داشت) را به اندیس 1 – موقعیت 2 – ارائه منتقل کرده‌ایم.

```php
  # ایجاد یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # کلون اسلاید مورد نظر به انتهای مجموعه اسلایدها در همان ارائه
    $slds = $pres->getSlides();
    # کلون اسلاید مورد نظر به اندیس مشخص شده در همان ارائه
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # نوشتن ارائهٔ تغییر یافته به دیسک
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **کلون یک اسلاید در انتهای یک ارائهٔ دیگر**
اگر می‌خواهید اسلایدی را از یک ارائه کلون کرده و در انتهای اسلایدهای یک ارائهٔ دیگر قرار دهید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه منبع است، ایجاد کنید.  
1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه مقصد است، ایجاد کنید.  
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection) را با ارجاع به مجموعه [اسلایدها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه مقصد دریافت کنید.  
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه مقصد ارائه می‌شود فراخوانی کنید و اسلاید منبع را به عنوان پارامتر به این متد پاس دهید.  
1. فایل ارائهٔ مقصد را بنویسید.

در مثال زیر، ما اسلایدی (از اولین اندیس ارائه منبع) را به انتهای ارائهٔ مقصد کلون کرده‌ایم.

```php
  # ایجاد یک شیء از کلاس Presentation برای بارگذاری فایل ارائه منبع
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # ایجاد یک شیء از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    $destPres = new Presentation();
    try {
      # کلون اسلاید مورد نظر از ارائه منبع به انتهای مجموعه اسلایدهای ارائه مقصد
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # نوشتن ارائهٔ مقصد به دیسک
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **کلون یک اسلاید به موقعیت دیگری در یک ارائهٔ دیگر**
اگر می‌خواهید اسلایدی را از یک ارائه کلون کرده و در موقعیتی مشخص در ارائهٔ دیگری قرار دهید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه منبع است، ایجاد کنید.  
1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه مقصد است، ایجاد کنید.  
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) را با ارجاع به مجموعه اسلایدهای ارائه مقصد دریافت کنید.  
1. متد [insertClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#insertClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه مقصد ارائه می‌شود فراخوانی کنید و اسلاید منبع به همراه موقعیت دلخواه را به عنوان پارامتر به این متد پاس دهید.  
1. فایل ارائهٔ مقصد را بنویسید.

در مثال زیر، ما اسلایدی (از اندیس صفر ارائه منبع) را به اندیس 1 (موقعیت 2) ارائهٔ مقصد کلون کرده‌ایم.

```php
  # ایجاد یک شیء از کلاس Presentation برای بارگذاری فایل ارائه منبع
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # ایجاد یک شیء از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    $destPres = new Presentation();
    try {
      # کلون اسلاید مورد نظر از ارائه منبع به انتهای مجموعه اسلایدهای ارائه مقصد
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # نوشتن ارائه مقصد به دیسک
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **کلون یک اسلاید در موقعیت مشخصی در یک ارائهٔ دیگر**
اگر می‌خواهید اسلایدی همراه با اسلاید اصلی (master) را از یک ارائه کلون کرده و در ارائهٔ دیگری استفاده کنید، ابتدا باید اسلاید اصلی موردنظر را از ارائه منبع به ارائه مقصد کلون کنید. سپس برای کلون اسلاید با اسلاید اصلی، متد [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) یک اسلاید اصلی از ارائه مقصد را می‌طلبد، نه از منبع. برای کلون اسلاید با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه منبع است، ایجاد کنید.  
1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که شامل ارائه مقصد است، ایجاد کنید.  
1. به اسلایدی که می‌خواهید کلون کنید به همراه اسلاید اصلی آن دسترسی پیدا کنید.  
1. شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterSlideCollection) را با ارجاع به مجموعه Masters ارائه مقصد ایجاد کنید.  
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterSlideCollection) ارائه می‌شود فراخوانی کنید و اسلاید اصلی منبع را به عنوان پارامتر به این متد پاس دهید.  
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) را با ارجاع به مجموعه اسلایدهای ارائه مقصد تنظیم کنید.  
1. متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSlides) ارائه می‌شود فراخوانی کنید و اسلاید منبع همراه با اسلاید اصلی را به عنوان پارامتر به این متد پاس دهید.  
1. فایل ارائهٔ مقصد را بنویسید.

در مثال زیر، ما اسلایدی همراه با اسلاید اصلی (که در اندیس صفر ارائه منبع قرار داشت) را با استفاده از اسلاید اصلی منبع به انتهای ارائهٔ مقصد کلون کرده‌ایم.

```php
  # ایجاد یک شیء از کلاس Presentation برای بارگذاری فایل ارائه منبع
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # ایجاد یک شیء از کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    $destPres = new Presentation();
    try {
      # ایجاد یک شیء ISlide از مجموعه اسلایدها در ارائه منبع همراه با
      # اسلاید اصلی
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعه اسلایدهای اصلی در
      # ارائه مقصد
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعه اسلایدهای اصلی در
      # ارائه مقصد
      $iSlide = $masters->addClone($SourceMaster);
      # کلون اسلاید موردنظر از ارائه منبع با اسلاید اصلی موردنظر به انتهای
      # مجموعه اسلایدها در ارائه مقصد
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # ذخیرهٔ ارائه مقصد به دیسک
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **کلون یک اسلاید در انتهای یک بخش مشخص**
اگر می‌خواهید اسلایدی را کلون کنید و سپس در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، از متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection/#addClone) که توسط کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideCollection) ارائه می‌شود استفاده کنید. Aspose.Slides for PHP via Java امکان کلون یک اسلاید از اولین بخش و سپس درج آن اسلاید کلون‌شده در بخش دوم همان ارائه را فراهم می‌کند.

کد نمونه زیر نشان می‌دهد چگونه اسلایدی را کلون کنید و اسلاید کلون‌شده را در یک بخش مشخص وارد کنید.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # ذخیرهٔ ارائه مقصد به دیسک
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر نیز کلون می‌شوند؟**

بله. صفحهٔ یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج آن‌ها را[remove them](/slides/fa/php-java/presentation-notes/) کنید.

**نمودارها و منابع داده‌ای آنها چگونه مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های داخلی کپی می‌شوند. اگر نمودار به منبع خارجی (مانند یک کتاب‌کار OLE‑embedded) پیوند داشته باشد، این پیوند به عنوان یک [OLE object](/slides/fa/php-java/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در یک اندیس اسلاید خاص درج کنید و آن را به یک [section](/slides/fa/php-java/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن بخش منتقل کنید.