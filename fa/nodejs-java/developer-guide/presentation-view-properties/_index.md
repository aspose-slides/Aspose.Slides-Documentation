---
title: دریافت و به‌روزرسانی خصوصیات نمای ارائه در جاوااسکریپت
linktitle: خصوصیات نمای
type: docs
weight: 80
url: /fa/nodejs-java/presentation-view-properties/
keywords:
- خصوصیات نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل‌کردن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازهٔ بعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "با Aspose.Slides برای Node.js از طریق ویژگی‌های نمای جاوا، فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگ‌نمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، یک ناحیه محتوا کناری، و یک ناحیه محتوا زیرین. خصوصیات مربوط به موقعیت‌یابی نواحی مختلف محتوا. این اطلاعات به برنامه امکان می‌دهد حالت نمای خود را در فایل ذخیره کند، به‌گونه‌ای که هنگام بازگشایی، نما در همان وضعیت باشد که آخرین بار ارائه ذخیره شده بود.

متد [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) اضافه شده است تا دسترسی به خصوصیات نمای عادی ارائه را فراهم کند. 

[NormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties) کلاس و نسل‌های آن، و enum [SplitterBarStateType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType) اضافه شده‌اند.

## **درباره NormalViewProperties**

نمایش‌دهندهٔ خصوصیات نمای عادی.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) مشخص می‌کنند که آیا برنامه باید در صورت نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) مشخص می‌کنند که آیا تقسیم‌کننده عمودی باید وقتی ناحیهٔ کناری به اندازه کافی کوچک باشد، به حالت کوچک‌شده قفل شود یا نه.

ویژگی‌های [getPreferSingleView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ تک‌محتوا با تمام‑پنجره را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) وضعیت نوار تقسیم‌کنندهٔ افقی یا عمودی را که باید نمایش داده شود، مشخص می‌کنند. یک نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوای کناری جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) ابعاد ناحیهٔ بالایی یا کناری اسلاید در نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SplitterBarStateType#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) اعمال شده باشد، مشخص می‌کنند.

## **درباره بازگردانی NormalViewProperties** 

ابعاد ناحیهٔ اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) باشد) در نمای عادی را زمانی که ناحیه دارای اندازهٔ بازگردانده متغیری باشد (نه کوچک‌شده و نه بزرگ‌شده) مشخص می‌کند. 

متد [getDimensionSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) اندازهٔ ناحیهٔ اسلاید را (عرض وقتی که فرزند restoredTop باشد، ارتفاع وقتی که فرزند restoredLeft باشد) مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) مشخص می‌کند که آیا اندازهٔ ناحیهٔ محتوای کناری باید برای اندازهٔ جدید جبران شود هنگامی که پنجرهٔ حاوی نما در برنامه تغییر اندازه می‌دهد یا نه.

مثالی که در زیر آورده شده است نشان می‌دهد چگونه می‌توانید به خصوصیات [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) برای یک ارائه دسترسی پیدا کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // بازگرداندن خصوصیات نمای ارائه
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **تنظیم مقدار بزرگ‌نمایی پیش‌فرض**

{{% alert color="info" %}} 

Aspose.Slides برای Node.js از طریق Java اکنون از تنظیم مقدار پیش‌فرض بزرگ‌نمایی برای ارائه پشتیبانی می‌کند به‌طوری‌که هنگامی‌که ارائه باز می‌شود، بزرگ‌نمایی از پیش تنظیم شده باشد. این می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) در Aspose.Slides تنظیم کنیم.

{{% /alert %}} 

برای تنظیم خصوصیات نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ViewProperties) را برای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) تنظیم کنید.
1. ارائه را به‌عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید. در مثال زیر، مقدار بزرگ‌نمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // تنظیم خصوصیات نمای ارائه
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمای اسلاید
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // مقدار بزرگ‌نمایی به درصد برای نمای یادداشت‌ها
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم فاصله شبکه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) و [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) فاصلهٔ شبکهٔ ویرایش زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای تمام ارائه اعمال می‌شود، نه برای یک اسلاید جداگانه. فاصلهٔ شبکه بر حسب نقاط مشخص می‌شود که ۷۲ نقطه معادل یک اینچ است. از مقدار مثبت استفاده کنید، همان‌طور که مستندات API خواسته است.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ کنونی شبکه را چاپ می‌کند، یک فاصلهٔ یک‌چهارم اینچ تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

شبکه با [drawing guides](/slides/fa/nodejs-java/drawing-guides/) متفاوت است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمایی‌های رسم خطوطی افقی یا عمودی هستند که به صورت جداگانه موقعیت‌یابی می‌شوند. افزودن، جابه‌جایی یا حذف راهنمایی‌های رسم، فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمایی‌های رسم، کمک‌های ویرایشی هستند. آن‌ها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیره‌کردن فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر شبکه را نشان دهد: قابلیت دیده شدن آن نیز به تنظیمات نمایشگر یا ویرایشگر بستگی دارد.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getViewProperties--) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. از [ViewProperties.getShowComments](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#getShowComments--) و [ViewProperties.setShowComments](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) برای خواندن یا تغییر ترجیح ذخیره‌شدهٔ اینکه آیا نظرات هنگام باز شدن ارائه در PowerPoint یا ویرایشگر سازگار دیگر نمایش داده شوند یا نه، استفاده کنید.

این تنظیم فقط ترجیح ذخیره‌شدهٔ نمای را کنترل می‌کند. این کار نظرات را اضافه، حذف، ویرایش یا رفع نمی‌کند. مخفی‌سازی نظرات محتوای آن‌ها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌هایی که خود نظرات را تغییر می‌دهند، به [Presentation Comments](/slides/fa/nodejs-java/presentation-comments/) مراجعه کنید.

مثال زیر به یک فایل `comments.pptx` موجود که حاوی نظرات است، نیاز دارد. این برنامه تنظیمات فعلی قابلیت دیده شدن را چاپ می‌کند، درخواست مخفی‌سازی نظرات می‌کند و یک PPTX جدید را بدون حذف نظرات ذخیره می‌کند. همچنین از [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) همراه با [ViewType.SlideView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewtype/#SlideView) برای پیکربندی نمای ویرایشی اولیه به‌همراه قابلیت دیده شدن نظرات استفاده می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این تنظیم تعیین نمی‌کند که آیا نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت‌ها یا جزوه‌ها گنجانده شوند یا نه. گزینه‌های خاص هر نوع خروجی را به‌صورت جداگانه تنظیم کنید.

## **سوالات متداول**

**چرا پس از باز کردن مجدد ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات قابلیت مشاهدهٔ شبکه در ویرایشگر را بررسی کنید.

**آیا حذف راهنمایی‌های رسم فاصلهٔ شبکه را تغییر می‌دهد؟**

خیر. راهنمایی‌های رسم و فاصلهٔ شبکه تنظیمات مستقلی هستند. حذف راهنمایی‌ها بازهٔ ذخیره‌شدهٔ شبکه را دست نخورده می‌گذارد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

تنظیمات [View settings](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))، نه به‌ازای هر بخش؛ بنابراین یک مجموعهٔ پارامتر واحد برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی برای کاربران مختلف از پیش تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیح‌های کاربر را رعایت کنند، اما خود فایل تنها یک مجموعهٔ خصوصیات نمای را دارد.

**آیا می‌توانم یک الگو با View Properties از پیش تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. زیرا [view properties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getviewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب گنجانده و اسناد جدید را از آن با همان پیکربندی نمای اولیه ایجاد کنید.