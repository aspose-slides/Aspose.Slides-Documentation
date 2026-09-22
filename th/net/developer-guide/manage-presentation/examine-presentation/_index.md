---
title: ดึงข้อมูลและอัปเดตข้อมูลพรีเซนต์เทชั่นใน .NET
linktitle: ข้อมูลพรีเซนต์เทชั่น
type: docs
weight: 30
url: /th/net/examine-presentation/
keywords:
- รูปแบบพรีเซนต์เทชั่น
- คุณสมบัตพรีเซนต์เทชั่น
- คุณสมบัติเอกสาร
- ดึงคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- พรีเซนต์เทชั่น
- .NET
- C#
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาต้าในพรีเซนต์เทชั่น PowerPoint และ OpenDocument ด้วย .NET เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของพรีเซนต์เทชั่นและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุพรีเซนต์เทชั่นเต็มรูปแบบ นี่เป็นประโยชน์เมื่อคุณต้องการจำแนกไฟล์ สร้างรายการสต็อก หรือสอบถามคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาพรีเซนต์เทชั่นหรือไม่

บทความนี้แสดงการตรวจสอบแบบน้ำหนักเบาผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) พร้อมกับการอัปเดตแบบเจาะจงผ่าน [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/)  

## **ตรวจสอบรูปแบบพรีเซนต์เทชั่น**

หากคุณมีพรีเซนต์เทชั่นที่โหลดแล้วแล้ว ให้ดู [กำหนดรูปแบบพรีเซนต์เทชั่นดั้งเดิม](/slides/th/net/detect-presentation-source-format/) สำหรับการตรวจจับหลังการโหลดและข้อจำกัดของสตรีม PPT, PPS, และ POT แบบเก่า

ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อสอบถามไฟล์โดยไม่ต้องสร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) อินสแตนซ์ คุณสมบัติ [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/loadformat/) รายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP  

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **สร้างรายการพรีเซนต์เทชั่นแบบน้ำหนักเบา**

เมื่อคุณต้องประมวลผลไฟล์พรีเซนต์เทชั่นจำนวนมาก คุณอาจต้องการรายการสต็อกที่กะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในสถานการณ์นี้ ให้ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อรับอ็อบเจกต์ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) แล้วเรียก [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้ไม่ได้สร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) หรือบังคับให้คุณเดินทางผ่านโมเดลวัตถุพรีเซนต์เทชั่นเต็มรูปแบบ

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) ให้ค่ารายการต่อไปนี้:

| คุณสมบัติ | ค่ารายการ |
| --- | --- |
| [สไลด์](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/slides/th/) | จำนวนสไลด์ทั้งหมด |
| [HiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/hiddenslides/) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [Notes](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/notes/) | จำนวนสไลด์ที่มีบันทึก |
| [Paragraphs](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/paragraphs/) | จำนวนย่อหน้าทั้งหมด (ถ้ามี) |
| [Words](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/words/) | จำนวนคำทั้งหมด |
| [MultimediaClips](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/multimediaclips/) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าที่กล่าวถึงโดยไม่สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วพิมพ์รายการสต็อกที่กะทัดรัด นอกจากนี้ยังรวม [HeadingPairs](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/headingpairs/) กับ [TitlesOfParts](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/titlesofparts/) เพื่อแสดงกลุ่มเนื้อหา เช่น แบบอักษร ธีม และชื่อสไลด์  

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

แต่ละ [IHeadingPair](https://reference.aspose.com/slides/th/net/aspose.slides/iheadingpair/) จะให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/titlesofparts/) เป็นอาเรย์เรียงลำดับแบบแบน ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละหัวข้อระบุ  

### **เมทาดาต้าจัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติสต็อกที่คืนค่าจาก [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) สะท้อนเมตาดาต้าที่มีในเอกสารต้นฉบับ Aspose.Slides ไม่ได้โหลดและเดินทางผ่านโมเดลวัตถุพรีเซนต์เทชั่นเพื่อคำนวณค่าใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายไปจะแสดงเป็นค่าตัดตั้งค่าเริ่มต้น และค่าที่เก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และคลิปมัลติมีเดีย รวมถึงคู่หัวข้อและชื่อส่วน ความพร้อมใช้งานขึ้นอยู่กับว่าผู้ผลิตเอกสารเขียนคุณสมบัติเหล่านี้หรือไม่  
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติบางอย่างไม่มีหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่เก็บหรือค่าตั้งต้นแทนการคำนวณจากสไลด์  
- **ODP:** เมทาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้า, และคำ แต่ค่าเหล่านี้ไม่สอดคล้องกับคุณสมบัติเพิ่มเติมเฉพาะ PowerPoint อย่างสไลด์ที่ซ่อน, สไลด์โน้ต, มัลติมีเดีย, คู่หัวข้อ, และชื่อส่วน อาจไม่มีเมทาดาต้าเหล่านี้และคุณสมบัติสต็อกอาจคืนค่าตั้งต้น อย่าถือว่าค่าเป็นศูนย์หรืออาเรย์ว่างเป็นหลักฐานที่แน่นอนว่เนื้อหาที่สอดคล้องไม่มีอยู่  

ใช้วิธีเมทาดาต้าน้ำหนักเบาสำหรับการสร้างรายการสต็อกและการตรวจสอบเบื้องต้น โหลดพรีเซนต์เทชั่นและตรวจสอบโมเดลวัตถุแบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องยืนยันเนื้อหาจริงของพรีเซนต์เทชั่น  

## **อัปเดตคุณสมบัติการพรีเซนต์เทชั่น**

คุณสมบัติที่คืนค่าจาก [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ใด ๆ ใช้ [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) เพื่อทำการเปลี่ยนแปลง แล้วเขียนพรีเซนต์เทชั่นที่ผูกไว้ด้วย [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/writebindedpresentation/)  

ภาพต่อไปนี้แสดงคุณสมบัติดั้งเดิมของเอกสาร  

![Original document properties of the PowerPoint presentation](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาที่บันทึกครั้งสุดท้าย แล้วเขียนผลลัพธ์ไปยังไฟล์ใหม่:  

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่เปลี่ยนแปลงของพรีเซนต์เทชั่น PowerPoint  

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยที่เกี่ยวข้องและการตั้งค่าการปกป้อง ให้ดูบทความต่อไปนี้  

- [ป้องกันพรีเซนต์เทชั่นด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/)  
- [ป้องกันการเขียนพรีเซนต์เทชั่น](/slides/th/net/write-protected-presentation/)  

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังหรือไม่และเป็นแบบใดบ้าง?**  

โหลดพรีเซนต์เทชั่นและใช้ [Presentation.FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/fontsmanager/) เรียก [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อรับแบบอักษรที่ฝังอยู่ และ [FontsManager.GetFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getfonts/) เพื่อรับแบบอักษรที่พรีเซนต์เทชั่นใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาแบบอักษรที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝัง  

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และมีจำนวนเท่าไหร่?**  

เมื่อเมทาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/hiddenslides/) ผ่าน [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) และ [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) ซึ่งเหมาะกับการทำรายการสต็อกแบบน้ำหนักเบา หากพรีเซนต์เทชั่นถูกแก้ไขในหน่วยความจำ เมทาดาต้าอาจหายหรือล้าสมัย หรือคุณต้องตรวจสอบค่าจริงโดยวนผ่าน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) และตรวจสอบคุณสมบัติ [Slide.Hidden](https://reference.aspose.com/slides/th/net/aspose.slides/slide/hidden/) ของแต่ละสไลด์  

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีพารามิเตอร์ขนาดสไลด์และการวางแนวแบบกำหนดเองและว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**  

ได้ โหลดพรีเซนต์เทชั่นและอ่าน [Presentation.SlideSize](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slidesize/) ตรวจสอบ [ISlideSize.Type](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/size/), และ [ISlideSize.Orientation](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/orientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับพรีเซ็ตและขนาดที่คาดหวัง  

**มีวิธีรวดเร็วที่จะตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**  

ได้ หาแต่ละ [Chart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/) แล้วตรวจสอบ [ChartData.DataSourceType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) หากเป็นเวิร์กบุ๊กภายนอก ให้อ่าน [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) ประเภทแหล่งข้อมูลและเส้นทางบ่งบอกถึงการอ้างอิงภายนอก แต่การตรวจสอบว่าไฟล์เป้าหมายพร้อมใช้งานต้องทำแยกต่อไป  

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**  

ไม่มีคุณสมบัติความซับซ้อนเพียงอย่างเดียว ให้เดินทางผ่าน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) และคอลเลกชัน [IBaseSlide.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/shapes/) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการเรนเดอร์หรือส่งออกตัวอย่างเพื่อวัดประสิทธิภาพก่อนสรุปว่าสไลด์เป็นคอขวดของประสิทธิภาพ.