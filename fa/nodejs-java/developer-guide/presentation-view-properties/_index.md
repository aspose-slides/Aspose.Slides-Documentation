---
title: دریافت و به‌روزرسانی ویژگی‌های نمایش ارائه در جاوا اسکریپت
linktitle: ویژگی‌های نمایش
type: docs
weight: 80
url: /fa/nodejs-java/presentation-view-properties/
keywords:
- ویژگی‌های نمایش
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ویژگی‌های نمایش Aspose.Slides برای Node.js via Java را کشف کنید تا فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوا کناری، و یک ناحیه محتوا پایین. ویژگی‌هایی که به موقعیت‌یابی نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمایش را در فایل ذخیره کند، به طوری که هنگام بازگشت، نمایش در همان وضعیتی باشد که آخرین بار ارائه ذخیره شده بود.

متد [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.

[NormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties) کلاس و فرزندان آن، [SplitterBarStateType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType) enum اضافه شده‌اند.

## **درباره NormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید در صورتی که محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی نمایش داده شود، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) تعیین می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیه جانبی به حالت کمینه بچسبد یا خیر.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‑پنجره کامل را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه می‌تواند یکی از نواحی محتوا را در کل پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) وضعیت نوار تقسیم‌کننده عمودی یا افقی را تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا کناری جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیه بالایی یا کناری اسلاید در نمای عادی را مشخص می‌کنند، زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) به‌صورت متقابل اعمال شده باشد.

## **درباره Restoring NormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) باشد، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) باشد) در نمای عادی را زمانی که ناحیه اندازه‌گیری متغیر بازنشانی شده‌ای دارد (نه کمینه و نه بیشینه) مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) اندازه ناحیه اسلاید (عرض وقتی فرزند restoredTop، ارتفاع وقتی فرزند restoredLeft) را تعیین می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) مشخص می‌کند که آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید وقتی پنجره حاوی نمای داخل برنامه تغییر اندازه می‌یابد، جبران شود یا نه.

یک مثال زیر نشان می‌دهد چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // بازگرداندن ویژگی‌های نمای ارائه
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **تنظیم مقدار پیش‌فرض بزرگ‌نمایی**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java اکنون از تنظیم مقدار پیش‌فرض بزرگ‌نمایی برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، بزرگ‌نمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به صورت برنامه‌نویسی تنظیم شوند. در این مقاله، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) در Aspose.Slides تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) تنظیم کنید.
1. ارائه را به عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.  
   در مثال زیر، مقدار بزرگ‌نمایی برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // تنظیم ویژگی‌های نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمای یادداشت‌ها
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم فاصله‌بندی شبکه**

از متد [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای کلی استفاده کنید. متدهای [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) و [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) فاصله شبکه ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای اسلاید منفرد. فاصله شبکه بر حسب نقطه است و ۷۲ نقطه برابر یک اینچ است. همان‌طور که در مستندات API آمده است، از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را می‌فتح، فاصله شبکه فعلی را چاپ می‌کند، فاصله ربع اینچی تنظیم می‌نماید و سپس نتیجه را ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

شبکه با [راهنمایی‌های رسم](/slides/fa/nodejs-java/drawing-guides/) متفاوت است. فاصله شبکه یک فاصله منظم را کنترل می‌کند، در حالی که راهنمایی‌های رسم خطوط تراز افقی یا عمودی هستند که به‌صورت جداگانه موقعیت می‌یابند. افزودن، جابجایی یا پاک کردن راهنمایی‌های رسم، فاصله شبکه را تغییر نمی‌دهد.

هر دو شبکه و راهنمایی‌های رسم ابزارهای ویرایشی هستند. آن‌ها به عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید نمایش داده نمی‌شوند. ذخیره‌سازی فاصله شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد: قابلیت نمایش آن نیز به تنظیمات ترجیحات بیننده یا ویرایشگر وابسته است.

## **سوالات متداول**

**چرا پس از باز کردن مجدد ارائه شبکه دیده نمی‌شود؟**

فایل فاصله شبکه را ذخیره می‌کند، اما ویرایشگر تعیین می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش‌پذیری شبکه در ویرایشگر را بررسی کنید.

**آیا پاک کردن راهنمایی‌های رسم فاصله شبکه را تغییر می‌دهد؟**

خیر. راهنمایی‌های رسم و فاصله شبکه تنظیمات مستقل هستند. پاک کردن راهنمایی‌ها فاصله ذخیره‌شده شبکه را زیر اثر نمی‌گذارد.

**آیا می‌توان تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کرد؟**

[تنظیمات نمای](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))، نه برای هر بخش، بنابراین یک مجموعه پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توان حالت‌های نمای مختلفی را برای کاربران مختلف از پیش تعریف کرد؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به اشتراک گذاشته می‌شوند. برنامه‌های مشاهده می‌توانند ترجیحات کاربر را در نظر بگیرند، اما خود فایل تنها یک مجموعه ویژگی نمای دارد.

**آیا می‌توان قالبی با ویژگی‌های نمای پیش‌تعریف‌شده تهیه کرد تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجایی که [ویژگی‌های نمای](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در قالبی قرار دهید و اسناد جدید را با همان پیکربندی نمای اولیه از آن قالب ایجاد کنید.