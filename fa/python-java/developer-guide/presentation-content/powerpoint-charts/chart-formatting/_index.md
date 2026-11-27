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
description: "قالب‌بندی نمودارها را در Aspose.Slides برای پایتون از طریق جاوا بیاموزید و ارائه PowerPoint خود را با محورها، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد سفارشی پیشرفت دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنید. این نشان می‌دهد که چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنماها، ناحیه‌نقشه و پرکننده‌های دیوار را برای بهبود ظاهر و قابلیت خواندن داده‌های نمودار سفارشی کنید.

همچنین نشان می‌دهد که چگونه ویژگی‌های قلم برای متن نمودار تنظیم شود، قالب‌های عددی پیش‌فرض بر روی داده‌های نمودار اعمال شود و گوشه‌های گرد برای ناحیه نمودار فعال شود. این مثال‌ها نشان می‌دهند که چگونه هم سبک بصری و هم ارائه داده‌های نمودارها را در یک ارائه کنترل کنید.

For separate fills and outlines on rising and falling intervals, see the [مثال نمودار سهام](/slides/fa/python-java/create-chart/#create-stock-charts).

## **قالب‌بندی موجودیت‌های نمودار**

از [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، راهنماها و ناحیه‌نقشه استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط جداگانه‌ای را بر محوری مقدار و محوری دسته‌بندی اعمال می‌کند. اندازه‌های قلم و ضخامت خطوط بر حسب نقطه مشخص می‌شوند؛ برچسب‌های دسته‌بندی به میزان 45 درجه چرخانده می‌شوند.

محور مقدار از [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) به‌صورت مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است، با فاصله‌های بزرگ به‌مقدار 2 و فاصله‌های جزئی به‌مقدار 0.5. این مثال همچنین قالب‌بندی درصد را با [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) که بر روی هزارها تنظیم شده ترکیب می‌کند، بنابراین این تنظیمات را مطابق با معنی و مقیاس داده‌های خود تطبیق دهید. راهنما به‌دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) با مقدار `False` خارج از ناحیه‌نقشه می‌ماند. پرکننده‌های دیوار پشت و کف از طریق [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) و [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده هستند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازه پیش‌فرض قلم برای متن نمودار را از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 نقطه‌ای ایجاد می‌کند و برچسب‌های مقدار را برای اولین سری از طریق [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) فعال می‌سازد. عناصر متنی که تنظیمات قلم صریح خود را دارند می‌توانند پیش‌فرض نمودار را نادیده بگیرند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استفاده مجدد از قالب‌بندی قاب متن برای راهنمای نمودار**

برای هم‌خوانی راهنما با عنوان اسلاید، قلم عنوان را از طریق [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) در اولین پاراگراف تنظیم کنید. بر روی قالبی که توسط [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) راهنما بازگردانده می‌شود، [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) را فراخوانی کنید. این کار تنظیمات قاب متن، قالب‌بندی اولین پاراگراف و ویژگی‌های قلم پیش‌فرض آن پاراگراف را کپی می‌کند. قالب‌بندی که مستقیماً به بخش‌های فردی یا پاراگراف‌های بعدی اعمال شود، به‌صورت محلی در منبع باقی می‌ماند.

این مثال از یک عنوان Calibri به‌صورت توپر، 26 نقطه‌ای و به رنگ سرمه‌ای به‌عنوان الگو استفاده می‌کند. پس از استایل دادن به راهنما، با فراخوانی [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) همان قالب‌بندی را بر یک زیرنویس جداگانه اعمال می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در ارائه ذخیره‌شده، راهنما و زیرنویس از نظر اندازه، وزن و رنگ با عنوان مطابقت دارند. راهنما همچنان نام‌های سری‌ها را نشان می‌دهد و زیرنویس متن خود را حفظ می‌کند. اگر بخشی از زیرنویس قبلاً اندازه قلم صریح داشته باشد، آن اندازه نسبت به پیش‌فرض پاراگراف کپی‌شده اولویت دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![نمودار فروش فصلی با برچسب‌های راهنمایی سیاه معمولی و زیرنویس سیاه](legend-formatting-before.png) | ![نمودار مشابه با برچسب‌های راهنمایی بزرگتر، توپر، به رنگ سرمه‌ای و زیرنویس مطابق](legend-formatting.png) |

## **تنظیم قالب عددی**

از [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) برای اعمال یک قالب عددی داخلی به سلول‌های کتاب کاری نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض و پشتیبانی‌شده توسط سلول‌ها ایجاد می‌کند و شاخص قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌کند. این کار نحوه نمایش مقادیر را در کتاب کار بدون تغییر اعداد پایه تغییر می‌دهد؛ به عنوان مثال، 0.25 به صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

جدول زیر فهرست ایندکس‌های قالب عددی داخلی همراه با قالب‌های نمایشی اکسل برای محلی English (United States) را نشان می‌دهد. رشته‌های قالب دقیق و نمایش آنها می‌تواند با توجه به برنامه و locale متفاوت باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های اکسل نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های مایکروسافت در مورد پیاده‌سازی قالب عددی](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| اندیس | قالب |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تنظیم گوشه‌های گرد ناحیه نمودار**

با فراخوانی [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) با مقدار `True` گوشه‌های ناحیه نمودار را گرد می‌کنید. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) برای دادن یک رنگ خاکستری جامد و سبک خط تک‌خطی به پیرامون آن پیش از ذخیرهٔ ارائه استفاده می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند شامل اشکال سفارشی، مانند یک حاشیه‌نویسی متنی که وضعیت گزارش را توضیح می‌دهد، باشد. به این اشکال از طریق [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) دسترسی پیدا کنید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) برگردانده می‌شود، شامل اشکال متعلق به نمودار است.

یک کادر متن معمولی که بر روی نمودار قرار می‌گیرد، به اسلاید تعلق دارد، حتی اگر شبیه بخشی از نمودار به نظر برسد. عبور از طریق [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) نمودار و اشکال معمولی اسلاید را پیدا می‌کند، اما اشکال فردی داخل نمودار را لیست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای از نمودار هستند و حاشیه‌نویسی‌های سفارشی در این مجموعه نیستند.

فایل [chart-annotations.pptx](chart-annotations.pptx) را بارگیری کنید و در پوشه کاری برنامه قرار دهید. اولین اسلاید آن شامل یک نمودار با حاشیه‌نویسی تجمیع‌نشده‌ای با متن «Preliminary results»، یک خط متعلق به نمودار و یک کادر متن معمولی اسلایدی با متن «Slide overlay» است. این مثال اولین نمودار در آن اسلاید را پیدا می‌کند و هنگام آماده‌سازی گزارش برای انتشار، حاشیه‌نویسی را به «Final results» تغییر می‌دهد. ابتدا بررسی می‌کند که مجموعه خالی نیست و فقط یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) با قاب متن غیر `None` که توسط [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) برگردانده شده و متن مورد انتظار دارد را ویرایش می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

خط و کادر متن اسلاید بدون تغییر باقی می‌مانند. تصاویر زیر ورودی و نتیجه ذخیره‌شده و بازگشایی شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه‌نویسی نمودار با متن Preliminary results](chart-annotations-before.png) | ![حاشیه‌نویسی نمودار با متن Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
این مثال فقط اشکال سطح بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) باشد، مجموعهٔ [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متنی را برای اشکال فرزندشان اعمال کنید. یک گروه خود یک مخزن است؛ آن را به‌ عنوان کادر متن در نظر نگیرید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم پرکننده‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه را مات نگه می‌دارم؟**

Yes. Fill transparency and the outline are configured separately. This is useful for improving the readability of the grid and data in dense visualizations.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند برخورد کنم؟**

Reduce the font size, disable nonessential label components (for example, categories), adjust the label position, show labels only for selected points if necessary, or switch the format to "value + legend".

**آیا می‌توانم پرکننده‌های گرادیان یا الگو را به سری‌ها اعمال کنم؟**

Yes. Series support solid, gradient, and pattern fills. In practice, use gradients sparingly and avoid combinations that reduce contrast with the grid and text.