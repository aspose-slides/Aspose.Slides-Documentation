---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در جاوااسکریپت
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/nodejs-java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل کردن تقسیم‌کننده عمودی
- نمای تک‌پنجره
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
description: "با استفاده از ویژگی‌های نمای Aspose.Slides برای Node.js via Java، می‌توانید فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی‌سازی کنید—لایه‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوا کناری، و یک ناحیه محتوا پایینی. ویژگی‌های مربوط به موقعیت‌گذاری نواحی مختلف محتوا. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به طوری که هنگام باز شدن مجدد، نمای همان وضعیت را داشته باشد که در آخرین ذخیره‌سازی ارائه بوده است.

متد [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.  

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties) و انواع مشتق‌شدهٔ آن، همچنین شمارش‌گر [SplitterBarStateType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **دربارهٔ NormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید در صورت نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی، آیکون‌ها را نشان دهد یا خیر.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) مشخص می‌کنند که آیا تقسیم‌کنندهٔ عمودی باید هنگام کوچک شدن کافی ناحیهٔ کناری به حالت کمینه بچسبد یا خیر.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ تک‑محتوا در تمام پنجره به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال‌سازی، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) وضعیت نوار تقسیم‌کنندهٔ عمودی یا افقی را که باید نمایش داده شود، تعیین می‌کنند. نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوا کناری جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیهٔ بالایی یا کناری اسلاید در نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) اعمال شده، مشخص می‌کند.

## **دربارهٔ بازگرداندن NormalViewProperties**

ابعاد ناحیهٔ اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) باشد) در نمای عادی را زمانی که ناحیه دارای اندازهٔ بازنشانی متغیر (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) اندازهٔ ناحیهٔ اسلاید (عرض زمانیکه فرزند restoredTop باشد، ارتفاع زمانیکه فرزند restoredLeft باشد) را تعیین می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) مشخص می‌کند که آیا اندازهٔ ناحیهٔ محتوا کناری باید برای اندازهٔ جدید جبران کند وقتی که پنجرهٔ حاوی نما در برنامه تغییر اندازه می‌دهد.

در مثال زیر نشان داده شده است که چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

```javascript

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

## **تنظیم مقدار بزرگ‌نمایی پیش‌فرض**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java اکنون از تنظیم مقدار بزرگ‌نمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به گونه‌ای که وقتی ارائه باز می‌شود، بزرگ‌نمایی قبلاً تنظیم شده است. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) و همچنین [getNotesViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این مطلب، با یک مثال می‌بینیم چگونه می‌توان [View Properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) در [Aspose.Slides](/slides/fa/) تنظیم کرد.

{{% /alert %}} 

برای تنظیم ویژگی‌های نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) مربوط به [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) را تنظیم کنید.
1. ارائه را به عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید. در مثال زیر، مقدار بزرگ‌نمایی برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```javascript
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

## **سؤالات متداول**

**آیا می‌توانم تنظیمات نما متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

تنظیمات [View settings](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))، نه به‌صورت بخش به بخش، بنابراین یک مجموعه پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم وضعیت‌های نما متفاوتی برای کاربران مختلف از پیش تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌صورت عمومی به اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌کننده ممکن است به ترجیحات کاربر احترام بگذارند، اما خود فایل شامل یک مجموعه ویژگی نمای است.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. زیرا [view properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در قالبی قرار دهید و اسناد جدید را از آن با همان پیکربندی اولیه نما ایجاد کنید.