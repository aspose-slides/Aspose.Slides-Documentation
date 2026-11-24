---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Python
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-net/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- ملصق البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة المخطط المؤقتة
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides للغة Python عبر .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر عمل المخطط في Aspose.Slides. تعرض كيفية قراءة وكتابة بيانات المخطط من خلال تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

وتغطي أيضًا العمل مع دفاتر عمل خارجية كمصادر بيانات للمخطط. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-net/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `True` لرسم الخلايا المرئية فقط، أو على `False` لتضمين كل من الخلايا المرئية والمخفية. يتحكم هذا الإعداد في رسم المخطط فقط؛ ولا يخفي أو يُظهر صفوف أو أعمدة ورقة العمل.

يحتوي [العرض التقديمي النموذجي](hidden-source-data.pptx) على مخطط عمودي كأول شكل في الشريحة الأولى. يحتوي ورقة العمل المضمنة، `Sheet1`، على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: شهر | B: تجزئة | C: جملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) وقراءة [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) لفحص حالتها المخفية. هذه الخاصية للقراءة فقط. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على التوالي.

في هذا المثال، عاِد تحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمن باستخدام [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) وأعد تحميله باستخدام [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). عند تضمين كل الخلايا، استخدم أيضًا [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لاستعادة النطاق الكامل، بما في ذلك الفئة المخفية فبراير. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وعلامات الفئات في هذا المثال.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # تحديث بيانات المخطط من دفتر العمل المضمن.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        # الشكل الأول ليس مخططًا.
        print("The first shape is not a chart.")
```

يحفظ المثال نسختين من العرض التقديمي: واحدة فقط بالقيم التجزئة المرئية (10 و20)، وأخرى بكل القيم الستة. تم إنشاء الصور أدناه من العروض التقديمية المحفوظة بعد إعادة فتحها؛ كلا الملفين يحافظان على إعداد الرسم المعين. يبقى الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمنين.

| الخلايا المرئية فقط (`True`) | كل الخلايا (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) في كيفية عرض القيم المفقودة؛ ولا يشمل أو يستثني البيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-net/chart-series/#control-the-display-of-empty-cells) لمثال.

## **استرجاع نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُرجع طريقة [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) النطاق الحالي كصيغة مؤهلة بورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 بما فيها. تشير علامات الدولار إلى مراجع صف وعمود مطلقة.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل. إذا لم يستخدم المخطط دفتر عمل كمصدر بيانات، تُلقى استثناء. لمزيد من المعلومات، راجع [مرجع API لـ ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويفحص الأشكال مباشرةً في كل شريحة للبحث عن مخططات. يطبع اسم كل مخطط ونطاق المصدر. إذا تعذر استرجاع النطاق، يطبع رسالة تشخيصية ويستمر إلى المخطط التالي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

يوفر Aspose.Slides for Python via .NET طريقتي [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) اللتين تسمحان بقراءة وكتابة دفاتر عمل بيانات المخطط (المحتوية على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمن إلى تدفق، يمسح السلاسل والفئات الحالية، ويكتب نفس دفتر العمل مرة أخرى. يبقى التغييرات في الذاكرة؛ لا يحفظ المثال العرض التقديمي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلاسل الفئات والمجموعات الأصلية. قد يتسبب هذا الاختلاف في فشل [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) مع خطأ "index-out-of-range". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدّث إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. العلامة التعليقية تشير إلى مكان تحرير دفتر العمل؛ يكتب المثال دفتر العمل الأصلي مرة أخرى ويُصَدِّق التخطيط في الذاكرة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # تعديل تدفق دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

إزالة المجموعات تُزيل مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تعيينات فئات مطلوبة لدفتر العمل المحدّث قبل استخدام المخطط.

## **اختيار طريقة تخزين ملصقات الفئة**

قم بتعيين [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) بينما تكون مجموعة الفئات فارغة. اضبطها على `True` للملصقات التي تشير إلى خلايا ورقة العمل أو تشكّل هيكلًا هرميًا، مثل الفصول الربعية المجمعة حسب السنة. اضبطها على `False` لمستوى واحد من الملصقات المقدمة كسلاسل نصية. يطبق هذا الإعداد فقط على الفئات. كلا المخططين في المثال يستخدمان خلايا ورقة العمل لقيم السلاسل الرقمية.

ينشئ المثال مخططين عموديين ويطبع وضع التخزين والملصقات `Q1 Q2 Q3 Q4` لكل منهما. بالنسبة للملصقات المدعومة بخلايا، تُعيد [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) خلية ورقة العمل، وتُعيد [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) الملصق المخزن فيها. بالنسبة للملصقات الحرفية، اقرأ السلسلة مباشرةً من [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيقات رقمية مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) للتحكم في كيفية ظهور القيم الرقمية في دفتر العمل المضمن للمخطط. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربع خانات عشرية ومعامل بخمس خانات عشرية. احفظ القيمتين كأرقام لتظل متاحة للحسابات ورسم المخطط.

تنسيق الرقم يغيّر العرض فقط، لا القيمة المخزنة. التنسيق `0.0000%` يعرض `0.125` كـ `12.5000%`؛ ولا يستبدل الرقم المخزن بـ `12.5`. بالمثل، `0.00000` يعرض `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستخدم [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) بدلاً منه.

المثال التالي ينشئ مخطط عمودي ويصل إلى خلاياه عبر [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلتا الخليتين تُزوّدان قيم المخطط. يُمكّن المثال أيضًا ملصقات القيم المرتبطة بالتنسيقات المصدر.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات المحددة مباشرةً على محاور المخطط أو ملصقات البيانات. في هذا المثال، كل ملصق يعرض قيمة خلية المصدر لأنه تم تمكين [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)، ويتبع تنسيق الرقم المصدر لأن [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) هي `True`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر الملصقات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي تنسيقه الخاص [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) وهو `0.00`، مع ضبط [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) إلى `False`.

لتنسيق ملصق بيانات بشكل مستقل، عيّن علم الارتباط بالمصدر إلى `False` وعيّن [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). لا يغيّر ذلك تنسيق خلية دفتر العمل. على سبيل المثال، تنسيق مستقل للملصق بـ `0.00` يعرض القيمة الأولى كـ `0.13`، بينما لا يزال B2 يُظهر `12.5000%`. راجع [ملصقات بيانات المخطط](/slides/ar/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق الملصق مباشرةً.

الصورة أدناه تم توليدها من العرض التقديمي المحفوظ بعد إعادة فتحه:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **استخدام خلية دفتر العمل كملصق بيانات مخطط**

يمكنك استخدام النص من خلايا دفتر العمل كملصقات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للملصقات الثلاث الأولى في السلسلة الأولى، يمكّن الملصقات من الخلايا، ويحفظ العرض التقديمي المحدث.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة أوراق العمل**

توفر الخاصية [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **تحديد نوع مصدر البيانات**

يمكن أيضًا تخزين قيم نقاط السلسلة مباشرةً كقيمة رقمية حرفية. راجع [تعيين قيم السلسلة باستخدام القيم الرقمية الحرفية](/slides/ar/python-net/chart-series/#set-series-values-using-numeric-literals) لمثال كامل يحفظ ويقرأ هذه القيم. نوع مصدر القيم منفصل عن تكوين دفتر العمل الداخلي أو الخارجي للمخطط؛ ولا يؤدي استخدام القيم الرقمية الحرفية إلى إزالة دفتر العمل المضمن.

ينشئ هذا المثال مخطط عمودي ثلاثي الأبعاد ببيانات افتراضية ويعيّن اسمي سلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم سلسلة حرفية؛ والثاني يستخدم الخلية C1 في ورقة العمل 0. يختار تعداد [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بأسماء السلاسل المحدّثة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **كشف تنسيقات دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام الخاصية [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) على [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مدمج.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يغلق تدفق الإخراج قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض التقديمي المرتبط.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من عدم إمكانية تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر العمل الخارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لتعيين A1:B4 كسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

معامل `update_chart_data` في طريقة [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يتحكم فيما إذا تم تحميل دفتر العمل.

* عندما يكون `update_chart_data` مساويًا لـ `False`، يُحدَّث مسار دفتر العمل فقط. لا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل الهدف، وبالتالي يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `update_chart_data` مساويًا لـ `True`، تُحدَّث بيانات المخطط من دفتر العمل الهدف.

يُظهر المثال التالي تعيين عنوان URL نائب مع `update_chart_data` مضبوطًا على `False`. يحتفظ بالبيانات الافتراضية للمخطط الدائري ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **الحصول على مسار دفتر العمل المصدر للبيانات الخارجية لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واسترجع مسار دفتر العمل الخاص به.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان شكلًا مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتويات الدفاتر الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُطرح استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بدفتر عمل خارجي يمكن الوصول إليه. يضبط القيمة المدعومة بالخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المحدَّث. يمكن لتحرير قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة للحفاظ على دفتر العمل الأصلي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **استعادة دفتر عمل من ذاكرة مخطط التخزين المؤقت**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)، واضبط [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)، ثم عيّن [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) إلى `True` قبل فتح العرض التقديمي.

يعيد المثال التالي في Python بيانات دفتر العمل لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) و[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
    else:
        print("The first shape is not a chart.")
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُطرح Aspose.Slides استثناء. فعِّل الاستعادة فقط عندما يكون الاعتماد على بيانات المخطط المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكر المؤقت قد لا يحتوي على تغييرات تم إجراؤها على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبط بدفتر عمل خارجي أو مضمّن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد تحتاج إلى تحديث الرابط إذا تم نقل دفتر العمل.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد شبكة/مشاركات؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً؛ يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). يمكن أيضًا لتعديل بيانات المخطط المدعومة بالخلية تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان يجب بقاء الأصل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا يقبل Aspose.Slides كلمة مرور عند الربط. يُنصَح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) والربط بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس على كل مخطط في المرة التالية التي تُحمَّل فيها البيانات.