---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF ด้วย JavaScript
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ด JavaScript"
---
## **แนะนำ**

TIFF (**Tagged Image File Format**) คือรูปแบบภาพแรสเตอร์แบบ lossless ที่ได้รับความนิยมอย่างกว้างขวาง มีคุณภาพยอดเยี่ยมและคงรายละเอียดของกราฟิกได้อย่างเต็มที่ นักออกแบบ ช่างภาพ และผู้จัดพิมพ์บนเดสกท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น สี ความแม่นยำของสี และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ไปเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความสมจริงสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว รูป TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ด JavaScript นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น TIFF：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอ็อบเจ็กต์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // บันทึกการนำเสนอเป็นรูปแบบ TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ให้คุณระบุอัลกอริธม์ที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งเป็น `CCITT4` หรือ `CCITT3`

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริธม์การแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด หากต้องการกำหนดวิธีการแสดงผลของรูปทรงเดี่ยวเมื่ออยู่ในโหมดแสดงผลขาว-ดำ ให้ใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) ดูตัวอย่างได้ที่ [Control Black-and-White Rendering for Shapes](/slides/th/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes)
{{% /alert %}}

สมมติว่าเรามีไฟล์ “sample.pptx” ที่มีสไลด์ดังต่อไปนี้：

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด JavaScript นี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF ขาว-ดำ：

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

ผลลัพธ์：

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดที่กำหนดเอง**

หากต้องการภาพ TIFF ที่มีขนาดเฉพาะเจาะจง คุณสามารถตั้งค่าขนาดที่ต้องการโดยใช้เมธอดจาก [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setImageSize) ให้คุณกำหนดขนาดของภาพผลลัพธ์

โค้ด JavaScript นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ที่มีขนาดกำหนดเอง：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    ประเภทการบีบอัด:
        Default - ระบุรูปแบบการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกของสีถูกควบคุมโดยรูปแบบพิกเซล (ดูตัวอย่างด้านล่าง); CCITT3 และ CCITT4 จะให้ผลลัพธ์เป็น 1 บิตต่อพิกเซลเสมอ.

    // ตั้งค่า DPI ของภาพ.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ตั้งค่าขนาดของภาพ.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกการนำเสนอเป็น TIFF พร้อมขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) ของคลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) คุณสามารถกำหนดรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ผลลัพธ์ได้

โค้ด JavaScript นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบดัชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    /// บันทึกการนำเสนอเป็น TIFF พร้อมขนาดภาพที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
ลองใช้ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose
{{% /alert %}}

## **FAQ**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint หรือ OpenDocument เป็นภาพ TIFF แยกกัน

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

**เอฟเฟกต์แอนิเมชันและการเปลี่ยนสไลด์ของ PowerPoint จะถูกรักษาขณะแปลงเป็น TIFF หรือไม่?**

ไม่ เนื่องจาก TIFF เป็นรูปแบบภาพคงที่ ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ถูกรักษา จะได้เฉพาะสแนปชอตคงที่ของสไลด์เท่านั้น

---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF ด้วย JavaScript
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ด JavaScript"
---