---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ด้วย JavaScript
titlelink: PowerPoint เป็น TIFF
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
- PowerPoint เป็น TIFF
- งานนำเสนอเป็น TIFF
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
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Node.js พร้อมตัวอย่างโค้ด JavaScript"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่มีการสูญเสียคุณภาพที่ได้รับความนิยมอย่างกว้างขวาง เนื่องจากคุณภาพที่ยอดเยี่ยมและการเก็บรักษารายละเอียดของกราฟิกอย่างเหมาะสม นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมของภาพ

โดยใช้ Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ไปเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย โดยทำให้การนำเสนอของคุณคงความคมชัดสูงสุด

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) ที่ให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว รูปภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ช่วยให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF เหลือง-ขาว โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

```js
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

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดที่กำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถกำหนดค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setImageSize) ช่วยให้คุณกำหนดขนาดของภาพผลลัพธ์

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    ประเภทการบีบอัด:
        Default - ระบุแผนการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นอยู่กับชนิดการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

    // ตั้งค่า DPI ของภาพ.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ตั้งขนาดภาพ.
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

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ผลลัพธ์

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าดังต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, indexed.
        Format4bppIndexed - 4 บิตต่อพิกเซล, indexed.
        Format8bppIndexed - 8 บิตต่อพิกเซล, indexed.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    /// บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
ลองดู [ตัวแปลง PowerPoint เป็นโปสเตอร์ ฟรี](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดียวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

**การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่มี TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนจะไม่ถูกเก็บรักษาไว้ มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออก