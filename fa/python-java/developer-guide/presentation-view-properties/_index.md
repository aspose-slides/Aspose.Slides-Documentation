---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در Python از طریق Java
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/python-java/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل‌کردن تقسیم‌کننده عمودی
- نمای تک
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
description: "ویژگی‌های نمای Aspose.Slides برای Python از طریق Java را کشف کنید تا اسلایدهای PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوایی است: اسلاید خود، یک ناحیه محتوای جانبی، و یک ناحیه محتوای پایین. ویژگی‌های نمای عادی موقعیت این نواحی محتوایی را توصیف می‌کند. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری‌که هنگام باز کردن مجدد، نما در همان وضعیتی باشد که ارائه در آخرین ذخیره‌سازی بود.

متد [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای دسترسی به ویژگی‌های نمای عادی یک ارائه اضافه شده است.

کلاس‌های [NormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/) و [NormalViewRestoredProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/) و همچنین شمارش‌گر [SplitterBarStateType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره NormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

متدهای [getShowOutlineIcons](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) و [setShowOutlineIcons](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) تعیین می‌کنند که آیا برنامه باید نمادها را هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوایی حالت نمای عادی نشان دهد یا نه.

متدهای [getSnapVerticalSplitter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) تعیین می‌کنند که آیا تقسیم‌کننده عمودی باید هنگام کوچک شدن کافی ناحیه جانبی به حالت کمینه (Minimized) بچسبد یا خیر.

متدهای [getPreferSingleView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) و [setPreferSingleView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) تعیین می‌کنند که آیا کاربر ترجیح می‌دهد ناحیه محتوای تک‑پنجره‌ای تمام‌صفحه را به‌جای نمای عادی استاندارد با سه ناحیه محتوایی ببیند. در صورت فعال باشد، برنامه ممکن است یک ناحیه محتوا را در تمام پنجره نشان دهد.

متدهای [getVerticalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) وضعیت نمایش نوار تقسیم‌کننده افقی یا عمودی را تعیین می‌کنند. یک نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوای زیر اسلاید جدا می‌کند؛ یک نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Maximized)، و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Restored).

متدهای [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) و [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) اندازه‌گذاری ناحیه اسلاید بالا یا جانبی نمای عادی را وقتی مقدار [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fa/python-java/aspose.slides/splitterbarstatetype/#Restored) بر روی [getVerticalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) و [getHorizontalBarState](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) به‌صورت متقابل اعمال می‌شود، مشخص می‌کنند.

## **درباره بازیابی NormalViewProperties**

اندازه‌گذاری ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredTop) است، ارتفاع وقتی فرزند [getRestoredLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) است) در نمای عادی را وقتی که ناحیه دارای اندازه متغیر بازگردانده شده (نه کمینه و نه حداکثر) باشد، تعیین می‌کند.

متد [getDimensionSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) اندازه ناحیه اسلاید (عرض وقتی فرزند [getRestoredTop] است، ارتفاع وقتی فرزند [getRestoredLeft] است) را مشخص می‌کند.

متد [getAutoAdjust](https://reference.aspose.com/slides/fa/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) تعیین می‌کند که آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید جبران کند وقتی پنجره‌ی حاوی نما در برنامه تغییر اندازه می‌دهد.

مثال زیر نشان می‌دهد چگونه می‌توان به [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties) برای یک ارائه دسترسی پیدا کرد.

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
Aspose.Slides for Python via Java از تنظیم مقدار پیش‌فرض بزرگنمایی پشتیبانی می‌کند تا هنگام باز شدن ارائه، به‌طور خودکار اعمال شود. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) یک ارائه انجام شود. متدهای [getSlideViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNotesViewProperties) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این مطلب، با یک مثال نشان می‌دهیم چگونه [View Properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) را برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) در [Aspose.Slides](/slides/fa/) تنظیم کنیم.
{{% /alert %}}

برای تنظیم ویژگی‌های نمای، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. [View Properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) را برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) تنظیم کنید.
3. ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.

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

## **سوالات متداول**

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

[View settings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#getSlideViewProperties))، نه برای هر بخش، به‌طوری که یک مجموعه پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم وضعیت‌های نمای متفاوتی برای کاربران مختلف پیش تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره شده و به‌اشتراک گذاشته می‌شوند. برنامه‌های نمایش ممکن است ترجیحات کاربر را در نظر بگیرند، اما خود فایل فقط یک مجموعه ویژگی نمای را شامل می‌شود.

**آیا می‌توانم یک الگو با View Properties از پیش تعریف‌شده آماده کنم تا ارائه‌های جدید به‌همین شکل باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getViewProperties) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در الگو جاسازی کنید و اسناد جدید را با همان پیکربندی نمای اولیه از آن ایجاد کنید.