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
- آیکون‌های طرح کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تک‌پنجره‌ای
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای پایتون از طریق جاوا را کشف کنید تا اسلایدهای PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، یک ناحیه محتوا جانبی، و یک ناحیه محتوا پایین. ویژگی‌های نمای عادی موقعیت این ناحیه‌های محتوا را توصیف می‌کنند. این اطلاعات به برنامه اجازه می‌دهد وضعیت نمای خود را در فایل ذخیره کند تا هنگام بازگشایی، نمای برنامه در همان وضعیتی باشد که آخرین بار ارائه ذخیره شده بود.

متد [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای دسترسی به ویژگی‌های نمای عادی یک ارائه افزوده شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/) و [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/) و enumeration [SplitterBarStateType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره NormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) مشخص می‌کنند که آیا برنامه باید هنگام نمایش محتوی طرح کلی در هر یک از ناحیه‌های محتوا در حالت نمای عادی، آیکون‌ها را نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) تعیین می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیه جانبی، به حالت کمینه (minimized) بچسبد یا نه.

متدهای [getPreferSingleView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) و [setPreferSingleView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوا تک‌پنجره‌ای تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. اگر فعال باشد، برنامه ممکن است یکی از ناحیه‌های محتوا را در تمام پنجره نمایش دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) وضعیت نمایش نوار تقسیم‌کننده افقی یا عمودی را تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند؛ نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا جانبی جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) و [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) ابعاد ناحیه اسلاید بالایی یا جانبی نمای عادی را زمانی که مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Restored) برای [getVerticalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) اعمال می‌شود، مشخص می‌کند.

## **درباره بازگرداندن NormalViewProperties**

ابعاد ناحیه اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) باشد) در نمای عادی را زمانی که ناحیه دارای اندازه بازگردانده متغیر (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) اندازه ناحیه اسلاید (عرض زمانی که فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) باشد، ارتفاع زمانی که فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) باشد) را تعیین می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) مشخص می‌کند که آیا اندازه ناحیه محتوا جانبی باید برای اندازه جدید هنگام تغییر اندازه پنجره حاوی نمای برنامه جبران شود یا نه.

مثال زیر نشان می‌دهد چگونه به [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای یک ارائه دسترسی پیدا کنیم.

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

## **تنظیم مقدار بزرگنمایی پیش‌فرض**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java از تنظیم مقدار بزرگنمایی پیش‌فرض پشتیبانی می‌کند تا هنگام باز شدن ارائه به‌صورت خودکار اعمال شود. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNotesViewProperties) می‌توانند به‌صورت برنامه‌نویسی پیکربندی شوند. در این موضوع، با یک مثال می‌بینیم چگونه [View Properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) را برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) در Aspose.Slides تنظیم کنیم.

{{% /alert %}}

برای تنظیم ویژگی‌های نمای، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. [View Properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) را برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) تنظیم کنید.
1. ارائه را به‌عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.

در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و نمای یادداشت‌ها هر دو تنظیم می‌شود.

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

## **تنظیم فاصله شبکه (Grid Spacing)**

از [Presentation.getViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getGridSpacing) و [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setGridSpacing) فاصله‌بندی شبکه ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم بر کل ارائه اعمال می‌شود، نه بر یک اسلاید جداگانه. فاصله شبکه بر حسب نقاط (points) مشخص می‌شود که ۷۲ نقطه برابر یک اینچ است. از مقدار مثبت استفاده کنید، همان‌طور که مستندات API خواستار است.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصله شبکه فعلی را چاپ می‌کند، فاصله یک‌چهارم اینچ را تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

شبکه با [drawing guides](/slides/fa/python-java/drawing-guides/) متفاوت است. فاصله شبکه یک بازه منظم را کنترل می‌کند، در حالی که راهنمای رسم (drawing guides) خطوط افقی یا عمودی موقعیت‌دار به‌صورت منفرد هستند. افزودن، جابه‌جایی یا حذف راهنمای رسم، فاصله شبکه را تغییر نمی‌دهد.

هر دو شبکه و راهنمای رسم ابزارهای کمکی ویرایشی هستند. آن‌ها به‌عنوان محتوا در PDF، تصویر، SVG یا حالت نمایش اسلاید رندر نمی‌شوند. ذخیره‌سازی فاصله شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد: نمایش آن نیز به تنظیمات نمایشگر یا ویرایشگر بستگی دارد.

## **FAQ**

**چرا پس از بازگشایی دوبارهٔ ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصله شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک‌کردن راهنمای رسم، فاصله شبکه را تغییر می‌دهد؟**

نه. راهنمای رسم و فاصله شبکه تنظیمات مستقلی هستند. حذف راهنماها فاصله ذخیره‌شدهٔ شبکه را دست نخورده می‌گذارند.

**آیا می‌توان تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعریف کرد؟**

[View settings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getSlideViewProperties)) و نه برای هر بخش، بنابراین یک مجموعه پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توان حالت‌های نمای مختلفی را برای کاربران مختلف پیش‌تعریف کرد؟**

نه. تنظیمات در فایل ذخیره می‌شوند و به اشتراک گذاشته می‌شوند. برنامه‌های مشاهده‌کننده ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل فقط یک مجموعه ویژگی نمای دارد.

**آیا می‌توان یک قالب با ویژگی‌های نمای پیش‌تعریف‌شده تهیه کرد تا ارائه‌های جدید به همان صورت باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در قالب بگنجانید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.