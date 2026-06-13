---
title: แปลงการนำเสนอ PowerPoint เป็น SWF Flash ด้วย Java
linktitle: PowerPoint เป็น SWF
type: docs
weight: 80
url: /th/java/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น SWF
- การนำเสนอเป็น SWF
- สไลด์เป็น SWF
- PPT เป็น SWF
- PPTX เป็น SWF
- PowerPoint เป็น Flash
- การนำเสนอเป็น Flash
- สไลด์เป็น Flash
- PPT เป็น Flash
- PPTX เป็น Flash
- บันทึก PPT เป็น SWF
- บันทึก PPTX เป็น SWF
- ส่งออก PPT เป็น SWF
- ส่งออก PPTX เป็น SWF
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ด้วย Java และ Aspose.Slides. ตัวอย่างโค้ดทีละขั้น, ผลลัพธ์คุณภาพสูงและรวดเร็ว, ไม่ต้องอัตโนมัติ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงไฟล์นำเสนอ PowerPoint เป็น SWF โดยใช้ Aspose.Slides แสดงวิธีบันทึกการนำเสนอเป็นไฟล์ SWF ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) และวิธีกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/), รวมถึงการตั้งค่าผู้ชมและการจัดวางโน้ตหรือคอมเมนต์

## **แปลงการนำเสนอเป็น Flash**

เมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ที่เปิดให้ใช้งานโดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) สามารถใช้เพื่อแปลงการนำเสนอทั้งหมดเป็นเอกสาร **SWF** ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอเป็นเอกสาร **SWF** โดยใช้ตัวเลือกที่จัดให้โดยคลาส [**SWFOptions**](https://reference.aspose.com/slides/th/java/com.aspose.slides/SwfOptions) คุณยังสามารถรวมคอมเมนต์ใน SWF ที่สร้างขึ้นได้โดยใช้คลาส [**ISWFOptions**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISwfOptions) และอินเทอร์เฟซ [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/th/java/com.aspose.slides/INotesCommentsLayoutingOptions) 

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // บันทึกการนำเสนอ
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**Can I include hidden slides in the SWF?**  
ใช่. เปิดใช้งานสไลด์ที่ซ่อนอยู่โดยใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) ใน [SwfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/) ตามค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกส่งออก.

**How can I control compression and the final SWF size?**  
ใช้เมธอด [setCompressed](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) และ [adjust JPEG quality](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) เพื่อปรับสมดุลระหว่างขนาดไฟล์และคุณภาพภาพ.

**What is 'setViewerIncluded' for, and when should I disable it?**  
[setViewerIncluded](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) จะเพิ่ม UI ของผู้เล่นแบบฝัง (ปุ่มนำทาง, แพเนล, การค้นหา) ปิดการใช้งานหากคุณต้องการใช้ผู้เล่นของคุณเองหรือจำเป็นต้องมีกรอบ SWF ที่ไม่มี UI.

**What happens if a source font is missing on the export machine?**  
Aspose.Slides จะใช้ฟอนต์ที่คุณระบุผ่าน [setDefaultRegularFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ใน [SwfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/swfoptions/) เพื่อแทนที่ฟอนต์ที่หายไปและหลีกเลี่ยงการเปลี่ยนฟอนต์โดยไม่ตั้งใจ.