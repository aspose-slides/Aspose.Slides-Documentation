---
title: ลิงก์แผนภูมิไปยังเวิร์กบุ๊กภายนอก
description: ลิงก์ข้อมูลแผนภูมิกับเวิร์กบุ๊กภายนอกและรีเฟรชมัน
type: docs
url: /th/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **ภาพรวม**

ชี้แผนภูมิไปยังเวิร์กบุ๊กภายนอกแทนการเก็บข้อมูลต้นฉบับทั้งหมดในงานนำเสนอ คุณสามารถตั้งค่าเส้นทางของเวิร์กบุ๊กและเลือกว่าจะอัปเดตแผนภูมิจากไฟล์นั้นหรือไม่ แผนภูมิที่บันทึกไว้ยังสามารถบรรจุข้อมูลแคชที่แสดงได้ด้วย

## **ตัวอย่างการใช้งาน**

ตัวอย่าง C# นี้ใช้ Aspose.Slides for .NET สร้างเวิร์กบุ๊กการขายที่ถูกต้องโดยกำหนด North = 55 และ South = 40 แล้วบันทึกเป็น sales.xlsx ข้างไฟล์ผลลัพธ์ รีเซ็ตค่าของ North ในแผนภูมิเป็น 20 จากนั้นเชื่อมแผนภูมิไปยังเส้นทางเต็มของเวิร์กบุ๊กและรีเฟรช: North จะกลับเป็น 55 อีกครั้ง ช่วงที่ระบุอย่างชัดเจนครอบคลุมแถวหัวตารางและสองแถวข้อมูล ควรรักษาไฟล์ sales.xlsx ให้พร้อมใช้งานเมื่อเปิดใหม่หรืออัปเดตแผนภูมิที่เชื่อมโยง; งานนำเสนอจะไม่ฝังไฟล์ภายนอกนี้ ไม่จำเป็นต้องมีไฟล์อินพุต โปรแกรมจะบันทึก *external-chart-workbook.pptx* และ *external-chart-workbook.png* ติดตั้งไลบรารีโดยใช้ [คู่มือการติดตั้ง](/slides/th/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **คำถามที่พบบ่อย**

### **ฉันสามารถอ่านค่าที่แคชทั้งหมดเมื่อไฟล์ที่เชื่อมโยงหายไปได้หรือไม่?**

Aspose.Slides for .NET 26.11 สามารถ [อ่านค่าที่แคชของแผนภูมิโดยตรง](/slides/th/net/chart-workbook/#read-cached-chart-values-without-a-workbook) โดยไม่ต้องเปิดเวิร์กบุ๊กที่เชื่อมโยง ซึ่งรวมถึงค่าปกติ, ค่า X/Y, ขนาดบับเบิลและค่าประเภทเมื่อมีแคชเหล่านั้น แคชข้อมูลอาจไม่มีหรือล้าสมัย; มันไม่ใช่เวิร์กบุ๊กเต็ม การรีเฟรชจากแหล่งข้อมูลยังคงต้องมีเวิร์กบุ๊กที่สนับสนุนและพร้อมใช้ สำหรับ SDK และเวอร์ชันอื่น ๆ โปรดตรวจสอบคู่มือแผนภูมิที่สอดคล้องกัน

### **จะเกิดอะไรขึ้นหากเวิร์กบุ๊กภายนอกถูกย้าย?**

อัปเดตเส้นทางของเวิร์กบุ๊กภายนอกของแผนภูมิให้เป็นตำแหน่งใหม่ของมัน และทำให้ไฟล์นั้นพร้อมใช้งานทุกที่ที่มีการประมวลผลงานนำเสนอ อย่าพึ่งพาข้อมูลแคชสำหรับการเข้าถึงข้อมูลเต็มเมื่อตัวแคชหายไป

### **ฉันสามารถเลือกว่าจะรีเฟรชข้อมูลแคชของแผนภูมิเมื่อทำการเชื่อมโยงหรือไม่?**

ได้เลย คุณสามารถเลือกว่าจะอัปเดตข้อมูลแผนภูมิเมื่อกำหนดลิงก์หรือไม่ การรีเฟรชต้องมีเวิร์กบุ๊กที่สนับสนุนและพร้อมใช้งาน; การข้ามการรีเฟรชจะบันทึกลิงก์โดยไม่อ่านค่าที่ใหม่จากไฟล์นั้น

## **คู่มือ**

- [จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอด้วย .NET](/slides/th/net/chart-workbook/)

ฟีเจอร์ที่เกี่ยวข้อง: [เติมแผนภูมิที่แก้ไขได้ด้วยข้อมูล](/slides/th/features/chart-data-binding/).