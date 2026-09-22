---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در PHP
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/php-java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- فریز تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- زوم پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای PHP از طریق Java را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی‌سازی کنید — چیدمان‌ها، سطوح زوم و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای عادی از سه ناحیه محتوایی تشکیل شده است: خود اسلاید، یک ناحیه محتوای جانبی، و یک ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌یابی نواحی محتوای مختلف مربوط می‌شوند. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری که هنگام بازگشت، نمای آن در همان وضعیت باشد که آخرین بار ارائه ذخیره شده بود.

متد [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه فراهم شود.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties) و زیردستان آن، و شمارش [SplitterBarStateType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) مشخص می‌کنند که آیا برنامه باید آیکون‌ها را هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوایی حالت نمای عادی نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) مشخص می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک بودن کافی ناحیه جانبی به حالت کمینه «snap» کند یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) و [setPreferSingleView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوایی تک‑پنجره‌ای تمام‑صفحه را به جای نمای عادی استاندارد که شامل سه ناحیه است، ببیند. اگر فعال باشد، برنامه ممکن است یکی از نواحی محتوایی را در کل پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) حالت نمایش نوار تقسیم‌کننده افقی یا عمودی را تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوای زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Minimized)، [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Maximized) و [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) و [getRestoredTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties#getRestoredTop) اندازه‌گذاری ناحیه اسلاید بالا یا کناری نمای عادی را وقتی مقدار [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) به‌کار گرفته می‌شود، مشخص می‌کنند.

## **درباره بازگرداندن INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض هنگام فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)، ارتفاع هنگام فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) نمای عادی را هنگامی که ناحیه دارای اندازه بازگردانی متغیر (نه کمینه و نه حداکثر) باشد، مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) اندازه ناحیه اسلاید (عرض هنگام فرزند restoredTop، ارتفاع هنگام فرزند restoredLeft) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) تعیین می‌کند که آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید هنگام تغییر اندازه پنجره حاوی نما در برنامه جبران شود یا خیر.

مثالی که در زیر آورده شده است نشان می‌دهد چگونه می‌توانید ویژگی‌های [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) را برای یک ارائه دسترسی پیدا کنید.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # بازگرداندن ویژگی‌های نمای ارائه
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **تنظیم مقدار زوم پیش‌فرض**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java اکنون از تنظیم مقدار زوم پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) و همچنین [getNotesViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) می‌توانند برنامه‌نویسی شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) در Aspose.Slides تنظیم کنیم.

{{% /alert %}} 

به‌منظور تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) تنظیم کنید.
1. ارائه را به‌عنوان یک فایل [PPTX ](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید. در مثال زیر، مقدار زوم را برای نمای اسلاید و نمای یادداشت‌ها تنظیم کرده‌ایم.

```php
  $presentation = new Presentation();
  try {
    # تنظیم ویژگی‌های نمای ارائه
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // مقدار زوم به درصد برای نمای اسلاید
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // مقدار زوم به درصد برای نمای یادداشت‌ها

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **تنظیم فاصله‌بندی شبکه**

از [Presentation::getViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getViewProperties) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#getGridSpacing) و [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#setGridSpacing) فاصله‌بندی شبکه ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای یک اسلاید منفرد. فاصله‌بندی شبکه بر حسب نقطه‌ست، که ۷۲ نقطه برابر یک اینچ است. همان‌طور که مستندات API می‌طلبد، از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصله‌بندی شبکه فعلی را چاپ می‌کند، فاصله‌ٔ یک‌چهارم اینچ تنظیم می‌‍کند و نتیجه را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

شبکه متفاوت از [drawing guides](/slides/fa/php-java/drawing-guides/) است. فاصله‌بندی شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های ترسیم خطوط افقی یا عمودی تنظیم‌شده به‌صورت فردی هستند. افزودن، جابجایی یا پاک‌کردن راهنمای‌های ترسیم، فاصله‌بندی شبکه را تغییر نمی‌دهد.

هر دو شبکه و راهنمای‌های ترسیم ابزارهای کمکی ویرایشی هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا حالت اسلایدشو رندر نمی‌شوند. ذخیرهٔ فاصله‌بندی شبکه تضمین نمی‌کند که ویرایشگر آن را نمایش دهد؛ نمایش آن همچنین به تنظیمات ترجیحی نمایشگر یا ویرایشگر بستگی دارد.

## **FAQ**

**چرا پس از باز کردن مجدد ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصله‌بندی شبکه را ذخیره می‌کند، اما ویرایشگر تصمیم می‌گیرد آیا شبکه نمایش داده شود یا خیر. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک‌کردن راهنمای‌های ترسیم، فاصله‌بندی شبکه را تغییر می‌دهد؟**

نه. راهنمای‌های ترسیم و فاصله‌بندی شبکه تنظیمات مستقلی هستند. پاک‌کردن راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را تغییر نمی‌دهد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعیین کنم؟**

[View settings](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getslideviewproperties/))، نه برای هر بخش، بنابراین یک مجموعه پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای مختلف را برای کاربران مختلف از پیش تعریف کنم؟**

نه. تنظیمات در فایل ذخیره می‌شوند و به‌ صورت مشترک استفاده می‌شوند. برنامه‌های مشاهده ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعه ویژگی نمای را شامل می‌شود.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف‌شده تهیه کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب جایگذاری کنید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.