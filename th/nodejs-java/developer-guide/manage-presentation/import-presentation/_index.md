---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ใน JavaScript
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js เพื่อการประมวลผลสไลด์ที่ต่อเนื่องและมีประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/th/nodejs-java/), คุณสามารถนำเข้าไฟล์พรีเซนเทชันจากรูปแบบไฟล์อื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) เพื่อให้คุณนำเข้าไฟล์พรีเซนเทชันจาก PDF, เอกสาร HTML ฯลฯ.

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะทำการแปลง PDF ไปเป็นพรีเซนเทชัน PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/).
2. เรียกใช้เมธอด [addFromPdf()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) และส่งไฟล์ PDF
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด JavaScript นี้แสดงการทำงานการแปลง PDF ไปเป็น PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 
คุณอาจต้องการตรวจสอบแอปเว็บ **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการใช้จริงของกระบวนการที่อธิบายไว้ที่นี่. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะทำการแปลงเอกสาร HTML ไปเป็นพรีเซนเทชัน PowerPoint.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/).
2. เรียกใช้เมธอด [addFromHtml()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) และส่งไฟล์ PDF
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด JavaScript นี้แสดงการทำงานการแปลง HTML ไปเป็น PowerPoint:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ตารางจะยังคงอยู่เมื่อทำการนำเข้า PDF หรือไม่ และการตรวจจับตารางสามารถปรับปรุงได้หรือไม่?**

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfimportoptions/) มีเมธอด [setDetectTables](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) ที่เปิดใช้งานการจดจำตาราง ประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF.