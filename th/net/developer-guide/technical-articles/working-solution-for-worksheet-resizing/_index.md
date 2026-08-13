---
title: วิธีแก้ไขการปรับขนาดแผ่นงาน
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
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: สองวิธีเพื่อคงความสอดคล้องของกรอบวัตถุ—ปรับสเกลกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX."
---
{{% alert color="info" %}}

พบว่าชีตงาน Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนท์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่สังเกตได้ในงานนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้งานของวัตถุ OLE เราได้ทำการตรวจสอบปัญหานี้อย่างละเอียดและได้จัดหาแนวทางแก้ไข ซึ่งอธิบายไว้ในบทความนี้

{{% /alert %}}

## **Background**

ในบทความ [จัดการ OLE](/slides/th/net/manage-ole/) เราได้อธิบายวิธีการเพิ่มกรอบ OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อแก้ไขปัญหา [การแสดงตัวอย่างวัตถุ](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่ชีตงานที่เลือกให้กับกรอบวัตถุ OLE ในงานนำออกที่ได้ เมื่อคุณดับเบิลคลิกที่กรอบวัตถุ OLE ที่แสดงภาพชีต Excel จะทำการเปิดใช้งานเวิร์กบุ๊ก Excel ผู้ใช้สุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในเวิร์กบุ๊กจริง แล้วกลับไปที่สไลด์โดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปที่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบวัตถุ OLE และเวิร์กบุ๊ก Excel ที่ฝังไว้

## **Cause of Resizing**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้เมือเปิดใช้งานครั้งแรก ในทางกลับกันกรอบวัตถุ OLE มีขนาดของตนเอง ตามข้อมูลของ Microsoft เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะทำการต่อรองขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบวัตถุ OLE

## **Working Solution**

มีสองวิธีแก้ไขที่เป็นไปได้เพื่อลดผลกระทบจากการปรับขนาด

- ปรับขนาดกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดกรอบ OLE ไม่เปลี่ยนแปลงและปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมให้พอดีกับขนาดกรอบ OLE ที่เลือก

### **Scale the OLE Frame Size**

ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดกรอบ OLE ของเวิร์กบุ๊ก Excel ที่ฝังเพื่อให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เข้าร่วมในชีตงาน Excel

สมมติว่าเรามีชีตเทมเพลต Excel และต้องการเพิ่มลงในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ ขนาดของกรอบวัตถุ OLE จะถูกคำนวณเป็นขั้นแรกจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ของแถวและคอลัมน์ที่เข้าร่วมในเวิร์กบุ๊ก จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะทำการจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพของกรอบ OLE

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
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

// เพิ่มภาพ OLE ลงในทรัพยากรของงานนำเสนอ.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// สร้างกรอบวัตถุ OLE.
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

### **Scale the Cell Range Size**

ในวิธีนี้ เราจะเรียนรู้วิธีการปรับความสูงของแถวที่เข้าร่วมและความกว้างของคอลัมน์ที่เข้าร่วมให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

สมมติว่าเรามีชีตเทมเพลต Excel และต้องการเพิ่มลงในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของกรอบ OLE และปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่กรอบ OLE จากนั้นเราจะบันทึกเวิร์กบุ๊กลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาเรย์ไบต์เพื่อเพิ่มลงในกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะทำการจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพของกรอบ OLE

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// เพิ่มภาพ OLE ลงในทรัพยากรของงานนำเสนอ.
var oleImage = presentation.Images.AddImage(imageStream);

// สร้างกรอบวัตถุ OLE.
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

## **Conclusion**

{{% alert color="info" %}}

มีสองแนวทางในการแก้ไขปัญหาการปรับขนาดชีตงาน การเลือกแนวทางที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งานเฉพาะ ทั้งสองแนวทางทำงานในลักษณะเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์เริ่มต้น นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบวัตถุ OLE ในวิธีแก้ไขนี้

{{% /alert %}}

## **FAQ**

### ทำไมชีตงาน Excel ที่ฝังใน PowerPoint ถึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรก?
นี่เกิดขึ้นเนื่องจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่กรอบวัตถุ OLE ใน PowerPoint มีมิติของตนเอง PowerPoint และ Excel จะต่อรองขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

### สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?
ได้ การปรับขนาดกรอบ OLE ให้อยู่ในขนาดช่วงเซลล์ Excel หรือการปรับขนาดช่วงเซลล์ให้พอดกับขนาดกรอบ OLE ที่ต้องการ จะช่วยป้องกันการปรับขนาดที่ไม่พึงประสงค์

### ควรใช้วิธีการปรับขนาดใด OLE frame scaling หรือ cell range scaling?
เลือก **OLE frame scaling** หากต้องการคงขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **cell range scaling** หากต้องการขนาดคงที่สำหรับกรอบ OLE ในงานนำเสนอของคุณ

### วิธีแก้เหล่านี้จะทำงานได้หากงานนำเสนอของฉันอิงจากเทมเพลตหรือไม่?
ได้ ทั้งสองวิธีทำงานได้กับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์เริ่มต้น

### มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?
ไม่มี คุณสามารถกำหนดขนาดกรอบวัตถุ OLE ได้ตามต้องการตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

### มีวิธีหลีกเลี่ยงข้อความตัวแทน “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?
ได้ โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวแทนของกรอบ OLE คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนตัวแทนค่าเริ่มต้นได้

## **Related Articles**

[สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE](/slides/th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดตวัตถุ OLE อัตโนมัติด้วย Add-In ของ MS PowerPoint](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)