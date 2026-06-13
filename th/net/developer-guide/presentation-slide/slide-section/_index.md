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
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับกระบวนการส่วนสไลด์ใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET — แบ่ง, เปลี่ยนชื่อ, และจัดเรียงใหม่เพื่อเพิ่มประสิทธิภาพการทำงานของ PPTX และ ODP."
---
## **Introduction**

ด้วย Aspose.Slides for .NET คุณสามารถจัดระเบียบการนำเสนอ PowerPoint ให้เป็นส่วน ๆ ได้ คุณสามารถสร้างส่วนที่บรรจุสไลด์เฉพาะได้  

คุณอาจต้องการสร้างส่วนและใช้มันเพื่อจัดระเบียบหรือแยกสไลด์ในงานนำเสนอเป็นส่วนตรรกะในสถานการณ์ต่อไปนี้:

- เมื่อคุณทำงานบนการนำเสนอใหญ่กับคนอื่นหรือทีม — และต้องการมอบหมายสไลด์บางส่วนให้กับเพื่อนร่วมงานหรือสมาชิกทีม  
- เมื่อคุณกำลังจัดการการนำเสนอที่มีสไลด์จำนวนมาก — และคุณประสบปัญหาในการจัดการหรือแก้ไขเนื้อหาทั้งหมดพร้อมกัน  

โดยแนวคิดที่ดี คุณควรสร้างส่วนที่บรรจุสไลด์ที่คล้ายกัน — สไลด์มีสิ่งที่ร่วมกันหรือสามารถอยู่ในกลุ่มตามกฎ — และตั้งชื่อส่วนให้บรรยายสไลด์ภายในนั้น  

## **Create Sections in Presentations**

เพื่อเพิ่มส่วนที่บรรจุสไลด์ในงานนำเสนอ Aspose.Slides for .NET มีเมธอด AddSection ที่ให้คุณระบุชื่อของส่วนที่ต้องการสร้างและสไลด์ที่ส่วนเริ่มต้นจากนั้น  

โค้ดตัวอย่างนี้แสดงวิธีสร้างส่วนในงานนำเสนอด้วย C#:  

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 จะสิ้นสุดที่ newSlide2 และต่อจากนั้น section2 จะเริ่มต้น   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Change the Names of Sections**

หลังจากที่คุณสร้างส่วนในงานนำเสนอ PowerPoint แล้ว คุณอาจต้องการเปลี่ยนชื่อของมัน  

โค้ดตัวอย่างนี้แสดงวิธีเปลี่ยนชื่อของส่วนในงานนำเสนอด้วย C# โดยใช้ Aspose.Slides:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**  

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.  

**Can an entire section be "hidden"?**  

No. Only individual slides can be hidden. A section as an entity has no "hidden" state.  

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**  

Yes. A section is uniquely defined by its starting slide; given a slide you can determine which section it belongs to, and for a section you can access its first slide.  