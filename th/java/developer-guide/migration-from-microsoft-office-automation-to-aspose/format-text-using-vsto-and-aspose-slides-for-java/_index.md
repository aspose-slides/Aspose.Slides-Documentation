---
title: จัดรูปแบบข้อความโดยใช้ VSTO และ Aspose.Slides สำหรับ Java
linktitle: จัดรูปแบบข้อความ
type: docs
weight: 30
url: /th/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- จัดรูปแบบข้อความ
- การย้าย
- VSTO
- การอัตโนมัติของ Office
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ย้ายจากการอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ Java และจัดรูปแบบข้อความในงานนำเสนอ PowerPoint (PPT, PPTX) ด้วยการควบคุมที่แม่นยำ."
---
{{% alert color="primary" %}}

บางครั้งคุณอาจต้องจัดรูปแบบข้อความบนสไลด์โดยอัตโนมัติ บันทความนี้แสดงวิธีการอ่านงานนำเสนอตัวอย่างที่มีข้อความบนสไลด์แรกโดยใช้ [VSTO](/slides/th/java/format-text-using-vsto-and-aspose-slides-for-java/) หรือ [Aspose.Slides for Java](/slides/th/java/format-text-using-vsto-and-aspose-slides-for-java/) โค้ดจะจัดรูปแบบข้อความใน TextBox ที่สามของสไลด์ให้ดูเหมือนกับข้อความใน TextBox สุดท้าย

{{% /alert %}}
## **การจัดรูปแบบข้อความ**
ทั้งวิธีการของ VSTO และ Aspose.Slides มีขั้นตอนดังต่อไปนี้:

1. เปิดงานนำเสนอต้นฉบับ
1. เข้าถึงสไลด์แรก
1. เข้าถึง TextBox ที่สาม
1. เปลี่ยนการจัดรูปแบบของข้อความใน TextBox ที่สาม
1. บันทึกงานนำเสนอลงดิสก์

ภาพหน้าจอต่อไปนี้แสดงสไลด์ตัวอย่างก่อนและหลังการเรียกใช้โค้ดของ VSTO และ Aspose.Slides for Java

**งานนำเสนออินพุต**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **ตัวอย่างโค้ด VSTO**
โค้ดด้านล่างแสดงวิธีการจัดรูปแบบข้อความบนสไลด์โดยใช้ VSTO

**ข้อความที่จัดรูปแบบใหม่ด้วย VSTO**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **ตัวอย่าง Aspose.Slides for Java**
เพื่อจัดรูปแบบข้อความด้วย Aspose.Slides ให้เพิ่มแบบอักษรก่อนการจัดรูปแบบข้อความ

**งานนำเสนอผลลัพธ์ที่สร้างด้วย Aspose.Slides**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}