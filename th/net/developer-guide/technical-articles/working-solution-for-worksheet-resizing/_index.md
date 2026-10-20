---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 40
url: /th/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- ปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: วิธีสองวิธีเพื่อทำให้กรอบอ็อบเจกต์คงที่—ปรับขนาดกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX"
---
{{% alert color="info" title="Note" %}}

แผ่นงาน Excel ที่ฝังเป็นอ็อบเจกต์ OLE ในการนำเสนอ PowerPoint โดยใช้คอมโพเนนต์ของ Aspose อาจเปลี่ยนขนาดโดยไม่คาดคิดหลังจากการเปิดใช้งานครั้งแรก การกระทำนี้ทำให้เกิดความแตกต่างทางภาพที่เห็นได้ระหว่างอ็อบเจกต์ OLE ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและอธิบายวิธีแก้สองวิธี

{{% /alert %}} 

## **พื้นฐาน**

ในบทความ [จัดการ OLE](/slides/th/net/manage-ole/) เราอธิบายวิธีการเพิ่มกรอบ OLE ลงในการนำเสนอ PowerPoint โดยใช้ Aspose.Slides for .NET เพื่อตอบสนองต่อ [ปัญหาการแสดงตัวอย่างอ็อบเจกต์](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบอ็อบเจกต์ OLE ในการนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจกต์ OLE ที่แสดงรูปภาพของแผ่นงาน แผ่นงาน Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใดๆ ที่ต้องการกับแผ่นงาน Excel จริงและจากนั้นกลับไปยังสไลด์โดยคลิกนอกแผ่นงาน Excel ที่เปิดใช้งาน ขนาดของกรอบอ็อบเจกต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบอ็อบเจกต์ OLE และแผ่นงาน Excel ที่ฝังอยู่

## **สาเหตุของการเปลี่ยนขนาด**

เนื่องจากแผ่นงาน Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมเมื่อเปิดใช้งานครั้งแรก ในทางกลับกัน กรอบอ็อบเจกต์ OLE มีขนาดของมันเอง ตามข้อมูลของ Microsoft เมื่อแผ่นงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาข้อกำหนดขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การเปลี่ยนขนาดเกิดขึ้นเนื่องจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบอ็อบเจกต์ OLE

## **วิธีแก้ไขที่ทำงาน**

มีวิธีแก้ไขสองวิธีที่สามารถหลีกเลี่ยงผลกระทบจากการเปลี่ยนขนาดได้

- ปรับขนาดกรอบ OLE ในการนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก
- คงขนาดกรอบ OLE ไว้คงที่และปรับขนาดแถวและคอลัมน์ที่เลือกให้พอดีกับกรอบนั้น

### **ปรับขนาดกรอบ OLE**

วิธีการนี้ตั้งค่าขนาดกรอบ OLE ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกในแผ่นงาน Excel ที่ฝังอยู่

ตัวอย่างนี้โหลดแผ่นงาน Excel ที่มีอยู่แล้วและเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) กำหนดช่วงที่จะแสดง ตัวอย่างภาพพรีวิวถูกเรนเดอร์ที่ 96 DPI และมิติโพิกเซลของมันจะถูกแปลงเป็นพอยท์โดยใช้ 72 พอยท์ต่อความนิ้ว [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) ฝังแผ่นงานที่แก้ไขในกรอบที่มีขนาดดังกล่าว ตัวอย่างพรีวิวถูกกำหนดผ่าน [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) เพื่อแทนที่ตัวแทนข้อความ "EMBEDDED OLE OBJECT" ในการนำเสนอที่บันทึก

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

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์ workbook ถูกใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE เป็นหน่วยพอยท์.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// เราต้องใช้ workbook ที่ปรับแก้แล้ว.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// เพิ่มภาพ OLE ลงในทรัพยากรของการนำเสนอ.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// สร้างกรอบอ็อบเจกต์ OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

ตัวช่วยพรีวิวตั้งค่าที่ [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) ให้เป็นช่วงที่เลือกและลบขอบเขต ส่วนหัวส่วนท้ายออก เมื่อเปิดใช้ [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) จะเรนเดอร์ช่วงเป็นภาพ PNG ตัวช่วยจะรีแวินด์สตรีมของภาพก่อนส่งกลับเพื่อใช้ในการนำเสนอ

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

### **ปรับขนาดช่วงเซลล์**

วิธีการนี้ปรับความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

ตัวอย่างนี้โหลดแผ่นงาน Excel ที่มีอยู่แล้วและเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) กำหนดช่วงที่จะแสดง และตัวช่วยด้านล่างจะปรับสัดส่วนของช่วงนั้นให้พอดีกับกรอบที่กว้าง 400 พอยท์ และสูง 100 พอยท์ หลังจากบันทึกแผ่นงานที่แก้ไขลงในสตรีมแล้ว [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) จะฝังมันในขนาดที่ระบุ ตัวอย่างพรีวิวที่เรนเดอร์ที่ 96 DPI จะถูกกำหนดผ่าน [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) ทำให้การนำเสนอที่บันทึกแสดงเซลล์ที่เลือกแทนตัวแทนข้อความเริ่มต้น

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

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์ workbook ถูกใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับขนาดช่วงเซลล์ให้พอดีกับขนาดกรอบ.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้ workbook ที่ปรับแก้แล้ว.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// เพิ่มภาพ OLE ลงในทรัพยากรของการนำเสนอ.
var oleImage = presentation.Images.AddImage(imageStream);

// สร้างกรอบอ็อบเจกต์ OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

ตัวช่วยการปรับขนาดคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก โดยคงอัตราส่วนความกว้างของคอลัมน์และความสูงของแถวไว้ จากนั้นจะแปลงมิติที่คำนวณได้จากพอยท์เป็นนิ้วก่อนนำไปใช้กับ [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) และ [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). ช่วงที่เลือกต้องมีความกว้างและความสูงที่ไม่เป็นศูนย์

```cs
/// <param name="width">ความกว้างที่คาดหวังของช่วงเซลล์เป็นหน่วยพอยท์.</param>
/// <param name="height">ความสูงที่คาดหวังของช่วงเซลล์เป็นหน่วยพอยท์.</param>
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

ตัวช่วยพรีวิวนี้เรนเดอร์ช่วงที่ปรับขนาดใหม่โดยใช้ [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). มันจำกัด [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) ไว้ที่ช่วงนั้น ลบขอบเขต ส่วนหัวส่วนท้ายออกและส่งคืนสตรีม PNG ที่ตำแหน่งเริ่มต้น

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

{{% alert color="info" title="Note" %}}

มีสองแนวทางเพื่อแก้ไขปัญหาการปรับขนาดแผ่นงาน เลือกแนวทางที่เหมาะกับความต้องการและกรณีการใช้งานของคุณ ทั้งสองแนวทางทำงานในลักษณะเดียวกัน ไม่ว่าจะเป็นการสร้างการนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบอ็อบเจกต์ OLE ในวิธีแก้นี้

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

นี่เกิดขึ้นเพราะ Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ส่วนกรอบอ็อบเจกต์ OLE ใน PowerPoint มีขนาดของตัวเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาดที่ไม่ต้องการ

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้ทั้งหมดหรือไม่?**

ได้เลย โดยการปรับขนาดกรอบ OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือปรับขนาดช่วงเซลล์ให้พอดีกับขนาดกรอบ OLE ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีการปรับขนาดใด OLE frame scaling หรือ cell range scaling?**

เลือก **OLE frame scaling** หากคุณต้องการรักษาขนาดแถวและคอลัมน์เดิมของ Excel เลือก **cell range scaling** หากคุณต้องการขนาดคงที่สำหรับกรอบ OLE ในการนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากการนำเสนอของฉันสร้างจากเทมเพลต?**

ใช่ ทั้งสองวิธีทำงานได้กับการนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**

ไม่ คุณสามารถตั้งขนาดกรอบอ็อบเจกต์ OLE ได้ตามต้องการตราบใดที่ตั้งสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความตัวแทน "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**

มี โดยการถ่ายสแนปช็อตของช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวแทนของกรอบ OLE คุณสามารถแสดงภาพพรีวิวที่กำหนดเองแทนตัวแทนค่าเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังเข้าในการนำเสนอเป็นอ็อบเจกต์ OLE](/slides/th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดตอ็อบเจกต์ OLE โดยอัตโนมัติด้วย MS PowerPoint Add-In](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)