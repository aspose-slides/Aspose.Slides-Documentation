---
title: บีบอัดการนำเสนอ
description: ลดขนาดการนำเสนอโดยการบีบอัดรูปภาพและลบเนื้อหาที่ไม่ได้ใช้.
type: docs
url: /th/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **ภาพรวม**

บีบอัดรูปภาพ, ลบส่วนที่ถูกตัดออกของรูปเมื่อไม่จำเป็นแล้ว, และเลือกการตั้งค่าการบีบอัดการนำเสนอก่อนบันทึก. นี้เป็นประโยชน์สำหรับชุดสไลด์ที่มีรูปภาพขนาดใหญ่หรือสื่อที่ซ้ำกัน. จำนวนที่บันทึกได้ขึ้นอยู่กับเนื้อหาและการตั้งค่าที่คุณเลือก.

## **ตัวอย่างการใช้งาน**

ตัวอย่าง C# นี้โหลดไฟล์ `input.pptx`, บีบอัดการนำเสนอ, และบันทึกเป็น `compressed.pptx`.

ใช้ Aspose.Slides for .NET 26.11 หรือใหม่กว่า. สำหรับการตั้งค่า, ดูที่ [ติดตั้ง Aspose.Slides for .NET](/slides/th/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![ภาพที่สเกลเท่ากันก่อนและหลังการบีบอัด, ตามด้วยแถบขนาดไฟล์ PPTX ที่วัดได้และขนาดภาพที่จัดเก็บ.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*วัดบนอุปกรณ์กริดรายละเอียดสังเคราะห์หนึ่งรายการ: 584,030 → 128,323 ไบต์. ทั้งสองการแสดงผลใช้สเกลเดียวกันและกรอบ 252 × 336 จุด. การบีบอัดลบพื้นที่ตัดออกและลดภาพที่จัดเก็บเป็น 525 × 700 พิกเซล; การประหยัดขนาดขึ้นอยู่กับอินพุต.*
<!-- visual-explanation:compress-presentations:end -->

## **คำถามที่พบบ่อย**

### **นี่เป็นสวิทช์การเพิ่มประสิทธิภาพไฟล์ทั้งหมดแบบเดียวหรือไม่?**

Aspose.Slides for .NET 26.11 เพิ่ม [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), ซึ่งรวมการลบเลเอาต์/มาสเตอร์ที่ไม่ได้ใช้, การย่อยฟอนต์ที่ฝังและการบีบอัดรูปภาพ 150-DPI. มันลบพื้นที่รูปที่ถูกตัดออกอย่างถาวร. สำหรับการประมวลผลเฉพาะรูป, ใช้ [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); สำหรับการควบคุมที่ละเอียดขึ้น, ดู [ตัวอย่างการบีบอัดรูปภาพแต่ละรูป](/slides/th/net/examples/optimization-batch/compression/). ตั้งแต่เวอร์ชัน 26.11, การเรียกใช้เดียวกันสำหรับการนำเสนอทั้งหมดก็มีให้ใช้ใน Java, Node.js ผ่าน Java, Python ผ่าน .NET และ C++. ตัวอย่างและลิงก์ในหน้านี้สำหรับ .NET.

### **การบีบอัดรูปภาพทำให้ข้อความที่แก้ไขได้หรือแผนภูมิเข้ากันหรือไม่?**

การบีบอัดรูปภาพมุ่งเป้าไปที่ข้อมูลรูป, ไม่ใช่ข้อความที่แก้ไขได้หรือข้อมูลแผนภูมิ. ตรวจสอบรูปภาพเนื่องจากการปรับขนาดหรือการบีบอัดใหม่อาจลดรายละเอียดของมัน.

### **ฉันควรเลือกความละเอียดสำหรับรูปภาพในงานนำเสนออย่างไร?**

เลือกเป้าหมายตามขนาดรูปที่แสดงและการใช้งานหน้าจอหรือการพิมพ์ที่ตั้งใจ. ควรเก็บความละเอียดสูงสำหรับจอแสดงผลขนาดใหญ่, การพิมพ์และแผนภูมิที่ละเอียด, และเปรียบเทียบผลลัพธ์ที่แสดงก่อนทิ้งไฟล์ต้นฉบับ.

## **คู่มือ**

- [บีบอัดการนำเสนอทั้งหมดใน .NET](/slides/th/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [ปรับแต่งการจัดการรูปภาพในงานนำเสนอใน .NET](/slides/th/net/image/)

คุณลักษณะแนบ: [ลบมาสเตอร์, เลเอาต์ และสื่อที่ไม่ได้ใช้](/slides/th/features/remove-unused-content/).

## ตัวอย่าง .NET ที่สามารถเรียกใช้ได้

- [ลดขนาดการนำเสนอ](/slides/th/net/examples/optimization-batch/compression/)