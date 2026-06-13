---
title: ادغام مؤثر ارائه‌ها در PHP
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/php-java/merge-presentation/
keywords:
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- PHP
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را با Aspose.Slides برای PHP از طریق Java ترکیب کنید و جریان کاری خود را ساده‌سازی کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا ارائه‌ها را با کپی کردن اسلایدها از یک ارائه به ارائه دیگر ترکیب کنید. این مقاله توضیح می‌دهد که چگونه می‌توانید کل ارائه‌ها یا اسلایدهای انتخابی را ادغام کنید، از یک اسلاید مستر یا طرح‌بندی خاص در حین ادغام استفاده کنید، ارائه‌های با اندازه اسلاید متفاوت را مدیریت کنید، و اسلایدهای ادغام‌شده را به یک بخش از ارائه اضافه کنید. همچنین نکات عملی مربوط به محتوای ادغام‌شده، از جمله یادداشت‌های گوینده، نظرات، فایل‌های منبع دارای گذرواژه، و استفاده از نخ‌ها را پوشش می‌دهد.

## **ادغام ارائه‌ها**

هنگامی که یک ارائه را به ارائه دیگری ادغام می‌کنید، عملاً اسلایدهای آن‌ها را در یک ارائه ترکیب می‌کنید تا یک فایل به دست آید.

{{% alert title="اطلاعات" color="info" %}}

بیشتر برنامه‌های ارائه (PowerPoint یا OpenOffice) قابلیت‌هایی برای ترکیب ارائه‌ها به این شکل ندارند.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/fa/php-java/) به شما امکان می‌دهد تا ارائه‌ها را به روش‌های مختلف ترکیب کنید. می‌توانید ارائه‌ها را همراه با تمام اشکال، سبک‌ها، متن‌ها، قالب‌بندی‌ها، نظرات، انیمیشن‌ها و غیره ادغام کنید بدون نگرانی از دست رفتن کیفیت یا داده.

**همچنین ببینید**

[کپی اسلایدها](/slides/fa/php-java/clone-slides/).

{{% /alert %}}

### **چه چیزهایی می‌تواند ادغام شود**

با Aspose.Slides می‌توانید

* کل ارائه‌ها را ادغام کنید. تمام اسلایدهای ارائه‌ها در یک ارائه جمع می‌شوند
* اسلایدهای مشخصی را ادغام کنید. اسلایدهای انتخابی در یک ارائه جمع می‌شوند
* ارائه‌ها را در یک فرمت (PPT به PPT، PPTX به PPTX و غیره) و در فرمت‌های مختلف (PPT به PPTX، PPTX به ODP و غیره) به همدیگر متصل کنید.

{{% alert title="توجه" color="warning" %}} 

علاوه بر ارائه‌ها، Aspose.Slides به شما اجازه می‌دهد تا فایل‌های دیگر را نیز ادغام کنید:

* [تصاویر](https://products.aspose.com/slides/fa/php-java/merger/image-to-image/)، مانند [JPG به JPG](https://products.aspose.com/slides/fa/php-java/merger/jpg-to-jpg/) یا [PNG به PNG](https://products.aspose.com/slides/fa/php-java/merger/png-to-png/)
* اسناد، مانند [PDF به PDF](https://products.aspose.com/slides/fa/php-java/merger/pdf-to-pdf/) یا [HTML به HTML](https://products.aspose.com/slides/fa/php-java/merger/html-to-html/)
* و دو فایل متفاوت مانند [تصویر به PDF](https://products.aspose.com/slides/fa/php-java/merger/image-to-pdf/) یا [JPG به PDF](https://products.aspose.com/slides/fa/php-java/merger/jpg-to-pdf/) یا [TIFF به PDF](https://products.aspose.com/slides/fa/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **گزینه‌های ادغام**

می‌توانید گزینه‌هایی اعمال کنید که تعیین می‌کنند:

* هر اسلاید در ارائه خروجی یک سبک منحصر به فرد نگه دارد
* یک سبک خاص برای تمام اسلایدهای ارائه خروجی استفاده شود.

برای ادغام ارائه‌ها، Aspose.Slides متدهای [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) (از کلاس [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/)) را فراهم می‌کند. چندین پیاده‌سازی از متدهای `addClone` وجود دارد که پارامترهای فرایند ادغام ارائه را تعریف می‌کند. هر شیء Presentation دارای مجموعه‌ای از [slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getslides/) است، بنابراین می‌توانید از ارائه‌ای که می‌خواهید اسلایدها را به آن ادغام کنید، متد `addClone` را فراخوانی کنید.

متد `addClone` یک شیء `Slide` برمی‌گرداند که نسخه‌ای کپی از اسلاید منبع است. اسلایدهای موجود در ارائه خروجی صرفاً کپی‌ای از اسلایدهای منبع هستند. بنابراین می‌توانید تغییراتی بر روی اسلایدهای حاصل (مثلاً اعمال سبک یا گزینه‌های قالب‌بندی یا طرح‌بندی) انجام دهید بدون اینکه نگران تأثیر بر روی ارائه‌های منبع باشید.

## **ادغام ارائه‌ها**

Aspose.Slides متد [addClone(Slide)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) را ارائه می‌دهد که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که اسلایدها طرح‌بندی و سبک‌های خود را حفظ می‌کنند (پارامترهای پیش‌فرض).

این کد PHP نشان می‌دهد که چگونه می‌توانید ارائه‌ها را ادغام کنید:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **ادغام ارائه‌ها با اسلاید مستر**

Aspose.Slides متد [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) را فراهم می‌کند که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که یک قالب اسلاید مستر را اعمال می‌کنید. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

این کد عملیات توصیف‌شده را نشان می‌دهد:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="توجه" color="warning" %}} 

طرح‌بندی اسلاید برای اسلاید مستر به صورت خودکار تعیین می‌شود. وقتی که یک طرح‌بندی مناسب نتواند تعیین شود، اگر پارامتر boolean `allowCloneMissingLayout` متد `addClone` برابر `true` باشد، طرح‌بندی اسلاید منبع استفاده می‌شود. در غیر این‌صورت، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PptxEditException) پرتاب می‌شود.

{{% /alert %}}

اگر می‌خواهید اسلایدهای ارائه خروجی دارای طرح‌بندی متفاوتی باشند، هنگام ادغام از متد [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) استفاده کنید.

## **ادغام اسلایدهای خاص از ارائه‌ها**

ادغام اسلایدهای خاص از چندین ارائه برای ایجاد مجموعه‌های سفارشی اسلاید مفید است. Aspose.Slides for PHP via Java به شما اجازه می‌دهد فقط اسلایدهای مورد نیاز را انتخاب و وارد کنید. API قالب‌بندی، طرح‌بندی و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد PHP زیر یک ارائه جدید ایجاد می‌کند، اسلایدهای عنوان را از دو ارائه دیگر اضافه می‌کند و نتیجه را در یک فایل ذخیره می‌نماید:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **ادغام ارائه‌ها با طرح‌بندی اسلاید**

این کد PHP نشان می‌دهد که چگونه می‌توانید اسلایدها را از ارائه‌ها ترکیب کنید در حالی که طرح‌بندی دلخواه خود را بر روی آن‌ها اعمال می‌کنید تا یک ارائه خروجی دریافت کنید:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **ادغام ارائه‌ها با اندازه اسلاید متفاوت**

{{% alert title="توجه" color="warning" %}} 

شما نمی‌توانید ارائه‌هایی با اندازه اسلاید متفاوت را ادغام کنید.

{{% /alert %}}

برای ادغام ۲ ارائه با اندازه اسلاید متفاوت، باید یکی از ارائه‌ها را طوری تغییر اندازه دهید که اندازه آن با ارائه دیگر منطبق شود.

این کد نمونه عملیات توصیف‌شده را نشان می‌دهد:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **ادغام اسلایدها به بخش یک ارائه**

این کد PHP نشان می‌دهد که چگونه می‌توانید یک اسلاید خاص را به یک بخش در ارائه اضافه کنید:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

اسلاید در انتهای بخش افزوده می‌شود.

## **موارد مرتبط**

Aspose یک [ابزار ساخت کلاژ آنلاین رایگان](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ادغام کنید، [شبکه‌های تصویری](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و موارد دیگری نیز انجام دهید.

به [ادغام‌کننده رایگان آنلاین Aspose](https://products.aspose.app/slides/fa/merger) نگاهی بیندازید. این سرویس به شما امکان می‌دهد ارائه‌های PowerPoint را در همان فرمت (مثلاً PPT به PPT، PPTX به PPTX) یا در فرمت‌های مختلف (مثلاً PPT به PPTX، PPTX به ODP) ادغام کنید.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/fa/merger)

## **سؤالات متداول**

**آیا محدودیتی برای تعداد اسلایدها هنگام ادغام ارائه‌ها وجود دارد؟**

محدودیت سخت‌گیری وجود ندارد. Aspose.Slides می‌تواند فایل‌های بزرگ را مدیریت کند، اما عملکرد به اندازه فایل و منابع سیستم بستگی دارد. برای ارائه‌های بسیار بزرگ توصیه می‌شود از JVM ۶۴ بیتی استفاده کرده و حافظه heap کافی تخصیص دهید.

**آیا می‌توانم ارائه‌ها را با ویدیو یا صداهای جاسازی‌شده ادغام کنم؟**

بله، Aspose.Slides محتوای چندرسانه‌ای جاسازی‌شده در اسلایدها را حفظ می‌کند، اما ممکن است اندازه نهایی ارائه به‌ طور قابل‌ توجهی بزرگ‌تر شود.

**آیا قلم‌ها هنگام ادغام ارائه‌ها حفظ می‌شوند؟**

بله. قلم‌های استفاده‌شده در ارائه‌های منبع در فایل خروجی حفظ می‌شوند، به شرط آنکه روی سیستم نصب شده باشند یا [جاسازی شده](/slides/fa/php-java/embedded-font/).