---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 40
url: /ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين المخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells للـ C++ وتضمين دفتر العمل في عرض PowerPoint باستخدام Aspose.Slides، بما في ذلك معاينة المخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط عمودي في Excel باستخدام Aspose.Cells للـ C++ وتضمين دفتر العمل الخاص به في عرض تقديمي PowerPoint باستخدام Aspose.Slides للـ C++. يحتوي دفتر العمل المضمن على كل من البيانات المصدرية والمخطط. عرض PNG منفصل يُظهر المخطط على الشريحة قبل تفعيل كائن OLE.

النتيجة هي كائن Excel مضمّن، وليس مخطط PowerPoint أصلي. يتطلب تحرير دفتر العمل عبر OLE وجود تطبيق سطح مكتب يدعم تفعيل OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

قم بتهيئة مشروع C++ الخاص بك مع رؤوس ومكتبات Aspose.Cells للـ C++ وAspose.Slides للـ C++. ضع مثال الشيفرة في نقطة دخول التطبيق، مع إعلانات الـ include على مستوى الملف. لا يلزم وجود Microsoft Office لتوليد العرض باستخدام هذه المكتبات.

لا توجد ملفات إدخال مطلوبة: يقوم المثال بإنشاء البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى دليل العمل الحالي. طبّق تراخيص كلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيفية عمل الدمج**

1. إنشاء دفتر عمل يحتوي على ورقة بيانات وورقة مخطط.  
1. جعل ورقة المخطط نشطة بحيث يُفتح دفتر العمل على المخطط.  
1. ضبط نطاق عرض OLE لدفتر العمل وتصدير المخطط إلى PNG.  
1. حفظ دفتر العمل كـ XLSX في الذاكرة وتضمين تلك البايتات في شريحة.  
1. تعيين PNG كمعاينة كائن OLE وحفظ العرض التقديمي كـ PPTX.

نطاق عرض دفتر العمل والإطار على الشريحة لهما أدوار مختلفة. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) يأخذ مؤشرات الصف والعمود بنظام الصفر. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) بدلاً من ذلك يأخذ الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال مؤشر الصف 55 ومؤشر العمود 25 كحدود سفلية يمنة؛ هذه القيم اختيارات تخطيط، ليست عدد صفوف أو أعمدة البيانات.

يستخدم إطار الشريحة نقاطًا. يقوم المثال بملائمته داخل الشريحة وتوسيطه مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

المثال الكامل التالي يملأ `DataSheet` بأربع صفوف وخمس أعمدة من القيم. كل صف يتحول إلى سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ دفتر العمل.

يتم حفظ دفتر العمل صراحةً كـ XLSX، متطابقًا مع الامتداد `xlsx` الممرّر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). يتم تحميل PNG من تدفق في الذاكرة دون تحويل إلى bitmap وسيط. تُرجع Aspose.Cells متجهات بايت، ينسخ المثال تلك المتجهات إلى نوع المصفوفة المقبول من قبل Aspose.Slides. يجب تهيئة Aspose.Cells قبل استخدام كائناتها، وإطلاق مواردها بعد تدمير تلك الكائنات. استبدالها عبر [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) يستبدل العنصر النائب الافتراضي لـ OLE.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// تهيئة Cells قبل إنشاء أي من كائناتها.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // إنشاء معاينة المخطط وتسلسل دفتر العمل القابل للتحرير بشكل منفصل.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // نسخ مخازن Cells إلى نوع المصفوفة المستخدمة من قبل Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // ملاءمة المعاينة داخل الشريحة دون تغيير نسبة الأبعاد.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// تحرير موارد Cells بعد تدمير جميع كائنات Cells.
Aspose::Cells::Cleanup();
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة مع دفتر عمل Excel مضمّن ومعاينة مخطط. يحتوي دفتر العمل على البيانات الأصلية ومخطط عمودي بأربع سلاسل. المعاينة متمركزة على الشريحة وتحتفظ بنسبة أبعادها.

![مخطط عمودي في Excel معروض كمعاينة لدفتر عمل مضمّن](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة مع وجود Excel، انقر مزدوجًا على الكائن لتفعيل وتحرير دفتر العمل المضمّن. يعتمد التفعيل والتحرير على دعم OLE لتطبيق المستضيف وإعدادات الأمان.

## **الأسئلة المتكررة**

**لماذا يلزم وجود صورة معاينة؟**

دفتر العمل المضمّن ومعاينة الشريحة منفصلان. قدم صورة مخطط حتى تعرض الشريحة المخطط بدلاً من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". راجع [مشكلة معاينة الكائن عند إضافة OleObjectFrame](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/).

**هل يتم تحديث المعاينة تلقائيًا عندما أغيّر المصنف في الكود؟**

اعتبر المعاينة لقطة ثابتة. عند تحديث بيانات دفتر العمل برمجيًا، أعد توليد صورة المخطط واستبدل المعاينة وكذلك بيانات دفتر العمل المضمّن.

**هل يمكنني استخدام XLS بدلاً من XLSX؟**

نعم. احفظ دفتر العمل بصيغة XLS واستخدم الامتداد `xls` كامتداد البيانات المضمنة. يجب أن يتطابق الامتداد مع تنسيق دفتر العمل الفعلي؛ تغيير الامتداد وحده لا يُحوِّل البيانات.

**لماذا قد يتغير حجم الكائن بعد التفعيل؟**

يمكن لتطبيق المستضيف تحديث عرض كائن OLE عند تفعيل دفتر العمل. كل من نطاق عرض OLE لدفتر العمل وأبعاد إطار الشريحة مهمان. راجع [حل عملي لإعادة تحجيم المخطط في PPTX](/slides/ar/cpp/working-solution-for-chart-resizing-in-pptx/).

## **الأقسام المرتبطة**

- [حل عملي لإعادة تحجيم المخطط في PPTX](/slides/ar/cpp/working-solution-for-chart-resizing-in-pptx/)
- [مشكلة معاينة الكائن عند إضافة OleObjectFrame](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/)