---
title: سفارشی‌سازی جداول دادهٔ نمودار در ارائه‌ها با استفاده از پایتون
linktitle: جدول داده
type: docs
url: /fa/python-java/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "سفارشی‌سازی قلم‌های جدول دادهٔ نمودار، حاشیه‌ها و کلیدهای راهنما در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای پایتون از طریق جاوا."
---
## **بررسی کلی**

Aspose.Slides for Python via Java به شما امکان می‌دهد جدول داده‌های یک نمودار را نمایش داده و قالب‌بندی متن، حاشیه‌ها و کلیدهای راهنما را سفارشی کنید. این مقاله نحوه فعال‌سازی جدول، قالب‌بندی متن آن، کنترل هر نوع حاشیه و نمایش یا مخفی‌سازی کلیدهای راهنما را توضیح می‌دهد. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم خصوصیات قلم**

برای نمایش جدول داده‌های یک نمودار، مقدار `True` را به [setDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDataTable) بدهید. برای دسترسی به جدول و پیکربندی قالب‌بندی متن از [getChartDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#getChartDataTable) استفاده کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
1. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.
1. جدول داده‌های نمودار را فعال کنید.
1. متن بولد را با [setFontBold](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setFontBold) فعال کنید و برای متن ۲۰‑نقطه‌ای مقدار `20` را به [setFontHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setFontHeight) بدهید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به فایل `test.pptx` در پوشهٔ کاری که حداقل یک اسلاید دارد، نیاز دارد. این مثال نموداری با داده‌های پیش‌فرض در موقعیت (50, 50) اضافه می‌کند، با عرض 600 نقطه و ارتفاع 400 نقطه. فایل `output.pptx` ذخیره‌شده شامل نمودار با جدول داده فعال و تنظیمات قلم مشخص‌شده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سفارشی‌سازی حاشیه‌های جدول داده‌ها**

جدول را با [Chart.setDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDataTable) فعال کنید و از طریق [Chart.getChartDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#getChartDataTable) به آن دسترسی پیدا کنید. می‌توانید سه نوع حاشیه را به‌صورت مستقل کنترل کنید:

- [setBorderHorizontal](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setBorderHorizontal) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.
- [setBorderVertical](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setBorderVertical) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.
- [setBorderOutline](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setBorderOutline) حاشیهٔ خارجی جدول را کنترل می‌کند.

برای نمایش حاشیه‌ها مقدار `True` و برای مخفی‌سازی مقدار `False` را به هر متد بدهید. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و حاشیهٔ خارجی را نمایش می‌دهد و حاشیه‌های عمودی را مخفی می‌کند. نیازی به فایل ورودی نیست. موقعیت و اندازهٔ نمودار بر حسب نقطه مشخص شده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مقایسهٔ زیر از همان داده‌های نمودار و تنظیمات کلید راهنما در چهار حالت استفاده می‌کند. با فعال‌سازی تمام حاشیه‌ها آغاز می‌شود و هر واریانت باقی‌مانده یک تنظیم حاشیه را غیرفعال می‌کند. واریانت پایین‑چپ با تنظیمات حاشیهٔ مثال مطابقت دارد.

![جدول‌های دادهٔ نمودار با تمام حاشیه‌ها فعال، بدون حاشیهٔ افقی، بدون حاشیهٔ عمودی و بدون حاشیهٔ خارجی](data-table-borders.png)

## **نمایش یا مخفی کردن کلیدهای راهنما**

کلیدهای راهنما نشانگرهای رنگی کوچک در کنار نام سری‌ها در جدول داده هستند. این نشانگرها به خوانندگان کمک می‌کنند تا هر ردیف جدول را به یک سری نمودار مرتبط کنند. مقدار `True` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setShowLegendKey) بدهید تا این نشانگرها نمایش داده شوند یا مقدار `False` بدهید تا مخفی شوند.

راهنمای جداگانهٔ نمودار با [Chart.setLegend](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setLegend) کنترل می‌شود. این تنظیمات مستقل‌اند: مخفی‌سازی راهنمای جداگانه، کلیدهای داخل جدول داده را مخفی نمی‌کند و مخفی‌سازی کلیدهای جدول، راهنمای جداگانه را مخفی نمی‌کند.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را فعال می‌کند و کلیدهای راهنما را در داخل آن نشان می‌دهد در حالی که راهنمای جداگانه مخفی است. تمام حاشیه‌های جدول به‌صورت صریح فعال هستند. نیازی به ارائهٔ ورودی نیست. برای مخفی کردن فقط کلیدهای جدول مقدار `False` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setShowLegendKey) بدهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مقایسهٔ زیر همان جدول را با کلیدهای راهنما فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال می‌مانند و راهنمای جداگانهٔ نمودار در هر دو حالت مخفی است.

![جدول‌های دادهٔ نمودار با کلیدهای راهنما در سمت چپ نمایش داده شده و در سمت راست مخفی](data-table-legend-keys.png)

## **سوالات متداول**

**آیا می‌توانم کلیدهای راهنما را در جدول داده‌های چارت نمایش دهم؟**

بله. مقدار `True` را به [setShowLegendKey](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setShowLegendKey) بدهید تا کلیدهای راهنما نمایش داده شوند یا مقدار `False` بدهید تا مخفی شوند.

**آیا جدول داده‌ها هنگام خروجی گرفتن ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides هنگام خروجی به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/python-java/convert-powerpoint-to-html/) یا [images](/slides/fa/python-java/convert-powerpoint-to-png/)، نمودار و جدول دادهٔ نمایش داده‌شده را به‌عنوان بخشی از اسلاید رندر می‌کند.

**آیا می‌توانم با جدول‌های داده در نمودارهای بارگذاری‌شده از یک قالب کار کنم؟**

بله. برای یک نمودار بارگذاری‌شده از ارائه یا قالب موجود، از [hasDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#hasDataTable) و [setDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setDataTable) برای بررسی یا تغییر وضعیت نمایش جدول داده استفاده کنید.

**چگونه می‌توانم نمودارهایی را پیدا کنم که جدول داده آن‌ها فعال است؟**

در هر اسلاید به‌دمای شکل‌ها مرور کنید، نمودارها را شناسایی کنید و متد [hasDataTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#hasDataTable) آن‌ها را فراخوانی کنید. مقدار `True` نشان می‌دهد که جدول داده فعال است.