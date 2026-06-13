---
title: แปลงงานนำเสนอ PowerPoint เป็น SWF Flash ใน JavaScript
linktitle: PowerPoint เป็น SWF
type: docs
weight: 80
url: /th/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น SWF
- งานนำเสนอเป็น SWF
- สไลด์เป็น SWF
- PPT เป็น SWF
- PPTX เป็น SWF
- PowerPoint เป็น Flash
- งานนำเสนอเป็น Flash
- สไลด์เป็น Flash
- PPT เป็น Flash
- PPTX เป็น Flash
- บันทึก PPT เป็น SWF
- บันทึก PPTX เป็น SWF
- ส่งออก PPT เป็น SWF
- ส่งออก PPTX เป็น SWF
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ด้วย Aspose.Slides สำหรับ Node.js. ตัวอย่างโค้ดขั้นตอนต่อขั้นตอน, ผลลัพธ์คุณภาพเร็ว, ไม่ต้องใช้การทำอัตโนมัติของ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็น SWF โดยใช้ Aspose.Slides มันแสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ SWF ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) และวิธีกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/), รวมถึงการตั้งค่าผู้ชมและการจัดรูปแบบบันทึกหรือความคิดเห็น

## **แปลง PPT(X) เป็น SWF**
เมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร **SWF** ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร **SWF** โดยใช้ตัวเลือกที่จัดเตรียมโดยคลาส [**SWFOptions**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SwfOptions) คุณยังสามารถรวมความคิดเห็นใน SWF ที่สร้างขึ้นโดยใช้คลาส [**SWFOptions**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SwfOptions) และคลาส [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) ได้

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // บันทึกงานนำเสนอ
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่ ใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) ใน [SwfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/) โดยค่าเริ่มต้นสไลด์ที่ซ่อนจะไม่ถูกส่งออก

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้เมธอด [setCompressed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/setcompressed/) และ [setJpegQuality](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/setjpegquality/) เพื่อปรับสมดุลระหว่างขนาดไฟล์และคุณภาพภาพ

**'setViewerIncluded' ใช้ทำอะไร และควรใช้เมื่อใด?**

[setViewerIncluded](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) จะเพิ่ม UI ของผู้เล่นแบบฝัง (การควบคุมการนำทาง, แพเนล, การค้นหา) ใช้เมธอดนี้หากคุณต้องการใช้ผู้เล่นของคุณเองหรือจำเป็นต้องมีกรอบ SWF เปล่าโดยไม่มี UI

**จะเกิดอะไรขึ้นหากฟอนต์ต้นทางหายไปบนเครื่องส่งออก?**

Aspose.Slides จะเปลี่ยนฟอนต์ด้วยฟอนต์ที่คุณระบุผ่าน [setDefaultRegularFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [SwfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/swfoptions/) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองโดยไม่ตั้งใจ