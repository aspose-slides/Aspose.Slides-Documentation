---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน .NET
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/net/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติของเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย .NET เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุของงานนำเสนอเต็มรูปแบบ ซึ่งมีประโยชน์เมื่อคุณต้องการจำแนกไฟล์ สร้างรายการสินค้าคงคลัง หรือตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาของงานนำเสนอหรือไม่

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/), รวมถึงการอัปเดตแบบเจาะจงผ่าน [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/).

## **ตรวจสอบรูปแบบงานนำเสนอ**

ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสมบัติ [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/loadformat/) รายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

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

## **สร้างรายการสินค้าคงคลังงานนำเสนอแบบเบา**

เมื่อคุณต้องประมวลผลไฟล์งานนำเสนอจำนวนมาก คุณอาจต้องการรายการสินค้าคงคลังขนาดกะทัดรัดสำหรับการตรวจสอบ ความสืบค้น หรือระบบจัดการเอกสาร ในสถานการณ์นี้ ใช้ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อรับอ็อบเจ็กต์ [IPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/) แล้วเรียก [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้จะไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) หรือทำให้คุณต้องไล่กราดโมเดลวัตถุของงานนำเสนอทั้งหมด

คุณสมบัติเพิ่มเติมที่เปิดโดย [IDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/) ให้ค่าต่อไปนี้สำหรับรายการสินค้าคงคลัง:

| Property | Inventory value |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/slides/th/) | จำนวนสไลด์ทั้งหมด |
| [HiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/hiddenslides/) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [Notes](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/notes/) | จำนวนสไลด์ที่มีบันทึก |
| [Paragraphs](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/paragraphs/) | จำนวนย่อหน้าโดยรวม (ถ้ามี) |
| [Words](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/words/) | จำนวนคำทั้งหมด |
| [MultimediaClips](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/multimediaclips/) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ใด ๆ และพิมพ์รายการสินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังรวม [HeadingPairs](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/headingpairs/) กับ [TitlesOfParts](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/titlesofparts/) เพื่อแสดงกลุ่มเนื้อหา เช่น แบบอักษร ธีม และชื่อสไลด์

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

แต่ละ [IHeadingPair](https://reference.aspose.com/slides/th/net/aspose.slides/iheadingpair/) ให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/titlesofparts/) เป็นอาเรย์แบนลำดับเดียว ดังนั้นจึงต้องใช้จำนวนชื่อต่อเนื่องที่ระบุโดยแต่ละ heading pair

### **เมตาดาต้าจัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติรายการสินค้าคงคลังที่คืนค่าจาก [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) สะท้อนเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและไล่กราดโมเดลวัตถุของงานนำเสนอเพื่อคำนวณค่าเหล่านี้ใหม่ในครั้งนี้ คุณสมบัติที่ขาดหายจะถูกแทนที่ด้วยค่าดีฟอลต์ และค่าที่จัดเก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ล่าสุดไม่ได้อัปเดตคุณสมบัติเบื้องต้นของเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, หมายเหตุ, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าผู้ผลิตเอกสารได้เขียนคุณสมบัติเหล่านั้นหรือไม่
- **PPT:** รูปแบบไบนารีสามารถจัดเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติหายหรือไม่ได้รับการอัปเดตโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าเริ่มต้นแทนการคำนวณจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้า, และคำ แต่ค่าดังกล่าวไม่สอดคล้องกับคุณสมบัติเพิ่มเติมของ PowerPoint ทุกอย่าง เมตาดาต้าเกี่ยวกับสไลด์ที่ซ่อน, สไลด์บันทึก, มัลติมีเดีย, heading‑pair และ part‑title อาจไม่มีให้ใช้งาน และคุณสมบัติรายการสินค้าคงคลังอาจคืนค่าเริ่มต้น อย่าพิจารณาค่า 0 หรืออาเรย์ว่างเป็นหลักฐานที่แน่นอนว่าข้อมูลดังกล่าวไม่มี

ใช้วิธีการเมตาดาต้าแบบเบาสำหรับการสร้างรายการสินค้าคงคลังและการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุแบบเรียลไทม์เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการตรวจสอบเนื้อหาจริงของงานนำเสนอ

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่คืนค่าจาก [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) แล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/writebindedpresentation/)

ภาพต่อไปนี้แสดงคุณสมบัติดั้งเดิมของเอกสารการนำเสนอ PowerPoint

![คุณสมบัติดั้งเดิมของเอกสารการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาการบันทึกล่าสุดและเขียนผลลัพธ์ไปยังไฟล์ใหม่:

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

ภาพต่อไปนี้แสดงคุณสมบัติของเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint

![คุณสมบัติของเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง โปรดดูบทความต่อไปนี้:

- [การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอ](/slides/th/net/password-protected-presentation/)
- [การป้องกันการเขียนสำหรับงานนำเสนอ](/slides/th/net/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังอยู่และเป็นแบบไหนบ้าง?**

โหลดงานนำเสนอและใช้ [Presentation.FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/fontsmanager/). เรียก [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อรับแบบอักษรที่ฝังอยู่และ [FontsManager.GetFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getfonts/) เพื่อรับแบบอักษรที่งานนำใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหารูปแบบอักษรที่จำเป็นสำหรับการแสดงผลแต่ไม่ได้ฝังไว้

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไหร่?**

เมื่อเมตาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/hiddenslides/) ผ่าน [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/getpresentationinfo/) และ [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationinfo/readdocumentproperties/) ซึ่งเหมาะกับการทำรายการสินค้าคงคลังแบบเบา หากงานนำเสนอได้รับการแก้ไขในหน่วยความจำ เมตาดาต้าอาจหายหรือล้าสมัย หรือคุณต้องการตรวจสอบค่าจริง ให้วนลูปผ่าน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) และตรวจสอบคุณสมบัติ [Slide.Hidden](https://reference.aspose.com/slides/th/net/aspose.slides/slide/hidden/) ของแต่ละสไลด์แทน

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวทางสไลด์ที่กำหนดเองและว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้ โหลดงานนำเสนอและอ่าน [Presentation.SlideSize](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slidesize/). ตรวจสอบ [ISlideSize.Type](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/size/), และ [ISlideSize.Orientation](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/orientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าพรีเซ็ตและมิติที่คาดหวัง

**มีวิธีเร็ว ๆ เพื่อดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้ ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/) และตรวจสอบ [ChartData.DataSourceType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/). สำหรับเวิร์กบุ๊กภายนอก อ่าน [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/). ประเภทแหล่งข้อมูลและเส้นทางบ่งบอกถึงการอ้างอิงภายนอก แต่การตรวจสอบว่าเป้าหมายพร้อมใช้งานต้องทำการตรวจสอบทรัพยากรเพิ่มเติม

**ฉันจะประเมินสไลด์ที่ "หนัก" ซึ่งอาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเดียวที่บ่งบอก ใช้การไล่กราด [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) และคอลเลกชัน [IBaseSlide.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/shapes/) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนสรุปว่าสไลด์เป็นคอขวดของประสิทธิภาพอย่างแน่นอน