---
title: بازیابی و به‌روزرسانی خصوصیات نمای ارائه در اندروید
linktitle: خصوصیات نمای
type: docs
weight: 80
url: /fa/androidjava/presentation-view-properties/
keywords:
- خصوصیات نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای Android از طریق Java را کشف کنید تا فرمت‌های PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، ناحیه محتوا در سمت و ناحیه محتوا در پایین. ویژگی‌هایی که به موقعیت‌گذاری نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری‌که هنگام بازگشایی، نما در همان وضعیتی باشد که آخرین بار ارائه ذخیره شد.

متد[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.

[INormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties) رابط‌ها و فرزندان آن، و مقدارهای [SplitterBarStateType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType) هم اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش ویژگی‌های نمای عادی را نمایان می‌کند.

متدهای[getShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و[setShowOutlineIcons](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید در صورت نمایش محتوا به شکل ساختار در هر یک از نواحی محتوا در حالت نمای عادی، آیکون‌ها را نشان دهد یا نه.

متدهای[getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) تعیین می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیه کناری به حالت کمینه بچسبد یا نه.

ویژگی[getPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‌پنجره‌ای کامل به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه می‌تواند یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای[getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وضعیت نمایش نوار تقسیم‌کننده افقی یا عمودی را تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا در زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا در کنار جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

متدهای[getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و[getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) اندازه‌گیری ناحیه اسلاید بالایی یا کناری نمای عادی را وقتی مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SplitterBarStateType#Restored) برای[getVerticalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) اعمال شده باشد، تعیین می‌کند.

## **درباره بازیابی INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (پهنای آن هنگامی که فرزند[getRestoredTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) باشد، ارتفاع آن هنگامی که فرزند[getRestoredLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) باشد) را وقتی ناحیه در اندازه متغیر بازیابی شده (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

متد[getDimensionSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) اندازه ناحیه اسلاید (پهنای آن هنگامی که فرزند restoredTop باشد، ارتفاع آن هنگامی که فرزند restoredLeft باشد) را تعیین می‌کند.

متد[getAutoAdjust](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) مشخص می‌کند که آیا اندازه ناحیه محتوا در کنار باید برای اندازه جدید هنگام تغییر اندازه پنجره حاوی نما در برنامه جبران شود یا نه.

مثالی که در ادامه آورده شده نشان می‌دهد چگونه می‌توانید به ویژگی‌های[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) یک ارائه دسترسی پیدا کنید.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // بازگرداندن خصوصیات نمای ارائه
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **تنظیم مقدار مقیاس پیش‌فرض**

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java اکنون از تنظیم مقدار مقیاس پیش‌فرض برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، مقیاس از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) یک ارائه صورت گیرد. متدهای[getSlideViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌ای تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) را در [Aspose.Slides](/slides/fa/) تنظیم کنیم.

{{% /alert %}} 

برای تنظیم ویژگی‌های نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ViewProperties) را برای[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) تنظیم کنید.
1. ارائه را به عنوان فایل[PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.
   در مثال زیر، مقدار مقیاس را برای نمای اسلاید و نمای یادداشت‌ها تنظیم کرده‌ایم.

```java
Presentation presentation = new Presentation();
try {
    // تنظیم خصوصیات نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگنمایی به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگنمایی به درصد برای نمای یادداشت‌ها 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**آیا می‌توانم تنظیمات نمای مختلفی برای بخش‌های مختلف یک ارائه تعیین کنم؟**

[View settings](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)) و نه برای هر بخش، بنابراین یک مجموعه پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم وضعیت‌های نمای مختلفی را برای کاربران مختلف پیش‌تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را در نظر بگیرند، اما خود فایل فقط شامل یک مجموعه ویژگی‌های نمای است.

**آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف شده آماده کنم تا ارائه‌های جدید همان‌طور باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getViewProperties--) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب قرار داده و اسناد جدید را از آن با همان پیکربندی اولیه نمایش ایجاد کنید.