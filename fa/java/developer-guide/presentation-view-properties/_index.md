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
- چسباندن تقسیم‌کننده عمودی
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
description: "ویژگی‌های نمای Aspose.Slides برای جاوا را کشف کنید تا فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی‌سازی کنید - چیدمان‌ها، سطح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوایی است: اسلاید خود، ناحیه محتوای جانبی، و ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌گذاری نواحی محتوایی مختلف مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری‌که هنگام بازگشایی، نمای همان وضعیت آخرین بار ذخیره شده را داشته باشد.

متد [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties) و فرزندان آن، و نوع شمارشی [SplitterBarStateType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند آیا برنامه باید در صورت نمایش محتوای طرح کلی در هر یک از نواحی محتوایی حالت نمای عادی، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) مشخص می‌کنند آیا تقسیم‌کننده عمودی باید وقتی ناحیه جانبی به اندازه کافی کوچک باشد، به حالت کم‌حدود snap کند یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) مشخص می‌کنند آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‌پنجره‌ای تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوایی ببیند. اگر فعال باشد، برنامه ممکن است یکی از نواحی محتوایی را در کل پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وضعیت نشان‌دهی نوار تقسیم‌کننده افقی یا عمودی را مشخص می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوای زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیه بالایی یا جانبی نمای عادی را تعیین می‌کنند، وقتی مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) به‌کار گرفته شده باشد.

## **درباره بازگردانی INormalViewProperties** 

اندازه‌گیری ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) باشد، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) باشد) در نمای عادی را مشخص می‌کند، وقتی ناحیه دارای اندازه بازگردانی متغیر (نه کم‌حدود و نه بیشینه) باشد.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازه ناحیه اسلاید (عرض وقتی فرزند restoredTop باشد، ارتفاع وقتی فرزند restoredLeft باشد) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تعیین می‌کند آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید هنگام تغییر اندازه پنجره حاوی نمای داخل برنامه جبران کند یا خیر.

مثالی که در ادامه آورده شده نشان می‌دهد چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

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

## **تنظیم مقدار زوم پیش‌فرض**

{{% alert color="info" %}} 

Aspose.Slides for Java اکنون امکان تنظیم مقدار زوم پیش‌فرض برای ارائه را فراهم می‌کند به‌طوری‌که هنگام باز کردن ارائه، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties] یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به صورت برنامه‌نویسی تنظیم شوند. در این بخش، با مثال خواهیم دید چگونه [View Properties] را برای [Presentation] در Aspose.Slides تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.
   در مثال زیر، مقدار زوم برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

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

## **تنظیم فاصله‌بندی شبکه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#getGridSpacing--) و [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) فواصل شبکه ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای یک اسلاید خاص. فاصله‌بندی شبکه بر حسب پوینت مشخص می‌شود؛ ۷۲ پوینت برابر یک اینچ است. بر حسب مستندات API، از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصله‌بندی فعلی شبکه را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ را تنظیم می‌نماید و نتیجه را ذخیره می‌کند.

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

شبکه با [drawing guides](/slides/fa/java/drawing-guides/) متفاوت است. فاصله‌بندی شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های رسم به‌صورت خطوط افقی یا عمودی به‌صورت جداگانه موقعیت‌یابی می‌شوند. افزودن، جابجا کردن یا حذف راهنمای‌های رسم فاصله‌بندی شبکه را تغییر نمی‌دهد.

هم شبکه و هم راهنمای‌های رسم به‌عنوان ابزارهای ویرایش عمل می‌کنند. آن‌ها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیره‌سازی فاصله‌بندی شبکه تضمین نمی‌کند که یک ویرایشگر شبکه را نشان دهد؛ نمایش آن نیز به تنظیمات نمایشگر یا ویرایشگر وابسته است.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. با استفاده از [IViewProperties.getShowComments](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#getShowComments--) و [IViewProperties.setShowComments](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) می‌توانید تنظیمات ذخیره‌شدهٔ اینکه نظرات هنگام باز شدن ارائه در PowerPoint یا ویرایشگر سازگار دیگر نمایش داده شوند یا نه را بخوانید یا تغییر دهید.

این تنظیم فقط ترجیح نمای ذخیره‌شده را کنترل می‌کند. افزودن، حذف، ویرایش یا رفع نظرات را انجام نمی‌دهد. مخفی‌سازی نظرات محتوای آن‌ها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌هایی که خود نظرات را تغییر می‌دهند، به [Presentation Comments](/slides/fa/java/presentation-comments/) مراجعه کنید.

مثال زیر به یک فایل `comments.pptx` موجود که شامل نظرات است نیاز دارد. وضعیت فعلی نمایش نظرات را چاپ می‌کند، درخواست مخفی‌سازی نظرات را می‌فرستد و یک PPTX جدید را بدون حذف هیچ نظری ذخیره می‌کند. همچنین از [IViewProperties.setLastView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iviewproperties/#setLastView-int-) همراه با [ViewType.SlideView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewtype/#SlideView) برای پیکربندی نمای ویرایشی اولیه به‌همراهمرئیّت نظرات استفاده می‌کند.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این تنظیم تعیین نمی‌کند که نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت یا جزوه گنجانده شوند یا نه. گزینه‌های مربوط به هر نوع خروجی را به‌صورت جداگانه پیکربندی کنید.

## **سوالات متداول**

**چرا پس از بازکردن مجدد ارائه، شبکه نمایش داده نمی‌شود؟**

فایل فاصله‌بندی شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک‌سازی راهنمای‌های رسم فاصله‌بندی شبکه را تغییر می‌دهد؟**

خیر. راهنمای‌های رسم و فاصله‌بندی شبکه تنظیمات مستقلی هستند. پاک‌سازی راهنماها بازهٔ ذخیره‌شدهٔ شبکه را تغییر نمی‌دهد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعیین کنم؟**

تنظیمات نمای در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه به‌صورت بخش به بخش؛ بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی را برای کاربران مختلف از پیش تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و مشترک هستند. برنامه‌های مشاهده ممکن است ترجیحات کاربر را در نظر بگیرند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را دارد.

**آیا می‌توانم یک قالب با ویژگی‌های نمای پیش‌تعریف‌شده تهیه کنم تا ارائه‌های جدید به‌همین شکل باز شوند؟**

بله. از آنجایی که [view properties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب قرار دهید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.