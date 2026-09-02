---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام C++
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/cpp/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- دفتر عمل بيانات المخطط
- حساب الصيغة
- الثقافة المفضلة
- صيغة خاصة بالثقافة
- DBCS
- ثابت منطقي
- ثابت رقمي
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
description: "تطبيق صيغ بنمط Excel في Aspose.Slides لأوراق عمل مخططات C++، وإعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تقوم مخططات PowerPoint بتخزين بيانات المصدر في ورقة عمل مضمّنة. في Aspose.Slides للـ C++، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

توضح هذه المقالة سير عمل الصيغة بالكامل: إنشاء مخطط، تعبئة ورقة العمل الخاصة به، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة المخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغة المدعومة، مجموعة الدالات المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء جداول البيانات المحددة.

## **أوراق عمل المخطط والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص الورقة بفتح محرّر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المدمجة مفتوحة، يظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تُعرَض الورقة عبر واجهة [IChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/). استخدم [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_formula/) للصيغ بنمط A1 و[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا تزال الخلية المحسوبة تكشف عن نتيجتها عبر [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يوضح المثال التالي سير عمل من البداية إلى النهاية. فهو ينشئ مخطط عمودي متكتل، يفرغ البيانات النموذجية، يكتب قيم الإيرادات والمصروفات ربع السنوية، يحسب الربح باستخدام الصيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في هذا التدفق: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ النمط A1**

تحدد الصيغة A1 الأعمدة بحروف والصفوف بأرقام. عيّن تعبيرات بنمط A1 عبر [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

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

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغيّر المراجع النسبية عندما تُنقل الصيغة أو تُنسخها تطبيقات جداول البيانات. المراجع المطلقة تُبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تُثبت إما الصف أو العمود فقط.

## **استخدام صيغ النمط R1C1**

تحدد الصيغة R1C1 كلًا من الصفوف والأعمدة رقمياً. تستخدم المراجع النسبية إزاحات داخل أقواس مربعة. عيّن هذه الصيغة عبر [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

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

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، يعني `RC[-2]` الخلية في نفس الصف ولكن عمودين إلى اليسار (`B2`).

## **ثوابت الصيغ والعوامل**

يدعم مقيم الصيغ المدمج القيم المنطقية، القيم العددية الحرفية، السلاسل النصية، قيم أخطاء جداول البيانات، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والقيّم الحرفية**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرةً في تعبيرات منطقية مثل `A2=TRUE`. |
| رقمي | `1`, `0.5`, `.3`, `1E-2` | يدعم التدوين العشري والعلمي. |
| نص | `"abc"`, `"2/3/2020 12:00"` | القيم النصية محاطة بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن أن تُقيم صيغة صالحة إلى قيمة خطأ في جدول البيانات بدلاً من نتيجة عادية. |

هذا المثال يستخدم عدة أنواع من الثوابت:

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

| العامل | المعنى | المثال |
|---|---|---|
| `+` | جمع أو زائد أحادي | `2+3` |
| `-` | طرح أو سالب أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لتوضيح ترتيب التقييم، على سبيل المثال `(A2+B2)*C2`.

### **العوامل المقارنة**

تُعيد تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | المثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | ليس مساوياً | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقاً المدعومة**

يتضمن Aspose.Slides مقيم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموضحة في الوثائق محدودة إلى الدوال التالية. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| الدالة | الغرض أو الشكل المدعوم | المثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب رقم إلى أقرب مضاعف أعلى | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم النص | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم النص | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام التاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين التاريخين | `DAYS(B2,A2)` |
| `FIND` | البحث عن نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نص على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجعي | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجهي | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجهي | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الواردة في الجدول مهمة: `INDEX` موثّق في شكل مرجعي، بينما `LOOKUP` و `MATCH` موثّقان في شكليهما المتجهيين. `DATE` يستخدم نظام التاريخ 1900. يجب اعتبار الدوال غير المذكورة على أنها غير مدعومة من مقيم صيغ Aspose.Slides ما لم يتم توثيقها بشكل منفصل.

## **حساب الصيغ مع ثقافة مفضلة**

بعض دوال دفتر العمل تفسّر النص وفق قواعد ثقافية مخصصة. وهذا مهم خاصةً للدوال الموجهة للغات التي تستخدم مجموعات أحرف ثنائية البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/)، ضبط [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) عبر [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/)، ثم حمِّل العرض التقديمي.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

الثقافة المفضلة هي جزء من إعدادات تحميل العرض التقديمي، لذا حدّدها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). استخدم الثقافة المتوقعة من صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تخزّن ملفات جداول البيانات كلًا من الصيغة والقيمة التي تم حسابها آخرًا. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزّنة مؤقتًا من [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/) عند تحميل العرض التقديمي إذا لم تُغيّر بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على النتيجة المخزّنة القديمة. استدعِ [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعيتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزّنة السابقة. في تلك الحالة، قد يُثير قراءة قيمة خلية ذات صيغة غير مدعومة استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دالات Excel لا تُقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جداول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مُخمّنة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صالحة لكنها تُنتج نتيجة خطأ في جدول البيانات مثل `#DIV/0!`، `#N/A`، `#NAME?`، `#NULL!`، `#NUM!`، `#REF!`، أو `#VALUE!`. في هذه الحالة، يُعدّ رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/).

كما قد تفشل الصيغة في مرحلة التحليل، أو المرجع، أو التبعية، أو مستوى البيانات المدعومة. توفر Aspose.Slides استثناءات محددة لجدول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)، [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/)، [CellCircularReferenceException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/)، و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

عند الحصول على صيغ من قوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول عملية إعادة الحساب والوصول إلى القيم:

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
    // معالجة مرجع خلية غير صالح.
}
catch (CellCircularReferenceException&)
{
    // معالجة مرجع دائري.
}
catch (CellUnsupportedDataException&)
{
    // معالجة بيانات جدول بيانات غير مدعومة.
}
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات موجه لمجموعة محددة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل التقارير:

- استخدم فقط الثوابت والعوامل والمرجعيات والدوال الموثقة عندما تحتاج إلى أن تقوم Aspose.Slides بإعادة حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا من العروض المحملة كلقطات، لا كبديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا كانت تستخدم دالات غير مدرجة في القائمة الموثقة.
- للصيغ التي تحتاج إلى محرك حساب جدول بيانات كامل، احسبها خارجيًا ثم حدّث ورقة عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين `set_Formula` و `set_R1C1Formula`؟**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_formula/) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتوافق مع طريقة إنشاء أو نسخ الصيغ لديك.

**هل يجب قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) يُعيد كائنًا من نوع `IChartDataCell`. للحصول على النتيجة المحسوبة، اقرأ قيمة تلك الخلية عبر [IChartDataCell::get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_value/) بعد إعادة الحساب.

**متى يجب استدعاء `CalculateFormulas`؟**

استدعِ [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المقيّم المدمج.

**هل يدعم Aspose.Slides كل دالة Excel؟**

لا. يدعم المقيّم المدمج مجموعة موثّقة من الدوال فقط. لا يجب افتراض أن الدوال خارج هذه المجموعة ستحسَب بشكل صحيح. إذا كانت الحاجة إلى توافق كامل مع صيغ Excel، نفّذ الحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض التقديمي المحمَّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغيّر بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزّنة مسبقًا. بعد تعديل البيانات المرتبطة، قد لا تكون تلك القيمة المخزّنة صالحة. قد يؤدي الوصول إلى خلية بصيغة غير مدعومة إلى رفع استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات C++؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول بيانات تُنتج من عملية حساب صحيحة. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يحدث تحديث للمخطط تلقائيًا عندما تتغيّر خلية الصيغة؟**

يمكن لسلسلة المخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو عالج العرض التقديمي. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، سيستخدم المخطط القيم المحدثة؛ لا يلزم طريقة منفصلة لتحديث المخطط في هذا التدفق.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة تطبيقات بيانات المخطط. ومع ذلك، يُركز سير عمل حساب الصيغ الموصوف في هذه المقالة على دفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيّمها Aspose.Slides. لا تفترض أن [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) توفر إعادة حساب كاملة للصياغات العشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ محدود بالمحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو دفتر خارجي ضروريًا، تحقق من صلاحية الصيغة مع نسخة Aspose.Slides المستهدفة. بالنسبة للتدفقات التي تتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المُحَلَّة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة API في Aspose.Slides تُعيّن تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون علامة `=` في البداية. استخدام هذا الشكل يحافظ على توافق الصيغ المُولَّدة مع أمثلة API الموثقة.