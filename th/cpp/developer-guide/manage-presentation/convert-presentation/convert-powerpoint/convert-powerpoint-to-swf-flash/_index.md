---
title: แปลงงานนำเสนอ PowerPoint เป็น SWF Flash ใน C++
linktitle: PowerPoint ไปเป็น SWF
type: docs
weight: 80
url: /th/cpp/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็น SWF
- การนำเสนอไปเป็น SWF
- สไลด์ไปเป็น SWF
- PPT ไปเป็น SWF
- PPTX ไปเป็น SWF
- PowerPoint ไปเป็น Flash
- การนำเสนอไปเป็น Flash
- สไลด์ไปเป็น Flash
- PPT ไปเป็น Flash
- PPTX ไปเป็น Flash
- บันทึก PPT เป็น SWF
- บันทึก PPTX เป็น SWF
- ส่งออก PPT ไปเป็น SWF
- ส่งออก PPTX ไปเป็น SWF
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ใน C++ ด้วย Aspose.Slides. ตัวอย่างโค้ดทีละขั้นตอน, ผลลัพธ์คุณภาพเร็ว, ไม่ต้องใช้การทำงานอัตโนมัติของ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงการนำเสนอ PowerPoint เป็นไฟล์ SWF ด้วยการใช้ Aspose.Slides โดยจะแสดงวิธีบันทึกการนำเสนอเป็นไฟล์ SWF ด้วยเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) และวิธีกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/), รวมถึงการตั้งค่า viewer และการจัดวางบันทึกย่อหรือคอมเมนต์

## **แปลงการนำเสนอเป็นแฟลช**

เมธอด [Save](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) สามารถใช้เพื่อแปลงการนำเสนอทั้งหมดเป็นเอกสาร SWF คุณยังสามารถรวมคอมเมนต์ใน SWF ที่สร้างขึ้นโดยใช้คลาส [SWFOptions](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.swf_options) และคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอเป็นเอกสาร SWF ด้วยการใช้ตัวเลือกที่มาจากคลาส SWFOptions

``` cpp
// เส้นทางไปยังไดเรกทอรีเอกสาร.
    // สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์การนำเสนอ
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // บันทึกการนำเสนอและหน้าบันทึกย่อ
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่ ใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) ใน [SwfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/) ตามค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ได้รับการส่งออก

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้เมธอด [set_Compressed](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/set_compressed/) และปรับ [JPEG quality](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/set_jpegquality/) เพื่อสมดุลขนาดไฟล์และความคมชัดของภาพ

**'set_ViewerIncluded' ใช้ทำอะไรและควรใช้เมื่อใด?**

[set_ViewerIncluded](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) เพิ่ม UI ของผู้เล่นฝัง (ควบคุมการนำทาง, แผง, การค้นหา) ปิดการใช้งานถ้าคุณต้องการใช้ผู้เล่นของคุณเองหรือจำเป็นต้องมีเฟรม SWF เปล่าๆ โดยไม่มี UI

**อะไรจะเกิดขึ้นหากฟอนต์ต้นทางหายไปบนเครื่องที่ทำการส่งออก?**

Aspose.Slides จะสับเปลี่ยนฟอนต์ที่คุณระบุผ่าน [set_DefaultRegularFont](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) ใน [SwfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/swfoptions/) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองโดยไม่ตั้งใจ