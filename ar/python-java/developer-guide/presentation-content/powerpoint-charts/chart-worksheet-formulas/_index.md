---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام Python عبر Java
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/python-java/chart-worksheet-formulas/
keywords:
- مخطط جدول البيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- مصنف بيانات المخطط
- حساب الصيغة
- الثقافة المفضلة
- صيغة خاصة بالثقافة
- DBCS
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
- Java
- Aspose.Slides
description: "تطبيق صيغ على طراز Excel في أوراق عمل مخططات Aspose.Slides لـ Python عبر Java، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مضمّنة. في Aspose.Slides for Python via Java، يمكنك الوصول إلى تلك الورقة من خلال مصنّف chart data workbook، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات مخطط.

تشرح هذه المقالة سير عمل الصيغة الكامل: إنشاء مخطط، ملء ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بناء جملة الصيغ المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء جداول البيانات الخاصة.

## **أوراق عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم كشف ورقة العمل من خلال الفئة [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/). استخدم [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setFormula) للصيغ بنمط A1 و[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setR1C1Formula) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا تزال الخلية التي تم حسابها تكشف عن نتيجتها عبر [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#getValue). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الكود أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يوضح المثال التالي سير عمل من البداية إلى النهاية. فهو ينشئ مخطط أعمدة متكتل، يمسح البيانات النموذجية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الأرباح باستخدام الصيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم مخطط، ويحفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الأرباح المحسوبة. لا توجد مكالمة منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب المصنف أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

تحديد النمط A1 يعرّف الأعمدة بالحروف والصفوف بالأرقام. عيّن التعبيرات بنمط A1 عبر [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setFormula).

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
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

الأشكال الشائعة للمرجع بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل الصيغة أو نسخها بواسطة تطبيق جداول البيانات. المراجع المطلقة تُبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

يحدد النمط R1C1 كلًا من الصفوف والأعمدة عدديًا. المراجع النسبية تستخدم إزاحات داخل أقواس مربعة. عيّن هذا البنية عبر [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

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
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

الأشكال الشائعة للمرجع بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` تعني الخلية في نفس الصف ولكن عمودين إلى اليسار (`B2`).

## **ثوابت الصيغ والمعاملات**

يُدعم مُقَيِّم الصيغ المدمج القيم المنطقية، القيم العددية، السلاسل، قيم أخطاء جداول البيانات، المعاملات الحسابية، ومعاملات المقارنة.

### **الثوابت واللاحقات**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| عددي | `1`, `0.5`, `.3`, `1E-2` | يُدعم الشكل العادي والعلمي. |
| سلسلة | `"abc"`, `"2/3/2020 12:00"` | تُحاط السلاسل بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن للصيغة الصالحة أن تُعيد قيمة خطأ في جدول البيانات بدلاً من نتيجة عادية. |

يستخدم هذا المثال عدة أنواع من الثوابت:

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
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # خطأ
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **المعاملات الحسابية**

| المعامل | المعنى | المثال |
|---|---|---|
| `+` | جمع أو زائد أحادي | `2+3` |
| `-` | طرح أو سالب أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لتحديد ترتيب التقييم صراحةً، مثلًا `(A2+B2)*C2`.

### **معاملات المقارنة**

تعيد تعبيرات المقارنة قيمًا منطقية.

| المعامل | المعنى | المثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقًا المدعومة**

يشتمل Aspose.Slides على مُقَيِّم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| الدالة | الغرض أو النموذج المدعوم | المثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب العدد إلى الأعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نصي على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | نموذج مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | نموذج متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | نموذج متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول هامة: `INDEX` موثقة بنموذج مرجع، بينما `LOOKUP` و`MATCH` موثقة بنماذجها المتجهة. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار الدوال غير المدرجة هنا غير مدعومة من قبل مُقَيِّم الصيغ في Aspose.Slides ما لم يتم توثيقها بشكل منفصل.

## **حساب الصيغ باستخدام ثقافة مفضلة**

بعض دوال المصنف تفسّر النص وفق قواعد ثقافية معينة. وهذا مهم بصفة خاصة للدوال الموجهة للغات التي تستخدم مجموعات أحرف مزدوجة البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/)، عيّن الثقافة المفضلة عبر [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture)، مرّر خيارات جدول البيانات عبر [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، ثم حمّل العرض التقديمي.

يختار المثال التالي الثقافة اليابانية، يفتح عرضًا تقديميًا باستخدام خيارات التحميل المكوّنة، ويستدعي [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) لكل مصنف مخطط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

الثقافة المفضلة هي جزء من تكوين تحميل العرض التقديمي، لذا حددها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). استخدم الثقافة المتوقعة من صيغ المصنف؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تخزن ملفات جداول البيانات كلًا من الصيغة والقيمة المحسوبة الأخيرة. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#getValue) عند تحميل العرض التقديمي إذا لم تُغيّر بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل المصنف، لا يمكن الاعتماد على القيمة المخزنة السابقة. في تلك الحالة، قراءة قيمة خلية ذات بيانات غير مدعومة قد ترفع استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellunsupporteddataexception/).

إذا كان المخطط يعتمد على دوال Excel لا يُعيد Aspose.Slides حسابها، احسب تلك الصيغ باستخدام محرك جداول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى مصنف المخطط. لا تستبدل الصيغ غير المدعومة بقيم تخمينية.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينها.

يمكن أن تكون الصيغة صالحة ولكن تُنتج نتيجة خطأ جدول بيانات مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#getValue).

يمكن أن تفشل الصيغة أيضًا أثناء التحليل أو الإشارة أو التبعية أو مستوى البيانات المدعومة. توفر Aspose.Slides استثناءات خاصة بجداول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellunsupporteddataexception/).

عند جلب الصيغ من القوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محدودة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في اعتبارك عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، المعاملات، المراجع، والدوال المذكورة في الوثائق عندما تحتاج إلى أن يُعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا في العروض المحملة لقطات، لا كبديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دوالًا خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول بيانات كامل، احسبها خارجيًا ثم حدّث مصنف المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setFormula) و[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setR1C1Formula)؟**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setFormula) يُخزِّن تعبيرًا بنمط A1 مثل `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#setR1C1Formula) يُخزِّن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتطابق مع طريقة إنشاء أو نسخ الصيغ لديك.

**هل يجب علي قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#getCell) يُعيد كائنًا من نوع [ChartDataCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#getValue) لتلك الخلية بعد إعادة الحساب.

**متى يجب استدعاء [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)؟**

استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقَيِّم المدمج.

**هل يدعم Aspose.Slides كل دالة Excel؟**

لا. يدعم المُقَيِّم المدمج مجموعة موثقة من الدوال فقط. لا ينبغي افتراض أن الدوال خارج تلك المجموعة ستُعاد حسابها بشكل صحيح. إذا كانت هناك حاجة إلى توافق كامل مع صيغ Excel، قم بإجراء الحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى مصنف المخطط.

**ماذا يحدث إذا كان العرض التقديمي المحمَّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغيّر بيانات المخطط، قد يحتوي المصنف على قيمة مخزنة مؤقتًا سابقة. بعد تعديل البيانات المرتبطة، قد لا تكون تلك القيمة المخزنة صالحة. الوصول إلى خلية لا يمكن التعامل مع صيغتها قد يرفع استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها الاستثناءات؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول بيانات ينتجها حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يحدث تحديث للمخطط تلقائيًا عندما تتغيّر خلية الصيغة؟**

يمكن لسلسلة مخطط الإشارة إلى خلايا المصنف. أعد حساب المصنف أولاً، ثم احفظ أو اعرض العرض التقديمي. إذا كانت نقاط بيانات المخطط تشير إلى الخلايا المحسوبة، سيستخدم المخطط القيم المحدثة؛ لا تُحتاج إلى طريقة تحديث منفصلة للمخطط في هذا سير العمل.

**هل يمكن للمخططات استخدام مصنف Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام مصنف خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، يقتصر سير عمل حساب الصيغ الموصوف في هذه المقالة على مصنف بيانات المخطط ومجموعة الصيغ التي يُقيِّمها Aspose.Slides. لا تفترض أن [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) يُعيد حساب جميع الصيغ في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو مصنف آخر؟**

قد توجد مراجع بنمط Excel في مصنفات المخطط، لكن تقييم الصيغ محدود بالمحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو ملف خارجي أمرًا أساسيًا، تحقق من صلاحية الصيغة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير عمل يتطلب توافقًا واسعًا مع مراجع Excel، احسب المصنف خارجيًا واكتب القيم المُحلَّة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة API في Aspose.Slides تُعيّن تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون علامة `=` في البداية. استخدام هذا الشكل يحافظ على توافق الصيغ المُولَّدة مع أمثلة الوثائق.