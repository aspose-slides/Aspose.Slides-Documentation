---
title: แปลง PPT เป็น PPTX ใน .NET
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/net/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ใน .NET ด้วย Aspose.Slides. รวมตัวอย่าง C# สำหรับการแปลงไฟล์เดี่ยวและแบบกลุ่ม, การจัดการข้อผิดพลาด, และหมายเหตุความเที่ยงตรง."
---
## **ภาพรวม**

PPT คือรูปแบบไบนารีเก่าของ PowerPoint ในขณะที่ PPTX คือรูปแบบ Open XML ที่ใหม่กว่า Aspose.Slides for .NET สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) จากนั้นเรียก [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/). คำประกาศ `using` จะทำการปลดปล่อยการนำเสนอและรีลีซทรัพยากรเมื่อขอบเขตสิ้นสุด

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// โหลดการนำเสนอ PPT รุ่นเก่า.
using var presentation = new Presentation("presentation.ppt");

// บันทึกการนำเสนอในรูปแบบ PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

ส่วนขยายไฟล์ไม่ได้กำหนดรูปแบบผลลัพธ์ด้วยตนเอง; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ทำเช่นนั้น. ควรเก็บเส้นทางอินพุตและเอาต์พุตให้แตกต่างกันหากต้องการคงไฟล์ PPT ดั้งเดิม

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง. แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดงานทั้งหมดหยุดทำงาน

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

สำหรับงานการผลิต ให้บันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าควรเขียนทับไฟล์ผลลัพธ์ที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวลงในคิวรีไทร์หรือคิวตรวจสอบ. ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านเปิดโดยไม่มีรหัสที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับอาจทำให้การแปลงล้มเหลว. ดูที่ [Password-Protected Presentations](/slides/th/net/password-protected-presentation/) สำหรับโหลดไฟล์ที่เข้ารหัส

## **ความเที่ยงตรงและฟีเจอร์เดิม**

การแปลงโดยทั่วไปจะรักษาสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิไว้. อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงฟีเจอร์ทุกอย่างในรูปแบบที่เหมือนกันอย่างแน่นอน. ฟีเจอร์เดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ตัดออก, หรือแสดงอย่างแตกต่าง

ให้ตรวจสอบไฟล์ที่แปลงเมื่อมีแอนิเมชัน, การเปลี่ยนผ่าน, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, มีเดียฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA. ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่เปิดใช้งานแมโคร, ดังนั้นให้ใช้เวิร์กโฟลว์ที่รองรับแมโครเมื่อต้องการให้ VBA ยังใช้งานได้. ตรวจสอบด้วยว่าฟอนต์ที่จำเป็นและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่นำเสนอที่แปลงแล้วจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารสำคัญ, ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่โดยโปรแกรมและตรวจสอบจำนวนสไลด์หลักและเนื้อหา, จากนั้นเปรียบเทียบรูปลักษณ์และพฤติกรรมการแสดงสไลด์ในโปรแกรมดูที่ต้องการ. อย่าพิจารณาการเรียก [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) ที่สำเร็จเป็นหลักฐานว่าฟีเจอร์เดิมทุกอย่างมีการแสดงผลใน PPTX อย่างแม่นยำ

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็คเกจ Open XML, หรือจัดเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ากว่าไฟล์ไบนารี PPT ดั้งเดิม. เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเก็บถาวรหรือสำเนาสำรองจนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความเที่ยงตรงของคุณ

หากคุณต้องการ PDF, HTML, รูปภาพ, XPS, หรือประเภทผลลัพธ์อื่นแทน, ให้ใช้คำแนะนำเฉพาะรูปแบบใน [Convert Presentations to Multiple Formats](/slides/th/net/convert-presentation/) แทนการสันนิษฐานว่าทุกเป้าหมายจะคงฟีเจอร์ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์ที่ใช้อย่างไม่บ่อยหรือการเปรียบเทียบอย่างเร็ว, คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx). สำหรับการแปลงที่ทำซ้ำ, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน, ให้ใช้ .NET API

## **บทความที่เกี่ยวข้อง**

- [PPT กับ PPTX](/slides/th/net/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน .NET](/slides/th/net/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/slides/th/net/supported-file-formats/)
- [เปิดการนำเสนอใน .NET](/slides/th/net/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้. Aspose.Slides for .NET โหลดและบันทึกไฟล์การนำเสนอโดยไม่ต้องอาศัย Microsoft PowerPoint

**การแปลงจาก PPT ไปเป็น PPTX จะรักษาเนื้อหาทั้งหมดได้อย่างแม่นยำหรือไม่?**

มันรักษาเนื้อหาการนำเสนอทั่วไปได้, แต่ความเที่ยงตรงอย่างสมบูรณ์ไม่ได้รับการรับประกันสำหรับฟีเจอร์เดิมหรือฟีเจอร์ที่ไม่รองรับทุกอย่าง. ควรตรวจสอบไฟล์ที่สร้างขึ้นเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, มีเดีย, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้, หากคุณใส่รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์. การไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังจากแปลงหรือไม่?**

เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมดูและเวิร์กโฟลว์ที่สำคัญต่อคุณ. นี้จะเป็นสำเนาสำรองกรณีฟีเจอร์เดิมแปลงได้ต่างออกไป