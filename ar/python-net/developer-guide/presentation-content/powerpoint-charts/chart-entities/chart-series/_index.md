---
title: إدارة سلاسل المخطط في بايثون
linktitle: سلاسل المخطط
type: docs
url: /ar/python-net/chart-series/
keywords:
- سلاسل المخطط
- تداخل السلاسل
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة بيانات
- تباعد السلسلة
- PowerPoint
- العرض التقديمي
- بايثون
- Aspose.Slides
description: "تعرّف على كيفية إدارة سلاسل المخطط في بايثون لبرنامج PowerPoint (PPT/PPTX) من خلال أمثلة عملية للشفرة وأفضل الممارسات لتعزيز عروض بياناتك."
---

المجموعة هي صف أو عمود من الأرقام المتخيلة في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل مجموعة المخططات**

باستخدام خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/)، يمكنك تحديد مدى تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد (مدى: -100 إلى 100). تنطبق هذه الخاصية على جميع المجموعات في مجموعة المجموعات العليا: هذه إسقاط للخاصية المناسبة للمجموعة. لذلك، هذه الخاصية للقراءة فقط.

استخدم خاصية `parent_series_group.overlap` القابلة للقراءة/الكتابة لتعيين القيمة التي تفضلها لـ `overlap`.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. أضف مخطط أعمدة متجمعة في شريحة.
3. الوصول إلى مجموعة المخطط الأولى.
4. الوصول إلى `parent_series_group` لمجموعة المخطط وتعيين قيمة التداخل المفضلة لمجموعة البيانات.
5. اكتب التقديم المعدل إلى ملف PPTX.

يوضح لك هذا الكود بلغة بايثون كيفية تعيين التداخل لمجموعة مخططات:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Adds chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # Sets series overlap
        series[0].parent_series_group.overlap = -30

    # Writes the presentation file to disk
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير لون المجموعة**
يسمح لك Aspose.Slides لـ بايثون عبر .NET بتغيير لون مجموعة بهذه الطريقة:

1. أنشئ مثيلاً لفئة `Presentation`.
2. أضف مخططًا في الشريحة.
3. الوصول إلى المجموعة التي تريد تغيير لونها.
4. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
5. حفظ التقديم المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية تغيير لون مجموعة:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[1]
	
	point.explosion = 30
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير لون فئة المجموعة**
يسمح لك Aspose.Slides لـ بايثون عبر .NET بتغيير لون فئة المجموعة بهذه الطريقة:

1. أنشئ مثيلاً لفئة `Presentation`.
2. أضف مخططًا في الشريحة.
3. الوصول إلى فئة المجموعة التي تريد تغيير لونها.
4. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
5. حفظ التقديم المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية تغيير لون فئة المجموعة:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[0]
	
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير اسم المجموعة** 

بشكل افتراضي، أسماء الأساطير لمخطط هي محتويات الخلايا الموجودة فوق كل عمود أو صف من البيانات. 

في مثالنا (صورة نموذجية)، 

* الأعمدة هي *المجموعة 1، المجموعة 2،* و *المجموعة 3*؛
* الصفوف هي *الفئة 1، الفئة 2، الفئة 3،* و *الفئة 4.* 

يسمح لك Aspose.Slides لـ بايثون عبر .NET بتحديث أو تغيير اسم مجموعة في بيانات المخطط الخاصة بها والأسطورة. 

يوضح لك هذا الكود بلغة بايثون كيفية تغيير اسم المجموعة في بيانات المخطط `ChartDataWorkbook`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "اسم جديد"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

يوضح لك هذا الكود بلغة بايثون كيفية تغيير اسم مجموعة في أسطورتها من خلال `Series`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "اسم جديد"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **تعيين لون تعبئة مجموعة المخططات**

يسمح لك Aspose.Slides لـ بايثون عبر .NET بتعيين لون التعبئة التلقائي لمجموعات المخططات داخل منطقة التخطيط بهذه الطريقة:

1. أنشئ مثيلاً لفئة `Presentation`.
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType.CLUSTERED_COLUMN`).
4. الوصول إلى مجموعة المخططات وتعيين لون التعبئة إلى تلقائي.
5. حفظ التقديم إلى ملف PPTX.

يظهر لك هذا الكود بلغة بايثون كيفية تعيين لون التعبئة التلقائي لمجموعة المخططات:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Creates a clustered column chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # Sets series fill format to automatic
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # Writes the presentation file to disk
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين ألوان التعبئة العكسية لمجموعة المخططات**
يسمح Aspose.Slides لك بتعيين لون التعبئة العكسية لمجموعات المخططات داخل منطقة التخطيط بهذه الطريقة:

1. أنشئ مثيلاً لفئة `Presentation`.
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType.CLUSTERED_COLUMN`).
4. الوصول إلى مجموعة المخططات وتعيين لون التعبئة إلى عكسي.
5. حفظ التقديم إلى ملف PPTX.

يوضح لك هذا الكود بلغة بايثون كيفية إجراء العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Adds new series and categories
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Takes the first chart series and populates its series data.
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين المجموعة للتReverse عند القيمة سالبة**
يسمح لك Aspose.Slides بتعيين الانعكاسات من خلال الخصائص `ChartDataPoint.invert_if_negative`. عندما يتم تعيين العكس باستخدام الخصائص، يقوم نقطة البيانات بعكس ألوانها عندما تحصل على قيمة سالبة.

يوضح لك هذا الكود بلغة بايثون كيفية إجراء العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
	series = chart.chart_data.series
	chart.chart_data.series.clear()

	series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series[0].invert_if_negative = False

	series[0].data_points[2].invert_if_negative = True

	pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **مسح بيانات نقاط البيانات المحددة**
يسمح لك Aspose.Slides لـ بايثون عبر .NET بمسح بيانات `data_points` لمجموعة مخططات معينة بهذه الطريقة:

1. أنشئ مثيلاً لفئة `Presentation`.
2. احصل على مرجع شريحة من خلال مؤشرها.
3. احصل على مرجع مخطط من خلال مؤشره.
4. قم بالتكرار على جميع `data_points` للمخطط وتعيين `x_value` و `y_value` إلى فارغ.
5. مسح جميع `data_points` لمجموعات مخططات معينة.
6. كتابة التقديم المعدل إلى ملف PPTX.

يوضح لك هذا الكود بلغة بايثون كيفية إجراء العملية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين عرض الفجوة للمجموعة**
يسمح لك Aspose.Slides لـ بايثون عبر .NET بتعيين عرض الفجوة للمجموعة من خلال خاصية **`gap_width`** بهذه الطريقة:

1. أنشئ مثيلاً لفئة `Presentation`.
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الوصول إلى أي مجموعة مخططات.
5. تعيين الخاصية `gap_width`.
6. كتابة التقديم المعدل إلى ملف PPTX.

يوضح لك هذا الكود بلغة بايثون كيفية تعيين عرض فجوة المجموعة:

```py
# Creates empty presentation 
with slides.Presentation() as presentation:

    # Accesses the presentation's first slide
    slide = presentation.slides[0]

    # Adds a chart with default data
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # Sets the index of the chart data sheet
    defaultWorksheetIndex = 0

    # Gets the chart data worksheet
    fact = chart.chart_data.chart_data_workbook

    # Adds series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Adds Categories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Takes the second chart series
    series = chart.chart_data.series[1]

    # Populates the series data
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Sets GapWidth value
    series.parent_series_group.gap_width = 50

    # Saves presentation to disk
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```