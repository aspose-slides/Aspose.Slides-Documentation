---
title: แปลงงานนำเสนอ PowerPoint เป็น SWF Flash ใน .NET
linktitle: PowerPoint เป็น SWF
type: docs
weight: 80
url: /th/net/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น SWF
- งานนำเสนอเป็น SWF
- สไลด์เป็น SWF
- PPT เป็น SWF
- PPTX เป็น SWF
- PowerPoint เป็น Flash
- งานนำเสนอเป็น Flash
- สไลด์เป็น Flash
- PPT เป็น Flash
- PPTX เป็น Flash
- บันทึก PPT เป็น SWF
- บันทึก PPTX เป็น SWF
- ส่งออก PPT ไปเป็น SWF
- ส่งออก PPTX ไปเป็น SWF
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ใน .NET ด้วย Aspose.Slides ตัวอย่างโค้ด C# ทีละขั้นตอน ผลลัพธ์คุณภาพเร็ว ไม่ต้องใช้การอัตโนมัติของ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น SWF โดยใช้ Aspose.Slides แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ SWF ด้วยเมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) และวิธีกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions/), รวมถึงการตั้งค่าผู้ชมและการจัดรูปแบบโน้ตหรือความคิดเห็น

## **แปลงงานนำเสนอเป็นแฟลช**

เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save/index) ที่เปิดโดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร SWF คุณยังสามารถรวมความคิดเห็นใน SWF ที่สร้างขึ้นโดยใช้คลาส [SWFOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions) และอินเทอร์เฟส [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/inotescommentslayoutingoptions) ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร SWF โดยใช้ตัวเลือกที่ให้โดยคลาส SWFOptions

```c#
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // บันทึกงานนำเสนอและหน้าโน้ต
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่. เปิดใช้งานตัวเลือก [ShowHiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions/showhiddenslides/) ใน [SwfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions/). โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกส่งออก

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้แฟล็ก [Compressed](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions/compressed/) (เปิดใช้งานเป็นค่าดีฟอลต์) และปรับค่า [JpegQuality](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions/jpegquality/) เพื่อสมดุลขนาดไฟล์และความแม่นยำของภาพ

**'ViewerIncluded' มีไว้เพื่ออะไร และควรปิดใช้เมื่อใด?**

[ViewerIncluded](https://reference.aspose.com/slides/th/net/aspose.slides.export/swfoptions/viewerincluded/) เพิ่ม UI ของผู้เล่นในตัว (ควบคุมการนำทาง, แผง, การค้นหา) ปิดใช้งานหากคุณวางแผนจะใช้ผู้เล่นของคุณเองหรือจำเป็นต้องมีเฟรม SWF แบบเปล่าไม่มี UI

**เกิดอะไรขึ้นหากฟอนต์ต้นฉบับหายไปบนเครื่องที่ทำการส่งออก?**

Aspose.Slides จะเปลี่ยนฟอนต์ที่คุณระบุผ่าน [DefaultRegularFont](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/defaultregularfont/) ใน [SwfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/) เพื่อหลีกเลี่ยงการย้อนกลับที่ไม่ต้องการ