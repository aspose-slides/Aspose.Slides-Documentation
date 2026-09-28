---
title: ภาพรวมคุณลักษณะ
type: docs
weight: 94
url: /th/net/features-overview/
keywords:
- คุณลักษณะ
- แพลตฟอร์มที่รองรับ
- รูปแบบไฟล์
- การแปลง
- การเรนเดอร์
- เนื้อหาการนำเสนอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนสิ่งที่ Aspose.Slides for .NET ครอบคลุมก่อนที่คุณจะประเมิน: แพลตฟอร์มที่รองรับ, รูปแบบไฟล์, การเรนเดอร์สไลด์, และเนื้อหาที่คุณสามารถสร้างและแก้ไขได้."
---
## **ภาพรวม**

Aspose.Slides for .NET เป็นไลบรารีคลาสสำหรับสร้าง อ่าน แก้ไข แปลง และเรนเดอร์การนำเสนอ PowerPoint และ OpenDocument ไลบรารีนี้ไม่มีส่วนติดต่อผู้ใช้ของตนเองและไม่ต้องการ Microsoft PowerPoint หรือ Office ดังนั้นคุณจึงสามารถใช้ได้ในแอปพลิเคชันคอนโซล แอปพลิเคชันเดสก์ท็อปเช่น Windows Forms แอปพลิเคชันเว็บ และเว็บเซอร์วิส บทความนี้สรุปสิ่งที่ไลบรารีครอบคลุมและเชื่อมโยงไปยังบทความที่อธิบายแต่ละส่วน

## **แพลตฟอร์มที่รองรับ**

Aspose.Slides for .NET มีการจัดจำหน่ายเป็นแพ็กเกจ NuGet สองชุดที่มี API เหมือนกัน:

|**แพ็กเกจ**|**รุ่นในแพ็กเกจ**|**ระบบปฏิบัติการ**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0, และ .NET 6. ใช้งานกับ .NET Framework 4.6.2 หรือใหม่กว่า หรือกับ .NET 6 หรือใหม่กว่า.|Windows. Linux และ macOS ที่มีไลบรารี `libgdiplus` และสวิตช์ `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. ใช้งานกับ .NET 6 หรือใหม่กว่า.|Windows (x86, x64), Linux (x64 พร้อม glibc 2.23 ขึ้นไป, ARM64 พร้อม glibc 2.39 ขึ้นไป) และ macOS (x64, ARM64).|

[การติดตั้ง](/slides/th/net/installation/) อธิบายว่าควรเลือกแพ็กเกจใดและแต่ละแพ็กเกจต้องการอะไรบน Linux. [ความต้องการระบบ](/slides/th/net/system-requirements/) รายการแพลตฟอร์มที่รองรับอย่างละเอียด

## **รูปแบบไฟล์และการแปลง**

Aspose.Slides เปิดและบันทึกไฟล์ PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP, และการนำเสนอ PowerPoint XML นอกจากนี้ยังนำเข้าเนื้อหา PDF และ HTML ไปยังสไลด์ และบันทึกการนำเสนอเป็น PDF, XPS, HTML, HTML5, TIFF, GIF เคลื่อนไหว, SWF, Markdown, และ XAML. [รูปแบบไฟล์ที่รองรับ](/slides/th/net/supported-file-formats/) แสดงรายการทุกรูปแบบพร้อม API ที่อ่านหรือเขียนได้

|**คุณลักษณะ**|**คำอธิบาย**|
| :- | :- |
|[PPT และ PPTX](/slides/th/net/ppt-vs-pptx/)|อ่านและเขียนทั้งรูปแบบ PowerPoint 97-2003 แบบไบนารีและรูปแบบ Office Open XML.|
|[การแปลง PPT เป็น PPTX](/slides/th/net/convert-ppt-to-pptx/)|แปลงการนำเสนอ PPT รุ่นเก่าเป็น PPTX.|
|[Portable Document Format (PDF)](/slides/th/net/convert-powerpoint-to-pdf/)|ส่งออกการนำเสนอเป็น PDF รวมถึงเอกสาร PDF/A และ PDF/UA.|
|[XML Paper Specification (XPS)](/slides/th/net/convert-powerpoint-to-xps/)|ส่งออกการนำเสนอเป็นเอกสาร XPS.|
|[Tagged Image File Format (TIFF)](/slides/th/net/convert-powerpoint-to-tiff/)|ส่งออกการนำเสนอเป็นภาพ TIFF.|
|[HTML](/slides/th/net/convert-powerpoint-to-html/)|ส่งออกการนำเสนอเป็น HTML และ HTML5.|
|[การนำเข้า PDF และ HTML](/slides/th/net/import-presentation/)|สร้างสไลด์จากหน้า PDF และเนื้อหา HTML.|

## **การเรนเดอร์การนำเสนอ**

Aspose.Slides เรนเดอร์สไลด์และรูปทรงแต่ละชิ้นเป็นภาพ PNG, JPEG, BMP, GIF, TIFF, และ SVG, รวมถึงสไลด์เป็นไฟล์เมต้า EMF. ดูที่ [แปลงสไลด์การนำเสนอเป็นภาพ](/slides/th/net/convert-slide/), [เรนเดอร์สไลด์เป็นภาพ SVG](/slides/th/net/render-a-slide-as-an-svg-image/), และ [สร้างภาพย่อของรูปทรง](/slides/th/net/create-shape-thumbnails/).

## **คุณลักษณะของเนื้อหา**

Aspose.Slides ให้คุณสร้าง อ่าน และแก้ไขเนื้อหาส่วนใหญ่ของการนำเสนอ:

|**พื้นที่**|**สิ่งที่คุณทำได้**|
| :- | :- |
|[สไลด์](/slides/th/net/presentation-slide/)|เพิ่ม, คัดลอก, จัดลำดับใหม่, และลบสไลด์; ใช้เลย์เอาต์และมาสเตอร์; จัดสไลด์เป็นส่วน; เปลี่ยนขนาดสไลด์.|
|[การออกแบบ](/slides/th/net/presentation-design/)|ตั้งค่าพื้นหลัง, สีธีม, ส่วนหัวและส่วนท้าย, และแบบอักษร.|
|[ข้อความ](/slides/th/net/manage-text/)|สร้างและแก้ไขกรอบข้อความ, ย่อหน้า, และส่วน; ตั้งค่าแบบอักษร, สี, จุดอัตโนมัติ, และการจัดแนว; ค้นหาและแทนที่ข้อความ.|
|[รูปทรง](/slides/th/net/powerpoint-shapes/)|สร้าง AutoShapes, เส้น, ตัวเชื่อม, กลุ่มรูปทรง, และกรอบรูปภาพ; ตั้งค่าตำแหน่ง, ขนาด, เส้น, และการเติมแบบสีทึบ, ไล่ระดับ, หรือแบบลวดลาย; ค้นหารูปทรงโดยข้อความอธิบายแทน.|
|[ตาราง](/slides/th/net/powerpoint-table/), [แผนภูมิ](/slides/th/net/powerpoint-charts/), และ [SmartArt](/slides/th/net/powerpoint-smartart/)|สร้างและแก้ไขตาราง, แผนภูมิ Microsoft Office, และแผนภาพ SmartArt.|
|[สื่อ](/slides/th/net/manage-media-files/), [วัตถุ OLE](/slides/th/net/manage-ole/), และ [คอนโทรล ActiveX](/slides/th/net/activex/)|เพิ่มกรอบเสียงและวิดีโอที่ฝังหรือเชื่อมโยง, ฝังวัตถุ OLE, และเพิ่ม, แก้ไข หรือเอาคอนโทรล ActiveX ออก.|
|[บันทึกย่อ](/slides/th/net/presentation-notes/) และ [ความคิดเห็น](/slides/th/net/presentation-comments/)|เพิ่ม, อ่าน, และแก้ไขบันทึกย่อของผู้พูดและความคิดเห็น.|
|[แอนิเมชัน](/slides/th/net/powerpoint-animation/) และ [การเปลี่ยนหน้า](/slides/th/net/slide-transition/)|ใช้เอฟเฟกต์แอนิเมชันกับรูปทรง, ตั้งค่าการเปลี่ยนหน้าสไลด์, และกำหนดค่าการแสดงสไลด์โชว์.|
|[ความปลอดภัย](/slides/th/net/presentation-security/)|เข้ารหัสการนำเสนอด้วยรหัสผ่าน, ตั้งค่าการป้องกันการเขียน, และทำงานกับลายเซ็นดิจิทัล.|
|[มาโคร VBA](/slides/th/net/presentation-via-vba/)|เพิ่ม, ดึงออก, และลบโมดูล VBA ในการนำเสนอที่เปิดใช้งานมาโคร.|
|[คุณสมบัติ](/slides/th/net/presentation-properties/)|อ่านและแก้ไขคุณสมบัติเขียนของเอกสาร.|

## **คำถามที่พบบ่อย**

**ต้องติดตั้ง Microsoft PowerPoint บนเซิร์ฟเวอร์หรือ PC เพื่อให้ไลบรารีทำงานหรือไม่?**

ไม่จำเป็นต้องใช้ PowerPoint; Aspose.Slides เป็นเอนจินอิสระสำหรับสร้าง, แก้ไข, แปลง, และเรนเดอร์การนำเสนอ.

**การทำงานหลายเธรดทำอย่างไร? สามารถประมวลผลแบบขนานได้หรือไม่?**

ปลอดภัยที่จะประมวลผลเอกสารต่าง ๆ ในเธรดที่แตกต่างกัน; ห้ามใช้วัตถุ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) เดียวกันโดย [multiple threads](/slides/th/net/multithreading/) พร้อมกัน.

**รองรับการตั้งรหัสผ่านไฟล์และการเข้ารหัสหรือไม่?**

ใช่. [คุณสามารถ](/slides/th/net/password-protected-presentation/) เปิดการนำเสนอที่เข้ารหัส, ตั้งหรือถอดรหัสผ่านการเปิดและการเขียน, และตรวจสอบสถานะการป้องกัน.

**ต้องคำนึงถึงแบบอักษรในคอนเทนเนอร์ Linux หรือไม่?**

ใช่. แบบอักษรที่ใช้ในการนำเสนอของคุณหรือแบบอักษรทดแทนที่เหมาะสมต้องติดตั้งในระบบเพื่อให้ข้อความแสดงผลอย่างถูกต้อง. คุณยังสามารถ [กำหนดไดเรกทอรีแบบอักษร](/slides/th/net/custom-font/) ในแอปพลิเคชันของคุณ. [การติดตั้ง](/slides/th/net/installation/) ระบุข้อกำหนดลินุกซ์ของแต่ละแพ็กเกจ.

**มีข้อจำกัดในรุ่นทดลองหรือไม่?**

ใช่. หากไม่มี [license](/slides/th/net/licensing/) Aspose.Slides จะใส่น้ำแสดงการประเมินผลบนทุกสไลด์ที่บันทึกและจะตัดข้อความที่อ่านจากการนำเสนอ. มี [ใบอนุญาตชั่วคราว 30 วัน](https://purchase.aspose.com/temporary-license/) เพื่อทดสอบฟีเจอร์ทั้งหมด.

**รองรับการนำเข้ารูปแบบภายนอกเข้าสู่การนำเสนอ (PDF หรือ HTML ไปยัง PPTX) หรือไม่?**

ใช่. คุณสามารถเพิ่ม [หน้า PDF และเนื้อหา HTML](/slides/th/net/import-presentation/) เข้าไปในการนำเสนอ, ทำให้กลายเป็นสไลด์.