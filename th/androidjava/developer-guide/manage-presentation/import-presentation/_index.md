---
title: นำเข้าผลงานนำเสนอจาก PDF หรือ HTML บน Android
linktitle: นำเข้าผลงานนำเสนอ
type: docs
weight: 60
url: /th/androidjava/import-presentation/
keywords:
- นำเข้าผลงานนำเสนอ
- นำเข้าสไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF ไปยังผลงานนำเสนอ
- PDF ไปยัง PPT
- PDF ไปยัง PPTX
- PDF ไปยัง ODP
- HTML ไปยังผลงานนำเสนอ
- HTML ไปยัง PPT
- HTML ไปยัง PPTX
- HTML ไปยัง ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java และ Aspose.Slides สำหรับ Android เพื่อการประมวลผลสไลด์ที่ราบรื่นและประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/th/androidjava/), คุณสามารถนำเข้าไฟล์งานนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/) เพื่อให้คุณนำเข้าไฟล์งานนำเสนอจาก PDF, เอกสาร HTML ฯลฯ.

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะได้แปลงไฟล์ PDF เป็นงานนำเสนอ PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/)
2. เรียกเมธอด [addFromPdf()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) และส่งไฟล์ PDF
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

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
คุณอาจต้องการตรวจสอบแอปเว็บ **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เนื่องจากเป็นการนำกระบวนการที่อธิบายไว้ที่นี่ไปใช้แบบสด 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะได้แปลงเอกสาร HTML เป็นงานนำเสนอ PowerPoint.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/)
2. เรียกเมธอด [addFromHtml()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) และส่งสตรีมที่มีเอกสาร HTML
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

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

### ตารางจะยังคงอยู่เมื่อนำเข้า PDF หรือไม่ และสามารถปรับปรุงการตรวจจับได้หรือไม่?

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfimportoptions/) มีเมธอด [setDetectTables](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) ที่เปิดการจดจำตาราง ความมีประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF