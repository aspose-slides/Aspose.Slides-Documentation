---
title: สร้างแผนภูมิด้วย VSTO และ Aspose.Slides สำหรับ Java
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
description: "เรียนรู้วิธีการทำอัตโนมัติการสร้างแผนภูมิ PowerPoint ใน Java คำแนะนำขั้นตอนนี้แสดงให้เห็นว่า Aspose.Slides สำหรับ Java เป็นทางเลือกที่เร็วกว่าและมีประสิทธิภาพมากกว่า Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

แผนภูมิเป็นการแสดงข้อมูลด้วยภาพที่ใช้กันอย่างแพร่หลายในงานนำเสนอ บทความนี้แสดงโค้ดสำหรับสร้างแผนภูมิใน Microsoft PowerPoint อย่างโปรแกรมโดยใช้ [VSTO](/slides/th/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) และ [Aspose.Slides for Java](/slides/th/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **สร้างแผนภูมิ**
ตัวอย่างโค้ดด้านล่างอธิบายกระบวนการเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบกลุ่มแบบง่ายโดยใช้ VSTO คุณจะสร้างอินสแตนซ์ของงานนำเสนอ เพิ่มแผนภูมิดีฟอลต์ลงในนั้น จากนั้นใช้ Microsoft Excel Workbook เพื่อเข้าถึงและแก้ไขข้อมูลแผนภูมิพร้อมตั้งค่าคุณสมบัติของแผนภูมิ สุดท้ายบันทึกงานนำเสนอ
### **ตัวอย่าง VSTO**
โดยใช้ VSTO จะดำเนินการตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของงานนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์เปล่าไปยังงานนำเสนอ
1. เพิ่มแผนภูมิ **3D clustered column** และเข้าถึงมัน
1. สร้างอินสแตนซ์ใหม่ของ Microsoft Excel Workbook และโหลดข้อมูลแผนภูมิ
1. เข้าถึงเวิร์กชีตข้อมูลแผนภูมิโดยใช้ Microsoft Excel Workbook instancefromworkbook
1. ตั้งค่าช่วงข้อมูลแผนภูมิในเวิร์กชีตและลบซีรีส์ 2 และ 3 ออกจากแผนภูมิ
1. แก้ไขข้อมูลหมวดหมู่ของแผนภูมิในเวิร์กชีตข้อมูลแผนภูมิ
1. แก้ไขข้อมูลซีรีส์ 1 ของแผนภูมิในเวิร์กชีตข้อมูลแผนภูมิ
1. ตอนนี้เข้าถึงชื่อแผนภูมิและตั้งค่า setthefontrelatedproperties
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าหน่วยหลัก หน่วยรอง ค่าสูงสุดและค่าต่ำสุด
1. เข้าถึงแกนความลึกหรือแกนซีรีส์ของแผนภูมิและลบออกตามที่แสดงในตัวอย่างนี้ เนื่องจากมีการใช้ซีรีส์เดียวเท่านั้น
1. ตอนนี้ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y
1. บันทึกงานนำเสนอ
1. ปิดอินสแตนซ์ของ Microsoft Excel และ PowerPoint

**การนำเสนอผลลัพธ์ที่สร้างด้วย VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **ตัวอย่าง Aspose.Slides for Java**
โดยใช้ Aspose.Slides for Java จะดำเนินการตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของงานนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์เปล่าไปยังงานนำเสนอ
1. เพิ่มแผนภูมิ **3D clustered column** และเข้าถึงมัน
1. เข้าถึงเวิร์กชีตข้อมูลแผนภูมิโดยใช้ Microsoft Excel Workbook instancefromworkbook
1. ลบซีรีส์ที่ไม่ได้ใช้ 2 และ 3 ออก
1. เข้าถึงหมวดหมู่ของแผนภูมิและแก้ไขป้ายชื่อ
1. เข้าถึงซีรีส์ 1 และแก้ไขค่าของซีรีส์
1. ตอนนี้เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติฟอนต์
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าหน่วยหลัก หน่วยรอง ค่าสูงสุดและค่าต่ำสุด
1. ตอนนี้ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y
1. บันทึกงานนำเสนอเป็นรูปแบบ PPTX

**การนำเสนอผลลัพธ์ที่สร้างด้วย Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **คำถามที่พบบ่อย**

**ฉันสามารถสร้างแผนภูมิประเภทอื่น ๆ เช่น พาย, เส้น, หรือแท่งด้วย Aspose.Slides ได้หรือไม่?**

ใช่ Aspose.Slides รองรับประเภทแผนภูมิที่หลากหลายรวมถึง [chart types](/slides/th/java/create-chart/) เช่น แผนภูมิพาย, แผนภูมิเส้น, แผนภูมิบาร์, แผนภูมิกระจาย, แผนภูมิบับเบิลและอื่น ๆ คุณสามารถระบุประเภทแผนภูมิที่ต้องการโดยใช้คลาส [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) เมื่อเพิ่มแผนภูมิ

**ฉันสามารถใช้สไตล์หรือธีมที่กำหนดเองกับแผนภูมิได้หรือไม่?**

ใช่ คุณสามารถปรับแต่งลักษณะของแผนภูมิได้อย่างเต็มที่รวมถึงสี, ฟอนต์, การเติม, ขอบ, เส้นกริดและเค้าโครง อย่างไรก็ตาม การใช้ธีม Office ให้ตรงกับที่เห็นใน PowerPoint จำเป็นต้องตั้งค่าสไตล์แต่ละอย่างด้วยตนเอง

**ฉันสามารถส่งออกแผนภูมิเป็นภาพแยกจากสไลด์ได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณส่งออกรูปทรงใด ๆ รวมถึงแผนภูมิเป็นภาพแยก (เช่น PNG, JPEG) โดยใช้เมธอด `getImage` บน [shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/) ของแผนภูมิ