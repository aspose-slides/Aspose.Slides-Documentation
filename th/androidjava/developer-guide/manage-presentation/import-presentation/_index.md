---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML บน Android
linktitle: นำเข้า งานนำเสนอ
type: docs
weight: 60
url: /th/androidjava/import-presentation/
keywords:
- นำเข้าการนำเสนอ
- นำเข้า สไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF ไปยัง การนำเสนอ
- PDF ไปยัง PPT
- PDF ไปยัง PPTX
- PDF ไปยัง ODP
- HTML ไปยัง การนำเสนอ
- HTML ไปยัง PPT
- HTML ไปยัง PPTX
- HTML ไปยัง ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ในภาษา Java เพื่อการประมวลผลสไลด์ที่ต่อเนื่องและมีประสิทธิภาพสูง"
---
## **บทนำ**

Using [**Aspose.Slides สำหรับ Android ผ่าน Java**](https://products.aspose.com/slides/th/androidjava/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะทำการแปลงไฟล์ PDF เป็นงานนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/) .
2. เรียกใช้เมธอด [addFromPdf()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) และส่งไฟล์ PDF .
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint .

This Java code demonstrates the PDF to PowerPoint operation:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
คุณอาจต้องการตรวจสอบเว็บแอป **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการทำงานแบบสดของกระบวนการที่อธิบายไว้ที่นี่. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะทำการแปลงเอกสาร HTML เป็นงานนำเสนอ PowerPoint.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/) .
2. เรียกใช้เมธอด [addFromHtml()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) และส่งไฟล์ HTML .
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint .

This Java code demonstrates the HTML to PowerPoint operation: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ตารางจะถูกคงไว้เมื่อทำการนำเข้า PDF หรือไม่ และการตรวจจับสามารถปรับปรุงได้หรือไม่?**

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfimportoptions/) มีเมธอด [setDetectTables](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) ที่เปิดใช้งานการรู้จำตาราง. ประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF.