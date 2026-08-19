---
title: تطبيق صيغ أوراق عمل المخطط في العروض التقديمية باستخدام C++
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/cpp/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول بيانات
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
- C++
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في أوراق عمل مخططات Aspose.Slides للغة C++، وإعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر في ورقة عمل مدمجة. في Aspose.Slides للـ C++، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغة بالكامل: إنشاء مخطط، تعبئة ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغة المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء جداول البيانات المحددة.

## **أوراق عمل المخطط والصيغ**

ورقة عمل المخطط تحتوي على الفئات، وأسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المدمجة مفتوحة، يُظهر الفئات وبيانات السلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تكون ورقة العمل مكشوفة عبر واجهة [IChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/). استخدم [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_formula/) لصيغ بنمط A1 و[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) لصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

ما زالت الخلية المحسوبة تكشف عن نتيجتها عبر [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/). هذا مهم عندما تحتاج إلى فحص نتيجة صيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يُظهر المثال التالي سير عمل من الطرف إلى الطرف. فهو ينشئ مخطط عمودي مُجَمَّع، يمسح البيانات التجريبية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الربح بالصيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

نقاط بيانات المخطط تشير إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا يوجد استدعاء منفصل لتحديث المخطط في هذا التدفق: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ النمط A1**

تحدد ترميز A1 الأعمدة بحروف والصفوف بأرقام. عيّن تعبيرات بنمط A1 عبر [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

الأشكال الشائعة للمرجع بنمط A1 هي:

| الإشارة | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل أو نسخ صيغة بواسطة تطبيق جدول بيانات. المراجع المطلقة تبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ النمط R1C1**

يحدد ترميز R1C1 الصفوف والأعمدة عدديًا. تُستخدم المراجع النسبية الإزاحات داخل أقواس مربعة. عيّن هذا الترميز عبر [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

الأشكال الشائعة للمرجع بنمط R1C1 هي:

| الإشارة | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` يعني الخلية في نفس الصف قبل عمودين (`B2`).

## **ثوابت الصيغ والعوامل**

يدعم مقيم الصيغ المدمج القيم المنطقية، والعددية، والنصية، وقيم أخطاء جداول البيانات، والعوامل الحسابية، وعوامل المقارنة.

### **الثوابت والأنواع الثابتة**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في التعبيرات المنطقية مثل `A2=TRUE`. |
| رقمي | `1`, `0.5`, `.3`, `1E-2` | يُدعم الشكل العادي والعلمي. |
| نص | `"abc"`, `"2/3/2020 12:00"` | يُحاط النص داخل علامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | قد تُقيم صيغة صحيحة إلى قيمة خطأ في جدول البيانات بدلاً من نتيجة طبيعية. |

يستخدم هذا المثال عدة أنواع ثابتة:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // خطأ
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **العوامل الحسابية**

| العامل | المعنى | مثال |
|---|---|---|
| `+` | جمع أو إشارة موجبة أحادية | `2+3` |
| `-` | طرح أو نفي أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لجعل ترتيب التقييم واضحًا، مثلًا `(A2+B2)*C2`.

### **العوامل المقارنة**

تُعيد تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | مساواة | `A2=3` |
| `<>` | عدم مساواة | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مقيم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| الدالة | الغرض أو الصيغة المدعومة | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم للأعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم النص | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم النص | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين التاريخين | `DAYS(B2,A2)` |
| `FIND` | البحث عن قيمة نص داخل أخرى | `FIND("-",A2)` |
| `FINDB` | بحث نصي على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | صيغة مرجعية | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | صيغة متجهية | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | صيغة متجهية | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول مهمة: `INDEX` موثقة بصيغة مرجعية، بينما `LOOKUP` و`MATCH` موثقة بصورهما المتجهية. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار أي ميزات أو دوال غير مدرجة هنا غير مدعومة من قبل مقيم صيغ Aspose.Slides ما لم تُوثق بشكل منفصل.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

تخزن ملفات جداول البيانات عادةً الصيغة والقيمة المحسوبة الأخيرة. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة من [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/) عند تحميل عرض تقديمي ولم يتم تغيير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يرفع قراءة قيمة خلية ذات بيانات غير مدعومة استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دوال Excel لا يقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جدول بيانات يدعمها واكتب القيم الناتجة مرةً أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مفترضة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التفريق بينهما.

يمكن أن تكون الصيغة صالحة لكن تُنتج نتيجة خطأ في جدول البيانات مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة للخلية ويمكن إرجاعه عبر [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/).

كما يمكن أن تفشل الصيغة في التحليل أو الإشارة أو التبعية أو مستوى البيانات المدعومة. توفر Aspose.Slides استثناءات مخصصة لجداول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

عند جلب الصيغ من قوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // معالجة صيغة غير صالحة.
}
catch (CellInvalidReferenceException&)
{
    // معالجة إشارة خلية غير صالحة.
}
catch (CellCircularReferenceException&)
{
    // معالجة إشارة دائرية.
}
catch (CellUnsupportedDataException&)
{
    // معالجة بيانات جدول بيانات غير مدعومة.
}
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محدودة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. احرص على مراعاة هذه القيود عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، والعوامل، والمراجع، والدوال الموثقة عندما تحتاج إلى أن يقوم Aspose.Slides بإعادة حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد نتائج الصيغ عليها.
- اعتبر القيم المخزنة من العروض المحملة لقطات ثابتة، وليس بديلاً عن إعادة الحساب بعد التعديل.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا كانت تستخدم دوالًا غير مدرجة في القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب كامل لجداول البيانات، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما هو الفرق بين `set_Formula` و`set_R1C1Formula`؟**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_formula/) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم الترميز الذي يتناسب مع طريقة إنشاء أو نسخ الصيغ لديك.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) يعيد كائنًا من نوع `IChartDataCell`. للحصول على النتيجة المحسوبة، اقرأ قيمة تلك الخلية عبر [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/) بعد إعادة الحساب.

**متى يجب استدعاء `CalculateFormulas`؟**

استدعِ [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يحدث تحديث قيم الصيغ التي يدعمها المقيم المدمج.

**هل يدعم Aspose.Slides كل دوال Excel؟**

لا. يدعم المقيم المدمج مجموعة موثقة فقط من الدوال. لا ينبغي افتراض أن أي دالة Excel خارج هذه المجموعة ستُعاد حسابها بشكل صحيح. إذا كانت هناك حاجة إلى توافق كامل مع صيغ Excel، قم بإجراء الحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض المحمّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون هذه القيمة المخزنة صالحة. محاولة الوصول إلى خلية صيغتها لا يمكن معالجتها قد ترفع استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات C++؟**

لا. نتيجة مثل `#DIV/0!` هي قيمة جدول بيانات تنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يحدث تحديث للمخطط تلقائيًا عندما تتغير خلية صيغة؟**

يمكن لسلسلة مخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو قدم العرض. إذا كانت نقاط بيانات المخطط تشير إلى الخلايا المحسوبة، سيستخدم المخطط القيم المحدثة؛ لا يلزم استدعاء طريقة تحديث منفصلة لهذا التدفق.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموصوف في هذه المقالة يتعلق بدفتر عمل بيانات المخطط والصيغ التي يقيمها Aspose.Slides. لا تفترض أن [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) يوفر إعادة حساب كاملة للصيغ العشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بأسلوب Excel في دفاتر عمل المخططات، لكن تقييم الصيغ يقتصر على المحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو دفتر خارجي ضروريًا، تحقق من صلاحية الصيغة المحددة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا للمرجع عبر Excel، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرةً أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بالعلامة `=`؟**

أمثلة API في Aspose.Slides تُعيّن تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` دون علامة `=` أولية. استخدام هذا الشكل يبقي الصيغ المولدة متسقة مع أمثلة API الموثقة.