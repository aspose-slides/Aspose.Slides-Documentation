---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตใน C++
linktitle: PowerPoint เป็น PDF พร้อมโน้ต
type: docs
weight: 50
url: /th/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- สไลด์เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกงานนำเสนอเป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- โน้ตผู้พูด
- PDF พร้อมโน้ต
- C++
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ C++. รักษาการจัดวางและโน้ตผู้พูดสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมโน้ตผู้พูดโดยใช้ Aspose.Slides คู่มือฉบับนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบท้ายบทความคุณจะสามารถ:

- ดำเนินการแปลงเพื่อเปลี่ยนสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมรักษาโน้ตผู้พูดไว้
- ปรับแต่ง PDF ที่ได้เพื่อให้โน้ตผู้พูดถูกรวมและจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

เมธอด `Save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) สามารถใช้แปลงงานนำเสนอ PPT หรือ PPTX ไปเป็น PDF พร้อมโน้ตผู้พูดได้ ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ กำหนดค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมโน้ตผู้พูด แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอตัวอย่างเป็น PDF ในมุมมองสไลด์โน้ต

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// กำหนดค่าตัวเลือก PDF สำหรับการแสดงโน้ตผู้พูด.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // แสดงโน้ตผู้พูดด้านล่างสไลด์.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 

{{% /alert %}}