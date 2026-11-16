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
- نمادهای طرح کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازهٔ بُعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "از Aspose.Slides برای PHP از طریق Java استفاده کنید تا چیدمان نمای عادی، بزرگ‌نمایی اسلاید و یادداشت‌ها، فاصلهٔ شبکه و قابلیت مشاهده نظرات را در ارائه‌های PowerPoint پیکربندی کنید."
---
## **معرفی**

در نمای عادی PowerPoint، اسلاید بین یک پنل کناری برای تصویرهای کوچک یا یک طرح کلی و یک پنل یادداشت در پایین ظاهر می‌شود. Aspose.Slides برای PHP از طریق Java تنظیمات ذخیره‌شدهٔ ویرایش ارائه را از طریق [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) در دسترس می‌گذارد. این تنظیمات شامل چیدمان پنل، سطوح زوم، فاصلهٔ شبکه و نمایش نظرات هستند.

## **درباره NormalViewProperties**

از [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) برای دسترسی به کلاس [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) استفاده کنید. [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) تعیین می‌کند که آیا نمادها در کنار عناوین اسلاید در نمای طرح کلی ظاهر شوند یا خیر. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) به پنل کناری امکان می‌دهد هنگام باریک شدن توسط کاربر، به حالت کوچک‌شدهٔ خود بچسبد. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) نشان‌دهندهٔ ترجیح برای نمایش یک پنل در تمام پنجره است.  

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) تقسیم‌کننده بین پنل کناری و اسلاید را کنترل می‌کند. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) تقسیم‌کننده بالای پنل یادداشت‌ها را کنترل می‌کند. هر دو مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) که می‌تواند `Minimized`، `Maximized` یا `Restored` باشد، می‌پذیرند.

## **درباره بازگرداندن NormalViewProperties**

وقتی یک تقسیم‌کننده بازگردانده می‌شود، [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) اندازهٔ ذخیره‌شدهٔ پنل کناری را فراهم می‌کند و [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) اندازهٔ ذخیره‌شدهٔ ناحیهٔ بالایی اسلاید را فراهم می‌کند. هر دو [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/) را نشان می‌دهند. متد [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) آن مقدار درصدی از 0 تا 100 را می‌پذیرد و [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) تعیین می‌کند که آیا ویرایشگر هنگام تغییر اندازهٔ پنجره، اندازه را تنظیم کند یا نه.  

این مثال یک ارائه موجود را به‌روزرسانی می‌کند. تقسیم‌کننده افقی را بازگردانده، اندازهٔ برگرفته از [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) را به 80% تنظیم می‌کند با فعال‌سازی تنظیم خودکار، و تقسیم‌کننده عمودی را به حداکثر می‌رساند. همچنین [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) را فراخوانی می‌کند تا نمادها در نمای طرح کلی نمایش داده شوند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم مقدار پیش‌فرض زوم**

متدهای [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) و [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) تنظیمات زوم مستقل برای ویرایشگر را ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح خروجی تصویر تأثیری ندارند.  

این مثال یک ارائه موجود را باز می‌کند و [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) را برای مقیاس‌گذاری اسلاید به اندازهٔ پنجره ویرایش فراخوانی می‌کند. برای صفحهٔ یادداشت‌ها، مقیاس خودکار را غیرفعال می‌کند و با [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) زوم ثابت 80% را تنظیم می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم فاصلهٔ شبکه**

متد `setGridSpacing` در [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) فاصلهٔ خطوط شبکهٔ ویرایشی در سرتاسر ارائه را تنظیم می‌کند. این مقدار باید عددی مثبت بر اساس نقطه باشد که هر اینچ 72 نقطه دارد. این مثال فاصلهٔ فعلی را در یک ارائه موجود چاپ می‌کند و با تنظیم بازه به 18 نقطه، شبکهٔ یک‌چهارم اینچی را ذخیره می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

شبکه با یک بازهٔ ثابت تکرار می‌شود. [Drawing guides](/slides/fa/php-java/drawing-guides/) موقعیت‌های افقی یا عمودی جداگانه را علامت می‌زنند. هر دو ابزار کمکی ویرایشی هستند و فقط در ویرایشگرهایی که آنها را نمایش می‌دهند، ظاهر می‌شوند. اسلایدشوها و خروجی‌های به PDF، تصویر یا SVG این راهنماها را شامل نمی‌شوند.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) ترجیحی را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائه موجود که حاوی نظرات است، این مثال تنظیم فعلی را چاپ می‌کند و یک نسخهٔ کپی با نظرات مخفی ذخیره می‌نماید. همچنین [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) را با [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) فراخوانی می‌کند تا نسخهٔ کپی در نمای اسلاید باز شود.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مخفی‌سازی نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آنها را حفظ می‌کند. برای تغییر خود نظرات، به [Presentation Comments](/slides/fa/php-java/presentation-comments/) مراجعه کنید. تنظیمات خروجی تعیین می‌کند که آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا جزوات ظاهر شوند یا نه.

## **سوالات متداول**

**چرا شبکه هنگام باز کردن مجدد ارائه مخفی می‌شود؟**  
ارائه بازهٔ شبکه را ذخیره می‌کند. برای مشاهدهٔ شبکه، نمایش شبکه را در ویرایشگر فعال کنید.

**آیا پاک کردن راهنمای‌های رسم باعث تغییر فاصلهٔ شبکه می‌شود؟**  
خیر. افزودن، جابجا کردن یا پاک کردن یک راهنما، بازهٔ شبکه را دست‌نخورده می‌گذارد.

**آیا می‌توان برای بخش‌های مختلف یک ارائه تنظیمات نمای متفاوت داشت؟**  
خیر. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) برای کل ارائه اعمال می‌شود.

**آیا می‌توان تنظیمات نمای متفاوتی برای کاربران مختلف ذخیره کرد؟**  
فایل تنها یک مجموعهٔ تنظیمات نمای را برای همه ذخیره می‌کند. ممکن است ویرایشگر ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توان تنظیمات نمای را در یک قالب ذخیره کرد؟**  
بله. ارائه‌های ساخته‌شده از قالب، تنظیمات نمای ذخیره‌شدهٔ آن را ارث می‌برند.