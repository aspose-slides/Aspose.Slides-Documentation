---
title: بازیابی و به‌روزرسانی ویژگی‌های نمای ارائه در اندروید
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/androidjava/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- نمادهای طرح کلی
- چسباندن تقسیم‌کنندهٔ عمودی
- نمای تک‌تک
- وضعیت نوار
- اندازهٔ بُعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: ویژگی‌های نمای Aspose.Slides برای اندروید via Java را کشف کنید تا قالب‌های اسلاید PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح زوم و تنظیمات نمایش را تنظیم کنید.
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود اسلاید، یک ناحیه محتوای جانبی، و یک ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌ٔ ناحیه‌های مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری که هنگام بازگشایی، نما در همان وضعیتی باشد که ارائه آخرین بار ذخیره شده بود.

روش [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه فراهم شود.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties) و فرزندان آن، شمارش [SplitterBarStateType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید نمادها را در صورتی که محتویات طرح کلی در هر یک از ناحیه‌های محتوا در حالت نمای عادی نمایش داده شود، نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) تعیین می‌کنند که آیا تقسیم‌کنندهٔ عمودی باید وقتی ناحیهٔ جانبی به اندازهٔ کافی کوچک باشد، به حالت کاهش‌یافته (minimized) بچسبد یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) تعیین می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوا با تمام پنجره را به‌جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه می‌تواند یکی از ناحیه‌های محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وضعیت نمایش نوار تقسیم‌کنندهٔ افقی یا عمودی را مشخص می‌کنند. یک نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا در زیر اسلاید جدا می‌کند، در حالی که نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوا در کنار اسلاید جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) ابعاد ناحیهٔ بالایی یا جانبی اسلاید در نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) اعمال شده باشد، مشخص می‌کنند.

## **درباره بازگردانی INormalViewProperties**

ابعاد ناحیهٔ اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) باشد) در نمای عادی را وقتی که ناحیه دارای اندازهٔ بازگردانی متغیر (نه کاهش‌یافته و نه بیشینه) باشد، مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازهٔ ناحیهٔ اسلاید (عرض زمانی که فرزند restoredTop باشد، ارتفاع زمانی که فرزند restoredLeft باشد) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تعیین می‌کند که آیا اندازهٔ ناحیهٔ محتوا در کنار باید برای اندازهٔ جدید هنگام تغییر اندازهٔ پنجره‌ای که نمای را در برنامه دربردارد، جبران شود یا خیر.

مثالی که در زیر آورده شده است نشان می‌دهد چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

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

## **تنظیم مقدار بزرگ‌نمایی پیش‌فرض**

{{% alert color="info" %}} 
Aspose.Slides for Android via Java اکنون از تنظیم مقدار بزرگ‌نمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌گونه‌ای که هنگام باز کردن ارائه، بزرگ‌نمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) مربوط به [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) را در Aspose.Slides تنظیم کنیم.
{{% /alert %}} 

برای تنظیم ویژگی‌های نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به‌عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.
   در مثالی که در ادامه آورده شده است، مقدار بزرگ‌نمایی برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // تنظیم ویژگی‌های نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمایش اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمایش یادداشت‌ها 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم فاصلهٔ شبکه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) و [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) مقدار یا فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای یک اسلاید منفرد. فاصلهٔ شبکه بر حسب نقطه است که ۷۲ نقطه برابر یک اینچ است. همانطور که مستندات API می‌گوید، از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ شبکهٔ فعلی آن را چاپ می‌کند، فواصل یک‌چهارم اینچ را تنظیم می‌نماید و نتیجه را ذخیره می‌کند.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

شبکه با [drawing guides](/slides/fa/androidjava/drawing-guides/) متفاوت است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های رسم (drawing guides) خطوط افقی یا عمودی تنظیم شده به‌صورت جداگانه هستند. افزودن، جابه‌جایی یا پاک کردن راهنمای‌های رسم، فاصلهٔ شبکه را تغییر نمی‌دهد.

هم شبکه و هم راهنمای‌های رسم ابزارهای کمکی ویرایش هستند. آن‌ها به‌عنوان محتویات اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد؛ نمایش آن همچنین بستگی به تنظیمات نمایشگر یا ویرایشگر دارد.

## **FAQ**

**چرا پس از بازگشایی مجدد ارائه، شبکه قابل مشاهده نیست؟**  
فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر تعیین می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک کردن راهنمای‌های رسم فاصلهٔ شبکه را تغییر می‌دهد؟**  
خیر. راهنمای‌های رسم و فاصلهٔ شبکه تنظیمات مستقلی هستند. پاک کردن راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را تغییر نمی‌دهد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعیین کنم؟**  
تنظیمات [View settings](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه برای هر بخش، بنابراین یک مجموعهٔ پارامتر برای کل سند اعمال می‌شود وقتی که باز می‌شود.

**آیا می‌توانم وضعیت‌های نمای متفاوتی برای کاربران مختلف پیش‌تعریف کنم؟**  
خیر. این تنظیمات در فایل ذخیره می‌شوند و به اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**  
بله. چون [view properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب قرار دهید و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.