---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout บน Android
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารสรุป
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารสรุปใน Java ตั้งค่าจำนวนสไลด์ต่อหน้าเก็บบันทึกย่อ ส่งออกเป็น PDF หรือรูปภาพด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด ทดลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้าง handout สำหรับพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดวิธีที่หลายสไลด์ปรากฏบนหน้ากระดาษเดียว ทำให้เป็นประโยชน์สำหรับการประชุม สัมมนา และงานอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยตั้งค่าเมธอด `setSlidesLayoutOptions` ในอินเทอร์เฟซ [IPdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) 

เพื่อกำหนดขนาดหน้า handout และการวางแนวก่อนส่งออก โปรดดูที่ [Notes Page Size](/slides/th/androidjava/notes-size/)

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้ากระดาษเดียวและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
	// ตั้งค่าตัวเลือกการส่งออก.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 สไลด์บนหนึ่งหน้าตามแนวนอน
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // พิมพ์หมายเลขสไลด์
	slidesLayoutOptions.setPrintFrameSlide(true);                     // พิมพ์กรอบรอบสไลด์
	slidesLayoutOptions.setPrintComments(false);                      // ไม่มีคอมเมนต์

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// ส่งออกงานนำเสนอเป็น PDF ด้วยการจัดวางที่เลือก.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
โปรดทราบว่าเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะในรูปแบบเอาต์พุตบางประเภท เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นรูปภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อของสไลด์ต่อหน้ามากสุดในโหมด Handout คือเท่าใด?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/) สูงสุด 9 ภาพย่อต่อหน้าโดยจัดเรียงแบบแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง)

**ฉันสามารถกำหนดตารางแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่ได้ จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเคร่งครัดโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/) ไม่รองรับการจัดเรียงแบบอิสระ

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้ เปิดใช้สไลด์ที่ซ่อนอยู่โดยใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/)