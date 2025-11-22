---
title: إدارة سلاسل المخطط في بايثون
linktitle: سلسلة المخطط
type: docs
url: /ar/python-net/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة بيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية إدارة سلاسل المخطط في بايثون لبرنامج PowerPoint (PPT/PPTX) باستخدام أمثلة عملية على الشيفرة وأفضل الممارسات لتحسين عروض البيانات الخاصة بك."
---

## **نظرة عامة**

هذا المقال يصف دور [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) في Aspose.Slides for Python، مع التركيز على كيفية هيكلة البيانات وتصورها داخل العروض التقديمية. توفر هذه الكائنات العناصر الأساسية التي تحدد مجموعات نقاط البيانات الفردية والفئات ومعلمات المظهر في المخطط. من خلال العمل مع [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/)، يمكن للمطورين دمج مصادر البيانات الأساسية بسلاسة والحفاظ على التحكم الكامل في طريقة عرض المعلومات، مما ينتج عروضًا تقديمية ديناميكية قائمة على البيانات تنقل الأفكار والتحليل بوضوح.

السلسلة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![سلسلة-الرسم-البياني-في-بوربوينت](chart-series-powerpoint.png)

## **تعيين تداخل السلسلة**

خاصية [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) تتحكم في كيفية تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد عن طريق تحديد نطاق من -100 إلى 100. بما أن هذه الخاصية مرتبطة بمجموعة السلاسل بدلاً من كل سلسلة مخطط على حدة، فهي للقراءة فقط على مستوى السلسلة. لتكوين قيم التداخل، استخدم خاصية `parent_series_group.overlap` القابلة للقراءة والكتابة، والتي تطبق التداخل المحدد على جميع السلاسل في تلك المجموعة.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف مخطط عمودي متجمع مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # تعيين تداخل السلسلة.
        series.parent_series_group.overlap = series_overlap

    # حفظ ملف العرض التقديمي إلى القرص.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

يتيح Aspose.Slides تخصيص ألوان تعبئة سلاسل المخطط بسهولة، مما يسمح لك بتمييز نقاط بيانات معينة وإنشاء مخططات جذابة بصريًا. يتم ذلك عبر كائن [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/)، الذي يدعم أنواع تعبئة مختلفة وتكوينات ألوان وخيارات تنسيق متقدمة أخرى. بعد إضافة مخطط إلى شريحة والوصول إلى السلسلة المطلوبة، احصل على السلسلة وطبق لون التعبئة المناسب. بخلاف التعبئة الصلبة، يمكنك أيضًا الاستفادة من تعبئة التدرج أو النمط لتوفير مرونة تصميمية أكبر. بمجرد ضبط الألوان وفقًا لمتطلباتك، احفظ العرض التقديمي لتثبيت المظهر المحدث.

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف مخطط عمودي متجمع مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # حدد لون السلسلة الأولى.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # احفظ ملف العرض التقديمي إلى القرص.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![لون السلسلة](series_color.png)

## **إعادة تسمية سلسلة**

يوفر Aspose.Slides طريقة بسيطة لتعديل أسماء سلاسل المخطط، مما يسهل تسمية البيانات بطريقة واضحة وذات معنى. من خلال الوصول إلى خلية ورقة العمل ذات الصلة ببيانات المخطط، يمكن للمطورين تخصيص طريقة عرض البيانات. هذا التعديل مفيد خصوصًا عندما تحتاج أسماء السلاسل إلى تحديث أو توضيح بناءً على سياق البيانات. بعد إعادة تسمية السلسلة، يمكن حفظ العرض التقديمي لتثبيت التغييرات.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف مخطط عمودي متجمع مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # تحديد اسم السلسلة الأولى.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # احفظ ملف العرض التقديمي إلى القرص.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


الشفرة البديلة لتغيير اسم السلسلة:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف مخطط عمودي متجمع مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # تعيين اسم السلسلة الأولى.
    series.name.as_cells[0].value = series_name

    # احفظ ملف العرض التقديمي إلى القرص.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


النتيجة:

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

يسمح Aspose.Slides for Python بالحصول على لون التعبئة التلقائي لسلاسل المخطط داخل منطقة الرسم. بعد إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والحصول على المرجع إلى الشريحة المطلوبة عبر الفهرس، يمكنك إضافة مخطط من النوع المفضل (مثل `ChartType.CLUSTERED_COLUMN`). من خلال الوصول إلى السلسلة في المخطط، يمكنك استخراج لون التعبئة التلقائي.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف مخطط عمودي متجمع مع البيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # احصل على لون تعبئة السلسلة.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **تعيين تعبئة عكسية للسلسلة**

عندما تحتوي سلسلة البيانات على قيم موجبة وسالبة، قد يجعل تلوين كل عمود أو شريط باللون نفسه المخطط صعب القراءة. يتيح Aspose.Slides for Python تعيين لون تعبئة عكسي — تعبئة منفصلة تُطبق تلقائيًا على نقاط البيانات التي تقع تحت الصفر — وبذلك تبرز القيم السالبة بنظرة واحدة. في هذا القسم ستتعلم كيفية تفعيل هذا الخيار، اختيار لون مناسب، وحفظ العرض التقديمي المحدث.

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # أضف فئات جديدة.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # أضف سلسلة جديدة.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # املأ بيانات السلسلة.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # حدد إعدادات اللون للسلسلة.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![لون التعبئة الصلب العكسي](inverted_solid_fill_color.png)

يمكنك عكس لون التعبئة لنقطة بيانات واحدة بدلاً من السلسلة بأكملها. ما عليك سوى الوصول إلى `ChartDataPoint` المطلوبة وتعيين خاصية `invert_if_negative` إلى `True`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **مسح البيانات لنقاط بيانات محددة**

أحيانًا يحتوي المخطط على قيم اختبارية، قيم شاذة، أو مدخلات قديمة تحتاج إلى إزالتها دون إعادة بناء السلسلة بالكامل. يتيح Aspose.Slides for Python استهداف أي نقطة بيانات عبر الفهرس، مسح محتواها، وتحديث المخطط فورًا بحيث تنقل النقاط المتبقية وتُعاد مقياس المحاور تلقائيًا.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين عرض الفجوة للسلسلة**

يتحكم عرض الفجوة في مقدار المساحة الفارغة بين الأعمدة أو الأشرطة المتجاورة — زيادة الفجوة تُبرز الفئات الفردية، بينما تقليل الفجوة يخلق مظهرًا أكثر كثافة وضغطًا. من خلال Aspose.Slides for Python يمكنك ضبط هذه المعلمة لسلسلة كاملة، لتحقيق التوازن البصري المطلوب في العرض التقديمي دون تعديل البيانات الأساسية.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# أنشئ عرض تقديمي فارغ.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # أضف مخططًا بالبيانات الافتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # احفظ العرض التقديمي إلى القرص.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # ضبط قيمة gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # احفظ العرض التقديمي إلى القرص.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![عرض الفجوة](gap_width.png)

## **الأسئلة الشائعة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا يفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي يمكنك إضافتها. الحد العملي يُحدد بقراءة المخطط والذاكرة المتوفرة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة العنقودية متقاربة جدًا أو متباعدة جدًا؟**

قم بضبط إعداد [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) لتلك السلسلة (أو مجموعة السلاسل الأم). زيادة القيمة تُوسّع المسافة بين الأعمدة، بينما تقليلها يجعلهما أقرب.