---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در PHP
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/php-java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- توزیع
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "از Aspose.Slides برای PHP از طریق Java استفاده کنید تا سرصفحه‌ها و پاورقی‌های ارائه‌های PowerPoint و OpenDocument را اضافه و سفارشی‌سازی کنید و ظاهری حرفه‌ای به دست آورید."
---
## **مرور کلی**

Aspose.Slides به شما اجازه می‌دهد تنظیمات سرصفحه و پاورقی را در ارائه‌های PowerPoint مدیریت کنید. سرصفحه‌ها و پاورقی‌ها در سطح مستر ارائه کنترل می‌شوند و API متدهایی برای تعیین متن پاورقی، تغییر قابلیت مشاهدهٔ پاورقی و به‌روزرسانی متن سرصفحه در اسلایدهای یادداشت مستر فراهم می‌کند.

همچنین می‌توانید سرصفحه و پاورقی‌ها را برای اسلایدهای توزیع (Handout) و یادداشت (Notes) مدیریت کنید. این شامل تغییر قابلیت مشاهده و متن محل‌نگهدارنده‌های سرصفحه، پاورقی، شمارهٔ اسلاید و تاریخ‑زمان برای مستر یادداشت، تمام اسلایدهای فرزند یادداشت یا یک اسلاید یادداشت منفرد می‌شود.

## **مدیریت سرصفحه‌ها و پاورقی‌ها در یک ارائه**

یادداشت‌های برخی اسلایدهای خاص می‌تواند همان‌طور که در مثال زیر نشان داده شده است حذف شود:

```php
  # بارگذاری ارائه
  $pres = new Presentation("headerTest.pptx");
  try {
    # تنظیم پاورقی
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # دسترسی و به‌روزرسانی سرصفحه
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # ذخیره ارائه
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **مدیریت سرصفحه‌ها و پاورقی‌ها در اسلایدهای توزیع و یادداشت**
Aspose.Slides for PHP via Java از سرصفحه و پاورقی در اسلایدهای توزیع و یادداشت پشتیبانی می‌کند. لطفاً مراحل زیر را دنبال کنید:

- یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) حاوی ویدیو بارگذاری کنید.
- تنظیمات سرصفحه و پاورقی را برای مستر یادداشت و تمام اسلایدهای یادداشت تغییر دهید.
- محل‌نگهدارنده‌های پاورقی مستر یادداشت و تمام فرزندان آن را قابل مشاهده کنید.
- محل‌نگهدارنده‌های تاریخ و زمان مستر یادداشت و تمام فرزندان آن را قابل مشاهده کنید.
- تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید.
- محل‌نگهدارندهٔ سرصفحهٔ اسلاید یادداشت را قابل مشاهده کنید.
- متن را به محل‌نگهدارندهٔ سرصفحهٔ اسلاید یادداشت تنظیم کنید.
- متن را به محل‌نگهدارندهٔ تاریخ‑زمان اسلاید یادداشت تنظیم کنید.
- فایل ارائهٔ ویرایش‌شده را بنویسید.

قطعه کد در مثال زیر فراهم شده است.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # تغییر تنظیمات سرصفحه و پاورقی برای مستر یادداشت‌ها و تمام اسلایدهای یادداشت
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// نمایش اسلاید مستر یادداشت و تمام مکان‌گیرهای پاورقی فرزند

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// نمایش اسلاید مستر یادداشت و تمام مکان‌گیرهای سرصفحه فرزند

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// نمایش اسلاید مستر یادداشت و تمام مکان‌گیرهای شماره اسلاید فرزند

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// نمایش اسلاید مستر یادداشت و تمام مکان‌گیرهای تاریخ و زمان فرزند

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// تنظیم متن برای اسلاید مستر یادداشت و تمام مکان‌گیرهای سرصفحه فرزند

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// تنظیم متن برای اسلاید مستر یادداشت و تمام مکان‌گیرهای پاورقی فرزند

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// تنظیم متن برای اسلاید مستر یادداشت و تمام مکان‌گیرهای تاریخ و زمان فرزند

    }
    # تغییر تنظیمات سرصفحه و پاورقی فقط برای اولین اسلاید یادداشت
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// نمایش مکان‌گیر سرصفحه این اسلاید یادداشت

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// نمایش مکان‌گیر پاورقی این اسلاید یادداشت

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// نمایش مکان‌گیر شماره اسلاید این اسلاید یادداشت

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// نمایش مکان‌گیر تاریخ‑زمان این اسلاید یادداشت

      $headerFooterManager->setHeaderText("New header text");// تنظیم متن برای مکان‌گیر سرصفحه اسلاید یادداشت

      $headerFooterManager->setFooterText("New footer text");// تنظیم متن برای مکان‌گیر پاورقی اسلاید یادداشت

      $headerFooterManager->setDateTimeText("New date and time text");// تنظیم متن برای مکان‌گیر تاریخ‑زمان اسلاید یادداشت

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**آیا می‌توانم «سرصفحه» به اسلایدهای معمولی اضافه کنم؟**

در PowerPoint، «سرصفحه» فقط برای یادداشت‌ها و توزیع‌ها وجود دارد؛ در اسلایدهای معمولی عناصر پشتیبانی‌شده شامل پاورقی، تاریخ/زمان و شمارهٔ اسلاید هستند. در Aspose.Slides این محدودیت‌ها همان‌طور است: سرصفحه فقط برای یادداشت/توزیع، و در اسلایدها—پاورقی/تاریخ‑زمان/شمارهٔ اسلاید.

**اگر طرح شامل ناحیهٔ پاورقی نیست — آیا می‌توانم قابلیت مشاهدهٔ آن را «روشن» کنم؟**

بله. از طریق مدیر سرصفحه/پاورقی قابلیت مشاهده را بررسی کنید و در صورت نیاز آن را فعال کنید. این شاخص‌ها و متدهای API برای مواردی طراحی شده‌اند که محل‌نگهدارنده گم شده یا مخفی باشد.

**چگونه می‌توانم شمارهٔ اسلاید را از مقداری غیر از ۱ شروع کنم؟**

عدد «اولین شمارهٔ اسلاید» ارائه را با استفاده از [first slide number](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/setfirstslidenumber/) تنظیم کنید؛ پس از آن تمام شماره‌گذاری مجدداً محاسبه می‌شود. برای مثال می‌توانید از ۰ یا ۱۰ شروع کنید و شماره را در اسلاید عنوان مخفی کنید.

**هنگام خروجی گرفتن به PDF/‌تصاویر/HTML چه اتفاقی برای سرصفحه/پاورقی می‌افتد؟**

آن‌ها به‌عنوان عناصر متنی معمولی ارائه رندر می‌شوند. به عبارت دیگر، اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز همراه با بقیه محتوا ظاهر می‌شوند.