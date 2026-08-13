---
title: สร้างงานนำเสนอใหม่โดยใช้ VSTO และ Aspose.Slides for Java
linktitle: สร้างงานนำเสนอใหม่
type: docs
weight: 10
url: /th/java/create-a-new-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides for Java และสร้างงานนำเสนอ PowerPoint (PPT, PPTX) ใหม่ใน Java ด้วยโค้ดที่สะอาดและเชื่อถือได้."
---
{{% alert color="info" %}} 

VSTO ถูกพัฒนาเพื่อให้ผู้พัฒนาสร้างแอปพลิเคชันที่สามารถทำงานภายใน Microsoft Office ได้ VSTO ใช้พื้นฐาน COM แต่ถูกห่อหุ้มอยู่ในวัตถุ .NET เพื่อให้สามารถใช้ในแอปพลิเคชัน .NET ได้ VSTO จำเป็นต้องมีการสนับสนุนจาก .NET framework รวมถึงรันไทม์ที่ใช้ CLR ของ Microsoft Office แม้ว่าจะสามารถใช้ในการสร้าง Add-in ของ Microsoft Office ได้ แต่ก็เกือบจะเป็นไปไม่ได้ที่จะใช้เป็นส่วนประกอบฝั่งเซิร์ฟเวอร์ นอกจากนี้ยังมีปัญหาการปรับใช้ที่รุนแรง

Aspose.Slides for Java เป็นคอมโพเนนท์ที่สามารถใช้จัดการงานนำเสนอ Microsoft PowerPoint เช่นเดียวกับ VSTO แต่มีข้อได้เปรียบหลายประการ:
- Aspose.Slides มีเพียงโค้ดที่จัดการได้และไม่จำเป็นต้องมีรันไทม์ของ Microsoft Office ติดตั้งไว้
- สามารถใช้เป็นคอมโพเนนท์ฝั่งไคลเอนต์หรือฝั่งเซิร์ฟเวอร์ได้
- การปรับใช้ทำได้ง่ายเพราะ Aspose.Slides อยู่ในไฟล์ jar เพียงไฟล์เดียว

{{% /alert %}} 
## **สร้างงานนำเสนอ**
ด้านล่างเป็นตัวอย่างโค้ดสองตัวอย่างที่แสดงให้เห็นว่า VSTO และ Aspose.Slides for Java สามารถใช้เพื่อบรรลุเป้าหมายเดียวกันได้ ตัวอย่างแรกคือ [VSTO](/slides/th/java/create-a-new-presentation/); [ตัวอย่างที่สอง](/slides/th/java/create-a-new-presentation/) ใช้ Aspose.Slides.
### **ตัวอย่าง VSTO**
**ผลลัพธ์ของ VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **ตัวอย่าง Aspose.Slides for Java**
**ผลลัพธ์จาก Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}