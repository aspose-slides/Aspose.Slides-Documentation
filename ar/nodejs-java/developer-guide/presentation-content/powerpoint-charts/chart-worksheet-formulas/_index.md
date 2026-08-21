---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام JavaScript
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/nodejs-java/chart-worksheet-formulas/
keywords:
- جدول بيانات المخطط
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- دفتر بيانات المخطط
- حساب الصيغة
- الثقافة المفضلة
- صيغة مخصصة للثقافة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في Aspose.Slides لـ Node.js عبر أوراق عمل المخطط في Java، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مدمجة. في Aspose.Slides لـ Node.js عبر Java، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغ بالكامل: إنشاء مخطط، ملء ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة المخطط، وحفظ العرض التقديمي. كما توضح بنية الصيغة المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، والأخطاء الخاصة بجداول البيانات.

## **أوراق عمل المخطط والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المدمجة مفتوحة، يظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تُعرض ورقة العمل من خلال الفئة [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/). استخدم [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) للصيغ بنمط A1 و[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا زالت الخلية المحسوبة تُظهر نتيجتها عبر [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--). وهذا مهم عندما تحتاج إلى فحص نتيجة صيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يوضح المثال التالي سير عمل من البداية إلى النهاية. يُنشئ مخطط أعمدة متجمع، يمسح البيانات التجريبية، يكتب قيم الإيرادات والمصروفات الربع‑سنوية، يحسب الربح باستخدام الصيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

تحدد صيغة A1 الأعمدة بالأحرف والصفوف بالأرقام. عيّن تعبيرات بنمط A1 عبر [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

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

الأشكال الشائعة للمرجع بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما تُنقل الصيغة أو تُنسخها تطبيقات جداول البيانات. تحافظ المراجع المطلقة على تثبيت كلا الإحداثيين، بينما تثبت المراجع المختلطة إما صفًا أو عمودًا فقط.

## **استخدام صيغ بنمط R1C1**

تحدد صيغة R1C1 الصفوف والأعمدة رقمياً. تستخدم المراجع النسبية إزاحات داخل أقواس مربعة. عيّن هذه الصيغة عبر [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

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

الأشكال الشائعة للمرجع بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، يعني `RC[-2]` الخلية في نفس الصف قبل عمودين (`B2`).

## **ثوابت الصيغ والعوامل**

يدعم مُقيم الصيغ المدمج القيم المنطقية، القيم الرقمية، السلاسل النصية، قيم الأخطاء في جداول البيانات، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والقيّم**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| رقمي | `1`, `0.5`, `.3`, `1E-2` | يدعم الكتابة العادية والعلمية. |
| نص | `"abc"`, `"2/3/2020 12:00"` | تُحاط القيم النصية بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | قد تُعيد صيغة صالحة قيمة خطأ في جدول البيانات بدلاً من نتيجة عادية. |

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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
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
| `+` | جمع أو إشارة موجبة أحادية | `2+3` |
| `-` | طرح أو سالب أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | رفع إلى أس | `2^3` |

استخدم الأقواس لجعل ترتيب التقييم واضحًا، مثال `(A2+B2)*C2`.

### **عوامل المقارنة**

تُعيد تعبيرات المقارنة قيم منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مُقيم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| الدالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب العدد إلى الأعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج القيم النصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج القيم النصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نصي على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجعي | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الواردة في الجدول مهمة: `INDEX` موثقة على شكل مرجعي، بينما `LOOKUP` و`MATCH` موثقتان على أشكالهما المتجهية. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار الدوال غير المذكورة غير مدعومة من مُقيم صيغ Aspose.Slides ما لم يتم توثيقها بصورة منفصلة.

## **حساب الصيغ مع ثقافة مفضلة**

تفسر بعض دوال دفتر عمل المخطط النص وفق قواعد ثقافية خاصة. هذا مهم خصوصًا للدوال الموجهة للغات التي تستخدم مجموعات أحرف مزدوجة البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/)، عيّن الثقافة المفضلة عبر [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture)، عيّن خيارات جدول البيانات عبر [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، ثم حمّل العرض التقديمي.

المثال التالي يختار الثقافة اليابانية، يفتح عرضًا تقديميًا باستخدام خيارات التحميل المكوّنة، ويستدعي [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) لكل دفتر عمل مخطط:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

تُعد الثقافة المفضلة جزءًا من تكوين تحميل العرض التقديمي، لذا يجب تحديدها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). استخدم الثقافة المتوقعة من صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

غالبًا ما تخزن ملفات جداول البيانات كلًا من الصيغة والقيمة المحسوبة الأخيرة. يمكن لـ Aspose.Slides لذلك قراءة قيمة مخزنة مؤقتًا من خلال [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--) عند تحميل العرض التقديمي إذا لم تُغيّر بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يرفع قراءة قيمة خلية ذات بيانات غير مدعومة استثناءً [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellunsupporteddataexception/).

إذا كان المخطط يعتمد على دوال Excel لا تُقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جدول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم تخمين.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التفريق بينهما.

يمكن أن تكون الصيغة صالحة لكنها تُنتج نتيجة خطأ في جدول البيانات مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--).

قد تفشل الصيغة أيضًا عند التحليل أو الإشارة أو التبعية أو مستوى البيانات المدعومة. يوفر Aspose.Slides استثناءات خاصة بجدول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellunsupporteddataexception/).

عند جلب الصيغ من القوالب أو إدخال المستخدم، احرص على التقاط الأخطاء حول إعادة الحساب والوصول إلى القيم. توضح تفاصيل الخطأ مشكلة جدول البيانات الأساسية:

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

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محددة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدوال الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد حساب الصيغ بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة من العروض التقديمية المحملة لقطات، لا كبديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصة إذا استخدمت دوال غير مدرجة في القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول بيانات كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتداولة**

**ما الفرق بين [ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) و[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يت匹 السيِّ إنشاء الصيغ أو نسخها.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) يُعيد كائنًا من نوع [ChartDataCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [ChartDataCell.getValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdatacell/#getValue--) الخاصة بالخلية بعد إعادة الحساب.

**متى يجب استدعاء [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

استدعِ [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقيم المدمج.

**هل يدعم Aspose.Slides كل دوال Excel؟**

لا. يدعم المُقيم المدمج مجموعة موثقة من الدوال. لا يجب افتراض أن الدوال خارج هذه المجموعة ستُعاد حسابها بشكل صحيح. إذا كانت هناك حاجة لتوافق كامل مع صيغ Excel، نفّذ الحساب باستخدام محرك جدول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا احتوى عرض تقديمي مُحمَّل على صيغة غير مدعومة؟**

إذا لم تتغيّر بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون تلك القيمة المخزنة صالحة. الوصول إلى خلية لا يمكن معالجة صيغتها قد يرفع استثناءً [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها الاستثناءات؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول بيانات تنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cellcircularreferenceexception/) تدل على أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يحدث تحديث تلقائي للمخطط عندما تتغيّر خلية الصيغة؟**

يمكن لسلسلة المخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو صغّر العرض التقديمي. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، يستخدم المخطط قيم الخلايا المحدثة؛ لا يلزم استدعاء طريقة تحديث منفصلة لهذا سير العمل.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. مع ذلك، يختص سير عمل حساب الصيغ المذكور في هذه المقالة ب دفتر عمل بيانات المخطط ومجموعة الصيغ التي يُقيمها Aspose.Slides. لا تفترض أن [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) يوفر إعادة حساب كاملة لصيغ عشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ محدود بالمحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو دفتر عمل خارجي ضروريًا، تحقق من صحة الصيغة المحددة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

تُظهر أمثلة API في Aspose.Slides تعيين تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون علامة `=` في البداية. يُحافظ استخدام هذا الشكل على توافق الصيغ المولدة مع أمثلة API الموثقة.