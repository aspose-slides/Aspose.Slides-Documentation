---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 60
url: /ar/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إصلاح تغيير حجم المخطط غير المتوقع في ملفات PPTX عند استخدام كائنات OLE Excel المدمجة مع Aspose.Slides لـ C++. حدد أبعاد مخطط ثابتة للحفاظ على تناسق حجم المخطط وإطار OLE."
---
## **الخلفية**

يمكن أن تتغير حجم مخططات Excel المدمجة ككائنات OLE في عروض PowerPoint باستخدام مكونات Aspose بعد تفعيلها لأول مرة. يمكن أن يتسبب ذلك في اختلاف ملحوظ في مظهر المخطط قبل وبعد التفعيل. يشرح هذا المقال سبب حدوث تغيير الحجم ويظهر كيفية منعه عبر مطابقة أبعاد المخطط الثابتة مع إطار OLE.

في [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells لـ C++ وتضمينه في عرض PowerPoint باستخدام Aspose.Slides لـ C++. لمعالجة [مشكلة معاينة الكائن](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عندما تنقر مرتين على إطار كائن OLE الذي يعرض صورة المخطط، يتم تفعيل مخطط Excel. يمكن للمستخدمين تعديل مصنف Excel المدمج ثم العودة إلى الشريحة بالنقر خارج المصنف المفعل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، ويتفاوت عامل تغيير الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

يحتوي مصنف Excel المدمج على أبعاد نافذة خاصة به، ويحاول Excel الحفاظ عليها عند تفعيل الكائن لأول مرة. يحتوي إطار OLE على الشريحة على أبعاد محددة بشكل مستقل. عندما يتم تفعيل مصنف Excel، يتفاوض Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. وبالتالي قد تتسبب الاختلافات بين نافذة المصنف وإطار OLE في تغيير حجم الكائن.

## **الحل العملي**

قم بمطابقة حجم المخطط مع إطار OLE على الشريحة واحفظ أبعاد المخطط مستقلة عن نافذة المصنف. يعمل هذا الحل مع عرض تقديمي جديد أو قالب موجود.

يتطلب المثال Aspose.Cells لـ C++ وAspose.Slides لـ C++. يقوم بإنشاء مخطط عمودي بسيط على ورقة مخطط نشطة ويضمّن المصنف بصيغة XLS. لا يتم تعيين صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عندما يتم تفعيل كائن OLE في PowerPoint.

ضع كود المثال في نقطة دخول التطبيق، مع إعلانات include على مستوى الملف. قم بتهيئة Aspose.Cells قبل إنشاء كائنه وحرّر موارده بعد تدمير تلك الكائنات. ينسخ المثال متجه البايتات للمصنف الذي تُرجعه Aspose.Cells إلى نوع المصفوفة الذي تقبله Aspose.Slides.

يقوم المثال بإنشاء عرض تقديمي جديد بإطار OLE بحجم 9.5 × 4 بوصة يتم وضعه على بعد 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات وأبعاد الشريحة تكون بالنقاط (72 نقطة لكل بوصة). للحصول على عرض تقديمي موجود، راجع [استخدام قالب](#use-a-template).

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إحداثيات الشريحة وأبعادها بالنقاط (72 نقطة لكل بوصة).
    auto width = 684.f; // 9.5 بوصة.
    auto height = 288.f; // 4 بوصة.

    chart.SetSizeWithWindow(false);
    // تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // نسخ متجه بايتات Cells إلى نوع المصفوفة الذي تقبله Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **تعيين حجم مخطط ثابت**

عيّن [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) إلى false بحيث تكون أبعاد المخطط مستقلة عن نافذة المصنف. حدّد أبعاد [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) عبر [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) و[Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/)، محوّلًا النقاط إلى بكسل باستخدام 96 بكسل لكل بوصة: الإطار الذي يقيِّس 684 × 288 نقطة يساوي مخططًا بـ 912 × 384 بكسل. عيّن [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) إلى القيمة Custom من [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). يضمّن المثال المصنف باستخدام [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) ويحفظ عرضًا تقديميًا بإطار OLE بحجم 9.5 × 4 بوصة.

## **استخدام قالب**

منطق تحديد الحجم هو نفسه للعرض التقديمي الموجود. لتكييف المثال:

1. حمّل عرض القالب بدلاً من إنشاء عرض فارغ.
2. تحقق أن الشريحة الأولى تحتوي على ثلاث أشكال على الأقل، ثم استخدم الشكل الموجود في الفهرس 2 كعنصر نائب.
3. خذ عرض الإطار وارتفاعه من ذلك الشكل بدلاً من استخدام القيم الثابتة 684 و288. حافظ على حسابات الحجم دون تغيير.
4. أضف إطار OLE عند موضع العنصر النائب بدلاً من الإحداثيات الثابتة 36 و72.
5. احذف العنصر النائب قبل حفظ العرض التقديمي.

## **الأسئلة المتكررة**

**لماذا يتغير حجم مخطط Excel المدمج بعد تفعيله في PowerPoint؟**

يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب تغيير الحجم.

**كيف يمكنني الحفاظ على تناسق حجم المخطط وإطار OLE؟**

حدد أبعاد مخطط ثابتة تتطابق مع إطار OLE واستخدم حجم طباعة مخصص للمخطط قبل تضمين المصنف. يوضح المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل مطابقة حجم نافذة المصنف كافية؟**

مطابقة حجم نافذة المصنف وحده لا يمنع تغيير حجم إطار OLE بشكل موثوق بعد التفعيل. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يُطبق هذا الحل على العروض التقديمية القائمة على القالب وعلى العروض الجديدة؟**

نعم. بالنسبة للقالب، استخدم أبعاد وموقع العنصر النائب. بالنسبة للعرض الجديد، حدّد أبعاد الإطار وموقعه مباشرة.

**هل يمكنني استخدام هذا المثال مع المخططات التي تم إنشاؤها في برامج جداول بيانات أخرى؟**

يستخدم المثال مصنف Excel تم إنشاؤه باستخدام Aspose.Cells. لا يُظهر سلوك التفعيل لبرامج جداول البيانات الأخرى.

## **الأقسام ذات الصلة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)