---
title: สร้างแผนภูมิโดยใช้ VSTO และ Aspose.Slides สำหรับ Java
linktitle: สร้างแผนภูมิ
type: docs
weight: 70
url: /th/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- สร้างแผนภูมิ
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการทำให้การสร้างแผนภูมิ PowerPoint ใน Java เป็นอัตโนมัติ คู่มือทีละขั้นตอนนี้แสดงเหตุผลที่ Aspose.Slides สำหรับ Java เป็นทางเลือกที่เร็วกว่และมีประสิทธิภาพมากกว่าของ Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

แผนภูมิคือการแสดงผลข้อมูลแบบภาพที่ถูกใช้กันอย่างแพร่หลายในงานนำเสนอ บทความนี้แสดงโค้ดสำหรับการสร้างแผนภูมิใน Microsoft PowerPoint อย่างอัตโนมัติโดยใช้ [VSTO](/slides/th/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) และ [Aspose.Slides for Java](/slides/th/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **สร้างแผนภูมิ**
โค้ดตัวอย่างด้านล่างอธิบายกระบวนการเพิ่มแผนภูมิคอลัมน์ 3D clustered column อย่างง่ายโดยใช้ VSTO คุณจะสร้างอินสแตนซ์ของการนำเสนอ, เพิ่มแผนภูมิดีฟอลต์ลงไป แล้วใช้ Microsoft Excel workbook เพื่อเข้าถึงและแก้ไขข้อมูลแผนภูมิพร้อมตั้งค่าคุณสมบัติของแผนภูมิ และในที่สุดบันทึกการนำเสนอ
### **ตัวอย่าง VSTO**
โดยใช้ VSTO จะทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของการนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์ว่างลงในงานนำเสนอ
1. เพิ่มแผนภูมิ **3D clustered column** และเข้าถึงมัน
1. สร้างอินสแตนซ์ใหม่ของ Microsoft Excel Workbook และโหลดข้อมูลแผนภูมิ
1. เข้าถึง Worksheet ข้อมูลแผนภูมิโดยใช้ Microsoft Excel Workbook instancefromworkbook
1. ตั้งช่วงข้อมูลของแผนภูมิใน Worksheet และลบ series 2 และ 3 ออกจากแผนภูมิ
1. แก้ไขข้อมูลหมวดหมู่ของแผนภูมิใน Worksheet ข้อมูลแผนภูมิ
1. แก้ไขข้อมูล series 1 ของแผนภูมิใน Worksheet ข้อมูลแผนภูมิ
1. ต่อไป, เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติเกี่ยวกับฟอนต์
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่า major unit, minor units, ค่าสูงสุดและค่าต่ำสุด
1. เข้าถึงแกนความลึกหรือแกน series แล้วลบออกตามตัวอย่างนี้, มีการใช้เพียง seriesเดียว
1. ต่อไป, ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y
1. บันทึกงานนำเสนอ
1. ปิดอินสแตนซ์ของ Microsoft Excel และ PowerPoint

**งานนำเสนอที่ได้, สร้างด้วย VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **ตัวอย่าง Aspose.Slides for Java**
โดยใช้ Aspose.Slides for Java จะทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของการนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์ว่างลงในงานนำเสนอ
1. เพิ่มแผนภูมิ **3D clustered column** และเข้าถึงมัน
1. เข้าถึง Worksheet ข้อมูลแผนภูมิโดยใช้ Microsoft Excel Workbook instancefromworkbook
1. ลบ series 2 และ 3 ที่ไม่ได้ใช้
1. เข้าถึงหมวดหมู่ของแผนภูมิและแก้ไขป้ายกำกับ
1. เข้าถึง series 1 และแก้ไขค่าของ series
1. ต่อไป, เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติของฟอนต์
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่า major unit, minor units, ค่าสูงสุดและค่าต่ำสุด
1. ต่อไป, ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y
1. บันทึกงานนำเสนอเป็นรูปแบบ PPTX

**งานนำเสนอที่ได้, สร้างด้วย Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **คำถามที่พบบ่อย**

### ฉันสามารถสร้างแผนภูมิประเภทอื่นเช่น พาย, เส้น, หรือแผนภูมิแท่งด้วย Aspose.Slides ได้หรือไม่?
ใช่ Aspose.Slides รองรับรูปแบบ [chart types](/slides/th/java/create-chart/) อย่างกว้างขวาง รวมถึงแผนภูมิพาย, แผนภูมิเส้น, แผนภูมิแท่ง, scatter plot, bubble chart และอื่น ๆ คุณสามารถระบุประเภทแผนภูมิที่ต้องการโดยใช้คลาส [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) เมื่อเพิ่มแผนภูมิ

### ฉันสามารถใช้สไตล์หรือธีมแบบกำหนดเองกับแผนภูมิได้หรือไม่?
ใช่ คุณสามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้อย่างเต็มที่ รวมถึงสี, ฟอนต์, การเติม, เส้นขอบ, เส้นกริด และการจัดวาง อย่างไรก็ตามการใช้ธีม Office เฉพาะอย่างเหมือนใน PowerPoint จำเป็นต้องตั้งค่าสไตล์แต่ละส่วนด้วยตนเอง

### ฉันสามารถส่งออกแผนภูมิเป็นภาพแยกจากสไลด์ได้หรือไม่?
ใช่ Aspose.Slides อนุญาตให้คุณส่งออกรูปทรงใด ๆ รวมถึงแผนภูมิ เป็นภาพแยก (เช่น PNG, JPEG) โดยใช้เมธอด `getImage` บน [shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/) ของแผนภูมิ