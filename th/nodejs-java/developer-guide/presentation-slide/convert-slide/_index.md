---
title: แปลงสไลด์การนำเสนอเป็นภาพใน JavaScript
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
- สไลด์เป็นบิทแมป
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java — การแสดงผลที่รวดเร็วและคุณภาพสูง พร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for Node.js via Java ช่วยให้คุณแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่าง ๆ ได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่คุณต้องการส่งออกโดยใช้:
    - คลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) หรือ
    - คลาส [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/)
2. สร้างภาพสไลด์โดยเรียกใช้เมธอด [getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage)

ใน Aspose.Slides for Node.js via Java, [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) คือคลาสที่ช่วยให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้คลาสนี้เพื่อบันทึกภาพในรูปแบบที่หลากหลาย (BMP, JPG, PNG เป็นต้น)

## **แปลงสไลด์เป็นบิทแมปและบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นออบเจกต์บิทแมปและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิทแมปแล้วบันทึกรูปภาพเป็น JPEG หรือรูปแบบอื่นที่คุณต้องการ

โค้ด JavaScript ตัวอย่างนี้แสดงวิธีแปลงสไลด์แรกของการนำเสนอเป็นออบเจกต์บิทแมปและจากนั้นบันทึกรูปภาพเป็นรูปแบบ PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิทแมป.
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

คุณอาจต้องการภาพที่มีขนาดเฉพาะ โดยใช้ overload ของเมธอด [getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage) คุณสามารถแปลงสไลด์เป็นภาพด้วยมิติที่กำหนด (ความกว้างและความสูง)

โค้ดตัวอย่างนี้แสดงวิธีทำเช่นนั้น:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิทแมปด้วยขนาดที่ระบุ.
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

## **แปลงสไลด์ที่มีบันทึกและคอมเมนต์เป็นภาพ**

บางสไลด์อาจมีบันทึกและคอมเมนต์

Aspose.Slides มีสองคลาส—[TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) และ [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นภาพ ทั้งสองคลาสมีเมธอด `setSlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดการเรนเดอร์ของบันทึกและคอมเมนต์บนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกและคอมเมนต์ในภาพผลลัพธ์ได้

โค้ด JavaScript ตัวอย่างนี้แสดงวิธีแปลงสไลด์ที่มีบันทึกและคอมเมนต์:

```js
const scaleX = 2;
const scaleY = scaleX;

// โหลดไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // ตั้งค่าตำแหน่งของบันทึก.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // ตั้งค่าตำแหน่งของคอมเมนต์.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // ตั้งค่าความกว้างของพื้นที่คอมเมนต์.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // ตั้งค่าสีสำหรับพื้นที่คอมเมนต์.

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

{{% alert title="Note" color="warning" %}} 

ในการแปลงสไลด์เป็นภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของบันทึก) ได้ เนื่องจากข้อความของบันทึกอาจยาวเกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนดได้.

{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ TIFF Options**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/) ให้การควบคุมที่ละเอียดขึ้นสำหรับภาพ TIFF ผลลัพธ์โดยให้คุณระบุพารามิเตอร์ต่าง ๆ เช่น ขนาด, ความละเอียด, พาเลตสี และอื่น ๆ

โค้ด JavaScript ตัวอย่างนี้แสดงกระบวนการแปลงโดยใช้ตัวเลือก TIFF เพื่อสร้างภาพขาว-ดำที่มีความละเอียด 300 DPI และขนาด 2160 × 2800:

```js
// โหลดไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากงานนำเสนอ.
    let slide = presentation.getSlides().get_Item(0);

    // กำหนดการตั้งค่าภาพ TIFF ที่ส่งออก.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // ตั้งค่าขนาดของภาพ.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // ตั้งค่ารูปแบบพิกเซล (ขาวดำ).
    tiffOptions.setDpiX(300);                                                          // ตั้งความละเอียดแนวนอน.
    tiffOptions.setDpiY(300);                                                          // ตั้งความละเอียดแนวตั้ง.

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

{{% alert title="Note" color="warning" %}} 

การสนับสนุน TIFF ไม่รับประกันในเวอร์ชันก่อน JDK 9.

{{% /alert %}} 

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides ช่วยให้คุณแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ ซึ่งทำให้การแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพได้อย่างมีประสิทธิภาพ

โค้ดตัวอย่างนี้แสดงวิธีแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพด้วย JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // เรนเดอร์งานนำเสนอเป็นภาพแต่ละสไลด์.
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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์ที่มีแอนิเมชันหรือไม่?**

ไม่, เมธอด `getImage` จะบันทึกเฉพาะภาพนิ่งของสไลด์เท่านั้น ไม่รวมแอนิเมชัน.

**สไลด์ที่ซ่อนสามารถส่งออกเป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ทั่วไป เพียงให้แน่ใจว่ามีการรวมสไลด์เหล่านั้นในลูปการประมวลผล.

**สามารถบันทึกรูปภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งแสง, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ.