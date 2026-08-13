---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 130
url: /ar/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides for C++
description: "حل عملي لتغيير حجم ورقة العمل في عروض PowerPoint باستخدام C++"
---
{{% alert color="info" %}}

تم ملاحظة أن أوراق Excel المدمجة ككائنات OLE في عرض PowerPoint من خلال مكونات Aspose تُعاد تحجيمها إلى مقياس غير معروف بعد التفعيل الأول. يتسبب هذا السلوك في اختلاف بصري ملحوظ في العرض بين حالتي الكائن OLE قبل وبعد التفعيل. لقد فحصنا هذه المشكلة بالتفصيل وقدمنا حلاً، وهو ما يغطيه هذا المقال.

{{% /alert %}}

## **الخلفية**

في المقال [Manage OLE](/slides/ar/cpp/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for C++. لمعالجة [مشكلة معاينة الكائن](/slides/ar/cpp/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل دفتر Excel. يمكن للمستخدمين إجراء أي تغييرات مرغوبة على دفتر Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج دفتر Excel المفعل. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل التحجيم بناءً على حجم إطار كائن OLE ودفتر Excel المدمج.

## **سبب التحجيم**

نظرًا لأن دفتر Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لـ Microsoft، عندما يتم تفعيل دفتر Excel، تتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث التحجيم بناءً على الفروق بين حجم نافذة Excel وحجم وموقع إطار كائن OLE.

## **الحل العملي**

هناك حلّان ممكنان لتجنب تأثير التحجيم.

- تعديل مقياس حجم إطار OLE في عرض PowerPoint ليتطابق مع ارتفاع وعرض عدد الصفوف والأعمدة المطلوبة في إطار OLE.
- الحفاظ على حجم إطار OLE ثابتًا وتحويل مقياس حجم الصفوف والأعمدة المشاركة لتتناسب مع حجم إطار OLE المختار.

### **تعديل مقياس حجم إطار OLE**

في هذه الطريقة، سنتعلم كيفية تعيين حجم إطار OLE لدفتر Excel المدمج ليتطابق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة Excel.

لنفترض أن لدينا نموذج ورقة Excel ونرغب في إضافتها إلى عرض كإطار OLE. في هذا السيناريو، سيتم أولاً حساب حجم إطار كائن OLE بناءً على الارتفاعات التراكمية للصفوف وعروض الأعمدة المشاركة في الدفتر. ثم سنعيّن حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنب ظهور رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في الدفتر ونستخدمها كصورة لإطار OLE.

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

// تعيين الحجم الظاهر عندما يتم استخدام ملف دفتر العمل ككائن OLE في PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// الحصول على عرض وارتفاع صورة OLE بالنقاط.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// نحتاج إلى استخدام دفتر العمل المعدل.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة صورة OLE إلى موارد العرض التقديمي.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// إنشاء إطار كائن OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

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

### **تعديل مقياس حجم نطاق الخلايا**

في هذه الطريقة، سنتعلم كيفية تعديل ارتفاع الصفوف المشاركة وعرض الأعمدة المشاركة ليتطابق مع حجم إطار OLE مخصص.

لنفترض أن لدينا نموذج ورقة Excel ونرغب في إضافتها إلى عرض كإطار OLE. في هذا السيناريو، سنعيّن حجم إطار OLE ونحوّل مقياس حجم الصفوف والأعمدة التي تشارك في منطقة إطار OLE. ثم سنحفظ الدفتر إلى تدفق لتطبيق التغييرات ونحوّله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنب ظهور رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في الدفتر ونستخدمها كصورة لإطار OLE.

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

// تعيين الحجم الظاهر عندما يتم استخدام ملف دفتر العمل ككائن OLE في PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// تعديل مقياس نطاق الخلايا ليتناسب مع حجم الإطار.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// نحتاج إلى استخدام دفتر العمل المعدل.
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

{{% alert color="info" %}}

هناك نهجان لإصلاح مشكلة تحجيم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات الخاصة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من نموذج أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة الشائعة**

### لماذا يتغير حجم ورقة Excel المدمجة عندما يتم تفعيلها لأول مرة في PowerPoint؟

يحدث هذا لأن Excel تحاول الحفاظ على حجم النافذة الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب التحجيم.

### هل يمكن منع هذه المشكلة تمامًا؟

نعم. من خلال تعديل مقياس إطار OLE ليتطابق مع حجم نطاق خلية Excel أو تعديل مقياس نطاق الخلية ليتطابق مع حجم إطار OLE المطلوب، يمكنك منع التحجيم غير المرغوب فيه.

### أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟

اختر **تحجيم إطار OLE** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تحجيم نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

### هل ستعمل هذه الحلول إذا كان العرض مبنيًا على نموذج؟

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من النماذج أو من الصفر.

### هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟

لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط المقياس بشكل مناسب.

### هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟

نعم. من خلال التقاط لقطة لنطاق خلية Excel المستهدف وتعيينها كصورة بديلة لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)