---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در جاوا
linktitle: ویژگی‌های نما
type: docs
weight: 80
url: /fa/java/presentation-view-properties/
keywords:
- ویژگی‌های نمایش
- نمای عادی
- محتوا طرح‌واره
- آیکون‌های طرح‌واره
- قفل‌کردن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- زوم پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای جاوا را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی کنید - چیدمان‌ها، سطوح زوم و تنظیمات نمایش را تنظیم نمایید."
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، ناحیه محتوا در کنار و ناحیه محتوا در پایین. ویژگی‌هایی که به موقعیت‌یابی نواحی مختلف محتوا مربوط می‌شود. این اطلاعات به برنامه اجازه می‌دهد حالت نمای خود را در فایل ذخیره کند تا هنگام باز کردن مجدد، نما در همان حالتی باشد که آخرین بار ارائه ذخیره شده بود.

متد [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) برای دسترسی به ویژگی‌های نمای عادی ارائه اضافه شده است.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties) و مشتق‌های آن‌ها، [SplitterBarStateType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType) enum اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش ویژگی‌های نمای عادی.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کند که آیا برنامه باید در حالت نمای عادی، اگر محتویات طرح‌واره در هر یک از نواحی محتوا نمایش داده شود، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) مشخص می‌کند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیهٔ جانبی، به حالت کمینه بچسبد یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) تعیین می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوای تک‑پنجرهٔ تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال شدن، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) حالت نمایش نوار تقسیم‌کنندهٔ افقی یا عمودی را تعیین می‌کند. نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوا در کنار جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) ابعاد ناحیهٔ بالایی یا جانبی اسلاید را در نمای عادی تعیین می‌کند، زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) به‌طور متقابل اعمال شده باشد.

## **درباره بازگرداندن INormalViewProperties**

ابعاد ناحیهٔ اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) باشد) نمای عادی را زمانی که ناحیه دارای اندازهٔ متغیر بازگردانده شده (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازهٔ ناحیهٔ اسلاید (عرض برای فرزند restoredTop، ارتفاع برای فرزند restoredLeft) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تعیین می‌کند که آیا اندازهٔ ناحیهٔ محتوا در کنار باید هنگام تغییر اندازهٔ پنجرهٔ حاوی نما در برنامه، خودکار جبران شود یا نه.

یک مثال در زیر نشان می‌دهد چگونه می‌توانید ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) را برای یک ارائه دسترسی پیدا کنید.

```java
import com.aspose.slides.*;

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

## **تنظیم مقدار پیش‌فرض زوم**

{{% alert color="info" %}} 

Aspose.Slides for Java اکنون از تنظیم مقدار پیش‌فرض زوم برای ارائه پشتیبانی می‌کند به‌طوری‌که هنگام باز کردن ارائه، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) در [Aspose.Slides](/slides/fa/) تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نما، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.
   در مثال زیر، مقدار زوم برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // تنظیم ویژگی‌های نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار زوم به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار زوم به درصد برای نمای یادداشت‌ها 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

### آیا می‌توانم تنظیمات نمای متفاوتی را برای بخش‌های مختلف یک ارائه تنظیم کنم؟

[View settings](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه برای هر بخش، لذا یک مجموعهٔ پارامتر برای کل سند اعمال می‌شود وقتی باز می‌شود.

### آیا می‌توانم حالت‌های نمای مختلفی را برای کاربران مختلف پیش‌تعریف کنم؟

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک‌گذاری می‌شوند. برنامه‌های مشاهده ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را دارد.

### آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف‌شده تهیه کنم تا ارائه‌های جدید به همان صورت باز شوند؟

بله. چون [view properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در قالب جاسازی کنید و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.