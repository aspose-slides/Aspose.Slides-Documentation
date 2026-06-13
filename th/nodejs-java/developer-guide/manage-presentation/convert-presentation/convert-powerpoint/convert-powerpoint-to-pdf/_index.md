---
title: แปลง PPT และ PPTX เป็น PDF ด้วย JavaScript [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX ให้เป็น PDF คุณภาพสูง สามารถค้นหาได้ ด้วย Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน JavaScript มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเลย์เอาต์และการจัดรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF, ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพภาพ, รวมสไลด์ที่ซ่อน, ป้องกันไฟล์ PDF ด้วยรหัสผ่าน, ตรวจจับการแทนที่ฟอนต์, เลือกสไลด์ที่ต้องการแปลง, และใช้มาตรฐานการปฏิบัติตามเพื่อเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด `save` คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เปิดเผยเมธอด `save` ที่โดยทั่วไปใช้ในการแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java ใส่ข้อมูล API และหมายเลขเวอร์ชันของมันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่ารูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF ทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและคุณสมบัติต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดหัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint ไปเป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF ด้วยการตั้งค่าที่เหมาะที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ (PPT, PPTX, ODP ฯลฯ) เป็น PDF:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose มี **PowerPoint to PDF converter** ออนไลน์ฟรีที่ https://products.aspose.app/slides/th/conversion/ppt-to-pdf ซึ่งแสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้, ปิดล็อก PDF ด้วยรหัสผ่าน, หรือกำหนดวิธีการแปลงต่อไป

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถระบุการตั้งค่าคุณภาพที่ต้องการสำหรับภาพ raster, กำหนดวิธีจัดการ metafile, ตั้งระดับการบีบอัดสำหรับข้อความ, กำหนด DPI สำหรับภาพ, และอื่น ๆ

ตัวอย่างโค้ดด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกแบบกำหนดเองหลายอย่าง:

```js
// สร้างอินสแตนซ์ของคลาส PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality(java.newByte(90));

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // บันทึกงานนำเสนอเป็นเอกสาร PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้

โค้ด JavaScript ด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมรวมสไลด์ที่ซ่อน:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // เพิ่มสไลด์ที่ซ่อนอยู่.
    pdfOptions.setShowHiddenSlides(true);

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

โค้ด JavaScript นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint ให้เป็น PDF ที่ป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions):

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions) ซึ่งช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ด JavaScript นี้แสดงวิธีตรวจจับการแทนที่ฟอนต์:

```js
// ตั้ง callback การเตือนในตัวเลือก PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// บันทึกงานนำเสนอเป็น PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [Font Substitution](/slides/th/nodejs-java/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

โค้ด JavaScript นี้แสดงวิธีแปลงเฉพาะสไลด์ที่เลือกจากงานนำเสนอ PowerPoint เป็น PDF:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // กำหนดอาเรย์ของหมายเลขสไลด์.
    let slides = java.newArray("int", [1, 3]);

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

โค้ด JavaScript นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ:

```js
const slideWidth = 612;
const slideHeight = 792;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// สร้างงานนำเสนอใหม่โดยมีขนาดสไลด์ที่ปรับแล้ว.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // กำหนดขนาดสไลด์แบบกำหนดเอง.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกย่อ.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

โค้ด JavaScript นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อ:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // ตั้งค่าตัวเลือก PDF ด้วยเลย์เอาต์บันทึกย่อ.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อ.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด JavaScript นี้แสดงกระบวนการแปลง PowerPoint ไปเป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides รองรับการแปลง PDF ไปยังฟอร์แมตไฟล์ยอดนิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/th/nodejs-java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/nodejs-java/conversion/pdf-to-png/) การแปลง PDF ไปยังฟอร์แมตเฉพาะ—[PDF to SVG](https://products.aspose.com/slides/th/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/nodejs-java/conversion/pdf-to-tiff/)—ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปหนึ่งเดียว ส่วนองค์ประกอบเส้นทางย่อยจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็น artifacts; ข้อความแทน (alternative text) จะให้เฉพาะกับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF ได้เป็นชุดไหม?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงแบบโปรแกรมได้

**สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้แน่นอน ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions) เพื่อตั้งค่ารหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**จะรวมสไลด์ที่ซ่อนใน PDF อย่างไร?**

ใช้เมธอด `setShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions) เพื่อรวมสไลด์ที่ซ่อนเป็นส่วนหนึ่งของ PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น `setJpegQuality` และ `setSufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PdfOptions) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ ได้แก่ PDF/A1a, PDF/A1b, และ PDF/UA ซึ่งทำให้เอกสารของคุณตอบสนองต่อข้อกำหนดการเข้าถึงและการจัดเก็บระยะยาว

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ Node.js ผ่าน Java](/slides/th/nodejs-java/)
- [อ้างอิง API Aspose.Slides สำหรับ Node.js ผ่าน Java](https://reference.aspose.com/slides/th/nodejs-java/)
- [เครื่องมือแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion)