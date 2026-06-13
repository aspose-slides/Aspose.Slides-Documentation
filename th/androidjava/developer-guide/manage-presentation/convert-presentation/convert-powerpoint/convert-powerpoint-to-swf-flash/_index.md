---
title: แปลงงานนำเสนอ PowerPoint เป็น SWF Flash บน Android
linktitle: PowerPoint เป็น SWF
type: docs
weight: 80
url: /th/androidjava/convert-powerpoint-to-swf-flash/
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
- ส่งออก PPT ไปเป็น SWF
- ส่งออก PPTX ไปเป็น SWF
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ใน Java ด้วย Aspose.Slides สำหรับ Android. ตัวอย่างโค้ดขั้นตอนทีละขั้นตอน, ผลลัพธ์คุณภาพเร็ว, ไม่ต้องอัตโนมัติ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงงานนำเสนอ PowerPoint เป็น SWF โดยใช้ Aspose.Slides แสดงวิธีการบันทึกงานนำเสนอเป็นไฟล์ SWF ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) และวิธีการกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/), รวมถึงการตั้งค่าผู้ชมและการจัดวางโน้ตหรือความคิดเห็น

## **แปลง PPT(X) เป็น SWF**

เมธอด [Save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ที่เปิดให้ใช้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร **SWF** ตัวอย่างต่อไปนี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร **SWF** โดยใช้ตัวเลือกที่จัดให้โดยคลาส [**SWFOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SwfOptions) คุณยังสามารถรวมความคิดเห็นใน SWF ที่สร้างขึ้นโดยใช้ [**ISWFOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISwfOptions) และอินเทอร์เฟซ [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) ได้

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // บันทึกงานนำเสนอ
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่. เปิดใช้สไลด์ที่ซ่อนอยู่โดยใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) ใน [SwfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/) ตามค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกส่งออก.

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้เมธอด [setCompressed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) และ [adjust JPEG quality](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) เพื่อปรับสมดุลระหว่างขนาดไฟล์และคุณภาพภาพ.

**'setViewerIncluded' มีไว้เพื่ออะไร และควรปิดใช้งานเมื่อไหร่?**

[setViewerIncluded](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) เพิ่ม UI ของผู้เล่นที่ฝังไว้ (ควบคุมการนำทาง, แพเนล, การค้นหา) ปิดการใช้งานหากคุณต้องการใช้ผู้เล่นของคุณเองหรือจำเป็นต้องมีเฟรม SWF เปล่าๆ โดยไม่มี UI.

**เกิดอะไรขึ้นหากฟอนต์ต้นทางหายไปบนเครื่องที่ทำการส่งออก?**

Aspose.Slides จะทำการแทนที่ฟอนต์ที่คุณระบุผ่าน [setDefaultRegularFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ใน [SwfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/swfoptions/) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองโดยไม่ได้ตั้งใจ.