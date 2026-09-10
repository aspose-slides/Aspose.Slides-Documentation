---
title: قالب‌بندی نمودارهای ارائه در پایتون
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/python-java/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یادگیری قالب‌بندی نمودارها در Aspose.Slides برای Python از طریق Java و ارتقا ارائه PowerPoint شما با استایل حرفه‌ای و چشم‌نوازی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کرد. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورهای مقدار و دسته، خطوط شبکه، عناوین، راهنمای نمودار، ناحیهٔ ترسیم و پر کردن دیوارها را سفارشی‌سازی کرد تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌فرض و سفارشی به داده‌های نمودار، و فعال‌سازی گوشه‌های گرد برای ناحیهٔ نمودار را نشان می‌دهد. این مثال‌ها نشان می‌دهند چگونه می‌توان هم سبک بصری و هم ارائه داده‌های نمودارها را در یک ارائه کنترل کرد.

## **قالب‌بندی موجودیت‌های نمودار**
Aspose.Slides for Python via Java به توسعه‌دهندگان امکان می‌دهد از صفر نمودارهای سفارشی را به اسلایدهای خود اضافه کنند. این مقاله توضیح می‌دهد که چگونه موجودیت‌های مختلف نمودار شامل محورهای دسته و مقدار را قالب‌بندی کنیم.

Aspose.Slides for Python via Java یک API ساده برای مدیریت موجودیت‌های مختلف نمودار و قالب‌بندی آن‌ها با استفاده از مقادیر سفارشی ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. به یک اسلاید با استفاده از ایندکس آن دسترسی پیدا کنید.
1. یک نمودار از نوع مطلوب با داده‌های پیش‌فرض اضافه کنید (در این مثال از [ChartType.LineWithMarkers](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/#LineWithMarkers) استفاده می‌شود).
1. به محور مقدار نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. قالب **خط** را برای خطوط شبکهٔ اصلی محور مقدار تنظیم کنید.
   1. قالب **خط** را برای خطوط شبکهٔ فرعی محور مقدار تنظیم کنید.
   1. قالب **عدد** را برای محور مقدار تنظیم کنید.
   1. **حداقل، حداکثر، واحدهای اصلی و فرعی** را برای محور مقدار تنظیم کنید.
   1. **ویژگی‌های متن** را برای داده‌های محور مقدار تنظیم کنید.
   1. **عنوان** را برای محور مقدار تنظیم کنید.
1. به محور دسته نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. قالب **خط** را برای خطوط شبکهٔ اصلی محور دسته تنظیم کنید.
   1. قالب **خط** را برای خطوط شبکهٔ فرعی محور دسته تنظیم کنید.
   1. **ویژگی‌های متن** را برای داده‌های محور دسته تنظیم کنید.
   1. **عنوان** را برای محور دسته تنظیم کنید.
   1. **موقعیت‌گذاری برچسب** برای محور دسته تنظیم کنید.
   1. **زاویهٔ چرخش** برچسب‌های محور دسته تنظیم کنید.
1. به راهنمای نمودار دسترسی پیدا کنید و **ویژگی‌های متن** آن را تنظیم کنید.
1. راهنمای نمودار را بدون همپوشانی با نمودار نمایش دهید.
1. به **محور مقدار ثانویه** نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. محور مقدار ثانویه را فعال کنید.
   1. قالب **خط** را برای محور مقدار ثانویه تنظیم کنید.
   1. قالب **عدد** را برای محور مقدار ثانویه تنظیم کنید.
   1. **حداقل، حداکثر، واحدهای اصلی و فرعی** را برای محور مقدار ثانویه تنظیم کنید.
1. سری اول نمودار را روی محور مقدار ثانویه ترسیم کنید.
1. رنگ پر کردن دیوار پشتی نمودار را تنظیم کنید.
1. رنگ پر کردن ناحیهٔ ترسیم نمودار را تنظیم کنید.
1. ارائهٔ تغییر یافته را به فایل PPTX بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# یک نمونه از کلاس Presentation ایجاد کنید
presentation = Presentation()
try:
    # دسترسی به اولین اسلاید
    slide = presentation.getSlides().get_Item(0)

    # افزودن نمودار نمونه
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # تنظیم عنوان نمودار
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # تنظیم قالب خطوط شبکه اصلی برای محور مقدار
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # تنظیم قالب خطوط شبکه فرعی برای محور مقدار
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # تنظیم قالب عددی محور مقدار
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # تنظیم مقادیر حداکثر و حداقل نمودار
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # تنظیم ویژگی‌های متن محور مقدار
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # تنظیم عنوان محور مقدار
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # تنظیم قالب خطوط شبکه اصلی برای محور دسته
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # تنظیم قالب خطوط شبکه فرعی برای محور دسته
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # تنظیم ویژگی‌های متن محور دسته
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # تنظیم عنوان دسته
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # تنظیم موقعیت برچسب محور دسته
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # تنظیم زاویهٔ چرخش برچسب محور دسته
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # تنظیم ویژگی‌های متن راهنما
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # نمایش راهنمای نمودار بدون همپوشانی با نمودار

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # تنظیم محور مقدار ثانویه
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # تنظیم قالب عددی محور مقدار ثانویه
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # تنظیم مقادیر حداکثر و حداقل نمودار
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # تنظیم رنگ دیوار پشت نمودار
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # تنظیم رنگ ناحیهٔ ترسیم
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # ذخیرهٔ ارائه
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**
Aspose.Slides for Python via Java از تنظیم ویژگی‌های قلم برای نمودارها پشتیبانی می‌کند. برای تنظیم ویژگی‌های قلم مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- یک نمودار به اسلاید اضافه کنید.
- ارتفاع قلم را تنظیم کنید.
- ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر این مراحل را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم قالب عددی**
Aspose.Slides for Python via Java یک API ساده برای مدیریت قالب‌های دادهٔ نمودار ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. به یک اسلاید با استفاده از ایندکس آن دسترسی پیدا کنید.
1. یک نمودار از نوع مطلوب با داده‌های پیش‌فرض اضافه کنید (در این مثال از [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/#ClusteredColumn) استفاده می‌شود).
1. قالب عددی پیش‌فرض را از مقادیر پیش‌فرض موجود تنظیم کنید.
1. در هر سری نمودار به سلول‌های داده دسترسی پیدا کنید و قالب عددی آنها را تنظیم کنید.
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید
presentation = Presentation()
try:
    # به اولین اسلاید ارائه دسترسی پیدا کنید
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک نمودار ستونی خوشه‌ای پیش‌فرض
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # دسترسی به مجموعهٔ سری‌های نمودار
    chart_series_collection = chart.getChartData().getSeries()

    # تکرار بر روی هر سری نمودار
    for chart_series in chart_series_collection:
        # تکرار بر روی هر نقطه داده در سری
        for data_point in chart_series.getDataPoints():
            # تنظیم قالب عددی
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # ذخیرهٔ ارائه
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قالب‌های عددی پیش‌فرض موجود و ایندکس‌های آن‌ها در زیر فهرست شده‌اند:

|**0**|عمومی|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تنظیم حاشیه‌های گرد ناحیهٔ نمودار**
Aspose.Slides for Python via Java با استفاده از متدهای [hasRoundedCorners](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#hasRoundedCorners) و [setRoundedCorners](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#setRoundedCorners) در کلاس [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) از گوشه‌های گرد برای ناحیهٔ نمودار پشتیبانی می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. نوع پر کردن و سبک خط حاشیهٔ نمودار را تنظیم کنید.
1. گوشه‌های گرد را فعال کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر این مراحل را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا می‌توانم پر کردن نیمه شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که مرز را مات نگه می‌دارم؟**

بله. شفافیت پر کردن و خطوط مرزی به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند مقابله کنم؟**

اندازهٔ قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت/انتقال برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط منتخب برچسب‌ها را نشان دهید، یا قالب را به «مقدار + راهنما» تغییر دهید.

**آیا می‌توانم پر کردن گرادیان یا الگو را برای سری‌ها اعمال کنم؟**

بله. معمولاً پر کردن‌های یکدست و گرادیان/الگو در دسترس هستند. در عمل، از گرادیان‌ها به‌طور مقتصدانه استفاده کنید و ترکیب‌هایی که کنتراست را با شبکه و متن کاهش می‌دهند، اجتناب کنید.