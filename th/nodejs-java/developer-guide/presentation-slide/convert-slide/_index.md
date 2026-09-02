---
title: แปลงสไลด์งานนำเสนอเป็นภาพใน JavaScript
linktitle: สไลด์เป็นภาพ
type: docs
weight: 35
url: /th/nodejs-java/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP ไปเป็นภาพใน JavaScript โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java — การเรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for Node.js via Java ช่วยให้คุณสามารถแปลงสไลด์งานนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่างๆ ได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่นๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - คลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) หรือ
    - คลาส [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/)
2. สร้างภาพสไลด์โดยเรียกใช้เมธอด [getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage)

ใน Aspose.Slides for Node.js via Java, คลาส [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) เป็นคลาสที่ให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้คลาสนี้เพื่อบันทึกภาพในหลายรูปแบบ (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็นบิตแมพและบันทึกภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นออบเจ็กต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิตแมพแล้วบันทึกภาพเป็น JPEG หรือรูปแบบอื่นที่ต้องการ

โค้ด JavaScript นี้แสดงวิธีแปลงสไลด์แรกของงานนำเสนอเป็นออบเจ็กต์บิตแมพและบันทึกภาพในรูปแบบ PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพ.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // บันทึกภาพในรูปแบบ PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการภาพที่มีขนาดเฉพาะ โดยใช้ overload ของเมธอด [getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage) คุณสามารถแปลงสไลด์เป็นภาพโดยกำหนดความกว้างและความสูงที่ต้องการได้

โค้ดตัวอย่างนี้แสดงวิธีทำเช่นนี้:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพด้วยขนาดที่ระบุ.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // บันทึกภาพในรูปแบบ JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์พร้อมบันทึกย่อและความคิดเห็นเป็นภาพ**

บางสไลด์อาจมีบันทึกย่อและความคิดเห็น

Aspose.Slides มีคลาสสองคลาส—[TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) และ [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/)—ที่ให้คุณควบคุมการแปลงสไลด์งานนำเสนอเป็นภาพ ทั้งสองคลาสมีเมธอด `setSlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดการแปลงบันทึกย่อและความคิดเห็นบนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกย่อและความคิดเห็นในภาพที่ได้

โค้ด JavaScript นี้แสดงวิธีแปลงสไลด์พร้อมบันทึกย่อและความคิดเห็น:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // กำหนดตำแหน่งของบันทึกย่อ.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // กำหนดตำแหน่งของความคิดเห็น.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // กำหนดความกว้างของพื้นที่ความคิดเห็น.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // กำหนดสีสำหรับพื้นที่ความคิดเห็น.

    // สร้างตัวเลือกการเรนเดอร์.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // แปลงสไลด์แรกของงานนำเสนอเป็นภาพ.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // บันทึกภาพในรูปแบบ GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นภาพใดๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของบันทึกย่อ) เนื่องจากข้อความของบันทึกย่ออาจยาวเกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่ระบุได้.
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ให้การควบคุมที่มากขึ้นสำหรับภาพ TIFF ที่ได้โดยให้คุณระบุพารามิเตอร์ต่างๆ เช่น ขนาด ความละเอียด พาเลตสี ฯลฯ

โค้ด JavaScript นี้แสดงกระบวนการแปลงที่ใช้ตัวเลือก TIFF เพื่อสร้างภาพขาว-ดำด้วยความละเอียด 300 DPI และขนาด 2160 × 2800:

```js
// โหลดไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากงานนำเสนอ.
    let slide = presentation.getSlides().get_Item(0);

    // ตั้งค่าการกำหนดของภาพ TIFF ที่ส่งออก.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // กำหนดขนาดของภาพ.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // กำหนดรูปแบบพิกเซล (ขาวดำ).
    tiffOptions.setDpiX(300);                                                          // กำหนดความละเอียดแนวนอน.
    tiffOptions.setDpiY(300);                                                          // กำหนดความละเอียดแนวตั้ง.

    // แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    let image = slide.getImage(tiffOptions);
    try {
        // บันทึกภาพในรูปแบบ TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
การสนับสนุน Tiff ไม่รับประกันในเวอร์ชันที่ต่ำกว่า JDK 9.
{{% /alert %}} 

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides ทำให้คุณสามารถแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพได้ ทำให้งานนำเสนอทั้งหมดแปลงเป็นชุดของภาพ

โค้ดตัวอย่างนี้แสดงวิธีแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพด้วย JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // เรนเดอร์งานนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // ควบคุมสไลด์ที่ซ่อน (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // แปลงสไลด์เป็นภาพ.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // บันทึกภาพในรูปแบบ JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **การแสดงผลอีโมจีสี**

{{% alert title="หมายเหตุ" color="warning" %}} 
เพื่อให้การแสดงผลอีโมจีสีถูกต้องเมื่อแปลงสไลด์งานนำเสนอเป็นภาพ ฟอนต์อีโมจีที่ใช้ในงานนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้หายไป อีโมจีอาจแสดงเป็นสีเดียวในภาพผลลัพธ์.
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการแสดงสไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, เมธอด `getImage` จะบันทึกเฉพาะภาพนิ่งของสไลด์เท่านั้น ไม่มีแอนิเมชัน.

**สามารถส่งออกสไลด์ที่ซ่อนเป็นภาพได้หรือ?**

ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เหมือนสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่าถูกรวมในลูปการประมวลผล

**สามารถบันทึกภาพพร้อมเงาและเอฟเฟกต์ได้หรือ?**

ได้, Aspose.Slides รองรับการแสดงเงา ความโปร่งแสง และเอฟเฟกต์กราฟิกอื่นๆ เมื่อบันทึกสไลด์เป็นภาพ.