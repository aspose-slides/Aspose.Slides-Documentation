---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย Java
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- Handout
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอเป็น Handout ด้วย Java ตั้งค่าจำนวนสไลด์ต่อหน้า รักษาโน้ต ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด Java ทดลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ให้คุณแปลงงานนำเสนอเป็นรูปแบบผลลัพธ์ที่รองรับโหมด Handout ในโหมดนี้ สไลด์หลายสไลด์จะถูกจัดเรียงบนหน้าเดียว ซึ่งมีประโยชน์สำหรับการพิมพ์วัสดุการนำเสนอสำหรับการประชุม สัมมนา และกิจกรรมที่คล้ายกัน

โหมด Handout ถูกกำหนดค่าผ่านเมธอด `setSlidesLayoutOptions` ซึ่งมีให้ใช้ใน [IPdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/). เพื่อกำหนดเค้าโครง handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/handoutlayoutingoptions/) 

เพื่อกำหนดขนาดและทิศทางของหน้าวัน handout ก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึกหมายเหตุ](/slides/th/java/notes-size/).

## **การส่งออกโหมด Handout**

เพื่อส่งออกงานนำเสนอในโหมด Handout ให้ตั้งค่าเมธอด `setSlidesLayoutOptions` สำหรับตัวเลือกการส่งออกเป้าหมายและกำหนดอินสแตนซ์ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/handoutlayoutingoptions/) ที่กำหนดจำนวนสไลด์ต่อหน้าและพารามิเตอร์การแสดงผลที่เกี่ยวข้อง

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ตั้งค่าตัวเลือกการส่งออก.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหน้าในแนวนอน
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // พิมพ์หมายเลขสไลด์
    slidesLayoutOptions.setPrintFrameSlide(true);                     // พิมพ์กรอบรอบสไลด์
    slidesLayoutOptions.setPrintComments(false);                      // ไม่มีคอมเมนต์

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // ส่งออกงานนำเสนอเป็น PDF ด้วยเค้าโครงที่เลือก.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
โปรดจำไว้ว่าเมธอด `setSlidesLayoutOptions` มีให้เฉพาะบางรูปแบบผลลัพธ์เท่านั้น เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าลในโหมด Handout คือเท่าใด?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/java/com.aspose.slides/handouttype/) ได้สูงสุด 9 ภาพย่อต่อหน้าโดยมีการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดกริดแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่. จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเคร่งครัดโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/handouttype/) ; การจัดวางแบบใดก็ได้ไม่รองรับ.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ใช่. เปิดใช้งานสไลด์ที่ซ่อนอยู่โดยใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/).