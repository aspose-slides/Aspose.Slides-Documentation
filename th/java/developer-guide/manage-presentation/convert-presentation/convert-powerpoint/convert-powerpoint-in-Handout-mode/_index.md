---
title: แปลงงานนำเสนอ PowerPoint เป็นโหมด Handout ด้วย Java
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/java/convert-powerpoint-in-Handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารสรุป
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารสรุปใน Java ตั้งค่าจำนวนสไลด์ต่อหน้า เก็บบันทึกย่อ ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด Java ลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณสามารถแปลงงานนำเสนอเป็นรูปแบบผลลัพธ์ที่รองรับโหมด Handout ได้ ในโหมดนี้สไลด์หลายสไลด์จะถูกจัดเรียงบนหน้าเดียว ซึ่งเป็นประโยชน์สำหรับการพิมพ์เอกสารงานนำเสนอสำหรับการประชุม สัมมนา และกิจกรรมคล้ายกัน

โหมด Handout สามารถกำหนดค่าได้ผ่านเมธอด `setSlidesLayoutOptions` ซึ่งมีใน [IPdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/). เพื่อกำหนดรูปแบบ handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/handoutlayoutingoptions/)

## **การส่งออกโหมด Handout**

เพื่อส่งออกงานนำเสนอในโหมด Handout ให้ตั้งค่าเมธอด `setSlidesLayoutOptions` สำหรับตัวเลือกการส่งออกเป้าหมายและกำหนดอินสแตนซ์ของ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/handoutlayoutingoptions/) ซึ่งระบุจำนวนสไลด์ต่อหน้าและพารามิเตอร์การแสดงผลที่เกี่ยวข้อง

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```java
// โหลดงานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ตั้งค่าตัวเลือกการส่งออก.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหน้าในแนวนอน
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // พิมพ์หมายเลขสไลด์
    slidesLayoutOptions.setPrintFrameSlide(true);                     // พิมพ์กรอบรอบสไลด์
    slidesLayoutOptions.setPrintComments(false);                      // ไม่แสดงความคิดเห็น

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // ส่งออกงานนำเสนอเป็น PDF ด้วยเค้าโครงที่เลือก.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 

โปรดทราบว่าเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะสำหรับรูปแบบผลลัพธ์บางอย่างเท่านั้น เช่น PDF, HTML, TIFF, และเมื่อเรนเดอร์เป็นรูปภาพ

{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพตัวอย่างสไลด์สูงสุดต่อหน้าที่รองรับในโหมด Handout คือเท่าใด?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/java/com.aspose.slides/handouttype/) สูงสุดถึง 9 ภาพตัวอย่างต่อหน้าโดยมีการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดกริดแบบกำหนดเองได้หรือไม่ เช่น 5 หรือ 8 สไลด์ต่อหน้า?**

ไม่ได้. จำนวนและการจัดเรียงของภาพตัวอย่างถูกควบคุมอย่างเข้มงวดโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/handouttype/); ไม่สนับสนุนการจัดวางแบบกำหนดเอง.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้สไลด์ที่ซ่อนอยู่โดยใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/).