---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام بايثون
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/python-net/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- دفتر بيانات المخطط
- حساب الصيغ
- الثقافة المفضلة
- صيغة خاصة بالثقافة
- DBCS
- ثابت منطقي
- ثابت عددي
- ثابت نصي
- ثابت خطأ
- عامل حسابي
- عامل مقارن
- نمط A1
- نمط R1C1
- دالة معرفة مسبقًا
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تطبيق صيغ على نمط Excel في Aspose.Slides للبايثون عبر .NET باستخدام أوراق عمل المخطط، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مدمجة. في Aspose.Slides للـ Python عبر .NET، يمكنك الوصول إلى تلك الورقة من خلال دفتر بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ إلى الخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

توضح هذه المقالة سير العمل الكامل للصيغ: إنشاء مخطط، ملء ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغ المدعومة، مجموعة الدالات المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الأوراق الخاصة بالجدول.

## **أوراق عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة من قبل المخطط. في PowerPoint، يمكنك فحص الورقة بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة عمل مدمجة مفتوحة، تُظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تُعرض الورقة عبر [دفتر بيانات المخطط](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdataworkbook/). استخدم خاصية [formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/formula/) للصيغ بنمط A1 وخاصية [r1c1_formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا تزال الخلية المحسوبة تعرض نتيجتها عبر خاصية [value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/value/). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الكود أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

المثال التالي يوضح سير عمل متكامل من الطرف إلى الطرف. فهو يُنشئ مخطط عمودي مُجمَّع، ينظف البيانات التجريبية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الأرباح باستخدام صيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

نقاط بيانات المخطط تشير إلى `D2:D4`، لذا يستخدم المخطط قيم الأرباح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

يعرّف تدوين A1 الأعمدة بالحروف والصفوف بالأرقام. عيّن التعبيرات بنمط A1 عبر [IChartDataCell.formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

نماذج المراجع الشائعة بنمط A1 هي:

| مرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل أو نسخ الصيغة بواسطة تطبيق جدول بيانات. المراجع المطلقة تبقي الإحداثيين ثابتين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

يعرّف تدوين R1C1 الصفوف والأعمدة رقميًا. تستخدم المراجع النسبية إزاحات داخل أقواس مربعة. عيّن هذا النمط عبر [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

نماذج المراجع الشائعة بنمط R1C1 هي:

| مرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` تعني الخلية في نفس الصف لكن عمودين إلى اليسار (`B2`).

## **ثوابت الصيغ والعوامل**

يدعم مُقَيِّم الصيغ المدمج القيم المنطقية، القيم العددية، السلاسل، قيم أخطاء الجدول، والعوامل الحسابية ومقارنة.

### **الثوابت والليمِترات**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرةً في تعبيرات منطقية مثل `A2=TRUE`. |
| عددي | `1`, `0.5`, `.3`, `1E-2` | يدعم كل من الترميز العادي والعلمي. |
| سلسلة | `"abc"`, `"2/3/2020 12:00"` | تُحاط القيم النصية بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | قد تُقيِّم صيغة صالحة إلى قيمة خطأ جدول بدلاً من نتيجة عادية. |

يستخدم هذا المثال عدة أنواع من الثوابت:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # خاطئ
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **العوامل الحسابية**

| عامل | معنى | مثال |
|---|---|---|
| `+` | جمع أو علامة زائد أحادية | `2+3` |
| `-` | طرح أو نفي أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لتوضيح ترتيب التقييم، على سبيل المثال `(A2+B2)*C2`.

### **العوامل المقارنة**

تعيد تعبيرات المقارنة قيمًا منطقية.

| عامل | معنى | مثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدالات المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مُقَيِّم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدالات الموضحة في الجدول أدناه هي الوحيدة المدعومة. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| الدالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب عدد إلى أعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم النص | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم النص | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام التاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | البحث عن نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نصي على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | صيغة مرجعية | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | صيغة متجهة | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | صيغة متجهة | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

تُظهر القيود في الجدول أن `INDEX` موثقة بصيغة مرجعية، بينما `LOOKUP` و `MATCH` موثقتين بصورتهما المتجهتين. يستخدم `DATE` نظام تاريخ 1900. يجب اعتبار الدالات غير المدرجة هنا غير مدعومة من قِبَل مُقَيِّم الصيغ في Aspose.Slides إلا إذا وثقت بشكل منفصل.

## **حساب الصيغ مع ثقافة مفضلة**

تُفسّر بعض دالات دفتر العمل النص وفقًا لقواعد خاصة بالثقافة. وهذا مهم خاصةً للدالات التي تُستهدف لغات تستخدم مجموعات أحرف ذات بايتين (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/)، عيّن [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/spreadsheetoptions/) عبر [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/spreadsheet_options/)، ثم حمِّل العرض التقديمي.

المثال التالي يختار الثقافة اليابانية، يفتح عرضًا تقديميًا باستخدام خيارات التحميل المُكوَّنة، ويستدعي [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) لكل دفتر عمل مخطط:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

الثقافة المفضلة هي جزء من تكوين تحميل العرض التقديمي، لذا حدّدها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). استخدم الثقافة التي تتوقعها صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تُخزن ملفات الجدول كلاً من الصيغة والقيمة التي تم حسابها مؤخرًا. لذا يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [IChartDataCell.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/value/) عندما يُحمَّل العرض التقديمي ولم تُتغيّر بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يُثير قراءة قيمة خلية ذات بيانات غير مدعومة استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

إذا كان المخطط يعتمد على دالات Excel لا يقيِّمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جدول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مُخمنة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صالحة لكنها تُنتج نتيجة خطأ جدول مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يُعد رمز الخطأ نتيجة للخلية ويمكن إرجاعه عبر `value`.

قد تفشل الصيغة أيضًا أثناء التحليل، أو المرجع، أو التبعيات، أو على مستوى البيانات المدعومة. تُوفر Aspose.Slides استثناءات خاصة بالجدول لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

عند جلب الصيغ من القوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات موجه لمجموعة معرفة من حسابات الجداول، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدالات الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا من العروض المحملة لقطات، وليس بديلاً عن إعادة الحساب بعد التعديل.
- اختبر الصيغ من القوالب القائمة قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دالات خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جدول كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة الشائعة**

**ما الفرق بين `formula` و `r1c1_formula`؟**

[formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/formula/) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتوافق مع طريقة توليد أو نسخ الصيغ لديك.

**هل يجب علي قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) يُعيد كائن `IChartDataCell`. للحصول على النتيجة المحسوبة، اقرأ خاصية [value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/value/) لذلك بعد إعادة الحساب.

**متى يجب استدعاء `calculate_formulas`؟**

استدعِ [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقَيِّم المدمج.

**هل يدعم Aspose.Slides كل دالات Excel؟**

لا. يدعم المُقَيِّم المدمج مجموعة موثقة من الدالات. لا يجب افتراض أن الدالات خارج هذه المجموعة ستُعاد حسابها بشكل صحيح. إذا كنت تحتاج إلى توافق كامل مع صيغ Excel، نفِّذ الحساب باستخدام محرك جدول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض التقديمي المحمل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغيّر بيانات المخطط، قد لا يزال دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون تلك القيمة المخزنة صالحة. الوصول إلى خلية لا يمكن معالجة صيغتها قد يُثير استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات Python؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول تُنتج من حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يُحدَّث المخطط تلقائيًا عندما تتغيّر خلية الصيغة؟**

يمكن لسلسلة مخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو عرِض العرض التقديمي. إذا كانت نقاط بيانات المخطط تُشير إلى الخلايا المحسوبة، فإن المخطط يستخدم تلك القيم المحدثة؛ لا تحتاج إلى طريقة تحديث مخطط منفصلة لهذا السيناريو.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، يقتصر سير عمل حساب الصيغ الموضّح في هذه المقالة على دفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيمها Aspose.Slides. لا تفترض أن [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) يوفر إعادة حساب كاملة لصيغ عشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ مقيد بالمُحلِّل ومجموعة الدالات المدعومة. إذا كان المرجع عبر ورقة أو دفتر عمل خارجي ضروريًا، تحقق من صحة الصيغة مع إصدار Aspose.Slides المستهدف. للعمليات التي تتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

تُعيّن أمثلة API في Aspose.Slides تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون `=` أوليًا. استخدام هذا الشكل يحافظ على توافق الصيغ المُولَّدة مع أمثلة API الموثقة.