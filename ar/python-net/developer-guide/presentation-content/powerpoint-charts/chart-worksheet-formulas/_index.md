---
title: "تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام Python"
linktitle: "صيغ ورقة العمل"
type: docs
weight: 70
url: /ar/python-net/chart-worksheet-formulas/
keywords:
  - مخطط جدول البيانات
  - ورقة عمل المخطط
  - صيغة المخطط
  - صيغة ورقة العمل
  - صيغة جدول البيانات
  - دفتر بيانات المخطط
  - حساب الصيغة
  - ثابت منطقي
  - ثابت عددي
  - ثابت نصي
  - ثابت خطأ
  - عامل حسابي
  - عامل مقارنة
  - نمط A1
  - نمط R1C1
  - دالة معرفة مسبقًا
  - PowerPoint
  - عرض تقديمي
  - Python
  - Aspose.Slides
description: "تطبيق صيغ بنمط Excel في Aspose.Slides للبايثون عبر .NET على أوراق عمل المخططات، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تقوم مخططات PowerPoint بتخزين البيانات المصدر في ورقة عمل مضمّنة. في Aspose.Slides للـ Python عبر .NET، يمكنك الوصول إلى تلك الورقة عبر دفتر بيانات المخطط، كتابة القيم المدخلة، تعيين الصيغ إلى الخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغة الكامل: إنشاء مخطط، ملء ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة المخطط، وحفظ العرض. كما تصف صيغة الصيغ المدعومة، مجموعة الدالات المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الأوراق الخاصة بجداول البيانات.

## **أوراق عمل المخطط والصيغ**

تحتوي ورقة عمل المخطط على الفئات وأسماء السلاسل والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص الورقة بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المضمّنة مفتوحة، يظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تُعرَض الورقة عبر [دفتر بيانات المخطط](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdataworkbook/). استخدم خاصية [الصيغة](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/formula/) لصيغ بنمط A1 وخاصية [r1c1_formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) لصيغ بنمط R1C1. بعد تغيير خلايا الإدخال أو الصيغ، استدعِ [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

ما زالت الخلية المحسوبة تُظهر نتيجتها عبر خاصية [value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/value/). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الكود أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

المثال التالي يوضح سير عمل من الطرف إلى الطرف. ينشئ مخطط أعمدة متحد المجموعة، يمسح البيانات النموذجية، يكتب قيم الإيرادات والنفقات الفصلية، يحسب الربح بالصيغة، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا يوجد استدعاء منفصل لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ نمط A1**

تحدد تدوين A1 الأعمدة بأحرف والصفوف بأرقام. عيّن تعبيرات بنمط A1 عبر [IChartDataCell.formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/formula/).

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

أشكال المرجع الشائعة بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما تُنقل الصيغة أو تُنسخ بواسطة تطبيق جداول البيانات. المراجع المطلقة تبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تثبّت إما الصف أو العمود فقط.

## **استخدام صيغ نمط R1C1**

يحدد تدوين R1C1 الصفوف والأعمدة بالأرقام. تستخدم المراجع النسبية إزاحات بين أقواس مربعة. عيّن هذا النمط عبر [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

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

أشكال المرجع الشائعة بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، يعني `RC[-2]` الخلية في نفس الصف بعدد عمودين إلى اليسار (`B2`).

## **ثوابت الصيغة والعوامل**

يدعم مُقَيِّم الصيغ المدمج القيم المنطقية، القيم الرقمية الحرفية، السلاسل، قيم أخطاء جداول البيانات، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والقيّم الحرفية**

| النوع | الأمثلة | ملاحظات |
|---|---|---|
| Logical | `TRUE`, `FALSE` | يمكن استخدامها مباشرةً في تعبيرات منطقية مثل `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | تدعم الصيغة العادية والعلمية. |
| String | `"abc"`, `"2/3/2020 12:00"` | تُكتب القيم النصية بين علامتي اقتباس مزدوجتين داخل الصيغة. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | يمكن أن تُقييم صيغة صحيحة إلى قيمة خطأ في جدول البيانات بدلًا من نتيجة عادية. |

يستخدم هذا المثال عدة أنواع ثابتة:

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

    logical_value = workbook.get_cell(0, "B2").value  # خطأ
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **العوامل الحسابية**

| العامل | المعنى | المثال |
|---|---|---|
| `+` | الجمع أو الإشارة الموجبة الأحادية | `2+3` |
| `-` | الطرح أو النفي | `2-3`, `-3` |
| `*` | الضرب | `2*3` |
| `/` | القسمة | `2/3` |
| `%` | النسبة المئوية | `30%` |
| `^` | الرفع للأس | `2^3` |

استخدم الأقواس لتحديد ترتيب التقييم بوضوح، على سبيل المثال `(A2+B2)*C2`.

### **العوامل المقارنة**

تُعيد تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | المثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدالات المعرفة المسبقة المدعومة**

يتضمن Aspose.Slides مُقَيِّم صيغ مدمج لأوراق عمل المخطط، لكنه ليس محرك حساب Excel كامل. مجموعة الدالات الموثقة محدودة بالدالات أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها بواسطة [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| الدالة | الغرض أو الشكل المدعوم | المثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم للأعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | البحث عن نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نص على أساس البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجعي | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجهي | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجهي | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | مجموع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود المعروضة في الجدول هامة: `INDEX` موثقة على شكل مرجعي، بينما `LOOKUP` و`MATCH` موثقتان على أشكالهما المتجهية. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار الدالات والميزات غير المذكورة غير مدعومة من قبل مُقَيِّم صيغ Aspose.Slides ما لم يتم توثيقها بشكل منفصل.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تخزن ملفات جداول البيانات كلًا من الصيغة وقيمتها المحسوبة الأخيرة. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [IChartDataCell.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/value/) عند تحميل العرض ولم يتغير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يرمى قراءة قيمة خلية ذات بيانات غير مدعومة استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دالات Excel لا يقوم Aspose.Slides بتقييمها، احسب تلك الصيغ باستخدام محرك جداول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر بيانات المخطط. لا تستبدل الصيغ غير المدعومة بقيم مُخَمنَة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صالحة لكنها تنتج نتيجة خطأ في جدول البيانات مثل `#DIV/0!`، `#N/A`، `#NAME?`، `#NULL!`، `#NUM!`, `#REF!` أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر `value`.

قد تفشل الصيغة أيضًا في التحليل أو الإشارة أو التبعيات أو مستوى البيانات المدعومة. يوفر Aspose.Slides استثناءات خاصة بجداول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/)، [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/)، [CellCircularReferenceException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/)، و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

عند استخراج الصيغ من القوالب أو مدخلات المستخدم، تعامل مع هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

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

دعم الصيغ في أوراق عمل المخطط مخصص لمجموعة معرفة من عمليات حساب جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل التقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدالات الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا من العروض المحمَّلة لقطات، ولا تعتمد عليها كبديل لإعادة الحساب بعد تعديل.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دالات خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول بيانات كامل، احسبها خارجيًا ثم حدّث دفتر بيانات المخطط بالقيم النهائية.

## **الأسئلة الشائعة**

**ما الفرق بين `formula` و `r1c1_formula`؟**

[formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/formula/) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتناسب مع طريقة إنشاء الصيغ أو نسخها.

**هل يجب قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) يُعيد كائن `IChartDataCell`. للحصول على النتيجة المحسوبة، اقرأ خاصية [value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichartdatacell/value/) للخلية بعد إعادة الحساب.

**متى يجب استدعاء `calculate_formulas`؟**

استدعِ [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقَيِّم المدمج.

**هل يدعم Aspose.Slides كل دالة Excel؟**

لا. يُدعم المُقَيِّم المدمج مجموعة موثقة من الدالات فقط. لا يجب افتراض أن دالات خارج هذه المجموعة ستُعاد حسابها بشكل صحيح. إذا كان مطلوب توافق كامل مع صيغ Excel، نفّذ الحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى دفتر بيانات المخطط.

**ماذا يحدث إذا كان العرض المحمَّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد لا يزال دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون تلك القيمة المخزنة صالحة. قد يرمى الوصول إلى خلية لا يمكن للـ Aspose.Slides التعامل مع صيغتها استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغة هي نفسها استثناءات Python؟**

لا. نتيجة مثل `#DIV/0!` هي قيمة جدول بيانات تُنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يتحديث المخطط تلقائيًا عندما تتغير خلية الصيغة؟**

يمكن لسلسلة المخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو قدم العرض. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، سيستخدم المخطط تلك القيم المحدثة؛ لا يلزم استدعاء منفصل لتحديث المخطط في هذا سير العمل.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر API بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموصوف في هذه المقالة يتعلق بدفتر بيانات المخطط ومجموعة الصيغ التي يُقيمها Aspose.Slides. لا تفترض أن [calculate_formulas](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) يُعيد حساب جميع الصيغ في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخطط، لكن تقييم الصيغ يقتصر على المحلل ومجموعة الدالات المدعومة. إذا كان المرجع عبر ورقة أو خارجيًا ضروريًا، تحقق من صلاحية الصيغة المحددة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المُستخلصة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة API في Aspose.Slides تُعيّن تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون علامة `=` في البداية. استخدام هذا الشكل يحافظ على توافق الصيغ المولدة مع أمثلة API الموضحة.