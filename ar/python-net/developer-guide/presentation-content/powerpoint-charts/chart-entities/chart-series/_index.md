---
title: إدارة سلاسل بيانات المخطط في بايثون
linktitle: سلاسل البيانات
type: docs
url: /ar/python-net/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل بيانات المخطط في بايثون لبرنامج PowerPoint (PPT/PPTX) باستخدام أمثلة عملية على الشيفرة وأفضل الممارسات لتحسين عروض بياناتك."
---

## **نظرة عامة**

تصف هذه المقالة دور [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) في Aspose.Slides for Python، مع التركيز على كيفية تنظيم البيانات وتصويرها داخل العروض التقديمية. توفر هذه الكائنات العناصر الأساسية التي تحدد مجموعات منفصلة من نقاط البيانات، الفئات، ومعلمات المظهر في المخطط. من خلال العمل مع [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/)، يمكن للمطورين دمج مصادر البيانات الأساسية بسلاسة والحفاظ على تحكم كامل في طريقة عرض المعلومات، مما ينتج عروضاً تقديمية ديناميكية مدفوعة بالبيانات تنقل الأفكار والتحليل بوضوح.

السلسلة هي صف أو عمود من الأرقام يتم تمثيله في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل السلسلة**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) تتحكم الخاصية في كيفية تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد عن طريق تحديد نطاق من -100 إلى 100. بما أن هذه الخاصية مرتبطة بمجموعة السلاسل وليس بالسلسلة الفردية، فهي للقراءة فقط على مستوى السلسلة. لتكوين قيم التداخل، استخدم الخاصية `parent_series_group.overlap` القابلة للقراءة والكتابة، التي تطبق التداخل المحدد على جميع السلاسل في تلك المجموعة.

فيما يلي مثال بلغة Python يوضح كيفية إنشاء عرض تقديمي، إضافة مخطط أعمدة مجمع، الوصول إلى السلسلة الأولى في المخطط، ضبط إعداد التداخل، ثم حفظ النتيجة كملف PPTX:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مجمع ببيانات افتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # تعيين تداخل السلسلة.
        series.parent_series_group.overlap = series_overlap

    # حفظ ملف العرض التقديمي على القرص.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:
![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

تجعل Aspose.Slides من السهل تخصيص ألوان تعبئة سلاسل المخطط، مما يتيح لك تمييز نقاط بيانات معينة وإنشاء مخططات جذابة بصرياً. يتم ذلك عبر كائن [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/)، الذي يدعم أنواع تعبئة مختلفة، وتكوينات ألوان، وخيارات تنسيق متقدمة أخرى. بعد إضافة مخطط إلى شريحة والوصول إلى السلسلة المطلوبة، ما عليك سوى الحصول على السلسلة وتطبيق لون التعبئة المناسب. بخلاف التعبئة الصلبة، يمكنك أيضًا الاستفادة من التعبئة المتدرجة أو نمطية للحصول على مرونة تصميمية محسنة. بمجرد ضبط الألوان وفق متطلباتك، احفظ العرض التقديمي لتثبيت المظهر المحدث.

يظهر مثال الشيفرة التالي بلغة Python كيفية تغيير لون السلسلة الأولى:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مجمع ببيانات افتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # تعيين لون السلسلة الأولى.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # حفظ ملف العرض التقديمي على القرص.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:
![لون السلسلة](series_color.png)

## **إعادة تسمية سلسلة**

توفر Aspose.Slides طريقة بسيطة لتعديل أسماء سلاسل المخطط، مما يسهل تسمية البيانات بطريقة واضحة ذات معنى. من خلال الوصول إلى الخلية المناسبة في ورقة العمل داخل بيانات المخطط، يمكن للمطورين تخصيص طريقة عرض البيانات. يكون هذا التعديل مفيدًا خصوصًا عندما تحتاج أسماء السلاسل إلى تحديث أو توضيح بناءً على سياق البيانات. بعد إعادة تسمية السلسلة، يمكن حفظ العرض التقديمي لتثبيت التغييرات.

فيما يلي مقتطف شفرة بلغة Python يوضح هذه العملية عمليًا.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مجمع ببيانات افتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # تعيين اسم السلسلة الأولى.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # حفظ ملف العرض التقديمي على القرص.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


تظهر الشيفرة التالية بلغة Python طريقة بديلة لتغيير اسم السلسلة:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مجمع ببيانات افتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # تعيين اسم السلسلة الأولى.
    series.name.as_cells[0].value = series_name

    # حفظ ملف العرض التقديمي على القرص.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


النتيجة:
![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

تتيح Aspose.Slides for Python الحصول على لون التعبئة التلقائي لسلاسل المخطط داخل منطقة الرسم. بعد إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، يمكنك الحصول على مرجع للشفرة المطلوبة باستخدام الفهرس، ثم إضافة مخطط باستخدام النوع المفضلة لديك (مثل `ChartType.CLUSTERED_COLUMN`). من خلال الوصول إلى السلسلة في المخطط، يمكنك الحصول على لون التعبئة التلقائي.

توضح الشيفرة التالية بلغة Python هذه العملية بالتفصيل.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مجمع ببيانات افتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # الحصول على لون تعبئة السلسلة.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


مثال على المخرجات:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **تعيين ألوان تعبئة معكوسة لسلسلة**

عندما تحتوي سلسلة البيانات الخاصة بك على قيم موجبة وسالبة، فإن تلوين كل عمود أو شريط بنفس اللون قد يجعل المخطط يصعب قراءته. تتيح Aspose.Slides for Python تعيين لون تعبئة معكوس—تعبئة منفصلة تُطبق تلقائيًا على نقاط البيانات التي تقع تحت الصفر—حتى تبرز القيم السالبة بصورة فورية. في هذا القسم ستتعلم كيفية تفعيل هذا الخيار، اختيار اللون المناسب، وحفظ العرض التقديمي المحدث.

يظهر المثال التالي الشيفرة العملية:
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

    # إضافة فئات جديدة.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # إضافة سلسلة جديدة.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # تعبئة بيانات السلسلة.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # تعيين إعدادات اللون للسلسلة.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:
![لون التعبئة الصلب المعكوس](inverted_solid_fill_color.png)

يمكنك عكس لون التعبئة لنقطة بيانات واحدة بدلاً من السلسلة بأكملها. ما عليك سوى الوصول إلى `ChartDataPoint` المطلوبة وتعيين الخاصية `invert_if_negative` إلى `True`.

يوضح المثال التالي كيفية القيام بذلك:
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

أحيانًا يحتوي المخطط على قيم اختبار أو قيم شاذة أو إدخالات غير صالحة تحتاج إلى إزالتها دون إعادة بناء السلسلة بأكملها. تتيح Aspose.Slides for Python استهداف أي نقطة بيانات عن طريق الفهرس، مسح محتواها، وتحديث الرسم فورًا بحيث تتحرك النقاط المتبقية وتُعيد المحاور ضبط الحجم تلقائيًا.

يوضح المثال التالي العملية:
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

يتحكم عرض الفجوة في مقدار المساحة الفارغة بين الأعمدة أو الأشرطة المتجاورة—الفجوات الأوسع تبرز الفئات الفردية، بينما الفجوات الضيقة تخلق مظهرًا أكثر كثافة وتضييقًا. عبر Aspose.Slides for Python يمكنك ضبط هذه المعلمة بدقة لسلسلة كاملة، لتحقيق التوازن البصري المطلوب في عرضك التقديمي دون تعديل البيانات الأساسية.

يوضح المثال التالي كيف يمكن تعيين عرض الفجوة لسلسلة:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# إنشاء عرض تقديمي فارغ.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط ببيانات افتراضية.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # حفظ العرض التقديمي على القرص.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # تعيين قيمة gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # حفظ العرض التقديمي على القرص.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:
![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا تفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي يمكن إضافتها. الحد العملي يحدده وضوح المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل التجمع قريبة جدًا أو متباعدة جدًا؟**

قم بضبط إعداد [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) لتلك السلسلة (أو مجموعة السلاسل الأم). زيادة القيمة توسع المسافة بين الأعمدة، بينما تقليلها يقربها من بعضها.