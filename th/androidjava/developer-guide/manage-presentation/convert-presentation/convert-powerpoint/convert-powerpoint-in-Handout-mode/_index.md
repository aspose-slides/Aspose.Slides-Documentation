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
- เอกสารแจก
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารแจกใน Java ตั้งค่าจำนวนสไลด์ต่อหน้า รักษาบันทึก ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด ทดลองใช้งานฟรี"
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกสำหรับการพิมพ์ในโหมด Handout โมดนี้ช่วยให้คุณกำหนดว่าหลายสไลด์จะแสดงบนหน้าเดียวอย่างไร ทำให้เหมาะสำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้โดยตั้งค่าเมธอด `setSlidesLayoutOptions` ในอินเทอร์เฟซ [IPdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/)  

## **การส่งออกในโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handoutlayoutingoptions/) ที่กำหนดจำนวนสไลด์ที่จะวางบนหน้าเดียวและพารามิเตอร์การแสดงผลอื่น ๆ  

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout  

```java
// โหลดงานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
	// ตั้งค่าตัวเลือกการส่งออก.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 สไลด์ต่อหนึ่งหน้าในแนวนอน
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // พิมพ์หมายเลขสไลด์
	slidesLayoutOptions.setPrintFrameSlide(true);                     // พิมพ์กรอบรอบสไลด์
	slidesLayoutOptions.setPrintComments(false);                      // ไม่มีความเห็น

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// ส่งออกงานนำเสนอเป็น PDF ด้วยการจัดวางที่เลือก.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
โปรดทราบว่าเมธอด `setSlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบเอาต์พุตบางประเภท เช่น PDF, HTML, TIFF และเมื่อทำการเรนเดอร์เป็นรูปภาพ. 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อสไลด์สูงสุดต่อหน้าที่สามารถแสดงในโหมด Handout คือเท่าไร?**  

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).  

**ฉันสามารถกำหนดกริดแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**  

ไม่ได้ จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเคร่งครัดโดยคลาส [HandoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/handouttype/); ไม่รองรับการจัดวางแบบกำหนดเอง.  

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**  

ได้. เปิดใช้งานสไลด์ที่ซ่อนอยู่โดยใช้เมธอด `setShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/).