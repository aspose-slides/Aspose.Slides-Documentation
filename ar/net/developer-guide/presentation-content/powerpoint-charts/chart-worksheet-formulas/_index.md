---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية في .NET
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/net/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- دفتر بيانات المخطط
- حساب الصيغة
- الثقافة المفضلة
- صيغة محددة ثقافيًا
- DBCS
- ثابت منطقي
- ثابت عددي
- ثابت نصي
- ثابت خطأ
- معامل حسابي
- معامل مقارنة
- نمط A1
- نمط R1C1
- دالة مسبقة التعريف
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في أوراق عمل مخططات Aspose.Slides للـ .NET، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مدمجة. في Aspose.Slides for .NET، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة القيم المدخلة، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغة الكامل: إنشاء مخطط، تعبئة ورقة العمل الخاصة به، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغة المدعومة، مجموعة الدالات المضمنة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء جداول البيانات الخاصة.

## **أوراق عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المدمجة مفتوحة، يظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم كشف ورقة العمل عبر [دفتر بيانات المخطط](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/). استخدم خاصية [Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/formula/) للصيغ بنمط A1 وخاصية [R1C1Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/r1c1formula/) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا يزال الخلية المحسوبة تكشف عن نتيجتها عبر خاصية [Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/). وهذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يوضح المثال التالي سير عمل من البداية للنهاية. فهو ينشئ مخطط أعمدة مجمع، يمسح البيانات النموذجية، يكتب قيم الإيرادات والمصروفات ربع السنوية، يحسب الربح باستخدام الصيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا يوجد استدعاء منفصل لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

تحدد صيغة A1 الأعمدة بحروف والصفوف بأرقام. عيّن التعابير بنمط A1 عبر [IChartDataCell.Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

أشكال المرجع الشائعة بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل الصيغة أو نسخها بواسطة تطبيق جداول البيانات. المراجع المطلقة تبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

تحدد صيغة R1C1 الصفوف والأعمدة عدديًا. تستخدم المراجع النسبية إزاحات داخل أقواس مربعة. عيّن هذا النمط عبر [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

أشكال المرجع الشائعة بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` يعني الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغ والعاملات**

يدعم مقيم الصيغ المدمج القيم المنطقية، القيم العددية، السلاسل النصية، قيم أخطاء جداول البيانات، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والقيم الحرفية**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| عددي | `1`, `0.5`, `.3`, `1E-2` | يتم دعم الصيغة العادية والعلمية. |
| نصي | `"abc"`, `"2/3/2020 12:00"` | تُحاط القيم النصية بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | قد تُقيم صيغة صالحة إلى قيمة خطأ في جدول البيانات بدلاً من نتيجة عادية. |

يستخدم هذا المثال عدة أنواع من الثوابت:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // خطأ
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **العوامل الحسابية**

| العامل | المعنى | مثال |
|---|---|---|
| `+` | جمع أو علامة زائد أحادية | `2+3` |
| `-` | طرح أو سالب أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لتحديد ترتيب التقييم صراحةً، مثال `(A2+B2)*C2`.

### **عوامل المقارنة**

تُعيد تعابير المقارنة قيمًا منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدالات المسبقة التعريف المدعومة**

يتضمن Aspose.Slides مقيم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب كامل لـ Excel. مجموعة الدالات الموثقة محدودة بالدالات الواردة أدناه. لا تُفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| الدالة | الغرض أو الصيغة المدعومة | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم إلى الأعلى لعدد مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نصي للبايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | صيغة مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | صيغة متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | صيغة متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | مجموع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول هامة: `INDEX` موثّقة بصيغة مرجع، بينما `LOOKUP` و`MATCH` موثّقتان بصيغتهما المتجهة. تستخدم `DATE` نظام تاريخ 1900. يجب اعتبار الدالات غير المدرجة هنا غير مدعومة من قبل مقيم الصيغ في Aspose.Slides ما لم تُوثّق separatًا.

## **حساب الصيغ مع ثقافة مفضلة**

تفسر بعض دالات دفتر عمل المخطط النص وفق قواعد ثقافية محددة. هذا مهم خصوصًا للدالات التي تستهدف لغات تستخدم مجموعات أحرف مزدوجة البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/)، عيّن [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/ar/net/aspose.slides/ispreadsheetoptions/preferredculture/) عبر [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/spreadsheetoptions/)، ثم حمّل العرض التقديمي.

يختار المثال التالي الثقافة اليابانية، يفتح عرضًا تقديميًا باستخدام خيارات التحميل المكوّنة، ويستدعي [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) لكل دفتر عمل مخطط:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

الثقافة المفضلة هي جزء من تكوين تحميل العرض التقديمي، لذا حددها قبل إنشاء مثيل [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). استخدم الثقافة المتوافقة مع صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

غالبًا ما تخزن ملفات جداول البيانات كلًا من الصيغة وقيمتها الأخيرة المحسوبة. لذا يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [IChartDataCell.Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/) عندما يُحمَّل عرض تقديمي ولم يتغير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد بعد ذلك على القيمة المخزنة القديمة. في تلك الحالة، قد يرفع قراءة قيمة خلية ذات بيانات غير مدعومة الاستثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دالات Excel لا يقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جداول بيانات يدعمها واكتب القيم الناتجة إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مُخمنة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صالحة لكن تُنتج نتيجة خطأ في جدول البيانات مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر `Value`.

يمكن أيضًا أن تفشل الصيغة أثناء التحليل أو الإشارة أو التبعية أو مستوى البيانات المدعومة. توفر Aspose.Slides استثناءات خاصة بجداول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

عند حصول الصيغ من القوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات مُصمم لمجموعة محدودة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدالات الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا من العروض المقدمة كلقطات، ليست كبديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الموجودة قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دالات خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول بيانات كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين `Formula` و `R1C1Formula`؟**

[Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/formula/) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/r1c1formula/) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتطابق مع طريقة توليدك أو نسخك للصيغ.

**هل يجب قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/getcell/) يُعيد كائن `IChartDataCell`. للحصول على النتيجة المحسوبة، اقرأ خاصية [Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/) لتلك الخلية بعد إعادة الحساب.

**متى يجب استدعاء `CalculateFormulas`؟**

استدعِ [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المقيم المدمج.

**هل يدعم Aspose.Slides كل دالات Excel؟**

لا. يدعم المقيم المدمج مجموعة موثقة من الدالات. لا يُفترض أن تُعاد حساب الدالات خارج تلك المجموعة بشكل صحيح. إذا كان مطلوب توافق كامل مع صيغ Excel، قم بالحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا احتوى عرض تقديمي محمَّل على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون تلك القيمة المخزنة صالحة. محاولة الوصول إلى خلية لا يمكن التعامل مع صيغتها قد ترفع الاستثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات .NET؟**

لا. القيمة مثل `#DIV/0!` هي قيمة جدول بيانات تنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بشكل طبيعي.

**هل يحدث تحديث تلقائي للمخطط عند تغيير خلية الصيغة؟**

يمكن للسلسلة في المخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو صدّر العرض التقديمي. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، يستخدم المخطط القيم المحدثة؛ ولا يلزم استدعاء طريقة تحديث منفصلة لهذا السيناريو.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر API بيانات المخطط. ومع ذلك، يقتصر سير عمل حساب الصيغ الموضح في هذه المقالة على دفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيمها Aspose.Slides. لا تفترض أن [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) يوفر إعادة حساب كاملة لصيغ عشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ يقتصر على المحلل والدالات المدعومة. إذا كانت إشارة عبر ورقة أو دفتر عمل خارجي ضرورية، تحقق من صلاحية الصيغة المحددة مع نسخة Aspose.Slides التي تستخدمها. بالنسبة لسير عمل يحتاج إلى توافق واسع مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المستخلصة إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

تُظهر أمثلة API في Aspose.Slides تعيين تعابير مثل `B2-C2` أو `SUM(B2:B5)` دون علامة `=` تمهيدية. استخدام هذا الشكل يحافظ على توافق الصيغ المولدة مع أمثلة API الموثقة.