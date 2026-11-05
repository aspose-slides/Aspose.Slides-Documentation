---
title: เปลี่ยนขนาดและแนวทางของหน้าบันทึกใน JavaScript
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/nodejs-java/notes-size/
keywords:
- ขนาดหน้าบันทึก
- การจัดแนวบันทึก
- บันทึกแนวนอน
- บันทึกแนวตั้ง
- ขนาดสรุป
- PowerPoint
- งานนำเสนอ
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าบันทึกใน Aspose.Slides สำหรับ Node.js ผ่าน Java, สลับแนวทาง, ตรวจสอบขนาดที่บันทึก, และส่งออกบันทึกหรือเอกสารสรุปเป็น PDF และรูปภาพ."
---
## **ภาพรวม**

ใช้ [Presentation.getNotesSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getnotessize/) เพื่อเข้าถึงการตั้งค่าหน้าบันทึกของงานนำเสนอ มันจะคืนค่าอ็อบเจ็กต์ [NotesSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notessize/) ที่มีเมธอด [setSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notessize/setsize/) สำหรับกำหนดขนาดหน้า แม้ว่าจะไม่สามารถเปลี่ยนออบเจ็กต์การตั้งค่าได้โดยตรง แต่คุณสามารถกำหนดขนาดใหม่ผ่านเมธอดนี้

ความกว้างและความสูงระบุเป็น **points** โดยมี 72 points ต่อหนึ่งนิ้ว เช่น 900 × 600 points คือ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับงานนำเสนอทั้งหมด ไม่ใช่กับบันทึกของสไลด์แต่ละสไลด์

| การตั้งค่า | วัตถุประสงค์ |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getnotessize/) | ควบคุมขนาดหน้าบันทึกและขนาดหน้าที่ใช้ในการส่งออกเอกสารสรุป |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslidesize/) | ควบคุมขนาดสไลด์ปกติของงานนำเสนอผ่าน [SlideSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/) |

การเปลี่ยนการตั้งค่าใด ๆ หนึ่งจะไม่ทำให้การตั้งค่าอื่นเปลี่ยนโดยอัตโนมัติ การเปลี่ยนแนวทางของหน้าบันทึกก็ไม่ทำให้สไลด์ปกติดับหมุน โปรดดู [Slide Size](/slides/th/nodejs-java/slide-size/) เพื่อปรับขนาดสไลด์ปกติ

ตัวอย่างด้านล่างใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ที่มีบันทึกของผู้พูดแต่ละตัวอย่างสามารถทำงานได้อย่างอิสระ

## **อ่านขนาดและทิศทางของหน้าบันทึก**

อ่านความกว้างและความสูงและเปรียบเทียบเพื่อกำหนดทิศทาง: หน้าที่กว้างกว่าเป็นแนวนอน, หน้าที่สูงกว่าเป็นแนวตั้ง, และขนาดเท่ากันเป็นหน้าจัตุรัส ตัวอย่างนี้พิมพ์ขนาดจริงเป็น points โดยไม่สมมติขนาดกระดาษมาตรฐาน

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **สลับเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะแนวทาง ให้สลับค่าความกว้างและความสูงที่มีอยู่ สิ่งนี้จะรักษาความยาวของทั้งสองด้านรวมถึงขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างป้องกันไม่ให้หน้าที่เป็นแนวนอนแล้วสลับกลับเป็นแนวตั้งและทำให้หน้าจัตุรัสไม่เปลี่ยนแปลง

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับแนวตั้งให้ใช้การกำหนดค่าเดียวกันเมื่อ `size.getWidth() > size.getHeight()` อย่าแทนที่ขนาด A4 หรือ Letter เว้นแต่คุณต้องการเปลี่ยนขนาดกระดาษด้วย

## **ตั้งค่าและตรวจสอบขนาดหน้าบันทึกที่กำหนดเอง**

กำหนดขนาดทั้งสองมิติพร้อมกัน จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/save/) เพื่อบันทึกงานนำเสนอ ตัวอย่างนี้ตั้งค่าหน้าแนวนอน 900 × 600 points บันทึกเป็น PPTX แล้วเปิดไฟล์ที่บันทึกใหม่อีกครั้งเพื่อตรวจสอบค่าที่บันทึกไว้ การเปรียบเทียบอนุญาตให้มีความคลาดเคลื่อน 0.01 point สำหรับค่าจุดทศนิยม; ไม่ได้รับประกันความแม่นยำสำหรับทุกรูปแบบไฟล์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่คาดหวังคือ `900 x 600 points` และ `Size preserved: true` การตรวจสอบงานนำเสนอที่เปิดใหม่ยืนยันไฟล์ที่บันทึก ไม่ใช่เพียงการตั้งค่าในหน่วยความจำเท่านั้น

## **ส่งออกบันทึกและเอกสารสรุป**

ขนาดหน้ากำหนดพื้นที่ที่ใช้ได้สำหรับบันทึกหรือรูปแบบเอกสารสรุป แต่ไม่ได้เปิดใช้งานรูปแบบเหล่านั้นโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วย การส่งออกสไลด์ปกติจะยังคงใช้ขนาดสไลด์ต่อไป

### **ส่งออกบันทึกเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ให้กับ [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) เพื่อรวมบันทึกใน PDF ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกพร้อมบันทึกเป็น PNG ด้วย [Slide.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage) และ [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/)

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notespositions/) จะเก็บบันทึกบนหน้าเดียว; บันทึกที่ไม่พอดีจะถูกตัด PDF ใช้หน้า 900 × 600 points ที่สเกลภาพ 1 × 1 ตามด้านล่าง PNG จะเป็น 900 × 600 พิกเซล Points บรรยายรูปทรงหน้ากระดาษ; พิกเซลบรรยายผลลัพธ์แบบแรสเตอร์ที่มิติขึ้นอยู่กับสเกลการเรนเดอร์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

สำหรับการส่งออก PDF กับบันทึกยาว ให้ใช้ [BottomFull](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notespositions/) เพื่อเพิ่มหน้าเพิ่มเติมตามต้องการ อย่าใช้โหมดนั้นกับการเรียกภาพสไลด์เดี่ยวด้านบนซึ่งไม่รองรับ หลังจากปรับขนาด ตรวจสอบผลลัพธ์ว่าบันทึกถูกตัดหรือไม่และตำแหน่งของวัตถุ notes‑master ที่มีอยู่; การเปลี่ยนขนาดหน้าเพียงอย่างเดียวไม่ถือเป็นการรับประกันว่าทุกเนื้อหาจะพอดีกัน ดูรายละเอียดเพิ่มเติมที่ [Convert PowerPoint to PDF with Notes](/slides/th/nodejs-java/convert-powerpoint-to-pdf-with-notes/)

### **ส่งออกเอกสารสรุปเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handoutlayoutingoptions/) สำหรับภาพย่อหลายสไลด์บนหน้าเดียว ตัวอย่างต่อไปนี้ตั้งค่าหน้า 900 × 600 points และใช้ [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/handouttype/) เพื่อจัดเรียงสูงสุดสี่สไลด์ต่อหน้า การตั้งค่าฉบับแนวนอนกำหนดลำดับสไลด์; แนวหน้ามาจากความกว้างและความสูงของมัน

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้สำหรับตารางเอกสารสรุปโดยไม่เปลี่ยนขนาดสไลด์ต้นฉบับ สำหรับภาพเอกสารสรุป ให้ใช้ [Presentation.getImages](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getimages/) กับรูปแบบเอกสารสรุป แทนการใช้เมธอดภาพสไลด์เดี่ยว ใน Aspose.Slides การเรนเดอร์เอกสารสรุประดับงานนำเสนอใช้ขนาดหน้าบันทึก ส่วนการเรียกภาพสไลด์เดี่ยวไม่สร้างหน้าเอกสารสรุป ดูตัวเลือกการจัดวางที่ [Handout Mode](/slides/th/nodejs-java/convert-powerpoint-in-handout-mode/)

## **ขนาดหน้ากระดาษในตัวดู, การส่งออกและการพิมพ์**

รักษาขนาดงานนำเสนอที่เก็บไว้, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์ให้แยกกันชัดเจน:

- **Presentation viewers:** ตัวดูสามารถแสดงหรือพิมพ์บันทึกโดยใช้กฎการจัดวางของตนเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดไฟล์ใหม่และตรวจสอบขนาดอีกครั้ง; การแปลงรูปแบบของแอปนั้นอาจทำให้ขนาดเป็นมาตรฐาน
- **Export formats:** ตัวอย่าง PDF ของบันทึกและเอกสารสรุปด้านบนใช้ขนาดหน้าที่กำหนด Raster image ใช้มิติพิกเซลจำนวนเต็มและสเกลการเรนเดอร์ ดังนั้นค่าจุดเศษส่วนอาจถูกปัดเป็นจำนวนเต็มในผลลัพธ์ภาพ การส่งออกสไลด์ปกติจะไม่ใช้ขนาดหน้าบันทึก
- **Printer drivers:** การเลือกกระดาษ, การหมุนโดยอัตโนมัติ, และการตั้งค่า fit‑to‑page สามารถเปลี่ยนผลลัพธ์ทางกายภาพได้โดยไม่กระทบขนาดที่เก็บในงานนำเสนอหรือ PDF สำหรับขนาดกระดาษเฉพาะ ให้ปรับการตั้งค่าปริ้นเตอร์และตรวจสอบตัวอย่างการพิมพ์

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าขนาดบันทึกสำหรับสไลด์เดียวได้หรือไม่?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับงานนำเสนอ สไลด์แต่ละสไลด์สามารถมีเนื้อหาบันทึกที่ต่างกันได้ แต่คุณสมบัตินี้ไม่ให้ขนาดหน้าที่แยกต่างหากสำหรับสไลด์แต่ละอัน

**ทำไมการเปลี่ยนแนวทางบันทึกไม่ทำให้สไลด์ของฉันเปลี่ยน?**

หน้าบันทึกและสไลด์ปกติมีขนาดอิสระกัน ใช้วิธีตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์ของฉันจึงมีขนาดที่ต่างออกไป?**

ให้เปิดงานนำเสนอที่บันทึกใหม่อีกครั้งและเปรียบเทียบขนาดบันทึก หากขนาดเปลี่ยนให้ตรวจสอบว่าการบันทึกหรือแปลงไฟล์ในแอปพลิเคชันอื่นทำให้การตั้งค่าหน้าถูกเปลี่ยนหรือไม่ ถ้าไม่เปลี่ยน ให้ตรวจสอบการจัดวางการส่งออก, สเกลภาพ, การตั้งค่าตัวดู, และการเลือกกระดาษของเครื่องพิมพ์