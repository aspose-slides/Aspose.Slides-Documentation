---
title: "دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در اندروید"
linktitle: "ویژگی‌های نمای"
type: docs
weight: 80
url: /fa/androidjava/presentation-view-properties/
keywords:
- "ویژگی‌های نمای"
- "نمای عادی"
- "محتوای طرح کلی"
- "آیکون‌های طرح کلی"
- "قفل‌گذاری تقسیم‌کننده عمودی"
- "نمای تک"
- "وضعیت نوار"
- "اندازه بُعد"
- "تنظیم خودکار"
- "بزرگنمایی پیش‌فرض"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "ویژگی‌های نمای Aspose.Slides برای اندروید از طریق جاوا را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، یک ناحیه محتوای جانبی، و یک ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌گذاری نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری که هنگام بازگشایی، نما در همان وضعیتی باشد که ارائه آخرین بار ذخیره شده بود.

متد [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.

[INormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties) رابط‌ها و انواع مشتق‌شده آنها، enum [SplitterBarStateType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌دهنده ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید آیکن‌ها را هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) مشخص می‌کنند که آیا تقسیم‌کننده عمودی باید وقتی ناحیه جانبی به اندازه کافی کوچک باشد، به حالت کمینه (Minimized) بچسبد یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک در تمام پنجره ببیند به‌جای نمای عادی استاندارد با سه ناحیه محتوا. اگر فعال باشد، برنامه می‌تواند یکی از نواحی محتوا را در کل پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وضعیت نوار تقسیم‌کننده عمودی یا افقی که باید نمایش داده شود را مشخص می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوای زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیه بالایی یا جانبی اسلاید در نمای عادی را مشخص می‌کنند، زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) به‌طور متناسب اعمال شده باشد.

## **درباره بازگردانی INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) در نمای عادی را مشخص می‌کند، زمانی که ناحیه دارای اندازه بازگردانده‌شده متغیر (نه کمینه و نه بیشینه) باشد.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازه ناحیه اسلاید (عرض وقتی فرزند restoredTop، ارتفاع وقتی فرزند restoredLeft) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) مشخص می‌کند که آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید هنگام تغییر اندازه پنجره‌ای که نما را در برنامه دربر می‌گیرد، جبران کند یا نه.

مثالی که در ادامه آورده شده است نشان می‌دهد چگونه می‌توانید به ویژگی‌های [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

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

Aspose.Slides برای Android از طریق Java اکنون از تنظیم مقدار بزرگنمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز شدن ارائه، بزرگنمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) یک ارائه انجام شود. [getSlideViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و همچنین [getNotesViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به صورت برنامه‌نویسی تنظیم شوند. در این بخش، با یک مثال خواهیم دید چگونه [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) در [Aspose.Slides](/slides/fa/) تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. ویژگی‌های [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.
   در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // تنظیم ویژگی‌های نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگنمایی به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگنمایی به درصد برای نمای یادداشت‌ها 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

### آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟

تنظیمات نمای ([View settings](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--)) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))، نه برای هر بخش. بنابراین یک مجموعهٔ واحد از پارامترها برای تمام سند هنگام باز شدن اعمال می‌شود.

### آیا می‌توانم حالت‌های نمای متفاوتی را برای کاربران مختلف از پیش تعریف کنم؟

خیر. این تنظیمات در فایل ذخیره می‌شوند و مشترک هستند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل فقط یک مجموعهٔ ویژگی‌های نمای را شامل می‌شود.

### آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟

بله. از آنجا که [view properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب جای‌گذاری کنید و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.