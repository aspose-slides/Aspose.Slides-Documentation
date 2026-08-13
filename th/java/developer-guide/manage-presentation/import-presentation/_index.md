---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ใน Java
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/java/import-presentation/
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
- Java
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument ใน Java อย่างง่ายดายด้วย Aspose.Slides เพื่อการประมวลผลสไลด์ที่ราบรื่นและมีประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ Aspose.Slides คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/) ซึ่งช่วยให้คุณนำเข้าการนำเสนอจากเอกสาร PDF และ HTML

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะทำการแปลง PDF เป็นการนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/) 
2. เรียกเมธอด [addFromPdf()](https://reference.aspose.com/slides/th/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) และส่งไฟล์ PDF 
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด Java นี้แสดงการดำเนินการแปลง PDF เป็น PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
คุณอาจต้องการลองใช้แอปเว็บ **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการนำไปใช้จริงของกระบวนการที่อธิบายไว้ที่นี่. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะทำการแปลงเอกสาร HTML เป็นการนำเสนอ PowerPoint

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/) 
2. เรียกเมธอด [addFromHtml()](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) และส่งสตรีมที่มีเอกสาร HTML 
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด Java นี้แสดงการดำเนินการแปลง HTML เป็น PowerPoint: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

### ตารางจะถูกคงไว้เมื่อนำเข้า PDF หรือไม่ และการตรวจจับของพวกมันสามารถปรับปรุงได้หรือไม่?

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfimportoptions/) มีเมธอด [setDetectTables](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) ที่เปิดใช้งานการจดจำตาราง ประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF.

{{% alert title="Note" color="warning" %}} 
คุณอาจใช้ Aspose.Slides เพื่อแปลง HTML ไปเป็นรูปแบบไฟล์ที่นิยมอื่น ๆ: 

* [HTML เป็นรูปภาพ](https://products.aspose.com/slides/th/java/conversion/html-to-image/)
* [HTML เป็น JPG](https://products.aspose.com/slides/th/java/conversion/html-to-jpg/)
* [HTML เป็น XML](https://products.aspose.com/slides/th/java/conversion/html-to-xml/)
* [HTML เป็น TIFF](https://products.aspose.com/slides/th/java/conversion/html-to-tiff/)

{{% /alert %}}