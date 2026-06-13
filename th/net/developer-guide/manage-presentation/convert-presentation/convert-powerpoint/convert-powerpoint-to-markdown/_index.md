---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน .NET
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/net/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- งานนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- PowerPoint
- งานนำเสนอ
- Markdown
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint—PPT, PPTX—to Markdown ที่เรียบร้อยด้วย Aspose.Slides สำหรับ .NET, ทำให้การจัดทำเอกสารอัตโนมัติและคงรูปแบบ"
---
## **บทนำ**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็น Markdown ซึ่งเป็นประโยชน์สำหรับกระบวนการทำเอกสาร, การสร้างเว็บไซต์แบบสแตติก, การย้ายเนื้อหา, และการเผยแพร่ข้อความที่ควบคุมเวอร์ชันผ่านระบบควบคุมเวอร์ชัน API รองรับการส่งออกโดยตรงจากงานนำเสนอ PPT และ PPTX ไปเป็นไฟล์ MD และให้ตัวเลือกเพิ่มเติมเพื่อควบคุมวิธีการแสดงเนื้อหาสไลด์ในเอกสาร Markdown ที่ได้

คุณสามารถส่งออกงานนำเสนอเป็น Markdown ธรรมดา, เลือกรสชาติต่างๆ ของ Markdown เช่น CommonMark และ GitHub Flavored Markdown, และกำหนดวิธีการจัดการรูปภาพระหว่างการส่งออก สำหรับงานนำเสนอที่มีเนื้อหาเชิงภาพ Aspose.Slides ยังให้คุณบันทึกรูปภาพลงในโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้น

{{% alert color="warning" %}}
การส่งออก PowerPoint เป็น Markdown **ไม่มีรูปภาพ** ตามค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพ คุณต้องตั้งค่า `ExportType = MarkdownExportType.Visual` และระบุ `BasePath` ซึ่งเป็นตำแหน่งที่รูปภาพที่อ้างอิงในเอกสาร Markdown จะถูกบันทึก
{{% /alert %}}

## **แปลง PowerPoint เป็น Markdown**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อเป็นตัวแทนของอ็อบเจกต์งานนำเสนอ
2. ใช้เมธอด [Save ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save)เพื่อบันทึกอ็อบเจกต์เป็นไฟล์ markdown

โค้ด C# นี้แสดงวิธีแปลง PowerPoint เป็น markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **แปลง PowerPoint เป็นรูปแบบ Markdown**

Aspose.Slides ให้คุณแปลง PowerPoint ไปเป็น markdown (ที่มีไวยากรณ์พื้นฐาน), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab และรูปแบบ markdown อื่นๆ อีก 17 รูปแบบ

โค้ด C# นี้แสดงวิธีแปลง PowerPoint ไปเป็น CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

รูปแบบ markdown ทั้งหมด 23 รูปแบบที่รองรับสามารถดูได้จาก [Flavor enumeration](https://reference.aspose.com/slides/th/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) ของคลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)

## **แปลงงานนำเสนอที่มีรูปภาพเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) ให้คุณตั้งค่าคุณสมบัติและ enumeration ที่ช่วยกำหนดตัวเลือกหรือการตั้งค่าสำหรับไฟล์ markdown ที่ได้ enum [MarkdownExportType](https://reference.aspose.com/slides/th/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) ตัวอย่างเช่น สามารถตั้งค่าเป็นค่า `Sequential`, `TextOnly`, `Visual` เพื่อกำหนดวิธีการแสดงหรือจัดการรูปภาพ

### **แปลงรูปภาพเป็นลำดับ**

หากต้องการให้รูปภาพแสดงเป็นรายการแยกกันต่อเนื่องกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก sequential โค้ด C# นี้แสดงวิธีแปลงงานนำเสนอที่มีรูปภาพเป็น markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **แปลงรูปภาพเป็นแบบภาพ**

หากต้องการให้รูปภาพปรากฏรวมกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก visual  ในกรณีนี้ รูปภาพจะถูกบันทึกลงในไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และจะสร้างเส้นทางสัมพัทธ์สำหรับรูปภาพในเอกสาร markdown) หรือคุณสามารถระบุเส้นทางและชื่อโฟลเดอร์ที่ต้องการได้

โค้ด C# นี้แสดงการทำงาน:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์เทกซ์ยังคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่. ข้อความ [hyperlinks](/slides/th/net/manage-hyperlinks/) จะถูกเก็บไว้เป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/net/slide-transition/) และ [animations](/slides/th/net/powerpoint-animation/) จะไม่ถูกแปลง

**ฉันสามารถเร่งความเร็วการแปลงโดยรันหลายเธรดพร้อมกันได้หรือไม่?**

คุณสามารถทำงานแบบขนานตามไฟล์ได้ แต่อย่า [don’t share](/slides/th/net/multithreading/) อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันข้ามเธรด ใช้อินสแตนซ์หรือกระบวนการแยกตามไฟล์เพื่อหลีกเลี่ยงการแย่งใช้ทรัพยากร

**รูปภาพจะเกิดอะไรขึ้น—บันทึกไว้ที่ไหนและเส้นทางเป็นสัมพัทธ์หรือไม่?**

[Images](/slides/th/net/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะและไฟล์ Markdown จะอ้างอิงด้วยเส้นทางสัมพัทธ์โดยค่าเริ่มต้น คุณสามารถกำหนดฐานเส้นทางการส่งออกและชื่อโฟลเดอร์ assets เพื่อคงโครงสร้าง repo ที่คาดเดาได้