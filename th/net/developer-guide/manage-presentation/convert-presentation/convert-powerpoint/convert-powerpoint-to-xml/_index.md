---
title: แปลงการนำเสนอ PowerPoint ไปเป็น XML ใน .NET
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/net/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint ไปเป็น XML
- แปลงการนำเสนอไปเป็น XML
- PPT ไปเป็น XML
- PPTX ไปเป็น XML
- ODP ไปเป็น XML
- การนำเสนอ PowerPoint XML
- SaveFormat.Xml
- บันทึกการนำเสนอเป็น XML
- ส่งออกการนำเสนอเป็น XML
- สตรีม XML
- .NET
- C#
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPointและ OpenDocument ให้เป็นไฟล์หรือสตรีม PowerPoint XML ด้วย C# และ Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถแปลงไฟล์นำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์เป็น XML มีประโยชน์เมื่อคุณต้องการตัวแทนแบบข้อความเพื่อทำการตรวจสอบโครงสร้างของการนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือการรวมเข้ากับกระบวนการทำงานที่ใช้ XML แทนแพ็กเกจนำเสนอ

ใช้เมธอด [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) กับค่า `Xml` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงไปยังไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` สร้าง PowerPoint XML Presentation. มันไม่ได้แยกส่วน Office Open XML รายบุคคลที่จัดเก็บภายในแพ็กเกจ PPTX หากคุณต้องการส่วนของแพ็กเกจ PPTX ที่แม่นยำ เช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX เอง.
{{% /alert %}}

## **แปลงการนำเสนอเป็นไฟล์ XML**

โหลดการนำเสนอต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) จากนั้นส่งพาธผลลัพธ์และ `SaveFormat.Xml` ไปยังเมธอด [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) แหล่งข้อมูลต้นฉบับอาจเป็นรูปแบบการนำเสนอใดก็ได้ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้แปลงการนำเสนอ PPTX เป็นไฟล์ XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้ overload ของสตรีมของเมธอด [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) เมื่อ XML ต้องอยู่ในหน่วยความจำหรือส่งต่อไปยังส่วนประกอบอื่น เช่น เว็บเซอร์วิส ผู้ให้บริการจัดเก็บข้อมูล หรือพายไลน์การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) และเลื่อนตำแหน่งกลับเพื่อการอ่านต่อไป:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// ส่ง xmlStream ไปยังส่วนประกอบถัดไปในลำดับการทำงาน.
```

## **เปรียบเทียบ XML กับรูปแบบการนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการใช้ผลลัพธ์:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | การตรวจสอบโครงสร้าง, การแก้ไขปัญหา, การเปรียบเทียบผลลัพธ์ที่สร้างขึ้น, และการบูรณาการด้วย XML |
| PPT (`.ppt`) | ไฟล์นำเสนอไบนารีที่เก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่ประกอบด้วยหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนการนำเสนอ |
| PDF หรือ TIFF | หน้าแบบจัดตำแหน่งคงที่หรือภาพ TIFF | การดู, การพิมพ์, และการเก็บถาวร |
| PNG, JPEG หรือ SVG | การแสดงผลของสไลด์เดี่ยว | ภาพย่อลูก, การพรีวิว, และทรัพยากรภาพ |
| HTML หรือ HTML5 | ผลลัพธ์การนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีจุดมุ่งหมายหลักเพื่อการตรวจสอบและกระบวนการทำงานเชิงข้อมูล ต่างจาก PDF, TIFF, HTML และรูปแบบภาพสไลด์, มันเป็นการแสดงข้อมูลการนำเสนอแทนการเรนเดอร์สไลด์เป็นหน้า หรือทรัพยากรภาพ ตาราง [supported file formats](/slides/th/net/supported-file-formats/) แสดงรายการทุกรูปแบบที่ Aspose.Slides สามารถโหลด, นำเข้า, บันทึก, หรือเรนเดอร์ได้.

## **คำถามที่พบบ่อย**

**`SaveFormat.Xml` มีความเหมือนกับการบันทึกไฟล์ PPTX หรือไม่?**

ไม่. PPTX เป็นแพ็กเกจที่มีหลายส่วนของ Office Open XML, ในขณะที่ `SaveFormat.Xml` สร้างไฟล์ PowerPoint XML Presentation.

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**

ใช่. ส่งสตรีมที่เขียนได้ไปยังเมธอด [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). ตัวอย่างเช่น ใช้ [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) สำหรับการประมวลผลในหน่วยความจำ.

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกหรือไม่?**

ใช่. ส่งไฟล์ XML หรือสตรีมไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) แล้ว [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) จะคืนค่า `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) รายงาน `LoadFormat.Unknown` สำหรับรูปแบบนี้, ดังนั้นอย่าใช้เพื่อตัดสินว่าไฟล์ XML สามารถเปิดได้หรือไม่.

**การแปลงเป็น XML ทำให้แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**

ไม่. การแปลงเป็น XML จะเขียนข้อมูลการนำเสนอที่เป็นโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้าที่เน้น, หรือ PNG, JPEG และ SVG สำหรับภาพสไลด์เดี่ยว.