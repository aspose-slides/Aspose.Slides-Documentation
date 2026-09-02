---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย .NET
linktitle: ส่วนสไลด์
type: docs
weight: 100
url: /th/net/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ของส่วน
- ประมวลผลสไลด์ของส่วน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides สำหรับ .NET: สร้าง, เปลี่ยนชื่อ, เรียงลำดับใหม่, ดึงข้อมูล, และประมวลผลสไลด์ของส่วนในงานนำเสนอ PPTX."
---
## **คำนำ**

Sections จัดระเบียบสไลด์ต่อเนื่องให้เป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนเนื้อหาของสไลด์. ด้วย Aspose.Slides for .NET คุณสามารถสร้าง, เรียงลำดับใหม่, เปลี่ยนชื่อ, ตรวจสอบ, และลบส่วนได้ผ่านคุณสมบัติ [Presentation.Sections](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sections/) 

Sections มีประโยชน์เป็นพิเศษเมื่อ:

- การนำเสนอขนาดใหญ่ต้องการแบ่งเป็นหัวข้อหรือบทที่มีตรรกะ;
- กลุ่มสไลด์ต่าง ๆ ถูกมอบหมายให้กับผู้ร่วมงานคนต่างกัน;
- สไลด์ต้องได้รับการประมวลผล, ย้าย, หรือรวมเป็นกลุ่ม.

เลือกชื่อส่วนที่สั้นกระชับและอธิบายวัตถุประสงค์ของสไลด์ที่รวมกัน. เนื่องจากส่วนเป็นส่วนหนึ่งของโครงสร้างการนำเสนอ, ควรใช้ API ของส่วนเพื่อระบุสมาชิกแทนการคำนวณจากตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

ใช้ [ISectionCollection.AddSection](https://reference.aspose.com/slides/th/net/aspose.slides/sectioncollection/addsection/) เพื่อสร้างส่วนโดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides จะกำหนดสไลด์ที่เป็นของส่วนจากโครงสร้างส่วนปัจจุบันของการนำเสนอ.

[ISectionCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isectioncollection/) ยังทำให้คุณสามารถ:

- ย้ายส่วนพร้อมกับสไลด์ของมันโดยใช้ [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/th/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- ลบเฉพาะการกำหนดส่วนด้วย [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/th/net/aspose.slides/sectioncollection/removesection/), ซึ่งจะคงสไลด์ไว้;
- ลบส่วนพร้อมกับสไลด์ของมันด้วย [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/th/net/aspose.slides/sectioncollection/removesectionwithslides/);
- เพิ่มส่วนเปล่าที่ท้ายด้วย [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/th/net/aspose.slides/sectioncollection/appendemptysection/).

ตัวอย่างต่อไปนี้สร้างสองส่วน, ย้ายหนึ่งส่วน, ลบมันพร้อมกับสไลด์, และเพิ่มส่วนเปล่า:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

หลังจากการดำเนินการเหล่านี้ การนำเสนอจะมีส่วน `Introduction` พร้อมสไลด์ของมันและส่วนเปล่า `Appendix`. ส่วน `Results` และสไลด์ของมันถูกลบออกแล้ว.

## **เปลี่ยนชื่อส่วน**

เพื่อเปลี่ยนชื่อส่วน, ตั้งค่าคุณสมบัติ [ISection.Name](https://reference.aspose.com/slides/th/net/aspose.slides/isection/name/) ของส่วน. สไลด์และตำแหน่งของส่วนจะไม่เปลี่ยนแปลง.

ตัวอย่างต่อไปนี้สร้างส่วนหนึ่งและเปลี่ยนชื่อของมัน:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **ดึงสไลด์จากส่วน**

คุณสมบัติ [Presentation.Sections](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sections/) คืนค่า [ISectionCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isectioncollection/) ที่คุณสามารถวนลูปได้. สำหรับแต่ละ [ISection](https://reference.aspose.com/slides/th/net/aspose.slides/isection/), เรียก [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/th/net/aspose.slides/isection/getslideslistofsection/) เพื่อรับสไลด์ที่อยู่ในส่วนขณะนั้น. วิธีนี้คืนค่า [ISectionSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isectionslidecollection/), ซึ่งให้จำนวน, การเข้าถึงแบบดัชนี, และการวนลูป.

ตัวอย่างต่อไปนี้สร้างสองส่วนที่มีสไลด์และส่วนเปล่าหนึ่งส่วน, แล้วพิมพ์ [ชื่อ](https://reference.aspose.com/slides/th/net/aspose.slides/isection/name/), [ตัวระบุ](https://reference.aspose.com/slides/th/net/aspose.slides/isection/sectionid/), [สไลด์เริ่มต้น](https://reference.aspose.com/slides/th/net/aspose.slides/isection/startedfromslide/), จำนวนสไลด์, และหมายเลขสไลด์ของแต่ละส่วน. ใช้ดัชนีของคอลเลกชันเพื่ออ่านสไลด์แรกและ `foreach` เพื่อประมวลผลทุกสไลด์. สำหรับส่วนเปล่า, คอลเลกชันที่คืนค่ามีจำนวนเป็นศูนย์, ไม่ได้เข้าถึงดัชนี, และการวนลูปไม่มีการทำซ้ำใด ๆ.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

การเป็นสมาชิกของส่วนกำหนดโดยโครงสร้างส่วนของการนำเสนอ. อย่าคำนวณช่วงของส่วนด้วยตนเองจาก [ISection.StartedFromSlide](https://reference.aspose.com/slides/th/net/aspose.slides/isection/startedfromslide/), ดัชนีสไลด์, และสไลด์เริ่มต้นของส่วนถัดไป.

การแก้ไขเชิงโครงสร้างอาจเปลี่ยนทั้งสไลด์ที่คืนค่าให้กับส่วนและหมายเลขสไลด์ของพวกมัน. รวมถึงการเรียงลำดับสไลด์ใหม่, การคัดลอกสไลด์ไปยังส่วน, การย้ายส่วนพร้อมสไลด์, การลบสไลด์, และการลบส่วน. ตัวอย่างต่อไปนี้เรียก [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/th/net/aspose.slides/isection/getslideslistofsection/) หลังการเปลี่ยนแปลงแต่ละครั้งแทนการเก็บสมมติฐานเกี่ยวกับขอบเขตเดิมของส่วน.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

เรียก [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/th/net/aspose.slides/isection/getslideslistofsection/) อีกครั้งทุกครั้งที่สไลด์หรือส่วนถูกเรียงลำดับใหม่, คัดลอก, ย้าย, หรือลบ. วิธีนี้ทำให้การประมวลผลถัดไปสอดคล้องกับโครงสร้างการนำเสนอปัจจุบัน.

รูปแบบ PPT (PowerPoint 97–2003) ไม่เก็บเมตาดาต้าของส่วน. ใช้ขั้นตอนนี้กับรูปแบบที่รองรับส่วน, เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้างส่วนที่จำเป็นสำหรับการวนลูปต่อไป.

## **FAQ**

**ส่วนจะถูกรักษาไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่รองรับเมตาดาต้าของส่วน, ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt.

**สามารถซ่อนส่วนทั้งหมดได้หรือไม่?**

ไม่. ส่วนไม่มีสถานะการมองเห็น. เพื่อซ่อนเนื้อหาให้ตั้งค่าคุณสมบัติ [ISlide.Hidden](https://reference.aspose.com/slides/th/net/aspose.slides/islide/hidden/) สำหรับสไลด์แต่ละสไลด์ในส่วนนั้น.

**ฉันจะหาส่วนที่ประกอบด้วยสไลด์ใดสไลด์หนึ่งได้อย่างไร?**

วนลูป [Presentation.Sections](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sections/), เรียก [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/th/net/aspose.slides/isection/getslideslistofsection/) สำหรับแต่ละส่วน, แล้วเปรียบเทียบสไลด์ที่คืนค่ากับสไลด์เป้าหมาย. สำหรับส่วนที่ไม่ว่าง, [ISection.StartedFromSlide](https://reference.aspose.com/slides/th/net/aspose.slides/isection/startedfromslide/) คืนสไลด์แรก; สำหรับส่วนที่ว่าง, จะคืนค่า `null`.