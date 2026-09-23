---
title: بازیابی و به‌روزرسانی ویژگی‌های نمای ارائه در اندروید
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/androidjava/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای رئوس کلی
- آیکون‌های رئوس کلی
- قابلیت چسباندن جداساز عمودی
- نمای تک
- وضعیت نوار
- اندازهٔ بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای اندروید از طریق جاوا را کشف کنید تا قالب‌های PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوای کناری، و یک ناحیه محتوای پایین. ویژگی‌هایی مربوط به موقعیت‌یابی نواحی محتوا مختلف. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به طوری که هنگام بازگشایی، نمای آن در همان وضعیت باشد که آخرین بار ارائه ذخیره شده بود.

متد [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.

[INormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties) رابط‌ها و فرزندان آن، [SplitterBarStateType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType) enum اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید در صورتی که محتوای رئوس کلی را در هر یک از نواحی محتوا در حالت نمای عادی نمایش می‌دهد، آیکون‌ها را نشان دهد یا خیر.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) مشخص می‌کنند که آیا جداساز عمودی باید هنگام کافی کوچک بودن ناحیه کناری به حالت کمینه برسد یا خیر.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‑پنجره‌ای تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. اگر فعال باشد، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) حالت‌نمایی نوار جداساز افقی یا عمودی را که باید نمایش داده شود، مشخص می‌کنند. یک نوار جداساز افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند، نوار جداساز عمودی اسلاید را از ناحیه محتوای کناری جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیه اسلاید بالایی یا کناری در نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) اعمال شده است، مشخص می‌کنند.

## **درباره بازگردانی INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) است، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) است) در نمای عادی را زمانی که ناحیه دارای اندازه بازگردانده‌متغیر است (نه کمینه و نه بیشینه) مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازه ناحیه اسلاید را (عرض وقتی فرزند restoredTop است، ارتفاع وقتی فرزند restoredLeft است) مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تعیین می‌کند که آیا اندازه ناحیه محتوای کناری باید برای اندازه جدید ج compensation هنگام تغییر اندازه پنجره حاوی نمای داخل برنامه جبران کند یا نه.

یک مثال در ادامه نشان می‌دهد که چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

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

## **تنظیم مقدار بزرگنمایی پیش‌فرض**

{{% alert color="info" %}} 

Aspose.Slides برای Android از طریق Java اکنون از تنظیم مقدار بزرگنمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌گونه‌ای که هنگام باز شدن ارائه، بزرگنمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و همچنین [getNotesViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند برنامه‌نویسی شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) مربوط به [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) را در Aspose.Slides تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نمای، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. ویژگی‌های [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.
   در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // تنظیم ویژگی‌های نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگنمایی به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگنمایی به درصد برای نمای نوت‌ها 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم فاصله‌بندی شبکه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای کلی ارائه استفاده کنید. متدهای [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) و [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) فاصلهٔ شبکه ویرایشی پایه را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای یک اسلاید منفرد. فاصله شبکه بر حسب پوینت تعیین می‌شود که ۷۲ پوینت برابر یک اینچ است. مقدار مثبت استفاده کنید، همان‌طور که مستندات API می‌طلبند.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ شبکهٔ فعلی را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ تنظیم می‌کند و نتیجه را ذخیره می‌سازد.

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

شبکه متفاوت از [drawing guides](/slides/fa/androidjava/drawing-guides/) است. فاصلهٔ شبکه یک دورهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های ترسیم خطوط تراز افقی یا عمودی هستند که به‌صورت جداگانه موقعیت‌یابی می‌شوند. افزودن، جابه‌جایی یا پاک کردن راهنمای‌های ترسیم فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمای‌های ترسیم، ابزارهای کمکی ویرایش هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا ارائه اسلاید نمایش داده نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد: نمایش آن همچنین به تنظیمات نمایشگر یا ویرایشگر بستگی دارد.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای کلی ارائه استفاده کنید. از [IViewProperties.getShowComments](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) و [IViewProperties.setShowComments](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) برای خواندن یا تغییر ترجیح ذخیره‌شده برای اینکه آیا نظرات هنگام باز شدن ارائه در PowerPoint یا ویرایشگر سازگار دیگری نشان داده شوند یا نه، استفاده کنید.

این تنظیم تنها ترجیح ذخیره‌شدهٔ نمای را کنترل می‌کند. این کار نظرات را اضافه، حذف، ویرایش یا حل نمی‌کند. مخفی‌سازی نظرات محتوای آنها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌هایی که نظرات را تغییر می‌دهند، به [Presentation Comments](/slides/fa/androidjava/presentation-comments/) مراجعه کنید.

مثال زیر نیاز به یک فایل `comments.pptx` موجود دارد که حاوی نظرات باشد. تنظیمات قابل مشاهدهٔ فعلی را چاپ می‌کند، درخواست می‌کند که نظرات مخفی شوند و یک PPTX جدید را بدون حذف هیچ نظری ذخیره می‌کند. همچنین از [IViewProperties.setLastView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) همراه با [ViewType.SlideView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewtype/#SlideView) برای پیکربندی نمای ویرایش اولیه به‌همراه قابلیت مشاهدهٔ نظرات استفاده می‌کند.

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

این تنظیم تعیین نمی‌کند که آیا نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت یا جزوه گنجانده می‌شوند یا نه. گزینه‌های مخصوص هر نوع خروجی را به‌طور جداگانه پیکربندی کنید.

## **سؤالات متداول**

**چرا پس از باز کردن دوبارهٔ ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند که شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک‌کردن راهنمای‌های ترسیم فاصلهٔ شبکه را تغییر می‌دهد؟**

خیر. راهنمای‌های ترسیم و فاصلهٔ شبکه تنظیمات مستقلی هستند. پاک‌کردن راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را تغییر نمی‌دهد.

**آیا می‌توانم تنظیمات نمای متفاوت برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

تنظیمات [View settings](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه برای هر بخش، بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی برای کاربران مختلف پیش‌تعریف کنم؟**

خیر. این تنظیمات در فایل ذخیره می‌شوند و به اشتراک گذاشته می‌شوند. برنامه‌های نمایش ممکن است به تنظیمات کاربر احترام بگذارند، اما خود فایل فقط حاوی یک مجموعهٔ ویژگی‌های نمای است.

**آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجایی که [view properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در قالبی بگنجانید و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.