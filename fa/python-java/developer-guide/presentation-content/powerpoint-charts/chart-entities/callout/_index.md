---
title: مدیریت فراخوان‌ها در نمودارهای ارائه با استفاده از Python
linktitle: فراخوان
type: docs
url: /fa/python-java/callout/
keywords:
- فراخوان نمودار
- استفاده از فراخوان
- برچسب داده
- فرمت برچسب
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد و استایل دهی به فراخوان‌ها در Aspose.Slides برای Python از طریق Java با مثال‌های کد مختصر، سازگار با PPT و PPTX برای خودکارسازی جریان‌های کاری ارائه."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با فراخوان‌ها برای برچسب‌های داده نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه از متد [setShowLabelAsDataCallout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) برای نمایش برچسب‌ها به‌صورت فراخوان استفاده شود، چگونه تنظیمات برچسب مرتبط با فراخوان برای نمودار دونات پیکربندی شود، و اشاره می‌کند که فراخوان‌ها و ظاهر آن‌ها هنگام صادرات ارائه‌ها به فرمت‌های PDF، HTML5، SVG و تصاویر رستر حفظ می‌شوند.

## **استفاده از Callouts**

متدهای [getShowLabelAsDataCallout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) و [setShowLabelAsDataCallout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) در کلاس [DataLabelFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datalabelformat/) تعیین می‌کنند که آیا برچسب داده نمودار به‌صورت فراخوان یا به‌صورت برچسب داده معمولی نمایش داده شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم Callout برای نمودار دونات**

Aspose.Slides برای Python از طریق Java از تنظیم شکل فراخوان برچسب داده سری برای یک نمودار دونات پشتیبانی می‌کند. مثال زیر این را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا فراخوان‌ها هنگام تبدیل ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. فراخوان‌ها بخشی از رندر نمودار هستند، بنابراین هنگام صادرات به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/python-java/export-to-html5/)، [SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/)، یا [raster images](/slides/fa/python-java/convert-powerpoint-to-png/)، آن‌ها همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا قلم‌های سفارشی در فراخوان‌ها کار می‌کنند و آیا ظاهر آن‌ها می‌تواند در زمان صادرات حفظ شود؟**

بله. Aspose.Slides از [embedding fonts](/slides/fa/python-java/embedded-font/) در ارائه پشتیبانی می‌کند و در طول صادرات مانند [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، تعبیه قلم‌ها را کنترل می‌نماید تا فراخوان‌ها در سیستم‌های مختلف به‌یک شکل ظاهر شوند.