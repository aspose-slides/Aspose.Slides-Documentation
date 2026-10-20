---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นอ็อบเจกต์ OLE
type: docs
weight: 50
url: /th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- อ็อบเจกต์ OLE
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells for .NET และฝังเวิร์กบุ๊กลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides พร้อมภาพตัวอย่างของแผนภูมิ."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างแผนภูมิคอลัมน์ Excel ด้วย Aspose.Cells for .NET และฝังเวิร์กบุ๊กของมันลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET เวิร์กบุ๊กที่ฝังมานี้ประกอบด้วยข้อมูลต้นฉบับและแผนภูมิด้วย ภาพตัวอย่าง PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่อ็อบเจกต์ OLE จะถูกเปิดใช้งาน. ผลลัพธ์คืออ็อบเจกต์ Excel ที่ฝังอยู่ ไม่ใช่แผนภูมิ PowerPoint แบบดั้งเดิม การแก้ไขเวิร์กบุ๊กผ่าน OLE จำเป็นต้องใช้แอปพลิเคชันบนเดสก์ทอปที่รองรับการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้.

## **ข้อกำหนดเบื้องต้น**

เพิ่มการอ้างอิงไปยัง Aspose.Cells for .NET และ Aspose.Slides for .NET ในโปรเจกต์ C# ของคุณ ตัวอย่างนี้ใช้ top-level statements และต้องการ C# 9 หรือใหม่กว่า ไม่จำเป็นต้องติดตั้ง Microsoft Office เพื่อสร้างงานนำเสนอด้วยไลบรารีเหล่านี้. ไม่จำเป็นต้องมีไฟล์อินพุตใด ๆ: ตัวอย่างสร้างข้อมูลและแผนภูมิในหน่วยความจำ แล้วเขียนไฟล์ `OutputChart.pptx` ไปยังไดเรกทรีทำงานปัจจุบัน ให้ใส่ล licenses สำหรับผลิตภัณฑ์ทั้งสองเมื่อรันนอกโหมดประเมินผล.

## **วิธีการทำงานของการฝัง**

1. สร้างเวิร์กบุ๊กที่มีแผ่นงานข้อมูลและแผ่นงานแผนภูมิ.
2. ทำให้แผ่นงานแผนภูมิกำลังใช้งานเพื่อให้เวิร์กบุ๊กเปิดที่แผนภูมิ.
3. กำหนดช่วงการแสดงผล OLE ของเวิร์กบุ๊กและเรนเดอร์แผนภูมิเป็น PNG.
4. บันทึกเวิร์กบุ๊กเป็น XLSX ในหน่วยความจำและฝังไบต์เหล่านั้นลงในสไลด์.
5. กำหนด PNG เป็นภาพตัวอย่างของอ็อบเจกต์ OLE แล้วบันทึกงานนำเสนอเป็น PPTX.

ช่วงการแสดงผลของเวิร์กบุ๊กและกรอบบนสไลด์มีบทบาทที่แตกต่างกัน [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) ใช้ดัชนีแถวและคอลัมน์เริ่ม/สิ้นสุดแบบศูนย์ฐาน. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) แทนที่จะใช้จะรับแถวบน, คอลัมน์ซ้าย, แถวล่าง, และคอลัมน์ขวา. ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบเขตด้านขวาล่าง; ค่าดังกล่าวเป็นการเลือกการจัดวาง ไม่ใช่จำนวนแถวหรือคอลัมน์ของข้อมูล. กรอบสไลด์ใช้หน่วยจุด ตัวอย่างทำให้พอดีกับสไลด์และจัดกึ่งกลางโดยคงอัตราส่วนของ PNG ไว้ แทนการยืดภาพตัวอย่างให้เต็มสไลด์.

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มต่อไปนี้จะเติมค่าใน `DataSheet` ด้วยแถวสี่แถวและคอลัมน์ห้าคอลัมน์ แต่ละแถวจะเป็นซีรีส์ของแผนภูมิ `ChartSheet` ถูกเลือกเป็นแผ่นงานที่ใช้งานก่อนที่เวิร์กบุ๊กจะถูกบันทึก. เวิร์กบุ๊กถูกบันทึกเป็น XLSX อย่างชัดเจน โดยสอดคล้องกับส่วนขยาย `xlsx` ที่ส่งให้กับ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG จะถูกโหลดโดยตรงจากสตรีมโดยไม่ต้องแปลงเป็นบิตแมพกลาง การกำหนดผ่าน [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) จะเปลี่ยนตำแหน่งเก็บข้อมูล OLE เริ่มต้น.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// เรนเดอร์ภาพตัวอย่างของแผนภูมิและทำการบันทึกเวิร์กบุ๊กที่แก้ไขได้แยกส่วน.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีหนึ่งสไลด์ที่ฝังเวิร์กบุ๊ก Excel และภาพตัวอย่างของแผนภูมิ เวิร์กบุ๊กมีข้อมูลต้นฉบับและแผนภูมิคอลัมน์ที่มีสี่ซีรีส์ ภาพตัวอย่างถูกจัดกึ่งกลางบนสไลด์และคงอัตราส่วนไว้.

![แผนภูมิคอลัมน์ Excel แสดงเป็นภาพตัวอย่างของเวิร์กบุ๊กที่ฝังอยู่](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่รองรับและมี Excel อยู่ให้ใช้ได้ ให้คลิกสองครั้งที่อ็อบเจกต์เพื่อเปิดใช้งานและแก้ไขเวิร์กบุ๊กที่ฝัง การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย.

## **คำถามที่พบบ่อย**

**ทำไมต้องมีภาพตัวอย่าง?**  
เวิร์กบุ๊กที่ฝังและภาพตัวอย่างบนสไลด์เป็นเนื้อหาแยกกัน ให้จัดเตรียมภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนตำแหน่งที่กำหนดค่าเริ่มต้นของ "EMBEDDED OLE OBJECT" ดูที่ [Object Preview Issue when Adding OleObjectFrame](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/).

**ภาพตัวอย่างอัปเดตอัตโนมัติเมื่อฉันเปลี่ยนเวิร์กบุ๊กในโค้ดหรือไม่?**  
ถือว่าภาพตัวอย่างเป็นสแนปชอต เมื่ออัปเดตข้อมูลเวิร์กบุ๊กโดยโปรแกรม ให้สร้างภาพแผนภูมิใหม่และเปลี่ยนภาพตัวอย่างพร้อมกับข้อมูลเวิร์กบุ๊กที่ฝัง.

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**  
ได้. บันทึกเวิร์กบุ๊กในรูปแบบ XLS และใช้ `xls` เป็นส่วนขยายของข้อมูลที่ฝัง ส่วนขยายต้องตรงกับรูปแบบเวิร์กบุ๊กจริง; การเปลี่ยนส่วนขยายอย่างเดียวไม่ทำให้ข้อมูลแปลงรูปแบบ.

**ทำไมอ็อบเจกต์ถึงอาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**  
แอปพลิเคชันโฮสต์สามารถอัปเดตการแสดงผลของอ็อบเจกต์ OLE เมื่อเปิดใช้งานเวิร์กบุ๊ก ช่วงการแสดงผล OLE ของเวิร์กบุ๊กและมิติของกรอบสไลด์มีความสำคัญทั้งสอง ดูที่ [Working Solution for Chart Resizing in PPTX](/slides/th/net/working-solution-for-chart-resizing-in-pptx/).

## **ส่วนที่เกี่ยวข้อง**

- [โซลูชันที่ทำงานได้สำหรับการปรับขนาดแผนภูมิใน PPTX](/slides/th/net/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาภาพตัวอย่างอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/)
- [อัปเดตอ็อบเจกต์ OLE อัตโนมัติด้วยส่วนเสริม PowerPoint](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)