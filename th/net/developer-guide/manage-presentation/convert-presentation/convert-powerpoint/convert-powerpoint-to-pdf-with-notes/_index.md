---
title: แปลงงานนำเสนอ PowerPoint ไปเป็น PDF พร้อมบันทึกของวิทยากรใน .NET
linktitle: PowerPoint เป็น PDF พร้อมบันทึกของวิทยากร
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
- บันทึกของวิทยากร
- PDF พร้อมบันทึก
- .NET
- C#
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX ไปเป็น PDF พร้อมบันทึกของวิทยากรโดยใช้ Aspose.Slides สำหรับ .NET. รักษาการจัดรูปแบบและบันทึกของวิทยากรสำหรับการนำเสนอระดับมืออาชีพ."
---
## **Overview**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PDF พร้อมบันทึกของวิทยากรโดยใช้ Aspose.Slides คู่มือฉบับนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้แล้ว คุณจะสามารถ:

- ดำเนินการแปลงเพื่อแปลงสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมคงบันทึกของวิทยากรไว้
- ปรับแต่ง PDF ที่ได้เพื่อให้แน่ใจว่าบันทึกของวิทยากรถูกแทรกและจัดรูปแบบตามความต้องการของคุณ

เพื่อกำหนดขนาดและการวางแนวของหน้าบันทึกก่อนส่งออก ให้ดูที่ [ขนาดหน้าบันทึก](/slides/th/net/notes-size/).

## **Convert PowerPoint to PDF with Notes**

`Save` method ในคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX ไปเป็น PDF พร้อมบันทึกของวิทยากร ด้วย Aspose.Slides คุณเพียงแค่โหลดงานนำเสนอ กำหนดตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมบันทึกของวิทยากร แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึก

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // กำหนดตัวเลือก PDF สำหรับการเรนเดอร์บันทึกของวิทยากร.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // แสดงบันทึกของวิทยากรด้านล่างสไลด์.
        }
    };

    // บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกของวิทยากร.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
คุณอาจต้องการตรวจสอบ Aspose [เครื่องแปลง PowerPoint เป็น PDF ออนไลน์](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}