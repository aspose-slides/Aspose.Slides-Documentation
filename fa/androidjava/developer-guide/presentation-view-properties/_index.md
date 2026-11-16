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
- قفل‌کننده عمودی کشویی
- نمای تک
- وضعیت نوار
- اندازه‌ی ابعاد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "از Aspose.Slides برای اندروید از طریق جاوا برای پیکربندی طرح‌بندی نمای عادی، بزرگنمایی اسلاید و یادداشت‌ها، فاصله‌بندی شبکه و قابلیت مشاهده نظرات در ارائه‌های PowerPoint استفاده کنید."
---
## **مقدمه**

در نمای عادی پاورپوینت، اسلاید بین پانل کناری برای تصاویر کوچک یا طرح کلی و پانل یادداشت‌های زیرین نمایش داده می‌شود. Aspose.Slides برای Android از طریق Java ترجیحات ذخیره شده ویرایش ارائه را از طریق [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) در دسترس قرار می‌دهد. این موارد شامل طرح‌بندی پانل، سطوح زوم، فاصله‌بندی شبکه و قابل مشاهده بودن نظرات است.

## **درباره INormalViewProperties**

از [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) برای دسترسی به رابط [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) استفاده کنید. [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) کنترل می‌کند که آیا نمادها در کنار عناوین اسلاید در طرح کلی ظاهر می‌شوند یا نه. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) اجازه می‌دهد پانل کناری هنگام باریک شدن توسط کاربر به حالت حداقل خود محو شود. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) نشان‌دهنده ترجیح برای نمایش یک پانل در تمام پنجره است.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) تقسیم‌کننده بین پانل کناری و اسلاید را کنترل می‌کند. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) تقسیم‌کننده بالای پانل یادداشت‌ها را کنترل می‌کند. هر دو مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) که می‌تواند `Minimized`، `Maximized` یا `Restored` باشد را می‌پذیرند.

## **درباره بازیابی INormalViewProperties**

هنگامی که یک تقسیم‌کننده بازسازی می‌شود، [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) اندازه ذخیره‌شده پانل کناری و [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) اندازه ذخیره‌شده ناحیه بالایی اسلاید را فراهم می‌کند. هر دو [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/) را در دسترس می‌گذارند. متد [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) درصدی بین 0 تا 100 می‌پذیرد و [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) تعیین می‌کند که آیا ویرایشگر هنگام تغییر اندازه پنجره اندازه را تنظیم می‌کند یا نه.

این مثال یک ارائه موجود را به‌روز می‌کند. تقسیم‌کننده افقی را بازسازی می‌کند، اندازه‌ای که توسط [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) برگردانده شده را به 80% با فعال بودن تنظیم خودکار تنظیم می‌کند و تقسیم‌کننده عمودی را به حداکثر می‌رساند. همچنین [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) را برای نمایش نمادها در نمای طرح کلی فراخوانی می‌کند.

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

## **تنظیم مقدار پیش‌فرض زوم**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) تنظیمات زوم مستقل برای ویرایشگر ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلاید شو یا وضوح خروجی تصویر تأثیری ندارند.

این مثال یک ارائه موجود را باز می‌کند و [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) را برای متناسب کردن اسلاید با پنجره ویرایش فراخوانی می‌کند. برای صفحه یادداشت‌ها، مقیاس‌گذاری خودکار را غیرفعال می‌کند و [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) را برای تنظیم زوم ثابت 80% صدا می‌زند.

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

## **تنظیم فواصل شبکه**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) فاصله بین خطوط شبکه ویرایشی را در تمام ارائه تنظیم می‌کند. این مقدار یک مقدار مثبت بر حسب نقطه است، با 72 نقطه در هر اینچ. این مثال فاصله فعلی را در یک ارائه موجود چاپ می‌کند و با تنظیم فاصله به 18 نقطه، شبکه‌ای یک چهارم اینچی ذخیره می‌کند.

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

شبکه با فواصل ثابت تکرار می‌شود. [Drawing guides](/slides/fa/androidjava/drawing-guides/) موقعیت‌های افقی یا عمودی فردی را علامت‌گذاری می‌کنند. هر دو ابزارهای کمکی ویرایشی هستند و فقط در ویرایشگرهایی که آنها را نشان می‌دهند ظاهر می‌شوند. اسلاید شوها و خروجی به PDF، تصاویر یا SVG اینها را حذف می‌کنند.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) ترجیحی را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائه موجود که نظرات دارد، این مثال تنظیم فعلی را چاپ می‌کند و یک نسخه با نظرات مخفی ذخیره می‌کند. همچنین [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) را همراه با [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) صدا می‌زند تا نسخه در نمای اسلاید باز شود.

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

مخفی‌سازی نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آنها را حفظ می‌کند. برای تغییر خود نظرات، به [Presentation Comments](/slides/fa/androidjava/presentation-comments/) مراجعه کنید. تنظیمات خروجی تعیین می‌کند که آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا جزوات ظاهر می‌شوند یا نه.

## **سؤالات متداول**

**چرا شبکه هنگام باز کردن مجدد ارائه مخفی می‌شود؟**

ارائه فاصله شبکه را ذخیره می‌کند. برای مشاهده شبکه، قابلیت نمایش شبکه را در ویرایشگر فعال کنید.

**آیا پاک‌کردن راهنمای رسم فاصله شبکه را تغییر می‌دهد؟**

خیر. افزودن، جابجایی یا پاک‌کردن یک راهنما فاصله شبکه را بدون تغییر می‌گذارد.

**آیا بخش‌های مختلف یک ارائه می‌توانند تنظیمات نمای متفاوتی داشته باشند؟**

خیر. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) بر کل ارائه اعمال می‌شود.

**آیا می‌توانم تنظیمات نمای متفاوتی برای کاربران مختلف ذخیره کنم؟**

فایل یک مجموعه تنظیمات نمای برای همه ذخیره می‌کند. یک ویرایشگر ممکن است ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توانم تنظیمات نمای را در الگو ذخیره کنم؟**

بله. ارائه‌های ساخته‌شده از الگو، تنظیمات نمای ذخیره‌شده آن را به ارث می‌برند.