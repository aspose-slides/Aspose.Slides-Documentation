---
title: "สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นอ็อบเจ็กต์ OLE"
type: docs
weight: 50
url: /th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- "แผนภูมิ Excel"
- "ฝังแผนภูมิ"
- "อ็อบเจ็กต์ OLE"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย C#/.NET คู่มือขั้นตอนอย่างละเอียดพร้อมตัวอย่างโค้ด"
---
## **พื้นหลัง**

ใน PowerPoint การใช้แผนภูมิที่แก้ไขได้เพื่อแสดงข้อมูลเป็นกราฟิกเป็นการปฏิบัติที่พบบ่อย Aspose รองรับการสร้างแผนภูมิ Excel ด้วย Aspose.Cells สำหรับ .NET และแผนภูมิเหล่านี้สามารถฝังเป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint ผ่าน Aspose.Slides สำหรับ .NET บทความนี้ครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ด C# สำหรับการสร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ PowerPoint ด้วย Aspose.Cells และ Aspose.Slides.

## **ขั้นตอนที่ต้องทำ**

ลำดับขั้นตอนต่อไปนี้จำเป็นต้องทำเพื่อสร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint:

1. สร้างแผนภูมิ Excel ด้วย Aspose.Cells.
2. ตั้งค่าขนาด OLE ของแผนภูมิ Excel ด้วย Aspose.Cells.
3. ดึงรูปภาพของแผนภูมิ Excel ด้วย Aspose.Cells.
4. ฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ PPTX ด้วย Aspose.Slides.
5. แทนที่รูปภาพ "EMBEDDED OLE OBJECT" ด้วยรูปภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา [object preview issue](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/).
6. บันทึกงานนำเสนอลงดิสก์ในรูปแบบ PPTX.

## **การดำเนินการของขั้นตอนที่ต้องทำ**

การทำงานด้วย C# ของขั้นตอนด้านบนมีดังต่อไปนี้:

```cs
// ขั้นตอนที่ 1: สร้างแผนภูมิ Excel โดยใช้ Aspose.Cells.
// ---------------------------------------------------
// Create a workbook.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// ขั้นตอนที่ 2: ตั้งค่าขนาด OLE ของแผนภูมิโดยใช้ Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// ขั้นตอนที่ 3: ดึงรูปภาพของแผนภูมิด้วย Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Save the workbook to a stream.
MemoryStream workbookStream = workbook.SaveToStream();

// ขั้นตอนที่ 4 และ 5
// ==============
// ขั้นตอนที่ 4: ฝังแผนภูมิเป็นอ็อบเจ็กต์ OLE ภายในงานนำเสนอ .ppt โดยใช้ Aspose.Slides.
// ------------------------------------------------------------------------------------------
// ขั้นตอนที่ 5: แทนที่รูปภาพ "EMBEDDED OLE OBJECT" ด้วยรูปภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา Object Preview Issue.
// --------------------------------------------------------------------------------------------------------------------
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Add the workbook to the slide.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // ขั้นตอนที่ 6: บันทึกงานนำเสนอผลลัพธ์ลงดิสก์.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // อาเรย์ของชื่อเซลล์.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // อาเรย์ของข้อมูลเซลล์.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // เพิ่มเวิร์กชีตใหม่เพื่อเติมข้อมูลในเซลล์.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // เติมข้อมูลลงในแผ่นข้อมูล.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // เพิ่มแผ่นแผนภูมิ.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // เพิ่มแผนภูมิลงในแผ่นแผนภูมิโดยใช้ชุดข้อมูลจากแผ่นข้อมูล.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // กำหนดแผ่นแผนภูมิให้เป็นแผ่นทำงานที่ใช้งาน.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

งานนำเสนอที่สร้างโดยวิธีข้างต้นจะมีแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ซึ่งสามารถเปิดใช้งานได้โดยการคลิกสองครั้งที่เฟรมอ็อบเจ็กต์ OLE.

## **สรุป**

โดยการใช้ Aspose.Cells สำหรับ .NET ร่วมกับ Aspose.Slides สำหรับ .NET เราสามารถสร้างแผนภูมิ Excel ใด ๆ ที่รองรับโดย Aspose.Cells และฝังแผนภูมิเป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint ได้ ขนาด OLE ของแผนภูมิ Excel ยังสามารถกำหนดได้ ผู้ใช้ปลายทางจึงสามารถแก้ไขแผนภูมิ Excel เหมือนกับอ็อบเจ็กต์ OLE อื่น ๆ.

## **ส่วนที่เกี่ยวข้อง**

- [วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/net/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์เมื่อเพิ่ม OleObjectFrame](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/)
- [อัพเดตอ็อบเจ็กต์ OLE อัตโนมัติด้วยแอดอิน PowerPoint](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)