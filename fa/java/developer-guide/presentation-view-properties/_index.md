---
title: بازیابی و به‌روزرسانی ویژگی‌های نمای ارائه در جاوا
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- نمادهای طرح کلی
- تقسیم‌کننده عمودی اسنپ
- نمای تک
- وضعیت نوار
- اندازه بعدی
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "از Aspose.Slides برای جاوا استفاده کنید تا چینش نمای عادی، بزرگنمایی اسلاید و یادداشت‌ها، فاصله‌بندی شبکه و قابل مشاهده بودن نظرات را در ارائه‌های پاورپوینت پیکربندی کنید."
---
## **مقدمه**

در نمای عادی پاورپوینت، اسلاید بین یک پنل کناری برای تصویرهای کوچک یا یک طرح کلی و پنل یادداشت‌ها در زیر ظاهر می‌شود. Aspose.Slides for Java تنظیمات ذخیره‌شدهٔ ویرایش ارائه را از طریق [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) در دسترس می‌گذارد. این تنظیمات شامل چینش پنل‌ها، سطوح بزرگنمایی، فاصله‌بندی شبکه و نمایش نظرات هستند.

## **درباره INormalViewProperties**

از [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) برای دسترسی به رابط [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) استفاده کنید. [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) تعیین می‌کند آیا آیکون‌ها در کنار عناوین اسلایدها در طرح کلی نمایش داده شوند یا نه. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) به پنل کناری اجازه می‌دهد وقتی کاربر آن را باریک می‌کند، به حالت کمینه خود بچسبد. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) نشان‌دهندهٔ ترجیح نمایش یک پنل در تمام پنجره است.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) تقسیم‌کننده بین پنل کناری و اسلاید را کنترل می‌کند. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) تقسیم‌کننده بالای پنل یادداشت‌ها را کنترل می‌کند. هر دو یک مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) با مقادیر `Minimized`، `Maximized` یا `Restored` می‌پذیرند.

## **درباره بازگردانی INormalViewProperties**

وقتی یک تقسیم‌کننده بازگردانده می‌شود، [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) اندازهٔ ذخیره‌شدهٔ پنل کناری را فراهم می‌کند و [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) اندازهٔ ذخیره‌شدهٔ ناحیهٔ بالایی اسلاید را فراهم می‌کند. هر دو [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/) را در دسترس می‌گذارند. متد [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) این رابط یک درصد بین ۰ تا ۱۰۰ می‌پذیرد و [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) تعیین می‌کند آیا ویرایشگر هنگام تغییر اندازهٔ پنجره، اندازه را تنظیم کند یا نه.

این مثال یک ارائهٔ موجود را به‌روز می‌کند. تقسیم‌کنندهٔ افقی را بازگردانی می‌کند، اندازهٔ برگردانده‌شده توسط [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) را به ۸۰٪ با فعال کردن تنظیم خودکار تنظیم می‌نماید و تقسیم‌کنندهٔ عمودی را به حداکثر می‌رساند. همچنین [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) را فراخوانی می‌کند تا آیکون‌ها در نمای طرح کلی نمایش داده شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **تنظیم مقدار پیش‌فرض بزرگنمایی**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) تنظیمات بزرگنمایی مستقل برای ویرایشگر ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح خروجی تصویر تأثیری ندارند.

این مثال یک ارائهٔ موجود را باز می‌کند و [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) را برای تناسب اسلاید با پنجره ویرایش فراخوانی می‌کند. برای صفحهٔ یادداشت‌ها، مقیاس‌گذاری خودکار را غیرفعال می‌کند و با فراخوانی [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) بزرگنمایی ثابت ۸۰٪ را تنظیم می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **تنظیم فاصله‌بندی شبکه**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) فاصله بین خطوط شبکهٔ ویرایشی در سراسر ارائه را تنظیم می‌کند. این مقدار یک مقدار مثبت بر حسب نقطه است که ۷۲ نقطه برابر یک اینچ است. این مثال فاصلهٔ فعلی را در یک ارائهٔ موجود چاپ می‌کند و با تعیین فاصلهٔ ۱۸ نقطه، یک شبکهٔ چهارم اینچی ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);
    
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
شبکه با فاصلهٔ ثابت تکرار می‌شود. [راهنمای رسم](/slides/fa/java/drawing-guides/) موقعیت‌های افقی یا عمودی جداگانه را علامت‌گذاری می‌کند. هر دو ابزارهای کمکی ویرایشی هستند و فقط در ویرایشگرهایی که نمایش می‌دهند ظاهر می‌شوند. نمایش اسلایدها و خروجی‌های PDF، تصویر یا SVG آنها را حذف می‌کند.

## **نمایش یا پنهان‌سازی نظرات هنگام باز کردن ارائه**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) یک ترجیح را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌نمایند. برای یک ارائهٔ موجود با نظرات، این مثال تنظیم فعلی را چاپ می‌کند و یک نسخه با نظرات پنهان ذخیره می‌نماید. همچنین [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) را با [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) فراخوانی می‌کند تا نسخه در نمای اسلاید باز شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
پنهان کردن نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آنها را حفظ می‌کند. برای تغییر خود نظرات، به [نظرات ارائه](/slides/fa/java/presentation-comments/) مراجعه کنید. تنظیمات خروجی تعیین می‌کند آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا جزوه‌ها ظاهر شوند.

## **پرسش‌های متداول**

**چرا شبکه هنگام بازگشایی مجدد ارائه مخفی می‌شود؟**  
ارائه فاصلهٔ شبکه را ذخیره می‌کند. برای مشاهدهٔ شبکه، نمایش شبکه را در ویرایشگر فعال کنید.

**آیا پاک‌کردن راهنمای رسم فاصلهٔ شبکه را تغییر می‌دهد؟**  
خیر. افزودن، جابجایی یا پاک‌کردن یک راهنما فاصلهٔ شبکه را بدون تغییر باقی می‌گذارد.

**آیا بخش‌های مختلف یک ارائه می‌توانند تنظیمات نمای مختلف داشته باشند؟**  
خیر. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) برای کل ارائه اعمال می‌شود.

**آیا می‌توانم تنظیمات نمای متفاوتی برای کاربران مختلف ذخیره کنم؟**  
فایل یک مجموعهٔ تنظیمات نمای برای همه ذخیره می‌کند. یک ویرایشگر ممکن است ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توانم تنظیمات نمای را در یک قالب ذخیره کنم؟**  
بله. ارائه‌های ساخته‌شده از این قالب، تنظیمات نمای ذخیره‌شدهٔ آن را به ارث می‌برند.