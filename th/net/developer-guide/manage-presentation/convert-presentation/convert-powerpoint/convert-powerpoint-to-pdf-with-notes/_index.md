---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตใน .NET
linktitle: PowerPoint เป็น PDF พร้อมโน้ต
type: docs
weight: 50
url: /th/net/convert-powerpoint-to-pdf-with-notes/
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
- โน้ตผู้บรรยาย
- PDF พร้อมโน้ต
- .NET
- C#
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ .NET. รักษาเค้าโครงและโน้ตผู้บรรยายสำหรับงานนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกเสียงโดยใช้ Aspose.Slides คู่มือนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านครบแล้วคุณจะสามารถ:

- ดำเนินการแปลงเพื่อแปลงสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมคงบันทึกเสียงไว้
- ปรับแต่ง PDF ที่สร้างออกมาให้บันทึกเสียงถูกใส่และจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

เมธอด `Save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) สามารถใช้ในการแปลงงานนำเสนอ PPT หรือ PPTX ให้เป็น PDF พร้อมบันทึกเสียงได้ ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ ตั้งค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมบันทึกเสียง แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้สาธิตวิธีแปลงงานนำเสนอตัวอย่างเป็น PDF ในมุมมองสไลด์โน้ต

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // กำหนดค่าตัวเลือก PDF สำหรับการเรนเดอร์โน้ตผู้บรรยาย.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // เรนเดอร์โน้ตผู้บรรยายใต้สไลด์.
        }
    };

    // บันทึกงานนำเสนอเป็น PDF พร้อมโน้ตผู้บรรยาย.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}