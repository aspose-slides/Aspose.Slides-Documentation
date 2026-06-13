---
title: การติดตั้ง
type: docs
weight: 70
url: /th/cpp/installation/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการติดตั้ง Aspose.Slides สำหรับ C++ อย่างรวดเร็ว คู่มือเชิงขั้นตอน ความต้องการของระบบ และตัวอย่างโค้ด — เริ่มทำงานกับงานนำเสนอ PowerPoint วันนี้!"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการติดตั้ง Aspose.Slides บน Windows โดยมุ่งเน้นการติดตั้งผ่าน NuGet และแสดงวิธีเพิ่มไลบรารีเข้ากับโครงการ Visual Studio ทั้งผ่าน NuGet Package Manager หรือ Package Manager Console บน Windows รวมถึงวิธีอัปเดตแพคเกจและติดตั้งรุ่น prerelease เมื่อจำเป็น

## **Windows**
NuGet ให้วิธีที่ง่ายที่สุดในการดาวน์โหลดและติดตั้ง Aspose API สำหรับ C++ บนเครื่อง PC

### **ตัวเลือกที่หนึ่ง: ติดตั้งหรืออัปเดต Aspose.Slides for C++ จาก NuGet Package Manager**

1. เปิด Microsoft Visual Studio  
2. สร้างแอปพลิเคชันคอนโซลง่าย ๆ หรือเปิดโครงการที่คุณต้องการ  
3. ไปที่ **Tools** > **NuGet package manager**  
4. ใน **Browse** พิมพ์ *Aspose.Slides.Cpp* ลงในช่องข้อความ  

![todo:image_alt_text](installation_1.png)

3. คลิกเวอร์ชันที่คุณต้องการ **Aspose.Slides.Cpp** แล้วคลิก **Install**  
   * หากต้องการอัปเดต Aspose.Slides (หมายความว่าคุณได้ติดตั้งไว้แล้ว) ให้คลิก **Update** แทน  

API ที่เลือกจะถูกดาวน์โหลดและอ้างอิงในโครงการของคุณ

### **ตัวเลือกที่สอง: ติดตั้งหรืออัปเดต Aspose.Slides ผ่าน Package Manager Console**

เพื่ออ้างอิง [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) ด้วย Package Manager Console ทำตามขั้นตอนต่อไปนี้:

1. เปิดโซลูชัน/โครงการใน Visual Studio  

1. ไปที่ **Tools** > **NuGet Package Manager** > **Package Manager Console**  

   Package Manager Console จะเปิดขึ้น  

![todo:image_alt_text](installation_2.png)

4. พิมพ์คำสั่งนี้: `Install-Package Aspose.Slides.Cpp`  
> หากต้องการติดตั้งเวอร์ชัน x86 ให้ใช้แพคเกจ Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. กดปุ่ม Enter  

   รุ่นเต็มล่าสุดจะถูกติดตั้งลงในแอปพลิเคชันของคุณ  

   * หรือคุณสามารถเพิ่ม suffix `-prerelease` ลงในคำสั่งเพื่อระบุให้ติดตั้งรุ่นล่าสุด (รวมถึง hotfix) ด้วย  

![todo:image_alt_text](installation_3.png)

​	เมื่อการดาวน์โหลดเสร็จสมบูรณ์ คุณจะเห็นข้อความยืนยันบางอย่าง  

![todo:image_alt_text](installation_4.png)

หากคุณไม่คุ้นเคยกับ [Aspose EULA](https://about.aspose.com/legal/eula) คุณอาจต้องการอ่านสัญญาอนุญาตที่ระบุใน URL นั้น

ใน Package Manager Console คุณสามารถเรียกใช้คำสั่ง `Update-Package Aspose.Slides.Cpp` เพื่อตรวจสอบการอัปเดตของแพคเกจ Aspose.Slidesได้ การอัปเดต (หากพบ) จะถูกติดตั้งโดยอัตโนมัติ คุณยังสามารถใช้ suffix `-prerelease` เพื่ออัปเดตรุ่นล่าสุดได้เช่นกัน

### **การใช้โฟลเดอร์ Include และ lib**
1. [Download](https://downloads.aspose.com/slides/th/cpp) เวอร์ชันล่าสุดของ Aspose.Slides for C++  
1. แตกไฟล์โฟลเดอร์ไปยังสภาพแวดล้อมการผลิต  
1. เพื่อนำ Aspose.Slides for C++ ไปใช้ ให้อ้างอิงโฟลเดอร์ Include และ lib ในโครงการของคุณ  

## **FAQ**

**มีเวอร์ชันฟรีหรือข้อจำกัดของการทดลองใช้อยู่หรือไม่?**

ใช่ โดยค่าเริ่มต้น Aspose.Slides ทำงานในโหมดประเมินผล ซึ่งจะแสดงลายน้ำและอาจมีข้อจำกัดอื่น ๆ หากต้องการลบข้อจำกัดเหล่านั้น คุณต้องใช้ [license](/slides/th/cpp/licensing/) ที่ถูกต้อง.