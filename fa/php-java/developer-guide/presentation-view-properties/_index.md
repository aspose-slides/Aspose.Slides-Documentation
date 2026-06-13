---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه‌نامه در PHP
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/php-java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه‌نامه
- PHP
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای PHP از طریق Java را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی‌سازی کنید — چیدمان‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **Introduction**

نمای عادی شامل سه ناحیه محتوا است: اسلاید، ناحیه محتوا در کنار اسلاید، و ناحیه محتوا در پایین اسلاید. ویژگی‌هایی که به موقعیت‌یابی نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری‌که هنگام باز کردن مجدد، نمای برنامه در همان وضعیتی باشد که آخرین بار ارائه‌نامه ذخیره شده بود.

متد [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) برای دسترسی به ویژگی‌های نمای عادی ارائه‌نامه اضافه شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties) و مشتق‌‎های آن‌ها، و enum [SplitterBarStateType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **About INormalViewProperties**

نمایش‌دهنده ویژگی‌های نمای عادی.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) مشخص می‌کنند که آیا برنامه هنگام نمایش محتوای طرح کلی در هر یک از نواحی نمای عادی، آیکون‌ها را نشان دهد یا خیر.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) تعیین می‌کنند که آیا نوار تقسیم‌کننده عمودی هنگام کوچک شدن کافی ناحیه جانبی، به حالت کمینه منتقل شود یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) و [setPreferSingleView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوا به‌صورت تمام‑پنجره نمایش داده شود به‌جای نمای عادی استاندارد با سه ناحیه محتوا. اگر فعال باشد، برنامه می‌تواند یکی از نواحی محتوا را در تمام پنجره نشان دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) وضعیت نوار تقسیم‌کننده عمودی یا افقی را که باید نمایش داده شود، تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند، در حالی که نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا در کنار اسلاید جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Minimized)، [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Maximized) و [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) و [getRestoredTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties#getRestoredTop) اندازه‌گیری ناحیه بالایی یا جانبی اسلاید در نمای عادی را زمانی که مقدار [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) اعمال شده باشد، مشخص می‌کنند.

## **About Restoring INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) باشد) در نمای عادی را زمانی که ناحیه دارای اندازه متغیر بازیابی شده (نه کمینه و نه حداکثر) باشد، تعیین می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) اندازه ناحیه اسلاید را (عرض برای فرزند restoredTop، ارتفاع برای فرزند restoredLeft) مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) تعیین می‌کند که آیا اندازه ناحیه محتوا در کنار اسلاید باید برای اندازه جدید هنگام تغییر اندازه پنجرهٔ شامل نمای داخل برنامه جبران شود یا نه.

یک مثال زیر نشان می‌دهد چگونه می‌توان به ویژگی‌های [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) برای یک ارائه‌نامه دسترسی پیدا کرد.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # بازگرداندن ویژگی‌های نمای ارائه‌نامه
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Set the Default Zoom Value**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java اکنون از تنظیم مقدار زوم پیش‌فرض برای ارائه‌نامه پشتیبانی می‌کند به‌طوری‌که هنگام باز شدن ارائه‌نامه، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم شیء [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) یک ارائه‌نامه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این مطلب، با یک مثال نشان می‌دهیم چگونه ویژگی‌های [View Properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) در [Aspose.Slides](/slides/fa/) را تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. ویژگی‌های [View Properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) مربوط به [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) را تنظیم کنید.
1. ارائه‌نامه را به‌عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.  
   در مثال زیر، مقدار زوم برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```php
  $presentation = new Presentation();
  try {
    # تنظیم ویژگی‌های نمای ارائه‌نامه
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // مقدار زوم به درصد برای نمای اسلاید
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // مقدار زوم به درصد برای نمای یادداشت‌ها

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه‌نامه تعیین کنم؟**

[View settings](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه‌نامه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getslideviewproperties/)) و نه برای هر بخش؛ بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای مختلفی را برای کاربران متفاوت از پیش تعریف کنم؟**

خیر. این تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را در نظر بگیرند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف شده تهیه کنم تا ارائه‌نامه‌های جدید به همان روش باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه‌نامه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب قرار داده و سندهای جدید را بر پایهٔ آن قالب ایجاد کنید تا پیکربندی نمای اولیه یکسان باشد.