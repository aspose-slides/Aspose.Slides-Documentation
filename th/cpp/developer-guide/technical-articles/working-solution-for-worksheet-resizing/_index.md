---
title: โซลูชันการทำงานสำหรับการปรับขนาดเวิร์กชีต
type: docs
weight: 130
url: /th/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- เวิร์กชีต
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides for C++
description: "โซลูชันการทำงานสำหรับการปรับขนาดเวิร์กชีตในงานนำเสนอ PowerPoint ด้วย C++"
---
{{% alert color="primary" %}}
พบว่าเวิร์กชีต Excel ที่ฝังเป็นออบเจ็กต์ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนท์ของ Aspose จะถูกปรับขนาดเป็นอัตราที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างที่มองเห็นได้ในงานนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้ออบเจ็กต์ OLE เราได้ศึกษาปัญหานี้อย่างละเอียดและนำเสนอวิธีแก้ที่อธิบายในบทความนี้
{{% /alert %}}

## **พื้นฐาน**

ในบทความ[จัดการ OLE](/slides/th/cpp/manage-ole/) เราอธิบายวิธีเพิ่มกรอบ OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for C++ เพื่อแก้ไข[ปัญหาการแสดงตัวอย่างออบเจ็กต์](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่เวิร์กชีตที่เลือกให้กับกรอบออบเจ็กต์ OLE ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบ OLE ที่แสดงภาพเวิร์กชีต จะทำให้เวิร์กบุ๊ก Excel ทำงาน ผู้ใช้สามารถแก้ไขเวิร์กบุ๊ก Excel ตามต้องการแล้วคลิกนอกพื้นที่ที่เปิดใช้งานเพื่อกลับไปยังสไลด์ ขนาดของกรอบ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะต่างกันขึ้นอยู่กับขนาดของกรอบ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของมันเอง มันพยายามรักษาขนาดดั้งเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะเดียวกันกรอบออบเจ็กต์ OLE มีขนาดของมันเอง ตามที่ Microsoft ระบุเมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบออบเจ็กต์ OLE

## **วิธีแก้ที่ใช้งานได้**

มีวิธีแก้สองวิธีที่สามารถหลีกเลี่ยงผลกระทบจากการปรับขนาดได้

- ปรับขนาดกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดกรอบ OLE ไว้คงที่แล้วปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมให้พอดีกับขนาดกรอบ OLE ที่เลือกไว้

### **ปรับขนาด OLE Frame**

ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดกรอบ OLE ของเวิร์กบุ๊ก Excel ที่ฝังเพื่อให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เข้าร่วมในเวิร์กชีต Excel

สมมติว่าเรามีเทมเพลตเวิร์กชีต Excel และต้องการเพิ่มเป็นกรอบ OLE ในงานนำเสนอ ในกรณีนี้ขนาดของกรอบออบเจ็กต์ OLE จะถูกคำนวณโดยอิงจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่เข้าร่วมในเวิร์กบุ๊ก จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพกรอบ OLE

```cpp
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

```cpp
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

ในวิธีนี้ เราจะเรียนรู้วิธีปรับความสูงของแถวที่เข้าร่วมและความกว้างของคอลัมน์ที่เข้าร่วมให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

สมมติว่าเรามีเทมเพลตเวิร์กชีต Excel และต้องการเพิ่มเป็นกรอบ OLE ในงานนำเสนอ ในสถานการณ์นี้เราจะตั้งค่าขนาดของกรอบ OLE แล้วปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่กรอบ OLE เราจะบันทึกเวิร์กบุ๊กลงสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาเรย์ไบต์เพื่อเพิ่มลงในกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพกรอบ OLE

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// กำหนดขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นอ็อบเจ็กต์ OLE ใน PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// เราจำเป็นต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มภาพ OLE เข้าสู่ทรัพยากรของงานนำเสนอ.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// สร้างกรอบอ็อบเจ็กต์ OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

{{% alert color="primary" %}}
มีสองวิธีในการแก้ไขปัญหาการปรับขนาดของเวิร์กชีต การเลือกวิธีที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งานเฉพาะ ทั้งสองวิธีทำงานเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีข้อจำกัดต่อขนาดของกรอบออบเจ็กต์ OLE ในวิธีนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมเวิร์กชีต Excel ที่ฝังไว้จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**  
เนื่องจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ส่วนกรอบออบเจ็กต์ OLE ใน PowerPoint มีมิติของตัวเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้ทั้งหมดหรือไม่?**  
ได้ โดยการปรับขนาดกรอบ OLE ให้พอดีกับช่วงเซลล์ Excel หรือปรับขนาดช่วงเซลล์ให้พอดีกับกรอบ OLE ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีการปรับขนาดแบบใด OLE frame scaling หรือ cell range scaling?**  
เลือก **OLE frame scaling** หากต้องการรักษาขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **cell range scaling** หากต้องการให้กรอบ OLE มีขนาดคงที่ในงานนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากเทมเพลต?**  
ทำได้ ทั้งสองวิธีทำงานได้กับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีข้อจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**  
ไม่มี คุณสามารถตั้งค่ากรอบออบเจ็กต์ OLE ให้มีขนาดใดก็ได้ตราบใดที่ปรับสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความตัวอย่าง “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?**  
มี โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวอย่างของกรอบ OLE คุณจะสามารถแสดงภาพพรีวิวที่กำหนดเองแทนข้อความตัวอย่างเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็น OLE Object](/slides/th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)