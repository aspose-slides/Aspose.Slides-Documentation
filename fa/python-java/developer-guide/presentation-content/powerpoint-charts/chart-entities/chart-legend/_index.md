---
title: سفارشی‌سازی راهنمای نمودارها در ارائه‌ها با استفاده از پایتون
linktitle: راهنمای نمودار
type: docs
url: /fa/python-java/chart-legend/
keywords:
- راهنمای نمودار
- موقعیت راهنما
- اندازه قلم
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "راهنمای نمودارها را با Aspose.Slides برای پایتون از طریق جاوا سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی ویژهٔ راهنما بهینه کنید."
---
## **نمای کلی**

Aspose.Slides for Python via Java گزینه‌هایی برای سفارشی‌سازی راهنمای نمودارها در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازه یک راهنما را تنظیم کنید، اندازه قلم کل راهنما را تعیین کنید، یک ورودی راهنمای منفرد را قالب‌بندی کنید و ورودی‌های انتخابی را مخفی یا بازگردانی کنید.

پرسش‌های متداول رفتارهای مرتبط را پوشش می‌دهد، از جمله رزرو فضا برای راهنما، نمایش برچسب‌های چندخطی، و ارث‌بری قالب‌بندی از تم ارائه.

## **موقعیت‌یابی راهنما**

از متدهای راهنما [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX)، [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY)، [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) و [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) برای تعیین موقعیت و اندازه آن به‌صورت کسری از ابعاد نمودار استفاده کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض به اسلاید اول اضافه می‌نماید. تقسیم مقادیر دلخواه جابجایی و ابعاد راهنما بر عرض و ارتفاع نمودار، آن‌ها را به مقادیر نسبی تبدیل می‌کند: راهنما ۵۰ پوینت از گوشهٔ بالا‑چپ نمودار جابجا شده و به اندازهٔ ۱۰۰×۱۰۰ پوینت تنظیم می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # موقعیت و اندازهٔ راهنما را نسبت به نمودار بیان کنید.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم اندازه قلم راهنما**

از [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) راهنما برای دسترسی به قالب‌بندی متن آن استفاده کنید و با [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) اندازه قلم را برحسب پوینت تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن راهنما را روی ۲۰ پوینت تنظیم می‌نماید. همچنین مرزهای خودکار برای محور عمودی را غیرفعال کرده و دامنهٔ آن را از ‎-5 تا 10 تنظیم می‌کند.

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

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم اندازه قلم یک ورودی راهنمای منفرد**

از مجموعه‌ای که متد [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) راهنما برمی‌گرداند، برای دسترسی به قالب‌بندی یک ورودی خاص استفاده کنید. ایندکس‌های ورودی صفر‑محور هستند، بنابراین ایندکس `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای که داده‌های پیش‌فرض حداقل دو سری دارد ایجاد می‌کند. ورودی دوم راهنما را با قلم بولد، ایتالیک و متن آبی ۲۰ پوینتی قالب‌بندی می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مخفی کردن ورودی‌های منفرد راهنما**

برای حذف یک سری کمکی از راهنما در حالی که داده‌های آن قابل مشاهده می‌مانند، از [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) با مقدار `True` از طریق [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) استفاده کنید. این کار تنها ورودی انتخابی راهنما را مخفی می‌کند؛ سری یا نقاط دادهٔ آن حذف نمی‌شوند. در مقابل، فراخوانی [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) با مقدار `False` تمام راهنما را مخفی می‌کند.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با داده‌های پیش‌فرض ایجاد می‌کند. ورودی راهنمای سری دوم (ایندکس `1`) را مخفی می‌کند و ارائه را ذخیره می‌نماید. سپس با فراخوانی [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) با مقدار `False` ورودی را بازگردانده و یک کپی دوم ذخیره می‌کند. ستون‌ها در هر دو فایل قابل مشاهده می‌مانند.

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
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # ورودی یکسان را بدون تغییر داده‌های نمودار بازیابی کنید.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مقایسهٔ زیر همان نمودار را با تمام ورودی‌های قابل مشاهده و با مخفی بودن ورودی دوم نشان می‌دهد. ستون‌های سری دوم بدون تغییر باقی می‌مانند.

![مقایسهٔ نمودار با تمامی ورودی‌های راهنما قابل مشاهده و با مخفی شدن سری ۲ از راهنما؛ تمام ستون‌ها قابل مشاهده هستند.](hide-legend-entry.png)

در نمودارهای ستونی، میله‌ای و خطی، ورودی‌های راهنما نمایانگر سری‌ها هستند. در نمودارهای کیک، آن‌ها نمایانگر نقاط دادهٔ فردی (قطعات) هستند، بنابراین باید از [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) روی قطعهٔ منتخب استفاده کنید. این متد برای انواع نمودار `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` و `BarOfPie` مستند شده است. فرض نکنید که برای نمودارهای دونات نیز اعمال می‌شود، زیرا در آن فهرست گنجانده نشده‌اند.

## **پرسش‌های متداول**

**آیا می‌توانم نمودار را طوری تنظیم کنم که برای راهنما فضا اختصاص دهد به جای اینکه آن را روی نمودار بپوشاند؟**

بله. با فراخوانی [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) با مقدار `False` می‌توانید برای راهنما فضا رزرو کنید به جای اینکه اجازه دهید روی ناحیهٔ رسم هم‌پوشانی داشته باشد.

**آیا می‌توانم برچسب‌های راهنمای چندخطی داشته باشم؟**

بله. برچسب‌های طولانی می‌توانند هنگام نداشتن عرض کافی به چند خط تقسیم شوند. همچنین می‌توانید در نام‌های سری از کاراکترهای خط جدید استفاده کنید تا شکست خط دلخواه ایجاد شود.

**چگونه می‌توانم راهنما را طوری تنظیم کنم که طرح رنگی تم ارائه را دنبال کند؟**

رنگ‌ها، پرکننده‌ها و قلم‌های راهنما را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث ببرد. قالب‌بندی صریح بر تنظیمات مربوط به تم ارجحیت دارد.