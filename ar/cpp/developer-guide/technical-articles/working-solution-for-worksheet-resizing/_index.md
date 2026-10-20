---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 130
url: /ar/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تغيير حجم الصورة
- Excel
- ورقة العمل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides للغة C++
description: "حل عملي لتغيير حجم ورقة العمل في عروض PowerPoint باستخدام C++"
---
{{% alert color="info" title="Note" %}}
قد يتم تغيير حجم أوراق Excel المدمجة ككائنات OLE في عرض PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد تفعيلها الأول. يخلق هذا السلوك فرقًا بصريًا ملحوظًا بين كائن OLE قبل وبعد التفعيل. يشرح هذا المقال المشكلة ويصف طريقين لمعالجتها.
{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/cpp/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides للغة C++. لمعالجة [مشكلة معاينة الكائن](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المختارة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على المصنف الفعلي ثم العودة إلى الشريحة بالنقر خارج المصنف النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل تغيير الحجم اعتمادًا على حجم إطار OLE وحجم المصنف المضمّن.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel لديه حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تفعيل مصنف Excel، يتفاوض كل من Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث تغيير الحجم بناءً على الفروقات بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلان ممكنان لتجنب تأثير إعادة التحجيم.

- تحجيم إطار OLE في عرض PowerPoint لمطابقة الارتفاع والعرض الإجمالي للصفوف والأعمدة المحددة.
- إبقاء حجم إطار OLE ثابتًا وتحجيم الصفوف والأعمدة المحددة لتناسبه.

### **تحجيم حجم إطار OLE**

تحدد هذه المقاربة حجم إطار OLE لمطابقة الارتفاع والعرض الإجمالي للصفوف والأعمدة المحددة في ورقة Excel المدمجة.

يقوم المثال بتحميل مصنف Excel موجود ويختار الصفوف العشرة الأولى و13 عمودًا من ورقة العمل الأولى باستخدام فهارس تبدأ من الصفر. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) يحدد النطاق المعروض. يتم إنشاء المعاينة بدقة 96 DPI، وتُحول أبعاد البكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) يدمج المصنف المعدل في إطار بهذه الأبعاد. يتم تعيين المعاينة عبر [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) لاستبدال العنصر النائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

يستخدم أداة المساعدة للمعاينة [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) لتحديد النطاق وإزالة الهوامش والرؤوس والتذييلات. مع تمكين [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/)، يقوم [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) برسم النطاق كصورة PNG. تنسخ الأداة بيانات الصورة المرسومة إلى تدفق ذاكرة جديد موضعه في بدايته لاستخدامه في العرض.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **تحجيم حجم نطاق الخلايا**

تقوم هذه المقاربة بتحجيم ارتفاعات الصفوف المحددة وعروض الأعمدة المحددة لتتناسب مع حجم إطار OLE مخصص.

يقوم المثال بتحميل مصنف Excel موجود ويختار الصفوف العشرة الأولى و13 عمودًا من ورقة العمل الأولى باستخدام فهارس تبدأ من الصفر. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) يحدد النطاق المعروض، وتقوم الأداة أدناه بتحجيم ذلك النطاق ليتناسب مع إطار عرضه 400 نقطة وارتفاعه 100 نقطة. بعد حفظ المصنف المعدل إلى مصفوفة بايتات، يدمج [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/)ه في الحجم المحدد. يتم تعيين معاينة تم رسمها بدقة 96 DPI عبر [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/)، بحيث يعرض العرض المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// تحديد الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// تحجيم نطاق الخلايا ليتناسب مع حجم الإطار.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// نحتاج إلى استخدام المصنف المُعدل.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة صورة OLE إلى موارد العرض التقديمي.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// إنشاء إطار كائن OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

تحسب أداة المساعدة للتحجيم نسب العرض والارتفاع المنفصلة للنطاق المختار، مع الحفاظ على نسب عرض الأعمدة وارتفاع الصفوف. تقوم بتحويل الأبعاد المحسوبة من النقاط إلى إنشات قبل تطبيقها باستخدام [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) و[Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). يجب أن يكون للنطاق المختار عرض وارتفاع غير صفري.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">العرض المتوقع لنطاق الخلايا بالنقاط.</param>
/// <param name="height">الارتفاع المتوقع لنطاق الخلايا بالنقاط.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

تقوم أداة المساعدة للمعاينة هذه برسم النطاق المعاد تحجيمه باستخدام [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). تستخدم [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) لتقييد الطباعة على ذلك النطاق، وتزيل الهوامش والرؤوس والتذييلات، وتعيد تدفق PNG موضعه في بدايته.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **الخلاصة**

{{% alert color="info" title="Note" %}}
هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. اختر النهج الذي يناسب متطلباتك وحالتك الاستخدامية. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة المتكررة**

**لماذا تتغير حجم ورقة Excel المدمجة عند تفعيلها لأول مرة في PowerPoint؟**

يحدث ذلك لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تغيير الحجم.

**هل من الممكن منع مشكلة تغيير الحجم بالكامل؟**

نعم. من خلال تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**

اختر **تحجيم إطار OLE** إذا أردت الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تحجيم نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

**هل ستعمل هذه الحلول إذا كان عرضي معتمدًا على قالب؟**

نعم. كلا الحلين يعملان مع العروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**

لا. يمكنك ضبط إطار كائن OLE بأي حجم طالما قمت بضبط التحجيم بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. من خلال أخذ لقطة لنطاق خلايا Excel الهدف وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[إنشاء مخطط Excel وتضمينه في عرض ككائن OLE](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)