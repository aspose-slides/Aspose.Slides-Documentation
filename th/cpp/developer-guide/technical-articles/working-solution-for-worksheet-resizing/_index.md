---
title: โซลูชันที่ทำงานได้สำหรับการปรับขนาดแผ่นงาน
type: docs
weight: 130
url: /th/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides for C++
description: "โซลูชันที่ทำงานได้สำหรับการปรับขนาดแผ่นงานในงานนำเสนอ PowerPoint โดยใช้ C++"
---
{{% alert color="info" title="Note" %}}
แผ่นงาน Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint โดยใช้ส่วนประกอบของ Aspose อาจปรับขนาดโดยไม่คาดคิดหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่ชัดเจนระหว่างวัตถุ OLE ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและอธิบายวิธีแก้ไขสองวิธี
{{% /alert %}}

## **พื้นฐาน**

ในบทความ [จัดการ OLE](/slides/th/cpp/manage-ole/), เราได้อธิบายวิธีเพิ่มเฟรม OLE ลงในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for C++. เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดรูปภาพของพื้นที่แผ่นงานที่เลือกให้กับเฟรมวัตถุ OLE. ในงานนำเสนอที่ส่งออก, เมื่อคุณดับเบิลคลิกที่เฟรมวัตถุ OLE ที่แสดงรูปภาพแผ่นงาน, สมุดงาน Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในสมุดงาน Excel จริงและจากนั้นกลับไปยังสไลด์โดยคลิกนอกสมุดงาน Excel ที่เปิดใช้งาน ขนาดของเฟรมวัตถุ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของเฟรมวัตถุ OLE และสมุดงาน Excel ที่ฝังไว้

## **สาเหตุของการปรับขนาด**

เพราะสมุดงาน Excel มีขนาดหน้าต่างของตัวเอง มันพยายามรักษาขนาดเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะเดียวกันเฟรมวัตถุ OLE มีขนาดของตัวเอง ตามข้อมูลของ Microsoft เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้แน่ใจว่ารักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นตามความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของเฟรมวัตถุ OLE

## **วิธีแก้ไขที่ใช้งานได้**

มีวิธีแก้ไขสองวิธีที่เป็นไปได้เพื่อหลีกเลี่ยงผลของการปรับขนาด

- ปรับขนาดเฟรม OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างทั้งหมดของแถวและคอลัมน์ที่เลือก
- รักษาขนาดเฟรม OLE คงที่และปรับขนาดแถวและคอลัมน์ที่เลือกให้พอดีในนั้น

### **ปรับขนาดเฟรม OLE**

วิธีนี้ตั้งค่าขนาดเฟรม OLE ให้ตรงกับความสูงและความกว้างทั้งหมดของแถวและคอลัมน์ที่เลือกในแผ่นงาน Excel ที่ฝังไว้

ตัวอย่างโหลดสมุดงาน Excel ที่มีอยู่และเลือก 10 แถวแรกและ 13 คอลัมน์แรกของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) กำหนดช่วงที่จะแสดง ตัวอย่างแสดงผลที่ความละเอียด 96 DPI และมิติพิกเซลจะถูกแปลงเป็นพอยต์โดยใช้ 72 พอยต์ต่ออินช์ [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) ฝังสมุดงานที่แก้ไขไว้ในเฟรมที่มีขนาดดังกล่าว ตัวอย่างแสดงผลจะถูกกำหนดผ่าน [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) เพื่อแทนที่ข้อความตัวแทน "EMBEDDED OLE OBJECT" ในงานนำเสนอที่บันทึก
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

// กำหนดขนาดที่แสดงเมื่อไฟล์สมุดงานถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE หน่วยเป็นพอยต์.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// เราต้องใช้สมุดงานที่แก้ไขแล้ว.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มภาพ OLE ไปยังแหล่งข้อมูลของงานนำเสนอ.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// สร้างเฟรมวัตถุ OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

ตัวช่วยแสดงตัวอย่างใช้ [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) เพื่อเลือกช่วงและลบขอบ, ส่วนหัว, ส่วนท้าย. เมื่อเปิดใช้งาน [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) แล้ว [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) จะเรนเดอร์ช่วงเป็นภาพ PNG ตัวช่วยคัดลอกข้อมูลภาพที่เรนเดอร์ลงในสตรีมหน่วยความจำใหม่ที่ตำแหน่งเริ่มต้นเพื่อใช้ในงานนำเสนอ
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

### **ปรับขนาดช่วงเซลล์**

วิธีนี้ปรับความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาดเฟรม OLE ที่กำหนดเอง

ตัวอย่างโหลดสมุดงาน Excel ที่มีอยู่และเลือก 10 แถวแรกและ 13 คอลัมน์แรกของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) กำหนดช่วงที่จะแสดงและตัวช่วยด้านล่างจะปรับขนาดช่วงนั้นให้พอดีกับเฟรมที่กว้าง 400 พอยต์และสูง 100 พอยต์ หลังจากบันทึกสมุดงานที่แก้ไขเป็นอาร์เรย์ไบต์ [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) จะฝังมันในขนาดที่กำหนด ตัวอย่างที่เรนเดอร์ที่ความละเอียด 96 DPI จะถูกกำหนดผ่าน [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) เพื่อให้งานนำเสนอที่บันทึกแสดงเซลล์ที่เลือกแทนตัวแทนเริ่มต้น
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

// กำหนดขนาดที่แสดงเมื่อไฟล์สมุดงานถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับขนาดช่วงเซลล์ให้พอดีกับขนาดเฟรม.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้สมุดงานที่แก้ไขแล้ว.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// สร้างเฟรมวัตถุ OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

ตัวช่วยปรับสเกลคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก โดยรักษาความกว้างสัมพัทธ์ของคอลัมน์และความสูงสัมพัทธ์ของแถวไว้ มันจะแปลงขนาดที่คำนวณจากพอยต์เป็นนิ้วก่อนนำไปใช้กับ [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) และ [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) ช่วงที่เลือกต้องมีความกว้างและความสูงไม่เป็นศูนย์
```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยพอยต์</param>
/// <param name="height">ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยพอยต์</param>
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

ตัวช่วยแสดงตัวอย่างนี้เรนเดอร์ช่วงที่ปรับขนาดโดยใช้ [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). มันใช้ [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) เพื่อจำกัดการพิมพ์เฉพาะช่วงนั้น, ลบขอบ, ส่วนหัว, ส่วนท้าย, และคืนสตรีม PNG ที่ตำแหน่งเริ่มต้น
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

## **บทสรุป**

{{% alert color="info" title="Note" %}}
มีสองวิธีแก้ไขปัญหาการปรับขนาดแผ่นงาน เลือกวิธีที่เหมาะสมกับความต้องการและกรณีการใช้งานของคุณ ทั้งสองวิธีทำงานในลักษณะเดียวกัน ไม่ว่าการนำเสนอจะสร้างจากแม่แบบหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของเฟรมวัตถุ OLE ในวิธีแก้ไขนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**  
นี่เกิดขึ้นเพราะ Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อตั้งค่าเปิดใช้งาน ในขณะเดียวกันเฟรมวัตถุ OLE ใน PowerPoint มีมิติของตัวเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาดที่ไม่ต้องการ

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?**  
ได้ โดยการปรับขนาดเฟรม OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือปรับขนาดช่วงเซลล์ให้พอดีกับขนาดเฟรม OLE ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีปรับสเกลใด ระหว่างการปรับสเกลเฟรม OLE หรือการปรับสเกลช่วงเซลล์?**  
เลือก **OLE frame scaling** หากคุณต้องการรักษาขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **cell range scaling** หากคุณต้องการขนาดคงที่สำหรับเฟรม OLE ในงานนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากแม่แบบ?**  
ได้ ทั้งสองวิธีทำงานได้สำหรับงานนำเสนอที่สร้างจากแม่แบบหรือสร้างจากศูนย์

**มีขีดจำกัดขนาดของเฟรม OLE หรือไม่เมื่อใช้วิธีเหล่านี้?**  
ไม่มี คุณสามารถตั้งค่าเฟรมวัตถุ OLE ให้มีขนาดใดก็ได้ ตราบใดที่กำหนดสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความตัวแทน "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**  
ได้ โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวแทนของเฟรม OLE คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนตัวแทนเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)