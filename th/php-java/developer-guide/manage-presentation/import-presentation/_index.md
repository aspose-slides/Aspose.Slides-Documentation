---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ด้วย PHP
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/php-java/import-presentation/
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
- PHP
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument ด้วย PHP และ Aspose.Slides เพื่อการประมวลผลสไลด์ที่ราบรื่นและประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/th/php-java/), คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) เพื่อให้คุณนำเข้าการนำเสนอจาก PDF, เอกสาร HTML เป็นต้น

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้คุณจะทำการแปลง PDF เป็นการนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/)
2. เรียกเมธอด [addFromPdf()](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) และส่งไฟล์ PDF เข้าไป
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด PHP นี้แสดงการแปลง PDF ไปเป็น PowerPoint:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="เคล็ดลับ" color="primary" %}} 
คุณอาจต้องการลองใช้แอปเว็บ **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เพราะเป็นการทำงานจริงของกระบวนการที่อธิบายในที่นี้
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้คุณจะทำการแปลงเอกสาร HTML เป็นการนำเสนอ PowerPoint

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/)
2. เรียกเมธอด [addFromHtml()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) และส่งไฟล์ PDF เข้าไป
3. ใช้เมธอด [save()](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#save-java.lang.String-int-) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint

โค้ด PHP นี้แสดงการแปลง HTML ไปเป็น PowerPoint:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ตารางจะถูกเก็บรักษาไว้เมื่อทำการนำเข้า PDF หรือไม่ และการตรวจจับสามารถปรับปรุงได้หรือไม่?**

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfimportoptions/) มีเมธอด [setDetectTables](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfimportoptions/#setDetectTables) ที่เปิดใช้งานการจดจำตาราง ความมีประสิทธิภาพขึ้นอยู่กับโครงสร้างของ PDF

{{% alert title="หมายเหตุ" color="warning" %}} 
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML ไปเป็นรูปแบบไฟล์ที่นิยมอื่นๆ ได้เช่น:
* [HTML to image](https://products.aspose.com/slides/th/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/th/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/th/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/th/php-java/conversion/html-to-tiff/)
{{% /alert %}}