---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ด้วย JavaScript
titlelink: PowerPoint ไปยัง TIFF
type: docs
weight: 90
url: /th/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปยัง TIFF
- งานนำเสนอไปยัง TIFF
- สไลด์ไปยัง TIFF
- PPT ไปยัง TIFF
- PPTX ไปยัง TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ด JavaScript."
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่มีการสูญเสียที่ใช้อย่างแพร่หลาย มันเป็นที่รู้จักสำหรับคุณภาพที่ยอดเยี่ยมและการเก็บรายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

โดยใช้ Aspose.Slides, คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงความชัดเจนของภาพสูงสุด.

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) ที่ให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่สร้างขึ้นจะสอดคล้องกับขนาดสไลด์เริ่มต้น.

โค้ด JavaScript ด้านล่างนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ช่วยให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) เป็นการตั้งระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งฉบับ เพื่อกำหนดว่ารูปทรงใดควรแสดงอย่างไรเมื่อโหมดแสดงผลขาว-ดำทำงาน, ใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) ดูตัวอย่างใน [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes).
{{% /alert %}}

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด JavaScript ด้านล่างนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะคุณสามารถกำหนดค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setImageSize) ช่วยให้คุณกำหนดขนาดของภาพที่สร้างขึ้น.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // ตั้งค่าประเภทการบีบอัด.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    ประเภทการบีบอัด:
        Default - ระบุโครงการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกของสีถูกควบคุมโดยรูปแบบพิกเซล (ดูตัวอย่างด้านล่าง); CCITT3 และ CCITT4 จะสร้าง 1 บิตต่อพิกเซลเสมอ.

    // ตั้งค่า DPI ของภาพ.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ตั้งค่าขนาดของภาพ.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่สร้างขึ้น.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบจัดทำดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบจัดทำดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบจัดทำดัชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    /// บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
ตรวจสอบ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ครับ Aspose.Slides ช่วยให้คุณแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกันได้.

**มีข้อจำกัดเรื่องจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF.

**การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ได้ เนื่องจาก TIFF เป็นรูปแบบภาพแบบคงที่ ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนจะไม่ถูกรักษา; เฉพาะภาพนิ่งของสไลด์เท่านั้นที่ถูกส่งออก.