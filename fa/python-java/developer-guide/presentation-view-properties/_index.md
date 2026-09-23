---
title: دریافت و به‌روزرسانی ویژگی‌های نمایش ارائه در پایتون از طریق جاوا
linktitle: ویژگی‌های نمایش
type: docs
weight: 80
url: /fa/python-java/presentation-view-properties/
keywords:
- ویژگی‌های نمایش
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تکی
- وضعیت نوار
- اندازه ابعادی
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ویژگی‌های نمایش Aspose.Slides برای پایتون از طریق جاوا را کشف کنید تا اسلایدهای PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **معرفی**

نمای عادی متشکل از سه ناحیه محتوا است: اسلاید خودش، یک ناحیه محتوا در کنار و یک ناحیه محتوا در پایین. ویژگی‌های نمای عادی موقعیت این نواحی محتوا را توصیف می‌کنند. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند تا هنگام بازگشایی، نمای همان‌گونه باشد که آخرین بار ارائه ذخیره شده بود.

متد [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای دسترسی به ویژگی‌های نمای عادی یک ارائه اضافه شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/) و [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/) و شمارش‌گر [SplitterBarStateType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره NormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) تعیین می‌کنند که آیا برنامه باید در صورتی که محتوای طرح کلی را در هر یک از نواحی محتوا در حالت نمای عادی نمایش می‌دهد، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) تعیین می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیه جانب به حالت کمینه بچسبد یا خیر.

متدهای [getPreferSingleView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) و [setPreferSingleView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) مشخص می‌کنند که آیا کاربر ترجیح می‌دهد ناحیه محتوا تک‌پنجره‌ای تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. در صورت فعال بودن، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) وضعیت نشان‌دادن نوار تقسیم‌کننده افقی یا عمودی را مشخص می‌کنند. یک نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند؛ یک نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا در سمت جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) و [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) ابعاد ناحیه اسلاید کناری یا بالایی نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) اعمال می‌شود، تعیین می‌کنند.

## **درباره بازگرداندن NormalViewProperties**

ابعاد ناحیه اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) است، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) است) نمای عادی را زمانی که ناحیه دارای اندازه متغیر بازگردانده شده (نه کمینه‌ و نه بیشینه) باشد، مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) اندازه ناحیه اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) است، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) است) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) تعیین می‌کند که آیا اندازه ناحیه محتوا جانبی باید برای اندازه جدید هنگام تغییر اندازه پنجره‌ای که نمای داخل برنامه در آن قرار دارد، جبران شود یا نه.

نمونه زیر نشان می‌دهد که چگونه به [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای یک ارائه دسترسی پیدا کنیم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # بازگرداندن ویژگی‌های نمای ارائه.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم مقدار پیش‌فرض بزرگنمایی**

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Python از طریق Java امکان تنظیم مقدار پیش‌فرض بزرگنمایی را فراهم می‌کند تا هنگام باز شدن ارائه، این مقدار از پیش اعمال شده باشد. این کار با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) یک ارائه انجام می‌شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNotesViewProperties) می‌توانند به‌صورت برنامه‌نویسی پیکربندی شوند. در این موضوع، یک مثال می‌بینیم که چگونه [View Properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) را برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) در Aspose.Slides تنظیم کنیم.
{{% /alert %}}

برای تنظیم ویژگی‌های نما، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) را برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) تنظیم کنید.
1. ارائه را به‌عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.

در مثال زیر مقدار بزرگنمایی را برای هر دو نمای اسلاید و نمای یادداشت‌ها تنظیم می‌کنیم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # تنظیم ویژگی‌های نمای ارائه.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # درصد بزرگنمایی برای نمای اسلاید.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # درصد بزرگنمایی برای نمای یادداشت‌ها.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم فاصله‌گذاری شبکه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getGridSpacing) و [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setGridSpacing) فاصله‌ی شبکه ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای کل ارائه اعمال می‌شود، نه برای اسلاید جداگانه. فاصله‌گذاری شبکه بر حسب نقطه مشخص می‌شود که ۷۲ نقطه معادل یک اینچ است. همان‌طور که مستندات API بیان می‌کند، از مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصله‌گذاری شبکه فعلی را چاپ می‌کند، فاصله یک‌چهارم اینچ تنظیم می‌نماید و نتیجه را ذخیره می‌کند.

```python
import jpile
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

شبکه با [راهنمای‌های رسم](/slides/fa/python-java/drawing-guides/) متفاوت است. فاصله‌گذاری شبکه یک بازه منظم را کنترل می‌کند، در حالی که راهنمای‌های رسم خطوط افقی یا عمودی موقعیت‌یابی شده به‌صورت جداگانه هستند. افزودن، جابه‌جایی یا پاک‌کردن راهنمای‌های رسم، فاصله‌گذاری شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمای‌های رسم، ابزارهای ویرایشی هستند. آن‌ها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید نمایش داده نمی‌شوند. ذخیره‌سازی فاصله‌گذاری شبکه تضمین نمی‌کند که یک ویرایشگر شبکه را نشان دهد؛ نمایش آن نیز به تنظیمات نماینده یا ویرایشگر وابسته است.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. از [ViewProperties.getShowComments](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getShowComments) و [ViewProperties.setShowComments](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setShowComments) برای خواندن یا تغییر ترجیح ذخیره‌شدهٔ اینکه آیا نظرات هنگام باز شدن ارائه در PowerPoint یا ویرایشگر سازگار دیگر نمایش داده شوند یا نه، استفاده کنید.

این تنظیم فقط ترجیح نمای ذخیره‌شده را کنترل می‌کند. این تنظیم نظرات را اضافه، حذف، ویرایش یا حل نمی‌کند. مخفی‌سازی نظرات محتوای آن‌ها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌های تغییر نظرات به [نظرات ارائه](/slides/fa/python-java/presentation-comments/) مراجعه کنید.

مثال زیر به یک فایل `comments.pptx` حاوی نظرات نیاز دارد. تنظیم قابل مشاهدهٔ فعلی را چاپ می‌کند، درخواست می‌کند که نظرات مخفی شوند و یک PPTX جدید بدون حذف هیچ نظری ذخیره می‌کند. همچنین از [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setLastView) همراه با [ViewType.SlideView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewtype/#SlideView) برای پیکربندی نمای ویرایشی اولیه همراه با نمایان بودن نظرات استفاده می‌کند.

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

این تنظیم تعیین نمی‌کند که آیا نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت یا جزوه گنجانده می‌شوند یا نه. گزینه‌های مربوط به هر خروجی را جداگانه پیکربندی کنید.

## **سؤالات متداول**

**چرا پس از باز کردن مجدد ارائه، شبکه دیده نمی‌شود؟**

فایل فاصله‌گذاری شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک‌کردن راهنمای‌های رسم فاصله‌گذاری شبکه را تغییر می‌دهد؟**

نه. راهنمای‌های رسم و فاصله‌گذاری شبکه تنظیمات مستقلی هستند. پاک‌کردن راهنمای‌ها مقدار بازهٔ ذخیره‌شدهٔ شبکه را تحت‌اثر نمی‌گذارد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعریف کنم؟**

[View settings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getSlideViewProperties))، نه برای هر بخش. بنابراین یک مجموعه پارامتر برای تمام سند اعمال می‌شود هنگامی که باز می‌شود.

**آیا می‌توانم وضعیت‌های نمای متفاوتی برای کاربران مختلف پیش‌تعریف کنم؟**

نه. تنظیمات در فایل ذخیره می‌شوند و مشترک هستند. برنامه‌های نمایش ممکن است ترجیحات کاربر را در نظر بگیرند، اما خود فایل تنها شامل یک مجموعه ویژگی‌های نمای است.

**آیا می‌توانم قالبی با ویژگی‌های نمای از پیش تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجا که [view properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در قالب گنجانده و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.