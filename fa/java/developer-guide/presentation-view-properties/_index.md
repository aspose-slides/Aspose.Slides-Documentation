---
title: "بازخوانی و به‌روزرسانی ویژگی‌های نمای ارائه در جاوا"
linktitle: "ویژگی‌های نمای"
type: docs
weight: 80
url: /fa/java/presentation-view-properties/
keywords:
- "ویژگی‌های نمای"
- "نمای عادی"
- "محتویات طرح کلی"
- "آیکن‌های طرح کلی"
- "قاب‌بندی عمودی"
- "نمای تک"
- "وضعیت نوار"
- "اندازه بُعد"
- "تنظیم خودکار"
- "بزرگ‌نمایی پیش‌فرض"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "ویژگی‌های نمای Aspose.Slides برای Java را کشف کنید تا فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای معمولی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوا کناری، و یک ناحیه محتوا پایین. ویژگی‌های مربوط به موقعیت‌یابی نواحی مختلف محتوا. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری که هنگام بازگشایی، نما در همان حالت که آخرین بار ارائه ذخیره شده بود، باشد.

متد [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) برای دسترسی به ویژگی‌های نمای معمولی ارائه اضافه شده است.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties) و زیررابط‌های آن، شمارشگر [SplitterBarStateType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌دهنده ویژگی‌های نمای معمولی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) تعیین می‌کنند که آیا برنامه باید هنگام نمایش محتویات طرح کلی در هر یک از نواحی محتوا در حالت نمای معمولی، آیکن‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) تعیین می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک بودن کافی ناحیه کناری، به حالت کاهش‌یافته بچسبد یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیه تک‌محتوا را در کل پنجره ببیند به جای نمای معمولی استاندارد با سه ناحیه محتوا. در صورت فعال بودن، برنامه ممکن است یک از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وضعیت نمایش نوار تقسیم‌کننده عمودی یا افقی را تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا کناری جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیه بالایی یا کناری اسلاید در نمای معمولی را مشخص می‌کنند، زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) به‌کار رفته باشد.

## **درباره بازگرداندن INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) باشد، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) باشد) در نمای معمولی را مشخص می‌کند، زمانی که ناحیه دارای اندازه متغیر بازگردانده شده (نه کاهش‌یافته و نه بزرگ‌شده) باشد.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازه ناحیه اسلاید (عرض وقتی فرزند restoredTop باشد، ارتفاع وقتی فرزند restoredLeft باشد) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تعیین می‌کند که آیا اندازه ناحیه محتوا کناری باید هنگام تغییر اندازه پنجرهٔ حاوی نما در برنامه، برای اندازهٔ جدید جبران کند یا نه.

در مثال زیر نشان داده می‌شود که چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // بازگرداندن ویژگی‌های نمای ارائه
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **تنظیم مقدار بزرگ‌نمایی پیش‌فرض**

{{% alert color="primary" %}} 

اکنون Aspose.Slides برای Java از تنظیم مقدار بزرگ‌نمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، بزرگ‌نمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) یک ارائه انجام شود. [getSlideViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) و همچنین [getNotesViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) مربوط به [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) را در [Aspose.Slides](/slides/fa/) تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) مربوط به [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) را تنظیم کنید.
1. ارائه را به‌عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.
   در مثال زیر، مقدار بزرگ‌نمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```java
Presentation presentation = new Presentation();
try {
    // تنظیم ویژگی‌های نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمای یادداشت‌ها 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **پرسش‌های متداول**

**آیا می‌توانم تنظیمات نمای متفاوت برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

تنظیمات نمای ([View settings](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--)) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه به‌ازای هر بخش، به‌طوری که یک مجموعهٔ پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم وضعیت‌های نمای مختلف را برای کاربران مختلف از پیش تعریف کنم؟**

خیر. این تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌گر ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجا که ویژگی‌های نمای در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب گنجانده و اسناد جدیدی بر پایهٔ آن ایجاد کنید که همان پیکربندی نمای اولیه را داشته باشند.