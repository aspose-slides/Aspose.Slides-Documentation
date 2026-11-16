---
title: بازیابی و به‌روزرسانی ویژگی‌های نمای ارائه در جاوااسکریپت
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/nodejs-java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قابلق عمودی اسنپ
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- زوم پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "از Aspose.Slides برای Node.js از طریق Java برای پیکربندی چیدمان نمای عادی، زوم اسلاید و یادداشت‌ها، فاصله‌گذاری شبکه و قابلیت مشاهده نظرات در ارائه‌های PowerPoint استفاده کنید."
---
## **معرفی**

در نمای عادی PowerPoint، اسلاید بین یک پانل جانبی برای تصویرهای کوچک یا نمای کلی و یک پانل یادداشت‌ها در زیر قرار می‌گیرد. Aspose.Slides برای Node.js از طریق Java تنظیمات ذخیره‌شده ویرایشی ارائه را از طریق [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) نمایش می‌دهد. این تنظیمات شامل چیدمان پانل، سطوح زوم، فاصله‌گذاری شبکه و نمایانی نظرات است.

## **درباره NormalViewProperties**

از [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) برای دسترسی به کلاس [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) استفاده کنید. [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) تعیین می‌کند که آیا نمادها در کنار عناوین اسلاید در نمای کلی نمایش داده شوند. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) به پانل جانبی اجازه می‌دهد هنگام باریک شدن توسط کاربر به حالت حداقل خود بچسبد. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) نشان‌دهنده ترجیح نمایش یک پانل در کل پنجره است.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) تقسیم‌کننده بین پانل جانبی و اسلاید را کنترل می‌کند. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) تقسیم‌کننده بالای پانل یادداشت‌ها را کنترل می‌کند. هر دو یک مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) که می‌تواند `Minimized`، `Maximized` یا `Restored` باشد، می‌پذیرند.

## **درباره بازیابی NormalViewProperties**

هنگام بازیابی یک تقسیم‌کننده، [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) اندازه ذخیره‌شده پانل جانبی را فراهم می‌کند و [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) اندازه ذخیره‌شده ناحیه بالایی اسلاید را فراهم می‌کند. هر دو [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/) را نمایش می‌دهند. متد [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) آن یک درصد بین 0 تا 100 می‌گیرد و [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) تعیین می‌کند که آیا ویرایشگر هنگام تغییر اندازه پنجره، اندازه را تنظیم کند یا نه.

این مثال یک ارائه موجود را به‌روزرسانی می‌کند. تقسیم‌کننده افقی را بازمی‌گرداند، اندازه‌ای که توسط [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) برگردانده می‌شود را به 80% با فعال بودن تنظیم خودکار تنظیم می‌کند و تقسیم‌کننده عمودی را به حالت حداکثر می‌رساند. همچنین [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) را برای نمایش نمادها در نمای کلی فراخوانی می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **تنظیم مقدار زوم پیش‌فرض**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) تنظیمات زوم مستقل برای ویرایشگر را ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح خروجی تصویر تأثیر نمی‌گذارند.

این مثال یک ارائه موجود را باز می‌کند و [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) را فراخوانی می‌کند تا اسلاید را با پنجره ویرایش تناسب دهد. برای صفحه یادداشت‌ها، مقیاس خودکار را غیرفعال می‌کند و [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) را برای تنظیم زوم ثابت 80% فراخوانی می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **تنظیم فاصله‌گذاری شبکه**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) فاصله بین خطوط شبکه ویرایشی در سراسر ارائه را تنظیم می‌کند. این مقدار یک عدد مثبت به واحد نقطه است، با 72 نقطه در هر اینچ. این مثال فاصله جاری را در یک ارائه موجود چاپ می‌کند و با تنظیم فاصله به 18 نقطه، شبکه‌ای به‌مدت یک‌چهارم اینچ ذخیره می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
شبکه با یک فاصله ثابت تکرار می‌شود. [Drawing guides](/slides/fa/nodejs-java/drawing-guides/) موقعیت‌های افقی یا عمودی جداگانه را علامت‌گذاری می‌کنند. هر دو ابزارهای کمکی ویرایشی هستند و فقط در ویرایشگرهایی که آنها را نمایش می‌دهند ظاهر می‌شوند. اسلایدشوها و خروجی‌های PDF، تصویر یا SVG آنها را حذف می‌کنند.

## **نمایش یا مخفی‌کردن نظرات هنگام باز کردن یک ارائه**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) یک ترجیح را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائه موجود با نظرات، این مثال تنظیم فعلی را چاپ می‌کند و یک کپی با نظرات مخفی ذخیره می‌کند. همچنین [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) را با [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) فراخوانی می‌کند تا کپی در نمای اسلاید باز شود.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
مخفی‌کردن نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آنها را حفظ می‌کند. برای تغییر خود نظرات، به [Presentation Comments](/slides/fa/nodejs-java/presentation-comments/) مراجعه کنید. تنظیمات خروجی تعیین می‌کنند که آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا جزوه‌ها ظاهر شوند یا نه.

## **سؤال‌های متداول**

**چرا شبکه هنگام باز کردن دوباره ارائه مخفی می‌شود؟**

ارائه فاصله‌گذاری شبکه را ذخیره می‌کند. برای دیدن شبکه، قابلیت مشاهده شبکه را در ویرایشگر فعال کنید.

**آیا پاک‌ کردن راهنمای‌های رسم بر فاصله‌گذاری شبکه تأثیر می‌گذارد؟**

خیر. افزودن، جابجا کردن یا پاک‌ کردن یک راهنما فاصله‌گذاری شبکه را تغییر نمی‌دهد.

**آیا بخش‌های مختلف یک ارائه می‌توانند تنظیمات نمای متفاوتی داشته باشند؟**

خیر. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) برای کل ارائه اعمال می‌شود.

**آیا می‌توانم تنظیمات نمای متفاوتی را برای کاربران مختلف ذخیره کنم؟**

فایل یک مجموعه تنظیمات نما را برای همه ذخیره می‌کند. یک ویرایشگر ممکن است ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توانم تنظیمات نما را در یک الگو ذخیره کنم؟**

بله. ارائه‌های ایجاد‌شده از این الگو، تنظیمات ذخیره‌شدهٔ آن را به ارث می‌برند.