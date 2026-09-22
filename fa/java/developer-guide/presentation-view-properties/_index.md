---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در جاوا
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قابلیت چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای جاوا را کشف کنید تا فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم کنید."
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، یک ناحیه محتوا در کنار و یک ناحیه محتوا در پایین. ویژگی‌های مربوط به موقعیت‌گذاری نواحی مختلف محتوا. این اطلاعات به برنامه امکان می‌دهد حالت نمای خود را در فایل ذخیره کند تا وقتی دوباره باز می‌شود، نمای همان حالت را که در آخرین ذخیره‌سازی ارائه داشت داشته باشد.

متد [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) برای دسترسی به ویژگی‌های نمای عادی ارائه افزوده شده است.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties) و انواع مشتق‌شدهٔ آنها، [SplitterBarStateType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType) به اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند آیا برنامه باید در زمان نمایش محتوای طرح کلی در هر یک از نواحی نمای عادی، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) تعیین می‌کنند آیا تقسیم‌کنندهٔ عمودی هنگامیکه ناحیهٔ جانبی به اندازهٔ کافی کوچک شود، به حالت کمینه متصل شود یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) مشخص می‌کنند آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوا به‌صورت تمام‑صفحه دیده شود به‌جای نمای عادی استاندارد با سه ناحیه. اگر فعال باشد، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نشان دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وضعیت نمایش نوارهای جداکنندهٔ افقی یا عمودی را تعیین می‌کنند. یک نوار جداکنندهٔ افقی اسلاید را از ناحیهٔ محتوا در زیر اسلاید جدا می‌کند، در حالی که نوار جداکنندهٔ عمودی اسلاید را از ناحیهٔ محتوا در کناره جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) اندازهٔ ناحیهٔ بالایی یا کناری اسلاید در نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) اعمال شده باشد، مشخص می‌کند.

## **درباره بازنشانی INormalViewProperties**

اندازه‌گیری ناحیهٔ اسلاید (عرض هنگام فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)، ارتفاع هنگام فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) را در نمای عادی مشخص می‌کند وقتی که این ناحیه اندازهٔ متغیر بازنشانی‌شده‌ای دارد (نه کمینه نه بیشینه).

متد [getDimensionSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازهٔ ناحیهٔ اسلاید (عرض هنگام فرزند restoredTop، ارتفاع هنگام فرزند restoredLeft) را تعیین می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) مشخص می‌کند آیا اندازهٔ ناحیهٔ محتوای جانبی باید برای اندازهٔ جدید هنگام تغییر اندازهٔ پنجرهٔ حاوی نما جبران شود یا نه.

یک مثال در زیر نشان می‌دهد چگونه می‌توانید ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) را برای یک ارائه دریافت کنید.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // بازنشانی ویژگی‌های نمای ارائه
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **تنظیم مقدار پیش‌فرض بزرگ‌نمایی**

{{% alert color="info" %}} 

Aspose.Slides for Java هم‌اکنون از تنظیم مقدار پیش‌فرض بزرگ‌نمایی برای ارائه پشتیبانی می‌کند به‌طوری‌که وقتی ارائه باز می‌شود، بزرگ‌نمایی از پیش تنظیم شده است. این کار می‌تواند از طریق تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌ای تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه ویژگی‌های [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) را در Aspose.Slides تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نما، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. ویژگی‌های [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.  
   در مثال زیر مقدار بزرگ‌نمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```java
import com.aspose.slides.*;

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

## **تنظیم فاصله‌بندی شبکه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#getGridSpacing--) و [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم بر کل ارائه اعمال می‌شود، نه بر اسلاید منفرد. فاصلهٔ شبکه بر حسب نقطه تعیین می‌شود، به‌طوری‌که ۷۲ نقطه معادل یک اینچ است. مقدار مثبت استفاده کنید، همان‌طور که مستندات API خواستارش است.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ فعلی شبکه را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ را تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

شبکه متفاوت از [drawing guides](/slides/fa/java/drawing-guides/) است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های ترسیم خطوط افقی یا عمودی موقعیت‌دار جداگانه‌ای دارند. اضافه، جابه‌جایی یا پاک‌سازی راهنمای‌های ترسیم فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمای‌های ترسیم، ابزارهای ویرایشی هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیره کردن فاصلهٔ شبکه تضمین نمی‌کند که یک ویرایشگر آن را نمایش دهد: قابلیت مشاهده آن نیز به تنظیمات ترجیحی بیننده یا ویرایشگر بستگی دارد.

## **سوالات متداول**

**چرا بعد از باز کردن مجدد ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر تصمیم می‌گیرد آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکهٔ ویرایشگر را بررسی کنید.

**آیا پاک‌سازی راهنمای‌های ترسیم فاصلهٔ شبکه را تغییر می‌دهد؟**

نه. راهنمای‌های ترسیم و فاصلهٔ شبکه تنظیمات مستقلی هستند. پاک‌سازی راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را تحت تأثیر قرار نمی‌دهد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعریف کنم؟**

[View settings](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه به‌صورت بخش‑به‑بخش، بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای مختلفی برای کاربران مختلف از پیش تعریف کنم؟**

نه. این تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک‌گذاری می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را اعمال کنند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف‌شده تهیه کنم تا ارائه‌های جدید به‌صورت یکسان باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب بگنجانید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.