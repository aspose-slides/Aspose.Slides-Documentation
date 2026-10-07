---
title: เริ่มต้นใช้งาน
type: docs
weight: 10
url: /th/net/getting-started/
keywords:
- เริ่มต้นใช้งาน
- ข้อกำหนดของระบบ
- การติดตั้ง
- การนำเสนอแรก
- NuGet
- การประมวลผล PPT
- การประมวลผล PPTX
- การประมวลผล ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เส้นทางจากโครงการ .NET ใหม่ไปสู่การบันทึกการนำเสนอแรกด้วย Aspose.Slides: ตรวจสอบข้อกำหนด, ติดตั้งแพ็คเกจ, รันโปรแกรมแรก, และดำเนินการต่อด้วยงานทั่วไป."
---
## **ภาพรวม**

ทำตามสี่ขั้นตอนด้านล่างตามลำดับ แต่ละขั้นตอนระบุว่าต้องทำอะไรและเชื่อมโยงไปยังบทความที่มีรายละเอียด การประเมิน การให้สิทธิ์ใช้งาน และการสนับสนุนจะอธิบายหลังจากขั้นตอนเสร็จสิ้น

## **ขั้นตอน 1: ตรวจสอบข้อกำหนดของระบบ**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) ทำงานบน Windows, Linux, และ macOS. [System Requirements](/slides/th/net/system-requirements/) รายการระบบปฏิบัติการและเวอร์ชัน .NET ที่แต่ละแพ็คเกจรองรับ รวมถึงไลบรารีที่ Linux ต้องการเพิ่มเติม

## **ขั้นตอน 2: ติดตั้งแพ็คเกจ**

Aspose.Slides for .NET แจกจ่ายผ่าน NuGet เป็นสองแพ็คเกจที่ให้คลาสเดียวกัน เพิ่มหนึ่งในนั้นไปยังโครงการของคุณ:

- บน Windows: `dotnet add package Aspose.Slides.NET`
- บน Linux และ macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. บน Linux ให้ติดตั้งไลบรารี `fontconfig` ก่อน
- บน Alpine Linux และบนระบบ Linux ที่ glibc เก่ากว่า 2.23 (x64) หรือ 2.39 (ARM64): Aspose.Slides.NET พร้อมไลบรารี `libgdiplus` ที่ติดตั้งแล้ว

[Installation](/slides/th/net/installation/) ให้คำสั่ง Linux การตั้งค่าเริ่มต้นเพิ่มเติมที่ Aspose.Slides.NET ต้องการบน Linux และขั้นตอนสำหรับ Visual Studio

## **ขั้นตอน 3: สร้างการนำเสนอแรกของคุณ**

The [quick start on the Aspose.Slides for .NET home page](/slides/th/net/#your-first-presentation) เป็นโปรแกรมคอนโซลเต็มรูปแบบ: มันเพิ่มกล่องข้อความลงในสไลด์และบันทึกการนำเสนอเป็นไฟล์ PPTX. [Create Presentations](/slides/th/net/create-presentation/) อธิบายขั้นตอนเดียวกันอย่างละเอียดมากขึ้นและแสดงวิธีเปิดการนำเสนอที่มีอยู่และบันทึกในรูปแบบอื่น

## **ขั้นตอน 4: ดำเนินการกับงานทั่วไป**

- [Open a presentation](/slides/th/net/open-presentation/)
- [Save a presentation](/slides/th/net/save-presentation/)
- [Convert a presentation to PDF](/slides/th/net/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/th/net/convert-slide/)
- [Edit presentation text](/slides/th/net/manage-text/)
- [Examples by slide element](/slides/th/net/examples/)

## **ประเมินและขอใบอนุญาต**

หากไม่มีใบอนุญาต Aspose.Slides จะทำงานในโหมดประเมินผล: จะเพิ่มลายน้ำในทุกสไลด์ที่บันทึกและตัดข้อความที่อ่านจากการนำเสนอ

- [Evaluate Aspose.Slides](/slides/th/net/evaluate-aspose-slides/) อธิบายข้อจำกัดของการประเมินและวิธีขอใบอนุญาตชั่วคราว
- [Licensing](/slides/th/net/licensing/) แสดงวิธีนำใบอนุญาตจากไฟล์ สตรีม หรือทรัพยากรฝังตัว
- [Metered Licensing](/slides/th/net/metered-licensing/) ครอบคลุมการให้ใบอนุญาตแบบตามการใช้
- [Supported File Formats](/slides/th/net/supported-file-formats/) รายการรูปแบบไฟล์ที่ Aspose.Slides สามารถโหลดและบันทึกได้

## **ขอความช่วยเหลือ**

[Product Support](/slides/th/net/product-support/) อธิบายวิธีตั้งคำถามใน [free support forum](https://forum.aspose.com/c/slides/11) และสิ่งที่ควรแนบเมื่อต้องรายงานปัญหา

## **คำถามที่พบบ่อย**

**ฉันต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ไม่จำเป็น Aspose.Slides อ่านและเขียนไฟล์การนำเสนอด้วยตนเองและไม่ใช้ PowerPoint ดังนั้นจึงสามารถทำงานบนเซิร์ฟเวอร์และบน Linux ได้

**ควรใช้แพ็คเกจใดสำหรับแอปพลิเคชัน .NET Framework?**

Aspose.Slides.NET. มันรวมบิลด์สำหรับ .NET Framework 4.6.2 ขึ้นไป, .NET 6 ขึ้นไป, และ .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform ต้องการ .NET 6 ขึ้นไป