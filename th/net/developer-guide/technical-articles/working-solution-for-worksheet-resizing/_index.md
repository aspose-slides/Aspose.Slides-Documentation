---
title: วิธีแก้ปัญหาที่ใช้งานได้สำหรับการปรับขนาดแผ่นงาน
type: docs
weight: 40
url: /th/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: สองวิธีเพื่อให้เฟรมออบเจ็กต์คงที่—ปรับสเกลเฟรมหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX"
---
{{% alert color="primary" %}} 

พบว่าเวิร์กชีต Excel ที่ฝังเป็นออบเจ็กต์ OLE ในการนำเสนอ PowerPoint ผ่านคอมโพเนนต์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างที่เห็นได้ชัดระหว่างสถานะก่อนและหลังการเปิดใช้ออบเจ็กต์ OLE ในการนำเสนอ เราได้สอบสวนปัญหานี้อย่างละเอียดและจัดเตรียมวิธีแก้ไข ซึ่งอธิบายในบทความนี้

{{% /alert %}} 

## **เบื้องหลัง**

ในบทความ [จัดการ OLE](/slides/th/net/manage-ole/) เราได้อธิบายวิธีการเพิ่มเฟรม OLE ลงในการนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างออบเจ็กต์](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่เวิร์กชีตที่เลือกให้กับเฟรมออบเจ็กต์ OLE ในการนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่เฟรมออบเจ็กต์ OLE ที่แสดงภาพเวิร์กชีต Excel เวิร์กบุ๊กจะถูกเปิดใช้งาน ผู้ใช้สามารถทำการเปลี่ยนแปลงใด ๆ กับเวิร์กบุ๊ก Excel จริงได้ แล้วกลับไปที่สไลด์โดยคลิกนอกเวิร์กบุ๊ก Excel ที่เปิดใช้งาน ขนาดของเฟรมออบเจ็กต์ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปที่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันไปตามขนาดของเฟรมออบเจ็กต์ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้เมื่อตอนเปิดใช้งานครั้งแรก ในขณะเดียวกันเฟรมออบเจ็กต์ OLE มีขนาดของมันเอง ตามที่ Microsoft ระบุ เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้แน่ใจว่ามันรักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของเฟรมออบเจ็กต์ OLE

## **วิธีแก้ที่ใช้งานได้**

มีสองวิธีแก้ที่เป็นไปได้เพื่อหลีกเลี่ยงผลกระทบของการปรับขนาด

- ปรับสเกลขนาดเฟรม OLE ในการนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในเฟรม OLE
- คงขนาดเฟรม OLE ไว้คงที่และปรับสเกลขนาดของแถวและคอลัมน์ที่เข้าร่วมให้พอดีกับขนาดเฟรม OLE ที่เลือก

### **ปรับสเกลขนาดเฟรม OLE**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดเฟรม OLE ของเวิร์กบุ๊ก Excel ที่ฝังไว้ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เข้าร่วมในเวิร์กชีต

สมมติว่าเรามีเทมเพลตเวิร์กชีต Excel และต้องการเพิ่มลงในการนำเสนอเป็นเฟรม OLE ในสถานการณ์นี้ ขนาดของเฟรมออบเจ็กต์ OLE จะถูกคำนวณเป็นครั้งแรกโดยอิงจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่เข้าร่วมในเวิร์กบุ๊ก จากนั้นเราจะตั้งค่าขนาดของเฟรม OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" สำหรับเฟรม OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งค่าเป็นภาพของเฟรม OLE

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นออบเจ็กต์ OLE ใน PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE ในหน่วยจุด.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// เพิ่มภาพ OLE ลงในทรัพยากรของการนำเสนอ.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// สร้างเฟรมออบเจ็กต์ OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **ปรับสเกลขนาดช่วงเซลล์**

ในแนวทางนี้ เราจะเรียนรู้วิธีปรับสเกลความสูงของแถวที่เข้าร่วมและความกว้างของคอลัมน์ที่เข้าร่วมให้ตรงกับขนาดเฟรม OLE ที่กำหนดเอง

สมมติว่าเรามีเทมเพลตเวิร์กชีต Excel และต้องการเพิ่มลงในการนำเสนอเป็นเฟรม OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของเฟรม OLE และปรับสเกลขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่เฟรม OLE จากนั้นเราจะบันทึกเวิร์กบุ๊กเป็นสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาเรย์ไบต์เพื่อเพิ่มลงในเฟรม OLE เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" สำหรับเฟรม OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งค่าเป็นภาพของเฟรม OLE

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นออบเจ็กต์ OLE ใน PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดเฟรม.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// เพิ่มภาพ OLE ลงในทรัพยากรของการนำเสนอ.
var oleImage = presentation.Images.AddImage(imageStream);

// สร้างเฟรมออบเจ็กต์ OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยจุด.</param>
/// <param name="height">ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยจุด.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **สรุป**

{{% alert color="primary" %}}

มีสองวิธีในการแก้ไขปัญหาการปรับขนาดเวิร์กชีต การเลือกวิธีที่เหมาะสมขึ้นอยู่กับความต้องการเฉพาะและกรณีการใช้งาน ทั้งสองวิธีทำงานแบบเดียวกันไม่ว่าการนำเสนอจะสร้างจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีข้อจำกัดเรื่องขนาดของเฟรมออบเจ็กต์ OLE ในวิธีแก้นี้

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมเวิร์กชีต Excel ที่ฝังไว้ถึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**  
เกิดจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่เฟรมออบเจ็กต์ OLE ใน PowerPoint มีมิติของมันเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?**  
ได้โดยการปรับสเกลเฟรม OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือปรับสเกลช่วงเซลล์ให้พอดีกับขนาดเฟรม OLE ที่ต้องการ สามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีการสเกลแบบใด ระหว่างการสเกลเฟรม OLE หรือการสเกลช่วงเซลล์?**  
เลือก **การสเกลเฟรม OLE** หากต้องการคงขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **การสเกลช่วงเซลล์** หากต้องการขนาดคงที่สำหรับเฟรม OLE ในการนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากการนำเสนอของฉันสร้างจากเทมเพลต?**  
ทำงานได้ ทั้งสองวิธีทำงานกับการนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของเฟรม OLE หรือไม่เมื่อใช้วิธีเหล่านี้?**  
ไม่มี คุณสามารถกำหนดขนาดของเฟรมออบเจ็กต์ OLE ได้ตามต้องการตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความตัวอย่าง "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**  
ได้ โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพแทนที่ของเฟรม OLE คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนข้อความตัวอย่างเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังลงในการนำเสนอเป็นออบเจ็กต์ OLE](/slides/th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดตออบเจ็กต์ OLE อัตโนมัติโดยใช้ Add‑In ของ MS PowerPoint](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)