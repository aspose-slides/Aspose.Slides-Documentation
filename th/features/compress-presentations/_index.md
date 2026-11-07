---
title: บีบอัดการนำเสนอ
description: ลดขนาดการนำเสนอโดยการบีบอัดภาพและลบเนื้อหาที่ไม่ได้ใช้
type: docs
url: /th/features/compress-presentations/
weight: 250
feature_id: บีบอัด-การนำเสนอ
feature_group: การดำเนินการ
translationKey: สไลด์ฟีเจอร์-บีบอัด-การนำเสนอ
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **ภาพรวม**

บีบอัดรูปภาพ, ลบพื้นที่รูปที่ถูกตัดออกเมื่อไม่จำเป็นต้องใช้แล้ว, และเลือกการตั้งค่าการบีบอัดการนำเสนอก่อนบันทึก. สิ่งนี้เป็นประโยชน์สำหรับสไลด์ที่มีภาพถ่ายขนาดใหญ่หรือสื่อที่ใช้ซ้ำ. ปริมาณการบันทึกที่ได้ขึ้นอยู่กับเนื้อหาและการตั้งค่าที่คุณเลือก.

## **ตัวอย่างการใช้งาน**

ตัวอย่าง C# นี้โหลด `input.pptx`, บีบอัดการนำเสนอ, และบันทึกเป็น `compressed.pptx`.

ใช้ Aspose.Slides for .NET 26.11 หรือรุ่นใหม่กว่า. สำหรับการตั้งค่า, ดู[ติดตั้ง Aspose.Slides สำหรับ .NET](/slides/th/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **นี่เป็นสวิตช์การปรับแต่งไฟล์ทั้งหมดแบบเดียวหรือไม่?**

Aspose.Slides for .NET 26.11 เพิ่ม[Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), ซึ่งรวมการลบเลเอาต์/มาสเตอร์ที่ไม่ได้ใช้, การย่อยฟอนต์ที่ฝังไว้และการบีบอัดรูปภาพ 150‑DPI. มันลบพื้นที่รูปที่ถูกตัดออกอย่างถาวร. สำหรับการประมวลผลเฉพาะรูปภาพ, ใช้[Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); สำหรับการควบคุมที่ละเอียดกว่า, ดู[ตัวอย่างการบีบอัดรูปภาพแยกแต่ละรูป](/slides/th/net/examples/optimization-batch/compression/). ตัวช่วยใหม่เหล่านี้จำเพาะกับเวอร์ชัน .NET ที่ระบุ; ตรวจสอบคู่มือที่สอดคล้องสำหรับ SDK อื่น ๆ.

### **การบีบอัดรูปภาพทำให้ข้อความที่แก้ไขได้หรือแผนภูมิตามเปลี่ยนแปลงหรือไม่?**

การบีบอัดรูปภาพมุ่งเป้าไปที่ข้อมูลรูปภาพ, ไม่ใช่ข้อความที่แก้ไขได้หรือข้อมูลแผนภูมิ. ตรวจสอบรูปภาพเนื่องจากการปรับขนาดหรือการบีบอัดซ้ำอาจลดรายละเอียดของรูปได้.

### **ฉันควรเลือกความละเอียดสำหรับรูปภาพในการนำเสนออย่างไร?**

เลือกค่าเป้าหมายตามขนาดรูปภาพที่แสดงและการใช้จอหรือการพิมพ์ที่ตั้งใจ. รักษาความละเอียดมากขึ้นสำหรับจอแสดงผลขนาดใหญ่, การพิมพ์และไดอะแกรมที่ละเอียด, และเปรียบเทียบผลลัพธ์ที่เรนเดอร์ก่อนลบไฟล์ต้นฉบับ.

## **คู่มือ**

- [บีบอัดการนำเสนอทั้งหมดใน .NET](/slides/th/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [เพิ่มประสิทธิภาพการจัดการภาพในการนำเสนอใน .NET](/slides/th/net/image/)

ฟีเจอร์ที่เกี่ยวข้อง: [ลบมาสเตอร์, เลเอาต์และสื่อที่ไม่ได้ใช้](/slides/th/features/remove-unused-content/).

## ตัวอย่าง .NET ที่สามารถรันได้

- [ลดขนาดการนำเสนอ](/slides/th/net/examples/optimization-batch/compression/)