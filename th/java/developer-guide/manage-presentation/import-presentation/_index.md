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
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument ใน Java ด้วย Aspose.Slides อย่างง่ายดายเพื่อการประมวลผลสไลด์ที่ราบรื่นและประสิทธิภาพสูง"
---
## **บทนำ**

ด้วย Aspose.Slides คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides ให้คลาส [SlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/) ซึ่งช่วยให้คุณนำเข้าการนำเสนอจากเอกสาร PDF และ HTML

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะทำการแปลง PDF เป็นการนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/) 
2. เรียกเมธอด [addFromPdf()](https://reference.aspose.com/slides/th/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) และส่งไฟล์ PDF เข้าไป 
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

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
คุณอาจต้องการลองดูเว็บแอป **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการทำงานจริงของกระบวนการที่อธิบายไว้ที่นี่. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะทำการแปลงเอกสาร HTML เป็นการนำเสนอ PowerPoint

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/) 
2. เรียกเมธอด [addFromHtml()](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) และส่งไฟล์ PDF เข้าไป 
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

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

## **FAQ**

**ตารางจะถูกเก็บรักษาไว้เมื่อทำการนำเข้า PDF หรือไม่ และการตรวจจับสามารถปรับปรุงได้หรือไม่?**

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfimportoptions/) มีเมธอด [setDetectTables](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) ที่เปิดใช้งานการรับรู้ตาราง ความมีประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF

{{% alert title="Note" color="warning" %}} 
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML เป็นรูปแบบไฟล์ยอดนิยมอื่น ๆ: 

* [HTML to image](https://products.aspose.com/slides/th/java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/th/java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/th/java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/th/java/conversion/html-to-tiff/)

{{% /alert %}}