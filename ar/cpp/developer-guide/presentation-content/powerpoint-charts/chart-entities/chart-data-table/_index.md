---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام C++
linktitle: جدول البيانات
type: docs
url: /ar/cpp/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تخصيص خطوط جداول بيانات المخططات، الحدود، ومفاتيح الأسطورة في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تمكّن Aspose.Slides للغة C++ من عرض جدول بيانات المخطط وتخصيص تنسيق النص، والحدود، ومفاتيح الأسطورة. يشرح هذا المقال كيفية تمكين الجدول، تنسيق نصه، التحكم في كل نوع من الحدود، وإظهار أو إخفاء مفاتيح الأسطورة. تحفظ الأمثلة المخططات المكوّنة في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، مرّر `true` إلى [IChart::set_HasDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/set_hasdatatable/). استخدم [IChart::get_ChartDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_chartdatatable/) للوصول إلى الجدول وتكوين تنسيق النص.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. إضافة مخطط عمودي مجمع إلى الشريحة الأولى.
1. تمكين جدول بيانات المخطط.
1. تمكين النص الغامق باستخدام [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_fontbold/) ومرّر `20` إلى [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_fontheight/) للحصول على نص بحجم 20 نقطة.
1. حفظ العرض التقديمي المعدل.

تتطلب المثال التالي ملف `test.pptx` في دليل العمل يحتوي على شريحة واحدة على الأقل. يضيف مخططًا ببيانات افتراضية في الموقع (50, 50)، بعرض 600 نقطة وارتفاع 400 نقطة. يحتوي ملف `output.pptx` المحفوظ على المخطط مع جدول البيانات مفعلاً وإعدادات الخط المحددة مطبقة.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تخصيص حدود جدول البيانات**

تمكين الجدول باستخدام [IChart::set_HasDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/set_hasdatatable/) والوصول إليه عبر [IChart::get_ChartDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_chartdatatable/). يمكنك التحكم في ثلاثة أنواع من الحدود بشكل مستقل:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) يتحكم في حدود الخلايا الأفقية.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) يتحكم في حدود الخلايا العمودية.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) يتحكم في الحدود الخارجية للجدول.

مرّر `true` إلى كل مُحدد لعرض حدوده أو `false` لإخفائها. ينشئ المثال التالي مخطط عمودي مجمع ببيانات افتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب أي ملف إدخال. يُحدَّد موقع المخطط وحجمه بالنقاط.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعداد مفتاح الأسطورة في جميع الحالات الأربعة. يبدأ الجميع بجميع الحدود مفعلة، وتُعطَّل كل حالة حدوداً واحدة فقط. يتطابق الشكل السفلي الأيسر مع إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، دون حدود أفقية، دون حدود عمودية، ودون حد خارجي](data-table-borders.png)

## **إظهار أو إخفاء مفاتيح الأسطورة**

مفاتيح الأسطورة هي علامات ملونة صغيرة بجانب أسماء السلاسل في جدول البيانات. تساعد القراء على ربط كل صف من الجدول بسلسلة المخطط. مرّر `true` إلى [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) لإظهار هذه العلامات أو `false` لإخفائها.

يتم التحكم في الأسطورة المنفصلة للمخطط عبر [IChart::set_HasLegend](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/set_haslegend/). هذه الإعدادات مستقلة: إخفاء الأسطورة المنفصلة لا يخفى المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفى الأسطورة المنفصلة.

ينشئ المثال التالي مخططًا ببيانات افتراضية، يمكّن جدول البيانات، ويُظهر مفاتيح الأسطورة داخله مع إخفاء الأسطورة المنفصلة. جميع حدود الجدول مفعلة صراحة. لا يُطلب أي عرض تقديمي كإدخال. لإخفاء مفاتيح الجدول فقط، مرّر `false` إلى [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

المقارنة أدناه تُظهر نفس الجدول مع تمكين مفاتيح الأسطورة وإيقافها. تبقى جميع الحدود مفعلة، وتظل الأسطورة المنفصلة للمخطط مخفية في الحالتين.

![جداول بيانات المخطط مع إظهار مفاتيح الأسطورة على اليسار وإخفائها على اليمين](data-table-legend-keys.png)

## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح الأسطورة في جدول بيانات المخطط؟**

نعم. مرّر `true` إلى [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) لعرض مفاتيح الأسطورة أو `false` لإخفائها.

**هل سيُحافظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides بتصيير المخطط وجدول البيانات المعروض كجزء من الشريحة عند التصدير إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، أو [الصور](/slides/ar/cpp/convert-powerpoint-to-png/).

**هل يمكنني العمل مع جداول البيانات في المخططات التي تم تحميلها من قالب؟**

نعم. للمخطط المحمَّل من عرض تقديمي أو قالب موجود، استخدم [IChart::get_HasDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_hasdatatable/) للتحقق مما إذا كان جدول البيانات معروضًا و[IChart::set_HasDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/set_hasdatatable/) لتغيير رؤيته.

**كيف يمكنني العثور على المخططات التي لديها جدول بيانات مفعَّل؟**

قم بالتكرار عبر الأشكال في كل شريحة، حدِّد المخططات، وتحقق من نتيجة [IChart::get_HasDataTable](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_hasdatatable/). قيمة `true` تشير إلى أن جدول البيانات مفعَّل.