---
title: ตรวจสอบรูปแบบการนำเสนอดั้งเดิมใน .NET
linktitle: รูปแบบแหล่งข้อมูล
type: docs
weight: 35
url: /th/net/detect-presentation-source-format/
keywords:
- รูปแบบแหล่งข้อมูล
- ตรวจจับรูปแบบการนำเสนอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "อ่านรูปแบบดั้งเดิมของการนำเสนอที่โหลดใน C# ด้วย Aspose.Slides สำหรับ .NET, เปรียบเทียบ API การตรวจจับ, และจัดการไฟล์, สตรีม, และรูปแบบ legacy."
---
## **ภาพรวม**

หลังจากโหลดการนำเสนอแล้ว ให้อ่านคุณสมบัติแบบอ่านอย่างเดียว [Presentation.SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sourceformat/) เพื่อกำหนดรูปแบบดั้งเดิมของมัน คุณสมบัตินี้ยังสามารถเข้าถึงได้ผ่าน [IPresentation.SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/sourceformat/). ใช้คุณสมบัตินี้เมื่อการประมวลผลต่อไปขึ้นอยู่กับรูปแบบที่อินสแตนซ์ปัจจุบันถูกโหลดมาจาก

รูปแบบต้นทางจะแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นจะไม่เปลี่ยนแปลงรูปแบบต้นทางของอินสแตนซ์ที่มีอยู่

## **อ่านรูปแบบต้นทางของไฟล์**

ตัวอย่างนี้ต้องการไฟล์ `sample.pptx` ที่มีอยู่แล้ว มันโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปพลิเคชันโดยใช้ [Presentation.SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sourceformat/) แทนชื่อไฟล์ เปลี่ยนเส้นทางเข้าเพื่อทดลองรูปแบบอื่น ตัวอย่างพิมพ์นโยบายที่เลือก; ให้แทนข้อความเหล่านี้ด้วยตรรกะของแอปพลิเคชันของคุณ

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **ระบุค่าที่สนับสนุน**

การนับจำนวน [SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/sourceformat/) แยกรูปแบบการนำเสนอต่อไปนี้ ส่วนต่อขยายด้านล่างเป็นส่วนต่อขยายแบบปกติ ไม่ได้เป็นการสร้างใหม่ของชื่อไฟล์ต้นฉบับ

| ค่า SourceFormat | ส่วนต่อขยาย | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | การนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | การนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | การนำเสนอ Office Open XML ที่เปิดใช้งานมาโคร |
| `Pps` | `.pps` | การแสดงสไลด์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | การแสดงสไลด์ Office Open XML |
| `Ppsm` | `.ppsm` | การแสดงสไลด์ Office Open XML ที่เปิดใช้งานมาโคร |
| `Pot` | `.pot` | แม่แบบ PowerPoint 97–2003 |
| `Potx` | `.potx` | แม่แบบ Office Open XML |
| `Potm` | `.potm` | แม่แบบ Office Open XML ที่เปิดใช้งานมาโคร |
| `Odp` | `.odp` | การนำเสนอ OpenDocument |
| `Otp` | `.otp` | แม่แบบการนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | การนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | การนำเสนอ PowerPoint XML |

## **อ่านรูปแบบต้นทางของสตรีม**

ตัวอย่างนี้ต้องการไฟล์ `sample.pps` ที่มีอยู่แล้ว การอ่านไบต์ของไฟล์นี้เข้าสู่ memory stream เป็นการจำลองอินพุตที่ได้รับโดยไม่มีชื่อไฟล์ เช่น ค่าจากฐานข้อมูลหรืออาร์เรย์ไบต์ที่อัปโหลด ตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) รับเฉพาะสตรีมเท่านั้น

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS และ POT ใช้รูปแบบไบนารีพื้นฐานเดียวกัน เมื่อโหลดโดยใช้เส้นทางไฟล์ ส่วนต่อขยายสามารถช่วยแยกสไลด์โชว์หรือแม่แบบได้ หากไม่มีชื่อไฟล์ เนื้อหาแบบ legacy ของ PPS และ POT อาจถูกรายงานเป็น `SourceFormat.Ppt`; ตัวอย่าง PPS ด้านบนรายงาน `Ppt`

หากแอปพลิเคชันของคุณจำเป็นต้องรักษาความแตกต่างนี้ ควรเก็บชื่อไฟล์ต้นฉบับหรือเมทาดาต้าย่อยแยกไว้ ส่วนต่อขยายเป็นข้อมูลบ่งชี้ที่เป็นประโยชน์สำหรับย่อยแบบ legacy เหล่านี้ แต่ไม่ควรเป็นพื้นฐานเดียวในการระบุเนื้อหาการนำเสนอใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) และ [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/loadformat/) เมื่อคุณต้องการตรวจสอบไฟล์ก่อนโหลดโมเดลอ็อบเจกต์การนำเสนอเต็มรูปแบบ ใช้ [Presentation.SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sourceformat/) เมื่ออินสแตนซ์มีอยู่แล้ว

ตัวอย่างนี้ต้องการ `sample.pptx` และพิมพ์ `Pptx` สำหรับการตรวจสอบทั้งสองครั้ง ในการผลิต ให้เลือก API ที่เหมาะสมกับขั้นตอนการประมวลผลของคุณ; การนำเสนอที่โหลดแล้วไม่จำเป็นต้องตรวจสอบซ้ำเพียงเพื่อรับรูปแบบต้นทาง

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

ผลลัพธ์มีประเภทการนับจำนวนที่ต่างกัน: [LoadFormat](https://reference.aspose.com/slides/th/net/aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/sourceformat/). อย่าเปรียบเทียบโดยการแคสต์ค่าตัวเลขหรือสมมติว่าทุกรูปแบบมีผลลัพธ์การตรวจจับที่เหมือนกัน ในการตรวจสอบการบันทึก‑และ‑เปิดใหม่ที่อธิบายด้านล่าง PowerPoint XML ถูกรายงานเป็น `LoadFormat.Unknown` ก่อนโหลดและ `SourceFormat.Xml` หลังโหลด

## **แยกรูปแบบต้นทางและรูปแบบผลลัพธ์**

ตัวอย่างนี้ต้องการ `sample.pptx` และเขียน `converted.odp`. มันพิมพ์ `Pptx` ทั้งก่อนและหลังการบันทึกอินสแตนซ์ต้นฉบับ อินสแตนซ์ใหม่ที่โหลดจากไฟล์ ODP ผลลัพธ์จะรายงาน `Odp`

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

การนำเสนอที่สร้างจากศูนย์ด้วย `new Presentation()` จะรายงาน `SourceFormat.Pptx`. อินสแตนซ์นี้ไม่มีไฟล์อินพุต: นี่คือค่าตั้งต้นสำหรับอินสแตนซ์ที่สร้างใหม่ ไม่ได้หมายความว่าไฟล์ PPTX ถูกโหลด ตรวจสอบว่าแอปพลิเคชันของคุณสร้างหรือโหลดอินสแตนซ์นั้นแยกกันหรือไม่หากความแตกต่างนี้สำคัญ

## **แมปรูปแบบต้นทางเป็นส่วนต่อขยาย**

ตัวอย่างต่อไปนี้ต้องการ `sample.pptx`. มันแมปค่า [SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/sourceformat/) ที่สนับสนุนในปัจจุบันทุกค่าเป็นส่วนต่อขยายแบบปกติโดยไม่ต้องพาร์สชื่อไฟล์อินพุต ค่าต้องสำรองจะหลีกเลี่ยงการกำหนดส่วนต่อขยายให้ค่าที่ไม่รู้จักโดยเงียบ ๆ

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

การแมปนี้ไม่ได้แปลงไฟล์หรือกู้คืนย่อยแบบ legacy ของ PPS/POT ที่สูญหายระหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) อย่างชัดเจน หรือใช้การแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/net/save-presentation/#save-presentations-in-their-original-format)

## **ตรวจสอบรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างแบบอิสระนี้สร้างการนำเสนอและเขียนไฟล์สามไฟล์ในไดเรกทอรีทำงาน ทับไฟล์ที่มีชื่อเดียวกัน มันเปิดไฟล์ผลลัพธ์แต่ละไฟล์ใหม่ทั้งโดยเส้นทางและผ่าน memory stream สำหรับ PPTX และ ODP ทั้งสองวิธีรายงานรูปแบบที่บันทึกไว้ สำหรับ PPS การโหลดโดยเส้นทางรายงาน `Pps` ในขณะที่การโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์รายงาน `Ppt`

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

การตรวจสอบเดียวกันกับรูปแบบทั้งหมดที่ระบุด้านบนให้ผลลัพธ์ดังต่อไปนี้สำหรับการนำเสนอที่สร้างโดยมีส่วนต่อขยายตรงกัน:

| รูปแบบที่บันทึก | SourceFormat จากเส้นทางไฟล์ | SourceFormat จากสตรีมไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| ODP, OTP | `Odp`, `Otp` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

ในการตรวจสอบเหล่านี้ การทำให้รูปแบบต้นทางเป็นมาตรฐานเพียงอย่างเดียวคือการแปลง PPS/POT เป็น `Ppt` สำหรับสตรีมที่ไม่มีชื่อ ตารางอธิบายการระบุรูปแบบ ไม่ได้หมายถึงการคงคุณลักษณะการนำเสนอทุกอย่างระหว่างการแปลง

## **FAQ**

**การบันทึกเป็น ODP จะเปลี่ยนรูปแบบต้นทางของการนำเสนอที่โหลดจาก PPTX หรือไม่?**

ไม่. อินสแตนซ์ที่มีอยู่ยังคงรายงาน `Pptx`. อินสแตนซ์ที่โหลดจากไฟล์ ODP ที่บันทึกไว้จะรายงาน `Odp`.

**สตรีมสามารถแยกการนำเสนอ, สไลด์โชว์, และแม่แบบแบบ legacy ได้เสมอหรือไม่?**

ไม่. PPT, PPS, และ POT ใช้รูปแบบไบนารีเดียวกัน ควรเก็บชื่อไฟล์หรือเมทาดาต้าย่อยแยกไว้เมื่อความแตกต่างนี้จำเป็น

**ควรใช้ API ใดหากการนำเสนอถูกโหลดแล้ว?**

อ่าน [Presentation.SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sourceformat/). ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) สำหรับการตรวจสอบก่อนการโหลด.