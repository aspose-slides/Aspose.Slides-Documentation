---
title: แปลง PPT และ PPTX เป็น PDF ใน JavaScript [รวมฟีเจอร์ขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้โดยใช้ Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงการนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, ODP เป็นต้น) เป็นรูปแบบ PDF ใน JavaScript มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและการจัดรูปแบบของการนำเสนอของคุณ คู่มือนี้แสดงวิธีการแปลงการนำเสนอเป็นเอกสาร PDF, ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของรูปภาพ, รวมสไลด์ที่ซ่อนอยู่, ป้องกันไฟล์ PDF ด้วยรหัสผ่าน, ตรวจจับการแทนที่ฟอนต์, เลือกสไลด์เฉพาะสำหรับการแปลง, และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ใช้ Aspose.Slides คุณสามารถแปลงการนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงการนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) จากนั้นบันทึกการนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) ซึ่งโดยทั่วไปใช้สำหรับแปลงการนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides สำหรับ Node.js ผ่าน Java แทรกข้อมูล API และหมายเลขเวอร์ชันของมันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงการนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่อยู่ในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือลบข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF, ทำให้ไฟล์ PDF ที่ได้ตรงกับการนำเสนอเดิมอย่างใกล้เคียง องค์ประกอบและคุณลักษณะต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง, รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* รูปแบบข้อความ
* รูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint ไปเป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงการนำเสนอที่ให้เป็น PDF โดยใช้การตั้งค่าที่เหมาะที่สุดที่ระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดการนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกค่าเริ่มต้น

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose มีตัวแปลง PowerPoint เป็น PDF ออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงการนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการดำเนินการจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—เพื่อให้คุณปรับแต่ง PDF ที่ได้, ปิดกั้น PDF ด้วยรหัสผ่าน, หรือระบุวิธีการดำเนินกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์, ระบุวิธีการจัดการไฟล์เมต้า, ตั้งค่าระดับการบีบอัดสำหรับข้อความ, กำหนดค่า DPI สำหรับภาพ, และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF 1.5 โดยตั้งค่า JPEG quality เป็น 90, ความละเอียดภาพเป็น 300 DPI, บันทึกไฟล์เมต้าเป็น PNG, และใช้การบีบอัดข้อความแบบ Flate

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **รักษาไฟล์ OLE ฝังไว้เป็นไฟล์แนบ PDF**

หากการนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กพร้อมกับดูสไลด์ เรียกใช้เมธอด [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) ด้วยค่า `true` เพื่อเก็บไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่ได้

ค่าตั้งต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของออบเจกต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังไว้จะไม่ถูกใส่เป็นไฟล์แนบ การตั้งค่าเป็น `true` จะรวมข้อมูลไฟล์ด้วย ตัวอย่างแสดงภาพยังคงเป็นการแสดงผลวิชวล; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกต่างหากได้ ออบเจกต์ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

เพื่อตรวจสอบผลลัพธ์:

1. เปิดไฟล์ PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังไว้
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A กำหนดข้อจำกัดในการแนบไฟล์: PDF/A-1 ห้ามไฟล์ฝัง, PDF/A-2 อนุญาตให้แนบไฟล์ PDF/A เท่านั้น, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF ค่าเริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่เป็นหน้าใน PDF ที่ได้

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์รวมถึงการพิมพ์คุณภาพสูง

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides ให้เมธอด [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) เพื่อให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงการนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปยังคอนโซล คำเตือนจะพิมพ์เฉพาะเมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [การแทนที่ฟอนต์](/slides/th/nodejs-java/font-substitution/)

{{% /alert %}} 

### **จัดการฟอนต์ที่ไม่มีตัวหนาเฉพาะ**

การนำเสนอสามารถใช้การจัดรูปแบบตัวหนาสำหรับข้อความได้แม้ว่าฟอนต์ของมันจะไม่มีตัวหนาเฉพาะ ตัวอักษรอาจดูเป็นตัวหนาผ่านการทำ Synthetic Bold ซึ่งทำให้ glyph ปกติหนาขึ้น หากข้อความนั้นดูหนามากเกินไปหรือแตกต่างจากที่ต้องการใน PDF ให้ลองเรียกใช้เมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) ด้วยค่า `true` ตัวเลือกนี้จะแสดงข้อความที่ได้รับผลกระทบเป็นบิทแมพระหว่างการส่งออก PDF และอาจทำให้รูปลักษณ์ของฟอนต์บางตัวดีขึ้น ค่าเริ่มต้นคือ `false`

ตัวอย่างการนำเสนอมีกล่องข้อความสองกล่อง: หนึ่งกล่องมีข้อความปกติและอีกหนึ่งกล่องมีการจัดรูปแบบตัวหนาใช้ฟอนต์เดียวกันที่ไม่มีตัวหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดการนำเสนอ เปิดการเรสเซอร์ไลซ์สไตล์ฟอนต์ที่ไม่รองรับ และส่งออกเป็น PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

ตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิด การเปิดใช้งานตัวเลือกทำให้ข้อความตัวหนามีเส้นที่เบาลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับการนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้งานตัวเลือกทำให้ข้อความตัวหนาเท่านั้นถูกแปลงเป็นบิทแมพ: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความได้หากไม่มี OCR และขอบของมันจะดูนุ่มลงที่การซูม 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงยังคงเป็นข้อความ

ตัวเลือกนี้ทำการเรสเซอร์ไลซ์ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีตัวหนาเฉพาะ [การแทนที่ฟอนต์](/slides/th/nodejs-java/font-substitution/) จะเลือกฟอนต์อื่นเมื่อฟอนต์ต้นฉบับไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากการนำเสนอเป็น PDF ตัวเลขสไลด์ในอาร์เรย์นี้เริ่มต้นที่ 1 และการนำเข้าต้องมีอย่างน้อยสามสไลด์

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากการนำเสนอไปยังการนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 points (8.5 × 11 นิ้ว) มันปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ลบสไลด์เปล่าที่สร้างขึ้นพร้อมการนำเสนอใหม่.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยวางบันทึกย่อของผู้บรรยายแต่ละสไลด์ด้านล่างสไลด์ ใช้การนำเสนอที่มีบันทึกย่อเพื่อดูผลลัพธ์

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}

Aspose.Slides รองรับการดำเนินการแปลง PDF ทำให้คุณสามารถแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ยอดนิยมได้ คุณสามารถทำการแปลง [PDF ไป HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF ไป JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), และ [PDF ไป PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) การแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF ไป SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF ไป TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปแบบเดียว ไม่ได้เก็บองค์ประกอบเส้นทางแต่ละอันเป็นเนื้อหาแยกและอาจถูกบันทึกเป็นอาร์ตแฟคท์; ข้อความแทนที่ (alternative text) จะให้เฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**Can I convert multiple PowerPoint files to PDF in bulk?**

Yes, Aspose.Slides supports batch conversion of multiple PPT or PPTX files to PDF. You can iterate through your files and apply the conversion process programmatically.

**Is it possible to password-protect the converted PDF?**

Yes. Use the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class to set a password and define access permissions during the conversion process.

**How do I include hidden slides in the PDF?**

Call [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) with `true` in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class to include hidden slides in the resulting PDF.

**Can Aspose.Slides maintain high image quality in the PDF?**

Yes, you can control image quality by using methods such as [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) and [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class to ensure high-quality images in your PDF.

**Does Aspose.Slides support PDF/A compliance standards?**

Yes, Aspose.Slides allows you to export PDFs that comply with [various standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), including PDF/A1a, PDF/A1b, and PDF/UA, ensuring your documents meet accessibility and archival requirements.

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ Node.js ผ่าน Java](/slides/th/nodejs-java/)
- [อ้างอิง API Aspose.Slides สำหรับ Node.js ผ่าน Java](https://reference.aspose.com/slides/nodejs-java/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)