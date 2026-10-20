---
title: วิธีแก้ไขที่ทำงานได้สำหรับการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 60
url: /th/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- อ็อบเจกต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แก้ปัญหาการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังไว้ด้วย Aspose.Slides สำหรับ .NET ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดแผนภูมิและกรอบ OLE สอดคล้องกัน"
---
## **พื้นหลัง**

แผนภูมิ Excel ที่ฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ PowerPoint โดยใช้ส่วนประกอบของ Aspose อาจเปลี่ยนขนาดหลังจากการเปิดใช้งานครั้งแรก สิ่งนี้อาจทำให้เกิดความแตกต่างที่เห็นได้ชัดในลักษณะของแผนภูมิก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายเหตุผลที่เกิดการปรับขนาดและแสดงวิธีป้องกันโดยการจับคู่มิติแผนภูมิที่คงที่กับกรอบ OLE

ใน [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ](/slides/th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) เราอธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for .NET และฝังมันในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET เพื่อแก้ปัญหา [ปัญหาการแสดงตัวอย่างอ็อบเจกต์](/slides/th/net/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพแผนภูมิให้กับกรอบอ็อบเจกต์ OLE ของแผนภูมิ ในงานนำเสนอที่สร้างออกมา เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจกต์ OLE ที่แสดงรูปภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขสมุดงาน Excel ที่ฝังอยู่แล้วกลับไปยังสไลด์โดยคลิกที่นอกสมุดงานที่เปิดอยู่ ขนาดของกรอบอ็อบเจกต์ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปที่สไลด์ และอัตราการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดเดิมของกรอบ OLE และสมุดงาน Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

สมุดงาน Excel ที่ฝังอยู่มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามเก็บไว้เมื่ออ็อบเจกต์ถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีขนาดที่กำหนดโดยอิสระ เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดของอ็อบเจกต์เพื่อรักษาส่วนสัดส่วนของมันเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างสมุดงานและกรอบ OLE จึงอาจทำให้เกิดการปรับขนาดของอ็อบเจกต์ได้

## **วิธีแก้ไขที่ทำงานได้**

จับคู่ขนาดแผนภูมิกับกรอบ OLE บนสไลด์และทำให้มิติแผนภูมิอิสระจากหน้าต่างสมุดงาน วิธีแก้ไขนี้ทำงานได้ทั้งกับงานนำเสนอใหม่และเทมเพลตที่มีอยู่

ตัวอย่างนี้ต้องการ Aspose.Cells for .NET และ Aspose.Slides for .NET มันสร้างแผนภูมิคอลัมน์ง่ายบนแผ่นแผนภูมิที่ใช้งานอยู่และฝังสมุดงานในรูปแบบ XLS ไม่ได้กำหนดรูปภาพแผนภูมิก่อนหน้า; แผนภูมิจะปรากฏเมื่ออ็อบเจกต์ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างสร้างงานนำเสนอใหม่พร้อมกรอบ OLE ขนาด 9.5 × 4 นิ้วที่ตั้งตำแหน่งห่างจากขอบซ้าย 0.5 นิ้วและจากด้านบน 1 นิ้ว พิกัดและขนาดของสไลด์เป็นหน่วย point (72 point ต่อนิ้ว) สำหรับงานนำเสนอที่มีอยู่ ดูที่ [ใช้เทมเพลต](#use-a-template)

## **ตั้งค่าขนาดแผนภูมิคงที่**

ตั้งค่า [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) เป็น false เพื่อให้มิติแผนภูมิไม่ขึ้นกับหน้าต่าง workbook ตั้งค่า [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) ผ่าน [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) และ [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) โดยแปลงค่าจุดเป็นพิกเซลโดยใช้ 96 พิกเซลต่ออินช์: กรอบขนาด 684 × 288 จุดตรงกับแผนภูมิขนาด 912 × 384 พิกเซล ตั้งค่า [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) เป็นค่า Custom ของ [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) ตัวอย่างฝัง workbook ด้วย [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) และบันทึกงานนำเสนอที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// พิกัดและขนาดของสไลด์เป็นหน่วย point (72 จุดต่อนิ้ว).
var width = 684f; // 9.5 นิ้วน.
var height = 288f; // 4 นิ้วน.

chart.SizeWithWindow = false;
// แปลงหน่วย point เป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อนิ้ว.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **ใช้เทมเพลต**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่ เพื่อปรับตัวอย่าง:

1. โหลดงานนำเสนอเทมเพลตแทนการสร้างงานนำเสนอเปล่า
1. ตรวจสอบว่าหน้าสไลด์แรกมีอย่างน้อยสามรูปทรง แล้วใช้รูปทรงที่ตำแหน่ง index 2 เป็นตำแหน่งที่ใส่ข้อมูลชั่วคราว
1. นำความกว้างและความสูงของกรอบจากรูปทรงนั้นแทนการใช้ค่าคงที่ 684 และ 288 รักษาการคำนวณขนาดไว้ไม่เปลี่ยน
1. เพิ่มกรอบ OLE ณ ตำแหน่งของตำแหน่งที่ใส่ข้อมูลชั่วคราวแทนการใช้พิกัดคงที่ 36 และ 72
1. ลบตำแหน่งที่ใส่ข้อมูลชั่วคราวก่อนบันทึกงานนำเสนอ

## **คำถามที่พบบ่อย**

**ทำไมแผนภูมิ Excel ที่ฝังอยู่ของฉันจึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

สิ่งนี้เกิดขึ้นเนื่องจาก Excel พยายามคืนขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบอ็อบเจกต์ OLE ใน PowerPoint มีมิติของตนเอง PowerPoint และ Excel ทำการเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**ฉันจะทำให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกันได้อย่างไร?**

กำหนดขนาดแผนภูมิคงที่ที่ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิแบบกำหนดเองก่อนการฝัง workbook ตัวอย่างด้านบนแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การจับขนาดหน้าต่าง workbook เพียงอย่างเดียวพอหรือไม่?**

การจับขนาดหน้าต่าง workbook เพียงอย่างเดียวไม่สามารถป้องกันการเปลี่ยนขนาดของกรอบ OLE หลังจากการเปิดใช้งานได้อย่างมั่นใจ ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้ไขนี้ทำงานได้กับงานนำเสนอที่ใช้เทมเพลตและงานนำเสนอใหม่หรือไม่?**

ใช่ สำหรับเทมเพลต ให้ใช้ขนาดและตำแหน่งของตำแหน่งที่ใส่ข้อมูลชั่วคราว สำหรับงานนำเสนอใหม่ ให้ระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างใช้ workbook ของ Excel ที่สร้างด้วย Aspose.Cells ไม่ได้แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ](/slides/th/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [อัปเดตอ็อบเจกต์ OLE อัตโนมัติโดยใช้ PowerPoint Add-In](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)