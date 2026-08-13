---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกใน .NET
linktitle: PowerPoint เป็น PDF พร้อมบันทึก
type: docs
weight: 50
url: /th/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- สไลด์เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกการนำเสนอเป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- บันทึกเสียงผู้พูด
- PDF พร้อมบันทึก
- .NET
- C#
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกโดยใช้ Aspose.Slides สำหรับ .NET. รักษาการจัดวางและบันทึกเสียงผู้พูดสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกเสียงผู้พูดโดยใช้ Aspose.Slides คู่มือฉบับนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำภารกิจนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้ คุณจะสามารถ:

- ดำเนินการขั้นตอนการแปลงเพื่อแปลงสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมรักษาบันทึกเสียงผู้พูดไว้
- ปรับแต่งไฟล์ PDF ที่สร้างขึ้นเพื่อให้บันทึกเสียงผู้พูดถูกรวมและจัดรูปแบบตามความต้องการของคุณ

## **แปลง PowerPoint เป็น PDF พร้อมบันทึก**

`Save` เมธอดในคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) สามารถใช้เพื่อแปลงการนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกเสียงผู้พูด ด้วย Aspose.Slides คุณเพียงโหลดการนำเสนอ ตั้งค่าตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมบันทึกเสียงผู้พูด แล้วบันทึกไฟล์เป็น PDF โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอแบบตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึก

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // กำหนดตัวเลือก PDF สำหรับการแสดงบันทึกเสียงผู้พูด.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // แสดงบันทึกเสียงผู้พูดด้านล่างสไลด์.
        }
    };

    // บันทึกการนำเสนอเป็น PDF พร้อมบันทึกเสียงผู้พูด.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
คุณอาจต้องการตรวจสอบ Aspose [เครื่องแปลง PowerPoint เป็น PDF ออนไลน์](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}