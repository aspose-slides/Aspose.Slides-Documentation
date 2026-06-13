---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ใน .NET
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/net/import-presentation/
keywords:
- นำเข้าการนำเสนอ
- นำเข้าสไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF เป็นการนำเสนอ
- PDF เป็น PPT
- PDF เป็น PPTX
- PDF เป็น ODP
- HTML เป็นการนำเสนอ
- HTML เป็น PPT
- HTML เป็น PPTX
- HTML เป็น ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปสู่การนำเสนอ PowerPoint และ OpenDocument อย่างไม่มีความยากลำบากใน .NET ด้วย Aspose.Slides เพื่อการประมวลผลสไลด์ที่ราบรื่นและมีประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ Aspose.Slides คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้. Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/) ที่ช่วยให้คุณนำเข้าการนำเสนอจากไฟล์ PDF และ HTML

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณสามารถแปลงไฟล์ PDF ไปเป็นงานนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. เรียกเมธอด [AddFromPdf](https://reference.aspose.com/slides/th/net/aspose.slides.slidecollection/addfrompdf/methods/1) และส่งไฟล์ PDF เข้าไป  
3. ใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides.presentation/save/methods/5) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด C# นี้แสดงการทำงานแปลง PDF ไปเป็น PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
คุณอาจต้องการตรวจสอบเว็บแอป **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการทำงานจริงของกระบวนการที่อธิบายไว้ที่นี่. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณสามารถแปลงเอกสาร HTML ไปเป็นงานนำเสนอ PowerPoint

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. เรียกเมธอด [AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) และส่งไฟล์ HTML เข้าไป  
3. ใช้เมธอด [Save](https://apireference.aspose.com/slides/th/net/aspose.slides.presentation/save/methods/5) เพื่อบันทึกไฟล์เป็นเอกสาร PowerPoint

โค้ด C# นี้แสดงการทำงานแปลง HTML ไปเป็น PowerPoint: 

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ตารางจะยังคงอยู่เมื่อนำเข้า PDF หรือไม่ และการตรวจจับสามารถปรับปรุงได้หรือไม่?**

สามารถตรวจจับตารางระหว่างการนำเข้าได้; [PdfImportOptions](https://reference.aspose.com/slides/th/net/aspose.slides.import/pdfimportoptions/) มีพารามิเตอร์ [DetectTables](https://reference.aspose.com/slides/th/net/aspose.slides.import/pdfimportoptions/detecttables/) ที่เปิดใช้งานการรับรู้ตาราง ความแม่นยำขึ้นอยู่กับโครงสร้างของ PDF

{{% alert title="Note" color="warning" %}} 
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML ไปยังรูปแบบไฟล์ที่นิยมอื่นๆ ได้อีกด้วย: 

* [HTML ไปเป็นภาพ](https://products.aspose.com/slides/th/net/conversion/html-to-image/)
* [HTML ไปเป็น JPG](https://products.aspose.com/slides/th/net/conversion/html-to-jpg/)
* [HTML ไปเป็น XML](https://products.aspose.com/slides/th/net/conversion/html-to-xml/)
* [HTML ไปเป็น TIFF](https://products.aspose.com/slides/th/net/conversion/html-to-tiff/)

{{% /alert %}}