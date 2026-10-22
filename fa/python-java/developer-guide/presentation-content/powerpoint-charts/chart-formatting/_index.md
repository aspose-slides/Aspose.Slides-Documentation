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
description: "یاد بگیرید چگونه در Aspose.Slides برای پایتون از طریق جاوا نمودارها را قالب‌بندی کنید و ارائه PowerPoint خود را با محورهای سفارشی، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد نمودار ارتقا دهید."
---
## **نگاه کلی**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محور‌ها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه ترسیم و پر کردن دیواره‌ها را سفارشی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه ویژگی‌های قلم برای متن نمودار تنظیم شود، قالب‌های عددی پیش‌تنظیم‌شده بر داده‌های نمودار اعمال شود، و گوشه‌های گرد برای ناحیه نمودار فعال شود. این مثال‌ها به‌طور مشترک نشان می‌دهند چگونه هم سبک بصری و هم ارائه داده‌های نمودارها در یک ارائه کنترل شوند.

## **قالب‌بندی موجودیت‌های نمودار**

از [نمودار](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) برای قالب‌بندی عناوین نمودار، محور‌ها، خطوط شبکه، افسانه‌ها و ناحیه ترسیم استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط جداگانه‌ای برای محور مقدار و محور دسته‌بندی اعمال می‌کند. اندازه‌های قلم و عرض خطوط بر حسب نقطه مشخص می‌شوند؛ برچسب‌های دسته‌بندی به اندازه ۴۵ درجه چرخانده می‌شوند.

محور مقدار از [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) به‌صورت مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است، با بازه‌های اصلی 2 و بازه‌های فرعی 0.5. این مثال همچنین قالب‌بندی درصدی را با [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) که به هزارها تنظیم شده ترکیب می‌کند، بنابراین این تنظیمات را مطابق معنای داده‌ها و مقیاس آنها تنظیم کنید. افسانه به دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) با `False` در خارج ناحیه ترسیم می‌ماند. پرکننده‌های دیوار پشت و کف از طریق [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) و [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده هستند.

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

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 نقطه‌ای ایجاد می‌کند و برچسب‌های مقدار برای سری اول را از طریق [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) فعال می‌سازد. عناصر متنی با تنظیمات قلم صریح خود می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

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

## **تنظیم قالب عددی**

از [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) برای اعمال یک قالب عددی پیش‌ساخته به سلول‌های کتاب کار نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض و پشتیبانی‌شده توسط سلول‌ها ایجاد می‌کند و شاخص قالب 10 (`0.00%`) را بر هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر در کتاب کار را بدون تغییر اعداد پایه تغییر می‌دهد؛ به عنوان مثال، 0.25 به صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

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

جدول زیر فهرست‌ای از شاخص‌های قالب عددی پیش‌ساخته را همراه با قالب‌های نمایشی Excel برای زبان انگلیسی (ایالات متحده) ارائه می‌دهد. رشته‌های قالب دقیق و نمایش آن‌ها می‌تواند بر حسب برنامه و محل متفاوت باشد، به‌ویژه برای واحد پول و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توصیف شده است.

| نمایه | قالب |
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

با فراخوانی [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) با `True` گوشه‌های ناحیه نمودار را گرد کنید. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) برای دادن رنگ خاکستری ثابت و سبک خطی تک به حاشیه آن استفاده می‌کند، سپس ارائه را ذخیره می‌کند.

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

## **ویرایش حاشیه‌نویس‌های موجود در نمودار**

یک نمودار می‌تواند اشکال سفارشی شامل حاشیه‌نویسی متنی که وضعیت گزارشی را توضیح می‌دهد، داشته باشد. به این اشکال از طریق [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) دسترسی پیدا کنید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) برگردانده می‌شود، شامل اشکال متعلق به نمودار است.

یک کادر متن معمولی که روی نمودار قرار می‌گیرد، متعلق به اسلاید است، حتی اگر به‌نظر برسد بخشی از نمودار است. پیمایش از طریق [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) نمودار و اشکال عادی اسلاید را پیدا می‌کند، اما اشکال جداگانه داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای از نمودار هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویسی جدا نشده "نتایج اولیه"، خطی متعلق به نمودار و یک کادر متن اسلایدی معمولی با متن "Slide overlay" است. مثال اولین نمودار را در آن اسلاید پیدا می‌کند و حاشیه‌نویس را به "نتایج نهایی" تغییر می‌دهد هنگامی که گزارش آماده انتشار باشد. این موارد برای مجموعه خالی بررسی می‌شود و فقط یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) با فریم متن غیر `None` برگردانده شده توسط [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) و متن مورد انتظار ویرایش می‌کند.

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

خط و کادر متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجه ذخیره‌شده و بازگشای‌شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه‌نویس نمودار با متن نتایج اولیه](chart-annotations-before.png) | ![حاشیه‌نویس نمودار با متن نتایج نهایی](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) باشد، مجموعه‌ی [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متنی را برای اشکال فرزندشان اعمال کنید. یک گروه خود یک محفظه است؛ آن را به‌عنوان کادر متن در نظر نگیرید.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم پرکننده‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه آن‌ها مات (opaque) بماند؟**

بله. شفافیت پرکننده و حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود قابلیت خواندن شبکه و داده‌ها در تجسم‌های پرتراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که هم‌پوشانی دارند، برخورد کنم؟**

اندازۀ قلم را کاهش دهید، اجزای غیرضروری برچسب‌ها (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت نیاز تنها برچسب‌های نقاط انتخابی را نشان دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پرکننده‌های گرادیان یا الگو را بر سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکننده‌های یکدست، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌صورت مقتصدانه استفاده کنید و از ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند، خودداری کنید.