---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ด้วย .NET
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/net/import-presentation/
keywords:
- นำเข้าการนำเสนอ
- นำเข้าสไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF ไปยังการนำเสนอ
- PDF ไปยัง PPT
- PDF ไปยัง PPTX
- PDF ไปยัง ODP
- HTML ไปยังการนำเสนอ
- HTML ไปยัง PPT
- HTML ไปยัง PPTX
- HTML ไปยัง ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument ใน .NET ด้วย Aspose.Slides อย่างง่ายดายเพื่อการประมวลผลสไลด์ที่ต่อเนื่องและประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ Aspose.Slides คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/) ที่ช่วยให้คุณนำเข้าการนำเสนอจากเอกสาร PDF และ HTML

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะทำการแปลง PDF เป็นการนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
2. เรียกใช้เมธอด [AddFromPdf](https://reference.aspose.com/slides/th/net/aspose.slides.slidecollection/addfrompdf/methods/1) และส่งไฟล์ PDF เข้าไป 
3. ใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides.presentation/save/methods/5) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด C# ตัวอย่างนี้แสดงการแปลง PDF เป็น PowerPoint:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
คุณอาจต้องการตรวจสอบแอปเว็บ **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการนำไปใช้จริงของกระบวนการที่อธิบายไว้ที่นี่. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะทำการแปลงเอกสาร HTML เป็นการนำเสนอ PowerPoint

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
2. เรียกใช้เมธอด [AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) และส่งไฟล์ HTML เข้าไป 
3. ใช้เมธอด [Save](https://apireference.aspose.com/slides/th/net/aspose.slides.presentation/save/methods/5) เพื่อบันทึกไฟล์เป็นเอกสาร PowerPoint

โค้ด C# ตัวอย่างนี้แสดงการแปลง HTML เป็น PowerPoint: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### ตารางจะถูกคงไว้เมื่อนำเข้า PDF หรือไม่ และการตรวจจับสามารถปรับปรุงได้หรือไม่?

สามารถตรวจจับตารางได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/net/aspose.slides.import/pdfimportoptions/) มีพารามิเตอร์ [DetectTables](https://reference.aspose.com/slides/th/net/aspose.slides.import/pdfimportoptions/detecttables/) ที่เปิดใช้การรับรู้ตาราง ความมีประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF

{{% alert title="Note" color="warning" %}} 
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML ไปเป็นไฟล์รูปแบบอื่นที่นิยมได้: 

* [HTML เป็นภาพ](https://products.aspose.com/slides/th/net/conversion/html-to-image/)
* [HTML เป็น JPG](https://products.aspose.com/slides/th/net/conversion/html-to-jpg/)
* [HTML เป็น XML](https://products.aspose.com/slides/th/net/conversion/html-to-xml/)
* [HTML เป็น TIFF](https://products.aspose.com/slides/th/net/conversion/html-to-tiff/)

{{% /alert %}}