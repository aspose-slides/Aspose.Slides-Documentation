---
title: แปลงงานนำเสนอ PowerPoint เป็น XML ใน .NET
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/net/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint เป็น XML
- แปลงงานนำเสนอเป็น XML
- PPT เป็น XML
- PPTX เป็น XML
- ODP เป็น XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- บันทึกงานนำเสนอเป็น XML
- ส่งออกงานนำเสนอเป็น XML
- สตรีม XML
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ใน C# ด้วย Aspose.Slides for .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์ XML มีประโยชน์เมื่อคุณต้องการการแสดงผลแบบข้อความเพื่อทำการตรวจสอบโครงสร้างของงานนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือการรวมเข้ากับเวิร์กโฟลว์ที่ใช้ XML แทนการใช้แพ็กเกจงานนำเสนอ

ใช้เมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) พร้อมกับค่า `Xml` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงลงไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` สร้าง PowerPoint XML Presentation ไม่ได้ทำการแยกส่วน Office Open XML แต่ละส่วนที่เก็บอยู่ในแพ็กเกจ PPTX หากคุณต้องการส่วนที่เป็นไฟล์ PPTX อย่างแม่นยำ เช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX ด้วยตนเอง
{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) จากนั้นส่งเส้นทางไฟล์ผลลัพธ์และ `SaveFormat.Xml` ไปยัง [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใดก็ได้ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้จะแปลงงานนำเสนอ PPTX เป็นไฟล์ XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้ overload แบบสตรีมของ [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เมื่อผลลัพธ์ XML จำเป็นต้องอยู่ในหน่วยความจำหรือส่งต่อไปยังส่วนประกอบอื่น เช่น เว็บเซอร์วิส ผู้ให้บริการจัดเก็บข้อมูล หรือพายไลน์การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) แล้วรีวินด์เพื่อการอ่านต่อไป:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// ส่ง xmlStream ไปยังคอมโพเนนต์ต่อไปในเวิร์กโฟลว์.
```

## **เปรียบเทียบ XML กับรูปแบบงานนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการใช้งานของผลลัพธ์:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | การตรวจสอบโครงสร้าง, การแก้ไขปัญหา, การเปรียบเทียบผลลัพธ์ที่สร้างขึ้น, และการผสานรวมแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอแบบไบนารีแบบเก่า | ความเข้ากันได้กับเวิร์กโฟลว์ PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่ประกอบด้วยหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าที่มีการจัดวางตายตัวหรือภาพหลายหน้า | การดู, การพิมพ์, และการเก็บถาวร |
| PNG, JPEG หรือ SVG | การแสดงผลของสไลด์แต่ละสไลด์ | ภาพย่อ, ตัวอย่าง, และทรัพยากรภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีจุดประสงค์หลักเพื่อการตรวจสอบและเวิร์กโฟลว์ที่เน้นข้อมูล แตกต่างจาก PDF, TIFF, HTML, และรูปแบบรูปภาพสไลด์, XML แสดงข้อมูลงานนำเสนอแทนการเรนเดอร์สไลด์เป็นหน้า หรือทรัพยากรภาพ ตาราง [supported file formats](/slides/th/net/supported-file-formats/) ระบุว่า PowerPoint XML Presentation เป็นรูปแบบที่สามารถบันทึกได้เท่านั้น ดังนั้นอย่าใช้เมื่อเวิร์กโฟลว์ต้องโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อทำการแก้ไขต่อ

## **คำถามที่พบบ่อย**

**`SaveFormat.Xml` เหมือนกับการบันทึกไฟล์ PPTX หรือไม่?**

ไม่ PPTX เป็นแพ็กเกจที่ประกอบด้วยหลายส่วนของ Office Open XML ในขณะที่ `SaveFormat.Xml` สร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**

ได้ ส่งสตรีมที่สามารถเขียนได้ให้กับ [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ตัวอย่างเช่น ใช้ [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) สำหรับการประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกหรือไม่?**

ไม่ได้ PowerPoint XML Presentation ปัจจุบันรองรับการบันทึกเท่านั้นไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องทำการแก้ไขรอบ

**การแปลงเป็น XML ทำการเรนเดอร์แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**

ไม่ การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอเป็นโครงสร้าง ไม่ได้เรนเดอร์สไลด์เป็นหน้า ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า หรือ PNG, JPEG และ SVG สำหรับรูปภาพสไลด์แต่ละอัน