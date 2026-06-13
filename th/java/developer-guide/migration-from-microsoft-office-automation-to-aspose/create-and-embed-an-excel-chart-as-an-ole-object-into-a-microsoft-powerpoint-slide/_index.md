---
title: สร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE โดยใช้ VSTO และ Aspose.Slides สำหรับ Java
linktitle: สร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE
type: docs
weight: 60
url: /th/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- สร้างแผนภูมิ
- ฝังแผนภูมิ Excel
- อ็อบเจ็กต์ OLE
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ Java และฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ลงในสไลด์ PowerPoint (PPT, PPTX) โดยใช้ Java."
---
{{% alert color="primary" %}} 

แผนภูมิเป็นการแสดงผลข้อมูลของคุณในรูปแบบภาพและเป็นที่นิยมใช้ในสไลด์การนำเสนอ บทความนี้จะแสดงโค้ดเพื่อสร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint โดยใช้ [VSTO](/slides/th/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) และ [Aspose.Slides for Java](/slides/th/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **การสร้างและฝังแผนภูมิ Excel**
ตัวอย่างโค้ดสองชุดด้านล่างมีความยาวและละเอียดเนื่องจากงานที่อธิบายมีความซับซ้อน คุณจะสร้าง Microsoft Excel workbook, สร้างแผนภูมิและจากนั้นสร้าง Microsoft PowerPoint presentation ที่คุณจะฝังแผนภูมิเข้าไป อ็อบเจ็กต์ OLE จะมีลิงก์ไปยังเอกสารต้นฉบับดังนั้นผู้ใช้ที่ดับเบิลคลิกไฟล์ที่ฝังไว้จะเปิดไฟล์และแอปพลิเคชันของมัน

### **VSTO Example**
โดยใช้ VSTO จะดำเนินการตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของอ็อบเจ็กต์ Microsoft Excel ApplicationClass
1. สร้าง workbook ใหม่ที่มีชีทหนึ่งชีท
1. เพิ่มแผนภูมิลงในชีท
1. บันทึก workbook
1. เปิด workbook Excel ที่มี worksheet ที่มีข้อมูลแผนภูมิ
1. ดึงคอลเลกชัน ChartObjects ของชีท
1. ดึงแผนภูมิที่ต้องการคัดลอก
1. สร้าง presentation Microsoft PowerPoint
1. เพิ่มสไลด์เปล่าลงใน presentation
1. คัดลอกแผนภูมิจาก worksheet ของ Excel ไปยังคลิปบอร์ด
1. วางแผนภูมิลงใน presentation ของ PowerPoint
1. กำหนดตำแหน่งแผนภูมิบนสไลด์
1. บันทึก presentation



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **ตัวอย่าง Aspose.Slides for Java**
โดยใช้ Aspose.Slides for .NET ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้าง workbook โดยใช้ Aspose.Cells for Java
1. สร้างแผนภูมิ Microsoft Excel
1. กำหนดขนาด OLE ของแผนภูมิ Excel
1. ดึงภาพของแผนภูมิ
1. ฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ภายใน presentation PPTX โดยใช้ Aspose.Slides for Java
1. แทนที่ภาพของอ็อบเจ็กต์ที่เปลี่ยนแปลงด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ปัญหาอ็อบเจ็กต์ที่เปลี่ยนแปลง
1. เขียน presentation ผลลัพธ์ลงดิสก์ในรูปแบบ PPTX



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}