---
title: بازیابی و به‌روزرسانی خصوصیات نمایش ارائه در PHP
linktitle: خصوصیات نمایش
type: docs
weight: 80
url: /fa/php-java/presentation-view-properties/
keywords:
- خصوصیات نمایش
- نمای عادی
- محتوای نمای کلی
- آیکون‌های نمای کلی
- چسباندن تقسیم‌کننده عمودی
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
description: "با استفاده از خصوصیات نمایش Aspose.Slides برای PHP از طریق Java، فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی‌سازی کنید — چیدمان‌ها، سطوح زوم و تنظیمات نمایش را تنظیم نمایید."
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوایی است: اسلاید خود، یک ناحیه محتوای جانبی و یک ناحیه محتوای پایین. خصوصیات مربوط به موقعیت‌گذاری ناحیه‌های مختلف محتوا. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری که هنگام باز کردن مجدد، نما در همان وضعیتی باشد که ارائه در آخرین بار ذخیره شده بود.

متد [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) اضافه شده است تا دسترسی به خصوصیات نمای عادی ارائه را فراهم کند.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties) و فرزندان آن، و شمارش [SplitterBarStateType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌دهندهٔ خصوصیات نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) مشخص می‌کنند که آیا برنامه باید هنگام نمایش محتوای نمای کلی در هر یک از ناحیه‌های محتوای حالت نمای عادی، آیکن‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) مشخص می‌کنند که آیا تقسیم‌کنندهٔ عمودی باید هنگام کوچک بودن کافی ناحیهٔ جانبی، به حالت به‌حداقل‌رسیدهٔ خود چسبیده (snap) شود یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) و [setPreferSingleView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوای تک‌پنجره‌ای تمام‑صفحه به جای نمای عادی استاندارد با سه ناحیهٔ محتوا ببیند. در صورت فعال‌سازی، برنامه ممکن است یکی از ناحیه‌های محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) وضعیت نشان داده شدن میلهٔ تقسیم‌کنندهٔ افقی یا عمودی را مشخص می‌کنند. میلهٔ تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوای زیر اسلاید جدا می‌کند، میلهٔ تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Maximized) و [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) و [getRestoredTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties#getRestoredTop) اندازهٔ ناحیهٔ بالایی یا جانبی اسلاید در نمای عادی را مشخص می‌کنند، زمانی که مقدار [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SplitterBarStateType/#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) به‌طور متناسب اعمال شده باشد.

## **درباره بازگردانی INormalViewProperties**

ابعاد ناحیهٔ اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) باشد، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) باشد) در نمای عادی را مشخص می‌کند، زمانی که ناحیه دارای اندازهٔ بازگرداندهٔ متغیر (نه به‌حداقل‌رسیده و نه به‌حداکثر) باشد.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) اندازهٔ ناحیهٔ اسلاید را مشخص می‌کند (عرض وقتی فرزند restoredTop باشد، ارتفاع وقتی فرزند restoredLeft باشد).

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) تعیین می‌کند که آیا اندازهٔ ناحیهٔ محتوای جانبی باید هنگام تغییر اندازهٔ پنجرهٔ حاوی نما در برنامه، خود را متناسب با اندازهٔ جدید تنظیم کند یا خیر.

مثالی در زیر نشان می‌دهد چگونه می‌توانید به خصوصیات [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) یک ارائه دسترسی پیدا کنید.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # بازگرداندن خصوصیات نمایش ارائه
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

Aspose.Slides for PHP via Java اکنون از تنظیم مقدار زوم پیش‌فرض برای ارائه پشتیبانی می‌کند به طوری که هنگام باز کردن ارائه، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) می‌توانند به صورت برنامه‌نویسی تنظیم شوند. در این مطلب، با یک مثال می‌بینیم چگونه می‌توان [View Properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) در Aspose.Slides تنظیم کرد.

{{% /alert %}} 

برای تنظیم خصوصیات نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) تنظیم کنید.
1. ارائه را به عنوان یک فایل [PPTX ](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید. در مثال زیر، مقدار زوم برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```php
  $presentation = new Presentation();
  try {
    # تنظیم خصوصیات نمایش ارائه
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // مقدار زوم به درصد برای نمای اسلاید
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // مقدار زوم به درصد برای نمای یادداشت‌ها

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **تنظیم فواصل شبکه**

از [Presentation::getViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getViewProperties) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#getGridSpacing) و [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/#setGridSpacing) فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای اسلایدی منفرد. فاصلهٔ شبکه بر حسب پوینت تعیین می‌شود، به‌طوری که ۷۲ پوینت معادل یک اینچ است. طبق مستندات API باید از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ فعلی شبکه را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ را تنظیم می‌نماید و نتیجه را ذخیره می‌کند.

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

شبکه متفاوت از [drawing guides](/slides/fa/php-java/drawing-guides/) است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمایی‌های رسم خطوط تراز افقی یا عمودی به‌صورت مستقل موقعیت‌یابی می‌شوند. افزودن، جابجایی یا حذف راهنمایی‌های رسم فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمایی‌های رسم، ابزارهای کمکی ویرایشی هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر آن را نمایش دهد: نمایش آن نیز به تنظیمات نمایشگر یا ویرایشگر بستگی دارد.

## **نمایش یا پنهان‌سازی نظرات هنگام باز کردن یک ارائه**

از [Presentation::getViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. از [ViewProperties::getShowComments](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getshowcomments/) و [ViewProperties::setShowComments](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/setshowcomments/) برای خواندن یا تغییر ترجیح ذخیره‌شدهٔ نمایش نظرات هنگام باز شدن ارائه در PowerPoint یا ویرایشگر سازگار دیگر استفاده کنید.

این تنظیم فقط ترجیح نمای ذخیره‌شده را کنترل می‌کند. آن عمل افزودن، حذف، ویرایش یا حل نظرات را انجام نمی‌دهد. پنهان‌سازی نظرات محتوای آنها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌های تغییر خود نظرات، به [Presentation Comments](/slides/fa/php-java/presentation-comments/) مراجعه کنید.

مثال زیر به یک فایل `comments.pptx` موجود که شامل نظرات است، نیاز دارد. این مثال تنظیمات جاری قابلیت مشاهده را چاپ می‌کند، درخواست می‌کند نظرات مخفی شوند و یک PPTX جدید را بدون حذف هیچ نظری ذخیره می‌کند. همچنین از [ViewProperties::setLastView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/setlastview/) همراه با [ViewType::SlideView](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewtype/#SlideView) برای پیکربندی نمای اولیهٔ ویرایش به همراه قابلیت مشاهده نظرات استفاده می‌کند.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

این تنظیم تعیین نمی‌کند که آیا نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت‌ها یا برگه‌های توزیع گنجانده شوند یا نه. گزینه‌های خاص هر نوع خروجی را به‌طور جداگانه پیکربندی کنید.

## **FAQ**

**چرا پس از بازکردن مجدد ارائه، شبکه نشان داده نمی‌شود؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر تعیین می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا حذف راهنمایی‌های رسم فاصلهٔ شبکه را تغییر می‌دهد؟**

خیر. راهنمایی‌های رسم و فاصلهٔ شبکه تنظیمات مستقلی هستند. حذف راهنمایی‌ها فاصلهٔ ذخیره‌شدهٔ شبکه را بدون تغییر می‌گذارد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

[View settings](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/getslideviewproperties/))، نه برای هر بخش. بنابراین یک مجموعهٔ پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی را برای کاربران مختلف پیش‌تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک‌گذاری می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعهٔ خصوصیات نمای دارد.

**آیا می‌توانم قالبی با View Properties پیش‌تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجا که [view properties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب قرار دهید و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.