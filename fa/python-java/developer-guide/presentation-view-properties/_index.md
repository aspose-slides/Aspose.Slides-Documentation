---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در پایتون از طریق جاوا
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/python-java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- نمادهای طرح کلی
- قاب عمودی اسنپ
- نمای تک
- وضعیت میله
- اندازهٔ ابعاد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "از Aspose.Slides برای پایتون از طریق جاوا استفاده کنید تا طرح‌بندی نمای عادی، بزرگنمایی اسلاید و یادداشت‌ها، فاصله‌بندی شبکه و قابلیت نمایش نظرات را در ارائه‌های PowerPoint تنظیم کنید."
---
## **معرفی**

در نمای عادی PowerPoint، اسلاید بین پانل کناری برای بندهای کوچک یا طرح کلی و پانل یادداشت‌ها در پایین نمایش داده می‌شود. Aspose.Slides برای Python از طریق Java ترجیحات ذخیره‌شدهٔ ویرایش ارائه را از طریق [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) آشکار می‌کند. این‌ها شامل چیدمان پانل‌ها، سطوح زوم، فاصله‌بندی شبکه و قابلیت نمایش نظرات هستند.

## **درباره NormalViewProperties**

از [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای دسترسی به کلاس [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) استفاده کنید. [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) تعیین می‌کند آیا نمادها در کنار عناوین اسلاید در طرح کلی نمایش داده شوند یا نه. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) اجازه می‌دهد پانل کناری هنگام باریک شدن توسط کاربر به حالت کوچک شده خود بپیچد. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) نشان‌دهندهٔ تمایل به نمایش یک پانل در تمام پنجره است.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) تقسیم‌کننده بین پانل کناری و اسلاید را کنترل می‌کند. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) تقسیم‌کننده بالای پانل یادداشت‌ها را تنظیم می‌کند. هر دو مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) با گزینه‌های `Minimized`، `Maximized` یا `Restored` می‌پذیرند.

## **درباره بازگرداندن NormalViewProperties**

زمانی که یک تقسیم‌کننده بازگردانی می‌شود، [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) اندازهٔ ذخیره‌شدهٔ پانل کناری و [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) اندازهٔ ذخیره‌شدهٔ ناحیهٔ بالایی اسلاید را برمی‌گرداند. هر دو یک نمونه از [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) باز می‌گردانند. متد [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) درصدی بین ۰ تا ۱۰۰ می‌پذیرد و [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) تعیین می‌کند آیا ویرایشگر هنگام تغییر اندازهٔ پنجره اندازه را تنظیم کند یا نه.

این مثال یک ارائه موجود را به‌روزرسانی می‌کند. تقسیم‌کنندهٔ افقی را بازگردانی می‌کند، اندازهٔ بازگردانده‌شدهٔ توسط [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) را به ۸۰٪ تنظیم می‌کند و تنظیم خودکار را فعال می‌سازد، و تقسیم‌کنندهٔ عمودی را به حالت حداکثر می‌رساند. همچنین [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) را فراخوانی می‌کند تا نمادها در نمای طرح کلی نمایش داده شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم مقدار پیش‌فرض زوم**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) تنظیمات زوم مستقلی برای ویرایشگر ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح صادرات تصویر تأثیر نمی‌گذارند.

این مثال یک ارائه موجود را باز می‌کند و با فراخوانی [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) اسلاید را با پنجرهٔ ویرایش هم‌ اندازه می‌کند. برای صفحهٔ یادداشت‌ها، مقیاس خودکار را غیرفعال می‌کند و با فراخوانی [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) زوم ثابت ۸۰٪ را تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم فاصله‌بندی شبکه**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) فاصله بین خطوط شبکهٔ ویرایشی را در کل ارائه تنظیم می‌کند. مقدار مثبت بر حسب نقطه دریافت می‌کند که هر اینچ ۷۲ نقطه دارد. این مثال فاصلهٔ جاری را در یک ارائه موجود چاپ می‌کند و با تنظیم فواصل به ۱۸ نقطه، شبکه‌ای به اندازهٔ یک‌چهارم اینچ ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

شبکه با فاصلهٔ ثابتی تکرار می‌شود. [Drawing guides](/slides/fa/python-java/drawing-guides/) موقعیت‌های افقی یا عمودی فردی را علامت‌گذاری می‌کنند. هر دو ابزار کمکی برای ویرایش هستند و فقط در ویرایشگرهایی که آنها را نشان می‌دهند ظاهر می‌شوند. نمایش اسلایدها و صادرات به PDF، تصاویر یا SVG آنها را حذف می‌کند.

## **نمایش یا عدم نمایش نظرات هنگام باز کردن ارائه**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) ترجیحی را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائه موجود با نظرات، این مثال تنظیم فعلی را چاپ می‌کند و یک نسخهٔ کپی با نظرات مخفی ذخیره می‌کند. همچنین با فراخوانی [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) همراه با [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) باعث می‌شود نسخهٔ کپی در نمای اسلاید باز شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

پنهان کردن نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آنها را حفظ می‌کند. برای تغییر خود نظرات، به [Presentation Comments](/slides/fa/python-java/presentation-comments/) مراجعه کنید. تنظیمات صادرات تعیین می‌کند آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا برگه‌های تک‌صفحه ظاهر شوند یا نه.

## **سوالات متداول**

**چرا شبکه هنگام بازگشایی دوبارهٔ ارائه مخفی می‌شود؟**

ارائه فاصلهٔ شبکه را ذخیره می‌کند. برای مشاهدهٔ شبکه، قابلیت نمایش شبکه را در ویرایشگر فعال کنید.

**آیا حذف راهنمای رسم تغییر فاصلهٔ شبکه را ایجاد می‌کند؟**

خیر. افزودن، جابه‌جا یا حذف یک راهنما، فاصلهٔ شبکه را تغییری نمی‌دهد.

**آیا می‌توان تنظیمات نمای متفاوت برای بخش‌های مختلف ارائه داشت؟**

خیر. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) برای کل ارائه اعمال می‌شود.

**آیا می‌توان تنظیمات نمای متفاوتی برای کاربران مختلف ذخیره کرد؟**

فایل یک مجموعهٔ تنظیمات نمای برای همه ذخیره می‌کند. یک ویرایشگر ممکن است ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توان تنظیمات نمای را در قالب ذخیره کرد؟**

بله. ارائه‌های ساخته‌شده از قالب، تنظیمات نمای ذخیره‌شدهٔ آن قالب را به ارث می‌برند.