---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از پایتون
linktitle: برچسب داده
type: docs
url: /fa/python-java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های دادهٔ نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای پایتون از طریق جاوا اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی درباره سری‌های نمودار و نقاط دادهٔ جداگانه نمایش می‌دهند و به خوانندگان کمک می‌کنند مقدارها را تشخیص داده و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقدارها را قالب‌بندی کنید، درصدها را نمایش دهید، متن برچسب را بخوانید، برچسب‌ها را فراتر از حداکثر محور کنترل کنید، فاصلهٔ برچسب محور دسته‌بندی را تنظیم کنید و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنید.

## **تعداد برچسب‌های دادهٔ قابل مشاهده**

از [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels) برای بررسی تعداد برچسب‌هایی که پیش از انتشار ارائه فعال هستند استفاده کنید. برخلاف [getCount](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount) که تعداد کل برچسب‌های موجود در مجموعه را برمی‌گرداند، این متد پیش‌فرض‌های سری و تنظیمات برچسب‌های فردی را در نظر می‌گیرد.

این مثال یک نمودار ستونی با یک سری و سه نقطه داده ایجاد می‌کند. مجموعهٔ برچسب‌های سری را از طریق [getLabels](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) دریافت می‌کند و تعداد قابل مشاهده را هنگام تغییر تنظیمات چاپ می‌کند: **0, 3, 2, 3**. تعداد کل ثابت می‌ماند **3**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # کل: 3; قابل مشاهده: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # قابل مشاهده: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # قابل مشاهده: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # قابل مشاهده: 3
finally:
    presentation.dispose()
```

متد [getDefaultDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) تنظیمات پیش‌فرض را فراهم می‌کند. انتقال مقدار `True` به [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) در آن، مقدارها را برای هر سه برچسب نمایش می‌دهد. انتقال مقدار `False` از طریق [getDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) یک برچسب خاص، تنظیم آن را برای برچسب منتخب لغو می‌کند. انتقال مقدار `True` به [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) باعث می‌شود آن برچسب دوباره به عنوان قابل مشاهده در نظر گرفته شود، حتی اگر مقدارش مخفی بماند.

تعداد قابل مشاهده تنظیمات مرئی را منعکس می‌کند. این عدد نشان‌دهندهٔ این نیست که برچسب‌ها هم‌پوشانی دارند، بریده شده‌اند یا در نمودار رندر شده قابل خواندن هستند.

## **تنظیم دقت عددی در برچسب‌های دادهٔ نمودار**

از [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) برای قالب‌بندی مقادیر سری استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌کند. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقدارهای پایه نمایش می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای قالب‌بندی سلول‌های عددی در کتاب‌کار جاسازی‌شدهٔ نمودار، به [Set Custom Number Formats for Workbook Cells](/slides/fa/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells) نگاه کنید. آن مثال همچنین نشان می‌دهد برچسب‌های مقدار پس از قالب‌های سلول منبع خود نمایش داده می‌شوند در حالی که مقادیر عددی ذخیره‌شده حفظ می‌شوند.

## **نمایش درصد به عنوان برچسب**

برای یک نمودار ستونی پشته‌ای، هر مقدار را به عنوان درصدی از مجموع دستهٔ مربوطه محاسبه کنید و متن را به قاب متنی که توسط [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) بازگردانده می‌شود اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در فونت ۸ نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر رد می‌شوند. اگر داده‌های نمودار تغییر کنند متن سفارشی برچسب باید دوباره محاسبه شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به صورت کسر ذخیره می‌شوند، از [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) برای نمایش درصدها استفاده کنید. مقدار `False` را به [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) بدهید تا قالب برچسب مستقل از سلول‌های منبع باشد.

این مثال یک نمودار ستونی ۱۰۰٪ پشته‌ای با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به مجموع ۱ می‌رسد. قالب برچسب `0.0%` مقدار 0.30 را به عنوان 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید ۱۰ نقطه‌ای استفاده می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **خواندن متن واقعی برچسب‌های داده**

از [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) برای دریافت متنی که توسط تنظیمات برچسب داده تولید می‌شود استفاده کنید. این روش زمانی مفید است که برچسب‌ها را برای گزارش‌ها استخراج کنید، محتوای ارائه را جستجو کنید یا نمودارهای تولیدشده را اعتبارسنجی کنید. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) هر نام دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدارش را به درصد قالب‌بندی می‌کند و نقطهٔ دیگر متن سفارشی را از [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) دریافت می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

عدد ذخیره‌شده در یک نقطه داده همان `0.75` می‌ماند، حتی زمانی که برچسب آن `75%` را به همراه نام دسته و سری نشان می‌دهد. متن سفارشی متن تولیدشدهٔ برچسب را جایگزین می‌کند. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) در هر دو حالت رشتهٔ نهایی برچسب را برمی‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج فقط برچسب‌های قابل مشاهده باید به‌صورت جداگانه از [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) استفاده کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن عبور کنند. از [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) برای کنترل نمایش برچسب‌های آن‌ها استفاده کنید. این تنظیم فقط نمایش برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر پایه داده را تحت تأثیر قرار نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای ۲D با مقادیر ۶۰ و ۱۲۰ ایجاد می‌کند. مقدار `False` به [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) داده می‌شود و حداکثر به ۱۰۰ با [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) روی محور عمودی تنظیم می‌شود. اسلاید اول اجازهٔ برچسب‌های فراتر از حداکثر را می‌دهد؛ یک کپی از آن اسلاید این ویژگی را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) فعال کنید. تنظیم سطح نمودار به تنهایی نمایش مقدار را فعال نمی‌کند یا تنظیم غیرفعال یک برچسب منفرد را بازنویسی نمی‌کند. این مثال مقدارها را برای تمام سری فعال می‌کند و با [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصاویر زیر اسلایدهای ذخیره‌شده رندر شده توسط Microsoft PowerPoint را نشان می‌دهند. با `True`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با `False`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** است.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی ۲D با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محور برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصلهٔ برچسب از محور**

از [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) برای کنترل فاصلهٔ بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار بر حسب درصد حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و افست افقی محور به مقدار ۵۰۰ تنظیم می‌گردد. این تنظیم بر برچسب‌های محور دسته‌بندی اثر می‌گذارد نه بر برچسب‌های پیوست به نقاط دادهٔ فردی.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فاصله و ایجاد فضا برای خطوط راهنمایی تنظیم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را خارج از برش قرار می‌دهد و افست‌های افقی و عمودی را با استفاده از [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) و [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) تنظیم می‌کند. این افست‌ها به ترتیب نسبت به عرض و ارتفاع نمودار هستند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![نمودار دایره‌ای با موقعیت برچسب داده تنظیم‌شده](pie-chart-adjusted-label.png)

## **قالب‌بندی خطوط راهنما**

زمانی که برچسب‌های نمودار دایره‌ای بیرون از برش‌های خود قرار می‌گیرند، خطوط راهنما به خوانندگان کمک می‌کند تا هر مقدار را به برش صحیح مرتبط کنند. یک رنگ متضاد و خطی کمی ضخیم می‌تواند این ارتباط را آسان‌تر کند، در حالی که شفافیت و سبک خط نقطه‌ای خطوط را از دید بصری کمتر می‌کند.

از [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) برای قالب‌بندی خطوط راهنما در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات موجود در `series.getLabels().getLeaderLinesFormat().getLine()` به کل مجموعه اعمال می‌شود، نه به برچسب‌های منفرد.

این مثال یک نمودار دایره‌ای با داده پیش‌فرض ایجاد می‌کند، مقادیر را خارج از برش‌ها نمایش می‌دهد و [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) را فعال می‌کند. با استفاده از افست‌های [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) و [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) دو برچسب را از برش‌هایشان دورتر می‌برد. ارائهٔ ورودی نیازی نیست.

[ getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) یک رنگ آبی ثابت با مقدار آلفا ۱۹۱ از ۲۵۵ تنظیم می‌کند که تقریباً ۲۵٪ شفافیت دارد. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ضخامت را به ۲ نقطه تنظیم می‌کند و [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) خط را نقطه‌ای می‌کند.

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # دو برچسب را دورتر از برش‌هایشان جابجا کنید.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

فعال‌سازی خطوط راهنما تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. قابلیت دیده شدن بستگی به موقعیت برچسب و رفتار چیدمان نمودار دارد. در این مثال دو برچسب جابجا شده خطوط راهنمای قابل رؤیتی دارند؛ برچسب‌هایی که نزدیک برش‌های خود می‌مانند نیازی به این خطوط ندارند.

تصویر زیر فایل `FormattedLeaderLines.pptx` ذخیره‌شده را که با Aspose.Slides رندر شده است نشان می‌دهد:

![نمودار دایره‌ای با خطوط راهنمای آبی، نیمه‌شفاف و نقطه‌ای که دو برچسب خارجی را به برش‌هایشان متصل می‌کند](formatted-leader-lines.png)

## **افزودن چند ردیف برچسب‌های داده بالای یک نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ نمودار ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نشان می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پر کردن و حاشیه مخفی می‌شوند. متد [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) تمام سه سری را با مراکز دستهٔ یکسان هم‌تراز می‌کند.

تنظیمات [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) فضای لازم برای ردیف‌های برچسب را محفوظ می‌سازد. پس از اینکه [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) موقعیت‌های پیش‌فرض را محاسبه کرد، [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) و [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) تراز افقی را حفظ کرده و افست‌های عمودی را برای چینش برچسب‌ها در دو ردیف اعمال می‌کنند. عددها همچنان برچسب‌های دادهٔ مرتبط با مقادیر سری هستند؛ تنها سرعنوان‌های ردیف به‌صورت شکل‌های متنی جداگانه هستند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # ستون‌های B و C را پنهان کنید، اما برچسب‌های دادهٔ آن‌ها را نگه دارید.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # تمام سه سری را با مراکز دسته‌ای یکسان هم‌تراز کنید.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # برای این مثال فشرده خطوط شبکه کمتری استفاده کنید.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # فضای کافی در بالای ناحیهٔ نمودار برای دو ردیف برچسب‌های داده رزرو کنید.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # موقعیت افقی پیش‌فرض را حفظ کنید. Y یک جابجایی از
            # موقعیت پیش‌فرض برچسب است که به صورت کسری از ارتفاع نمودار بیان می‌شود.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # فقط عنوان ردیف یک شکل متنی جداگانه است.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ نمودار](multiple-rows-of-labels.png)

## **پرسش‌های متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای شلوغ جلوگیری کنم؟**

از ترکیب قرارگیری خودکار برچسب، خطوط راهنما و کاهش اندازهٔ قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای مقادیر انتهایی یا نقاط کلیدی برچسب نشان دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را پیش از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش را برای مقادیر ۰، مقادیر منفی یا مقادیر گمشده طبق قانون تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب را هنگام خروجی به PDF/تصویرها ثابت نگه دارم؟**

قابلاً خانوادهٔ قلم و اندازه را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ قلم پیش‌فرض جلوگیری شود.