---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام .NET
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
- دفتر عمل بيانات المخطط
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
- .NET
- C#
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في أوراق عمل المخطط في Aspose.Slides لـ .NET، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بياناتها المصدرية في ورقة عمل مدمجة. في Aspose.Slides لـ .NET، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة القيم المدخلة، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغ بالكامل: إنشاء مخطط، تعبئة ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغة المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الورقة الخاصة بالإكسل.

## **أوراق عمل المخططات والصيغ**

ورقة عمل المخطط تحتوي على الفئات وأسماء السلاسل والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة عمل مدمجة مفتوحة، يُظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تُعرض ورقة العمل من خلال [chart data workbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/). استخدم خاصية [Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/formula/) لصيغ نمط A1 وخاصية [R1C1Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/r1c1formula/) لصيغ نمط R1C1. بعد تغيير خلايا الإدخال أو الصيغ، اتصل بـ [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا يزال الخلية المحسوبة تُظهر نتيجتها من خلال خاصية [Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الكود أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

المثال التالي يُظهر سير عمل من البداية إلى النهاية. فهو ينشئ مخطط عمودي مُجَمَّع، يمسح البيانات التجريبية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الربح باستخدام صيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في سير العمل هذا: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

يحدد تدوين A1 الأعمدة بالحروف والصفوف بالأرقام. عين تعبيرات بنمط A1 عبر [IChartDataCell.Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/formula/).

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

الأشكال الشائعة للمرجع بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل الصيغة أو نسخها بواسطة تطبيق ورقة عمل. المراجع المطلقة تُبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تُثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

يحدد تدوين R1C1 كلًا من الصفوف والأعمدة رقمياً. تستخدم المراجع النسبية إزاحات داخل أقواس مربعة. عين هذا النحو عبر [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

الأشكال الشائعة للمرجع بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، يعني `RC[-2]` الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغة والعوامل**

يدعم مُقَيِّم الصيغ المدمج القيم المنطقية، الأعداد الحرفية، السلاسل النصية، قيم أخطاء الورقة، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والقيم الحرفية**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرةً في تعبيرات منطقية مثل `A2=TRUE`. |
| عددي | `1`, `0.5`, `.3`, `1E-2` | يدعم الترميز العادي والعلمي. |
| سلسلة | `"abc"`, `"2/3/2020 12:00"` | تُطَوَّق النصوص داخل الصيغة بأقواس اقتباس مزدوجة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن لصيغة صالحة أن تُقيم إلى قيمة خطأ في الورقة بدلاً من نتيجة عادية. |

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
| `+` | جمع أو زائد أحادي | `2+3` |
| `-` | طرح أو سالب أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لتحديد ترتيب التقييم صراحةً، مثلاً `(A2+B2)*C2`.

### **عوامل المقارنة**

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

يتضمن Aspose.Slides مُقَيِّم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب إكسل كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة إكسل عشوائية يمكن إعادة حسابها بواسطة [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| الدالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب العدد إلى أعلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين التاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على قيمة نص داخل أخرى | `FIND("-",A2)` |
| `FINDB` | بحث نص بتركيز بايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجعي | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول ذات أهمية: `INDEX` موثّق في الشكل المرجعي، بينما `LOOKUP` و `MATCH` موثّقان في أشكالهما المتجهية. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار أي ميزات أو دوال غير مُدرجة هنا غير مدعومة من قبل مُقَيِّم صيغ Aspose.Slides ما لم تُوثَّق بشكل منفصل.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تخزن ملفات الأوراق كلًا من الصيغة وقيمتها الأخيرة المحسوبة. لذا يمكن لـ Aspose.Slides قراءة قيمة مخزنة من [IChartDataCell.Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/) عند تحميل عرض تقديمي ولم تُغيّر بيانات المخطط ذات الصلة.

بعد تغيير خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يثير قراءة قيمة خلية ذات بيانات غير مدعومة الاستثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

إذا كان المخطط يعتمد على دوال إكسل لا تُقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك ورقة عمل يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مُخَمنَة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صالحة ولكن تُنتج نتيجة خطأ في الورقة مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر `Value`.

يمكن أن تفشل الصيغة أيضًا في مرحلة التحليل أو الإشارة أو التبعيات أو مستوى البيانات المدعومة. يقدم Aspose.Slides استثناءات خاصة بالورقة لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

عند جلب الصيغ من القوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

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

تم تصميم دعم الصيغ في أوراق عمل المخططات لمجموعة محددة من عمليات حساب الورقة، وليس لتوافق كامل مع إكسل. ضع هذه القيود في الاعتبار عند تصميم سير عمل التقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدوال الموثقة عندما تحتاج إلى أن تُعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة من العروض المحملة لقطات سريعة، وليس بديلاً عن إعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الموجودة قبل الاعتماد على قيمها المحسوبة، خصوصًا إذا كانت تستخدم دوالًا خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب ورقة عمل كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة الشائعة**

**ما الفرق بين `Formula` و `R1C1Formula`؟**

[Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/formula/) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/r1c1formula/) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النحو الذي يتناسب مع طريقة إنشاء أو نسخ الصيغ لديك.

**هل يجب علي قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/getcell/) يُعيد كائنًا من نوع `IChartDataCell`. للحصول على النتيجة المحسوبة، اقرأ خاصية [Value](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdatacell/value/) لذلك بعد إعادة الحساب.

**متى يجب استدعاء `CalculateFormulas`؟**

استدعِ [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بعد تغيير قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يحدّث قيم الصيغ التي يدعمها المُقَيِّم المدمج.

**هل يدعم Aspose.Slides كل دالة إكسل؟**

لا. يدعم المُقَيِّم المدمج مجموعة مُوثقة من الدوال. لا ينبغي افتراض أن أي دالة إكسل يمكن إعادة حسابها بشكل صحيح. إذا كان مطلوبًا توافق كامل مع صيغ إكسل، قم بالحساب باستخدام محرك ورقة عمل مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض التقديمي المحمل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغيّر بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزنة سابقة محسوبة. بعد تعديل البيانات ذات الصلة، قد لا تكون هذه القيمة المخزنة صالحة. الوصول إلى خلية لا يمكن معالجة صيغتها قد يرفع الاستثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات .NET؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة ورقة عمل تُنتج عن عملية حساب صالحة. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) تدل على أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يحدث تحديث تلقائي للمخطط عندما تتغيّر خلية الصيغة؟**

يمكن لسلسلة مخطط أن تشير إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو عرض العرض التقديمي. إذا كانت نقاط بيانات المخطط تشير إلى الخلايا المحسوبة، يستخدم المخطط القيم المحدثة؛ لا يلزم طريقة منفصلة لتحديث المخطط في هذا سير العمل.

**هل يمكن للمخططات استخدام دفتر إكسل خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر API بيانات المخطط. ومع ذلك، يقتصر سير عمل حساب الصيغ الموضح في هذه المقالة على دفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيمها Aspose.Slides. لا تفترض أن [CalculateFormulas](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) توفر إعادة حساب كاملة للصيغ العشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط إكسل في دفاتر عمل المخططات، لكن تقييم الصيغة يقتصر على المحلل ومجموعة الدوال المدعومة. إذا كان مرجع عبر ورقة أو مرجع خارجي ضروريًا، تحقق من صلاحية الصيغة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا مع مراجع إكسل، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

تُظهر أمثلة API في Aspose.Slides تعيين تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` دون علامة `=` الأولية. استخدام هذا الشكل يبقي الصيغ المُولَّدة متسقة مع أمثلة API الموثقة.