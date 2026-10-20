---
title: แปลง PPT และ PPTX เป็น PDF ใน JavaScript [รวมคุณลักษณะขั้นสูง]
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
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่ค้นหาได้โดยใช้ Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย JavaScript มีข้อได้เปรียบหลายประการ เช่น ความเข้ากันได้บนอุปกรณ์ต่างๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอ คู่มือนี้จะแสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF การใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพภาพ การรวมสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านสำหรับไฟล์ PDF การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [การนำเสนอ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) จากนั้นบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [บันทึก](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) คลาส [การนำเสนอ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) จะเปิดให้ใช้เมธอด [บันทึก](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) ที่โดยปกติใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงการนำเสนอเป็น PDF, Aspose.Slides จะใส่ค่าลงในฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer จะเป็นค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides ให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์ต่างๆ จะถูกเรนเดอร์อย่างแม่นยำในระหว่างการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบตัวอักษร
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* หัวกระดาษและท้ายกระดาษ
* สัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF ปกติใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF โดยใช้การตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกเริ่มต้น

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
Aspose มีตัวแปลงออนไลน์ฟรีที่ชื่อว่า [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ซึ่งแสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides ให้ตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้ ปิด PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมต้าไฟล์ ตั้งค่าระดับการบีบอัดข้อความ กำหนด DPI สำหรับภาพ และอื่นๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 พร้อมคุณภาพ JPEG ที่ 90 ความละเอียดภาพที่ 300 DPI เมต้าไฟล์บันทึกเป็น PNG และการบีบอัดข้อความแบบ Flate

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

### **เลือกการบีบอัดภาพอัตโนมัติ**

เมื่องานนำเสนอมีรูปถ่ายหรือภาพหน้าจอจำนวนมาก การลดขนาด PDF ที่ส่งออกออกมาจะทำให้ง่ายต่อการส่งอีเมลหรือดาวน์โหลด เรียกใช้เมธอด [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) ด้วยค่า `true` เพื่อให้ระบบเลือกอัลกอริธึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพระหว่างการส่งออก PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีอยู่ เปิดใช้งานการเลือกบีบอัดภาพอัตโนมัติ และบันทึกเป็นไฟล์ PDF การตั้งค่าอื่นๆ ของการส่งออก PDF ยังคงค่าเริ่มต้นไว้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

เมธอดนี้จะเลือกอัลกอริธึมการบีบอัดสำหรับแต่ละภาพ การลดค่าที่ส่งให้กับ [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) จะทำให้คุณภาพ JPEG ลดลง ส่วนการลดค่าที่ส่งให้กับ [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) จะทำให้ภาพมีการลดความละเอียดลง ซึ่งอาจลดรายละเอียดได้ การเปิดใช้งานการเลือกบีบอัดอัตโนมัติเองไม่ได้ทำให้การตั้งค่าเหล่านี้ลดลง

การเลือกอัลกอริธึมบีบอัดภาพต้องใช้การประมวลผลและหน่วยความจำเพิ่มเติม ขนาดที่ลดลงจะขึ้นกับภาพและการตั้งค่าการส่งออกของงานนำเสนอ; ไม่ได้รับประกันว่าจะลดขนาดได้เท่าเดิมสำหรับทุกงานนำเสนอ

### **เก็บไฟล์ OLE ฝังเป็นไฟล์แนบ PDF**

หากงานนำมีไฟล์ Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของไฟล์เวิร์คบุ๊กพร้อมกับดูสไลด์ เรียกใช้เมธอด [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) ด้วยค่า `true` เพื่อเก็บไฟล์ OLE ฝังเป็นไฟล์แนบใน PDF ที่สร้างขึ้น

ค่าเริ่มต้นคือ `false`: ภาพพรีวิวหรือไอคอนของอ็อบเจ็กต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ฝังจะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มข้อมูลไฟล์เข้าไปเช่นกัน พรีวิวยังคงเป็นการแสดงผลภาพ ส่วนไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ฝังแยกต่างหากได้ อ็อบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีไฟล์ Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์คบุ๊ก

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

1. เปิด PDF ที่ส่งออกในโปรแกรมที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์คบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต พรีวิวบนหน้า PDF จะอยู่แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเรื่องไฟล์แนบ: PDF/A-1 ห้ามมีไฟล์ฝัง, PDF/A-2 อนุญาตไฟล์แนบ PDF/A เท่านั้น, PDF/A-3 อนุญาตประเภทไฟล์อื่นรวมถึงเวิร์คบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) ของคลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่สร้างขึ้น

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมรวมสไลด์ที่ซ่อนทั้งหมด

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

### **แปลง PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงให้พิมพ์ได้ รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปยังคอนโซล คำเตือนจะปรากฏก็ต่อเมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [Font Substitution](/slides/th/nodejs-java/font-substitution/)
{{% /alert %}} 

### **จัดการฟอนต์ที่ไม่มีตัวหนาที่แยกออกมา**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนากับข้อความแม้ว่าฟอนต์นั้นจะไม่มีรูปแบบตัวหนาแยกออกมา ข้อความยังคงแสดงเป็นตัวหนาผ่านการทำตัวหนาสังเคราะห์ ซึ่งทำให้กรีฟธรรมดาหนาขึ้น หากข้อความนั้นดูหนาเกินไปหรือไม่ตรงกับรูปลักษณ์ที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) ด้วยค่า `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพระหว่างการส่งออก PDF และอาจทำให้รูปลักษณ์ดีขึ้นสำหรับฟอนต์บางตัว ค่าเริ่มต้นคือ `false`

งานนำเสนอตัวอย่างมีกล่องข้อความสองกล่อง: กล่องหนึ่งมีข้อความปกติและอีกกล่องหนึ่งมีการจัดรูปแบบตัวหนาใช้ฟอนต์เดียวกันที่ไม่มีตัวหนาแยกออกมา ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดใช้งานการเรซอร์ไรซ์ฟอนต์ที่ไม่รองรับรูปแบบตัวหนา และส่งออกเป็น PDF:

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

พรีวิวต่อไปนี้แสดงผลลัพธ์เมื่อปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความหนามีเส้นที่หนากว่าเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือกเส้นจะแน่นกว่า; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนกำหนดค่าตามที่ต้องการสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้การเปิดตัวเลือกทำให้ข้อความหนาแปลงเป็นบิตแมพเท่านั้น: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความได้หากไม่มี OCR และขอบจะดูอ่อนกว่าเมื่อซูมที่ 800% ส่วนข้อความปกติยังคงสามารถค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำให้ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีตัวหนาแยกออกมาถูกเรซอร์ไรซ์ [Font substitution](/slides/th/nodejs-java/font-substitution/) จะเลือกฟอนต์อื่นแทนเมื่อฟอนต์เดิมไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้นับจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

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

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 พ้อยท์ (8.5 × 11 นิ้ว) ปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

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

    // ลบสไลด์เปล่าที่สร้างขึ้นเมื่อสร้างการนำเสนอใหม่
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกย่อของผู้พูดใต้สไลด์แต่ละหน้า ใช้งานนำเสนอที่มีบันทึกย่อผู้พูดเพื่อดูผลลัพธ์

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

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [แนวทางการเข้าถึงเนื้อหาเว็บ (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่ผลิต PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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
Aspose.Slides รองรับการทำงานแปลง PDF ทำให้คุณสามารถแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ยอดนิยมอื่นได้ คุณสามารถทำการแปลง [PDF เป็น HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF เป็น JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), และ [PDF เป็น PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) การแปลง PDF ไปเป็นรูปแบบเฉพาะอื่น เช่น [PDF เป็น SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF เป็น TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) ก็รองรับเช่นกัน
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปแบบเดียว ไม่ได้เก็บส่วนประกอบเส้นทางแยกเป็นเนื้อหาแยกต่างหากและอาจถูกมาร์คเป็นสิ่งประดิษฐ์; ข้อความแทนภาพ (alt text) จะให้เฉพาะกับรูปทั้งหมดเท่านั้น

## **FAQ**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**ฉันสามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่สร้างขึ้น

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพได้โดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) และ [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่างๆ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตอบสนองความต้องการด้านการเข้าถึงและการเก็บรักษาแบบถาวร

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Node.js via Java Documentation](/slides/th/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)