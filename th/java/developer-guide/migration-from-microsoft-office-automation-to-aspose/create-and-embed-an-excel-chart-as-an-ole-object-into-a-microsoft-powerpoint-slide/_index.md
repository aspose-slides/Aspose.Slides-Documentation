---
title: สร้างและฝังแผนภูมิ Excel เป็นวัตถุ OLE ด้วย VSTO และ Aspose.Slides สำหรับ Java
linktitle: สร้างและฝังแผนภูมิ Excel เป็นวัตถุ OLE
type: docs
weight: 60
url: /th/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- สร้างแผนภูมิ
- ฝังแผนภูมิ Excel
- วัตถุ OLE
- การย้ายข้อมูล
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ Java และฝังแผนภูมิ Excel เป็นวัตถุ OLE ในสไลด์ PowerPoint (PPT, PPTX) ด้วย Java."
---
{{% alert color="info" %}} 

แผนภูมิคือการแสดงผลข้อมูลของคุณในรูปแบบภาพและถูกใช้กันอย่างกว้างขวางในสไลด์การนำเสนอ บทความนี้จะแสดงโค้ดเพื่อสร้างและฝังแผนภูมิ Excel เป็นวัตถุ OLE ในสไลด์ PowerPoint อย่างโปรแกรมโดยใช้ [VSTO](/slides/th/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) และ [Aspose.Slides for Java](/slides/th/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **การสร้างและฝังแผนภูมิ Excel**
ตัวอย่างโค้ดสองชุดด้านล่างยาวและละเอียดเพราะงานที่อธิบายมีความซับซ้อน คุณจะสร้างเวิร์กบุ๊ก Microsoft Excel, สร้างแผนภูมิ และจากนั้นสร้างงานนำเสนอ Microsoft PowerPoint ที่จะฝังแผนภูมิเข้าไป วัตถุ OLE จะมีลิงก์ไปยังเอกสารต้นฉบับ ดังนั้นผู้ใช้ที่สองคลิกไฟล์ที่ฝังไว้จะเปิดไฟล์และแอปพลิเคชันของมัน

### **ตัวอย่าง VSTO**
ใช้ VSTO จะทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของวัตถุ Microsoft Excel ApplicationClass
1. สร้างเวิร์กบุ๊กใหม่ที่มีแผ่นเดียว
1. เพิ่มแผนภูมิบนแผ่นงาน
1. บันทึกเวิร์กบุ๊ก
1. เปิดเวิร์กบุ๊ก Excel ที่มีแผ่นงานพร้อมข้อมูลแผนภูมิ
1. ดึงคอลเลกชัน ChartObjects ของแผ่นงาน
1. ดึงแผนภูมิที่จะคัดลอก
1. สร้างงานนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์เปล่าลงในงานนำเสนอ
1. คัดลอกแผนภูมิจากแผ่นงาน Excel ไปยังคลิปบอร์ด
1. วางแผนภูมิเข้าในงานนำเสนอ PowerPoint
1. กำหนดตำแหน่งแผนภูมิบนสไลด์
1. บันทึกงานนำเสนอ

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **ตัวอย่าง Aspose.Slides for Java**
ใช้ Aspose.Slides for .NET จะทำตามขั้นตอนต่อไปนี้:

1. สร้างเวิร์กบุ๊กโดยใช้ Aspose.Cells for Java
1. สร้างแผนภูมิ Microsoft Excel
1. ตั้งค่าขนาด OLE ของแผนภูมิ Excel
1. ดึงภาพของแผนภูมิ
1. ฝังแผนภูมิ Excel เป็นวัตถุ OLE ภายในงานนำเสนอ PPTX โดยใช้ Aspose.Slides for Java
1. แทนที่ภาพวัตถุที่เปลี่ยนแปลงด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ปัญหาวัตถุเปลี่ยนแปลง
1. เขียนงานนำเสนอผลลัพธ์ลงดิสก์ในรูปแบบ PPTX

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}