---
title: วิธีแก้ปัญหาการปรับขนาดชีตงาน
type: docs
weight: 130
url: /th/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- ชีตงาน
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides for C++
description: "วิธีแก้ปัญหาการปรับขนาดชีตงานในงานนำเสนอ PowerPoint ด้วย C++"
---
{{% alert color="info" %}}
พบว่าชีต Excel ที่ฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนต์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่ชัดเจนในงานนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้งานอ็อบเจกต์ OLE เราได้ตรวจสอบปัญหานี้อย่างละเอียดและให้วิธีแก้ ซึ่งครอบคลุมในบทความนี้
{{% /alert %}}

## **พื้นฐาน**

ในบทความ [จัดการ OLE](/slides/th/cpp/manage-ole/) เราอธิบายวิธีเพิ่มกรอบ OLE ไปยังงานนำเสนอ PowerPoint ด้วย Aspose.Slides for C++ เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่ชีตที่เลือกให้กับกรอบอ็อบเจกต์ OLE ในงานนำเสนอที่ได้ผลลัพธ์ เมื่อคุณดับเบิลคลิกกรอบอ็อบเจกต์ OLE ที่แสดงภาพชีต Excel Workbook จะถูกเปิดใช้งาน ผู้ใช้ปลายทางสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการใน Excel Workbook ที่แท้จริงแล้วกลับไปที่สไลด์โดยคลิกนอก Workbook ที่เปิดใช้งาน ขนาดของกรอบอ็อบเจกต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปที่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบอ็อบเจกต์ OLE และ Excel Workbook ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจาก Excel Workbook มีขนาดหน้าต่างของตนเอง มันพยายามเก็บขนาดเดิมไว้เมื่อตัวแรกเปิดใช้งาน อีกด้านหนึ่งกรอบอ็อบเจกต์ OLE มีขนาดของตนเอง ตามข้อมูลของ Microsoft เมื่อ Excel Workbook ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้คงอัตราส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบอ็อบเจกต์ OLE

## **วิธีแก้ที่ทำงานได้**

มีวิธีแก้สองวิธีเพื่อหลีกเลี่ยงผลกระทบการปรับขนาด

- ปรับสเกลขนาดกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดกรอบ OLE ไค่คงที่และปรับสเกลขนาดของแถวและคอลัมน์ที่เข้าร่วมให้พอดีกับขนาดกรอบ OLE ที่เลือก

### **ปรับสเกลขนาดกรอบ OLE**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งขนาดกรอบ OLE ของ Excel Workbook ที่ฝังอยู่ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เข้าร่วมในชีต Excel

สมมติว่าเรามีชีต Excel เทมเพลตและต้องการเพิ่มเข้าไปในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ ขนาดของกรอบอ็อบเจกต์ OLE จะคำนวณเป็นครั้งแรกจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่เข้าร่วมใน Workbook จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ใน Workbook และตั้งเป็นภาพกรอบ OLE

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

// ตั้งขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE เป็นจุด.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// สร้างกรอบอ็อบเจกต์ OLE.
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

### **ปรับสเกลขนาดช่วงเซลล์**

ในแนวทางนี้ เราจะเรียนรู้วิธีปรับสเกลความสูงของแถวที่เข้าร่วมและความกว้างของคอลัมน์ที่เข้าร่วมให้ตรงกับขนาดกรอบ OLE แบบกำหนดเอง

สมมติว่าเรามีชีต Excel เทมเพลตและต้องการเพิ่มเข้าไปในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของกรอบ OLE แล้วปรับสเกลขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่กรอบ OLE จากนั้นเราจะบันทึก Workbook ลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาร์เรย์ไบต์เพื่อเพิ่มเข้าไปในกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ใน Workbook และตั้งเป็นภาพกรอบ OLE

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

// ตั้งขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// สร้างกรอบอ็อบเจกต์ OLE.
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

/// <param name="width">ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยจุด.</param>
/// <param name="height">ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยจุด.</param>
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

## **สรุป**

{{% alert color="info" %}}
มีสองวิธีในการแก้ปัญหาการปรับขนาดชีต การเลือกวิธีที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้เฉพาะ ทั้งสองวิธีทำงานเช่นเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีข้อจำกัดเรื่องขนาดของกรอบอ็อบเจกต์ OLE ในวิธีแก้นี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ทำไมชีต Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?
นี่เกิดจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่กรอบอ็อบเจกต์ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อคงอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

### สามารถป้องกันปัญหาการปรับขนาดนี้ได้ทั้งหมดหรือไม่?
ได้ โดยการปรับสเกลกรอบ OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ OLE ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

### ควรใช้วิธีการสเกลแบบใด OLE frame scaling หรือ cell range scaling?
เลือก **OLE frame scaling** หากต้องการคงขนาดแถวและคอลัมน์ Excel ดั้งเดิม เลือก **cell range scaling** หากต้องการขนาดกรอบ OLE คงที่ในงานนำเสนอของคุณ

### วิธีการเหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากเทมเพลต?
ทำได้ ทั้งสองวิธีทำงานกับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

### มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?
ไม่มี คุณสามารถทำให้กรอบอ็อบเจกต์ OLE มีขนาดใดก็ได้ ตราบใดที่ตั้งค่าสเกลได้อย่างเหมาะสม

### มีวิธีหลีกเลี่ยงข้อความ “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?
มี โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการแล้วตั้งเป็นภาพตัวแทนของกรอบ OLE คุณจะสามารถแสดงภาพตัวอย่างแบบกำหนดเองแทนข้อความ placeholder เริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)