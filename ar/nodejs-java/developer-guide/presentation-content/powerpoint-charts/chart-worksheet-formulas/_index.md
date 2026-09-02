---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام JavaScript
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/nodejs-java/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق صيغ على نمط Excel في Aspose.Slides لـ Node.js عبر Java على أوراق عمل المخطط، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر في ورقة عمل مدمجة. في Aspose.Slides لـ Node.js عبر Java، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغة الكامل: إنشاء مخطط، ملء ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغة المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الجداول.

## **أوراق عمل المخطط والصيغ**

تحتوي ورقة عمل المخطط على الفئات وأسماء السلاسل والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة عمل مدمجة مفتوحة، تظهر بيانات الفئة والسلسلة](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم كشف ورقة العمل عبر الفئة [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/). استخدم [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) للصيغ بنمط A1 و[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

ما زالت الخلية المحسوبة تكشف عن نتيجتها عبر [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

المثال التالي يوضح سير عمل شامل من الطرف إلى الطرف. فهو ينشئ مخطط أعمدة مجمّع، يمسح البيانات النموذجية، يكتب قيم الإيرادات والمصروفات ربع السنوية، يحسب الربح باستخدام صيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد مكالمة منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولًا، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ نمط A1**

تحدد صياغة A1 الأعمدة بأحرف والصفوف بأرقام. عيّن التعبيرات بنمط A1 عبر [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

أشكال الإشارة الشائعة بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| الخلية | `A2` | `$A$2` | `A$2`, `$A2` |
| الصف | `2:2` | `$2:$2` | — |
| العمود | `A:A` | `$A:$A` | — |
| النطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير الإشارات النسبية عندما تُنقل الصيغة أو تُنسخها تطبيقات الجداول. الإشارات المطلقة تثبت كلا الإحداثيين، بينما الإشارات المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ نمط R1C1**

تحدد صياغة R1C1 كلًا من الصفوف والأعمدة رقمياً. تستخدم الإشارات النسبية إزاحات داخل أقواس مربعة. عيّن هذا النمط عبر [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

أشكال الإشارة الشائعة بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| الخلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| الصف | `R[2]` | `R2` | — |
| العمود | `C[3]` | `C3` | — |
| النطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، يعني `RC[-2]` الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغة والعوامل**

يدعم المقييم المدمج للصيغ القيم المنطقية، القيم العددية، النصوص، قيم الأخطاء في الجداول، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والليمترات**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقية | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| عددية | `1`, `0.5`, `.3`, `1E-2` | يدعم كل من الصيغة العادية والعلمية. |
| نصية | `"abc"`, `"2/3/2020 12:00"` | تُحاط النصوص بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن لصيغة صالحة أن تُقيّم إلى قيمة خطأ في الجدول بدلًا من نتيجة عادية. |

يستخدم هذا المثال عدة أنواع من الثوابت:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // خطأ
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **العوامل الحسابية**

| العامل | المعنى | مثال |
|---|---|---|
| `+` | جمع أو علامة زائد أحادية | `2+3` |
| `-` | طرح أو نفي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم القوسين لتوضيح ترتيب التقييم، مثال `(A2+B2)*C2`.

### **العوامل المقارنة**

تُعيد تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مقييمًا مدمجًا للصيغ في أوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محصورة في الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن أن تُعاد حسابها عبر [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| الدالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم إلى الأعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | البحث عن قيمة نصية داخل أخرى | `FIND("-",A2)` |
| `FINDB` | بحث نصي على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | صيغة مرجعية | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | صيغة متجهة | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | صيغة متجهة | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | مجموع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول مهمة: `INDEX` موثقة بصيغة مرجعية، بينما `LOOKUP` و`MATCH` موثقة بصيغهما المتجهة. `DATE` يستخدم نظام التاريخ 1900. يجب اعتبار الدوال غير المذكورة غير مدعومة من قبل مقييم الصيغ في Aspose.Slides ما لم يتم توثيقها بشكل منفصل.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تخزن ملفات الجداول كلًا من الصيغة والقيمة المحسوبة الأخيرة. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--) عند تحميل العرض التقديمي وعدم تعديل بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن اعتبار القيمة المخزنة السابقة موثوقة. في هذه الحالة، قد تُثير قراءة قيمة خلية ذات بيانات غير مدعومة استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellunsupporteddataexception/).

إذا كان المخطط يعتمد على دوال Excel لا يقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جداول يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم تخمين.

## **معالجة أخطاء الصيغة**

هناك نوعان مختلفان من المشكلات يجب تمييزهما.

يمكن أن تكون الصيغة صالحة ولكن تُنتج نتيجة خطأ في الجدول مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--).

يمكن أن تفشل الصيغة أيضًا أثناء التحليل أو الإشارة أو التبعيات أو مستوى البيانات المدعومة. يوفر Aspose.Slides استثنائات خاصة بالجداول لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellunsupporteddataexception/).

عند استلام صيغ من قوالب أو مدخلات المستخدم، احرص على التقاط الأخطاء حول إعادة الحساب والوصول إلى القيم. تُحدّد تفاصيل الخطأ المشكلة الأساسية في الجدول:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محددة من حسابات الجداول، وليس لتوافق كامل مع Excel. ضع هذه القيود في اعتبارك عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت والعوامل والإشارات والدوال الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد نتائج الصيغ عليها.
- باعتبار القيم المخزنة مؤقتًا من العروض المحملة كلقطات، لا تعتمد عليها كبديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا كانت تستخدم دوالًا غير مدرجة في القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) و[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتطابق مع طريقة توليد أو نسخ الصيغ لديك.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) يُعيد كائنًا من نوع [ChartDataCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--) لتلك الخلية بعد إعادة الحساب.

**متى يجب استدعاء [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المقييم المدمج.

**هل يدعم Aspose.Slides كل دالة في Excel؟**

لا. يدعم المقييم المدمج مجموعة مُحددة موثقة من الدوال. لا ينبغي الافتراض أن أي دالة Excel خارج هذه المجموعة تُعاد حسابها بشكل صحيح. إذا كان مطلوبًا توافق كامل مع صيغ Excel، نفّذ الحساب باستخدام محرك جداول مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض التقديمي المُحمَّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغيّر بيانات المخطط، قد يحتوي دفتر العمل على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد تصبح تلك القيمة المخزنة غير صالحة. الوصول إلى خلية لا يمكن معالجة صيغتها قد يُثير استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**هل قيم خطأ الصيغة هي نفسها الاستثناءات؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول تنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يتم تحديث المخطط تلقائيًا عندما تتغير خلية الصيغة؟**

يمكن لسلسلة مخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولًا، ثم احفظ أو عرض العرض التقديمي. إذا كانت نقاط بيانات المخطط تشير إلى الخلايا المحسوبة، سيستخدم المخطط هذه القيم المُحدَّثة؛ لا يلزم استدعاء طريقة تحديث منفصلة لهذا السيناريو.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموصوف في هذه المقالة يخص دفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيمها Aspose.Slides. لا تفترض أن [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) يوفر إعادة حساب كاملة لأي صيغ في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد إشارات بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ مقيد بالمُحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو مصدر خارجي ضروريًا، تحقق من صحة الصيغة الدقيقة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير عمل يتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المُحلَّة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة API في Aspose.Slides تعين التعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون علامة `=` في البداية. استخدام هذا الشكل يحافظ على توافق الصيغ مع أمثلة API الموثقة.