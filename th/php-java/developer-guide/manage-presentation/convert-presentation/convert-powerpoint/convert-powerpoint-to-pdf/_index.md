---
title: แปลง PPT และ PPTX เป็น PDF ใน PHP [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/php-java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่ค้นหาได้ใน PHP ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน PHP มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษารูปแบบและการจัดหน้าของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

ในการแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) แล้วบันทัตว์งานนำเสนอเป็น PDF ด้วยเมธอด `save` คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) แสดงเมธอด `save` ที่โดยปกติใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for PHP via Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **Note**ว่าคุณไม่สามารถสั่ง Aspose.Slides ให้เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกแสดงอย่างแม่นยำในการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* หัวกระดาษและท้ายกระดาษ
* สัญลักษณ์หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF โดยใช้การตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
$presentation = new Presentation("PowerPoint.pptx");
try {
    # บันทึกงานนำเสนอเป็น PDF
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose มีตัวแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการนำไปใช้งานจริงของขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง — คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/PdfOptions) — ที่ให้คุณปรับแต่ง PDF ที่ได้, ล็อค PDF ด้วยรหัสผ่าน, หรือระบุวิธีการดำเนินการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาไฟล์ ตั้งระดับการบีบอัดสำหรับข้อความ ปรับค่า DPI สำหรับภาพ และอื่น ๆ

ตัวอย่างโค้ดด้านล่างแสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกแบบกำหนดเองหลายอย่าง.

```php
# สร้างอินสแตนซ์ของคลาส PdfOptions.
$pdfOptions = new PdfOptions();

# ตั้งค่าคุณภาพสำหรับภาพ JPG.
$pdfOptions->setJpegQuality(90);

# ตั้งค่า DPI สำหรับภาพ.
$pdfOptions->setSufficientResolution(300);

# ตั้งค่าการทำงานสำหรับเมตาไฟล์.
$pdfOptions->setSaveMetafilesAsPng(true);

# ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# กำหนดโหมดการปฏิบัติตาม PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Save the presentation as a PDF document.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

ถ้างานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ของคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/PdfOptions) เพื่อใส่สไลด์ที่ซ่อนเป็นหน้าใน PDF ที่ได้

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมรวมสไลด์ที่ซ่อน:
```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # สร้างอินสแตนซ์ของคลาส PdfOptions.
    $pdfOptions = new PdfOptions();

    # เพิ่มสไลด์ที่ซ่อนอยู่.
    $pdfOptions->setShowHiddenSlides(true);

    # บันทึกงานนำเสนอเป็น PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/) :
```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # สร้างอินสแตนซ์ของคลาส PdfOptions.
    $pdfOptions = new PdfOptions();

    # ตั้งรหัสผ่าน PDF และกำหนดสิทธิ์การเข้าถึง.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # บันทึกงานนำเสนอเป็น PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ดนี้แสดงวิธีการตรวจจับการแทนที่ฟอนต์:
```php
// ตั้งค่าฟังก์ชันคอลแบ็คการแจ้งเตือนในตัวเลือก PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
$presentation = new Presentation("sample.pptx");
try {
    // บันทึกงานนำเสนอเป็น PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [Font Substitution](/slides/th/php-java/font-substitution/)
{{% /alert %}} 

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

โค้ดนี้แสดงวิธีการแปลงเฉพาะสไลด์ที่เลือกจากงานนำเสนอ PowerPoint เป็น PDF:
```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # ตั้งค่าอาร์เรย์ของหมายเลขสไลด์.
    $slides = array(1, 3);

    # บันทึกงานนำเสนอเป็น PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
$presentation = new Presentation("SelectedSlides.pptx");

# สร้างงานนำเสนอใหม่โดยปรับขนาดสไลด์.
$resizedPresentation = new Presentation();

try {
    # ตั้งค่าขนาดสไลด์ที่กำหนดเอง.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกย่อ.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองบันทึกย่อของสไลด์**

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อของสไลด์:
```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # กำหนดค่าตัวเลือก PDF ด้วยรูปแบบบันทึกย่อ.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อ.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้ขั้นตอนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ดนี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน:
```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides รองรับการทำงานแปลง PDF ให้เป็นรูปแบบไฟล์ที่นิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-png/) อีกทั้งยังรองรับการแปลง PDF ไปยังรูปแบบพิเศษอื่น ๆ — [PDF to SVG](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/php-java/conversion/pdf-to-xml/) — ด้วย
{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว องค์ประกอบเส้นทางแยกต่างหากจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นศิลปวัตถุ; ข้อความแทนที่จะให้เฉพาะกับรูปทั้งหมดเท่านั้น.

## **คำถามที่พบบ่อย**

**สามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF อย่างเป็นกลุ่มได้หรือไม่?**  
ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปผ่านไฟล์ของคุณและใช้กระบวนการแปลงแบบโปรแกรมได้

**สามารถตั้งรหัสผ่านป้องกัน PDF ที่แปลงแล้วได้หรือไม่?**  
แน่นอน. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**จะใส่สไลด์ที่ซ่อนใน PDF อย่างไร?**  
ใช้เมธอด `setShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/) เพื่อใส่สไลด์ที่ซ่อนใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ใช่, คุณสามารถควบคุมคุณภาพของภาพโดยใช้เมธอดเช่น `setJpegQuality` และ `setSufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ใช่, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for PHP via Java](/slides/th/php-java/)
- [อ้างอิง API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/th/php-java/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion)